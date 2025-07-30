using System;
using System.Collections;
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
using UnityEngine.UI.ProceduralImage;
using Object = UnityEngine.Object;

public class BrickGenerator : BaseScriptItemRendererView, ICommonBrick
{
    private bool _isInit;

    private Dictionary<BattleColor, string> _colorSkinRelation = new Dictionary<BattleColor, string>()
    {
        { BattleColor.Yellow, "h" },
        { BattleColor.Blue, "l" },
        { BattleColor.Cyan, "q" },
        { BattleColor.Red, "r" },
        { BattleColor.Pink, "f" },
        { BattleColor.Green, "lv" },
        { BattleColor.Purple, "zi" },
        { BattleColor.Brown, "z" }
    };
    
    private Material _material;

    private BrickGeneratorVo _data;

    public override object data
    {
        get { return _data; }
        set
        {
            _data = value as BrickGeneratorVo;
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
        _material = new Material(skeletonGraphic.material);

        skeletonGraphic.material = _material;
        
        var vo = _data;
        skeletonGraphic.Skeleton.SetSkin(_colorSkinRelation[vo.Color]);
        skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
        
        if (vo.State == BrickState.Dead)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void Render()
    {
        var vo = _data;
        switch (vo.State)
        {
            case BrickState.Dead:
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                break;
            case BrickState.Live:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                textLife.text = vo.Life.ToString();
                break;
        }
    }

    private void AfterRender()
    {
        _data.Item = this;
    }

    //auto generate propertyDef Start, Don't Delete it!
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI textLife;
    public SkeletonGraphic skeletonGraphic;
    //auto generate propertyDef End, Don't Delete it!


    public BrickGenerator()
    {
        prefabPath = "Games/osP1/BrickGenerator";
    }

    public GameObject GameObject => gameObject;

    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
        this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 0) as CanvasGroup;
        this.textLife = _viewSkin.GetSingleProperty("textLife", 1) as TextMeshProUGUI;
        this.skeletonGraphic = _viewSkin.GetSingleProperty("skeletonGraphic", 2) as SkeletonGraphic;
        //auto generate propertySet End, Don't Delete it!

        _isInit = true;
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
        //auto generate propertyDis End, Don't Delete it!
        
        Object.Destroy(_material);

        base.Dispose();
    }

    public void AnimationMove(Vector3 endPos,float delay,Action callback)
    {
        if (_data.State == BrickState.Dead)
        {
            callback?.Invoke();
            return;
        }
        
        var entry = skeletonGraphic.AnimationState.SetAnimation(0, "move", false);
        entry.Delay = delay;
        entry.Event += (entry, @event) =>
        {
            if (@event.Data.Name == "move_start")
            {
                var duration = entry.AnimationEnd - entry.AnimationTime;
                gameObject.transform.DOMove(endPos, duration).SetEase(Ease.InQuint);
            }
        };
        entry.Complete += entry =>
        {
            callback?.Invoke();
            //纯动画，被打断就被打断了
            var entry1 = skeletonGraphic.AnimationState.SetAnimation(0, "move_end", false);
            entry1.Complete += entry =>
            {
                skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
                
            };
        };

    }

    

    public void AnimationDead(Action cb)
    {
        textLife.text = "";
        var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "die", false);
        
        _data.AfterDead(cb);
    }

    public void AnimationHurt()
    {
        skeletonGraphic.AnimationState.SetAnimation(0, "hurt_l", false);
        EquineScheduler.RunYieldProcedure(HurtLight());
    }

    private IEnumerator HurtLight()
    {
        skeletonGraphic.material.SetColor("_Black", new Color(0.3f, 0.3f, 0.3f));
        yield return new WaitForSeconds(0.1f);
        skeletonGraphic.material.SetColor("_Black",new Color(0f, 0f, 0f));
    }

    public void AnimAdd()
    {
        var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "add", false);
        trackEntry.Complete += entry =>
        {
            skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
        };
    }

    public void Revive()
    {
        _isInit = true;
    }
    
    protected override void DoClick(GameObject go)
    {
        base.DoClick(go);
        
        if(GamePlay.instance.IsFreezePlayerInput)
            return;
        
        if(!UseHammer.IsUsing)
            return;
        
        
        var vo = GamePlay.instance.GamePlayData.BrickVo[_data.Row][_data.Col];
        if(vo.State == BrickState.Dead)
            return;
        
        GamePlay.instance.GameItem.Hammer.DestroyBrick(vo);
    }
}

// 数据类