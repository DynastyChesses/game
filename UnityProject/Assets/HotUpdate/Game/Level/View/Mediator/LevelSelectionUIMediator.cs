using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HotUpdate.osP1;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.Save;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUIEvent
{
    public const string RenderStamina = "RenderStamina";
    public const string RenderGold = "RenderGold";
    public const string RenderAdTicket = "RenderAdTicket";
    public const string RenderBtnPlay = "RenderBtnPlay";
    public const string RenderStaminaTime = "RenderStaminaTime";
    
}


public class LevelSelectionUIMediator : TBaseUIMediator<LevelSelectionUISkin>
{
    public static bool IsDebugModeWhenEnterLevel = false;
    
    private bool _isInit;

    private bool _isAllowClick = true;
    private bool _isBtnPlayLock = false;
    
    private bool _isEnterGameScene = false;


    private int _currentCh;

    private List<string> _chName = new List<string>()
    {
        "CH.1 Spring",
        "CH.2 Grassland",
        "CH.3 Forest",
        "CH.4 Oasis",
        "CH.5 Desert",
        "CH.6 Beach",
    };

    private float _chMoveTime = 0.5f;

    private TweenerCore<float, float, FloatOptions> _tweener;

    private HashSet<string> _groupLevelSkipName = new HashSet<string>()
    {
        "Bg",
        "Bg_Lock",
        "Cover",
        "Number1",
        "Number2",
        "Number3",
        "Number4",
        "Number5",
        "Number6",
        "Number7",
        "Number8",
        "Number9",
        "Number10",
        "Number11",
        "Number12",
        "Number13",
        "Number14",
        "Number15",
        "Number16"
    };


    


    public LevelSelectionUIMediator() : base(MediatorNames.LEVEL_SELECTION_U_I,
        NotificationConst.SHOW_LEVEL_SELECTION_U_I, NotificationConst.HIDE_LEVEL_SELECTION_U_I)
    {
        RegisterNotificationHandler(GameConsts.Destroy, OnDestroy);

        RegisterNotificationHandler(LevelSelectionUIEvent.RenderStamina, OnRenderStamina);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderGold, OnRenderGold);
        RegisterNotificationHandler(LevelSelectionUIEvent.RenderStaminaTime,OnRenderStaminaTime);


        //Debug
        RegisterNotificationHandler(GameDebugEvent.DebugGameWin, OnDebugGameWin);
        RegisterNotificationHandler(GameDebugEvent.DebugFillFeverEnergy, OnDebugFillFeverEnergy);
        
        RegisterNotificationHandler(GameDebugEvent.DebugEnterLevel,OnDebugEnterLevel);
        
        RegisterNotificationHandler(GameDebugEvent.DebugClearSave, OnDebugClearSave);
        RegisterNotificationHandler(GameDebugEvent.DebugAddStamina,OnDebugAddStamina);
        RegisterNotificationHandler(GameDebugEvent.DebugRemoveStamina,OnDebugRemoveStamina);

        RegisterNotificationHandler(GameDebugEvent.DebugAddGold,OnDebugAddGold);
        RegisterNotificationHandler(GameDebugEvent.DebugRemoveGold,OnDebugRemoveGold);
        RegisterNotificationHandler(GameDebugEvent.DebugAddAdTicket,OnDebugAddAdTicket);
        RegisterNotificationHandler(GameDebugEvent.DebugRemoveAdTicket,OnDebugRemoveAdTicket);
        RegisterNotificationHandler(GameDebugEvent.DebugAddMagnet,OnDebugAddMagnet);
        RegisterNotificationHandler(GameDebugEvent.DebugAddForceChoose,OnDebugAddForceChoose);
        RegisterNotificationHandler(GameDebugEvent.DebugAddHammer,OnDebugAddHammer);
        RegisterNotificationHandler(GameDebugEvent.DebugAddRefresh,OnDebugAddRefresh);
        RegisterNotificationHandler(GameDebugEvent.DebugSetRemainTime,OnDebugSetRemainTime);
        
        Application.targetFrameRate = 60;
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        EquineMonoDispatcher.onApplicationPause += OnPause;

        
        PlayerSave.instance.Load();

        
        
        UIEventListener.OnClick(_view.btnLeft).AddListener(OnBtnLeftClick);
        UIEventListener.OnClick(_view.btnRight).AddListener(OnBtnRightClick);
        UIEventListener.OnClick(_view.btnPlay).AddListener(OnBtnPlayClick);
        UIEventListener.OnClick(_view.btnSettings).AddListener(OnBtnSettingsClick);
        
        _isInit = true;
    }

    private void InitShowViewAndRefresh(object data)
    {
        //初始化体力金币
        ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderStamina,
            PlayerSave.instance.PlayerAssets.Stamina);
        ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderGold,
            PlayerSave.instance.PlayerAssets.Gold);

        //获取章节
        var levelId = PlayerSave.instance.PlayerProgress.CurrentLevelId;
        _currentCh = PlayerProgress.GetCurrentCh(levelId);
        

        //初始化chapter位置
        var deltaLength = Vector3.Distance(_view.rectPos.position, _view.rectOriginPos.position);
        var index = _currentCh - 1;
        var currentLevelGroup = _view.levelGroup.GetItem(index);
        currentLevelGroup.transform.position = _view.rectOriginPos.position;

        for (int i = index - 1, count = 1; i >= 0; i--, count++)
        {
            _view.levelGroup.GetItem(i).transform.position = _view.rectOriginPos.position -
                                                             new Vector3(1f, 0, 0) * (deltaLength * count);
        }

        for (int i = index + 1, count = 1; i < _view.levelGroup.length; i++, count++)
        {
            _view.levelGroup.GetItem(i).transform.position = _view.rectOriginPos.position +
                                                             new Vector3(1f, 0, 0) * (deltaLength * count);
        }


        //初始化导航圆圈
        _view.naviRound.GetItem(_currentCh - 1).sprite = GameImgCache.instance.LevelSelectionImg["BigRound"];
        _view.naviRound.GetItem(_currentCh - 1).SetNativeSize();

        //初始化按钮
        if (_currentCh == 1)
        {
            var canvasGroup = _view.btnLeftCG;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
        else if (_currentCh == 6)
        {
            var canvasGroup = _view.btnRightCG;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        //初始化关卡号码
        _view.textLevelId.text = $"LEVEL {PlayerSave.instance.PlayerProgress.CurrentLevelId}";


        //初始化图片
        var effectLevelId = PlayerSave.instance.PlayerProgress.CurrentLevelEffectId;
        var effectChapter = PlayerProgress.GetCurrentCh(effectLevelId);

        var chMinLevelId = PlayerProgress.GetChMinLevelId(effectChapter);
        var needDisplayIndex = effectLevelId - chMinLevelId - 1; //-1是因为levelId是当前多少要玩多少关，还未通关

        //effectLevelId 当前的章节
        if (levelId < PlayerProgress.MaxLevel)
        {
            var currentChapterTr = _view.levelGroup.GetItem(_currentCh - 1).transform;
            for (int j = 0; j < currentChapterTr.childCount; j++)
            {
                var child = currentChapterTr.GetChild(j);
                if (_groupLevelSkipName.Contains(child.name))
                    continue;
                if (int.Parse(child.name) <= needDisplayIndex)
                {
                    child.gameObject.SetActive(true);
                    child.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                }
            }
        }
        else
        {
            var currentChapterTr = _view.levelGroup.GetItem(_currentCh - 1).transform;
            for (int j = 0; j < currentChapterTr.childCount; j++)
            {
                var child = currentChapterTr.GetChild(j);
                if (child.name == "Cover")
                    child.GetComponent<Image>().enabled = true;
                if(child.name.StartsWith("Number"))
                    child.GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        

        //effectLevelId 之前的章节
        for (int i = PlayerProgress.MinCh; i < effectChapter; i++)
        {
            var prevChapterTr = _view.levelGroup.GetItem(i - 1).transform;
            for (int j = 0; j < prevChapterTr.childCount; j++)
            {
                var child = prevChapterTr.GetChild(j);
                if (child.name == "Cover")
                    child.GetComponent<Image>().enabled = true;
                if(child.name.StartsWith("Number"))
                    child.GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }

        //effectLevelId 之后的章节
        for (int i = effectChapter + 1; i <= PlayerProgress.MaxCh; i++)
        {
            var nextChapterTr = _view.levelGroup.GetItem(i - 1).transform;
            for (int j = 0; j < nextChapterTr.childCount; j++)
            {
                var child = nextChapterTr.GetChild(j);
                if (child.name == "Bg_Lock")
                    child.GetComponent<Image>().enabled = true;
                if(child.name.StartsWith("Number"))
                    child.GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        
        //当前关卡图片，如果特效播放播放完毕
        if(effectLevelId == levelId)
            OnRenderCurrentLevelImg(levelId);
        
        //初始化BtnPlay状态
        _isBtnPlayLock = false;
        
        //章节名称
        _view.textChapter.text = _chName[ _currentCh - 1];


        

        
    }


    protected override void OnShowViewAndRefresh(object data)
    {
        if (_isInit)
        {
            _isInit = false;
            InitShowViewAndRefresh(data);
        }
        
        //播放解锁特效 目前为直接播放
        
        var levelId = PlayerSave.instance.PlayerProgress.CurrentLevelId;
        if (PlayerSave.instance.PlayerProgress.CurrentLevelEffectId < levelId)
        {
            _isAllowClick = false;
            AcquireImg((() => _isAllowClick = true));
            PlayerSave.instance.PlayerProgress.CurrentLevelEffectId++;
        }

        //按钮关卡数
        OnRenderBtnPlay(PlayerSave.instance.PlayerProgress.CurrentLevelId);
    }


    private void AcquireImg(Action callback = null)
    {
        var levelId = PlayerSave.instance.PlayerProgress.CurrentLevelId;
        var effectLevelId = PlayerSave.instance.PlayerProgress.CurrentLevelEffectId;
        var ch = PlayerProgress.GetCurrentCh(effectLevelId);

        var chMinLevelId = PlayerProgress.GetChMinLevelId(ch);
        var bias = effectLevelId - chMinLevelId;
        var tr = _view.levelGroup.GetItem(ch - 1).transform;

        Vector3 imgOriginPos = Vector3.zero;
        Transform imgOriginParent = null;

        Transform imgTr = null;
        for (int i = 0; i < tr.childCount; i++)
        {
            var child = tr.GetChild(i).gameObject;
            if (_groupLevelSkipName.Contains(child.name))
                continue;
            if (int.Parse(child.name) == bias)
            {
                child.SetActive(true);
                imgOriginPos = child.transform.position;
                imgOriginParent = child.transform.parent;
                imgTr = child.transform;
                break;
            }
        }

        var seq = DOTween.Sequence();
        
        //隐藏图上字体
        imgTr.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        //光特效，黑幕
        if (_tweener != null)
        {
            _tweener.Pause();
            _tweener.setter(1f);
            _tweener.Kill();
            _tweener = null;
        }
        
        _view.goAcquireImg_Text.SetActive(true);
        _view.imgAcquireImgMask.enabled = true;
        _view.imgAcquireImgEffectLight.enabled = true;
        imgTr.SetParent(_view.rectAcquireImgPos);
        imgTr.position = _view.rectAcquireImgPos.position;
        seq.Append(_view.imgAcquireImgEffectLight.transform.DORotate(new Vector3(0f, 0f, 90f), 1f, RotateMode.Fast)
            .SetEase(Ease.Linear));
        seq.AppendCallback((() =>
        {
            _view.imgAcquireImgEffectLight.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            _view.imgAcquireImgMask.enabled = false;
            _view.imgAcquireImgEffectLight.enabled = false;
            _view.goAcquireImg_Text.SetActive(false);

        }));

        //位移
        var startPos = _view.rectAcquireImgPos.position;
        var endPos = imgOriginPos;
        var center = (startPos + endPos) / 2;
        var dis = Vector3.Distance(startPos, endPos);
        var deltaVec = center - startPos;
        var perpendicularVec = Vector2.Perpendicular(deltaVec);
        if (perpendicularVec.y < 0)
            perpendicularVec *= -1; //向上凸的曲线
        var perpendicularVec3 = new Vector3(perpendicularVec.x, perpendicularVec.y, 0);
        var midPos = center + perpendicularVec3 * (dis * 0.1f);

        var path = new Vector3[]
        {
            startPos,
            midPos,
            endPos,
        };
        seq.Append(imgTr.DOPath(path, 1f, PathType.CatmullRom));

        //结束回调
        seq.AppendCallback((() =>
        {
            OnRenderCurrentLevelImg(levelId);
            imgTr.SetParent(imgOriginParent);

            var nextChMinLevel = PlayerProgress.GetChMinLevelId(ch + 1);
            var currentChMaxLevel = nextChMinLevel;
            if (effectLevelId == currentChMaxLevel)
            {
                AcquireChapter(ch, callback);
            }
            else
            {
                callback?.Invoke();
            }
        }));

        //
    }

    private void AcquireChapter(int ch, Action callback = null)
    {
        var isProcessNextCh = ch < PlayerProgress.MaxCh;
        if (isProcessNextCh)
        {
            //新章节隐藏Bg_Lock
            var nextChTr = _view.levelGroup.GetItem(ch).transform;
            for (int j = 0; j < nextChTr.childCount; j++)
            {
                var child = nextChTr.GetChild(j);
                if (child.name == "Bg_Lock")
                {
                    child.GetComponent<Image>().enabled = false;
                }

                if (child.name.StartsWith("Number"))
                {
                    child.GetComponent<TextMeshProUGUI>().enabled = true;
                }
            }
        }


        var chTr = _view.levelGroup.GetItem(ch - 1).transform;
        var seq = DOTween.Sequence();
        seq.Append(chTr.DOScale(Vector3.one * 0.95f, 0.5f).SetEase(Ease.InQuad));
        seq.AppendCallback((() =>
        {
            //两个特效
            _view.skelAcquireChEffectLightUp.enabled = true;
            _view.skelAcquireChEffectLightUp.AnimationState.SetAnimation(0, "light", false);

            _view.skelAcquireChEffectLightDown.enabled = true;
            _view.skelAcquireChEffectLightDown.transform.DORotate(new Vector3(0f, 0f, 90f), 1f, RotateMode.Fast)
                    .SetEase(Ease.Linear).onComplete +=
                () =>
                {
                    _view.skelAcquireChEffectLightDown.enabled = false;
                    _view.skelAcquireChEffectLightDown.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                };
            //无缝隙的图
            for (int j = 0; j < chTr.childCount; j++)
            {
                var child = chTr.GetChild(j);
                if (child.name == "Cover")
                {
                    child.GetComponent<Image>().enabled = true;
                    child.SetAsLastSibling();
                }
            }
        }));
        seq.Append(chTr.DOScale(Vector3.one * 1.1f, 0.5f).SetEase(Ease.OutQuad));
        seq.Append(chTr.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad));
        seq.AppendCallback((() =>
        {
            if (isProcessNextCh)
            {
                OnBtnRightClick(null);
            }
        }));
        seq.AppendCallback((() => callback?.Invoke()));
        //震动，缩放
    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();

        UIEventListener.OnClick(_view.btnLeft).RemoveListener(OnBtnLeftClick);
        UIEventListener.OnClick(_view.btnRight).RemoveListener(OnBtnRightClick);
        UIEventListener.OnClick(_view.btnPlay).RemoveListener(OnBtnPlayClick);
        UIEventListener.OnClick(_view.btnSettings).RemoveListener(OnBtnSettingsClick);
        
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private void OnBtnRightClick(GameObject go)
    {
        if (!_isAllowClick && go != null)
            return;

        var oldCh = _currentCh;
        _currentCh++;
        var newCh = _currentCh;

        var count = 0;
        var total = _view.levelGroup.length;
        Action lambda = () =>
        {
            count++;
            if (count == total)
            {
                var canvasGroup = _view.btnLeftCG;
                canvasGroup.alpha = 1;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;

                canvasGroup = _view.btnRightCG;
                canvasGroup.alpha = 1;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;

                if (_currentCh == PlayerProgress.MinCh)
                {
                    canvasGroup = _view.btnLeftCG;
                    canvasGroup.alpha = 0;
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.interactable = false;
                }
                else if (_currentCh == PlayerProgress.MaxCh)
                {
                    canvasGroup = _view.btnRightCG;
                    canvasGroup.alpha = 0;
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.interactable = false;
                }


                ChangeChapter(oldCh, newCh);
            }
        };

        var canvasGroup = _view.btnLeftCG;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        canvasGroup = _view.btnRightCG;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;


        var deltaLength = Vector3.Distance(_view.levelGroup.GetItem(1).transform.position,
            _view.levelGroup.GetItem(0).transform.position);

        for (int i = 0; i < _view.levelGroup.length; i++)
        {
            var endPos = _view.levelGroup.GetItem(i).transform.position - new Vector3(1f, 0, 0) * deltaLength;
            _view.levelGroup.GetItem(i).transform.DOMove(endPos, _chMoveTime).SetEase(Ease.InOutCubic).onComplete +=
                lambda.Invoke;
        }
    }

    private void OnBtnLeftClick(GameObject go)
    {
        if (!_isAllowClick)
            return;

        var oldCh = _currentCh;
        _currentCh--;
        var newCh = _currentCh;

        var count = 0;
        var total = _view.levelGroup.length;
        Action lambda = () =>
        {
            count++;
            if (count == total)
            {
                var canvasGroup = _view.btnLeftCG;
                canvasGroup.alpha = 1;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;

                canvasGroup = _view.btnRightCG;
                canvasGroup.alpha = 1;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;

                if (_currentCh == PlayerProgress.MinCh)
                {
                    canvasGroup = _view.btnLeftCG;
                    canvasGroup.alpha = 0;
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.interactable = false;
                }
                else if (_currentCh == PlayerProgress.MaxCh)
                {
                    canvasGroup = _view.btnRightCG;
                    canvasGroup.alpha = 0;
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.interactable = false;
                }


                ChangeChapter(oldCh, newCh);
            }
        };

        var canvasGroup = _view.btnLeftCG;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        canvasGroup = _view.btnRightCG;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        var deltaLength = Vector3.Distance(_view.levelGroup.GetItem(1).transform.position,
            _view.levelGroup.GetItem(0).transform.position);

        for (int i = 0; i < _view.levelGroup.length; i++)
        {
            var endPos = _view.levelGroup.GetItem(i).transform.position + new Vector3(1f, 0, 0) * deltaLength;
            _view.levelGroup.GetItem(i).transform.DOMove(endPos, _chMoveTime).SetEase(Ease.InOutCubic).onComplete +=
                lambda.Invoke;
        }
    }

    public void ExternClickBtnPlay()
    {
        OnBtnPlayClick(null);
    }

    private void OnBtnPlayClick(GameObject go)
    {
        if (!_isAllowClick)
            return;
        
        if(_isBtnPlayLock)
            return;
        
        if(_isEnterGameScene)
            return;
        
        if (PlayerSave.instance.PlayerAssets.Stamina == 0)
        {
            ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_BUY_STAMINA_POPUP,this);
            return;
        }
        
        PlayerSave.instance.PlayerAssets.SetCacheRemoveStamina(true);
        
        _isEnterGameScene = true;
        var level = Mathf.Min(PlayerSave.instance.PlayerProgress.CurrentLevelId, PlayerProgress.MaxLevel);
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_GAME_PLAY, level);
        _isEnterGameScene = false;
    }

    private void OnBtnSettingsClick(GameObject go)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_SETTINGS_U_I,SettingsState.InLevelSelection);
    }
    

    private void OnDestroy(object data)
    {
        PlayerSave.instance.Save();
    }

    private void OnPause(bool isPause)
    {
        if (isPause)
            PlayerSave.instance.Save();
    }

    private void OnRenderStamina(object data)
    {
        _view.textStamina.text = ((int)data).ToString();
        if (PlayerSave.instance.PlayerAssets.Stamina == PlayerSave.instance.PlayerAssets.StaminaUpperLimit)
        {
            _view.textStaminaTime.text = "MAX";
        }
    }

    private void OnRenderGold(object data)
    {
        _view.textGold.text = ((int)data).ToString();
    }

    private void OnRenderStaminaTime(object data)
    {
        var second = (int)data;
        var timeSpan = TimeSpan.FromSeconds(second);
        if (PlayerSave.instance.PlayerAssets.Stamina != PlayerSave.instance.PlayerAssets.StaminaUpperLimit)
        {
            _view.textStaminaTime.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }
    }

    private void OnRenderBtnPlay(object data)
    {
        var level = Mathf.Min((int)data, PlayerProgress.MaxLevel);
        _view.textLevelId.text = $"LEVEL {level}";
    }

    private void OnRenderCurrentLevelImg(object data)
    {
        var levelId = (int)data;
        if(levelId > PlayerProgress.MaxLevel)
            return;
        
        var ch = PlayerProgress.GetCurrentCh(levelId);
        var tr = _view.levelGroup.GetItem(ch - 1).transform;
        var chMinLevelId = PlayerProgress.GetChMinLevelId(ch);
        var bias = levelId - chMinLevelId;
        Transform currentLevelTr = null;
        for (int i = 0; i < tr.childCount; i++)
        {
            var child = tr.GetChild(i);
            if (_groupLevelSkipName.Contains(child.name))
                continue;
            if (int.Parse(child.name) == bias)
            {
                currentLevelTr = child;
                break;
            }
        }
        //隐藏背景字体
        var str = "Number" + bias;
        for (int i = 0; i < tr.childCount; i++)
        {
            var child = tr.GetChild(i);
            if (child.name == str)
            {
                child.GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }

        currentLevelTr.gameObject.SetActive(true);
        _tweener = PlayAnimIdle(currentLevelTr);
    }

    private void ChangeChapter(int oldChapter, int newChapter)
    {
        //导航按钮
        _view.naviRound.GetItem(oldChapter - 1).sprite = GameImgCache.instance.LevelSelectionImg["SmallRound"];
        _view.naviRound.GetItem(oldChapter - 1).SetNativeSize();
        _view.naviRound.GetItem(newChapter - 1).sprite = GameImgCache.instance.LevelSelectionImg["BigRound"];
        _view.naviRound.GetItem(newChapter - 1).SetNativeSize();

        //章节名称
        _view.textChapter.text = _chName[newChapter - 1];
        
        //play按钮
        var ch = PlayerProgress.GetCurrentCh(PlayerSave.instance.PlayerProgress.CurrentLevelId);
        
        if (ch == newChapter)
        {
            _view.imgLockBg.enabled = false;
            _view.imgLockText.enabled = false;
            _isBtnPlayLock = false;
        }
        else
        {
            _view.imgLockBg.enabled = true;
            _view.imgLockText.enabled = true;
            _isBtnPlayLock = true;

        }
    }

    private TweenerCore<float, float, FloatOptions> PlayAnimIdle(Transform imgTr)
    {
        var cg = imgTr.GetComponent<CanvasGroup>();
        cg.alpha = 0;

        var anim = DOTween.To(() => cg.alpha, value => cg.alpha = value, 1f, 1.5f).SetEase(Ease.OutCubic);
        anim.SetLoops(-1, LoopType.Yoyo);

        return anim;
    }

    #region Debug

    private void OnDebugGameWin(object data)
    {
        GamePlay.instance.DebugGameWin();
    }

    private void OnDebugFillFeverEnergy(object data)
    {
        GamePlay.instance.Fever.DebugFillEnergy();
    }
    
    private void OnDebugEnterLevel(object data)
    {
        if (!_isAllowClick)
            return;
        
        if(_isBtnPlayLock)
            return;

        IsDebugModeWhenEnterLevel = true;
        var levelId = (int)data;
        levelId = Mathf.Min(levelId, PlayerProgress.MaxLevel);
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_GAME_PLAY, levelId);
    }
    
    private void OnDebugClearSave(object data)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    private void OnDebugAddStamina(object data)
    {
        PlayerSave.instance.PlayerAssets.AddStamina(1,true);
    }

    private void OnDebugRemoveStamina(object data)
    {
        PlayerSave.instance.PlayerAssets.RemoveStamina(1,true);
    }

    private void OnDebugAddGold(object data)
    {
        PlayerSave.instance.PlayerAssets.AddGold((int)data);
    }

    private void OnDebugRemoveGold(object data)
    {
        PlayerSave.instance.PlayerAssets.RemoveGold((int)data);
    }

    private void OnDebugAddAdTicket(object data)
    {
        PlayerSave.instance.PlayerAssets.AddAdTicket(1);
    }

    private void OnDebugRemoveAdTicket(object data)
    {
        PlayerSave.instance.PlayerAssets.RemoveAdTicket(1);
    }

    private void OnDebugAddMagnet(object data)
    {
        PlayerSave.instance.PlayerAssets.AddItemNum(GameItemType.Magnet,1);
    }

    private void OnDebugAddForceChoose(object data)
    {
        PlayerSave.instance.PlayerAssets.AddItemNum(GameItemType.ForceChoose,1);
    }

    private void OnDebugAddHammer(object data)
    {
        PlayerSave.instance.PlayerAssets.AddItemNum(GameItemType.Hammer, 1);
    }

    private void OnDebugAddRefresh(object data)
    {
        PlayerSave.instance.PlayerAssets.AddItemNum(GameItemType.Refresh, 1);
    }

    private void OnDebugSetRemainTime(object data)
    {
        var remainTime = (int)data;
        PlayerSave.instance.PlayerAssets.DebugSetRemainTime(remainTime);
    }

    #endregion
}