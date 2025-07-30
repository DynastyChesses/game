using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HotUpdate.osP1;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.Save;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GamePlayMediator : TBaseUIMediator<GamePlaySkin>
{
    private Dictionary<BattleColor, int> _colorIndexRelation = new Dictionary<BattleColor, int>();
    private int _levelId;
    
    private int _updatorId;

    private bool _isShowTip;
    private float _showTipCurrentTime;
    private float _showTipEndTime = 1f;


    public GamePlayMediator() : base(MediatorNames.GAME_PLAY, NotificationConst.SHOW_GAME_PLAY,
        NotificationConst.HIDE_GAME_PLAY)
    {
        //game state
        RegisterNotificationHandler(GamePlayUIEvent.GameOver, OnGameOver);
        RegisterNotificationHandler(GamePlayUIEvent.GameWin, OnGameWin);
        RegisterNotificationHandler(GamePlayUIEvent.TotalKillNumberUpdate, OnTotalKillNumberUpdate);
        RegisterNotificationHandler(GamePlayUIEvent.SpecialKillNumberUpdate, OnSpecialKillNumberUpdate);
        RegisterNotificationHandler(GamePlayUIEvent.RenderSlotLock, OnRenderSlotLock);

        RegisterNotificationHandler(GamePlayUIEvent.RenderCombo, OnRenderCombo);
        RegisterNotificationHandler(GamePlayUIEvent.RenderNewfeaturePopup, RenderNewFeaturePopup);
        RegisterNotificationHandler(GamePlayUIEvent.RenderNewItemPopup, RenderNewItemPopup);

        RegisterNotificationHandler(GamePlayUIEvent.GuideNextPhase, OnGuideNextPhase);

        //fever
        RegisterNotificationHandler(GamePlayUIEvent.FeverEnergyInc, OnFeverEnergyInc);
        RegisterNotificationHandler(GamePlayUIEvent.FeverEnergyDec, OnFeverEnergyDec);
        RegisterNotificationHandler(GamePlayUIEvent.StartFever, OnStartFever);
        RegisterNotificationHandler(GamePlayUIEvent.EndFever, OnEndFever);
        RegisterNotificationHandler(GamePlayUIEvent.ResetFever, OnResetFever);

        //tip
        RegisterNotificationHandler(GamePlayUIEvent.ShowTip, OnShowTip);

        RegisterNotificationHandler(GamePlayUIEvent.RenderItem, OnRenderItem);
        RegisterNotificationHandler(GamePlayUIEvent.RenderItemLock, OnRenderItemLock);

        RegisterNotificationHandler(GamePlayUIEvent.GameStartFinished, OnGameStartFinished);
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.Magnet)).AddListener(UseMagnet);
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.ForceChoose))
            .AddListener(UseForceChoose);
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.Hammer)).AddListener(UseHammer);
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.Refresh)).AddListener(UseRefresh);
        UIEventListener.OnClick(_view.fever.gameObject).AddListener(OnClickFever);
        UIEventListener.OnClick(_view.btnSettings).AddListener(OnBtnSettingsClick);

        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.Magnet)).AddListener(OnAddMagnet);
        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.ForceChoose))
            .AddListener(OnAddForceChoose);
        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.Hammer)).AddListener(OnAddHammer);
        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.Refresh)).AddListener(OnAddRefresh);
        
    }

    private int count = 0;

    protected override void OnShowViewAndRefresh(object data)
    {
        //整个UI当做游戏
        _levelId = (int)data;
        var levelData = new LevelData(_levelId);

        GamePlay.instance.InitGame(_view, levelData, _levelId);
        AudioFacade.instance.PlayClip("Bgm_Main", true);

        InitRender();

        if (_levelId == 1)
        {
            GamePlay.instance.IsGuideMode = true;

            _view.rectGuide1.gameObject.SetActive(true);
            UIEventListener.OnClick(_view.rectGuide2.gameObject).AddListener((go =>
            {
                _view.rectGuide2.gameObject.SetActive(false);

                _view.rectGuide3.gameObject.SetActive(true);
                GamePlay.instance.GuidePhase++;
            }));

            UIEventListener.OnClick(_view.rectGuide3.gameObject).AddListener((go =>
            {
                _view.rectGuide3.gameObject.SetActive(false);
                GameLaunch.ResumeGame();
            }));

            UIEventListener.OnClick(_view.rectGuide4.gameObject).AddListener(go =>
            {
                _view.rectGuide4.gameObject.SetActive(false);
                GameLaunch.ResumeGame();
            });
        }
        else
        {
            _view.rectGuide1.gameObject.SetActive(false);
        }


        _updatorId = EquineScheduler.AddTimeLimitUpdator(0, OnUpdate);
    }

    private void OnUpdate(int a, object b, UpdateTimeInfo time)
    {
        if (!_isShowTip)
            return;

        _showTipCurrentTime += time.deltaTime;
        if (_showTipCurrentTime >= _showTipEndTime)
        {
            _isShowTip = false;
            _view.tip.SetActive(false);
        }
    }

    protected override void BeforeHideView()
    {
        GamePlay.instance.Dispose();
        GamePlay.Release();
        AudioFacade.instance.StopClip("Bgm_Main");

        UnInitRender();

        EquineScheduler.RemoveLimitUpdator(ref _updatorId);

        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.Magnet))
            .RemoveListener(UseMagnet);
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.ForceChoose))
            .RemoveListener(UseForceChoose);
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.Hammer))
            .RemoveListener(UseHammer);
        UIEventListener.OnPointerUp(_view.itemBtnGameObject.GetItem((int)GameItemType.Refresh))
            .RemoveListener(UseRefresh);
        UIEventListener.OnClick(_view.fever.gameObject).RemoveListener(OnClickFever);
        UIEventListener.OnClick(_view.btnSettings).RemoveListener(OnBtnSettingsClick);

        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.Magnet)).RemoveListener(OnAddMagnet);
        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.ForceChoose))
            .RemoveListener(OnAddForceChoose);
        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.Hammer)).RemoveListener(OnAddHammer);
        UIEventListener.OnClick(_view.itemBgNumber.GetItem((int)GameItemType.Refresh)).RemoveListener(OnAddRefresh);
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private void InitRender()
    {
        //level
        _view.textLevelNum.text = _levelId.ToString();

        //target
        const float widthAny = 331f;
        const float widthSpecific = 323f;
        const float specificDelta = 70f;
        var winCondition = GamePlay.instance.WinCondition;
        switch (winCondition)
        {
            case WinCondition.Any:
                var sizeDelta = _view.rectInfo.sizeDelta;
                sizeDelta.x = widthAny;
                _view.rectInfo.sizeDelta = sizeDelta;
                _view.target[0].SetActive(true);

                //数量
                _view.target[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                _view.target[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    GamePlay.instance.NeedKillNum.ToString();

                //对钩
                _view.target[0].transform.GetChild(1).GetComponent<Image>().enabled = false;
                break;
            case WinCondition.Specific:
                sizeDelta = _view.rectInfo.sizeDelta;
                var num = GamePlay.instance.SpecificNeedKillNum.Count;
                sizeDelta.x = widthSpecific + (num - 1) * specificDelta;
                _view.rectInfo.sizeDelta = sizeDelta;
                var keys = GamePlay.instance.SpecificNeedKillNum.Keys.ToList();
                for (int i = 1; i < num + 1; i++)
                {
                    var battleColor = keys[i - 1];
                    _view.target[i].SetActive(true);

                    //目标图片
                    _view.target[i].GetComponent<Image>().sprite = GameImgCache.instance.TargetBrickImg[battleColor];

                    //数量
                    _view.target[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    _view.target[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                        GamePlay.instance.SpecificNeedKillNum[battleColor].ToString();

                    //对钩
                    _view.target[i].transform.GetChild(1).GetComponent<Image>().enabled = false;

                    _colorIndexRelation[battleColor] = i;
                }

                break;
        }

        //isHardMode
        _view.imgHard.enabled = GamePlay.instance.LevelData.IsHardMode;

        //box panel
        var col = GamePlay.instance.LevelData.BoxCol;
        //arrows
        for (int i = 0; i < col; i++)
        {
            _view.arrows.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = col; i < _view.arrows.transform.childCount; i++)
        {
            _view.arrows.transform.GetChild(i).gameObject.SetActive(false);
        }

        //lines
        for (int i = 0; i < col + 1; i++)
        {
            _view.lines.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = col + 1; i < _view.lines.transform.childCount; i++)
        {
            _view.lines.transform.GetChild(i).gameObject.SetActive(false);
        }

        //combo
        _view.comboBg.enabled = false;
        _view.comboImg.enabled = false;

        //tip
        _view.tip.SetActive(false);
    }

    private Image _feverBar;
    private Image _feverBarPlus;


    private void UnInitRender()
    {
        for (int i = 0; i < _view.target.length; i++)
        {
            _view.target[i].SetActive(false);
        }


        GameItem.ForeachItem((gameItemType =>
        {
            var index = (int)gameItemType;
            _view.itemImgPlus.GetItem(index).SetActive(false);
            _view.itemMask.GetItem(index).SetActive(false);
        }));

        _view.skelHard.gameObject.SetActive(false);
        _view.frameHard.gameObject.SetActive(false);
    }

    private void OnRenderSlotLock(object data)
    {
        const int defaultSlotNum = 4;
        const int maxSlotNum = 7;
        const float width4 = 418f;
        const float widthDelta = 140f;


        var currentSlotNum = (int)data;
        var sizeDelta = _view.slotLock.sizeDelta;

        //length
        if (currentSlotNum == defaultSlotNum)
        {
            sizeDelta.x = width4;
        }
        else if (currentSlotNum == GamePlay.instance.GamePlayData.SlotMaxNum)
        {
            sizeDelta.x = 0f;
        }
        else
        {
            sizeDelta.x = width4 - (currentSlotNum - defaultSlotNum) * widthDelta;
        }

        //three lines
        if (currentSlotNum == maxSlotNum - 1 || currentSlotNum == maxSlotNum)
        {
            _view.imgThreeLines.enabled = false;
        }
        else
        {
            _view.imgThreeLines.enabled = true;
        }


        _view.slotLock.sizeDelta = sizeDelta;
    }


    private void OnGameOver(object data)
    {
        var gameOverType = (GameOverType)data;
        var progress = GamePlay.instance.CurrentKillProgress;
        if (ReviveNormal.RemainReviveTime == 0)
        {
            ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_LOSE_U_I);
        }
        else
        {
            ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_REVIVE_U_I, (gameOverType, progress));
        }
    }

    private void OnGameWin(object data)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_WIN_U_I, _levelId);
    }

    private void OnTotalKillNumberUpdate(object data)
    {
        var totalKillNum = (int)data;
        if (totalKillNum > 0)
        {
            //数量
            _view.target[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = totalKillNum.ToString();
        }
        else
        {
            //数量
            _view.target[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            //对钩
            _view.target[0].transform.GetChild(1).GetComponent<Image>().enabled = true;
        }
    }

    private void OnSpecialKillNumberUpdate(object data)
    {
        var (color, num) = ((BattleColor, int))data;

        if (num > 0)
        {
            //数量
            _view.target[_colorIndexRelation[color]].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                num.ToString();
        }
        else
        {
            //数量
            _view.target[_colorIndexRelation[color]].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled =
                false;
            //对钩
            _view.target[_colorIndexRelation[color]].transform.GetChild(1).GetComponent<Image>().enabled = true;
        }
    }

    private string ToSpriteFont(int number)
    {
        var sb = new StringBuilder();
        foreach (var numChar in number.ToString())
        {
            sb.Append($"<sprite={numChar}>");
        }

        return sb.ToString();
    }

    private void UseForceChoose(GameObject gameObject, PointerEventData eventData)
    {
        if (GamePlay.instance.IsFreezePlayerInput)
            return;

        GamePlay.instance.GameItem.Use(GameItemType.ForceChoose);
    }

    private void UseMagnet(GameObject gameObject, PointerEventData eventData)
    {
        if (GamePlay.instance.IsFreezePlayerInput)
            return;

        GamePlay.instance.GameItem.Use(GameItemType.Magnet);
    }

    private void UseHammer(GameObject gameObject, PointerEventData eventData)
    {
        if (GamePlay.instance.IsFreezePlayerInput)
            return;

        GamePlay.instance.GameItem.Use(GameItemType.Hammer);
    }

    private void UseRefresh(GameObject gameObject, PointerEventData eventData)
    {
        if (GamePlay.instance.IsFreezePlayerInput)
            return;

        GamePlay.instance.GameItem.Use(GameItemType.Refresh);
    }

    private void OnAddMagnet(GameObject gameObject)
    {
        ShowBuyItemPopup(GameItemType.Magnet);
    }

    private void OnAddForceChoose(GameObject gameObject)
    {
        ShowBuyItemPopup(GameItemType.ForceChoose);
    }

    private void OnAddHammer(GameObject gameObject)
    {
        ShowBuyItemPopup(GameItemType.Hammer);
    }

    private void OnAddRefresh(GameObject gameObject)
    {
        ShowBuyItemPopup(GameItemType.Refresh);
    }

    private void ShowBuyItemPopup(GameItemType itemType)
    {
        var gameItem = GamePlay.instance.GameItem;
        if (gameItem.CurrentNum[itemType] != 0)
            return;

        //等于0的时候，即没有的时候才允许购买
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_BUY_ITEM_POPUP, itemType);
    }

    private void OnClickFever(GameObject gameObject)
    {
        if (GamePlay.instance.IsFreezePlayerInput)
            return;

        EquineScheduler.RunYieldProcedure(GamePlay.instance.Fever.StartFever());
    }

    private void OnBtnSettingsClick(GameObject gameObject)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_SETTINGS_U_I, SettingsState.InGame);
    }

    private void OnRenderCombo(object data)
    {
        var (num, percentage) = ((int, float))data;
        if (num == 0)
        {
            _view.comboNum.text = "";
            _view.comboBg.enabled = false;
            _view.comboImg.enabled = false;
        }
        else
        {
            _view.comboBg.enabled = true;
            _view.comboImg.enabled = true;
            var fever = GamePlay.instance.Fever;
            if (num >= fever.ComboNeedNumP5)
            {
                _view.comboImg.sprite = GameImgCache.instance.ComboImg["Perfect"];
                _view.comboBg.sprite = GameImgCache.instance.ComboImg["PerfectBg"];
                _view.comboImg.SetNativeSize();
                _view.comboBg.SetNativeSize();
                _view.comboImg.fillAmount = percentage;
            }
            else if (num >= fever.ComboNeedNumP4)
            {
                _view.comboImg.sprite = GameImgCache.instance.ComboImg["Fantastic"];
                _view.comboBg.sprite = GameImgCache.instance.ComboImg["FantasticBg"];
                _view.comboImg.SetNativeSize();
                _view.comboBg.SetNativeSize();
                _view.comboImg.fillAmount = percentage;
            }
            else if (num >= fever.ComboNeedNumP3)
            {
                _view.comboImg.sprite = GameImgCache.instance.ComboImg["Amazing"];
                _view.comboBg.sprite = GameImgCache.instance.ComboImg["AmazingBg"];
                _view.comboImg.SetNativeSize();
                _view.comboBg.SetNativeSize();
                _view.comboImg.fillAmount = percentage;
            }
            else if (num >= fever.ComboNeedNumP2)
            {
                _view.comboImg.sprite = GameImgCache.instance.ComboImg["Awesome"];
                _view.comboBg.sprite = GameImgCache.instance.ComboImg["AwesomeBg"];
                _view.comboImg.SetNativeSize();
                _view.comboBg.SetNativeSize();
                _view.comboImg.fillAmount = percentage;
            }
            else if (num >= fever.ComboNeedNumP1)
            {
                _view.comboImg.sprite = GameImgCache.instance.ComboImg["GoodJob"];
                _view.comboBg.sprite = GameImgCache.instance.ComboImg["GoodJobBg"];
                _view.comboImg.SetNativeSize();
                _view.comboBg.SetNativeSize();
                _view.comboImg.fillAmount = percentage;
            }
            else
            {
                _view.comboImg.enabled = false;
                _view.comboBg.enabled = false;
            }

            if (num >= 2)
                _view.comboNum.text = ToSpriteFont(num);
        }
    }

    private void OnFeverEnergyInc(object data)
    {
        var (fillAmount, phase) = ((float, int))data;

        var startFillAmount = 0.15f;
        var endFillAmount = 0.55f;


        if (phase == 1)
        {
            _view.feverBarP1.fillAmount = fillAmount;
            _view.feverBarP2.fillAmount = startFillAmount;
            _view.feverBarP3.fillAmount = startFillAmount;
        }
        else if (phase == 2)
        {
            _view.feverBarP1.fillAmount = endFillAmount;
            _view.feverBarP2.fillAmount = fillAmount;
            _view.feverBarP3.fillAmount = startFillAmount;
        }
        else if (phase == 3)
        {
            _view.feverBarP1.fillAmount = endFillAmount;
            _view.feverBarP2.fillAmount = endFillAmount;
            _view.feverBarP3.fillAmount = fillAmount;
        }


        if (phase == 1)
        {
            var anim = _view.skelFeverBtn.AnimationState.Tracks.Items[0].Animation.Name;
            if (anim == "normal")
                return;
            _view.skelFeverBtn.AnimationState.SetAnimation(0, "normal", true);
        }
        else if (phase == 2)
        {
            var anim = _view.skelFeverBtn.AnimationState.Tracks.Items[0].Animation.Name;
            if (anim == "level_01_ing")
                return;
            _view.skelFeverBtn.AnimationState.SetAnimation(0, "level_01_ing", true);
        }
        else if (phase == 3 && fillAmount < endFillAmount)
        {
            var anim = _view.skelFeverBtn.AnimationState.Tracks.Items[0].Animation.Name;
            if (anim == "level_02_ing")
                return;
            _view.skelFeverBtn.AnimationState.SetAnimation(0, "level_02_ing", true);
        }
        else
        {
            var anim = _view.skelFeverBtn.AnimationState.Tracks.Items[0].Animation.Name;
            if (anim == "level_03_ing")
                return;
            _view.skelFeverBtn.AnimationState.SetAnimation(0, "level_03_ing", true);
        }
    }

    private void OnFeverEnergyDec(object data)
    {
        var (fillAmount, phase) = ((float, int))data;

        var startFillAmount = 0.15f;
        var endFillAmount = 0.55f;

        if (phase == 1)
        {
            _view.feverBarP1.fillAmount = fillAmount;
            _view.feverBarP2.fillAmount = startFillAmount;
            _view.feverBarP3.fillAmount = startFillAmount;
        }
        else if (phase == 2)
        {
            _view.feverBarP1.fillAmount = endFillAmount;
            _view.feverBarP2.fillAmount = fillAmount;
            _view.feverBarP3.fillAmount = startFillAmount;
        }
        else if (phase == 3)
        {
            _view.feverBarP1.fillAmount = endFillAmount;
            _view.feverBarP2.fillAmount = endFillAmount;
            _view.feverBarP3.fillAmount = fillAmount;
        }

        if (Mathf.Approximately(fillAmount, startFillAmount) && phase == 1)
        {
            _view.skelFeverBtn.AnimationState.SetAnimation(0, "normal", true);
        }
    }


    private void RenderNewFeaturePopup(object data)
    {
        foreach (var (key, (lowwer, upper)) in PreviewContentData.instance.FeatureRange)
        {
            if (_levelId == upper && !PlayerSave.instance.PlayerUnlock.IsPopNewFeature[key])
            {
                ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_NEW_FEATURE_POPUP, key);
                PlayerSave.instance.PlayerUnlock.IsPopNewFeature[key] = true;
                break;
            }
        }
    }

    private void RenderNewItemPopup(object data)
    {
        foreach (var (key, (lowwer, upper)) in PreviewContentData.instance.ItemRange)
        {
            if (_levelId == upper && !PlayerSave.instance.PlayerUnlock.IsPopNewItem[key])
            {
                ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_NEW_ITEM_POPUP, key);
                PlayerSave.instance.PlayerUnlock.IsPopNewItem[key] = true;
                break;
            }
        }
    }

    private void OnGuideNextPhase(object data)
    {
        if (GamePlay.instance.GuidePhase == 1)
        {
            _view.rectGuide1.gameObject.SetActive(false);
        }
        else if (GamePlay.instance.GuidePhase == 2)
        {
            _view.rectGuide2.gameObject.SetActive(true);
        }
        else if (GamePlay.instance.GuidePhase == 4)
        {
            _view.rectGuide4.gameObject.SetActive(true);
        }
        else if (GamePlay.instance.GuidePhase == 5)
        {
            _view.rectGuide5.gameObject.SetActive(true);
        }
        else if (GamePlay.instance.GuidePhase == 6)
        {
            _view.rectGuide5.gameObject.SetActive(false);
        }
    }

    private void OnStartFever(object data)
    {
        var ui = _view;
        var fever = GamePlay.instance.Fever;

        AudioFacade.instance.StopClip("Bgm_Main");
        AudioFacade.instance.PlayClip("Bgm_Fever1_13s", true);

        //鸭子
        for (int i = 0; i < ui.feverDucks.length; i++)
        {
            ui.feverDucks.GetItem(i).gameObject.SetActive(true);
        }

        ui.rectFeverDucks.transform.DOMove(ui.feverEndPos.transform.position, fever.FeverAnimDuration);

        //背景
        ChangeBgColor(0).onComplete += () =>
            ChangeBgColor(1).onComplete += () =>
                ChangeBgColor(2).onComplete += () =>
                    ChangeBgColor(3).onComplete += () =>
                        ChangeBgColor(4).onComplete += () =>
                            ChangeBgColor(5);


        ui.ImgFeverBg_Low.transform.DOMove(ui.feverEndPos.transform.position, fever.FeverAnimDuration).onComplete +=
            () => { };

        ui.ImgFeverBg_High.transform.DOMove(ui.feverEndPos.transform.position, fever.FeverAnimDuration).onComplete +=
            () => { };


        //卡皮巴拉
        var capybaraVo = new CapybaraVo();
        capybaraVo.CapybaraAction = CapybaraAction.ChangeToHighForm;
        GamePlay.instance.Capybara.data = capybaraVo;

        // var track = ui.skelCapybara.AnimationState.SetAnimation(0, "switch", false);
        // track.TimeScale = 1.25f;
        // track.Complete += entry =>
        // {
        //     ui.skelCapybara.enabled = false;
        //     ui.skelCapybaraEx.enabled = true;
        //     ui.skelCapybaraEx.AnimationState.SetAnimation(0, "add", false);
        //     ui.skelCapybaraEx.AnimationState.AddAnimation(0, "idle", true, 0f);
        // };
    }

    private TweenerCore<float, float, FloatOptions> ChangeBgColor(int currentBgIndex)
    {
        if (currentBgIndex is <= -1 or >= 6)
            return null;

        var nextBgIndex = (currentBgIndex + 1) % 6;

        var ui = GamePlay.instance.UI;
        var highImg = ui.ImgFeverBg_High;
        var highImgEx = ui.ImgFeverBgEx_High;
        highImg.sprite = GameImgCache.instance.FeverBgImg[currentBgIndex];
        highImgEx.sprite = GameImgCache.instance.FeverBgImg[currentBgIndex];

        var lowImg = ui.ImgFeverBg_Low;
        var lowImgEx = ui.ImgFeverBgEx_Low;
        lowImg.sprite = GameImgCache.instance.FeverBgImg[nextBgIndex];
        lowImgEx.sprite = GameImgCache.instance.FeverBgImg[nextBgIndex];

        var ret = DOTween.To(() => highImg.color.a, alpha =>
        {
            var color = highImg.color;
            color.a = alpha;
            highImg.color = color;
            highImgEx.color = color;
        }, 0f, 1.5f);
        ret.onComplete += () =>
        {
            var color = highImg.color;
            color.a = 1f;
            highImg.color = color;
            highImgEx.color = color;
        };

        return ret;
    }

    private void OnEndFever(object data)
    {
        var ui = _view;
        ui.ImgFeverBg_Low.transform.position = ui.feverStartPos.transform.position;
        ui.ImgFeverBg_High.transform.position = ui.feverStartPos.transform.position;

        for (int i = 0; i < ui.feverDucks.length; i++)
        {
            ui.feverDucks.GetItem(i).gameObject.SetActive(false);
        }

        ui.rectFeverDucks.transform.position = ui.feverStartPos.transform.position;


        var capybaraVo = new CapybaraVo();
        capybaraVo.CapybaraAction = CapybaraAction.ChangeToLowForm;
        GamePlay.instance.Capybara.data = capybaraVo;

        AudioFacade.instance.StopClip("Bgm_Fever1_13s");
        AudioFacade.instance.PlayClip("Bgm_Main", true);
    }

    private void OnResetFever(object data)
    {
        var ui = _view;
        ui.ImgFeverBg_Low.transform.position = ui.feverStartPos.transform.position;
        ui.ImgFeverBg_High.transform.position = ui.feverStartPos.transform.position;

        for (int i = 0; i < ui.feverDucks.length; i++)
        {
            ui.feverDucks.GetItem(i).gameObject.SetActive(false);
        }

        ui.rectFeverDucks.transform.position = ui.feverStartPos.transform.position;

        AudioFacade.instance.StopClip("Bgm_Fever1_13s");
    }

    private void OnShowTip(object data)
    {
        var str = data as string;
        if (_view.tip.activeSelf)
        {
            _view.textTip.text = str;
        }
        else
        {
            _view.tip.SetActive(true);
            _view.textTip.text = str;
        }

        _showTipCurrentTime = 0f;
        _isShowTip = true;
    }

    private void OnRenderItem(object data)
    {
        var gameItem = GamePlay.instance.GameItem;
        var gameItemType = (GameItemType)data;

        //如果未解锁，就不渲染
        if (!gameItem.IsItemUnlocked[gameItemType])
            return;

        var itemId = (int)gameItemType;
        if (gameItem.RemainUseNum[gameItemType] == 0)
        {
            //达到使用上限
            _view.itemMask.GetItem(itemId).SetActive(true);

            _view.itemBgNumber.GetItem(itemId).SetActive(false);
        }
        else
        {
            //未达到使用上限
            _view.itemMask.GetItem(itemId).SetActive(false);

            _view.itemBgNumber.GetItem(itemId).SetActive(true);

            var itemNum = gameItem.CurrentNum[gameItemType];
            if (itemNum == 0)
            {
                _view.itemNumber.GetItem(itemId).GetComponent<TextMeshProUGUI>().text = "";
                _view.itemImgPlus.GetItem(itemId).SetActive(true);
            }
            else
            {
                _view.itemNumber.GetItem(itemId).GetComponent<TextMeshProUGUI>().text = itemNum.ToString();
                _view.itemImgPlus.GetItem(itemId).SetActive(false);
            }
        }
    }

    private void OnRenderItemLock(object data)
    {
        for (int i = 0; i < (int)GameItemType.MaxLimit; i++)
        {
            var gameItemType = (GameItemType)i;
            var isUnlock = GamePlay.instance.GameItem.IsItemUnlocked[gameItemType];


            //effect unlock
            _view.itemBtnGameObject.GetItem(i).SetActive(isUnlock);
            _view.itemBgNumber.GetItem(i).SetActive(isUnlock);


            //effect lock
            _view.itemText.GetItem(i).SetActive(!isUnlock);
            _view.itemTextLevel.GetItem(i).SetActive(!isUnlock);
            _view.itemTextLevel.GetItem(i).GetComponent<TextMeshProUGUI>().text =
                PreviewContentData.instance.ItemRange[(GameItemType)i].Item2.ToString();
            _view.itemImgLock.GetItem(i).SetActive(!isUnlock);
        }
    }

    private void OnGameStartFinished(object data)
    {
        if (!GamePlay.instance.LevelData.IsHardMode)
            return;

        //frame
        _view.frameHard.gameObject.SetActive(true);

        //anim
        _view.skelHard.gameObject.SetActive(true);
        _view.skelHard.gameObject.GetComponentInChildren<TextMeshProUGUI>().text =
            $"{(GamePlay.instance.LevelData.FailRate * 100):00}% OF HUMAN FRIENDS FAIL THE LEVEL.";
        _view.skelHard.AnimationState.SetAnimation(0, "add", false).Complete += entry =>
        {
            _view.skelHard.gameObject.SetActive(false);
            _view.frameHard.gameObject.SetActive(false);
        };
    }
}