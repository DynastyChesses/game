

using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using HotUpdate.osP1.Enum;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackableBullet : BaseScriptItemRendererView
{
    
    private static readonly Dictionary<BattleColor,string> Relation = new Dictionary<BattleColor, string>()
    {
        { BattleColor.Yellow, "黄色" },
        { BattleColor.Blue, "蓝色" },
        { BattleColor.Cyan, "青色" },
        { BattleColor.Red, "红色" },
        { BattleColor.Pink, "粉色" },
        { BattleColor.Green, "绿色" },
        { BattleColor.Purple, "紫色" },
        { BattleColor.Brown, "棕色" }
    };

    private StackableBulletVo _data;

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as StackableBulletVo;
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
        
        switch (vo.State)
        {
            case StackableBulletState.InPanel:
            case StackableBulletState.InBarrel:
                gameObject.SetActive(true);
                if(vo.Number == 1)
                    life.text = String.Empty;
                else
                    life.text = vo.Number.ToString();

                if (!vo.IsFeverStackableBullet)
                {
                    skelBall.Skeleton.SetSkin(Relation[vo.Color]);
                    skelBall.AnimationState.SetAnimation(0, "normal", true);

                }
                else
                {
                    skelBall.Skeleton.SetSkin("caise");
                    skelBall.AnimationState.SetAnimation(0, "caise_happy", true);
                }
                break;
            case StackableBulletState.Move2Slot:
                gameObject.SetActive(true);
                if(vo.Number == 1)
                    life.text = String.Empty;
                else
                    life.text = vo.Number.ToString();
                if(!vo.IsFeverStackableBullet)
                    skelBall.Skeleton.SetSkin(Relation[vo.Color]);
                else
                    skelBall.Skeleton.SetSkin("caise");
                skelBall.AnimationState.SetAnimation(0, "move_panzi", true);
                break;
            case StackableBulletState.Empty:
                gameObject.SetActive(false);
                break;
        }
    }
    
    public void AfterRender()
    {
        var vo = _data;
        vo.Item = this;
    }

    //auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI life;
	public SkeletonGraphic skelBall;
	//auto generate propertyDef End, Don't Delete it!



    public StackableBullet()
    {
        prefabPath = "Games/osP1/StackableBullet";
    }


    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.life = _viewSkin.GetSingleProperty("life", 0) as TextMeshProUGUI;
		this.skelBall = _viewSkin.GetSingleProperty("skelBall", 1) as SkeletonGraphic;
		//auto generate propertySet End, Don't Delete it!
        
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!

        
        base.Dispose();
    }

    
}

// 数据类
