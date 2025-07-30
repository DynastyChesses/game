

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class Bomb : BaseScriptItemRendererView,ICommonBrick
{
    private bool _isDisplayImg;
    private bool _isRedState;
    private int _originCountDown;
    
    private int _hitCount;
    private bool _isInit;
    
    private Material _material;

    private Dictionary<BattleColor, string> _colorSkinRelation = new Dictionary<BattleColor, string>()
    {
        { BattleColor.Yellow, "boom_h" },
        { BattleColor.Blue, "boom_l" },
        { BattleColor.Cyan, "boom_q" },
        { BattleColor.Red, "boom_r" },
        { BattleColor.Pink, "boom_f" },
        { BattleColor.Green, "boom_lv" },
        { BattleColor.Purple, "boom_zi" },
        { BattleColor.Brown, "boom_z" }
    };
    
    public Bomb()
    {
        prefabPath = "Games/osP1/Bomb";
    }
    
    private BombVo _data;

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as BombVo;
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
        skeletonGraphic.AnimationState.SetAnimation(0, "idle", true).Event += (entry, @event) =>
        {
            if(_isRedState)
                return;
            
            if (@event.Data.Name == "change")
            {
                _isDisplayImg = !_isDisplayImg;
                imgCanvasGroup.alpha = _isDisplayImg ? 1 : 0;
                textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
            }
        };

        if (vo.CountDown > 3)
        {
            _isRedState = false;
            _isDisplayImg = true;
            imgCanvasGroup.alpha = _isDisplayImg ? 1 : 0;
            textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
            textRedCanvasGroup.alpha = 0;

        }
        else
        {
            _isRedState = true;
            _isDisplayImg = true;//此处仅仅初始化，但不生效

            imgCanvasGroup.alpha = 0;
            textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
            textRedCanvasGroup.alpha = 1;
        }
        _originCountDown = vo.CountDown;

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
            case BrickState.Live:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                life.text = vo.Life.ToString();
                break;
            case BrickState.Dead:
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                break;
        }
        
        textYellowCountDown.text = ToSpriteFont(vo.CountDown);
        textRedCountDown.text = ToSpriteFont(vo.CountDown);
        imgCountDown.fillAmount = (float)vo.CountDown / (float)_originCountDown;
        
        //倒计时的图，字隐藏显示
        if (vo.CountDown > 3)
        {
            _isRedState = false;
            
            imgCanvasGroup.alpha = _isDisplayImg ? 1 : 0;
            textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
            textRedCanvasGroup.alpha = 0;

        }
        else
        {
            _isRedState = true;
            
            imgCanvasGroup.alpha = 0;
            textYellowCanvasGroup.alpha = 0;
            textRedCanvasGroup.alpha = 1;
        }

    }

    public void AfterRender()
    {
        _data.Item = this;
    }

    //auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI life;
	public CanvasGroup canvasGroup;
	public SkeletonGraphic skeletonGraphic;
	public CanvasGroup imgCanvasGroup;
	public CanvasGroup textYellowCanvasGroup;
	public CanvasGroup textRedCanvasGroup;
	public TextMeshProUGUI textYellowCountDown;
	public TextMeshProUGUI textRedCountDown;
	public Image imgCountDown;
	//auto generate propertyDef End, Don't Delete it!










    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.life = _viewSkin.GetSingleProperty("life", 0) as TextMeshProUGUI;
		this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 1) as CanvasGroup;
		this.skeletonGraphic = _viewSkin.GetSingleProperty("skeletonGraphic", 2) as SkeletonGraphic;
		this.imgCanvasGroup = _viewSkin.GetSingleProperty("imgCanvasGroup", 3) as CanvasGroup;
		this.textYellowCanvasGroup = _viewSkin.GetSingleProperty("textYellowCanvasGroup", 4) as CanvasGroup;
		this.textRedCanvasGroup = _viewSkin.GetSingleProperty("textRedCanvasGroup", 5) as CanvasGroup;
		this.textYellowCountDown = _viewSkin.GetSingleProperty("textYellowCountDown", 6) as TextMeshProUGUI;
		this.textRedCountDown = _viewSkin.GetSingleProperty("textRedCountDown", 7) as TextMeshProUGUI;
		this.imgCountDown = _viewSkin.GetSingleProperty("imgCountDown", 8) as Image;
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
                var entry2 = skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
                entry2.Event += (entry, @event) =>
                {
                    if(_isRedState)
                        return;
            
                    if (@event.Data.Name == "change")
                    {
                        _isDisplayImg = !_isDisplayImg;
                        imgCanvasGroup.alpha = _isDisplayImg ? 1 : 0;
                        textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
                    }
                };
            };
        };
    }

    public void AnimationDead(Action cb)
    {
        life.text = "";
        textRedCountDown.text = "";
        textYellowCountDown.text = "";
        var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "die02", false);
        trackEntry.MixDuration = 0f;
        trackEntry.Complete += entry => cb?.Invoke();
    }

    public void AnimationHurt()
    {
        _hitCount++;
        var animationName = _hitCount % 2 == 0 ? "hurt_l" : "hurt_r";
        skeletonGraphic.AnimationState.SetAnimation(0, animationName, false);
        skeletonGraphic.AnimationState.AddAnimation(0,"idle", true,0f).Event += (entry, @event) =>
        {
            if(_isRedState)
                return;
            
            if (@event.Data.Name == "change")
            {
                _isDisplayImg = !_isDisplayImg;
                imgCanvasGroup.alpha = _isDisplayImg ? 1 : 0;
                textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
            }
        };
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
        //目前炸弹没有add动画
        skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
        
        // var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "add", false);
        // trackEntry.Complete += entry =>
        // {
        //     skeletonGraphic.AnimationState.SetAnimation(0, "idle", true);
        // };

    }

    public void Revive()
    {
        _isInit = true;
    }

    public void AnimationBoom(Action callback)
    {
        skeletonGraphic.AnimationState.SetAnimation(0, "die", false);
        skeletonGraphic.AnimationState.AddAnimation(0,"idle", true,0f).Event += (entry, @event) =>
        {
            if(_isRedState)
                return;
            
            if (@event.Data.Name == "change")
            {
                _isDisplayImg = !_isDisplayImg;
                imgCanvasGroup.alpha = _isDisplayImg ? 1 : 0;
                textYellowCanvasGroup.alpha = _isDisplayImg ? 0 : 1;
            }
        };
        callback?.Invoke();
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
    
    private string ToSpriteFont(int number)
    {
        var sb = new StringBuilder();
        foreach (var numChar in number.ToString())
        {
            sb.Append($"<sprite={numChar}>");
        }

        return sb.ToString();
    }
}

// 数据类
