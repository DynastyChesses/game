using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using PureMVC.Patterns;


public class CommonNotification
{
	public const string ENTER_SCENE = "EnterScene";
	public const string ENTER_SCENE_FIRST_TIME = "EnterSceneFirstTime";
	public const string LEAVE_SCENE = "LeaveScene";
	public const string SERVER_RECONNECT_COMPLETE = "ServerReconnectComplete";
	public const string SHOW_PANEL = "ShowPanel";
	public const string ON_SHOW_MAP_MENU = "OnShowMapMenu";
	public const string ON_HIDE_MAP_MENU = "OnHideMapMenu";
	public const string REFRESH_TOP_RES_VIEW = "RefreshTopResView";
    
	public const string DISTURB_CURRENT_GUIDE = "DisturbCurrentGuide";
	public const string FINISH_CURRENT_GUIDE = "FinishCurrentGuide";
	public const string TRIGGER_RUNTIME_GUIDE = "TriggerRuntimeGuide";
	public const string TRIGGER_STATIC_GUIDE = "TriggerStaticGuide";
	public const string RESET_GUIDE = "ResetGuide";
	public const string ALL_GUIDE_FINISH = "AllGuideFinish";
	public const string FINISH_CURRENT_GUIDE_TALK = "FinishCurrentGuideTalk";
}

public abstract class BaseUIMediator : UIMediator
{
    // UI打开时间阈值，超过这个时间会上报BI
    private const int UI_OPEN_TIME_THRESHOLD = 500;

	enum CloseFlag
	{
		WillRecycle,
		DontRecycleOnce,
		NeverRecycle
	}

	enum ShowResult
	{
		Normal,
		NoResource,
		Error
	}

    #region Field

    public readonly string SHOW_NOTIFICATION;

	public readonly string HIDE_NOTIFICATION;
	
	public const string SHOW_UI_MEDIATOR = "SHOW_UI_MEDIATOR";

    public const string MARK_ALL_HIDDEN_VIEW_RECYCLABLE = "MarkAllHiddenViewRecyclable";

	public const string REMOVE_ALL_OPEN_VIEW = "RemoveAllOpenView";

    protected IPopupFacade popupManagerDelegate;
	protected ResourceReleaseFacade _resReleaseManager;
    
    protected BaseGamePopupView _baseView;
    protected virtual void OnClearBaseView() {}

    private object _openParam = null;

    private ArrayList _guideTargetList;

    private ResourceReleaseFacade.ResourceToken _token;
    private ParamAsyncPrefabLoadRequest _prefabRequest;

    protected bool _hasClickedReturn = false;
    private bool _isLoadingResources = false;
	private CloseFlag _closeFlag = CloseFlag.NeverRecycle;

	public override bool isLoading => _isLoadingResources;

	protected long? _startShowTime = null;

	#endregion

    #region Construct
    public BaseUIMediator (string mediatorName, string showNotification, string hideNotification = null):base(mediatorName)
    {
        SHOW_NOTIFICATION = showNotification;
	    HIDE_NOTIFICATION = hideNotification;
        RegisterNotificationHandler(SHOW_NOTIFICATION, ShowView);
	    RegisterNotificationHandler(CommonNotification.LEAVE_SCENE, BeforeLeaveScene);
        RegisterNotificationHandler(MARK_ALL_HIDDEN_VIEW_RECYCLABLE, MarkRecyclable);
	    RegisterNotificationHandler(REMOVE_ALL_OPEN_VIEW, OnForceRemovePanel);
		if (HIDE_NOTIFICATION != null)
		{
			RegisterNotificationHandler(HIDE_NOTIFICATION, OnRemovePanel);
		}

        // 多语言增量刷新处理
        RegisterNotificationHandler("LOCALE_FINISH_CALLBACK", RefreshUITextLanguage);
        _token = null;
    }
    #endregion

	/// <summary>
	/// 刷新UIText多语言
	/// </summary>
	/// <param name="obj"></param>
	public void RefreshUITextLanguage(object obj = null)
	{
        if (_baseView == null) return;
        
        var uiTexts = _baseView.gameObject.GetComponentsInChildren<UIText>(true);
        for (int i = 0; i < uiTexts.Length; i++)
        {
            var uit = uiTexts[i] as UIText;
            if (!string.IsNullOrEmpty(uit.key))
                uit.SetText(Language.GetContent(uit.key));
        }
    }

    private readonly List<IDisposable> _autoDisposeObjects = new List<IDisposable>();

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
    /// 如果没有设置CustomManageMemory = true，则管理器会在适当的时机调用传进去的Dispose来释放ResourceUnit
    /// </summary>
    public void Dispose(IResourceUnit unit, ResourceReleaseFacade.ResourceToken token)
    {
        _baseView = unit as BaseGamePopupView;
        if(_baseView != null)
        {
	        if (_baseView.returnBtn != null)
		        UIEventListener.OnClick(_baseView.returnBtn).RemoveListener(OnReturnButtonClick);
			if(_baseView.helpBtn!= null)
                UIEventListener.OnClick(_baseView.helpBtn).RemoveListener(HelpBtnClick);
            _baseView.onMaskClick -= OnReturnMaskClick;
            _baseView.afterEnter -= AfterShowViewListener;
            _baseView.afterExit -= AfterHideViewListener;
            _baseView.beforeEnter -= BeforeShowViewListener;
            _baseView.beforeExit -= BeforeHideViewListener;
            _baseView.showViewAndRefresh -= ShowViewAndRefresh;
            _baseView.showViewAndNoRefresh -= ShowViewAndNoRefresh;
            
			if (_guideTargetList != null)
			{
				_guideTargetList.Clear();
			}
			BeforeViewDispose();
			
			OnDispose();

            // 自动释放对象处理
            foreach (var obj in _autoDisposeObjects)
            {
                obj?.Dispose();
            }
            _autoDisposeObjects.Clear();

            _baseView.Dispose();
            _baseView = null;
            _token = null;
        }
    }

    protected virtual void OnDispose()
    {
	    
    }

    #region Override
    protected bool _isActive;

    public override bool isActive
    {
        get { return _isActive; }
    }

	public override void OnRegister()
	{
        base.OnRegister();
		popupManagerDelegate = PopupFacade.instance;
        _resReleaseManager = ResourceReleaseFacade.instance;
	}
     
    public override void OnRemove ()
    {
	    CancelResourceLoad();
        // Dispose(_baseView, null);
        base.OnRemove();
    }
    #endregion
	protected void ManagedGuideTarget(string targetName, GameObject target)
	{
		_guideTargetList = _guideTargetList ?? new ArrayList();
		_guideTargetList.Add(targetName);
		_guideTargetList.Add(target);
	}

	#region Protected Methods
	
	/// <summary>
	/// 打开上一层的面板，会把history栈顶的context弹出来，并把这个history传回给上层面板，如果要使用新数据刷新上层面板，则需要自己传入新数据。
	/// 若上一层面板不存在,则只隐藏自己
	/// </summary>
	/// <param name="refresh">If set to <c>true</c> 刷新上层面板.</param>
	protected void OpenPrevView()
	{
		HideSelf();
	}

	protected void OpenNextView(string nextView, bool hideSelf = false, object data = null)
	{
		if (hideSelf)
		{
			HideSelf();
		}
		
		SendNotification(nextView, data);
	}

	/// <summary>
	/// 隐藏面板.并且回收所有隐藏的面板
	/// </summary>
	protected void HideView(bool recycleAll = true)
	{
		HideSelf();
		if (recycleAll)
		{
			SendNotification(MARK_ALL_HIDDEN_VIEW_RECYCLABLE);
		}
	}
    
	#endregion
	
    #region Private Methods

    private void HideSelf()
    {
	    CancelResourceLoad();

//        if (_isActive && _baseView != null && !popupManagerDelegate.IsHiding(_baseView))
	    if (_baseView != null && !popupManagerDelegate.IsHiding(_baseView))
        {
            popupManagerDelegate.RemovePopup(_baseView);
        }
    }
    
    private void OnResourcesLoaded(GameObject go, string error, object data)
    {
	    _isLoadingResources = false;
	    if (go == null)
		    Logger.Error($"go is null. {m_mediatorName}");
	    if(string.IsNullOrEmpty(error))
	    {
		    DoShow(go);
	    }
    }

    private ShowResult DoShow(GameObject go)
    {
        _hasClickedReturn = false;
        object data = _openParam;

		if (!_isActive)
		{
			if (_token == null)
			{
				if (_baseView == null)//第一次创建，或被回收后再次创建
				{
					if (go == null)
					{
						return ShowResult.NoResource;
					}

					_baseView = CreateView(go, data);
					InitConstLabel(data);
					if (_baseView.returnBtn != null)
						UIEventListener.OnClick(_baseView.returnBtn).AddListener(OnReturnButtonClick);
                    if (_baseView.helpBtn != null)
                        UIEventListener.OnClick(_baseView.helpBtn).AddListener(HelpBtnClick);
                    _baseView.onMaskClick += OnReturnMaskClick;
					_baseView.beforeEnter += BeforeShowViewListener;
					_baseView.afterEnter += AfterShowViewListener;
					_baseView.beforeExit += BeforeHideViewListener;
					_baseView.afterExit += AfterHideViewListener;
					_baseView.showViewAndRefresh += ShowViewAndRefresh;
					_baseView.showViewAndNoRefresh += ShowViewAndNoRefresh;
				}
				//                else//票据被回收，但资源没被销毁
				//                {
				//                    FibMatrix.Logger.Error("_token == null && _baseView != null， 一般是因为在窗口没关闭的时候再次发送显示窗口的消息");
				//                    return;
				//                }
			}
			else//有票据
			{
				if (_baseView == null)
				{
					if (!customManageMemory)
					{
						_baseView = _resReleaseManager.Acquire(_token) as BaseGamePopupView;//用票据去管理者那里取回箱子
						_token = null;
						if (_baseView == null)
						{
							Debug.LogError("Acquire empty box : " + _token);
							return ShowResult.Error;
						}
					}
					else
					{
						Debug.LogError("customManageMemory mode should't have token");
						return ShowResult.Error;
					}
				}
				else
				{
					Debug.LogError("Should not have _baseView when have _token");
					return ShowResult.Error;
				}
			}

			DoPopupShow(data);
			_isActive = true;
		}
		else
		{
			DoPopupShow(data);
		}

	    _closeFlag = customManageMemory ? CloseFlag.NeverRecycle : CloseFlag.WillRecycle;
        
        return ShowResult.Normal;
    }

    protected virtual int GetLayer()
    {
	    return 0;
    }

	private void DoPopupShow(object data)
	{
		if (_baseView == null)
		{
			Debug.Log($"base view is null, mediator: {m_mediatorName}!!!");
			return;
		}

		if (popupManagerDelegate == null)
		{
			Debug.Log($"popupManagerDelegate is null!!!");
			return;
		}
		
		// 判断

		if (popupManagerDelegate.HasPopup(_baseView, false))
		{
			Debug.Log($"_baseView===>(1) {_baseView.name} {popupManagerDelegate.IsHiding(_baseView)}");
			if (popupManagerDelegate.IsHiding(_baseView))
			{
				popupManagerDelegate.ForceRemoveHidingPanel(_baseView);
				if (_token != null)
				{
					_baseView = _resReleaseManager.Acquire(_token) as BaseGamePopupView;
					_token = null;
				}
				Dictionary<uint, object> paramDic = GetParamDic(data);
				popupManagerDelegate.AddPopup(_baseView, GetPopupMode(), paramDic, GetLayer(), isFullScreen:GetIsFullScreen());
			}
			else
			{
				Dictionary<uint, object> paramDic = GetParamDic(data);
				popupManagerDelegate.RefreshPopup(_baseView, GetPopupMode(), paramDic, GetLayer());
			}
		}
		else
		{
			Dictionary<uint, object> paramDic = GetParamDic(data);
			popupManagerDelegate.AddPopup(_baseView, GetPopupMode(), paramDic, GetLayer(), isFullScreen:GetIsFullScreen());
		}
	}
    #endregion
    
    
    #region NotificationHandler
    /// <summary>
    /// Shows the view.在BeforeShowView前调用。
    /// </summary>
    /// <param name="param">Parameter.</param>
    private void ShowView (object param = null)
    {
	    //如果正在加载资源时再次收到打开面板的请求，直接返回不处理
	    if(_isLoadingResources)
	    {
		    DoLoadingResourcesLogic(param);   // 当正在加载资源时(这时又有其他地方有该面板请求)，做一些特殊处理
		    return;
	    }

	    _openParam = param;

	    if (!CheckCanShow(param))
	    {
		    return;
	    }

	    //#if DEBUG
	    //		_startShowTime = RealTimer.elapsedMilliseconds;
	    //		FibMatrix.Logger.Debug($"*** Start loading UIMediator {m_mediatorName}");
	    //#endif

	    _startShowTime = null;
	    GameObject go = null;
	    string prefabPath = GetUIPrefabPath(param);
	    UIManager.instance.IsUIPreloaded(prefabPath, out go);
	    var showResult = DoShow(go);
	    if (showResult == ShowResult.NoResource)
	    {
		    if (!string.IsNullOrEmpty(prefabPath)) //有资源要预加载
		    {
			    _prefabRequest = _prefabRequest ?? new ParamAsyncPrefabLoadRequest();
			    _isLoadingResources = true;
			    _prefabRequest.data = param;
			    _prefabRequest.LoadPrefabsAsync(prefabPath, OnResourcesLoaded);
		    }
		    else
		    {
			    _isLoadingResources = false;
			    Logger.Error("No UIPrefabPath set");
		    }
	    }
	    

	    // 界面打开记录
	    _startShowTime = DateTime.Now.Ticks;
    }

    private void CancelResourceLoad()
    {
	    if (_isLoadingResources)
	    {
		    _isLoadingResources = false;
		    if (_prefabRequest != null)
		    {
			    _prefabRequest.Cancel();
			    _prefabRequest = null;
		    }
	    }
    }

	private void OnRemovePanel(object param)
	{
	    if (isActive || _isLoadingResources)
		{
			OpenPrevView();
		}
	}

	private void OnForceRemovePanel(object param)
	{
		HideView((bool)param);
	}

	private void MarkRecyclable(object param = null)
	{
		if (_closeFlag == CloseFlag.DontRecycleOnce)
		{
			_closeFlag = CloseFlag.WillRecycle;
			DoRecycle();
		}
	}

	private void DoRecycle()
    {
        if(!_isActive && !customManageMemory && _baseView != null && _closeFlag == CloseFlag.WillRecycle)
        {
            _token = _resReleaseManager.Recycle(_baseView, Dispose);
            _baseView = null;
        }
    }

    private void BeforeLeaveScene(object param)
    {
	    DoBeforeLeaveScene();
    }

	#endregion

	#region Component callback

	private const string ON_POPUPVIEW_BEFORE_SHOW = "ON_POPUPVIEW_BEFORE_SHOW";
	private const string ON_POPUPVIEW_BEFORE_HIDE = "ON_POPUPVIEW_BEFORE_HIDE";
	private const string ON_POPUPVIEW_REMOVE      = "ON_POPUPVIEW_REMOVE";
	private void BeforeShowViewListener()
	{
		BeforeShowView();
        ApplicationFacade.instance.SendNotification(ON_POPUPVIEW_BEFORE_SHOW, this.MediatorName);
	}

	private void AfterShowViewListener()
    {
        AfterShowView();
    }

    private void BeforeHideViewListener()
    {
	    _hasClickedReturn = true;
        BeforeHideView();
        ApplicationFacade.instance.SendNotification(ON_POPUPVIEW_BEFORE_HIDE, this.MediatorName);
    }

    private void AfterHideViewListener()
    {
	    _isActive = false;
	    DoRecycle();
        AfterHideView();
        //clear cache notification
        ClearCacheNotifications();
        ApplicationFacade.instance.SendNotification(ON_POPUPVIEW_REMOVE);
    }
    
    private void ShowViewAndRefresh()
    {
	    try
	    {
		    OnShowViewAndRefresh(_openParam);
		    SendNotification(SHOW_UI_MEDIATOR, MediatorName);
	    }
	    catch (Exception e)
	    {
		    Debug.LogError(e);
	    }
    }

    private void ShowViewAndNoRefresh()
    {
	    try
	    {
		    OnShowViewNoRefresh(_openParam);
	    }
	    catch (Exception e)
	    {
		    Debug.LogError(e);
	    }
    }

    protected void OnReturnButtonClick(GameObject button)
    {
        if(_hasClickedReturn)
        {
            return;
        }
        _hasClickedReturn = true;
        PlayReturnButtonClickSound(button);
        DoOnReturnButtonClick(button);
        DoOnReturnButtonOrMaskClick();
    }

    protected void HelpBtnClick(GameObject button)
    {
        ApplicationFacade.instance.SendNotification("ShowCommonInfoPanel", _baseView.helpBtn.name);
    }

    protected void OnReturnMaskClick()
    {
        if(_hasClickedReturn)
        {
            return;
        }
        _hasClickedReturn = true;
        PlayReturnMaskClickSound();
        DoOnReturnMaskClick();
        DoOnReturnButtonOrMaskClick();
    }

    #endregion

    #region Abstract & Virtual
    protected virtual bool customManageMemory { get { return false; } }

    protected virtual bool CheckCanShow(object param = null)
    {
        return true;
    }

    /// <summary>
    /// 从子类里得到需要预加载的资源路径
    /// </summary>
    /// <param name="data">SendNotification里带的data，和OnShowViewAndRefresh的参数相同</param>
    /// <param returns>资源路径</returns>
    protected abstract string GetUIPrefabPath(object data);

    protected abstract BaseGamePopupView CreateView(GameObject prefab, object data);
    protected virtual void InitConstLabel(object data){}
    protected abstract void OnShowViewAndRefresh(object data);
    protected virtual void OnShowViewNoRefresh(object data){}

    /// <summary>
    /// 显示动画结束前调用
    /// </summary>
    /// <param name="data">Data.</param>
    protected virtual void BeforeShowView(){}
    /// <summary>
    /// 显示动画结束后调用
    /// </summary>
	protected virtual void AfterShowView()
    {
        if (_startShowTime.HasValue)
        {
            var uiOpenTime = (long)new TimeSpan(DateTime.Now.Ticks - _startShowTime.Value).TotalMilliseconds;
            var prefabPath = GetUIPrefabPath(null);
            
            // 日志记录 TODO
            
            // BI上报 TODO
            
        }
        _startShowTime = null;
    }
    protected virtual void BeforeHideView(){}
    /// <summary>
    /// 隐藏动画结束后调用，做相应的销毁工作
    /// </summary>
    protected virtual void AfterHideView()
    {
        // UI日志 TODO
    }

    /// <summary>
    /// 在View.Dispose之前调用，根据CustomManageMemory变量，一个Mediator可能自己管理View的释放或者让管理者通知View的释放时机。
    /// </summary>
    protected virtual void BeforeViewDispose(){}

    protected virtual void DoBeforeLeaveScene(){}

    protected virtual uint GetPopupMode()
    {
        return PopupMode.ANIMATED;
    }
    protected virtual bool GetIsFullScreen()
    {
	    return false;
    }
    protected virtual void FillAnimationDTO(ref PopupAnimationDTO dto)
    {
        dto.duration = PopupAnimationDTO.defaultDTO.duration;
    }

	protected virtual Dictionary<uint, object> GetParamDic(object data)
    {
        return null;
    }

    protected virtual void PlayReturnButtonClickSound(GameObject button)
    {
        // 播放声音 TODO
    }

    protected virtual void PlayReturnMaskClickSound()
    {
        // RuntimeAudioManager.PlayOnce(AudioNameConst.CLOSE_PANEL);
    }

    protected virtual void DoOnReturnButtonClick(GameObject button)
    {
        OpenPrevView();
    }

    protected virtual void DoOnReturnMaskClick()
    {
        OpenPrevView();
    }

    protected virtual void DoLoadingResourcesLogic(object param)
    {
    }

    /// <summary>
    /// ReturnButton或ReturnMask点击后都会触发这个函数
    /// </summary>
    protected virtual void DoOnReturnButtonOrMaskClick()
    {

    }

    #endregion
    
    protected void RefreshTopResource(ulong[] modes)
    {
		// TODO
    }
}
