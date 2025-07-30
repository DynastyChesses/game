using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Profiling;

namespace EquineScheduler.Schedule
{
    public class EquineScheduler : MonoBehaviour, IUpdateFacade
    {
        private static int _globalId = 1;

        private IntHashtable<BaseLimitUpdator> _updatorMap = new IntHashtable<BaseLimitUpdator>(20);

        abstract class BaseLimitUpdator
        {
            public int id { get; set; }

            public bool active { get; set; }

            protected Action _updateProxyHandler;

            protected Action<object> _updateHandler;

            protected object _param;

            protected bool _once = false;

            protected int _disposeTimes;

            protected BaseLimitUpdator()
            {
                _updateProxyHandler = new Action(UpdateProxyHandler);
            }

            protected void ResetVal(Action<object> target, object targetParam, bool once)
            {
                _updateHandler = target;
                _param = targetParam;
                _once = once;
            }

            protected abstract void UpdateProxyHandler();

            public virtual void Dispose()
            {
                _updateHandler = null;
                _param = null;
                _once = false;
                this.active = false;
                this.id = 0;
                ++this._disposeTimes;
            }
        }

        class TimeLimitUpdator : BaseLimitUpdator
        {
            private static Stack<TimeLimitUpdator> _timeLimitUpdatorStack = new Stack<TimeLimitUpdator>();

            private double _lastTime;
            private float _interval;
            private bool _inPool = false;

            TimeLimitUpdator()
            {
            }

            public static TimeLimitUpdator Allocate()
            {
                TimeLimitUpdator updator = null;
                if (_timeLimitUpdatorStack.Count > 0)
                {
                    updator = _timeLimitUpdatorStack.Pop();
                    updator._inPool = false;
                }
                else
                {
                    updator = new TimeLimitUpdator();
                }

                return updator;
            }

            public void Start(Action<object> updateHandler, float interval, object param, bool once = false)
            {
                ResetVal(updateHandler, param, once);
                _interval = interval;
                _lastTime = _currentFrameUpdateTimeInfo.realtimeSinceStartup;
                _param = param;
                active = true;
                EquineScheduler._instance.updateEvent += this._updateProxyHandler;
            }


            protected override void UpdateProxyHandler()
            {
                // webgl上时间精度很低，微信小游戏为1ms，pc chrome是0.1ms。pc上调用新时间的代价还很高，
                // 一帧内改用一个固定时间。profiler有一定消耗，所以放if里面
			    Profiler.BeginSample("T.UpdateProxyHandler");
                if (active && _currentFrameUpdateTimeInfo.realtimeSinceStartup - _lastTime >= _interval)
                {
                    Profiler.BeginSample(_updateHandler.Target != null ? _updateHandler.Target.ToString() : "NoNameTarget");
                    Profiler.BeginSample(_updateHandler.Method.Name);

                    _lastTime = _currentFrameUpdateTimeInfo.realtimeSinceStartup;
                    if (_once)
                    {
                        var lastDisposeTimes = this._disposeTimes;
                        var tmp = _updateHandler;
                        tmp(_param);
                        if (tmp == _updateHandler && this._disposeTimes == lastDisposeTimes)
                        {
                            Dispose();
                        }
                    }
                    else
                    {
                        _updateHandler(_param);
                    }

                    Profiler.EndSample();
                    Profiler.EndSample();
                }
                Profiler.EndSample();
            }

            public override void Dispose()
            {
                if (!_inPool)
                {
                    EquineScheduler._instance._updatorMap.Remove(id);
                    EquineScheduler._instance.updateEvent -= this._updateProxyHandler;
                    // 移除id和handler记录需要早于base.Dispose()
                    base.Dispose();
                    _timeLimitUpdatorStack.Push(this);
                    _inPool = true;
                }
            }
        }

        class FrameLimitUpdator : BaseLimitUpdator
        {
            private static Stack<FrameLimitUpdator> _frameLimitUpdatorStack = new Stack<FrameLimitUpdator>();

            private int _lastFrame;
            private int _interval;
            private bool _inPool = false;

            FrameLimitUpdator()
            {
            }

            public static FrameLimitUpdator Allocate()
            {
                FrameLimitUpdator updator = null;
                if (_frameLimitUpdatorStack.Count > 0)
                {
                    updator = _frameLimitUpdatorStack.Pop();
                    updator._inPool = false;
                }
                else
                {
                    updator = new FrameLimitUpdator();
                }

                return updator;
            }

            public void Start(Action<object> updateHandler, int interval, object param, bool once = false)
            {
                this.ResetVal(updateHandler, param, once);
                _interval = interval;
                _lastFrame = Time.frameCount;
                active = true;
                EquineScheduler._instance.updateEvent += this._updateProxyHandler;
            }


            protected override void UpdateProxyHandler()
            {
			    Profiler.BeginSample("F.UpdateProxyHandler");
                if (active && Time.frameCount - _lastFrame >= _interval)
                {
                    Profiler.BeginSample(_updateHandler.Target != null ? _updateHandler.Target.ToString() : "NoNameTarget");
                    Profiler.BeginSample(_updateHandler.Method.Name);
                    _lastFrame = Time.frameCount;
                    if (_once)
                    {
                        var lastDisposeTimes = this._disposeTimes;
                        var tmp = _updateHandler;
                        tmp(_param);
                        if (tmp == _updateHandler && this._disposeTimes == lastDisposeTimes)
                        {
                            Dispose();
                        }
                    }
                    else
                    {
                        _updateHandler(_param);
                    }

                    Profiler.EndSample();
                    Profiler.EndSample();
                }
                Profiler.EndSample();
            }

            public override void Dispose()
            {
                if (!_inPool)
                {
                    _instance._updatorMap.Remove(id);
                    _instance.updateEvent -= this._updateProxyHandler;
                    // 移除id和handler记录需要早于base.Dispose()
                    base.Dispose();
                    _frameLimitUpdatorStack.Push(this);
                    _inPool = true;
                }
            }
        }

        int IUpdateFacade.AddTimeLimitUpdatorMethod(float interval, Action<object> updateHandler, object param)
        {
            if (updateHandler == null)
            {
                Debug.LogError("Add Updator Error");
                return 0;
            }

            TimeLimitUpdator updator = TimeLimitUpdator.Allocate();
            int id = _globalId++;
            updator.id = id;
            updator.Start(updateHandler, interval, param);
            _updatorMap[id] = updator;
            return id;
        }

        int IUpdateFacade.CallOnceMethod(int delayFrames, Action<object> updateHandler, object param)
        {
            FrameLimitUpdator updator = FrameLimitUpdator.Allocate();
            int id = _globalId++;
            updator.id = id;
            updator.Start(updateHandler, delayFrames, param, true);
            _updatorMap[id] = updator;
            return id;
        }

        int IUpdateFacade.AddFrameLimitUpdatorMethod(int interval, Action<object> updateHandler, object param)
        {
            FrameLimitUpdator updator = FrameLimitUpdator.Allocate();
            int id = _globalId++;
            updator.id = id;
            updator.Start(updateHandler, interval, param);
            _updatorMap[id] = updator;
            return id;
        }

        int IUpdateFacade.CallOnceMethod(float delayTimes, Action<object> updateHandler, object param)
        {
            if (updateHandler == null)
            {
                Debug.LogError("Add Updator Error");
                return 0;
            }

            TimeLimitUpdator updator = TimeLimitUpdator.Allocate();
            int id = _globalId++;
            updator.id = id;
            updator.Start(updateHandler, delayTimes, param, true);
            _updatorMap[id] = updator;
            return id;
        }

        void IUpdateFacade.RemoveLimitUpdatorMethod(int id)
        {
            BaseLimitUpdator limitUpdator = _updatorMap[id];
            if (limitUpdator != null)
            {
                limitUpdator.Dispose();
            }
        }

        bool IUpdateFacade.IsValid(int id)
        {
            return _updatorMap.ContainsKey(id);
        }

        void IUpdateFacade.SetActive(int id, bool active)
        {
            BaseLimitUpdator limitUpdator = _updatorMap[id];
            if (limitUpdator != null)
            {
                limitUpdator.active = active;
            }
        }

        protected static EquineScheduler _instance = null;
	    /// <summary>
    	/// 当前帧的更新帧时间信息，因为webgl下取实时时间代价很高，所以替换成这个一帧内不变的或少变的
	    /// </summary>
    	private static UpdateTimeInfo _currentFrameUpdateTimeInfo;

        private static int _mainThreadId;

        private Action _updateDelegate;

        public event Action updateEvent
        {
            add { _updateDelegate += value; }

            remove { _updateDelegate -= value; }
        }

        private List<Action> _pendingRunnableQueue = new List<Action>();

        private List<Action> _cachedRunnableQueue = new List<Action>();

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
                _mainThreadId = Thread.CurrentThread.ManagedThreadId;
		        _currentFrameUpdateTimeInfo = UniqueMonoEventListener.instance.currentUpdateTimeInfo;
                this.DoAwake();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        protected virtual void DoAwake()
        {
        }

        public static void ClearAll()
        {
            if (_instance != null)
            {
                _instance._updateDelegate = null;
                _instance._pendingRunnableQueue.Clear();
                _instance._cachedRunnableQueue.Clear();
            }
        }

        public static int AddTimeLimitUpdator(float interval, Action<object> updateHandler, object param = null)
        {
            return (_instance as IUpdateFacade).AddTimeLimitUpdatorMethod(interval, updateHandler, param);
        }

        public static int CallOnce(float delayTime, Action<object> updateHandler, object param = null)
        {
            return (_instance as IUpdateFacade).CallOnceMethod(delayTime, updateHandler, param);
        }

        public static int AddFrameLimitUpdator(int interval, Action<object> updateHandler, object param = null)
        {
            return (_instance as IUpdateFacade).AddFrameLimitUpdatorMethod(interval, updateHandler, param);
        }

        public static int CallOnceFrame(int delayFrames, Action<object> updateHandler, object param = null)
        {
            return (_instance as IUpdateFacade).CallOnceMethod(delayFrames, updateHandler, param);
        }

        public static void RemoveLimitUpdator(ref int id)
        {
            if (id > 0)
            {
                (_instance as IUpdateFacade).RemoveLimitUpdatorMethod(id);
                id = 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid(int id)
        {
            return id > 0 && (_instance as IUpdateFacade).IsValid(id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetActive(int id, bool active)
        {
            (_instance as IUpdateFacade).SetActive(id, active);
        }

        public static Coroutine StartYieldCoroutine(IEnumerator coroutine)
        {
            return _instance.StartCoroutine(coroutine);
        }

        public static void StopYieldCoroutine(Coroutine coroutine)
        {
            _instance.StopCoroutine(coroutine);
        }

        public static void StopAllYieldCoroutine()
        {
            _instance.StopAllCoroutines();
        }

        public static void RunToMainThread(Action action)
        {
            if (_mainThreadId == Thread.CurrentThread.ManagedThreadId)
            {
                action();
            }
            else
            {
                _instance.DoRunToMainThread(action);
            }
        }

        private void DoRunToMainThread(Action action)
        {
            lock (this._pendingRunnableQueue)
            {
                this._pendingRunnableQueue.Add(action);
            }
        }

        private void LateUpdate()
        {
		    _currentFrameUpdateTimeInfo = UniqueMonoEventListener.instance.currentUpdateTimeInfo;
            int startIndex = this._cachedRunnableQueue.Count;
            lock (this._pendingRunnableQueue)
            {
                this._cachedRunnableQueue.AddRange(this._pendingRunnableQueue);
                this._pendingRunnableQueue.Clear();
            }

            int l = this._cachedRunnableQueue.Count;
            if (l > startIndex)
            {
                for (int i = startIndex; i < l; ++i)
                {
                    Action action = this._cachedRunnableQueue[i];
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                this._cachedRunnableQueue.Clear();
            }
            else if (startIndex > 0)
            {
                this._cachedRunnableQueue.Clear();
            }

            this.DoLateUpdate();
        }

        protected virtual void DoLateUpdate()
        {
            if (_updateDelegate != null)
            {
                _updateDelegate();
            }
        }
    }
}
