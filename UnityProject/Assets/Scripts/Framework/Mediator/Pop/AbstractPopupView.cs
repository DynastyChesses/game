using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractPopupView : IPopupView
{
	private static readonly Vector3 MOVE_TO_SKY_POS = Vector3.up * 10000f;

	private GameObject _gameObject;

	private RectTransform _transform;
	private Vector3 _orgPos;

	private Canvas _mainCanvas;

	private string _name;

	protected ScriptViewSkin _viewSkin;

	private static int _popupIdCounter = 0;

	public UIPanelConfig uiConfig;

	public System.Action onMaskClick
    {
        get; set;
    }

    private System.Action _beforeEnter;
    public event System.Action beforeEnter
    {
        add
        {
            _beforeEnter += value;
        }
        remove
        {
            _beforeEnter -= value;
        }
    }

    private System.Action _afterEnter;
    public event System.Action afterEnter
    {
        add
        {
            _afterEnter += value;
        }
        remove
        {
            _afterEnter -= value;
        }
    }

    private System.Action _beforeExit;
    public event System.Action beforeExit
    {
        add
        {
            _beforeExit += value;
        }
        remove
        {
            _beforeExit -= value;
        }
    }
    
    private System.Action _afterExit;
    public event System.Action afterExit
    {
        add
        {
            _afterExit += value;
        }
        remove
        {
            _afterExit -= value;
        }
    }
    
    private System.Action _showViewAndRefresh;
    public event System.Action showViewAndRefresh
    {
	    add
	    {
		    _showViewAndRefresh += value;
	    }
	    remove
	    {
		    _showViewAndRefresh -= value;
	    }
    }
    
    private System.Action _showViewAndNoRefresh;
    public event System.Action showViewAndNoRefresh
    {
	    add
	    {
		    _showViewAndNoRefresh += value;
	    }
	    remove
	    {
		    _showViewAndNoRefresh -= value;
	    }
    }

	protected AbstractPopupView(GameObject viewObj, bool autoAnchor = true)
	{
		
		_gameObject = viewObj;
		_transform = viewObj.GetComponent<RectTransform>();
		_orgPos = _transform.localPosition;
		_viewSkin = viewObj.GetComponent<ScriptViewSkin>();
		
		_mainCanvas = UIUtil.SetupCanvas(viewObj);
		_mainCanvas.sortingOrder = 0;
		
		
		_mainCanvas.sortingOrder = 0;
  
		++_popupIdCounter;
		popupId = _popupIdCounter;
		this.autoAnchor = autoAnchor;
		
  //
		// 按钮，增加点击音效
		for ( int i = 0; i < _viewSkin.singlePropList.Count; i++ )
		{
			var s = _viewSkin.singlePropList[i];
  
            // 添加对GameObject类型的对象兼容
            if (s.propVal is GameObject go)
            {
                if (go != null)
                {
                    var uiButton = go.GetComponent<UIButton>();
                    if (uiButton && !string.IsNullOrEmpty(uiButton.clickAudioName))
                    {
                        uiButton.onClick.AddListener(() => { AudioFacade.instance.PlayClip(uiButton.clickAudioName, false); });
                    }
                }
            }
  
			else if (s.propVal is UIButton btn)
			{
				if( !string.IsNullOrEmpty( btn.clickAudioName ) )
				{
					btn.onClick.AddListener( () => { AudioFacade.instance.PlayClip( btn.clickAudioName, false ); } );
				}
			}
		}
  
		// 只能在这进行本地化操作
		var uiTexts = _transform.GetComponentsInChildren<UIText>( true );
		for ( int i = 0; i < uiTexts.Length; i++ )
		{
			var uit = uiTexts[i] as UIText;
			if( !string.IsNullOrEmpty( uit.key ) )
				uit.SetText( Language.GetContent( uit.key ) );
		}
	}

    //public Coroutine StartCoroutine(IEnumerator routine)
    //{
    //	return _viewSkin.StartCoroutine(routine);
    //}

    //public Coroutine StartCoroutine_Auto(IEnumerator routine)
    //{
    //	return _viewSkin.StartCoroutine(routine);
    //}

    //public Coroutine StartCoroutine(string methodName, object value)
    //{
    //	return _viewSkin.StartCoroutine(methodName, value);
    //}

    //public Coroutine StartCoroutine(string methodName)
    //{
    //	return _viewSkin.StartCoroutine(methodName);
    //}

    //public void StopCoroutine(string methodName)
    //{
    //	_viewSkin.StopCoroutine(methodName);
    //}

    //public void StopCoroutine(IEnumerator routine)
    //{
    //	_viewSkin.StopCoroutine(routine);
    //}

    //public void StopCoroutine(Coroutine routine)
    //{
    //	_viewSkin.StopCoroutine(routine);
    //}

    //public void StopAllCoroutines()
    //{
    //	_viewSkin.StopAllCoroutines();
    //}

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

    public int popupId
	{
		get;
		private set;
	}

	public string name
	{
		get
        {
			_name = _name ?? _gameObject.name;
			return _name;
        }
	}

	public bool isValid
	{
		get
        {
			return this._gameObject;
        }
	}

	public bool autoAnchor
    {
		get;
		private set;
    }

	public Transform parent
	{
		get
		{
			return this._transform ? this._transform.parent : null;
		}

		set
        {
			if (this._transform && this._transform.parent != value)
			{
				this._transform.SetParent(value, false);
			}
		}
	}

	public bool visible
    {
		get
        {
			// return this._gameObject && this._gameObject.activeSelf;
			return this._mainCanvas != null && this._mainCanvas.enabled;
        }

		set
        {
			// if (this._gameObject && this._gameObject.activeSelf != value)
            // {
			// 	this._gameObject.SetActive(value);
            // }
            if (this._mainCanvas != null && this._mainCanvas.enabled != value)
            {
	            this._mainCanvas.enabled = value;
	            if (value && this._mainCanvas.sortingOrder > 0)
	            {
		            this._mainCanvas.overrideSorting = true;
	            }
            }
        }
    }

	public bool visibleInHierarchy
    {
		get
        {
			return this._gameObject && this._gameObject.activeInHierarchy;
        }
    }

	public Vector3 localPosition
	{
		get
        {
			if (this._transform)
            {
				return this._transform.anchoredPosition;
            }
			return Vector3.zero;
        }

		set
        {
			if (this._transform)
            {
				this._transform.anchoredPosition = value;
            }
        }
    }

	public Quaternion localRotation
    {
		get
        {
			if (this._transform)
            {
				return this._transform.localRotation;
            }
			return Quaternion.identity;
        }

		set
        {
			if (this._transform)
            {
				this._transform.localRotation = value;
            }
        }
    }

	public Vector3 localScale
    {
		get
        {
			if (this._transform)
            {
				return this._transform.localScale;
            }
			return Vector3.one;
        }

		set
        {
			if (this._transform)
            {
				this._transform.localScale = value;
            }
        }
    }

	public int depth
	{
		get
		{
			if (this._mainCanvas)
            {
				return this._mainCanvas.sortingOrder;
            }
			return 0;
		}

		set
        {
			if (this._mainCanvas)
            {
	            if (!this._mainCanvas.overrideSorting)
	            {
		            this._mainCanvas.overrideSorting = true;
	            }
				this._mainCanvas.sortingOrder = value;
            }
        }
	}

	public virtual void ResetTransform()
    {
		if (this._transform)
        {
			// this._transform.anchoredPosition = Vector2.zero;
			this._transform.rotation = Quaternion.identity;
			this._transform.localScale = Vector3.one;
			this._transform.anchorMin = Vector2.zero;
			this._transform.anchorMax = Vector2.one;
			this._transform.offsetMax = Vector2.zero;
			this._transform.offsetMin = Vector2.zero;

        }
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
        _autoDisposeObjects.Clear();

        if (_gameObject)
		{
			_viewSkin = null;
			_gameObject = null;
		}
	}

	public virtual void BeforeEnter ()
	{
        if(_beforeEnter != null)
            _beforeEnter();
        DoBeforeEnter();
	}

	public void AfterEnter()
	{
        if(_afterEnter != null)
            _afterEnter();
        DoAfterEnter();
	}

	public virtual void BeforeExit()
    {
        if(_beforeExit != null)
            _beforeExit();
        DoBeforeExit();
    }
    
	public void AfterExit ()
	{
        if(_afterExit != null)
            _afterExit();
        DoAfterExit();
	}

	public void ShowViewAndRefresh()
	{
		if(_showViewAndRefresh != null)
			_showViewAndRefresh();
		DoShowViewAndRefresh();
	}

	public void ShowViewAndNoRefresh()
	{
		if(_showViewAndNoRefresh != null)
			_showViewAndNoRefresh();
		DoShowViewAndNoRefresh();
	}

	protected virtual void DoBeforeEnter(){}
    protected virtual void DoAfterEnter(){}
    protected virtual void DoBeforeExit(){}
    protected virtual void DoAfterExit(){}
    protected virtual void DoShowViewAndRefresh(){}
    protected virtual void DoShowViewAndNoRefresh(){}

    public void MoveToSky(bool toSky)
    {
	    if (_transform == null || _transform.gameObject == null)
	    {
		    return;
	    }
        if (toSky)
		{
			_transform.localPosition = MOVE_TO_SKY_POS;
		}
		else
		{
			_transform.localPosition = _orgPos;
		}
    }

    private bool _maskInteractive = true;

	public bool maskInteractive
	{
		get { return _maskInteractive; }
		set { _maskInteractive = value; }
	}

	public GameObject gameObject
    {
		get
        {
			return this._gameObject;
        }
    }
	
	public virtual BasePopupAnimation popupAnimation
	{
		get
		{
			return null;
		}
	}
	
	public virtual uint removeAllFlag => PopupRemoveMode.DEFAULT;
}
