using System;
using DG.Tweening;
using UnityEngine;

public class AnimatorPopupAnimation : BasePopupAnimation
{
	public enum AnimType
	{
		ExpandInShrinkOut,
		ExpandInExpandOut,
		ShrinkInShrinkOut,
		ShrinkInExpandOut
	}
    public Animator animator = null;
    public Vector3 offset;
    public AnimType animType;
    private BaseGamePopupView popupView;
    public CanvasGroup group = null;
	//
	
	public Animator Window;
	public Animator Bot;
	private bool isFirst = true;
	private int onceInterval = EquineScheduler.INVALID;
    public AnimatorPopupAnimation(IPopupView popupView, float duration = 0, PopupAnimationType aniType = PopupAnimationType.OpenOnly) : base(popupView, aniType, duration)
    {
	    isFirst = true;
	    animType = AnimType.ExpandInShrinkOut;
	    popupView = (BaseGamePopupView)popupView;
	    
    }

    private void Run()
    {
	    Bot.transform.localScale = Vector3.one;
	    if (group != null)
	    {
		    group.alpha = 1f;
	    }
	    Window.Play("HeroListPanel", -1, 0f);
	    Window.Update(0);
	    Bot.Play("HeroListPanel", -1, 0f);
	    Bot.Update(0);
    }
    
    public override void StartAnimation(Action<PopupParam> completeCallback, float duration, PopupParam context = null, bool reverse = false)
    {
	    // 
        StopAnimation();
        if (Window != null && Bot != null)
        {
	        if (isFirst)
	        {
		        isFirst = false;
		        if (group != null)
		        {
			        group.alpha = 0f;
		        }
		        Bot.transform.localScale = Vector3.zero;
		        onceInterval = EquineScheduler.CallOnceFrame(3, (i, u, p) =>
		        {
			        onceInterval = EquineScheduler.INVALID;
			        Run();
		        });
	        }
	        else
	        {
		        Run();
	        }
	        
        }
        base.StartAnimation(completeCallback, duration, context, reverse);
    }

    protected override void AnimationEnds(int updator, object args, UpdateTimeInfo info)
	{
		base.AnimationEnds(updator, args, info);
	}

	public override void StopAnimation()
	{
		base.StopAnimation();
		if (onceInterval != EquineScheduler.INVALID)
		{
			EquineScheduler.RemoveLimitUpdator(ref onceInterval);
			onceInterval = EquineScheduler.INVALID;
		}
	}
}