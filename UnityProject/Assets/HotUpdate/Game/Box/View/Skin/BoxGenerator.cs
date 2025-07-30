

using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxGenerator : BaseScriptItemRendererView,ICommonBox
{

    private Dictionary<BoxGeneratorDirection, string> _directionSkinRelation =
        new Dictionary<BoxGeneratorDirection, string>()
        {
            { BoxGeneratorDirection.left, "l" },
            { BoxGeneratorDirection.right, "r" },
            { BoxGeneratorDirection.up, "up" },
        };

    private Dictionary<BoxGeneratorDirection, string> _directionBoneRelation =
        new Dictionary<BoxGeneratorDirection, string>()
        {
            { BoxGeneratorDirection.left, "numeral2" },
            { BoxGeneratorDirection.right, "numeral2" },
            { BoxGeneratorDirection.up, "numeral" },
        };

    private bool _isInit;
    
    private BoxGeneratorVo _data;
    

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as BoxGeneratorVo;
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
        skeletonGraphic.Skeleton.SetSkin(_directionSkinRelation[vo.Direction]);
        skeletonGraphic.Skeleton.SetToSetupPose();
        boneFollower.SetBone(_directionBoneRelation[vo.Direction]);
    }

    public void Render()
    {
        var vo = _data;
        textChildCount.text = vo.ChildNumber.ToString();
        switch (vo.State)
        {
            case BoxState.InMatrix:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                break;
            case BoxState.PlaceHolder:
                canvasGroup.alpha = 0;
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
	public SkeletonGraphic skeletonGraphic;
	public CanvasGroup canvasGroup;
	public TextMeshProUGUI textChildCount;
	public BoneFollowerGraphic boneFollower;
	//auto generate propertyDef End, Don't Delete it!

    



    public BoxGenerator()
    {
        prefabPath = "Games/osP1/BoxGenerator";
    }



    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.skeletonGraphic = _viewSkin.GetSingleProperty("skeletonGraphic", 0) as SkeletonGraphic;
		this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 1) as CanvasGroup;
		this.textChildCount = _viewSkin.GetSingleProperty("textChildCount", 2) as TextMeshProUGUI;
		this.boneFollower = _viewSkin.GetSingleProperty("boneFollower", 3) as BoneFollowerGraphic;
		//auto generate propertySet End, Don't Delete it!



        _isInit = true;



    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!







        base.Dispose();
    }

    public CanvasGroup CanvasGroup => canvasGroup;
    

    

    

    public void AnimationMoveUp(Vector3 startPos,Vector3 endPos, Action callBack)
    {
        AnimationMove("move_up_end", startPos,endPos, callBack);
    }

    public void AnimationMoveLeft(Vector3 startPos,Vector3 endPos, Action callBack)
    {
        AnimationMove("", startPos,endPos, callBack);
    }

    public void AnimationMoveRight(Vector3 startPos,Vector3 endPos, Action callBack)
    {
        AnimationMove("", startPos,endPos, callBack);
    }

    private void AnimationMove(string endAnimation, Vector3 startPos, Vector3 endPos, Action callBack)
    {
        gameObject.transform.position = startPos;
        //dotween
        var tweenerCore = gameObject.transform.DOMove(endPos, BoxMatrixMoveUp.BoxMatrixMoveUpDuration);
        tweenerCore.onComplete += () =>
        {
            if (endAnimation == "")
            {
                callBack?.Invoke();
                return;
            }
            callBack?.Invoke();

            //spine
            var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, endAnimation, false);
            trackEntry.Complete += entry => { };
        };
    }

    public void AnimationDisappear(Action callBack)
    {
        var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "idle", false);
        trackEntry.MixDuration = 0f;
        trackEntry.Complete += entry =>
        {
            callBack?.Invoke();
        };
    }

    public void AnimationProduct(BoxGeneratorDirection direction)
    {
        switch (direction)
        {
            case BoxGeneratorDirection.left:
                skeletonGraphic.AnimationState.SetAnimation(0, "atk_l", false);
                break;
            case BoxGeneratorDirection.right:
                skeletonGraphic.AnimationState.SetAnimation(0, "atk_r", false);
                break;
            case BoxGeneratorDirection.up:
                skeletonGraphic.AnimationState.SetAnimation(0, "atk_up", false);
                break;
        }
    }
}

// 数据类
