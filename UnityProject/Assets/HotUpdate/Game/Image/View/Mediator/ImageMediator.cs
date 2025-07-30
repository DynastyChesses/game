

using System;
using System.Collections.Generic;
using UnityEngine;

public class ImageMediator : TBaseUIMediator<ImageSkin>
{
    public ImageMediator() : base(MediatorNames.IMAGE,NotificationConst.SHOW_IMAGE,NotificationConst.HIDE_IMAGE)
    {
        
    }

    

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        Debug.LogError("OnCreateView!!!");
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
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }
}
