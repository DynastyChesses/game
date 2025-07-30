

using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class Bullet : BaseScriptItemRendererView
{
    private const float StartAnimScale = 2f;
    
    private BulletVo _data;
    
    private static readonly Dictionary<BattleColor, string> Relation = new Dictionary<BattleColor, string>
    {
        { BattleColor.Yellow, "ball_huang" },
        { BattleColor.Blue, "ball_lan" },
        { BattleColor.Cyan, "ball_qing" },
        { BattleColor.Red, "ball_hong" },
        { BattleColor.Pink, "ball_fen" },
        { BattleColor.Green, "ball_lv" },
        { BattleColor.Purple, "ball_zi" },
        { BattleColor.Brown, "ball_zong" }
    };

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as BulletVo;
            Refresh();
        }
    }

    public Bullet()
    {
        prefabPath = "Games/osP1/Bullet";
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

        var startPos = GamePlay.instance.UI.firePoint.position;
        var deltaVector = (vo.TargetPos - startPos).normalized;
        var forwardVector = new Vector3(0f, 1f, 0f);
        
        var angle = Vector3.SignedAngle(forwardVector, deltaVector, new Vector3(0f, 0f, 1f));
        this.gameObject.transform.eulerAngles = new Vector3(0f,0f,angle);
        if(!vo.IsFeverBullet)
            skelBullet.Skeleton.SetSkin(Relation[vo.Color]);
        else
            skelBullet.Skeleton.SetSkin("ball_hua");
            
        
    }

    public void AfterRender()
    {
        var vo = _data;
        vo.Item = this;
    }
    
    //auto generate propertyDef Start, Don't Delete it!
	public SkeletonGraphic skelBullet;
	//auto generate propertyDef End, Don't Delete it!

    
    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.skelBullet = _viewSkin.GetSingleProperty("skelBullet", 0) as SkeletonGraphic;
		//auto generate propertySet End, Don't Delete it!
        
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!
        
        base.Dispose();
    }

    public void AnimMove(Vector3 startPos,Vector3 endPos,CommonItemRenderer cir,Action callback = null)
    {
        //spine
        skelBullet.AnimationState.SetAnimation(0, "start", false);
        skelBullet.AnimationState.AddAnimation(0, "fly", true,0f);
        
        //dotween
        gameObject.transform.position = startPos;
        var duration = Vector3.Distance(startPos, endPos) / FireBullet.BulletFireSpeed;
        gameObject.transform.DOMove(endPos, duration).SetEase(Ease.Linear).onComplete += () =>
        {
            //spine
            var trackEntry = skelBullet.AnimationState.SetAnimation(0, "end", false);
            trackEntry.Complete += entry =>
            {
                cir.Dispose();
            };
            callback?.Invoke();
        };
    }
}

// 数据类
