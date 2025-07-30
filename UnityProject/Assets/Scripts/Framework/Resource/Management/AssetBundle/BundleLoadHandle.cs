using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Profiling;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = System.Object;
using UObject = UnityEngine.Object;
#if UNITY_WEBGL && !UNITY_EDITOR
using WeChatWASM;
#endif

public class CustomObj<T> : UObject
{
    public AsyncOperationHandle<T> handle;

    public CustomObj()
    {
            
    }
}
/// <summary>
/// 包装unity的AssetBundle，一个ab对应唯一一个此类对象
/// 包括异步加载请求，记录从它加载的资源等
/// </summary>
public class BundleLoadHandle : IAsyncBase
{
    
    public BundleLoadHandle(string url)
    {
        this.url = url;
        // this._mainAssetName = assetId.ToLower();
        this._bundle = bundle;
        this.isCompleted = true;
    }
    public BundleLoadHandle(string url/*, string assetId*/, AssetBundle bundle, Stream stream)
    {
        this.url = url;
        // this._mainAssetName = assetId.ToLower();
        this._bundle = bundle;
        this.isCompleted = true;
        _stream = stream;
    }

    public BundleLoadHandle(string url/*, string assetId*/, AssetBundleCreateRequest bundleRequest, Stream stream)
    {
        this.url = url;
        _stream = stream;
        this._bundleRequest = bundleRequest;
        if (this._bundleRequest != null)
        {
            if (this._bundleRequest.isDone)
            {
                this._bundle = this._bundleRequest.assetBundle;
                this._bundleRequest = null;
                this.isCompleted = true;
            }
            else
            {
                this._loopQueryHandler = EquineScheduler.AddFrameLimitUpdator(1, LoopQueryAssetBundleStatus, this);
            }
        }
    }

    public readonly string url;
    private AssetBundle _bundle;
    private AssetBundleCreateRequest _bundleRequest;
    private Stream _stream;
    // private string _mainAssetName;
    private int _delayDispatchHandler;
    private int _loopQueryHandler;
    private Dictionary<string, BundleLoadAssetHandle> _assetMap = new Dictionary<string, BundleLoadAssetHandle>(1);

    public AssetBundle bundle
    {
        get
        {
            if (this._bundle == null && _bundleRequest != null)
            {
                this.ApplyBundle(this._bundleRequest.assetBundle, true);
            }
            return this._bundle;
        }
    }

    public bool isCompleted
    {
        get;
        set;
    }

    private Action<IAsyncBase> _completeCallback;

    public event Action<IAsyncBase> completeCallback
    {
        add
        {
            this._completeCallback += value;
        }

        remove
        {
            this._completeCallback -= value;
        }
    }

    // public IUAssetLoadHandle LoadMainAsset(Type type)
    // {
    //     // if (this._mainAssetName == null)
    //     // {
    //     //     if (this.bundle == null || this.bundle.name == null)
    //     //     {
    //     //         return null;
    //     //     }
    //     //     this._mainAssetName = Path.GetFileNameWithoutExtension(bundle.name);
    //     // }
    //     return this.LoadAsset(this._mainAssetName, type);
    // }

    // public IUAssetLoadHandle LoadMainAssetAsync(Type type)
    // {
    //     // if (this._mainAssetName == null)
    //     // {
    //     //     if (this.bundle == null || this.bundle.name == null)
    //     //     {
    //     //         return null;
    //     //     }
    //     //     this._mainAssetName = Path.GetFileNameWithoutExtension(bundle.name);
    //     // }
    //     return this.LoadAssetAsync(this._mainAssetName, type);
    // }

    
    
    // 不用ab的方式，用addressable
    // public BundleLoadAssetHandle LoadAsset(string assetName, Type type)
    // {
    //     BundleLoadAssetHandle handle;
    //     if (!_assetMap.TryGetValue(assetName, out handle))
    //     {
    //         // Assets/Arts/Prefabs/BasePanel.prefab
    //         UObject asset = new UObject();
    //         try
    //         {
    //             // 获取整个的名字
    //             string fullName = "";
    //             if (!assetName.Contains("Assets"))
    //             {
    //                 fullName = $"Assets/Arts/Prefabs/{assetName}.prefab";
    //             }
    //             else
    //             {
    //                 fullName = $"{assetName}.prefab";
    //             }
    //             // asset = type != null ? this.bundle.LoadAsset(assetName, type) : this.bundle.LoadAsset(assetName);
    //             var ret = Addressables.LoadAssetAsync<GameObject>(fullName);
    //             asset = ret.WaitForCompletion();
    //         }
    //         catch (Exception e)
    //         {
    //             Debug.LogException(e);
    //         }
    //         // if (asset == null)
    //         // {
    //         //     return null;
    //         // }
    //         handle = new BundleLoadAssetHandle(assetName, asset);
    //         _assetMap.Add(assetName, handle);
    //     }
    //
    //     return handle;
    // }
    //
    // public IUAssetLoadHandle LoadAssetAsync(string assetName, Type type)
    // {
    //     BundleLoadAssetHandle handle;
    //     if (!_assetMap.TryGetValue(assetName, out handle))
    //     {
    //         if (this.bundle == null)
    //         {
    //             return null;
    //         }
    //         AssetBundleRequest assetRequest = null;
    //         try
    //         {
    //             Profiler.BeginSample("BundleLoadHandle.LoadAssetAsync");
    //             Profiler.BeginSample(assetName);
    //             assetRequest = this.bundle.LoadAssetAsync(assetName, type);
    //             Profiler.EndSample();
    //             Profiler.EndSample();
    //         }
    //         catch (Exception e)
    //         {
    //             Debug.LogException(e);
    //         }
    //         if (assetRequest == null)
    //         {
    //             return null;
    //         }
    //         handle = new BundleLoadAssetHandle(assetName, assetRequest);
    //         _assetMap.Add(assetName, handle);
    //     }
    //     return handle;
    // }

    public void UnloadAsset(IUAssetLoadHandle handle)
    {
        BundleLoadAssetHandle assetHandle = handle as BundleLoadAssetHandle;
        if (assetHandle != null)
        {
            _assetMap.Remove(assetHandle.assetName);
            assetHandle.Dispose();
        }
    }

    public void UnloadSerializeResource()
    {
        UnloadBundle(false);
    }

    void UnloadBundle(bool unloadTrue)
    {
        var sd = AssetActionLogger.GetActionStartData();
        var bundle = this.bundle;
        if (bundle)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            // 同步的不是用wxAssetBundle加载的，用wxUnload会报错误log，所以仿照查找下
            if (WXAssetBundle.bundle2path.ContainsKey(bundle))
                bundle.WXUnload(unloadTrue);
            else
                bundle.Unload(unloadTrue);
#else
            bundle.Unload(unloadTrue);
#endif
            this._bundle = null;
        }
        _stream?.Dispose(); 
        AssetActionLogger.RecordAction(sd, url, unloadTrue ? AssetBundleActionType.UnloadBundle_True : 
            AssetBundleActionType.UnloadBundle_False);
    }

    public void Dispose(bool unloadTrue)
    {
        var iter = this._assetMap.GetEnumerator();
        while (iter.MoveNext())
        {
            iter.Current.Value.Dispose();
        }
        this._assetMap.Clear();
        UnloadBundle(unloadTrue);
        // this._mainAssetName = null;
        this._completeCallback = null;
        EquineScheduler.RemoveLimitUpdator(ref this._delayDispatchHandler);
        EquineScheduler.RemoveLimitUpdator(ref this._loopQueryHandler);
    }

    private static void LoopQueryAssetBundleStatus(int a, object context, UpdateTimeInfo timeInfo)
    {
        var handle = context as BundleLoadHandle;
        if (!EquineScheduler.IsValid(handle._loopQueryHandler))
        {
            return;
        }
        var request = handle._bundleRequest;
        if (request != null && request.isDone)
        {
            handle.ApplyBundle(request.assetBundle, false);
        }
    }

    private void ApplyBundle(AssetBundle bundle, bool delayDispatch)
    {
        EquineScheduler.RemoveLimitUpdator(ref this._loopQueryHandler);

        this._bundleRequest = null;
        this._bundle = bundle;
        this.isCompleted = true;

        if (!delayDispatch)
        {
            this.DispatchCompleteEvent(0, null, new UpdateTimeInfo());
        }
        else if (!EquineScheduler.IsValid(this._delayDispatchHandler))
        {
            this._delayDispatchHandler = EquineScheduler.CallOnceFrame(1, this.DispatchCompleteEvent);
        }
    }

    private void DispatchCompleteEvent(int a, object context, UpdateTimeInfo timeInfo)
    {
        this._delayDispatchHandler = -1;
        Action<IAsyncBase> callback = this._completeCallback;
        this._completeCallback = null;
        if (callback != null)
        {
            callback(this);
        }
    }
}