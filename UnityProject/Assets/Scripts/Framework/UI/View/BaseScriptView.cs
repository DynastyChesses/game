using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseScriptView :IResourceUnit, System.IDisposable, IGameObjectReplace
{
	public virtual string id
	{
		get
		{
			return gameObject.name;
		}
	}

	private GameObject _gameObject;
	private RectTransform _rectTransform;
	protected ScriptViewSkin _viewSkin;

    public GameObject helpBtn;

    public ScriptViewSkin viewSkin
    {
	    get
	    {
		    return _viewSkin;
	    }
    }
    
    public SpriteAtlasWrapper.Adapter spriteAdapter { get; private set; }
    
	public GameObject gameObject
	{
		get { return _gameObject; }
	}

	public RectTransform rectTransform
	{
		get
		{
			return _rectTransform;
		}
	}

	public bool enabled
	{
		get
		{
			return _viewSkin?.enabled ?? true;
		}

		set
		{
			if (_viewSkin != null)
				_viewSkin.enabled = value;
		}
	}

	public BaseScriptView()
	{
		spriteAdapter = new SpriteAtlasWrapper.Adapter();
	}

	public BaseScriptView(GameObject viewObj)
	{
		spriteAdapter = new SpriteAtlasWrapper.Adapter();
		
		Replace(viewObj);
	}
	
	// Refresh Language
	public void SetObjectAndViewSkin(GameObject viewObj)
    {
	    if (viewObj == null)
	    {
		    Debug.LogError("SetObjectAndViewSkin Object is Null");
		    return;
	    }
        _gameObject = viewObj;
        _rectTransform = _gameObject.GetComponent<RectTransform>();
        _viewSkin = viewObj.GetComponent<ScriptViewSkin>();

        if (_viewSkin == null)
        {
	        return;
        }

#if RG_WECHAT_MINIGAME
        UIMediator.BindingWxInputs(_viewSkin);  
#endif
    }
    public virtual void  Replace(GameObject viewObj)
	{
        SetObjectAndViewSkin(viewObj);
    }

	private readonly List<IDisposable> _autoDisposeObjects = new List<IDisposable>();
	private readonly Dictionary<UnityEvent, List<UnityAction>> _autoRemoveListeners = new Dictionary<UnityEvent, List<UnityAction>>();

	/// <summary>
	/// 注册自动释放对象
	/// </summary>
	/// <param name="obj">目标对象</param>
	/// <returns>目标对象自身</returns>
	public virtual object RegisterAutoDisposeObject(IDisposable obj)
	{
		if (obj == null) return null;
		_autoDisposeObjects.Add(obj);
		return obj;
	}

	/// <summary>
	/// 注册自动移除监听器
	/// </summary>
	/// <param name="listener"></param>
	/// <param name="action"></param>
	public virtual void RegisterAutoRemoveListener(UnityEvent listener, UnityAction action)
    {
        if (listener == null || action == null) return;
        if (!_autoRemoveListeners.TryGetValue(listener, out var actions))
		{
			actions = new List<UnityAction>();
            _autoRemoveListeners.Add(listener, actions);
		}
		actions.Add(action);
		listener.AddListener(action);
    }
	
	public void StopAllCoroutines()
	{
		_viewSkin.StopAllCoroutines();
	}

	public virtual void Dispose()
	{
		// 自动移除监听器处理
		foreach (var listener in _autoRemoveListeners.Keys)
        {
			if (listener == null) continue;
			foreach (var action in _autoRemoveListeners[listener])
            {
				if (action == null) continue;
                listener.RemoveListener(action);
            }
			_autoRemoveListeners[listener].Clear();
        }
		_autoRemoveListeners.Clear();

		// 自动释放对象处理
		foreach (var obj in _autoDisposeObjects)
		{
			obj?.Dispose();
		}
		
		spriteAdapter?.Dispose();
		spriteAdapter = null;
		
		_autoDisposeObjects.Clear();
		
		_viewSkin = null;
		_gameObject = null;
	}
	
}
