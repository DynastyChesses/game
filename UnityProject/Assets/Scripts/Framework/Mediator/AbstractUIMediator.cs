using System;

using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;
// using Thrift.Protocol;
using UnityEngine;
using PureMVC.Core;

public abstract class AbstractUIMediator : AbstractMediator
{
    // protected CommunicationCenter _cmCenter = CommunicationCenter.instance;
    // private Dictionary<string, Action<TBase>> _messageMapping = null;
	private Dictionary<string, ObjectAction> _notificationMapping = null;
	private Dictionary<string, bool> _ignoreMapping = null;
    private List<string> _notifications = new List<string>();

	public virtual bool isActive
	{
		get
		{
			return true;
		}
	}
    
	public AbstractUIMediator(string mediatorName): base(mediatorName) { }

    public override IList<string> ListNotificationInterests ()
    {
        return _notifications;
    }

    public override void OnRemove()
    {
        // if(_messageMapping != null)
        // {
        //     List<string> keys = new List<string>(_messageMapping.Keys);
        //     int count = keys.Count;
        //     for(int i = 0; i < count; ++i)
        //     {
        //         string key = keys[i];
        //         UnRegisterMessageHandler(key);
        //     }
        // }
        base.OnRemove();
    }
    
    public override void HandleNotification (INotification notification)
    {
        string key = notification.Name;
		if (_notificationMapping == null || !_notificationMapping.ContainsKey(key) || (!isActive && _ignoreMapping[key]))
            return;
		_notificationMapping[key].Invoke(notification.Body);
    }

    /// <summary>
    /// 注册要监听的游戏内部的Notification，不用Unregister,此函数要在注册meidiator之前调用才有效,推荐在构造函数内调用.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="action">Action.</param>
    protected void RegisterNotificationHandler(string key, ObjectAction action, bool ignoreWhenInActive = false)
    {
	    _notificationMapping = _notificationMapping ?? new Dictionary<string, ObjectAction>();
	    _ignoreMapping = _ignoreMapping ?? new Dictionary<string, bool>();

	    _notificationMapping[key] = action;
	    _ignoreMapping[key] = ignoreWhenInActive;
	    if(!_notifications.Contains(key))
            _notifications.Add(key);
    }

    private void HandleMessage(INotification message)
    {
     //    TBase tmsg = message.Body as TBase;
     //    string key = tmsg.signature;
     //    if(_messageMapping == null || !_messageMapping.ContainsKey(key))
     //        return;
	    // _messageMapping[key].Invoke(tmsg);
	}

    /// <summary>
    /// 注册要监听的服务器返回的Message，需要Unregister。
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="action">Action.</param>
    // protected void RegisterMessageHandler(string key, Action<TBase> action)
    // {
    //     // _messageMapping = _messageMapping ?? new Dictionary<string, Action<TBase>>();
    //     //
    //     // if (!_messageMapping.ContainsKey(key))
    //     // {
    //     //     View.Instance.RegisterObserver(key, new Observer(HandleMessage, this));
    //     //     _messageMapping.Add(key, action);
    //     // }
    //     // else
    //     // {
    //     //     _messageMapping[key] = action;
    //     // }
    // }

    /// <summary>
    /// 注销监听服务器返回的Message
    /// </summary>
    /// <param name="key">Key.</
    ///
    ///                                                                                                              param>
    // protected void UnRegisterMessageHandler(string key)
    // {
    //     if (_messageMapping != null && _messageMapping.ContainsKey(key))
    //     {
    //         _messageMapping.Remove(key);
    //         View.Instance.RemoveObserver(key, this);
    //     }
    // }
}
