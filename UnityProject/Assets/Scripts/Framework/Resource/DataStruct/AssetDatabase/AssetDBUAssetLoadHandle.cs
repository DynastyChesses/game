#if UNITY_EDITOR
using System;
using UnityEngine;
using UObject = UnityEngine.Object;
public class AssetDBUAssetLoadHandle : IUAssetLoadHandle
{
    public AssetDBUAssetLoadHandle(UObject asset)
    {
        this._asset = asset;
        this.isCompleted = true;
    }

    public AssetDBUAssetLoadHandle(AssetDBFakeResRequest assetRequest)
    {
        this._assetRequest = assetRequest;
        if (this._assetRequest.isDone)
        {
            this._asset = this._assetRequest.asset;
            this._assetRequest = null;
            this.isCompleted = true;
        }
        else
        {
            this._assetRequest.completed += this.OnAsyncAssetComplete;
            this.isCompleted = false;
            // this._loopQueryHandler = GlobalScheduler.AddFrameLimitUpdator(1, LoopQueryAssetStatus, this);
        }
    }

    private UObject _asset;
    private AssetDBFakeResRequest _assetRequest;
    private int _delayDispatchHandler;

    public UObject asset
    {
        get
        {
            if (this._asset == null && _assetRequest != null)
            {
                this._assetRequest.completed -= this.OnAsyncAssetComplete;
                this.ApplyAsset(this._assetRequest.asset, true);
            }
            return this._asset;
        }
    }

    public bool isCompleted
    {
        get;
        private set;
    }

    public bool Unload()
    {
        if (this._assetRequest != null)
        {
            this._assetRequest.completed -= this.OnAsyncAssetComplete;
            this._assetRequest = null;
        }
        bool needUnloadUnusedAsset = false;
        this._completeCallback = null;
        var obj = this.asset;
        if (obj)
        {
            if (!(obj is GameObject))
            {
                Resources.UnloadAsset(obj);
            }
            else
            {
                needUnloadUnusedAsset = true;
            }
        }
        this._asset = null;
        EquineScheduler.RemoveLimitUpdator(ref this._delayDispatchHandler);
        return needUnloadUnusedAsset;
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

    private void OnAsyncAssetComplete(AssetDBFakeResRequest op)
    {
        op.completed -= this.OnAsyncAssetComplete;
        if (this._assetRequest != op)
        {
            return;
        }
        var request = op as AssetDBFakeResRequest;
        if (request != null && request.isDone)
        {
            this.ApplyAsset(request.asset, false);
        }
    }

    private void ApplyAsset(UObject asset, bool delayDispatch)
    {
        // if (this._loopQueryHandler != null)
        // {
        //     GlobalScheduler.RemoveLimitUpdator(this._loopQueryHandler);
        //     this._loopQueryHandler = null;
        // }
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
#endif
