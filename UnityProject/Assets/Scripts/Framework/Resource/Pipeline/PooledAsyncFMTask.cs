using System;
public class PooledAsyncFMTask : FMTask
{
    private static ObjectPool2<PooledAsyncFMTask> _pool = 
        new ObjectPool2<PooledAsyncFMTask>(-1, () => new PooledAsyncFMTask(), false);

    public object context { get; set; }

    public object context2 { get; set; }
    public Func<PooledAsyncFMTask, IAsyncBase> generateAsyncWork { get; set; }

    public Func<PooledAsyncFMTask, IAsyncBase, ResourceError> getAsyncWorkError { get; set; }

    public Action<PooledAsyncFMTask, IAsyncBase> processAsyncWorkResult { get; set; }
    
    private IAsyncBase _task;

    private PooledAsyncFMTask() : base("PooledAsyncRETask ", false)
    {

    }

    public static PooledAsyncFMTask Allocate(object context, object context2, 
        Func<PooledAsyncFMTask, IAsyncBase> generateAsyncWork, 
        Func<PooledAsyncFMTask, IAsyncBase, ResourceError> getAsyncWorkError, 
        Action<PooledAsyncFMTask, IAsyncBase> processAsyncWorkResult)
    {
        var task = _pool.Allocate();
        task.context = context;
        task.context2 = context2;
        task.generateAsyncWork = generateAsyncWork;
        task.getAsyncWorkError = getAsyncWorkError;
        task.processAsyncWorkResult = processAsyncWorkResult;
        return task;
    }

    protected override string ToStringAddon()
    {
        return this.context != null ? this.context.ToString() : "";
    }

    protected override void DoAction()
    {
        this._task = this.generateAsyncWork != null ? this.generateAsyncWork(this) : null;
        // 如果没创建出任务，由创建方识别是什么错误。比如bundle不存在就不需要创建task
        // if (this._task == null)
        // {
        //     this.ApplyError("Generate asyncTask failed", (int)ResourceError.AsyncTaskGenerateError);
        //     return;
        // }

        if (_task == null || _task.isCompleted)
        {
            OnComplete(_task);
        }
        else
        {
            // 实际任务完成后回调fmTask完成
            this._task.completeCallback += this.OnComplete;       
        }
    }

    private void OnComplete(IAsyncBase task)
    {
        if (task != this._task)
        {
            return;
        }
        this._task = null;
        ResourceError errorCode = ResourceError.None;
        if (getAsyncWorkError != null)
            errorCode = getAsyncWorkError(this, task);
        
        if (errorCode != ResourceError.None)
        {
            this.ApplyError("Get async work error", (int)errorCode);
        }
        else
        {
            if (this.processAsyncWorkResult != null)
            {
                this.processAsyncWorkResult(this, task);
            }
            this.ApplyComplete();
        }
    }

    protected override void DoAbort()
    {
        base.DoAbort();
        if (this._task != null)
        {
            this._task.completeCallback -= this.OnComplete;
            this._task = null;
        }
    }

    protected override void DoDispose()
    {
        base.DoDispose();
        this.context = null;
        this.generateAsyncWork = null;
        this.getAsyncWorkError = null;
        this.processAsyncWorkResult = null;
        _pool.Recycle(this);
    }
}