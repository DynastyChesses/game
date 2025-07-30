using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using UnityEngine;

public class Capybara : BaseScriptItemRendererView
{
    private bool _isInit;
    private int _updatorId;

    private CapybaraVo _data;

    private CapybaraAction _action;

    private float _currentSleepyTime;
    private float _endSleepyTime = 3f;

    private float _currentAttackTime;
    private float _endAttackTime = 2.5f;

    public Capybara()
    {
        prefabPath = "Games/osP1/Capybara";
    }

    public override object data
    {
        get { return _data; }
        set
        {
            _data = value as CapybaraVo;
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
        skel.enabled = true;
        skelEx.enabled = false;
    }

    public void Render()
    {
        switch (_data.CapybaraAction)
        {
            case CapybaraAction.AttackLowForm:
                AnimAttackLowForm();
                break;
            case CapybaraAction.AttackHighForm:
                AnimAttackHighForm();
                break;
            case CapybaraAction.ChangeToHighForm:
                ChangeToHighForm();
                break;
            case CapybaraAction.ChangeToLowForm:
                ChangeToLowForm();
                break;
            case CapybaraAction.IdleLowForm:
                AnimIdleLowForm();
                break;
            default:
                Debug.LogError($"未实现的 CapybaraAction: {_data.CapybaraAction}");
                break;
        }
    }

    //auto generate propertyDef Start, Don't Delete it!
    public SkeletonGraphic skel;
    public SkeletonGraphic skelEx;
    //auto generate propertyDef End, Don't Delete it!


    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
        this.skel = _viewSkin.GetSingleProperty("skel", 0) as SkeletonGraphic;
        this.skelEx = _viewSkin.GetSingleProperty("skelEx", 1) as SkeletonGraphic;
        //auto generate propertySet End, Don't Delete it!

        _isInit = true;
        _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
        //auto generate propertyDis End, Don't Delete it!
        EquineScheduler.RemoveLimitUpdator(ref _updatorId);

        base.Dispose();
    }

    private void OnUpdate(int a, object b, UpdateTimeInfo time)
    {
        UpdateSleepy(time);
        UpdateAttackHighForm(time);
    }

    private void UpdateSleepy(UpdateTimeInfo time)
    {
        if (_action != CapybaraAction.IdleLowForm)
            return;

        if (_action == CapybaraAction.Sleepy)
            return;

        _currentSleepyTime += time.deltaTime;
        if (_currentSleepyTime >= _endSleepyTime)
        {
            AnimSleepy(AnimIdleLowForm);
        }
    }

    private void UpdateAttackHighForm(UpdateTimeInfo time)
    {
        if (!skelEx.enabled)
            return;

        if (_action == CapybaraAction.IdleHighForm)
            return;

        _currentAttackTime += time.deltaTime;
        if (_currentAttackTime >= _endAttackTime)
        {
            AnimIdleHighForm();
        }
    }

    private void AnimIdleLowForm()
    {
        if (_action == CapybaraAction.ChangeToHighForm || _action == CapybaraAction.ChangeToLowForm)
            return;

        _action = CapybaraAction.IdleLowForm;
        skel.AnimationState.SetAnimation(0, "idle", true);
        _currentSleepyTime = 0;
    }

    private void AnimIdleHighForm()
    {
        if (_action == CapybaraAction.ChangeToHighForm || _action == CapybaraAction.ChangeToLowForm)
            return;

        _action = CapybaraAction.IdleHighForm;
        skelEx.AnimationState.SetAnimation(0, "idle", true);
        _currentAttackTime = 0f;
    }

    private void AnimSleepy(Action callback)
    {
        if (!skel.enabled)
            return;

        if (_action == CapybaraAction.ChangeToHighForm || _action == CapybaraAction.ChangeToLowForm)
            return;

        _action = CapybaraAction.Sleepy;
        var entry = skel.AnimationState.SetAnimation(0, "keshui", false);
        entry.Complete += entry1 => callback?.Invoke();
    }

    private void AnimAttackLowForm()
    {
        if (!skel.enabled)
            return;

        if (_action == CapybaraAction.ChangeToHighForm || _action == CapybaraAction.ChangeToLowForm)
            return;

        _action = CapybaraAction.AttackLowForm;
        var entry = skel.AnimationState.SetAnimation(0, "attack", false);
        entry.MixDuration = 0f;
        entry.Complete += entry1 => AnimIdleLowForm();
    }

    private void AnimAttackHighForm()
    {
        if (!skelEx.enabled)
            return;

        if (_action == CapybaraAction.ChangeToHighForm || _action == CapybaraAction.ChangeToLowForm)
            return;

        var anim = skelEx.AnimationState.Tracks.Items[0].Animation.Name;
        if (anim != "attack")
        {
            _action = CapybaraAction.AttackHighForm;
            skelEx.AnimationState.SetAnimation(0, "attack_ing", true);
        }
        else
        {
            _currentAttackTime = 0f;
        }
    }


    private void ChangeToHighForm()
    {
        _action = CapybaraAction.ChangeToHighForm;

        var entry = skel.AnimationState.SetAnimation(0, "out", false);
        entry.Complete += entry1 =>
        {
            skel.enabled = false;
            skelEx.enabled = true;
            var entry2 = skelEx.AnimationState.SetAnimation(0, "add", false);
            entry2.Complete += entry3 =>
            {
                _action = CapybaraAction.IdleHighForm;
                AnimIdleHighForm();
            };
        };
    }

    private void ChangeToLowForm()
    {
        _action = CapybaraAction.ChangeToLowForm;

        var entry = skelEx.AnimationState.SetAnimation(0, "die", false);
        entry.MixDuration = 0f;
        entry.Complete += entry1 =>
        {
            skel.enabled = true;
            skelEx.enabled = false;
            var entry2 = skel.AnimationState.SetAnimation(0,"in", false);
            entry2.Complete += entry3 =>
            {
                _action = CapybaraAction.IdleLowForm;
                AnimIdleLowForm();
            };
        };
    }
}

// 数据类