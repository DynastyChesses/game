

using System;
using System.Collections.Generic;
using UnityEngine;

public class CommonRewardPanelV2Mediator : TBaseUIMediator<CommonRewardPanelV2Skin>
{
    
    public CommonRewardPanelV2Mediator() : base(MediatorNames.COMMON_REWARD_PANEL_V2,NotificationConst.SHOW_COMMON_REWARD_PANEL_V2,NotificationConst.HIDE_COMMON_REWARD_PANEL_V2)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

    }

    protected override void OnShowViewAndRefresh(object data)
    {
        _view.closeButton2.onClick.AddListener(OnBack);
    }

    private void OnBack()
    {
        HideView();
    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }
}
