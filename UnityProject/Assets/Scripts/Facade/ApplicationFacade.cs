using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ApplicationFacade : DefaultFacadeImpl
{
    class PooledNotification : Notification
    {
        private static readonly object _lockObj = new object();
        private static volatile PooledNotification _poolHead;

        private PooledNotification _next;

        public static PooledNotification Allocate(string name, object body = null, string type = null)
        {
            PooledNotification noti;
            if (_poolHead == null)
            {
                noti = new PooledNotification(name, body, type);
            }
            else
            {
	            lock (_lockObj)
	            {
		            noti = _poolHead;
		            _poolHead = noti._next;
	            }
	            noti._next = null;
                noti.Name = name;
                noti.Body = body;
                noti.Type = type;
            }
            return noti;
        }

        public override void Dispose()
        {
	        this.Name = null;
	        this.Body = null;
	        this.Type = null;
            lock (_lockObj)
            {
                this._next = _poolHead;
                _poolHead = this;
            }
        }

        private PooledNotification(string name, object body, string type) : base(name, body, type)
        {
        }


    }
	private static readonly object _staticSyncRoot = new object();

	private static ApplicationFacade _instance;

	private readonly Dictionary<string, int> _cachedNotiMap = new Dictionary<string, int>();
	private readonly List<INotification> _cachedNotiList = new List<INotification>();

	private bool _cachedNoti = false;
	
	// 增加性能监控
	public Stopwatch stopwatch = new Stopwatch();
	private double current = -1;

	public void ResetWatch()
	{
		stopwatch.Reset();
		current = 0;
	}

	public void StopWatch()
	{
		stopwatch.Stop();
		current = 0;
	}

	public void StartWatch()
	{
		if (stopwatch.IsRunning)
		{
			StopWatch();
			ResetWatch();
		}
		stopwatch.Start();
	}

	public string Counting()
	{
		string ret = "";
		if (stopwatch.IsRunning)
		{
			ret = ((int)stopwatch.Elapsed.TotalMilliseconds - current).ToString() + "毫秒";
			current = stopwatch.Elapsed.TotalMilliseconds;
		}
		return ret;
	}
	
	
	
	public bool cachedNotification
	{
		get { return _cachedNoti; }
		set
		{
			_cachedNoti = value;

			if (!_cachedNoti)
			{
				int count = _cachedNotiList.Count;

				for (int i = 0; i < count; ++i)
				{
					try
					{
						base.NotifyObservers(_cachedNotiList[i]);
					}
					catch (Exception e)
					{
						Debug.LogError(e);
					}
				}
				_cachedNotiList.Clear();
				_cachedNotiMap.Clear();
			}
		}
	}

	public void ResetCache()
	{
		_cachedNoti = false;
		_cachedNotiList.Clear();
		_cachedNotiMap.Clear();
	}

	public static  ApplicationFacade instance
	{
		get 
		{
			if (_instance == null)
			{
				lock (_staticSyncRoot)
				{
					if (_instance == null) 
                    {
                        _instance = new ApplicationFacade();
                        Facade.implement = _instance;
                    }
				}
			}
			
			return _instance;
		}
	}

	private int _stackNum = 0;

	public override void NotifyObservers(INotification notification)
	{
		try
		{
			_stackNum++;
			if (_stackNum >= 20)
			{
				Debug.LogError("Error SendNotification Stack");
				return;
			}
			DoNotifyObservers(notification);
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
		finally
		{
			_stackNum--;
		}
	}
    private void DoNotifyObservers(INotification notification)
	{
		if (!_cachedNoti)
		{
            base.NotifyObservers(notification);
		}
		else if (!_cachedNotiMap.TryGetValue(notification.Name, out var cacheIdx))
		{
			_cachedNotiMap.Add(notification.Name, _cachedNotiList.Count);
			_cachedNotiList.Add(notification);
		}
		else
		{
			int count = _cachedNotiList.Count;
			_cachedNotiMap[notification.Name] = count - 1;
			for (int i = cacheIdx; i < count - 1; ++i)
			{
				INotification tmp = _cachedNotiList[i];
				_cachedNotiList[i] = _cachedNotiList[i + 1];
				_cachedNotiList[i + 1] = tmp;
				_cachedNotiMap[_cachedNotiList[i].Name] = i;
			}
		}
	}

	public override void SendNotification(string notificationName)
	{
		NotifyObservers(PooledNotification.Allocate(notificationName));
	}

	public override void SendNotification(string notificationName, object body)
	{
        NotifyObservers(PooledNotification.Allocate(notificationName, body));
	}

	public override void SendNotification(string notificationName, object body, string type)
	{
        NotifyObservers(PooledNotification.Allocate(notificationName, body, type));
	}
}
