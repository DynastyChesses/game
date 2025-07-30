

using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using UnityEngine;

public class GoldBox : BaseScriptItemRendererView,ICommonBox
{


    public GoldBox()
    {
        prefabPath = "Games/osP1/GoldBox";
    }

    private bool _isInit;
    
    private GoldBoxVo _data;

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as GoldBoxVo;
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
    }

    private void InitRender()
    {
        skelGold.enabled = true;
        skelStamp.enabled = false;
    }

    public void Render()
    {
        switch (_data.State)
        {
            case BoxState.InMatrix:
                var entry = skelGold.AnimationState.SetAnimation(0, "coin_add", false);
                entry.Complete += entry =>
                {
                    skelGold.enabled = false;
                    skelStamp.enabled = true;
                    var entry1 = skelStamp.AnimationState.SetAnimation(0, "passed_down", false);
                    entry1.Complete += entry1 =>
                    {
                        skelStamp.AnimationState.SetAnimation(0, "passed_normal", true);
                    
                    };
                };
                break;
            case BoxState.PlaceHolder:
                skelGold.enabled = false;
                skelStamp.enabled = true;
                skelStamp.AnimationState.SetAnimation(0, "passed_normal", true);
                break;
        }
        
    }

    //auto generate propertyDef Start, Don't Delete it!
	public SkeletonGraphic skelStamp;
	public SkeletonGraphic skelGold;
	//auto generate propertyDef End, Don't Delete it!




    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.skelStamp = _viewSkin.GetSingleProperty("skelStamp", 0) as SkeletonGraphic;
		this.skelGold = _viewSkin.GetSingleProperty("skelGold", 1) as SkeletonGraphic;
		//auto generate propertySet End, Don't Delete it!

        
        _isInit = true;
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!

        
        
        
        base.Dispose();
    }

    public CanvasGroup CanvasGroup { get; }
   
    public void AnimationMoveUp(Vector3 startPos, Vector3 endPos, Action callBack)
    {
        var tweenerCore = gameObject.transform.DOMove(endPos, BoxMatrixMoveUp.BoxMatrixMoveUpDuration);
        tweenerCore.onComplete += () => callBack?.Invoke();
    }

    public void AnimationMoveLeft(Vector3 startPos, Vector3 endPos, Action callBack)
    {
        throw new NotImplementedException();
    }

    public void AnimationMoveRight(Vector3 startPos, Vector3 endPos, Action callBack)
    {
        throw new NotImplementedException();
    }
}

// 数据类
