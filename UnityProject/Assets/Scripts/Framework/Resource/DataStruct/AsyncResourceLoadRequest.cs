using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp;
using UnityEngine;
using UObject = UnityEngine.Object;
using UnityEngine.Profiling;
/// <summary>
/// 简化使用为 Addressable
/// </summary>
internal class AsyncResourceLoadRequest : IAsyncResourceRequest
{
    public AsyncResourceLoadRequest(string id)
    {
        this._id = id;
        this._priority = priority;
    }

    private readonly string _id;

    public string id
    {
        get { return _id; }
    }
    

    private readonly int _priority;

    public bool instantiated { get; }
    public bool destroyed { get; }
    public int priority => _priority;

    public Action<IAsyncResourceRequest> callback { get; set; }
    public Action<IAsyncResourceRequest> callbackNoDispose { get; set; }
    

    private UObject _asset;
    protected internal UObject originalAsset => _asset;

    public UObject asset
    {
        get
        {
            return _asset;
        }
    }

    public int OnAssetLoadComplete<T>(object original, bool is_inst)
    {
        var t = typeof(T);
        int ret = 0;
        if (t == typeof(GameObject))
        {
            if (is_inst)
            {
                _asset = GameObject.Instantiate((GameObject)original);
            }
            else
            {
                _asset = (GameObject)original;
            }
        }
        else
        {
            _asset = (UObject)original;
        }
        ret = _asset.GetInstanceID();
        isDone = true;
        var d = callbackNoDispose;
        callbackNoDispose = null;
        if (d != null)
        {
            try
            {
                d(this);
            }
            catch (NullReferenceException e)
            {
                
            }
            catch (AccessViolationException e)
            {
                
            }
        }

        if (callback == null)
        {
            return ret;
        }
        var c = callback;
        callback = null;
        if (c != null)
        {
            // 延迟到回调当中，取AsyncResourceLoadRequest.asset时实例化。但这样没法把实例化和回调分帧
            try
            {
                c(this);
            }
            catch (NullReferenceException e)
            {
                
            }
            catch (AccessViolationException e)
            {
                
            }
            // 加载回调完成后自动dispose，无回调不销毁，使用者不必每次手动调用
            Dispose();
        }

        return ret;
    }

    public bool isDone { get; set; }

    public void Dispose()
    {
        callback = null;
        callbackNoDispose = null;

        var tAsset = _asset;
        _asset = null;
    }

#if UNITY_EDITOR
    ~AsyncResourceLoadRequest()
    {
        
    }
#endif
}