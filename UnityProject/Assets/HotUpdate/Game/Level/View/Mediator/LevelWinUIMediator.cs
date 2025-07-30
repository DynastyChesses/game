

using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.Save;
using PureMVC.Patterns;
using UnityEngine;




public class LevelWinUIMediator : TBaseUIMediator<LevelWinUISkin>
{

    private int _baseGold;
    private float _multiply;
    
    private Sequence _sequence;
    
    public LevelWinUIMediator() : base(MediatorNames.LEVEL_WIN_U_I,NotificationConst.SHOW_LEVEL_WIN_U_I,NotificationConst.HIDE_LEVEL_WIN_U_I)
    {
        

    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

        _baseGold = PlayerSave.instance.PlayerAssets.LevelFinishedGold;

        
        UIEventListener.OnClick(_view.btnRandomGold).AddListener(OnBtnRandomGoldClick);
        UIEventListener.OnClick(_view.btnBaseGold).AddListener(OnBtnBaseGoldClick);

    }

    protected override void OnShowViewAndRefresh(object data)
    {
        var levelId = (int)data;
        
        OnRenderLevel(levelId);
        OnRenderProgress(levelId);
        
        //effect1
        _view.skelEffect1.AnimationState.SetAnimation(0, "guang_add", false).Complete += entry =>
        {
            _view.skelEffect1.AnimationState.SetAnimation(0, "guang_ing", true);
        };
        
        //effect2
        _view.skelEffect2.AnimationState.SetAnimation(0, "caidai_add", false);
        
        //skelText
        _view.skelText.AnimationState.SetAnimation(0, "text_add", false).Complete += entry =>
        {
            _view.skelText.AnimationState.SetAnimation(0, "text_normal", true);
        };
        
        //base gold btn
        _view.txtBaseGoldNum.text = _baseGold.ToString();
        
        var startAngle = new Vector3(0, 0, 0);
        var leftAngle = new Vector3(0, 0, 73);
        var rightEndAngle = new Vector3(0, 0, -73);
        
        _view.rectPtr.transform.localEulerAngles = startAngle;
        var seq = DOTween.Sequence();
        _sequence = seq;
        seq.Append(_view.rectPtr.DOLocalRotate(rightEndAngle, 0.5f).SetEase(Ease.OutCubic));
        seq.Append(_view.rectPtr.DOLocalRotate(startAngle, 0.5f).SetEase(Ease.InCubic));
        seq.Append(_view.rectPtr.DOLocalRotate(leftAngle, 0.5f).SetEase(Ease.OutCubic));
        seq.Append(_view.rectPtr.DOLocalRotate(startAngle, 0.5f).SetEase(Ease.InCubic));
        seq.SetLoops(-1, LoopType.Restart);

        seq.onUpdate += () =>
        {
            var angle = _view.rectPtr.transform.localEulerAngles.z;
            angle = Mathf.Abs(angle);
            
            
            if (angle < 13.3f)
            {
                _multiply = 3f;
            }
            else if (angle < 38.6f)
            {
                _multiply = 2.5f;
            }
            else if (angle < 62f)
            {
                _multiply = 2f;
            }
            else
            {
                _multiply = 1.5f;
            }


            _view.txtRandomGoldNum.text = ((int)(_baseGold * _multiply)).ToString();
        };
        
        //logic
        if (LevelSelectionUIMediator.IsDebugModeWhenEnterLevel)
        {
            LevelSelectionUIMediator.IsDebugModeWhenEnterLevel = false;
            return;
        }
        
        PlayerSave.instance.PlayerAssets.SetCacheRemoveStamina(false);
        
        //当前关卡超过了就不再增加
        if(PlayerSave.instance.PlayerProgress.CurrentLevelId != PlayerProgress.MaxLevel + 1)
            PlayerSave.instance.PlayerProgress.CurrentLevelId++;
    }

    private void OnBtnRandomGoldClick(GameObject go)
    {
        _sequence.Pause();
        
        //TODO: play ad
        AfterPlayAd();
    }

    private void AfterPlayAd()
    {
        PlayerSave.instance.PlayerAssets.AddGold((int)(_baseGold * _multiply));
        
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_GAME_PLAY);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_LEVEL_WIN_U_I);
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_SELECTION_U_I);//用以触发level selection刷新
    }
    
    private void OnBtnBaseGoldClick(GameObject go)
    {
        PlayerSave.instance.PlayerAssets.AddGold(_baseGold);
        
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_GAME_PLAY);
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_LEVEL_WIN_U_I);
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_SELECTION_U_I);//用以触发level selection刷新
    }


    protected override void BeforeHideView()
    {
        _sequence.Kill();
        _sequence = null;
        
        base.BeforeHideView();
        
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
        UIEventListener.OnClick(_view.btnBaseGold).RemoveListener(OnBtnBaseGoldClick);
        UIEventListener.OnClick(_view.btnRandomGold).RemoveListener(OnBtnRandomGoldClick);

    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private void OnRenderLevel(object data)
    {
        var levelId = (int)data;
        _view.textLevel.text = $"Level {levelId}";
    }
    
    private void OnRenderProgress(object data)
    {
        _view.goNewFeature.SetActive(true);
        
        var levelId = (int)data;
        var isDisplay = false;
        foreach (var (key,(lowwer,upper)) in PreviewContentData.instance.FeatureRange)
        {
            var displayUpper = upper - 1;
            if (lowwer <= levelId && levelId <= displayUpper)
            {
                var oldFillAmount = (levelId-1) / (float)upper;
                var newFillAmount = levelId / (float)upper;
                _view.imgProgress.fillAmount = oldFillAmount;
                DOTween.To((() => _view.imgProgress.fillAmount), val => _view.imgProgress.fillAmount = val,
                    newFillAmount, 1f);
                
                _view.textProgress.text = $"{levelId}/{upper}";
                _view.imgNewFeature.sprite = GameImgCache.instance.NewFeatureImg[key];
                _view.imgNewFeature.SetNativeSize();
                
                isDisplay = true;
                break;
            }
        }

        if (!isDisplay)
        {
            _view.goNewFeature.SetActive(false);
        }
        
        
        
        //read excel
        //get range
        //check range
        //
    }
}
