using System;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPopupFacadeImpl:IPopupFacade
{
	private readonly int[] _initPopupDepths;
	private readonly int[] _currentPopupDepths;// = PopupConfig.INITIALIZE_POPUP_DEPTH;

    // private int[] _popupZs;// = PopupConfig.INITIALIZE_POPUP_Z;

    private IPopupView _currentPopup;

	private readonly Transform[] _popupLayers;

	private readonly Dictionary<int, PopupParam> _paramDic;
	
	private readonly List<PopupParam> _history;
	
	private readonly CommonUIWidget[] _commonUIWidgets;
	private int _commonUIWidgetsFlag;
	
	private readonly PopupQueueAction[] _popupQueueActions;
	private readonly uint _popupQueueActionFlag;

	private readonly BasePopupAction[] _actionList;

	private readonly uint _animatedModeFlag;

	private readonly int _defaultLayer;

	//private IUpdateFacade _updateFacade;
	public const string ONLY_MAIN_PANEL_SHOW = "OnlyMainPanelShow";
	public DefaultPopupFacadeImpl((Transform, int)[] popupLayerConfigs, int defaultLayer,
		CommonUIWidget[] commonUIWidgets,
		PopupQueueAction[] popupQueueActions,
		BasePopupAction[] actionList,
		uint animatedModeFlag)
	{
		int layerNum = popupLayerConfigs.Length;
		_initPopupDepths = new int[layerNum];
		_currentPopupDepths = new int[layerNum];
		_popupLayers = new Transform[layerNum];
		_defaultLayer = MathUtil.ClampInt(defaultLayer, 0, layerNum - 1);
		_paramDic = new Dictionary<int, PopupParam>();

		_history = new List<PopupParam>();
		_commonUIWidgets = commonUIWidgets;
		for (int i = 0, count = _commonUIWidgets?.Length ?? 0; i < count; i++)
		{
			_commonUIWidgetsFlag |= 1 << i;
		}

		_popupQueueActions = popupQueueActions;
		for (int i = 0, count = _popupQueueActions?.Length ?? 0; i < count; i++)
		{
			_popupQueueActionFlag |= _popupQueueActions[i].mode;
		}

		_actionList = actionList;

		int len = _actionList != null ? _actionList.Length : 0;
		for (int i = 0; i < len; ++i)
		{
			_actionList[i].popupManagerDelegate = this;
		}

		for (int i = 0; i < layerNum; ++i)
		{
			_popupLayers[i] = popupLayerConfigs[i].Item1;
			_initPopupDepths[i] = _currentPopupDepths[i] = popupLayerConfigs[i].Item2;
		}

		_animatedModeFlag = animatedModeFlag;
	}

	/// <summary>
	/// 娓呯悊PopupManager銆傛瘡娆″垏鎹㈠満鏅椂閮藉簲璇ヨ皟鐢ㄨ鏂规硶銆?	/// </summary>
	public void Clear()
	{
		DoRemoveAllPopup(true, PopupRemoveMode.FORCE);
		_currentPopup = null;
	}

	public bool HasPopup(IPopupView view, bool includeHiding = true)
	{
		if (!_paramDic.ContainsKey(view.popupId) || (!includeHiding && view.popupAnimation != null && view.popupAnimation.isPlayingReverse))
		{
			return false;
		}

		return true;
	}

	public bool HasAnyPopup()
	{
		return _paramDic != null && _paramDic.Count > 0;
	}
	
	public int GetPopupCount()
	{
		if (_paramDic == null)
		{
			return 0;
		}
		return _paramDic.Count;
	}

	private bool _managedMainUI = false;
	
	public bool IsMainUIManaged()
	{
		return _managedMainUI;
	}

	public void ResetManageMainUI()
	{
		_managedMainUI = false;
#if UNITY_EDITOR || DEBUG
		Debug.LogError($"PopupFacade ResetManageMainUI state change {_managedMainUI}");
#endif
	}

	public void ManageMainUI(IPopupView curView)
	{
		_managedMainUI = true;
#if UNITY_EDITOR || DEBUG
		Debug.LogError($"PopupFacade ManageMainUI state change {_managedMainUI} | {curView?.name}");
#endif
		//将当前hud设置到最低层级 界面是hud 不能参与pop计算
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (curView == view)
				{
					curView.depth = UIManager.POPUP_LAYER_ORDER;
					_history.Remove(param);
					_history.Insert(0,param);
					break;
				}
			}
		}
	}

	private Dictionary<int,bool> _stashCache = new Dictionary<int,bool>();

	public void SetViewShow(IPopupView view, bool show)
	{
		if(!_stashCache.ContainsKey(view.popupId))
		{
			view.visible = show;
		}
	}

	public void HideViewBelow(IPopupView targetView)
	{
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (view == targetView)
				{
					continue;
				}
				if (view.depth < targetView.depth)
				{
					SetViewShow(view, false);
				}
			}
		}
	}
	
	public void ShowAllView()
	{
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				SetViewShow(view, true);
			}
		}
	}

	public void Stash()
	{
		_stashCache.Clear();
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (view.depth > UIManager.POPUP_LAYER_ORDER)
				{
					_stashCache.Add(view.popupId,view.visible);
					view.visible = false;
				}
			}
		}
		UIManager.ForceShowMainCamera();
		UIManager.ForceShowSceneUI();
	}
	
	public void StashPop()
	{
		// AddBlurMaskPopupAction.canHandleMainUI = true;
		if (_stashCache == null)
		{
			return;
		}
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (view.depth > UIManager.POPUP_LAYER_ORDER && _stashCache.TryGetValue(view.popupId, out var value))
				{
					view.visible = value;
				}
			}
		}
		_stashCache.Clear();
		UIManager.RefreshMainCameraStateByVisibleCount();
		UIManager.RefreshSceneUIShowByVisibleCount();
	}
	public IPopupView GetTopView()
	{
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (param.isHiding)
				{
					continue;
				}

				if (view.depth ==9999)
				{
					continue;
				}
				bool isAnimated = CheckMode(param.popupMode, _animatedModeFlag) && view.popupAnimation != null;
				if(!isAnimated && (param.delayOpenHandle != EquineScheduler.INVALID || param.delayCloseHandle != EquineScheduler.INVALID))
				{
					continue;
				}
				if (isAnimated && view.popupAnimation != null && (view.popupAnimation.isPlaying || view.popupAnimation.isPlayingReverse))
				{
					continue;
				}
				return view;
			}
		}
		return null;
	}
	public bool IsTopView(IPopupView v)
	{
		int count = _history.Count;
		if (count > 0)
		{
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (param.isHiding)
				{
					continue;
				}
				bool isAnimated = CheckMode(param.popupMode, _animatedModeFlag) && view.popupAnimation != null;
				if(!isAnimated && (param.delayOpenHandle != EquineScheduler.INVALID || param.delayCloseHandle != EquineScheduler.INVALID))
				{
					continue;
				}
				if (isAnimated && view.popupAnimation != null && (view.popupAnimation.isPlaying || view.popupAnimation.isPlayingReverse))
				{
					continue;
				}
				return view == v;
			}
		}
		return false;
	}

	public bool CloseTopView(IPopupView except = null)
	{
		int count = _history.Count;
		if (count > 0)
		{
			IPopupView topView = null;
			for (int i = count - 1; i >= 0; i--)
			{
				var param = _history[i];
				var view = param.popupView;
				if (param.isHiding || view == except)
				{
					continue;
				}
				bool isAnimated = CheckMode(param.popupMode, _animatedModeFlag) && view.popupAnimation != null;
				if(!isAnimated && (param.delayOpenHandle != EquineScheduler.INVALID || param.delayCloseHandle != EquineScheduler.INVALID))
				{
					continue;
				}
				if (isAnimated && view.popupAnimation != null && (view.popupAnimation.isPlaying || view.popupAnimation.isPlayingReverse))
				{
					continue;
				}
				topView = view;
				break;
			}
			if (topView != null)
			{
				#if UNITY_EDITOR
					Debug.LogError("MainUI Debug " + topView.name);
				#endif
				if (topView.onMaskClick != null)
				{
					topView.onMaskClick();
				}
				else
				{
					RemovePopup(topView);
				}

				return true;
			}
		}
		return false;
	}

	public void RefreshPopupAction(IPopupView view, uint popupMode, object actionParam)
	{
		PopupParam popupParam;
		if (_paramDic.TryGetValue(view.popupId, out popupParam))
		{
			popupParam.SetExternalParam(popupMode, actionParam);
			ExecuteAction(view, 4, popupParam, popupMode);
		}
	}
	
	public void RefreshPopupParam(IPopupView view, uint popupMode, object actionParam)
	{
		if (view != null && _paramDic.TryGetValue(view.popupId, out var popupParam))
		{
			popupParam.SetExternalParam(popupMode, actionParam);
		}
	}

	public void AddPopup(IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null, int popupLayer = -1,
		PopupQueueMode queueMode = PopupQueueMode.QueueBack,bool isFullScreen = false)
	{
		if (popupLayer < 0 || popupLayer >= _popupLayers.Length)
		{
			popupLayer = _defaultLayer;
		}
		AddPopup(_popupLayers[popupLayer], popupLayer, view, popupMode, paramDic, isFullScreen);
	}
	
	public void RefreshPopup(IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null,
		int popupLayer = -1)
	{
		var hasPopup = _paramDic.TryGetValue(view.popupId, out var param);
		if (!hasPopup)
		{
			return;
		}
		
		if (popupLayer < 0 || popupLayer >= _popupLayers.Length)
		{
			popupLayer = _defaultLayer;
		}
		
		param.popupLayer = popupLayer;
		param.popupView = view;
		param.popupMode = popupMode;
		param.externalActionParamMap = paramDic;
		// param.popupData = data;
		
		_currentPopupDepths[param.popupLayer] += PopupConfig.DEPTH_INCREMENT;
		var popDepth = _currentPopupDepths[param.popupLayer];
		param.popDepth = popDepth;

		_history.Remove(param);
		_history.Add(param);
		
		SetPanelDepths(view, param.popDepth);
		
		RefreshPopupAction(view, param.popupMode,  param);
		view.ShowViewAndRefresh();
		
		BuildPanels();
	}

	/// <summary>
	/// 创建并显示一个面板。面板会被缓存，因此该方法可以重复调用。
	/// </summary>
	/// <param name="parent">窗口路径.</param>
	/// <param name="view">窗口路径.</param>
	/// <param name="popupMode">模式标识.</param>
	/// <param name="queueMode">队列标识.</param>POP_CANVAS_LAYER_NAME
	/// <param name="paramDic">参数字典.</param>
	/// <returns>The and add popup.</returns>
	private void AddPopup(Transform parent, int popupLayer, IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null, bool isFullScreen = false)
	{
		PopupParam param = new PopupParam();
		param.popupLayer = popupLayer;
		param.popupView = view;
		param.popupMode = popupMode;
		param.isFullScreen = isFullScreen;
		param.externalActionParamMap = paramDic;
		
		_currentPopupDepths[param.popupLayer] += PopupConfig.DEPTH_INCREMENT;
		var popDepth = _currentPopupDepths[param.popupLayer];
		param.popDepth = popDepth;

		view.parent = parent;
		view.visible = false;
		view.ResetTransform();
		// view.visible = true;
		
		_history.Add(param);
		_paramDic.Add(param.popupView.popupId, param);
		
		ShowPopup(view, param);
		
	}

	public bool IsHiding(IPopupView view)
	{
		if (view != null && view.isValid)
		{
			PopupParam param;
			_paramDic.TryGetValue(view.popupId, out param);
			if (param.isHiding)
			{
				return true;
			}
		}
		return false;
	}

	public void ForceRemoveHidingPanel(IPopupView view, bool withExitNotify = false)
	{
		//        LogPanelInfo("ForceRemoveHidingPanel", view, withExitNotify.ToString());
		if (_paramDic.TryGetValue(view.popupId, out var popupParam) && popupParam.isHiding)
		{
			if (view.popupAnimation != null)
			{
				view.popupAnimation.StopAnimation();
			}
			
			PopupParam param = _paramDic[view.popupId];
			EquineScheduler.RemoveLimitUpdator(ref popupParam.delayCloseHandle);
			HidePopupCallback(param);
		}
	}

	/// <summary>
	/// 绉婚櫎涓€涓凡鐭ラ潰鏉裤€?	/// </summary>
	/// <param name="view">闈㈡澘.</param>
	public void RemovePopup(IPopupView view, bool removeNow = false)
	{
		//        LogPanelInfo("RemovePopup", view, removeNow.ToString());
		if (view == null)
			return;

		CheckExistence(null, view);

		if ((view.popupAnimation == null && view.visible) || (view.popupAnimation != null && !view.popupAnimation.isPlayingReverse))
		{
			HidePopup(view, removeNow);
		}
	}

	public void RemoveAllPopup(uint removeMode = PopupRemoveMode.DEFAULT,bool cleanScene = false)
	{
		DoRemoveAllPopup(false, removeMode,cleanScene);
	}

	private void DoRemoveAllPopup(bool cleanup, uint removeMode,bool cleanScene = false)
	{
		Debug.LogError($"DoRemoveAllPopup!!!");
		try
		{
			var popups = new List<PopupParam>(_history);
			
			_history.Clear();
			_paramDic.Clear();
			
			int count = popups.Count;
			uint mode = 0;
			for (int i = count - 1; i >= 0 ; i--)
			{
				var popupParam = popups[i];
				IPopupView view = popupParam.popupView;
				if ((view.removeAllFlag & removeMode) == 0)
				{
					continue;
				}

				mode |= popupParam.popupMode;
				
				if (!popupParam.isHiding)
				{
					if (popupParam.delayOpenHandle != EquineScheduler.INVALID)
					{
						EquineScheduler.RemoveLimitUpdator(ref popupParam.delayOpenHandle);
					}
					ExecuteAction(view, 2, popupParam, popupParam.popupMode);
					view.BeforeExit();
				}
				if (view.isValid && (view.visible || popupParam.isHiding))
				{
					if (view.popupAnimation != null)
					{
						view.popupAnimation.StopAnimation();
					}
					DoHidePopup(view, popupParam);
				}

				if (view.isValid && !view.visible && view.depth != 0)
				{
					SetPanelDepths(view, 0);
				}
				
				EquineScheduler.RemoveLimitUpdator(ref popupParam.delayCloseHandle);
				view.AfterExit();
				if (cleanup)
				{
					view.Dispose();
				}
			}
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
		Array.Copy(_initPopupDepths, _currentPopupDepths, _currentPopupDepths.Length);
		
		BuildPanels();
		BuildQueueAction();
		
		ClearCommonWidgets(cleanScene);
		ClearAllActions(cleanScene);
	}

	private void CheckExistence(IPopupView notExist, IPopupView exist)
	{
		if (notExist != null && _paramDic.ContainsKey(notExist.popupId))
		{
			throw new ArgumentException("a popup panel can not be added again without removing first.");
		}

		if (exist != null && !_paramDic.ContainsKey(exist.popupId))
		{
			throw new ArgumentException("a target (parent) panel not found. " + exist.GetType().Name);
		}
	}

	private void ShowPopup(IPopupView view, PopupParam param)
	{
		if ((param.popupMode & PopupMode.ADD_BLUR_MASK) == PopupMode.ADD_BLUR_MASK)
		{
			ShowPopupAfterOneFrame(view, param);
			return;
		}
		if ((param.popupMode & PopupMode.NO_SHOW) == PopupMode.NO_SHOW)
		{
            view.visible = false;
        }
		else
		{
			view.visible = true;
			if ((param.popupMode & PopupMode.MOVE_TO_SKY) == PopupMode.MOVE_TO_SKY)
			{
				view.MoveToSky(true);
            }
			else
			{
				view.MoveToSky(false);
            }
		}
		SetPanelDepths(view, param.popDepth);
		ExecuteAction(view, 0, param, param.popupMode);
		
		view.BeforeEnter();
		// first enter
		view.ShowViewAndRefresh();
		
		bool isAnimated = CheckMode(param.popupMode, _animatedModeFlag) && view.popupAnimation != null && view.popupAnimation.animationType != PopupAnimationType.CloseOnly;
		if (isAnimated)
		{
			StartAnimation(view, false, ShowPopupCallback, param);
		}
		else
		{
			if (view.popupAnimation != null)
			{
				view.popupAnimation.StopAnimation();
			}
			
			//延迟到下一帧执行，和播放动画保持一致
			param.delayOpenHandle = EquineScheduler.CallOnceFrame(1, DelayPopupCallback, param);
		}
		
		BuildPanels();
	}
	
	private void ShowPopupAfterOneFrame(IPopupView view, PopupParam param)
	{
		ExecuteAction(view, 0, param, param.popupMode);
		// view.visible = false;
		SetPanelDepths(view, param.popDepth);
		view.maskInteractive = false;
		param.delayShowOneFrameHandle = EquineScheduler.CallOnceFrame(1, (i, o, arg3) =>
		{
			param.delayShowOneFrameHandle = EquineScheduler.INVALID;
			view.maskInteractive = true;
			if ((param.popupMode & PopupMode.NO_SHOW) == PopupMode.NO_SHOW)
			{
				view.visible = false;
			}
			else
			{
				view.visible = true;
                if ((param.popupMode & PopupMode.MOVE_TO_SKY) == PopupMode.MOVE_TO_SKY)
                {
                    view.MoveToSky(true);
                }
                else
                {
					view.MoveToSky(false);
                }
            }
            view.BeforeEnter();
			// first enter
			view.ShowViewAndRefresh();
		
			bool isAnimated = CheckMode(param.popupMode, _animatedModeFlag) && view.popupAnimation != null && view.popupAnimation.animationType != PopupAnimationType.CloseOnly;
			if (isAnimated)
			{
				StartAnimation(view, false, ShowPopupCallback, param);
			}
			else
			{
				if (view.popupAnimation != null)
				{
					view.popupAnimation.StopAnimation();
				}
			
				//延迟到下一帧执行，和播放动画保持一致
				param.delayOpenHandle = EquineScheduler.CallOnceFrame(1, DelayPopupCallback, param);
			}
		
			BuildPanels();
		});
	} 

	public void StartAnimation(IPopupView view, bool reverse, Action<PopupParam> endDelegate, PopupParam popupParam)
	{
		//        LogPanelInfo("StartAnimation", view, reverse.ToString());
		PopupAnimationDTO dto;
		GetAnimationDTO(popupParam.externalActionParamMap, out dto);

		BasePopupAnimation popupAnimation = view.popupAnimation;
		popupAnimation.StartAnimation(endDelegate, dto.duration > 0 ? dto.duration : popupAnimation.defaultDuration, popupParam, reverse);
	}

	private void GetAnimationDTO(Dictionary<uint, object> paramDic, out PopupAnimationDTO dto)
	{
		if (paramDic == null || !paramDic.TryGetValue(_animatedModeFlag, out var value))
			dto = PopupAnimationDTO.defaultDTO;
		else
			dto = (PopupAnimationDTO)value;
	}

	private void DelayPopupCallback(int updator, object args, UpdateTimeInfo info)
	{
//		LogUtility.Log("DelayPopupCallback " + Time.frameCount);
		PopupParam param = args as PopupParam;
		param.delayOpenHandle = EquineScheduler.INVALID;
		ShowPopupCallback(param/*, param*/);
	}

	private void ShowPopupCallback(PopupParam popupParam/*, object param*/)
	{
		IPopupView view = popupParam.popupView;
		ExecuteAction(view, 1, popupParam, popupParam.popupMode);
		view?.AfterEnter();

		BuildQueueAction();
	}

	private void HidePopup(IPopupView view, bool removeNow = false)
	{
		PopupParam popupParam;
		if (!_paramDic.TryGetValue(view.popupId, out popupParam))
		{
			Debug.LogError($"{view.name} not found in history");
			return;
		}
		if (popupParam.delayShowOneFrameHandle != EquineScheduler.INVALID)
		{
			EquineScheduler.RemoveLimitUpdator(ref popupParam.delayShowOneFrameHandle);
		}
		if (popupParam.delayOpenHandle != EquineScheduler.INVALID)
		{
			EquineScheduler.RemoveLimitUpdator(ref popupParam.delayOpenHandle);
		}
		ExecuteAction(view, 2, popupParam, popupParam.popupMode);		
		view.BeforeExit();
		bool isAnimated = CheckMode(popupParam.popupMode, _animatedModeFlag) && view.popupAnimation != null && view.popupAnimation.animationType != PopupAnimationType.OpenOnly && !removeNow;
		popupParam.isHiding = true;
		if (isAnimated)
		{
			StartAnimation(view, true, HidePopupCallback, popupParam);
		}
		else
		{
			if (view.popupAnimation != null)
			{
				view.popupAnimation.StopAnimation();
			}
			EquineScheduler.RemoveLimitUpdator(ref popupParam.delayCloseHandle);

			popupParam.delayCloseHandle = EquineScheduler.CallOnceFrame(1, DelayCloseCallback, popupParam);
		}
	}

	private void DelayCloseCallback(int updator, object args, UpdateTimeInfo info)
	{
		PopupParam param = args as PopupParam;
		param.delayCloseHandle = EquineScheduler.INVALID;
		HidePopupCallback(param);
	}

	private void HidePopupCallback(PopupParam param)
	{
		IPopupView view = param.popupView;
		if (view == null)
		{
			return;
		}
		_history.Remove(param);
		_paramDic.Remove(param.popupView.popupId);
		
		DoHidePopup(view, param);

		param.isHiding = false;
		param.popupView = null;

		view.AfterExit();
				
		ResetPopupDepth();
		BuildPanels();
		BuildQueueAction();
		
		if (_history.Count == 0)
		{
			// ApplicationFacade.instance.SendNotification(ONLY_MAIN_PANEL_SHOW);
			// 没有历史不发通知
		}
	}
	
	private void DoHidePopup(IPopupView view, PopupParam param)
	{
		EquineScheduler.RemoveLimitUpdator(ref param.delayOpenHandle);
		EquineScheduler.RemoveLimitUpdator(ref param.delayCloseHandle);
		
		ExecuteAction(view, 3, param, param.popupMode);

		view.visible = false;

		SetPanelDepths(view, 0);
	}
	
	private void BuildPanels()
	{
		int count = _history.Count;
		var found = false;

		int commonUIWidgetsProcessed = _commonUIWidgetsFlag;
		uint queueActionMode = 0;
		for (int i = count - 1; i >= 0; i--)
		{
			var param = _history[i];
			//暂存的界面不处理了
			if (_stashCache != null && param.popupView!= null && _stashCache.ContainsKey(param.popupView.popupId))
			{
				continue;
			}
			if (!found)
			{
				if ((param.popupMode & PopupMode.HIDE_CAMERA) > 0)
				{
					found = true;
				}
				
				if (param.popupView.visible == false)
				{
					// param.popupView.BeforeEnter();
					if ((param.popupMode & PopupMode.NO_SHOW) == PopupMode.NO_SHOW)
					{
						param.popupView.visible = false;
                    }
					else
					{
						param.popupView.visible = true;
                        if ((param.popupMode & PopupMode.MOVE_TO_SKY) == PopupMode.MOVE_TO_SKY)
                        {
                            param.popupView.MoveToSky(true);
                        }
                        else
                        {
							param.popupView.MoveToSky(false);
                        }
                    }
                    // param.popupView.AfterEnter();
                    param.popupView.ShowViewAndNoRefresh();
				}
			}
			else
			{
				if (param.popupView.visible)
				{
					// param.popupView.BeforeExit();
					param.popupView.visible = false;
					// param.popupView.AfterExit();
				}
			}

			queueActionMode |= param.popupMode & _popupQueueActionFlag;

			if (commonUIWidgetsProcessed != 0)
			{
				for (int j = 0, widgetCount = _commonUIWidgets.Length;
					j < widgetCount && commonUIWidgetsProcessed > 0;
					j++)
				{
					var widget = _commonUIWidgets[j];
					if ((1 << j & commonUIWidgetsProcessed) != 0 &&
					    (widget.mode & param.popupMode) != 0)
					{
						widget.Refresh(param);
						commonUIWidgetsProcessed &= ~(1 << j);
					}
				}
			}
		}

		if (commonUIWidgetsProcessed != 0)
		{
			for (int j = 0, widgetCount = _commonUIWidgets.Length;
				j < widgetCount && commonUIWidgetsProcessed > 0;
				j++)
			{
				var widget = _commonUIWidgets[j];
				if ((1 << j & commonUIWidgetsProcessed) != 0)
				{
					widget.Refresh(null);
					commonUIWidgetsProcessed &= ~(1 << j);
				}
			}
		}
	}

	private void BuildQueueAction()
	{
		int count = _history.Count;

		uint queueActionMode = 0;
		for (int i = count - 1; i >= 0; i--)
		{
			var param = _history[i];
			queueActionMode |= param.popupMode & _popupQueueActionFlag;
		}
		
		for (int i = 0, actionCount = _popupQueueActions?.Length ?? 0; i < actionCount; i++)
		{
			_popupQueueActions[i].Execute((queueActionMode & _popupQueueActions[i].mode) != 0);
		}
	}

	private void ResetPopupDepth()
	{
		Array.Copy(_initPopupDepths, _currentPopupDepths, _currentPopupDepths.Length);
		var itor = _history.GetEnumerator();
		while (itor.MoveNext())
		{
			var param = itor.Current;
			if (param?.popupView == null)
			{
				Debug.LogError("popup view is null");
				continue;
			}
			// 重新复制历史层级
			int popupViewDepth = param.popDepth;
			if (popupViewDepth > _currentPopupDepths[param.popupLayer])
			{
				_currentPopupDepths[param.popupLayer] = popupViewDepth;
			}
		}
	}
	
	private void AddCommonWidgets(PopupParam popupParam)
	{
		for (int i = 0, widgetCount = _commonUIWidgets.Length; i < widgetCount; i++)
		{
			var uiWidget = _commonUIWidgets[i];
			if ((popupParam.popupMode & uiWidget.mode) != 0)
			{
				_commonUIWidgets[i].Refresh(popupParam);
			}
		}
	}

	private void RemoveCommonWidgets(PopupParam popupParam)
	{
		for (int i = 0, widgetCount = _commonUIWidgets.Length; i < widgetCount; i++)
		{
			var uiWidget = _commonUIWidgets[i];
			if ((popupParam.popupMode & uiWidget.mode) != 0)
			{
				_commonUIWidgets[i].Refresh(null);
			}
		}
	}
	
	private void ClearCommonWidgets(bool cleanScene)
	{
		if (_commonUIWidgets == null)
		{
			return;
		}
		for (int i = 0, count = _commonUIWidgets.Length; i < count; i++)
		{
			_commonUIWidgets[i].Refresh(null,cleanScene);
		}
	}

	private void ClearAllActions(bool cleanUp)
	{
		if (_actionList == null)
		{
			return;
		}
		for (int i = 0, count = _actionList.Length; i < count; i++)
		{
			_actionList[i].ClearAction(cleanUp);
		}
	}
	private void ExecuteAction(IPopupView view, int phase, PopupParam popupParam, uint popupMode)
	{
		//        LogPanelInfo("ExecuteAction", view, phase.ToString());
		for (int i = 0, imax = _actionList.Length; i < imax; ++i)
		{
			BasePopupAction action = _actionList[i];

			if (CheckMode(popupMode, action.mode))
			{
				if (phase == 0)
					action.ExecuteBeforeShow(_popupLayers[popupParam.popupLayer], view, popupParam);
				else if (phase == 1)
					action.ExecuteAfterShow(_popupLayers[popupParam.popupLayer], view, popupParam);
				else if (phase == 2)
					action.ExecuteBeforeHide(_popupLayers[popupParam.popupLayer], view, popupParam);
				else if (phase == 3)
					action.ExecuteAfterHide(_popupLayers[popupParam.popupLayer], view, popupParam);
				else if (phase == 4)
					action.Refresh(view, popupParam);
			}
		}
	}

	private void SetPanelDepths(IPopupView view, int depth/*, int z*/)
	{
		// 设置 Depth
		view.depth = depth;
	}

	private bool CheckMode(uint popupMode, uint mode)
	{
		return (popupMode & mode) > 0;
	}

	private void LogPanelInfo(string functionName, IPopupView view, string param1 = "", string param2 = "")
	{
		Debug.LogError(string.Format("{0} called, at panel: {1},  {2}, {3}", functionName, view != null ? view.name : "", param1, param2));
	}
}
