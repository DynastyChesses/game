

using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HotUpdate.osP1;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.Save;
using UnityEngine;

public enum ConsumeType
{
    Gold,
    AdTicket,
    Ad
}



public class BuyItemPopupMediator : TBaseUIMediator<BuyItemPopupSkin>
{
    //ui
    private TweenerCore<Quaternion, Vector3, QuaternionOptions> _tweenerCore;
    
    //logic
    private ConsumeType _consumeType;
    private int _price;
    private GameItemType _gameItemType;

    
    public BuyItemPopupMediator() : base(MediatorNames.BUY_ITEM_POPUP,NotificationConst.SHOW_BUY_ITEM_POPUP,NotificationConst.HIDE_BUY_ITEM_POPUP)
    {
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderGold,OnRenderGold,true);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderAdTicket,OnRenderAdTicket,true);
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        UIEventListener.OnClick(_view.btnBuy).AddListener(OnBtnBuyClick);
    }

    protected override void OnShowViewAndRefresh(object data)
    {
        var gameItem = GamePlay.instance.GameItem;
        _gameItemType = (GameItemType)data;
        
        //item name
        _view.txtTitle.text = gameItem.Name[_gameItemType];
        
        //item desc
        _view.txtDesc.text = gameItem.Desc[_gameItemType];
        
        //remain
        _view.txtRemain.text = $"Remain {gameItem.RemainUseNum[_gameItemType]}/{gameItem.UseLimit[_gameItemType]}";
        
        //item img
        _view.imgItem.sprite = GameImgCache.instance.GameItemImg[_gameItemType];
        _view.imgItem.SetNativeSize();
        
        //effect
        if (_tweenerCore != null)
        {
            _tweenerCore.Kill();
            _tweenerCore = null;
        }
        _view.trEffectLight.eulerAngles = new Vector3(0, 0, 0);
        _tweenerCore = _view.trEffectLight.DORotate(new Vector3(0f,0f,180f),5f,RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
        
        //刷新显示广告卷和金币
        _view.txtGoldNum.text = PlayerSave.instance.PlayerAssets.Gold.ToString();
        _view.txtAdTicketNum.text = PlayerSave.instance.PlayerAssets.AdTicket.ToString();
        
        //购买按钮
        _price = gameItem.Price[_gameItemType];
        if (PlayerSave.instance.PlayerAssets.Gold >= _price)
        {
            _consumeType = ConsumeType.Gold;
            _view.txtBtnBuy.text = _price.ToString();
            
        }else if (PlayerSave.instance.PlayerAssets.AdTicket != 0)
        {
            _consumeType = ConsumeType.AdTicket;
            _view.txtBtnBuy.text = "1";

        }
        else
        {
            _consumeType = ConsumeType.Ad;
            _view.txtBtnBuy.text = "USE";
        }
        _view.imgBtnBuy.sprite = GameImgCache.instance.ConsumeImg[_consumeType];
        _view.imgBtnBuy.SetNativeSize();
    }
    
    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        UIEventListener.OnClick(_view.btnBuy).RemoveListener(OnBtnBuyClick);

        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private void OnRenderGold(object data)
    {
        var goldNum = (int)data;
        _view.txtGoldNum.text = goldNum.ToString();
    }

    private void OnRenderAdTicket(object data)
    {
        var adTicketNum = (int)data;
        _view.txtAdTicketNum.text = adTicketNum.ToString();
    }

    private void OnBtnBuyClick(GameObject go)
    {
        switch (_consumeType)
        {
            case ConsumeType.Gold:
                ConsumeGold();
                break;
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
        PlayerSave.instance.PlayerAssets.RemoveGold(_price);
        AddItem(1);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_BUY_ITEM_POPUP);
        GamePlay.instance.GameItem.Use(_gameItemType);
    }

    private void ConsumeAdTicket()
    {
        PlayerSave.instance.PlayerAssets.RemoveAdTicket(1);
        AddItem(1);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_BUY_ITEM_POPUP);
        GamePlay.instance.GameItem.Use(_gameItemType);

    }

    private void ConsumeAd()
    {
        //播放广告
        AfterPlayAd();
    }

    private void AfterPlayAd()
    {
        AddItem(1);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_BUY_ITEM_POPUP);
        GamePlay.instance.GameItem.Use(_gameItemType);
    }

    private void AddItem(int amount)
    {
        //存档获得
        PlayerSave.instance.PlayerAssets.AddItemNum(_gameItemType,amount);
        var gameItem = GamePlay.instance.GameItem;
        gameItem.CurrentNum[_gameItemType] += amount;
        ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,_gameItemType);
    }
}
