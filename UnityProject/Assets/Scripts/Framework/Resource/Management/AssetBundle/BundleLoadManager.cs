using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;
using UObject = UnityEngine.Object;

public class BundleLoadManager
{
    private static BundleLoadManager _instance = new BundleLoadManager();

    public static BundleLoadManager instance
    {
        get { return _instance; }
    }

    private Dictionary<string, BundleLoadHandle> _handleMap = new Dictionary<string, BundleLoadHandle>();

    private List<SearchPath> _searchPaths = new List<SearchPath>();

    private IBundleFileMapper _mapper = null;

    public List<SearchPath> searchPaths
    {
        get => _searchPaths;
        set => _searchPaths = value;
    }

    public void Initialize(List<SearchPath> searchPaths, IBundleFileMapper mapper)
    {
        _searchPaths = searchPaths;
        _mapper = mapper;
    }

    public IBundleFileMapper mapper
    {
        get => _mapper;
        set => _mapper = value;
    }

    private const bool _localStreamMode =
#if UNITY_WEBGL
        true;
#else            
        false;
#endif

    public BundleLoadHandle LoadBundle(string url, string md5 /*, string assetId*/)
    {
        return LoadBundleImpl(url, md5, false);
    }

    public BundleLoadHandle LoadBundleAsync(string url, string md5)
    {
        return LoadBundleImpl(url, md5, true);
    }

    public BundleLoadHandle LoadBundleImpl(string url, string md5, bool async)
    {
        BundleLoadHandle handle;
        if (!_handleMap.TryGetValue(url, out handle))
        {
            AssetBundleCreateRequest bundleRequest = null;
            AssetBundle bundle = null;
            bool searchPathWritable = false;
            Stream stream = null;
            
            // 因为使用的是 Addressable 所以不用走下面流程 
            // var searchPath = SearchBundleActualPath(url, md5, out string fullPath, out int offset);
            // if (searchPath != null)
            // {
            //     searchPathWritable = searchPath.writable;
            //     try
            //     {
            //         var sd = AssetActionLogger.GetActionStartData();
            //         Profiler.BeginSample(url);
            //         if (!_localStreamMode)
            //         {
            //             if (async)
            //                 bundleRequest = AssetBundle.LoadFromFileAsync(fullPath, 0, (ulong)offset);
            //             else
            //                 bundle = AssetBundle.LoadFromFile(fullPath, 0, (ulong)offset);
            //         }
            //         else
            //         {
            //             // 微信小游戏实测用openSync同时打开的文件不能超过20，所以用同步一次全读到内存的方式
            //             bool useMemoryStream = true;
            //             if (useMemoryStream)
            //             {
            //                 var bytes = searchPath.storageImpl.ReadAllBytes(fullPath);
            //                 stream = new MemoryStream(bytes);
            //             }
            //             else
            //             {
            //                 stream = searchPath.storageImpl.OpenRead(fullPath);
            //             }
            //                 
            //             if (offset > 0)
            //             {
            //                 stream.Seek(offset, SeekOrigin.Begin);
            //             }
            //
            //             if (async)
            //                 bundleRequest = AssetBundle.LoadFromStreamAsync(stream);
            //             else
            //                 bundle = AssetBundle.LoadFromStream(stream);
            //         }
            //
            //         Profiler.EndSample();
            //         // 异步没在完成时记录，先临时这么用
            //         AssetActionLogger.RecordAction(sd, url, 
            //             async ? AssetBundleActionType.BundleLoadAsync : AssetBundleActionType.BundleLoad);
            //     }
            //     catch (Exception e)
            //     {
            //         Debug.LogError(fullPath);
            //         Debug.LogException(e);
            //     }
            // }
            //
            // if (bundleRequest == null && bundle == null)
            // {
            //     Debug.LogError($"LoadBundleImpl failed: async={async}, url={fullPath}, searchPath={searchPath?.prefix}");
            //     // if (searchPathWritable)
            //     //     (searchPath.storageImpl as IReadWriteStorageImpl)?.DeleteFile(fullPath);
            //     return null;
            // }
            if (async)
                handle = new BundleLoadHandle(url, bundleRequest, stream);
            else
                handle = new BundleLoadHandle(url, bundle, stream);
            _handleMap.Add(url, handle);
        }

        return handle;
    }

    public BundleLoadHandle AddBundle(string url, AssetBundle bundle)
    {
        if (!_handleMap.TryGetValue(url, out var bundleLoadHandle))
        {
            bundleLoadHandle = new BundleLoadHandle(url, bundle, null);
            _handleMap.Add(url, bundleLoadHandle);
        }
        else
        {
            if (bundleLoadHandle.bundle != null)
            {
                // 会存在这种情况？有2个同名bundle加载时unity早报错了
                var sd = AssetActionLogger.GetActionStartData();
                bundle.Unload(true);
                AssetActionLogger.RecordAction(sd, url, AssetBundleActionType.UnloadBundle_True);
            }
            else
            {
                _handleMap[url] = bundleLoadHandle = new BundleLoadHandle(url, bundle, null);
            }
        }

        return bundleLoadHandle;
    }

    /// <summary>
    /// 所搜bundle在包内或文件系统上的实际文件名和偏移
    /// </summary>
    /// <param name="originalURL"></param>
    /// <param name="fullPathelativePath"></param>
    /// <param name="offset"></param>
    /// <returns>对应的searchPath，不存在返回null</returns>
    SearchPath SearchBundleActualPath(string originalURL, string md5, out string fullPath, out int offset)
    {
        fullPath = originalURL;
        offset = -1;
        for (int i = 0, l = _searchPaths.Count; i < l; ++i)
        {
            SearchPath searchPath = _searchPaths[i];
            if (searchPath.persistType == PersistType.Disk)
            {
                fullPath = searchPath.GetFullPath(ResourceHelper.GetRuntimeSavePath(originalURL, md5));
                if (searchPath.storageImpl.Exists(fullPath))
                {
                    offset = 0;
                    return searchPath;
                }
            }
            else if (searchPath.persistType == PersistType.Package)
            {
                _mapper.GetFileInfo(originalURL, out var mappingRelativePath, out offset);
                fullPath = searchPath.GetFullPath(mappingRelativePath);
                if (offset >= 0)
                    return searchPath;
            }
            else
            {
                Debug.LogError($"Unknown type: {searchPath.persistType}");
                return null;
            }
        }

        return null;
    }

    internal bool DoesBundleExist(string originalURL, string md5)
    {
        // todo, 可以优化为先找包内mapper，再查包外fs，对安卓能少很多fs操作
        return SearchBundleActualPath(originalURL, md5, out var fullPath, out var offset) != null;
    }

    public void UnloadBundle(BundleLoadHandle bundleHandle, bool unloadAsset)
    {
        if (bundleHandle != null)
        {
            if (!unloadAsset)
            {
                bundleHandle.UnloadSerializeResource();
                return;
            }

            _handleMap.Remove(bundleHandle.url);
            bundleHandle.Dispose(true);
        }
    }

    public void UnloadAll(bool unloadWhenDispose)
    {
        var iter = this._handleMap.GetEnumerator();
        while (iter.MoveNext())
        {
            iter.Current.Value.Dispose(unloadWhenDispose);
        }

        this._handleMap.Clear();
    }
}