

using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HotUpdate.osP1;
using UnityEngine;

public class NewItemPopupMediator : TBaseUIMediator<NewItemPopupSkin>
{
    private TweenerCore<Quaternion, Vector3, QuaternionOptions> _tweenerCore;
    
    public NewItemPopupMediator() : base(MediatorNames.NEW_ITEM_POPUP,NotificationConst.SHOW_NEW_ITEM_POPUP,NotificationConst.HIDE_NEW_ITEM_POPUP)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

    }

    protected override void OnShowViewAndRefresh(object data)
    {

        var newItem = (GameItemType)data;
        _view.imgNewItem.sprite = GameImgCache.instance.GameItemImg[newItem];
        _view.textName.text = PreviewContentData.instance.ItemName[newItem];
        _view.textDesc.text = PreviewContentData.instance.ItemDesc[newItem];
        
        
        _tweenerCore = _view.effectLight.transform.DORotate(new Vector3(0f,0f,180f),5f,RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
        
        

        
        
        UIEventListener.OnClick(_view.btnConfirm).AddListener(OnBtnConfirmClick);
    }


    protected override void BeforeHideView()
    {
        
        _tweenerCore.Kill();
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
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_NEW_ITEM_POPUP);
    }
}
