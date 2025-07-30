using System;
using System.Collections.Generic;

public class ResourcePipelineContext : IResourcePipelineContext, IDisposable
{
    public ResourcePipelineContext()
    {
    }
    
    internal AssetActionLogger.ActionStartData startData;

    public Type type { get; private set; }

    private List<IResourceLoadPipe> _pipelines = null;

    private ResourceError _error = ResourceError.None;
    public ResourceError error { get { return this._error; } }

    private FMTask _currentTask = null;

    private int _currentPipeIndex = 0;

    private Action<ResourcePipelineContext, ResourceError, List<IResourcePipelineCallback>> _completeCallback;

    private List<IResourcePipelineCallback> _requests = null;

    public void Add(IResourcePipelineCallback request)
    {
        _requests = _requests ?? new List<IResourcePipelineCallback>(1);
        _requests.Add(request);
    }

    public void Remove(IResourcePipelineCallback request)
    {
        // TODO?
        if (_requests != null)
        {
            int index = _requests.IndexOf(request);
            if (index >= 0)
            {
                _requests[index] = null;
            }
        }
    }

    private bool Flow(int pipeIndex)
    {
        if (pipeIndex >= _pipelines.Count)
        {
            return false;
        }
        var pipe = this._pipelines[pipeIndex];
        this._error = ResourceError.None;
        this._currentTask = pipe.Handle(this, out this._error);
        // 完成任务
        if (error != ResourceError.None)
        {
            if (this._currentTask != null)
            {
                this._currentTask.Dispose();
                this._currentTask = null;
            }
            return false;
        }
        if (this._currentTask != null)
        {
            DoCompleteCallback(_currentTask);
        }
        return true;
    }

    private static List<IResourcePipelineCallback> _cacheRequests = new List<IResourcePipelineCallback>();

    private void OnTaskComplete(FMTask task)
    {
        this._currentTask = null;
        task.Dispose();
        if (!this.Flow(this._currentPipeIndex + 1))
        {
            DoCompleteCallback(task);
        }
    }

    private void OnTaskError(FMTask task, string errorDesc, int errorCode)
    {
        this._error = (ResourceError)errorCode;
        this._currentTask = null;
        task.Dispose();
        DoCompleteCallback(task);
    }

    private void DoCompleteCallback(FMTask task)
    {
        var callback = this._completeCallback;
        this._completeCallback = null;
        // 已有request移动到另一个地方暂存
        var requests = this._requests;
        if (requests != null && requests.Count > 0)
        {
            if (_cacheRequests.Count > 0)
            {
                _cacheRequests.Clear();
            }
            _cacheRequests.AddRange(requests);
            requests.Clear();
            requests = _cacheRequests;
        }
        callback(this, this._error, requests);
        _cacheRequests.Clear();
    }

    public void Dispose()
    {
        this.type = null;
        this._completeCallback = null;
        this._currentPipeIndex = 0;
        FMTask task = this._currentTask;
        this._currentTask = null;
        if (task != null)
        {
            task.Dispose();
        }
    }
}
