using System;
using UnityEngine;
public abstract class FMTask : IDisposable
{
	public enum Status
	{
		None,
		Working,
		Completed,
		Error,
	}

	/** 当前重试计数 */
	private int _executeCount = 0;

	public int executeCount
	{
		get { return this._executeCount; }
	}

	// /** 任务是否已经开始 */
	// private bool _alreadyBegin = false;
	//
	// public bool alreadyBegin
	//    {
	// 	get
	//        {
	// 		return this._alreadyBegin;
	//        }
	//    }

	/** 任务是否已经完成 */
	// private bool _alreadyCompleted = false;
	private Status _status = Status.None;

	/** 定制的超时时间 */
	private float _customOverTime = 0;

	/** 测试用的: 任务开始时间 */
	private float _beginTimer = 0;

	/** 测试用的: 任务结束时间 */
	private float _endTimer = 0;

	/** 测试用的：日志相关的一个说明文本 */
	private string _text;

	/** setTimeOut的超时handler */
	private int _overTimerHandler;

	/** 任务是否超时 */
	private bool _isOvertime = false;

	private bool _useTimeout = true;

	/** 回调方法: 开始任务时 */
	public Action<FMTask> onBegin;

	/** 回调方法: 进度变化时 */
	public Action<FMTask> onProgress;

	/** 回调方法: 完成时 */
	public Action<FMTask> onCompleted;

	/** 回调方法: 失败时 */
	public Action<FMTask, string, int> onError;

	//------------------------------------------------------

	/** 构造 */
	public FMTask(string text = "Task", bool useTimeout = true)
	{
		this._text = text;
		this._useTimeout = useTimeout;
	}

	//------------------------------------------------------

	/** 结束处理超时设定 */
	private void OverTimeEnd()
	{
		if (!this._useTimeout) return;

		EquineScheduler.RemoveLimitUpdator(ref this._overTimerHandler);
	}


	protected void WrapCallErrorListener(Action<FMTask, string, int> listener, string errorDesc, int errorCode)
	{
		if (listener != null)
		{
			try
			{
				listener(this, errorDesc, errorCode);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}

	protected void WrapCallNormalListener(Action<FMTask> listener)
	{
		if (listener != null)
		{
			try
			{
				listener(this);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}

	protected void ApplyComplete()
	{
		if (this._status != Status.Working)
		{
			return;
		}

		this.OverTimeEnd();
		this._status = Status.Completed;

		this._endTimer = (float) RealTimer.elapsedSeconds;

		this.DoComplete();

		this.WrapCallNormalListener(this.onCompleted);

	}

	protected void ApplyError(string errorDesc, int errorCode)
	{
		if (this._status != Status.Working)
		{
			return;
		}

		this.OverTimeEnd();
		this._status = Status.Error;

		this._endTimer = (float) RealTimer.elapsedSeconds;

		this.WrapCallErrorListener(this.onError, errorDesc, errorCode);
	}

	protected virtual void DoComplete()
	{

	}

	/** 获取统一的超时时间 */
	protected virtual float GetOverTimeSetting()
	{
		return 0f;
	}

	protected virtual void DoOverTime()
	{
		this.WrapCallErrorListener(this.onError, "Timeout", (int) FMTaskError.Timeout);
	}

	/** 开始超时检查 */
	private void StartOverTimeCheck()
	{
		if (!this._useTimeout) return;
		// var now: number = new Date().getTime();

		EquineScheduler.RemoveLimitUpdator(ref this._overTimerHandler);

		float o = this.GetOverTimeSetting();
		float co = this._customOverTime;
		if (o < co)
		{
			o = co;
		}

		if (o <= 0) return;

		this._overTimerHandler = EquineScheduler.CallOnce(o, this.OnOverTime);
	}

	private void OnOverTime(int a, object context, UpdateTimeInfo updateTimeInfo)
	{
		if (this._status == Status.Working)
		{
			Debug.Log(string.Format("Task超时 {0}", RealTimer.elapsedSeconds - this._beginTimer));
			this._isOvertime = true;
			this.DoOverTime();
		}
	}

	protected virtual void DoAbort()
	{

	}

	/** 取消 */
	public void Abort()
	{
		this.OverTimeEnd();
		this._status = Status.None;
		this._isOvertime = false;
		this.DoAbort();
	}

	protected abstract void DoAction();

	/** 开始任务 */
	public void Begin()
	{
		if (this._status == Status.Working)
		{
			this.Abort();
		}

		this._status = Status.Working;
		++this._executeCount;
		this._beginTimer = (float) RealTimer.elapsedSeconds;
		this.StartOverTimeCheck();
		this.WrapCallNormalListener(this.onBegin);
		this.DoAction();
	}

	/** 销毁 */
	public void Dispose()
	{
		this.DoDispose();
	}

	protected virtual void DoDispose()
	{
		this.Abort();
		this.onBegin = this.onProgress = this.onCompleted = null;
		this.onError = null;
	}

	/** 获取附加给toString的文本信息 */
	protected virtual string ToStringAddon()
	{
		return "";
	}

	/** 重写的toString方法，方便打日志时知道是个什么情况 */
	public override string ToString()
	{
		return (this._text != null ? this._text : "Task") + this.ToStringAddon();
	}

	/** 获取调试信息 */
	public string GetDebugInfo()
	{
		if (this._isOvertime)
		{
			return "超时";
		}

		return this.GetDebugStatusInfo();
	}

	/** 获取调试状态信息, 例如返回个404啥的 */
	protected virtual string GetDebugStatusInfo()
	{
		return "失败";
	}


	//------------------------------------------------------

	/** 获取或设置定制的超时时间 */
	public virtual float customOverTime
	{
		get { return this._customOverTime; }

		set { this._customOverTime = value; }
	}

	/** 任务是否已经完成 */
	public Status status
	{
		get { return _status; }
	}

	/** 任务的完成进度 */
	public virtual float progress
	{
		get { return this._status == Status.Completed ? 1 : 0; }
	}

	/** 获取任务的起始时间 */
	public float beginTimer
	{
		get { return this._beginTimer; }
	}

	/** 获取任务的结束时间 */
	public float endTimer
	{
		get { return this._endTimer; }
	}

	/** 获取任务的使用时间 */
	public float useTime
	{
		get
		{
			if (this._endTimer <= 0 || this._beginTimer <= 0)
			{
				return -1;
			}

			return this._endTimer - this._beginTimer;
		}
	}

	/** 获取任务是否超时 */
	public bool isOvertime
	{
		get { return this._isOvertime; }
	}
}

