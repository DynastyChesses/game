

using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using HotUpdate.osP1.Save;
using UnityEngine;

public class LevelLoseUIMediator : TBaseUIMediator<LevelLoseUISkin>
{
    
    public LevelLoseUIMediator() : base(MediatorNames.LEVEL_LOSE_U_I,NotificationConst.SHOW_LEVEL_LOSE_U_I,NotificationConst.HIDE_LEVEL_LOSE_U_I)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        
        UIEventListener.OnClick(_view.btnRestart).AddListener(OnBtnRestartClick);
        UIEventListener.OnClick(_view.btnBack).AddListener(OnBtnBackClick);
    }

    protected override void OnShowViewAndRefresh(object data)
    {
        if (PlayerSave.instance.PlayerAssets.IsGuarantyStamina)
        {
            PlayerSave.instance.PlayerAssets.SetCacheRemoveStamina(false);
            PlayerSave.instance.PlayerAssets.RemoveStamina(1);
        }
    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        UIEventListener.OnClick(_view.btnRestart).RemoveListener(OnBtnRestartClick);
        UIEventListener.OnClick(_view.btnBack).RemoveListener(OnBtnBackClick);
        
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    public void ExternBtnRestartClick()
    {
        OnBtnRestartClick(null);
    }

    private int _closeHandler = EquineScheduler.INVALID;

    private void OnBtnRestartClick(GameObject go)
    {
        
        if (PlayerSave.instance.PlayerAssets.Stamina == 0)
        {
            ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_BUY_STAMINA_POPUP,this);
            //体力购买
            return;
        }
        
        PlayerSave.instance.PlayerAssets.SetCacheRemoveStamina(true);
        
        var levelId = GamePlay.instance.LevelId;
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_GAME_PLAY);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_REVIVE_U_I);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_LEVEL_LOSE_U_I);
        _closeHandler = EquineScheduler.CallOnceFrame(2, ((i, o, arg3) => DelayCall(levelId)));
    }

    private void DelayCall(int levelId)
    {
        //Hide通知默认延时一帧完成
        _closeHandler = EquineScheduler.INVALID;
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_GAME_PLAY,levelId);
    }

    private void OnBtnBackClick(GameObject go)
    {
        //反向逐步隐藏
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_GAME_PLAY);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_REVIVE_U_I);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_LEVEL_LOSE_U_I);
        //ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_SELECTION_U_I);
    }
}
