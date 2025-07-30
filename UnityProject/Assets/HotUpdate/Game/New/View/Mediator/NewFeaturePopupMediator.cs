

using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using UnityEngine;

public class NewFeaturePopupMediator : TBaseUIMediator<NewFeaturePopupSkin>
{
    
    public NewFeaturePopupMediator() : base(MediatorNames.NEW_FEATURE_POPUP,NotificationConst.SHOW_NEW_FEATURE_POPUP,NotificationConst.HIDE_NEW_FEATURE_POPUP)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

    }

    protected override void OnShowViewAndRefresh(object data)
    {
        var newFeature = (NewFeature)data;
        _view.imgNewFeature.sprite = GameImgCache.instance.NewFeatureImg[newFeature];
        _view.textName.text = PreviewContentData.instance.FeatureName[newFeature];
        _view.textDesc.text = PreviewContentData.instance.FeatureDesc[newFeature];
        
        UIEventListener.OnClick(_view.btnConfirm).AddListener(OnBtnConfirmClick);
    }


    protected override void BeforeHideView()
    {
        UIEventListener.OnClick(_view.btnConfirm).RemoveListener(OnBtnConfirmClick);

        
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

    private void OnBtnConfirmClick(GameObject go)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_NEW_FEATURE_POPUP);
    }
}
