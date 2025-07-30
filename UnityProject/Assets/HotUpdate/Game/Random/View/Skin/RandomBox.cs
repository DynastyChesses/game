using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class RandomBox : BaseScriptItemRendererView, ICommonBox
{
    private Dictionary<int, string> _numSkinRelation = new Dictionary<int, string>()
    {
        { 1, "X1" },
        { 2, "X2" },
        { 3, "X3" },
        { 4, "X4" },
    };

    private CommonItemRenderer _boxCir;
    
    private RandomBoxVo _data;

    private bool _isInit = false;

    public override object data
    {
        get { return _data; }
        set
        {
            _data = value as RandomBoxVo;
            Refresh();
        }
    }

    public override void Refresh()
    {
        base.Refresh();
        if (_data == null)
            return;
        if (_isInit)
        {
            _isInit = false;
            InitRender();
        }
        Render();
        AfterRender();
    }

    private void InitRender()
    {
        var vo = _data;
        skeletonGraphic.AnimationState.ClearTracks();
        skeletonGraphic.Skeleton.SetToSetupPose();
        if(vo.Bullets.Count != 0)
            skeletonGraphic.Skeleton.SetSkin(_numSkinRelation[vo.Bullets.Count]);
    }
    
    public void Render()
    {
        var vo = _data;
        _boxCir.data = vo.ToBoxVo();
        switch (vo.State)
        {
            case BoxState.InMatrix:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                if (vo.Row == 0)
                {
                    var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "idle", false);
                    trackEntry.TimeScale = 2f;
                }

                break;
            case BoxState.InSlot:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                rectTransform.transform.localScale = Vector3.one * 0.88f;
                break;
            case BoxState.PlaceHolder:
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                break;
            case BoxState.Move2Slot:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                break;
        }
    }

    private void AfterRender()
    {
        _data.Item = this;
    }

    //auto generate propertyDef Start, Don't Delete it!
	public CanvasGroup canvasGroup;
	public SkeletonGraphic skeletonGraphic;
	//auto generate propertyDef End, Don't Delete it!





    public RandomBox()
    {
        prefabPath = "Games/osP1/RandomBox";
    }


    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 0) as CanvasGroup;
		this.skeletonGraphic = _viewSkin.GetSingleProperty("skeletonGraphic", 1) as SkeletonGraphic;
		//auto generate propertySet End, Don't Delete it!

        
        _boxCir = new CommonItemRenderer(gameObject.transform);
        _boxCir.initCallBack += () =>
        {
            _boxCir.gameObject.transform.SetAsFirstSibling();
        };

        _isInit = true;
    }


    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!
        
        _boxCir.Dispose();

        base.Dispose();
    }

    protected override void DoClick(GameObject go)
    {
        if(GamePlay.instance.IsFreezePlayerInput)
            return;
        
        var vo = _data;
        GamePlay.instance.ChooseBox(vo.Row, vo.Col);
    }

    public CanvasGroup CanvasGroup => canvasGroup;


    
    
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
            trackEntry.Complete += entry =>
            {
                //此处由于 idle 是掀布动画，所以此处只能先切换回Setup Pose
                //skeletonGraphic.Skeleton.SetToSetupPose();
                //TODO: 此处为了提升手感，不播放死亡动画就 回掉，所以上述代码暂时被注释
            };
        };
    }

    
}

// 数据类