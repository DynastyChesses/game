#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine.Profiling;

 public class AssetDBFakeResRequest
{
    private static Action<int, object, UpdateTimeInfo> _asyncCompleteCallback = new Action<int, object, UpdateTimeInfo>(OnAsyncLoadComplete);
    private string _path;
    private System.Type _type;
    private bool _isDone;
    private Action<AssetDBFakeResRequest> _completeCallback;

    public AssetDBFakeResRequest(string url, Type type)
    {
        _path = url;
        _type = type;
        _isDone = false;
        EquineScheduler.CallOnceFrame(1, _asyncCompleteCallback, this);
    }

    private static void OnAsyncLoadComplete(int a, object obj, UpdateTimeInfo timeInfo)
    {
        AssetDBFakeResRequest request = obj as AssetDBFakeResRequest;
        request.DetermineCompletion();
    }

    private void DetermineCompletion()
    {
        if (!_isDone)
        {
            _isDone = true;
            InvokeCompletionEvent();
        }
    }
    
    public bool isDone => _isDone;

    public UnityEngine.Object asset
    {
        get
        {
            DetermineCompletion();
            return AssetDatabase.LoadAssetAtPath(_path, _type);
        }
    }
    
    private void InvokeCompletionEvent()
    {
        if (this._completeCallback == null)
            return;
        Profiler.BeginSample("AssetDBFakeResRequest.InvokeCompletionEvent");
        Profiler.BeginSample(_path);
        this._completeCallback(this);
        Profiler.EndSample();
        Profiler.EndSample();
        this._completeCallback = null;
    }

    public event Action<AssetDBFakeResRequest> completed
    {
        add
        {
            if (this.isDone)
                value(this);
            else
                this._completeCallback += value;
        }
        remove => this._completeCallback -= value;
    }
}
#endif