using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using HotUpdate.osP1.ValueObject.Interface;
using Spine;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;
using AnimationState = Spine.AnimationState;
using Object = UnityEngine.Object;

public enum BrickForm
{
    Low,
    Medium,
    High,
}


public class Brick : BaseScriptItemRendererView, ICommonBrick
{
    private int _hitCount;
    private bool _isInit = false;


    private BrickVo _data;

    private BrickForm _form;


    private int _lowFormMaxLife = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["low_form_max_hp"].Value);
    private int _mediumFormMaxLife = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["medium_form_max_hp"].Value);


    private static Material _lowOrigin;
    private static Material _mediumOrigin;
    private static Material _highOrigin;

    private static readonly Dictionary<BattleColor, string> SkinRelation = new Dictionary<BattleColor, string>()
    {
        { BattleColor.Yellow, "brick_huang" },
        { BattleColor.Blue, "brick_lan" },
        { BattleColor.Cyan, "brick_qing" },
        { BattleColor.Red, "brick_hong" },
        { BattleColor.Pink, "brick_fen" },
        { BattleColor.Green, "brick_lv" },
        { BattleColor.Purple, "brick_zi" },
        { BattleColor.Brown, "brick_zong" }
    };


    public override object data
    {
        get { return _data; }
        set
        {
            _data = value as BrickVo;
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
        _highOrigin ??= skelHigh.material;
        _mediumOrigin ??= skelMedium.material;
        _lowOrigin ??= skelLow.material;

        skelHigh.material = new Material(_highOrigin);
        skelMedium.material = new Material(_mediumOrigin);
        skelLow.material = new Material(_lowOrigin);

        skelHigh.gameObject.SetActive(false);
        skelMedium.gameObject.SetActive(false);
        skelLow.gameObject.SetActive(false);

        var vo = _data;
        if (vo.State != BrickState.Dead)
        {
            if (vo.Life > _mediumFormMaxLife)
            {
                skelHigh.gameObject.SetActive(true);
                skelMedium.gameObject.SetActive(false);
                skelLow.gameObject.SetActive(false);

                skelHigh.Skeleton.SetSkin(SkinRelation[vo.Color]);
                skelHigh.AnimationState.SetAnimation(0, "idle", true);
                _form = BrickForm.High;

                boneFollower.skeletonGraphic = skelHigh;
                boneFollower.SetBone("numeral");
            }
            else if (vo.Life > _lowFormMaxLife)
            {
                skelHigh.gameObject.SetActive(false);
                skelMedium.gameObject.SetActive(true);
                skelLow.gameObject.SetActive(false);

                skelMedium.Skeleton.SetSkin(SkinRelation[vo.Color]);
                skelMedium.AnimationState.SetAnimation(0, "idle", true);
                _form = BrickForm.Medium;

                boneFollower.skeletonGraphic = skelMedium;
                boneFollower.SetBone("numeral");
            }
            else if (vo.Life > 0)
            {
                skelHigh.gameObject.SetActive(false);
                skelMedium.gameObject.SetActive(false);
                skelLow.gameObject.SetActive(true);

                skelLow.Skeleton.SetSkin(SkinRelation[vo.Color]);
                skelLow.AnimationState.SetAnimation(0, "idle", true);
                _form = BrickForm.Low;

                boneFollower.skeletonGraphic = skelLow;
                boneFollower.SetBone("numeral");
            }
            else
            {
                Debug.LogError("brick life lq 0");
            }
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            life.text = "";
            skelHigh.gameObject.SetActive(false);
            skelMedium.gameObject.SetActive(false);
            skelLow.gameObject.SetActive(false);
        }
    }

    public void Render()
    {
        var vo = _data;
        switch (_data.State)
        {
            case BrickState.Dead:
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                break;
            case BrickState.Live:
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                life.text = vo.Life.ToString();
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
    public CanvasGroup canvasGroup;
    public SkeletonGraphic skelLow;
    public SkeletonGraphic skelMedium;
    public SkeletonGraphic skelHigh;
    public BoneFollowerGraphic boneFollower;
    //auto generate propertyDef End, Don't Delete it!

    public void SetInit()
    {
        _isInit = true;
    }

    public void AnimationDead(Action cb)
    {
        AnimationDeadInner(_form, () => cb?.Invoke());
    }

    public void AnimationHurt()
    {
        //TODO: disable mix
        _hitCount++;

        switch (_form)
        {
            case BrickForm.Low:
                var animationName = _hitCount % 2 == 0 ? "hurt_l" : "hurt_r";
                skelLow.AnimationState.SetAnimation(0, animationName, false);
                skelLow.AnimationState.AddAnimation(0, "idle", true, 0f);
                EquineScheduler.RunYieldProcedure(HurtLight(BrickForm.Low));
                break;
            case BrickForm.Medium:
                animationName = _hitCount % 2 == 0 ? "hurt_l" : "hurt_r";
                if (_data.Life == _lowFormMaxLife) //当前生命等于该值时，会切换形态，注意此时已经扣完血
                {
                    //AudioFacade.instance.PlayClip("Sound_Trans",false);
                    skelMedium.AnimationState.SetAnimation(0, "die", false).Complete += entry =>
                    {
                        skelMedium.gameObject.SetActive(false);
                    };
                    skelLow.gameObject.SetActive(true);
                    skelLow.Skeleton.SetSkin(SkinRelation[_data.Color]);
                    skelLow.AnimationState.SetAnimation(0, animationName, false);
                    skelLow.AnimationState.AddAnimation(0, "idle", true, 0f);
                    _form = BrickForm.Low;

                    boneFollower.skeletonGraphic = skelLow;
                    boneFollower.SetBone("numeral");
                }
                else
                {
                    animationName = _hitCount % 2 == 0 ? "hurt_l" : "hurt_r";
                    skelMedium.AnimationState.SetAnimation(0, animationName, false);
                    skelMedium.AnimationState.AddAnimation(0, "idle", true, 0f);
                }

                EquineScheduler.RunYieldProcedure(HurtLight(BrickForm.Medium));
                break;
            case BrickForm.High:
                animationName = _hitCount % 2 == 0 ? "hurt_l" : "hurt_r";
                if (_data.Life == _mediumFormMaxLife) //当前生命等于该值时，会切换形态，注意此时还未扣血
                {
                    //AudioFacade.instance.PlayClip("Sound_Trans",false);
                    skelHigh.AnimationState.SetAnimation(0, "die", false).Complete += entry =>
                    {
                        skelHigh.gameObject.SetActive(false);
                    };
                    skelMedium.gameObject.SetActive(true);
                    skelMedium.Skeleton.SetSkin(SkinRelation[_data.Color]);
                    skelMedium.AnimationState.SetAnimation(0, animationName, false);
                    skelMedium.AnimationState.AddAnimation(0, "idle", true, 0f);
                    _form = BrickForm.Medium;

                    boneFollower.skeletonGraphic = skelMedium;
                    boneFollower.SetBone("numeral");
                }
                else
                {
                    skelHigh.AnimationState.SetAnimation(0, animationName, false);
                    skelHigh.AnimationState.AddAnimation(0, "idle", true, 0f);
                }

                EquineScheduler.RunYieldProcedure(HurtLight(BrickForm.High));
                break;
        }
    }

    private IEnumerator HurtLight(BrickForm form)
    {
        switch (form)
        {
            case BrickForm.Low:
                skelLow.material.SetColor("_Black", new Color(0.3f, 0.3f, 0.3f));
                break;
            case BrickForm.Medium:
                skelMedium.material.SetColor("_Black", new Color(0.3f, 0.3f, 0.3f));
                break;
            case BrickForm.High:
                skelHigh.material.SetColor("_Black", new Color(0.3f, 0.3f, 0.3f));
                break;
        }

        yield return new WaitForSeconds(0.1f);
        switch (form)
        {
            case BrickForm.Low:
                skelLow.material.SetColor("_Black", new Color(0f, 0f, 0f));
                break;
            case BrickForm.Medium:
                skelMedium.material.SetColor("_Black", new Color(0f, 0f, 0f));
                break;
            case BrickForm.High:
                skelHigh.material.SetColor("_Black", new Color(0f, 0f, 0f));
                break;
        }
    }

    public void AnimationMove(Vector3 endPos, float delay, Action callback)
    {
        if (_data.State == BrickState.Dead)
        {
            callback?.Invoke();
            return;
        }

        AnimationState.TrackEntryEventDelegate lambda = (entry, @event) =>
        {
            if (@event.Data.Name == "move_start")
            {
                var duration = entry.AnimationEnd - entry.AnimationTime;
                gameObject.transform.DOMove(endPos, duration).SetEase(Ease.InQuint);
            }
        };

        switch (_form)
        {
            case BrickForm.Low:
                var entry = skelLow.AnimationState.SetAnimation(0, "move", false);
                entry.Delay = delay;
                entry.Event += lambda;
                entry.Complete += entry =>
                {
                    callback?.Invoke();
                    //纯动画，被打断就被打断了
                    var entry1 = skelLow.AnimationState.SetAnimation(0, "move_end", false);
                    entry1.Complete += entry => { skelLow.AnimationState.SetAnimation(0, "idle", true); };
                };
                break;
            case BrickForm.Medium:
                entry = skelMedium.AnimationState.SetAnimation(0, "move", false);
                entry.Delay = delay;
                entry.Event += lambda;
                entry.Complete += entry =>
                {
                    callback?.Invoke();
                    //纯动画，被打断就被打断了
                    var entry1 = skelMedium.AnimationState.SetAnimation(0, "move_end", false);
                    entry1.Complete += entry => { skelMedium.AnimationState.SetAnimation(0, "idle", true); };
                };
                break;
            case BrickForm.High:
                entry = skelHigh.AnimationState.SetAnimation(0, "move", false);
                entry.Delay = delay;
                entry.Event += lambda;
                entry.Complete += entry =>
                {
                    callback?.Invoke();
                    //纯动画，被打断就被打断了
                    var entry1 = skelHigh.AnimationState.SetAnimation(0, "move_end", false);
                    entry1.Complete += entry => { skelHigh.AnimationState.SetAnimation(0, "idle", true); };
                };
                break;
        }
    }


    public void AnimationDeadInner(BrickForm form, Action cb = null)
    {
        life.text = "";
        EquineScheduler.RunYieldProcedure(HurtLight(form));


        switch (form)
        {
            case BrickForm.Low:
                var trackEntry = skelLow.AnimationState.SetAnimation(0, "die", false);
                trackEntry.MixDuration = 0f;
                trackEntry.Complete += entry => cb?.Invoke();
                break;
            case BrickForm.Medium:
                trackEntry = skelMedium.AnimationState.SetAnimation(0, "die", false);
                trackEntry.MixDuration = 0f;
                trackEntry.Complete += entry => cb?.Invoke();
                break;
            case BrickForm.High:
                trackEntry = skelHigh.AnimationState.SetAnimation(0, "die", false);
                trackEntry.MixDuration = 0f;
                trackEntry.Complete += entry => cb?.Invoke();
                break;
        }
    }

    public void AnimAdd()
    {
        TrackEntry trackEntry;
        switch (_form)
        {
            case BrickForm.Low:
               trackEntry = skelLow.AnimationState.SetAnimation(0, "add", false);
               trackEntry.Complete += entry =>
               {
                   skelLow.AnimationState.SetAnimation(0, "idle", true);
               };
                break;
            case BrickForm.Medium:
                trackEntry = skelMedium.AnimationState.SetAnimation(0, "add", false);
                trackEntry.Complete += entry =>
                {
                    skelMedium.AnimationState.SetAnimation(0, "idle", true);
                };
                break;
            case BrickForm.High:
                trackEntry = skelHigh.AnimationState.SetAnimation(0, "add", false);
                trackEntry.Complete += entry =>
                {
                    skelHigh.AnimationState.SetAnimation(0, "idle", true);
                };
                break;
        }
    }

    public void Revive()
    {
        _isInit = true;
        skelHigh.gameObject.SetActive(false);
        skelMedium.gameObject.SetActive(false);
        skelLow.gameObject.SetActive(false);
    }


    public Brick()
    {
        prefabPath = "Games/osP1/Brick";
    }

    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
        this.life = _viewSkin.GetSingleProperty("life", 0) as TextMeshProUGUI;
        this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 1) as CanvasGroup;
        this.skelLow = _viewSkin.GetSingleProperty("skelLow", 2) as SkeletonGraphic;
        this.skelMedium = _viewSkin.GetSingleProperty("skelMedium", 3) as SkeletonGraphic;
        this.skelHigh = _viewSkin.GetSingleProperty("skelHigh", 4) as SkeletonGraphic;
        this.boneFollower = _viewSkin.GetSingleProperty("boneFollower", 5) as BoneFollowerGraphic;
        //auto generate propertySet End, Don't Delete it!


        _lowFormMaxLife = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["low_form_max_hp"].Value);
        _mediumFormMaxLife = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["medium_form_max_hp"].Value);

        _isInit = true;
    }

    protected override void DoClick(GameObject go)
    {
        base.DoClick(go);
        
        if(GamePlay.instance.IsFreezePlayerInput)
            return;

        if (!UseHammer.IsUsing)
            return;
        
        
        var vo = GamePlay.instance.GamePlayData.BrickVo[_data.Row][_data.Col];
        if(vo.State == BrickState.Dead)
            return;
        
        GamePlay.instance.GameItem.Hammer.DestroyBrick(vo);
    }


    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
        //auto generate propertyDis End, Don't Delete it!


        base.Dispose();
    }
}

// 数据类