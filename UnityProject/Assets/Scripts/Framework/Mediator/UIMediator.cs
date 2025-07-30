using System;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

public delegate void StringAction(string obj);

public delegate void CharAction(char obj);

public delegate void ByteAction(byte obj);

public delegate void ShortAction(short obj);

public delegate void UshortAction(ushort obj);

public delegate void IntAction(int obj);

public delegate void Int2Action(int obj1, int obj2);

public delegate void UintAction(uint obj);

public delegate void LongAction(long obj);

public delegate void UlongAction(ulong obj);

public delegate void DecimalAction(decimal obj);

public delegate void FloatAction(float obj);

public delegate void Float2Action(float obj1, float obj2);

public delegate void DoubleAction(double obj);

public delegate void BoolAction(bool obj);

public delegate void EnumAction(Enum obj);

public delegate void Vector2Action(Vector2 obj);

public delegate void Vector2IntAction(Vector2Int obj);

public delegate void Vector3Action(Vector3 obj);

public delegate void ObjectAction(object obj);

public delegate void GameObjectAction(GameObject obj);

public delegate void ObjectListAction(ArrayList obj);
 
public delegate void Int2Float2Action(int int1, int int2, float float1, float float2);

public abstract class UIMediator: AbstractMediator
{
	private Dictionary<string, ObjectAction> _notificationMapping = null;
	private Dictionary<string, bool> _ignoreMapping = null;
    private List<string> _notifications = new List<string>();

    private Dictionary<string, object> _cacheNotifications = new Dictionary<string, object>();
    
    private bool _hasExecuteCacheNotifications = false;

    public bool hasExecuteCacheNotifications => _hasExecuteCacheNotifications;

    public virtual bool isActive
	{
		get
		{
			return true;
		}
	}

	public abstract bool isLoading { get; }

	public UIMediator(string mediatorName): base(mediatorName) { }

    public override IList<string> ListNotificationInterests ()
    {
        return _notifications;
    }

    public override void OnRemove()
    {
        base.OnRemove();
    }
    
    public override void HandleNotification (INotification notification)
    {
        string key = notification.Name;
		if (_notificationMapping == null || !_notificationMapping.ContainsKey(key))
            return;
		if (!isActive && isLoading)
		{
			if (!_cacheNotifications.ContainsKey(key))
			{
				_cacheNotifications.Add(key, notification.Body);
				if (!_hasExecuteCacheNotifications)
				{
					_hasExecuteCacheNotifications = true;
				}
			}

			return;
		}

		if (!isActive && _ignoreMapping[key])
			return;
		
		_notificationMapping[key].Invoke(notification.Body);
    }
    
    protected void RegisterNotificationHandler(string key, ObjectAction action, bool ignoreWhenInActive = false)
    {
	    _notificationMapping = _notificationMapping ?? new Dictionary<string, ObjectAction>();
	    _ignoreMapping = _ignoreMapping ?? new Dictionary<string, bool>();
	    if (_notificationMapping.ContainsKey(key))
	    {
		    _notificationMapping[key] = action;
		    _ignoreMapping[key] = ignoreWhenInActive;
	    }
	    else
	    {
		    _notificationMapping.Add(key, action);
		    _ignoreMapping.Add(key, ignoreWhenInActive);
	    }
	    if(!_notifications.Contains(key))
            _notifications.Add(key);
    }

    protected void ClearCacheNotifications()
    {
	    _cacheNotifications.Clear();
	    _hasExecuteCacheNotifications = false;
    }

    protected void HandleCacheNotification()
    {
	    var itor = _cacheNotifications.GetEnumerator();
	    while (itor.MoveNext())
	    {
		    ObjectAction objectAction = null;
		    _notificationMapping?.TryGetValue(itor.Current.Key, out objectAction);
		    objectAction?.Invoke(itor.Current.Value);
	    }

	    _hasExecuteCacheNotifications = false;
    }
}