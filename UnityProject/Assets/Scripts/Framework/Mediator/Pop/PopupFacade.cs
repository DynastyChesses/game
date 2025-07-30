using System;
using UnityEngine;
using System.Collections.Generic;

public class PopupFacade : IPopupFacade
{
	private readonly BasePopupAction[] _actionList;

	private static PopupFacade _instance;

	private IPopupFacade _impl;

    public static PopupFacade instance
    {
        get
        {
            return _instance;
        }
    }

	public static void SetPopupImplement(IPopupFacade popupImpl)
	{
		_instance = new PopupFacade(popupImpl);
	}

	private PopupFacade (IPopupFacade popupImpl)
	{
		_impl = popupImpl;
	}

	public void Clear()
	{
		_impl.Clear();
	}

    public bool HasPopup(IPopupView view, bool includeHiding = true)
    {
		return _impl.HasPopup(view, includeHiding);
    }

	public bool HasAnyPopup()
	{
		return _impl.HasAnyPopup();
	}

	public int GetPopupCount()
	{
		return _impl.GetPopupCount();
	}
	
	public bool IsTopView(IPopupView v)
	{
		return _impl.IsTopView(v);
	}
	
	public IPopupView GetTopView()
	{
		return _impl.GetTopView();
	}
	public void SetViewShow(IPopupView view, bool show)
	{
		_impl.SetViewShow(view,show);
	}
	public void Stash()
	{
		_impl.Stash();
	}
	public void StashPop()
	{
		_impl.StashPop();
	}
	public void ManageMainUI(IPopupView view)
	{
		_impl.ManageMainUI(view);
	}
	public void ResetManageMainUI()
	{
		_impl.ResetManageMainUI();
	}
	public void HideViewBelow(IPopupView targetView)
	{
		_impl.HideViewBelow(targetView);
	}

	public void ShowAllView()
	{
		_impl.ShowAllView();
	}

	public bool IsMainUIManaged()
	{
		return _impl.IsMainUIManaged();
	}

	public bool CloseTopView(IPopupView except = null)
	{
		return _impl.CloseTopView(except);
	}

	public void RefreshPopupAction(IPopupView view, uint popupMode, object param)
	{
		_impl.RefreshPopupAction(view, popupMode, param);
	}
	
	public void RefreshPopupParam(IPopupView view, uint popupMode, object param)
	{
		_impl.RefreshPopupParam(view, popupMode, param);
	}

	public void AddPopup(IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null, int popupLayer = -1,
		PopupQueueMode queueMode = PopupQueueMode.QueueBack,bool isFullScreen = false)
	{
		_impl.AddPopup(view, popupMode, paramDic, popupLayer, queueMode, isFullScreen);
	}

	public void RefreshPopup(IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null, int popupLayer = -1)
	{
		_impl.RefreshPopup(view, popupMode, paramDic, popupLayer);
	}

	public bool IsHiding(IPopupView view)
	{
		return _impl.IsHiding(view);
	}

	public void ForceRemoveHidingPanel(IPopupView view, bool withExitNotify = false)
	{
		_impl.ForceRemoveHidingPanel(view, withExitNotify);
	}

    public void RemovePopup(IPopupView view, bool removeNow = false)
    {
		_impl.RemovePopup(view, removeNow);
    }

	public void RemoveAllPopup(uint removeMode = PopupRemoveMode.DEFAULT,bool clearScene = false)
	{
		_impl.RemoveAllPopup(removeMode,clearScene);
	}
}
