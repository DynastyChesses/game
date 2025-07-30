using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PureMVC.Patterns;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UObject = UnityEngine.Object;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.Initialization;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Profiling;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.U2D;
using Object = UnityEngine.Object;

public class AssetMgr : MonoSingleton<AssetMgr>
{
    Dictionary<string, object> componentHandleCache = new Dictionary<string, object>();
    Dictionary<string, Type> componentTypeCache = new Dictionary<string, Type>();
    // 
    public IEnumerator DownloadOrLoad(List<string> labels, bool isClear = false)
    {
        while (!Caching.ready)
        {
            yield return new WaitForEndOfFrame();
        }
        // 测试下载
        if (isClear)
        {
            // 强行清理本地缓存
            Caching.ClearCache();
        }
        
        bool downFailed = false;
        // 下载资源判断
        var sizeHandle = Addressables.GetDownloadSizeAsync(labels);
        yield return sizeHandle;
        if (sizeHandle.Status != AsyncOperationStatus.Succeeded)
        {
            // 发起通知下载失败
            ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLOAD_SIZE_FAILED, sizeHandle.OperationException.ToString());
            yield break;
        }
        
        long totalDownloadSize = sizeHandle.Result;
        Debug.Log("即将下载：" + totalDownloadSize);
        if (totalDownloadSize > 0)
        {
            // 通知总大小
            ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLOADING_TOTAL_SIZE, totalDownloadSize);
            // 下载
            var downloadHandle = Addressables.DownloadDependenciesAsync(labels, true);
            while (!downloadHandle.IsDone)
            {
                if (downloadHandle.Status == AsyncOperationStatus.Failed)
                {
                    ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLOAD_FAILED, downloadHandle.OperationException.ToString());
                    yield break;
                }
                // 下载进度
                float percentage = downloadHandle.PercentComplete;
                ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLOADING_PERCENT, percentage);
                yield return null;
            }
            // 下载成功后通过状态机 进入
            ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLOAD_SUCCESS);
        }
        
        // 加载缓存
        for (int i = 0; i < labels.Count; i++)
        {
            var locations = Addressables.LoadResourceLocationsAsync(labels[i]);
            yield return locations;
            // 则进行缓存
            var totalResCount = locations.Result.Count;
            var finisResCount = 0;
            foreach (IResourceLocation location in locations.Result)
            {
                // Debug.LogError($"加载资源{location.ResourceType}，类别为:{location.InternalId}");
                AsyncOperationHandle handle;
                if (location.ResourceType == typeof(GameObject) || location.ResourceType.BaseType == typeof(GameObject))
                {
                    // GameObject
                    handle = Addressables.LoadAssetAsync<GameObject>(location);
                }
                else if (location.ResourceType == typeof(ScriptableObject) || location.ResourceType.BaseType == typeof(ScriptableObject))
                {
                    // 数据
                    handle = Addressables.LoadAssetAsync<ScriptableObject>(location);
                }
                else if (location.ResourceType == typeof(Material) ||
                         location.ResourceType.BaseType == typeof(Material))
                {
                    // 材质
                    handle = Addressables.LoadAssetAsync<Material>(location);
                }
                else if (location.ResourceType == typeof(Shader) ||
                         location.ResourceType.BaseType == typeof(Shader))
                {
                    // Shader
                    handle = Addressables.LoadAssetAsync<Shader>(location);
                }
                else if (location.ResourceType == typeof(TextAsset) ||
                         location.ResourceType.BaseType == typeof(TextAsset))
                {
                    // TextAsset
                    handle = Addressables.LoadAssetAsync<TextAsset>(location);
                }
                else if (location.ResourceType == typeof(Texture) ||
                         location.ResourceType.BaseType == typeof(Texture))
                {
                    // Texture
                    handle = Addressables.LoadAssetAsync<Texture>(location);
                }
                else if (location.ResourceType == typeof(SpriteAtlas) ||
                         location.ResourceType.BaseType == typeof(SpriteAtlas))
                {
                    // SpriteAtlas
                    handle = Addressables.LoadAssetAsync<SpriteAtlas>(location);
                }
                else if (location.ResourceType == typeof(AnimationClip) ||
                         location.ResourceType.BaseType == typeof(AnimationClip))
                {
                    // AnimationClip
                    handle = Addressables.LoadAssetAsync<AnimationClip>(location);
                }
                else if (location.ResourceType == typeof(AudioClip) ||
                         location.ResourceType.BaseType == typeof(AudioClip))
                {
                    // AudioClip
                    handle = Addressables.LoadAssetAsync<AudioClip>(location);
                }
                else
                {
                    // 其他为Object
                    handle = Addressables.LoadAssetAsync<Object>(location);
                }
                
                handle.Completed += obj => {
                    componentHandleCache[location.InternalId] = handle;
                    componentTypeCache[location.InternalId] = location.ResourceType;
                    if (handle.Status == AsyncOperationStatus.Failed)
                    {                        
                        downFailed = true;
                        // 通知资源缓存失败
                        ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLAOD_CACHEING_FAILED, handle.OperationException.ToString());
                    }
                    if (handle.Status == AsyncOperationStatus.Succeeded)
                    {
                        // 通知资源缓存成功
                        ApplicationFacade.instance.SendNotification(NotificationConst.DOWNLAOD_CACHEING_SUCCESS, location.InternalId);
                    }
                    finisResCount++;
                };
            }
            while (finisResCount != totalResCount)
            {
                yield return new WaitForFixedUpdate();
            }
        }
        if (downFailed)
        {
            // 资源加载失败
            ApplicationFacade.instance.SendNotification(NotificationConst.RESOURCE_LOADED_ERROR);
        }
        else
        {
            // 资源加载完成
            ApplicationFacade.instance.SendNotification(NotificationConst.RESOURCE_LOADED_SUCCESS);
        }
    }
}







/// <summary>
/// 资源==================================================================================
/// </summary>


public class ResourceFacade : DefaultFacadeImpl
{
    private static readonly object _staticSyncRoot = new object();
    
    private static ResourceFacade _instance;
    public static  ResourceFacade instance
    {
        get 
        {
            if (_instance == null)
            {
                lock (_staticSyncRoot)
                {
                    if (_instance == null) 
                    {
                        _instance = new ResourceFacade();
                        Facade.implement = _instance;
                    }
                }
            }
			
            return _instance;
        }
    }
    private AsyncOperationHandle downloader;


    private void OnError(string log)
    {
        Debug.LogError(log);
    }


    #region Fields
        
        private static List<UObject> _autoUnloadList = new List<UObject>();

        private AbstractResourceFacadeImpl _impl;
        private string _prefabPathPrefix;
        private Dictionary<string, string> _idConvertCacheMap = new Dictionary<string, string>(200);

        private Dictionary<Type, ResourceType> _typeResTypeMap = new Dictionary<Type, ResourceType>()
        {
            {typeof(GameObject), ResourceType.Prefab},
            {typeof(Material), ResourceType.Material},
            {typeof(Shader), ResourceType.Shader},
            {typeof(TextAsset), ResourceType.TextAsset},
            {typeof(Texture), ResourceType.Texture},
            {typeof(SpriteAtlas), ResourceType.SpriteAtlas},
            {typeof(RuntimeAnimatorController), ResourceType.AnimatorController},
            {typeof(AnimatorOverrideController), ResourceType.AnimatorOverrideController},
            {typeof(AnimationClip), ResourceType.AnimationClip},
            {typeof(ScriptableObject), ResourceType.Scriptable},
            {typeof(AudioClip), ResourceType.AudioClip}
        };
        
        #endregion

        #region Public Static Methods

        public static void AddAutoUnloadObject(UObject go)
        {
            if (go)
            {
                _autoUnloadList.Add(go);
            }
        }

        public static void RemoveAutoUnloadObject(UObject go)
        {
            if (go)
            {
                _autoUnloadList.Remove(go);
            }
        }

        public static void ClearAutoUnloadObjects()
        {
            int count = _autoUnloadList.Count;

            for (int i = 0; i < count; ++i)
            {
                UObject autoUnload = _autoUnloadList[i];
                if (autoUnload)
                {
                    _instance.Unload(autoUnload);
                }
            }

            _autoUnloadList.Clear();
        }

        public static void GC(bool clearUnHandleResources = true)
        {
            Profiler.BeginSample("ResFacade.GC");
            AbstractResourceFacadeImpl impl = instance._impl;
            // TODO
            Profiler.EndSample();
            System.GC.Collect();
        }

        public static GameObject Instantiate(GameObject original)
        {
            return _instance.InstantiateImpl(original) as GameObject;
        }
        
        public static UObject Instantiate(UObject original)
        {
            return _instance.InstantiateImpl(original);
        }
        
        public static GameObject NewGameObject(string name = "")
        {
            return _instance.NewGameObjectImpl(name);
        }
        
        public static GameObject NewGameObjectWithoutRef(string name = "")
        {
            return new GameObject(name);
        }

        public static void Destroy(UnityEngine.Object obj)
        {
            _instance.DestroyImpl<UObject>(obj);
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// 初始化实际使用的资源模式
        /// </summary>
        /// <param name="initConfig"></param>
        public void Initialize(IResourceInitConfig initConfig)
        {
            if (_impl != null)
            {
                _impl.Dispose();
                _impl = null;
            }
            AssetActionLogger.Init();
            this._prefabPathPrefix = initConfig.prefabPathPrefix;
            this._impl = new BundleResourceFacadeImpl();
            this._impl.Initialize(initConfig);
        }

        public void Dispose()
        {
            _shaderCache.Clear();
            if (this._impl != null)
            {
                this._impl.Dispose();
                this._impl = null;
            }
            AssetActionLogger.Dispose();
        }
        
        // 加载各种类别的范型函数
        public void LoadObjectAsync<T>(string localPath, Func<T, int> callback)
        {
            var req = Addressables.LoadAssetAsync<T>(localPath);
            req.Completed += handle =>
            {
                callback.Invoke(handle.Result);
            };
        }
        
        
        public IAsyncResourceRequest LoadObjectAsync<T>(string localPath, string prefix = "")
        {
            return LoadObjectAsync<T>(localPath, prefix, 0);
        }

        /// <summary>
        /// 即使加载失败，仍然对外执行回调，这里只是 Prefab****
        /// </summary>
        /// <param name="localPath"></param>
        /// <param name="overrideExtension"></param>
        /// <param name="type"></param>
        /// <param name="prefix"></param>
        /// <param name="priority"></param>
        /// <returns>回调执行后，request会被dispose，不可再使用</returns>
        public IAsyncResourceRequest LoadObjectAsync<T>(string localPath, string overrideExtension,
            string prefix, int priority)
        {
            Type type = typeof(T);
            if (!_typeResTypeMap.TryGetValue(type, out var resType))
            {
                resType = ResourceType.Other;
            }
            string extension;
            bool create;
            DetermineLoadParams(resType, overrideExtension, out extension, out create);
            string id = GetPathID(prefix, localPath, extension, true);
            var request = _impl.LoadObjectAsync<T>(id, create, priority);
            return request;
        }
        
        public IAsyncResourceRequest LoadObjectAsync<T>(string localPath, string prefix,int priority)
        {
            return LoadObjectAsync<T>(localPath, null, prefix, priority);
        }

        public IAsyncResourceRequest LoadPrefabAsync(string localPath)
        {
            return LoadPrefabAsync(localPath, 0);
        }
        public IAsyncResourceRequest LoadPrefabAsync(string localPath, int priority)
        {
            return LoadObjectAsync<GameObject>(localPath, _prefabPathPrefix, priority);
        }
        
        
        public void Unload(UObject obj)
        {
            DestroyImpl<UObject>(obj);
        }
        public void Unload(GameObject gameObject)
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                gameObject.transform.SetParent(null);
                gameObject.transform.position = Vector3.one * 9999;
                DestroyImpl<GameObject>(gameObject);
            }
            
        }
        public void Unload(Texture2D texture2D)
        {
            // 废除引用计数
            DestroyImpl<Texture2D>(texture2D);
        }
        public void Unload(TextAsset textAsset)
        {
            DestroyImpl<TextAsset>(textAsset);
        }
        public void Unload(Material material)
        {
            DestroyImpl<Material>(material);
        }

        
        
        Dictionary<string,Shader> _shaderCache = new Dictionary<string, Shader>();

        #endregion

        #region Private Methods

        /// <summary>
        /// 基于实例化对象再次实例化，需要找到源资源处理计数
        /// </summary>
        /// <param name="original">已经实例化的对象</param>
        /// <returns></returns>
        private UObject InstantiateImpl(UObject original)
        {
            // if (_impl == null)
            // {
            //     Debug.LogError("Invoke \"Instantiate\" on uninitialized ResourceFacade");
            //     return null;
            // }
            if (original != null)
            {
                // 如何实例化 TODO
                return UObject.Instantiate(original);
            }
            
            return null;
        }

        private GameObject NewGameObjectImpl(string name = "")
        {
            if (_impl == null)
            {
                Debug.LogWarning("Invoke \"Create GameObject\" on uninitialized ResourceFacade");
                return null;
            }
            
            return _impl.NewGameObject(name);
        }

        private void DestroyImpl<T>(object obj, float delayTime = 0)
        {
            if (_impl == null)
            {
#if UNITY_EDITOR
                UObject.Destroy((UObject)obj);
#endif
                Debug.LogWarning("Invoke \"Destroy\" on uninitialized ResourceFacade");
                return;
            }
            _impl.Destroy<T>(obj, true, delayTime);
        }

        private string GetPathID(string prefix, string localPath, string extension, bool useCache)
        {
            string result;
            if (!useCache || !_idConvertCacheMap.TryGetValue(localPath, out result))
            {
                result = _impl.GenerateLoadURL(prefix, localPath, extension);
                if (useCache)
                {
                    _idConvertCacheMap.Add(localPath, result);
                }
            }
            return result;
        }

        private void DetermineLoadParams(ResourceType type, string overrideExtension, out string extension, out bool instantiated)
        {
            instantiated = false;
            switch (type)
            {
                case ResourceType.Prefab:
                    extension = ".prefab";
                    instantiated = true;
                    break;
                case ResourceType.Material:
                    extension = ".mat";
                    break;
                case ResourceType.Shader:
                    extension = ".shader";
                    break;
                case ResourceType.Texture:
                    extension = ".tex";
                    break;
                case ResourceType.TextAsset:
                    extension = ".txt";
                    break;                
                case ResourceType.SpriteAtlas:
                    extension = ".spriteatlasv2";
                    break;
                case ResourceType.AnimatorOverrideController:
                    extension = ".overrideController";
                    break;
                case ResourceType.AnimatorController:
                    extension = ".controller";
                    break;
                case ResourceType.Scriptable:
                    extension = ".asset";
                    break;
                case ResourceType.AudioClip:
                    extension = "";
                    break;
                default:
                    extension = ".asset";
                    break;
            }

            extension = overrideExtension ?? extension;
        }

        #endregion
}
