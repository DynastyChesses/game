using System;
using System.Collections.Generic;
using UnityEngine;

public class FMTaskList : FMTask
{
    private int _taskIndex = 0;

    private List<FMTask> _tasks = new List<FMTask>();

    private bool _asyncMode = false;

    private FMTaskList _host = null;

    public Action<FMTaskList, FMTask> onTaskListCompleted = null;

    /** 回调方法: 子任务失败时。跟基类的有些重复 */
    public Action<FMTask, string, int> onSubTaskError = null;

    /** 延迟一帧执行下一个任务的handler */
    private int _beginNexTaskHandler;

    private int _retryTaskHandler;

    private int _errorCount = 0;

    private readonly bool _errorWhenAnyFailed;

    private FMTask _currentTask = null;

    public FMTask currentTask
    {
        get { return _currentTask; }
    }

    /** 任务失败时的重试时间（毫秒），如果此值小于或者等于0时，不重试，默认为0 */
    private float _retryTime = 0f;

    public float retryTime
    {
        get { return this._retryTime; }

        set { this._retryTime = value; }
    }

    //------------------------------------------------

    /** 构造 */
    public FMTaskList(string text = "TaskList", bool useTimeout = true, bool errorWhenAnyFailed = true)
        : base(text, useTimeout)
    {
        this._errorWhenAnyFailed = errorWhenAnyFailed;
    }

    //------------------------------------------------

    /** 添加每个子任务的回调方法 */
    private void InitTaskCallbacks(FMTask task)
    {
        task.onBegin = this.OnSubTaskBegin;
        task.onCompleted = this.OnSubTaskCompleted;
        task.onError = this.OnSubTaskError;
        task.onProgress = this.OnSubTaskProgress;
    }

    protected void WrapCallNormalListener(Action<FMTaskList, FMTask> listener, FMTask task)
    {
        if (listener != null)
        {
            try
            {
                listener(this, task);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }

    /** 每个子任务开始时 */
    private void OnSubTaskBegin(FMTask task)
    {
        DoSubTaskBegin(task);
    }

    protected virtual void DoSubTaskBegin(FMTask task)
    {
    }

    /** 子任务完成时 */
    private void OnSubTaskCompleted(FMTask task)
    {
        this._currentTask = task;
        this.WrapCallNormalListener(this.onProgress);
        this._currentTask = null;
        this._taskIndex++;
        // 异步fmTask是全并发的，由实际异步请求完成回调驱动到这里的，不需要由GlobalScheduler驱动到下一个任务
        // 有GlobalScheduler反而可能在一堆实际异步请求同一帧完成时创建一堆 GlobalScheduler回调，导致多次切换下一任务，
        // 进而多次调用DoTaskListComplete
        if ((this._host != null || _asyncMode) && this.CheckAllCompleted())
        {
            DoTaskListComplete(task);
            return;
        }

        if (!_asyncMode)
            this._beginNexTaskHandler = EquineScheduler.CallOnceFrame(1, this.ScheduleNextTask, task);
    }

    private void DoTaskListComplete(FMTask lastTask)
    {
        this._currentTask = lastTask;
        this.WrapCallNormalListener(this.onTaskListCompleted, lastTask);
        this.DoSubTaskComplete(lastTask);
        this._currentTask = null;
        if (_errorCount == 0)
        {
            this.ApplyComplete();
        }
        else
        {
            this.ApplyError("Task list failed", (int)FMTaskError.ListFailed);
        }
    }

    private void ScheduleNextTask(int a, object context, UpdateTimeInfo timeInfo)
    {
        this._beginNexTaskHandler = -1;
        try
        {
            this.BeginNextTask(context as FMTask);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    protected virtual void DoSubTaskComplete(FMTask task)
    {
    }

    /** 子任务进度变化时 */
    private void OnSubTaskProgress(FMTask task)
    {
        this.WrapCallNormalListener(this.onProgress);
        this.DoSubTaskProgress(task);
    }

    protected virtual void DoSubTaskProgress(FMTask task)
    {
    }

    /** 子任务失败时 */
    private void OnSubTaskError(FMTask task, string errorDesc, int errorCode)
    {
        this.WrapCallErrorListener(this.onSubTaskError, errorDesc, errorCode);

        EquineScheduler.RemoveLimitUpdator(ref this._retryTaskHandler);

        task.Abort();
        //任务表的任务失败后，再次重试
        if (this._retryTime > 0)
        {
            this._retryTaskHandler = EquineScheduler.CallOnce(this._retryTime, this.DoRetryTask, task);
        }
        else if (!this._asyncMode || _errorWhenAnyFailed)
        {
            ApplyError("Task list failed", errorCode);
            if (this._asyncMode)
            {
                this.Abort();
            }
        }
        else
        {
            ++_errorCount;
            if (CheckAllCompleted())
            {
                ApplyError("Task list failed", errorCode);
            }
        }
    }

    private void DoRetryTask(int a, object param, UpdateTimeInfo timeInfo)
    {
        FMTask task = param as FMTask;
        task.Begin();
    }

    /** 开始下一个任务 */
    protected void BeginNextTask(FMTask lastTask)
    {
        if (this.CheckAllCompleted())
        {
            DoTaskListComplete(lastTask);
            return;
        }

        if (this._asyncMode)
        {
            return;
        }

        FMTask task = this._tasks[this._taskIndex];

        if (task == null)
        {
            return;
        }

        this.InitTaskCallbacks(task);

        task.Begin();

        this._currentTask = task;
        this.WrapCallNormalListener(this.onProgress);
        this._currentTask = null;
    }

    /** 检查所有任务是否都已经完成 */
    protected bool CheckAllCompleted()
    {
        return _taskIndex + _errorCount >= _tasks.Count;
    }

    /** 重置任务状态 */
    protected override void DoAbort()
    {
        base.DoAbort();
        EquineScheduler.RemoveLimitUpdator(ref this._beginNexTaskHandler);
        for (int i = 0; i < this._tasks.Count; ++i)
        {
            if (this._tasks[i].status == Status.Working)
            {
                this._tasks[i].Abort();
            }
        }

        this._taskIndex = 0;
        this._errorCount = 0;
    }

    /** 开始任务 */
    protected override void DoAction()
    {
        _taskIndex = 0;
        _errorCount = 0;
        if (this._asyncMode)
        {
            for (int i = 0; i < this._tasks.Count; ++i)
            {
                FMTask task = this._tasks[i];
                this.InitTaskCallbacks(task);
                task.Begin();
            }

            return;
        }

        this.BeginNextTask(null);
    }

    /** 取消任务 */
    protected override void DoDispose()
    {
        base.DoDispose();
        this.onTaskListCompleted = null;
        this.Clear();
    }

    /** 添加任务 */
    public void Add(FMTask task)
    {
        if (task == null)
        {
            return;
        }

        FMTaskList taskList = task as FMTaskList;
        if (taskList != null)
        {
            taskList._host = this;
        }

        this._tasks.Add(task);
    }

    /** 移除指定任务 */
    public void Remove(FMTask task)
    {
        if (this._tasks.Remove(task))
        {
            FMTaskList taskList = task as FMTaskList;
            if (taskList != null)
            {
                taskList._host = null;
                taskList.Clear();
            }

            task.onBegin = task.onCompleted = task.onProgress = null;
            task.onError = null;
        }
    }

    /** 清空任务 */
    public void Clear()
    {
        for (int i = 0; i < this._tasks.Count; ++i)
        {
            FMTask task = this._tasks[i];

            FMTaskList taskList = task as FMTaskList;
            if (taskList != null)
            {
                taskList._host = null;
                taskList.Clear();
            }

            task.onBegin = task.onCompleted = task.onProgress = null;
            task.onError = null;
        }

        this._tasks.Clear();

        this._taskIndex = 0;

        this._errorCount = 0;
    }

    //------------------------------------------------

    /** 获取或设置任务表是否同时启动所有子任务的执行 (默认为false, 逐个执行子任务) */
    public bool asyncMode
    {
        get { return this._asyncMode; }

        set { this._asyncMode = value; }
    }

    public bool empty
    {
        get { return this._tasks == null || this._tasks.Count == 0; }
    }

    /** 获取所有子任务 */
    public List<FMTask> GetSubTasks()
    {
        return new List<FMTask>(this._tasks);
    }

    /** 获取任务执行进度 */
    public float GetCurrentProgress()
    {
        if (this.status == Status.Working)
        {
            if (this._tasks.Count > 0)
            {
                float ret = 0f;
                float step = 1.0f / this._tasks.Count;


                for (int i = 0; i < this._tasks.Count; ++i)
                {
                    float itemProgress = this._tasks[i].progress;
                    ret += step * itemProgress;
                }

                if (ret >= 0.99) ret = 1;

                return ret;
            }
        }

        return 0;
    }
}