using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Box : BaseScriptItemRendererView, ICommonBox
{
    private BoxVo _data;

    private List<CommonItemRenderer> _commonItemRendererList;

    private bool _isFirst = true;

    private float _moveInSlotduration = 0.2f;
    
    public const float BoxScaleInSlot = 0.84f;

    public override object data
    {
        get { return _data; }
        set
        {
            _data = value as BoxVo;
            Refresh();
        }
    }

    public override void Refresh()
    {
        base.Refresh();
        if (_data == null)
            return;
        Render();
        AfterRender();
    }

    public void Render()
    {
        var vo = _data;
        
        switch (vo.Bullets.Count)
        {
            case 1:
                RenderBullet1(vo);
                break;
            case 2:
                RenderBullet2(vo);
                break;
            case 3:
                RenderBullet3(vo);
                break;
            case 4:
                RenderBullet4(vo);
                break;
        }

        skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
        switch (vo.State)
        {
            case BoxState.InMatrix:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                outline.enabled = vo.Row == 0;
                break;
            case BoxState.InSlot:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                rectTransform.transform.localScale = Vector3.one * BoxScaleInSlot;
                outline.enabled = false;
                break;
            case BoxState.PlaceHolder:
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                outline.enabled = false;
                break;
            case BoxState.Move2Slot:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                outline.enabled = false;
                break;
        }
    }

    public void AfterRender()
    {
        var vo = _data;
        vo.Item = this;
    }

    //auto generate propertyDef Start, Don't Delete it!
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public SkeletonGraphic skeletonGraphic;
    public Outline outline;
    public SkinUObjectList<GameObject> bulletGroup4;
    public SkinUObjectList<GameObject> bulletGroup3;
    public SkinUObjectList<GameObject> bulletGroup2;
    public SkinUObjectList<GameObject> bulletGroup1;
    //auto generate propertyDef End, Don't Delete it!

    public Box()
    {
        prefabPath = "Games/osP1/Box";
    }

    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
        this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 0) as CanvasGroup;
        this.rectTransform = _viewSkin.GetSingleProperty("rectTransform", 1) as RectTransform;
        this.skeletonGraphic = _viewSkin.GetSingleProperty("skeletonGraphic", 2) as SkeletonGraphic;
        this.outline = _viewSkin.GetSingleProperty("outline", 3) as Outline;
        this.bulletGroup4 = new SkinUObjectList<GameObject>(_viewSkin, "bulletGroup4", 0);
        this.bulletGroup3 = new SkinUObjectList<GameObject>(_viewSkin, "bulletGroup3", 1);
        this.bulletGroup2 = new SkinUObjectList<GameObject>(_viewSkin, "bulletGroup2", 2);
        this.bulletGroup1 = new SkinUObjectList<GameObject>(_viewSkin, "bulletGroup1", 3);
        //auto generate propertySet End, Don't Delete it!


        Init();
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
        //auto generate propertyDis End, Don't Delete it!

        UnInit();

        base.Dispose();
    }

    private void Init()
    {
        //把所有位置分配到 list
        _commonItemRendererList = new List<CommonItemRenderer>();
        var cir = new CommonItemRenderer(bulletGroup1[0].transform);
        _commonItemRendererList.Add(cir);
        for (int i = 0; i < bulletGroup2.length; i++)
        {
            cir = new CommonItemRenderer(bulletGroup2[i].transform);
            _commonItemRendererList.Add(cir);
        }

        for (int i = 0; i < bulletGroup3.length; i++)
        {
            cir = new CommonItemRenderer(bulletGroup3[i].transform);
            _commonItemRendererList.Add(cir);
        }

        for (int i = 0; i < bulletGroup4.length; i++)
        {
            cir = new CommonItemRenderer(bulletGroup4[i].transform);
            _commonItemRendererList.Add(cir);
        }
    }

    private void UnInit()
    {
        for (int i = 0; i < _commonItemRendererList.Count; i++)
            _commonItemRendererList[i].Dispose();

        _commonItemRendererList.Clear();
        _commonItemRendererList = null;
    }

    protected override void DoClick(GameObject go)
    {
        if(GamePlay.instance.IsFreezePlayerInput)
            return;
        
        var vo = _data;
        
        if(vo.State == BoxState.InMatrix) 
            GamePlay.instance.ChooseBox(vo.Row, vo.Col);
    }


    #region Render Bullet

    private void RenderBullet1(BoxVo vo)
    {
        for (int i = 0; i < vo.Bullets.Count; i++)
        {
            bulletGroup1[i].SetActive(true);
            _commonItemRendererList[i].data = vo.Bullets[i];
        }

        ShieldOtherGroup(1);
    }

    private void RenderBullet2(BoxVo vo)
    {
        for (int i = 0; i < vo.Bullets.Count; i++)
        {
            bulletGroup2[i].SetActive(true);
            _commonItemRendererList[i + 1].data = vo.Bullets[i];
        }

        ShieldOtherGroup(2);
    }

    private void RenderBullet3(BoxVo vo)
    {
        for (int i = 0; i < vo.Bullets.Count; i++)
        {
            bulletGroup3[i].SetActive(true);
            _commonItemRendererList[i + 3].data = vo.Bullets[i];
        }

        ShieldOtherGroup(3);
    }

    private void RenderBullet4(BoxVo vo)
    {
        for (int i = 0; i < vo.Bullets.Count; i++)
        {
            bulletGroup4[i].SetActive(true);
            _commonItemRendererList[i + 6].data = vo.Bullets[i];
        }

        ShieldOtherGroup(4);
    }

    private void ShieldOtherGroup(int selfGroup)
    {
        if (selfGroup != 1)
            for (int i = 0; i < bulletGroup1.length; i++)
                bulletGroup1[i].SetActive(false);

        if (selfGroup != 2)
            for (int i = 0; i < bulletGroup2.length; i++)
                bulletGroup2[i].SetActive(false);

        if (selfGroup != 3)
            for (int i = 0; i < bulletGroup3.length; i++)
                bulletGroup3[i].SetActive(false);

        if (selfGroup != 4)
            for (int i = 0; i < bulletGroup4.length; i++)
                bulletGroup4[i].SetActive(false);
    }

    #endregion

    public CanvasGroup CanvasGroup => canvasGroup;

    public void AnimationMove2Slot(Vector3 startPos, Vector3 endPos, Action callback)
    {
        AudioFacade.instance.PlayClip("Sound_BoxMove",false);
        
        var count = 0;
        var total = 3; //spine + move + scale
        const float playScale = 2f;
        
        var endMove = skeletonGraphic.SkeletonData.FindEvent("end_move");
        var scale = 0.675f; //TODO: 写死，应该在动画事件上传浮点数进来
        var animMoveDuration = skeletonGraphic.SkeletonData.FindAnimation("move_up_jump").Duration * scale;

        //move
        var tr = gameObject.transform;
        tr.position = startPos;
        
        var tweenerCore = tr.DOMove(endPos, animMoveDuration / playScale);
        tweenerCore.onComplete += (() =>
        {
            AudioFacade.instance.PlayClip("Sound_BoxEnd", false);
            gameObject.transform.SetParent(GamePlay.instance.UI.slotLayout);
            count++;
            if (count == total)
                callback?.Invoke();
        });

        //spine
        var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "move_up_jump", false);
        trackEntry.MixDuration = 0f;
        trackEntry.TimeScale = playScale;
        var startScale = skeletonGraphic.Skeleton.Data.FindEvent("start_scale");

        trackEntry.Event += (entry, @event) =>
        {
            if (@event.Data == startScale)
            {
                //scale
                var duration = (entry.AnimationEnd * scale - entry.AnimationTime) / entry.TimeScale;
                tr.DOScale(Vector3.one * BoxScaleInSlot, duration).onComplete += (() =>
                {
                    count++;
                    if (count == total)
                        callback?.Invoke();
                });
            }
        };
        trackEntry.Complete += entry =>
        {
            count++;
            if (count == total)
                callback?.Invoke();
        };
    }

    public void AnimationMoveInSlot(Vector3 startPos, Vector3 endPos, Action callback)
    {
        var tweenerCore = gameObject.transform.DOMove(endPos, _moveInSlotduration);
        tweenerCore.onComplete += () =>
        {
            if (_data.State == BoxState.PlaceHolder)
            {
                callback?.Invoke();
            }
            else
            {
                //当箱子用完时会被 move_down 打断
                var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "move_left_end", false);
                trackEntry.MixDuration = 0f;
                trackEntry.Complete += entry => callback?.Invoke();
                trackEntry.Interrupt += entry => callback?.Invoke();
            }
        };
    }

    public void AnimationUseUp(Action callBack)
    {
        //TODO: 被打断原因

        var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "move_down", false);
        trackEntry.MixDuration = 0f;
        trackEntry.Complete += entry => { callBack?.Invoke(); };
        trackEntry.Interrupt += entry => { callBack?.Invoke(); };
    }

    public void AnimationMoveUp(Vector3 startPos, Vector3 endPos, Action callBack)
    {
        AnimationMove("move_up_end", startPos, endPos, callBack);
    }

    public void AnimationMoveLeft(Vector3 startPos, Vector3 endPos, Action callBack)
    {
        AnimationMove("move_left_end", startPos, endPos, callBack);
    }

    public void AnimationMoveRight(Vector3 startPos, Vector3 endPos, Action callBack)
    {
        AnimationMove("move_right_end", startPos, endPos, callBack);
    }

    private void AnimationMove(string endAnimation, Vector3 startPos, Vector3 endPos, Action callBack)
    {
        gameObject.transform.position = startPos;
        
        //dotween
        var tweenerCore = gameObject.transform.DOMove(endPos, BoxMatrixMoveUp.BoxMatrixMoveUpDuration);
        tweenerCore.onComplete += () =>
        {
            callBack?.Invoke();
            //spine
            var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, endAnimation, false);
            trackEntry.Complete += entry => {  };
        };
    }

    
}

// 数据类