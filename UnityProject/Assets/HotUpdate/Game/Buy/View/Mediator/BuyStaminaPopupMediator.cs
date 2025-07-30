

using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using HotUpdate.osP1.Save;
using UnityEngine;

public class BuyStaminaPopupMediator : TBaseUIMediator<BuyStaminaPopupSkin>
{
    private int _refillPrice;
    private int _refillNum;
    private ConsumeType _consumeType;
    private BaseUIMediator _mediator;
    
    public BuyStaminaPopupMediator() : base(MediatorNames.BUY_STAMINA_POPUP,NotificationConst.SHOW_BUY_STAMINA_POPUP,NotificationConst.HIDE_BUY_STAMINA_POPUP)
    {
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderStaminaTime,OnRenderStaminaTime,true);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderAdTicket,OnRenderAdTicket,true);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderGold,OnRenderGold,true);
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        UIEventListener.OnClick(_view.btnRefill).AddListener(OnBtnRefillClick);
        UIEventListener.OnClick(_view.btnOneMoreLife).AddListener(OnBtnOneMoreLifeClick);
        _refillPrice = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["stamina_gold"].Value);
        _refillNum = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["stamina_gold_stamina"].Value);
    }

    protected override void OnShowViewAndRefresh(object data)
    {
        _mediator = data as BaseUIMediator;
        
        _view.txtAdTicketNum.text = PlayerSave.instance.PlayerAssets.AdTicket.ToString();
        _view.txtGoldNum.text = PlayerSave.instance.PlayerAssets.Gold.ToString();

        _view.txtConsumeGoldNum.text = _refillPrice.ToString();

        if (PlayerSave.instance.PlayerAssets.AdTicket > 0)
        {
            _view.imgBtnOneMoreLife.sprite = GameImgCache.instance.ConsumeImg[ConsumeType.AdTicket];
            _view.imgBtnOneMoreLife.SetNativeSize();
            _view.txtBtnOneMoreLife.text = "1";
            _consumeType = ConsumeType.AdTicket;
        }
        else
        {
            _view.imgBtnOneMoreLife.sprite = GameImgCache.instance.ConsumeImg[ConsumeType.Ad];
            _view.imgBtnOneMoreLife.SetNativeSize();
            _view.txtBtnOneMoreLife.text = "USE";
            _consumeType = ConsumeType.Ad;

        }

    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        UIEventListener.OnClick(_view.btnRefill).RemoveListener(OnBtnRefillClick);
        UIEventListener.OnClick(_view.btnOneMoreLife).RemoveListener(OnBtnOneMoreLifeClick);
        
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private void OnBtnRefillClick(GameObject go)
    {
        if(PlayerSave.instance.PlayerAssets.Gold < _refillPrice)
            return;
        
        ConsumeGold();
    }

    private void OnBtnOneMoreLifeClick(GameObject go)
    {
        switch (_consumeType)
        {
            case ConsumeType.AdTicket:
                ConsumeAdTicket();
                break;
            case ConsumeType.Ad:
                ConsumeAd();
                break;
        }
    }

    private void ConsumeGold()
    {
        //logic
        PlayerSave.instance.PlayerAssets.RemoveGold(_refillPrice);
        PlayerSave.instance.PlayerAssets.AddStamina(_refillNum);
        
        AfterConsume();
    }

    private void ConsumeAdTicket()
    {
        //logic
        PlayerSave.instance.PlayerAssets.RemoveAdTicket(1);
        PlayerSave.instance.PlayerAssets.AddStamina(1);
        
        AfterConsume();
    }

    private void ConsumeAd()
    {
        //logic
        PlayerSave.instance.PlayerAssets.AddStamina(1);
        
        //ad
        AfterPlayAd();
    }

    private void AfterPlayAd()
    {
        AfterConsume();
    }

    private void AfterConsume()
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_BUY_STAMINA_POPUP);
        if (_mediator is LevelSelectionUIMediator levelSelectionUIMediator)
        {
            levelSelectionUIMediator.ExternClickBtnPlay();
        }
        else if(_mediator is LevelLoseUIMediator levelLoseUIMediator)
        {
            levelLoseUIMediator.ExternBtnRestartClick();
        }
    }

    private void OnRenderStaminaTime(object data)
    {
        var second = (int)data;
        var dateTime = new DateTime();
        dateTime = dateTime.AddSeconds(second);
        if (PlayerSave.instance.PlayerAssets.Stamina != PlayerSave.instance.PlayerAssets.StaminaUpperLimit)
        {
            _view.txtTime.text = dateTime.ToString("mm:ss");
        }
    }

    private void OnRenderAdTicket(object data)
    {
        _view.txtAdTicketNum.text = ((int)data).ToString();
    }

    private void OnRenderGold(object data)
    {
        _view.txtGoldNum.text = ((int)data).ToString();
    }
}
