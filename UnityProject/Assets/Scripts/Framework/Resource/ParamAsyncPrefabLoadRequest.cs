using System;
using UnityEngine;

public class ParamAsyncPrefabLoadRequest
{
    private Action<GameObject, string, object> _onLoadDoneHandler;
    private IAsyncResourceRequest _request;
	private object _data;

	public object data
	{
		get { return _data; }
		set { _data = value; }
	}

    public ParamAsyncPrefabLoadRequest()
    {
    }


    /// <summary>
    /// 每次调用会先把之前没收到返回的回调函数监听取消。如果资源都已经加载过了，则同步返回。
    /// </summary>
    public void LoadPrefabsAsync(string path, Action<GameObject, string, object> onDone)
    {
        Cancel();
        _onLoadDoneHandler = onDone;
        _request = ResourceFacade.instance.LoadPrefabAsync(path);
        if (_request == null)
        {
            string error = $"Can't find AssetBundle for path:{path}";
            Logger.Error(error);
            FinishRequest(null, error);
            return;
        }
        _request.callback = OnResourcesLoaded;
    }


    /// <summary>
    /// 取消请求的回调函数监听
    /// </summary>
    public void Cancel()
    {
        if(_request != null)
        {
            _request.Dispose();
            _request = null;
        }
        _onLoadDoneHandler = null;
    }

    private void OnResourcesLoaded(IAsyncResourceRequest request)
    {
        if(!request.isDone || request.asset == null)
        {
            string error = $"Load failed: {request.id}, {request.isDone}";
            Debug.LogError(error);
            FinishRequest(null, error);
            return;
        }
        FinishRequest(request.asset as GameObject);
        if (_request != null)
        {
            _request.Dispose();
            _request = null;
        }
    }

    private void FinishRequest(GameObject prefab, string error = null)
    {
        if(_onLoadDoneHandler != null)
        {
            Action<GameObject, string, object> temp = _onLoadDoneHandler;
            _onLoadDoneHandler = null;
            temp(prefab, error, _data);
        }
    }
}

