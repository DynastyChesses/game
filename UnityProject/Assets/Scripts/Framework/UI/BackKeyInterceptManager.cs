using System;
using System.Collections.Generic;
using UnityEngine;

public class BackKeyInterceptManager
{
    public enum InterceptResult
    {
        Continue,
        Break,
        GotoDefault,
    }
    public interface IInterceptor
    {
        int priority
        {
            get;
        }
        InterceptResult OnExecute();
    }

    private static BackKeyInterceptManager _instance = null;

    public static BackKeyInterceptManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackKeyInterceptManager();
            }

            return _instance;
        }
    }
    
    private readonly LinkedList<IInterceptor> _triggerChain = new LinkedList<IInterceptor>();

    private int _backKeyUpdator = 0;

    private Action _defaultAction = null;
    
    public void AddBackKeyInterceptor(IInterceptor interceptor)
    {
        if (!_triggerChain.Contains(interceptor))
        {
            if (_triggerChain.Count == 0)
            {
                _triggerChain.AddLast(interceptor);
            }
            else
            {
                LinkedListNode<IInterceptor> p = _triggerChain.Last;
                while (p != null && p.Value.priority < interceptor.priority)
                {
                    p = p.Previous;
                }
                if (p == null)
                {
                    _triggerChain.AddFirst(interceptor);
                }
                else
                {
                    _triggerChain.AddAfter(p, interceptor);
                }
            }
        }
    }

    public void RemoveBackKeyInterceptor(IInterceptor interceptor)
    {
        _triggerChain.Remove(interceptor);
    }

    public void Start(Action defaultAction)
    {
        this.Stop();
        _defaultAction = defaultAction;
        _backKeyUpdator = EquineScheduler.AddFrameLimitUpdator(1, BackKeyUpdateHandler);
    }

    public void Stop()
    {
        EquineScheduler.RemoveLimitUpdator(ref _backKeyUpdator);
        _triggerChain.Clear();
        _defaultAction = null;
    }
    
    private void BackKeyUpdateHandler(int arg1, object arg2, UpdateTimeInfo arg3)
    {
#if UNITY_ANDROID || UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LinkedListNode<IInterceptor> p = _triggerChain.First;

            bool intercepted = false;

            while (p != null)
            {
                try
                {
                    InterceptResult result = p.Value.OnExecute();

                    if (result != InterceptResult.Continue)
                    {
                        intercepted = result == InterceptResult.Break;
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }

                p = p.Next;
            }

            if (!intercepted)
            {
                _defaultAction?.Invoke();
            }
        }
#endif
    }
}