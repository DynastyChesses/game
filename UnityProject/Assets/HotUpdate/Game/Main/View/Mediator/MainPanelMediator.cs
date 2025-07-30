

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainPanelMediator : TBaseUIMediator<MainPanelSkin>
{
    
    public MainPanelMediator() : base(MediatorNames.MAIN_PANEL,NotificationConst.SHOW_MAIN_PANEL,NotificationConst.HIDE_MAIN_PANEL)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

    }

    protected override void OnShowViewAndRefresh(object data)
    {
        // 测试
        _view.clickTest.onClick.AddListener(OnTest);
    }

    private void OnTest()
    {
        Debug.LogError($"Test!!!!!");
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
