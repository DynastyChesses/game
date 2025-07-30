

using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.Save;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using UnityEngine;

public class ReviveUIMediator : TBaseUIMediator<ReviveUISkin>
{
    private GameOverType _gameOverType;
    private ConsumeType _consumeType;

    private int _normalRevivePrice;
    private int _bombRevivePrice;
    private int _timeoutRevivePrice;
    
    public ReviveUIMediator() : base(MediatorNames.REVIVE_U_I,NotificationConst.SHOW_REVIVE_U_I,NotificationConst.HIDE_REVIVE_U_I)
    {

        RegisterNotificationHandler(LevelSelectionUIEvent.RenderStamina,OnRenderStamina,true);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderStaminaTime,OnRenderStaminaTime,true);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderAdTicket,OnRenderAdTicket,true);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderGold,OnRenderGold,true);

    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

        _normalRevivePrice = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["revive_normal_gold"].Value);
        _bombRevivePrice = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["revive_bomb_gold"].Value);
        _timeoutRevivePrice = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["revive_time_gold"].Value);

        UIEventListener.OnClick(_view.btnKeepPlaying).AddListener(OnBtnKeepPlayingClick);
        UIEventListener.OnClick(_view.btnGiveUp).AddListener(OnBtnGiveUpClick);
    }

    protected override void OnShowViewAndRefresh(object data)
    {
        var (gameOverType,progress) = ((GameOverType, float))data;
        _gameOverType = gameOverType;

        _view.textProgress.text = (int)(progress*100)+"%";

        var levelProgress = GamePlay.instance.LevelData.ProgressRate;
        string testLost;
        if (progress < levelProgress)
            testLost = $"Most human friends only complete {levelProgress:P0}";
        else
            testLost = "You are about to pass, hold on a little longer!";

        _view.textLose.text = testLost;
        
        
        //capybara pos
        var temp = _view.rectCapybara.anchoredPosition;
        var startCapybaraX = -222;
        temp.x = startCapybaraX;
        _view.rectCapybara.anchoredPosition = temp;
        var capybaraX = -222 + (288 + 222) * progress;
        
        _view.rectCapybara.anchoredPosition = temp;
        _view.rectCapybara.DOLocalMoveX(capybaraX, 1f);
        
        //most player pos
        var mostX = -270 + (250 + 270) * levelProgress;
        temp = _view.rectMostPlayer.anchoredPosition;
        temp.x = mostX;
        _view.rectMostPlayer.anchoredPosition = temp;
        
        //remain revive text
        _view.textRemainRevive.text = $"{ReviveNormal.RemainReviveTime}/{ReviveNormal.OriginReviveTime}";
        
        _view.txtStaminaNum.text = PlayerSave.instance.PlayerAssets.Stamina.ToString();
        if (PlayerSave.instance.PlayerAssets.Stamina == PlayerSave.instance.PlayerAssets.StaminaUpperLimit)
        {
            _view.txtStaminaTime.text = "MAX";
        }
        _view.txtAdTicketNum.text = PlayerSave.instance.PlayerAssets.AdTicket.ToString();
        _view.txtGoldNum.text = PlayerSave.instance.PlayerAssets.Gold.ToString();
        
        //复活花费
        if (PlayerSave.instance.PlayerAssets.Gold >= GetRevivePrice())
        {
            _consumeType = ConsumeType.Gold;
            _view.txtBtnRevive.text = GetRevivePrice().ToString();
        }else if (PlayerSave.instance.PlayerAssets.AdTicket > 0)
        {
            _consumeType = ConsumeType.AdTicket;
            _view.txtBtnRevive.text = "1";
        }
        else
        {
            _consumeType = ConsumeType.Ad;
            _view.txtBtnRevive.text = "USE";
        }
        _view.imgBtnRevive.sprite = GameImgCache.instance.ConsumeImg[_consumeType];
        _view.imgBtnRevive.SetNativeSize();
        
        
    }

   


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
        
        
    }

    protected override void BeforeViewDispose()
    {
        UIEventListener.OnClick(_view.btnKeepPlaying).RemoveListener(OnBtnKeepPlayingClick);
        UIEventListener.OnClick(_view.btnGiveUp).RemoveListener(OnBtnGiveUpClick);
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private int GetRevivePrice()
    {

        return _gameOverType switch
        {
            GameOverType.SlotFilled => _normalRevivePrice,
            GameOverType.Bomb => _bombRevivePrice,
            GameOverType.Timeout => _timeoutRevivePrice,
        };
    }

    private void OnBtnKeepPlayingClick(GameObject go)
    {
        if(ReviveNormal.RemainReviveTime == 0)
            return;

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
        PlayerSave.instance.PlayerAssets.RemoveGold(GetRevivePrice());
        DoRevive();
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_REVIVE_U_I);
    }

    private void ConsumeAdTicket()
    {
        PlayerSave.instance.PlayerAssets.RemoveAdTicket(1);
        DoRevive();
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_REVIVE_U_I);
    }

    private void ConsumeAd()
    {
        //播放广告
        DoRevive();
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_REVIVE_U_I);
    }

    private void DoRevive()
    {
        GamePlay.instance.Revive(_gameOverType);
        ReviveNormal.RemainReviveTime--;
    }

    private void OnBtnGiveUpClick(GameObject go)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_LOSE_U_I);
    }

    private void OnRenderStamina(object data)
    {
        _view.txtStaminaNum.text = ((int)data).ToString();
        if (PlayerSave.instance.PlayerAssets.Stamina == PlayerSave.instance.PlayerAssets.StaminaUpperLimit)
        {
            _view.txtStaminaTime.text = "MAX";
        }
    }
    
    private void OnRenderStaminaTime(object data)
    {
        var second = (int)data;
        var dateTime = new DateTime();
        dateTime = dateTime.AddSeconds(second);
        if (PlayerSave.instance.PlayerAssets.Stamina != PlayerSave.instance.PlayerAssets.StaminaUpperLimit)
        {
            _view.txtStaminaTime.text = dateTime.ToString("mm:ss");

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
