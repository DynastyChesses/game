using System;
using UnityEngine;
using UObject = UnityEngine.Object;

/// <summary>
/// 包装从assetBundle中加载出来的一个资源
/// </summary>

public class BundleLoadAssetHandle : IUAssetLoadHandle
{

    public BundleLoadAssetHandle(string assetName, UObject asset)
    {
        this.assetName = assetName;
        this._asset = asset;
        this.isCompleted = true;
    }

    public BundleLoadAssetHandle(string assetName, AssetBundleRequest assetRequest)
    {
        this.assetName = assetName;
        this._assetRequest = assetRequest;
        if (this._assetRequest.isDone)
        {
            this._asset = this._assetRequest.asset;
            this._assetRequest = null;
            this.isCompleted = true;
        }
        else
        {
            this._loopQueryHandler = EquineScheduler.AddFrameLimitUpdator(1, LoopQueryAssetStatus, this);
        }
    }

    public readonly string assetName;
    private UObject _asset;
    private AssetBundleRequest _assetRequest;
    private int _delayDispatchHandler;
    private int _loopQueryHandler;
    

    public UObject asset
    {
        get
        {
            if (this._asset == null && _assetRequest != null)
            {
                this.ApplyAsset(this._assetRequest.asset, true);
            }
            return this._asset;
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

    public void Dispose()
    {
        this._asset = null;
        if (this._assetRequest != null)
        {
            //下面这句不能删，确保异步请求完成
            var assureAsset = this._assetRequest.asset;
            this._assetRequest = null;
        }
        this._completeCallback = null;
        EquineScheduler.RemoveLimitUpdator(ref this._delayDispatchHandler);
        EquineScheduler.RemoveLimitUpdator(ref this._loopQueryHandler);
    }

    private static void LoopQueryAssetStatus(int a, object context, UpdateTimeInfo timeInfo)
    {
        var handle = context as BundleLoadAssetHandle;
        if (!EquineScheduler.IsValid(handle._loopQueryHandler))
        {
            return;
        }
        var request = handle._assetRequest;
        if (request != null && request.isDone)
        {
            handle.ApplyAsset(request.asset, false);
        }
    }

    private void ApplyAsset(UObject asset, bool delayDispatch)
    {
        EquineScheduler.RemoveLimitUpdator(ref this._loopQueryHandler);

        this._assetRequest = null;
        this._asset = asset;
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