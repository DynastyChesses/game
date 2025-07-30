

using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using HotUpdate.osP1.Save;
using UnityEngine;

public class LeaveUIMediator : TBaseUIMediator<LeaveUISkin>
{
    
    public LeaveUIMediator() : base(MediatorNames.LEAVE_U_I,NotificationConst.SHOW_LEAVE_U_I,NotificationConst.HIDE_LEAVE_U_I)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        
        UIEventListener.OnClick(_view.btnClose).AddListener(OnBtnCloseClick);
        UIEventListener.OnClick(_view.btnLeave).AddListener(OnBtnLeaveClick);
    }

    protected override void OnShowViewAndRefresh(object data)
    {

    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
        
        UIEventListener.OnClick(_view.btnClose).RemoveListener(OnBtnCloseClick);
        UIEventListener.OnClick(_view.btnLeave).RemoveListener(OnBtnLeaveClick);

    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }
    
    private void OnBtnCloseClick(GameObject go)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_LEAVE_U_I);
    }

    private void OnBtnLeaveClick(GameObject go)
    {
        if (PlayerSave.instance.PlayerAssets.IsGuarantyStamina)
        {
            PlayerSave.instance.PlayerAssets.SetCacheRemoveStamina(false);
            PlayerSave.instance.PlayerAssets.RemoveStamina(1);
        }
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_LEAVE_U_I);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_SETTINGS_U_I);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_GAME_PLAY);

    }
}
