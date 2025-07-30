using UnityEngine;
using System;
using System.Collections;


public class AutoHidePopupAction : BasePopupAction
{
	public AutoHidePopupAction (uint popupMode) : base (popupMode)
	{
		
	}

	public override void ExecuteAfterShow (Transform popupRoot, IPopupView view, PopupParam popupParam)
	{
		object param = popupParam.GetExternalParam(mode);
		float removeDelay = param == null ? -1f : (float)param;
		if (removeDelay > 0)
        {
            vp_Timer.Handle autoRemoveHandle = new vp_Timer.Handle();
            vp_Timer.In(removeDelay, RemovePopup, view, autoRemoveHandle);
			popupParam.SetInternalParamMap(mode, autoRemoveHandle);
        }
	}
	
	public override void ExecuteAfterHide (Transform popupRoot, IPopupView view, PopupParam popupParam)
	{
		vp_Timer.Handle autoRemoveHandle = (vp_Timer.Handle)popupParam.GetInternalParam(mode);
        if(autoRemoveHandle != null)
        {
            autoRemoveHandle.Cancel();
			popupParam.SetInternalParamMap(mode, null);
        }
	}

	private void RemovePopup(object args)
	{
        IPopupView view = args as IPopupView;
		popupManagerDelegate.RemovePopup(view);
	}
}
