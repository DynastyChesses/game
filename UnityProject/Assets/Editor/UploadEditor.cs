using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.Build.Content;
using UnityEditor.Build.Pipeline;
using UnityEditor.Build.Reporting;
using Debug = UnityEngine.Debug;

public class UploadEditor
{
    // public static void CloseAllSublime()
    // {
    //     string[] ids = GameUtil.ExecuteBashCommand("pgrep sublime").Split("\n");
    //     
    //     if (ids.Length > 0)
    //     {
    //         Debug.Log($"======>{ids[0]}");
    //     }
    //     // if (ids.Length > 0)
    //     // {
    //     //     for (int i = 0; i < ids.Length; i++)
    //     //     {
    //     //         GameUtil.ExecuteBashCommand($"kill -9 {ids[i]}");
    //     //     }
    //     // }
    // }
    
    public static void ShowConfirmation(string title, string message, string ok, string no)
    {
        bool ret = EditorUtility.DisplayDialog(
            title,
            message,
            ok,
            no
        );
 
        if (ret)
        {
            // TODO
        }
        else
        {
            // TDDO
        }
    }

    public static void BuildAddressable()
    {
        AddressablesBuildMenuUpdateAPreviousBuild build = new AddressablesBuildMenuUpdateAPreviousBuild();
    }
    
    public static void ShowConfirmation(string title, string message, string ok)
    {
        bool ret = EditorUtility.DisplayDialog(
            title,
            message,
            ok
        );
    }

    public static string GetIP()
    {
        //
        string ip = "";
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var networkInterface in networkInterfaces)
        {
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
                var ipProperties = networkInterface.GetIPProperties();
                var ipAddresses = ipProperties.UnicastAddresses;
                foreach (var ipAddress in ipAddresses)
                {
                    if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        var ipv4Address = ipAddress.Address.ToString();
                        if (!ipv4Address.Equals("127.0.0.1"))
                        {
                            ip = ipv4Address;
                        }
                    }
                }
            }
        }

        return ip;
    }
    
    [MenuItem("Tools/Upload/Upload Dll", false, 1)]
    public static void Upload()
    {
        string platform = "";
        switch (EditorUserBuildSettings.activeBuildTarget)
        {
            case BuildTarget.Android:
                platform = "Android";
                break;
            case BuildTarget.iOS:
                platform = "iOS";
                break;
            case BuildTarget.StandaloneWindows:
                platform = "Win";
                break;
        }
        //
        if (platform != "")
        {
            // 读取编译的路径
            var dir = Directory.GetParent(Application.dataPath);
            string fileName = $"{dir.FullName}/HybridCLRData/HotUpdateDlls/{platform}/{GameConsts.DllName}.dll";
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    GameLaunch.UploadFile(GameConsts.OssPath, null, fileStream);
                }
                // 上传完成
                Debug.Log("上传DLL完成!!!!!!!!!!!!!!!");
            }
            else
            {
                Debug.LogError($"文件：{fileName} 不存在");
            }
        }
        
        // Hash
        switch (EditorUserBuildSettings.activeBuildTarget)
        {
            case BuildTarget.Android:
                platform = "Android";
                break;
            case BuildTarget.iOS:
                platform = "iOS";
                break;
            case BuildTarget.StandaloneWindows:
                platform = "Win";
                break;
        }
        //
        if (platform != "")
        {
            // 读取编译的路径
            var dir = Directory.GetParent(Application.dataPath);
            string fileName = $"{dir.FullName}/HybridCLRData/HotUpdateDlls/{platform}/{GameConsts.DllName}.dll";
            if (File.Exists(fileName))
            {
#if UNITY_EDITOR
                string hashStr = GameLaunch.GetMD5Hash(fileName);
                // 写入hash.txt
                string hashFile = $"{Application.persistentDataPath}/{GameConsts.platform}/hash.txt";
                if (!Directory.Exists($"{Application.persistentDataPath}/{GameConsts.platform}"))
                {
                    Directory.CreateDirectory($"{Application.persistentDataPath}/{GameConsts.platform}");
                }
                File.WriteAllText(hashFile, hashStr);
                // 自动上传
                using (FileStream fileStream = new FileStream(hashFile, FileMode.Open))
                {
                    GameLaunch.UploadFile($"game/{GameConsts.platform}/hash.txt", null, fileStream);
                }
                Debug.Log("上传Hash完成!!!!!!!!!!!!!!!");
#endif
            }
            else
            {
                Debug.LogError($"文件：{fileName} 不存在");
            }
        }
    }


    [MenuItem("Tools/Upload/Upload IP", false, 2)]
    public static void UploadIP()
    {
        string ip = GetIP();
        
        string platform = "";
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                platform = "Android";
                break;
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXEditor:
                platform = "iOS";
                break;
            case RuntimePlatform.WindowsEditor:
                platform = "Win";
                break;
        }
        
#if UNITY_EDITOR
        // 自动上传
        var IpFile = $"{Application.dataPath}/ip.txt";
        // 写入文件IP
        using (StreamWriter writer = new StreamWriter(IpFile))
        {
            writer.Write(ip);
        }
        
        if (File.Exists(IpFile))
        {
            using (FileStream fileStream = new FileStream(IpFile, FileMode.Open))
            {
                GameLaunch.UploadFile("game/ip.txt", null, fileStream);
            }
            // 删除文件
            Debug.Log("上传IP完成!!!!!!!!!!!!!!!");
            File.Delete(IpFile);
        }
        else
        {
            Debug.LogError($"The IP File:{IpFile} not exist!!");
        }
#endif
    }
    
    [MenuItem("Tools/Upload/Upload Language", false, 3)]
    public static void UploadLanguage()
    {
        // language hash
        
        
        Debug.LogError($"更新语言!");
        string platform = "";
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                platform = "Android";
                break;
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXEditor:
                platform = "iOS";
                break;
            case RuntimePlatform.WindowsEditor:
                platform = "Win";
                break;
        }
        string path = $"{Directory.GetParent(Application.dataPath)}/lang.csv";
        if (File.Exists(path))
        {
            // 多语言文件存在
            var arr = path.Split("/");
            var name = arr[^1];
            // 上传 
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                GameLaunch.UploadFile($"game/{platform}/{name}", null, fileStream);
            }
        }
        
        // 更新 Lang Hash
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                platform = "Android";
                break;
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXEditor:
                platform = "iOS";
                break;
            case RuntimePlatform.WindowsEditor:
                platform = "Win";
                break;
        }
        //
        if (platform != "")
        {
            // 读取最新的表数据
            if (File.Exists(path))
            {
#if UNITY_EDITOR
                string hashStr = GameLaunch.GetMD5Hash(path);
                // 写入 lang_hash.txt
                string hashFile = $"{Application.persistentDataPath}/lang_hash.txt";
                File.WriteAllText(hashFile, hashStr);
                // 自动上传
                using (FileStream fileStream = new FileStream(hashFile, FileMode.Open))
                {
                    GameLaunch.UploadFile("game/lang_hash.txt", null, fileStream);
                }
                Debug.Log("上传Lang Hash完成!!!!!!!!!!!!!!!");
#endif
            }
            else
            {
                Debug.LogError($"文件：{path} 不存在");
            }
        }
    }
    

    [MenuItem("Tools/Run Server", false, 100)]
    public static void RunServer()
    {
        // 后台运行服务器
        string basePath = $"{Directory.GetParent(Directory.GetParent(Application.dataPath).FullName)}/server/game/";
        string cmd = $"nohup ./skynet ./config.lua > log.log &:";
        GameUtil.ExecuteBashCommand(cmd, false, false, false, false, basePath);
        // Debug.LogError($"请在命令行执行:./skynet ./config.lua");
        ShowConfirmation("服务器", "服务器已经开启", "好的");
    }
    [MenuItem("Tools/Run Server", true, 100)]
    public static bool IsRunServerPortUsed()
    {
        // 判断 8001 端口
        var ret = GameUtil.ExecuteBashCommand("lsof -i:8001");
        if (string.IsNullOrEmpty(ret))
        {
            return true;
        }
        return false;
    }
    
    [MenuItem("Tools/Stop Server", false, 101)]
    public static void StopServer()
    {
        // 
        var ret = GameUtil.ExecuteBashCommand("lsof -i:8001");
        var list = GameUtil.GetValueByRegex("skynet  [0-9]+", ret);
        if (list.Count > 0)
        {
            string temp = list[0];
            temp = temp.Replace("skynet", "");
            temp = temp.Replace(" ", "");
            if (temp != "")
            {
                // kill
                GameUtil.ExecuteBashCommand($"kill -9 {temp}");
                ShowConfirmation("服务器", "服务器已经关闭", "好的");
            }
        }
    }
    [MenuItem("Tools/Stop Server", true, 101)]
    public static bool IsStopServerPortUsed()
    {
        // 判断 8001 端口
        var ret = GameUtil.ExecuteBashCommand("lsof -i:8001");
        if (!string.IsNullOrEmpty(ret))
        {
            return true;
        }
        return false;
    }
    
    // [MenuItem("Tools/Open Server Log", false, 103)]
    // public static void OpenServerLog()
    // {
    //     // pgrep sublime
    //     CloseAllSublime();
    //     // 
    //     string basePath = $"{Directory.GetParent(Directory.GetParent(Application.dataPath).FullName)}/server/game/";
    //     GameUtil.ExecuteBashCommand($"nohup /Applications/Sublime\\ Text.app/Contents/MacOS/sublime_text --launch-or-new-window ./log.log > tmp &:", false, false, false, false, basePath);
    // }
    //
    // [MenuItem("Tools/编辑协议", false, 104)]
    // public static void EditorPB()
    // {
    //     CloseAllSublime();
    //     // 
    //     string basePath = $"{Directory.GetParent(Directory.GetParent(Application.dataPath).FullName)}/server/game/";
    //     GameUtil.ExecuteBashCommand($"nohup /Applications/Sublime\\ Text.app/Contents/MacOS/sublime_text --launch-or-new-window ./pb/message.proto > tmp &:", false, false, false, false, basePath);
    // }
    //
    // [MenuItem("Tools/处理协议ID", false, 105)]
    // public static void EditorPBID()
    // {
    //     CloseAllSublime();
    //     // 
    //     string basePath = $"{Directory.GetParent(Directory.GetParent(Application.dataPath).FullName)}/server/game/";
    //     GameUtil.ExecuteBashCommand($"nohup /Applications/Sublime\\ Text.app/Contents/MacOS/sublime_text --launch-or-new-window ./lualib/messagedefine.lua > tmp &:", false, false, false, false, basePath);
    // }
    //
    // [MenuItem("Tools/编译协议", false, 106)]
    // public static void CompilePB()
    // {
    //     CloseAllSublime();
    //     // 
    //     string basePath = $"{Directory.GetParent(Directory.GetParent(Application.dataPath).FullName)}/server/game/";
    //     GameUtil.ExecuteBashCommand($"nohup sh ./pb/gen.sh > tmp &:", false, false, false, false, basePath);
    // }
    //
    // [MenuItem("Tools/编辑服务器", false, 107)]
    // public static void EditorServer()
    // {
    //     CloseAllSublime();
    //     // 
    //     string basePath = $"{Directory.GetParent(Directory.GetParent(Application.dataPath).FullName)}/server/game/";
    //     GameUtil.ExecuteBashCommand($"nohup /Applications/Sublime\\ Text.app/Contents/MacOS/sublime_text --launch-or-new-window ./main.lua > tmp &:", false, false, false, false, basePath);
    // }
    
    [MenuItem("Tools/上传线上服务", false, 108)]
    public static void UploadServer()
    {
        // TODO
    }
    
    [MenuItem("Tools/上传线上服务", true, 108)]
    public static bool UploadServerJudge()
    {
        // TODO
        return false;
    }
    

    /// <summary>
    /// TODO
    /// </summary>
    [MenuItem("Tools/Upload/Upload Res", true, 1000)]
    public static void UploadRes()
    {
        string platform = "";
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                platform = "Android";
                break;
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXEditor:
                platform = "iOS";
                break;
            case RuntimePlatform.WindowsEditor:
                platform = "Win";
                break;
        }
        string path = $"{Directory.GetParent(Application.dataPath)}/ServerData/{platform}";
        // 获取目录下所有文件
        var paths = Directory.GetFiles(path);
        for (int i = 0; i < paths.Length; i++)
        {
            if (!paths[i].Contains(".DS_Store"))
            {
                if (File.Exists(paths[i]))
                {
                    var arr = paths[i].Split("/");
                    var Name = arr[arr.Length - 1];
                    // 上传 
                    using (FileStream fileStream = new FileStream(paths[i], FileMode.Open))
                    {
                        GameLaunch.UploadFile($"game/{platform}/{Name}", null, fileStream);
                        Debug.Log($"Upload File:game/{platform}/{Name}");
                    }
                }
                
            }
        }
    }

}