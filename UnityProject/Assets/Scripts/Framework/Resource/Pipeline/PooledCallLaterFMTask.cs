public class PooledCallLaterFMTask : FMTask
{
    private static ObjectPool2<PooledCallLaterFMTask> _pool = new ObjectPool2<PooledCallLaterFMTask>(-1, () => new PooledCallLaterFMTask(), false);

    public int frames
    {
        get;
        set;
    }

    private int _updator;

    private PooledCallLaterFMTask() : base("PooledCallLaterRETask ", false)
    {

    }

    public static PooledCallLaterFMTask Allocate(int frames = 1)
    {
        var task = _pool.Allocate();
        task.frames = frames;
        return task;
    }

    protected override void DoAction()
    {
        this._updator = EquineScheduler.CallOnceFrame(this.frames, this.OnDownloadComplete);
    }

    private void OnDownloadComplete(int a, object context, UpdateTimeInfo timeInfo)
    {
        if (!EquineScheduler.IsValid(this._updator))
        {
            return;
        }
        this._updator = -1;
        this.ApplyComplete();
    }

    protected override void DoAbort()
    {
        base.DoAbort();
        EquineScheduler.RemoveLimitUpdator(ref this._updator);
    }

    protected override void DoDispose()
    {
        base.DoDispose();
        _pool.Recycle(this);
    }
}
