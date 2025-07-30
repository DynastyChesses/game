using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Aliyun.OSS;
using osP1.Helper;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Debug = UnityEngine.Debug;

public class GameLaunch : MonoSingleton<GameLaunch>
{
    private GameObject _ui = null;
    private Transform _pool = null;
    public GameObject ui
    {
        get
        {
            return _ui;
        }
    }

    public Transform pool
    {
        get
        {
            return _pool;
        }
    }

    
    public static List<string> files = new List<string>()
    {
        // 需要下载的文件列表
    };
    
    // 全局的LateUpdate
    private Dictionary<string, Action> updateEvent = new Dictionary<string, Action>();
    
    // 注册
    public void RegisterUpdate(string name, Action func)
    {
        if (!updateEvent.ContainsKey(name))
        {
            updateEvent[name] = func;
        }
    }
    
    // 反注册
    public void UnRegisterUpdate(string name)
    {
        if (updateEvent.ContainsKey(name))
        {
            updateEvent.Remove(name);
        }
    }

    public static string GetMD5Hash(string filePath)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
            }
        }
    }

    Assembly hotUpdateAss = null;
    
    private static void ConfigureResourceFacade()
    {
        // 暂时不做版本比对 
        IResourceInitConfig resConfig = null;
        // 直接定义AB模式
        resConfig = new AssetBundleInitConfig();
        // 模拟Config 
        var config = new AssetConfig();
        config.version = GameConsts.configVersion;
        config.resList = new AssetList();
        (resConfig as AssetBundleInitConfig).config = config;
        // CDN 配置不用理会
        ResourceFacade.instance.Initialize(resConfig);
        EquineMonoDispatcher.onApplicationQuit += (ResourceFacade.instance.Dispose);
    }
    
    private void LoadMain()
    {
        // Debug.LogError($"Application.identifier:{Application.identifier}");
        if (hotUpdateAss != null)
        {
            // 其他初始化过程
            // 初始化资源配置
            ConfigureResourceFacade();
            Type type = hotUpdateAss.GetType(GameConsts.Main);
            type.GetMethod(GameConsts.MainFunction).Invoke(null, new []{_ui});
        }
    }
    
    // 多个文件地址
    private IEnumerator Download(string downloadPath = "", Action cb = null)
    {
        if (string.IsNullOrEmpty(downloadPath))
        {
            downloadPath = GameConsts.OssPath;
        }
        string subFileName = downloadPath.Split('/')[^1] ?? "";
        // 进行下载
        if (!string.IsNullOrEmpty(subFileName))
        {
            using (UnityWebRequest wr = UnityWebRequest.Get($"{GameConsts.OssUrl}{downloadPath}"))
            {
                yield return wr.SendWebRequest();
                if (wr.result == UnityWebRequest.Result.Success)
                {
                    byte[] data = wr.downloadHandler.data;
                    // 写入文件
                    string fileName = $"{Application.persistentDataPath}/{subFileName}";
 
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter(fileStream))
                        {
                            writer.Write(data);
                        }
                    }
                    // 完成
                    if (downloadPath.EndsWith("dll.bytes"))
                    {
                        hotUpdateAss = Assembly.Load(File.ReadAllBytes(fileName));
                        LoadMain();
                    }
                    // 计算 Hash
                    // string hashStr = GetMD5Hash(fileName);
                    // Debug.LogError("The Hash Code:" + hashStr);
                    // 下载文件
                    Debug.LogError($"下载:{downloadPath}完成 ！！");
                    if (cb != null)
                    {
                        cb.Invoke();
                    }
                }
                else
                {
                    // 错误
                    Debug.LogError($"下载:{downloadPath}错误!!!!");
                    if (downloadPath.EndsWith("dll.bytes"))
                    {
                        // 直接进入旧版本
                        string fileName = $"{Application.persistentDataPath}/{subFileName}";
                        if (File.Exists(fileName))
                        {
                            hotUpdateAss = Assembly.Load(File.ReadAllBytes(fileName));
                            LoadMain();
                        }
                    }
                }
            }   
        }
    }
    
    
    // 增加通用文件下载
    private IEnumerator DownloadCustomHashFile(string old_hash, string fileName, Action cb)
    {
        // 判断 Hash文件一致性
        // 拆分文件
        Debug.LogError($"fileName:{fileName}");
        string[] filesName = fileName.Split('.');
        var url = $"{GameConsts.OssUrl}{filesName[0]}_hash.{filesName[1]}";
        Debug.LogError($"即将检测Hash文件:{url}!!");
        using (UnityWebRequest wr =
               UnityWebRequest.Get(url))
        {
            yield return wr.SendWebRequest();
            if (wr.result == UnityWebRequest.Result.Success)
            {
                if (wr.downloadHandler.text != old_hash)
                {
                    // 需要下载
                    yield return Download(fileName);
                }
                else
                {
                    Debug.LogError($"已经存在最新的文件{fileName}!!");
                    if (cb != null)
                    {
                        cb.Invoke();
                    }
                }
            }
            else
            {
                if (cb != null)
                {
                    cb.Invoke();
                }
            }
        }
    }
    
    // 文件下载
    private IEnumerator DownloadLangHashFile(string old_hash, Action cb)
    {
        // 判断 Hash文件一致性
        using (UnityWebRequest wr =
               UnityWebRequest.Get($"{GameConsts.OssUrl}{GameConsts.LangHashPath}"))
        {
            yield return wr.SendWebRequest();
            if (wr.result == UnityWebRequest.Result.Success)
            {
                if (wr.downloadHandler.text != old_hash)
                {
                    // 需要下载
                    yield return Download(GameConsts.LangResPath);
                }
                else
                {
                    if (cb != null)
                    {
                        cb.Invoke();
                    }
                }
            }
            else
            {
                if (cb != null)
                {
                    cb.Invoke();
                }
            }
        }
    }
    
    private IEnumerator DownloadHashFile(string old_hash, Action cb)
    {
        // 判断 Hash文件一致性
        using (UnityWebRequest wr =
               UnityWebRequest.Get($"{GameConsts.OssUrl}{GameConsts.HashPath}"))
        {
            yield return wr.SendWebRequest();
            if (wr.result == UnityWebRequest.Result.Success)
            {
                if (wr.downloadHandler.text != old_hash)
                {
                    // 需要下载
                    yield return Download();
                }
                else
                {
                    if (cb != null)
                    {
                        cb.Invoke();
                    }
                }
            }
            else
            {
                if (cb != null)
                {
                    cb.Invoke();
                }
            }
        }
    }
    
    // 增加自定义Hash文件检测
    private void checkCustomHashAndDownload(string fileName)
    {
        // 更新Lang
        string langFileName = fileName.Split("/")[^1];
        string fileLocalName = $"{Application.persistentDataPath}/{langFileName}";
        
        Debug.LogError($"即将下载文件:{fileName}");
        
        if (!File.Exists(fileLocalName))
        {
            StartCoroutine(Download(fileName));
            return;
        }
        else
        {
            string hashStr = GetMD5Hash(fileLocalName);
            StartCoroutine(DownloadCustomHashFile(hashStr,  fileName,null));
        }
    }
    
    
    // 开启一个协程把控一个文件Stream
    private IEnumerator RunServerLog()
    {
        // TODO
        #if UNITY_EDITOR
        // 可以读取 Log
        Debug.Log($"可以读取Log日志");
        #endif
        yield return null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("UIContainer");
        _pool = _ui.transform.Find("Pool");
        if (GraphicsSettings.renderPipelineAsset is UniversalRenderPipelineAsset)
        {
            Debug.Log($"【当前项目】：「URP」".ToRed());
        }
        else
        {
            Debug.Log($"【当前项目】：非「URP」".ToRed());
        }
        
#if UNITY_EDITOR_OSX
        // Editor情况下监控且本地服务器开启的情况下监控Server日志
        // 判断服务器本地开启？
        var ret = GameUtil.ExecuteBashCommand("lsof -i:8001");
        var list = GameUtil.GetValueByRegex("skynet  [0-9]+", ret);
        if (list.Count > 0)
        {
            // 监控下 Server 的 log.log
            StartCoroutine(RunServerLog());
        }
#endif
        
        RealTimer.Reset();
        UniqueMonoEventListener.instance.onApplicationQuit += BeforeApplicationQuit;
        
        // 暂时不需要更新
        // if (Application.internetReachability != NetworkReachability.NotReachable)
        // {
        //     // 更新Lang
        //     string langFileName = GameConsts.LangResPath.Split("/")[^1];
        //     string fileLangName = $"{Application.persistentDataPath}/{langFileName}";
        //     if (!File.Exists(fileLangName))
        //     {
        //         StartCoroutine(Download(GameConsts.LangResPath));
        //         return;
        //     }
        //     else
        //     {
        //         string hashStr = GetMD5Hash(fileLangName);
        //         StartCoroutine(DownloadLangHashFile(hashStr, null));
        //     }
        //     
        //     // 更新自定义文件
        //     for (int i = 0; i < files.Count; i++)
        //     {
        //         checkCustomHashAndDownload(files[i]);
        //     }
        // }
        
        
        // Editor环境下，HotUpdate.dll.bytes已经被自动加载，不需要加载，重复加载反而会出问题。
#if !UNITY_EDITOR
        string dllFileName = GameConsts.OssPath.Split("/")[^1];
        string fileName = $"{Application.persistentDataPath}/{dllFileName}";
        if (!File.Exists(fileName))
        {
            StartCoroutine(Download());
            return;
        }
        else
        {
            string hashStr = GetMD5Hash(fileName);
            StartCoroutine(DownloadHashFile(hashStr, () =>
            {
                // 直接加载
                hotUpdateAss = Assembly.Load(File.ReadAllBytes(fileName));
                LoadMain();
            })) ;
        }
#else
        RunGame();
#endif
    }
    
    private void BeforeApplicationQuit()
    {
        if (hotUpdateAss != null)
        {
            Debug.Log("Quit");
            //
            Type type = hotUpdateAss.GetType(GameConsts.Main);
            type.GetMethod(GameConsts.CleanUp)?.Invoke(null, null);
            hotUpdateAss = null;
        }
    }
    
    // 增加通用的 StartCoroutine
    public void RunCoroutine(IEnumerator itor)
    {
        StartCoroutine(itor);
    }
    

    private void RunGame()
    {
        hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(assembly => assembly.GetName().Name == GameConsts.DllName);
        LoadMain();
    }

    
    public static bool UploadFile(string key, string fileExt, Stream fileStream)
    {
        var result = true;
        try
        {
            key = $"{Application.identifier}/{key}";
            Debug.LogError($"上传Key:{key}");
            var client = new OssClient(OssConfig.endpoint, OssConfig.accessKeyId, OssConfig.accessKeySecret);
            client.PutObject(OssConfig.bucketName, key, fileStream);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.ToString());
            result = false;
        }
        return(result);
    }

    // LateUpdate
    private void LateUpdate()
    {
        if (updateEvent != null)
        {
            foreach (var item in updateEvent)
            {
                item.Value.Invoke();
            }
        }
    }
    
    // 获取自定义下载的文件内容
    public string getCustomFileContent(string name)
    {
        if (files.Contains(name))
        {
            var fileName = name.Split("/")[^1];
            string fileLocalName = $"{Application.persistentDataPath}/{fileName}";
            return File.ReadAllText(fileLocalName);
        }

        return "";
    }
    
    private void OnDestroy()
    {
        ApplicationFacade.instance.SendNotification(GameConsts.Destroy);
        EquineMonoDispatcher.onApplicationQuit -= (ResourceFacade.instance.Dispose);
    }
    
    //
    public static string GetMemoryValue(string key)
    {
        return MemoryEnvironment.GetValue(key);
    }

    public static void SetMemoryValue(string key, string value)
    {
        MemoryEnvironment.SetValue(key, value);
    }

    public static bool DeleteMemoryValue(string key)
    {
        return MemoryEnvironment.DeleteValue(key);
    }

    public static bool HasMemoryValue(string key)
    {
        return MemoryEnvironment.HasValue(key);
    }

    public static string[] GetMemoryKeys()
    {
        return MemoryEnvironment.GetKeys();
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
