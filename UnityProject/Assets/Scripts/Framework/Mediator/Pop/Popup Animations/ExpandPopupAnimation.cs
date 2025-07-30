using System;
using DG.Tweening;
using UnityEngine;

public class ExpandPopupAnimation : BasePopupAnimation
{
    public enum AnimType
    {
        ExpandInShrinkOut,
        ExpandInExpandOut,
        ShrinkInShrinkOut,
        ShrinkInExpandOut
    }

    private const float DEFAULT_DURATION = 0.1f;
    private const float ORIGIN_ALPHA = 0.3f;
    private const float EXPAND_IN_ORIGIN_SCALE = 0.5f;
	private const float SHRINK_IN_ORIGIN_SCALE = 2.5f;

    private Tweener _tweenScale;
    private Tweener _tweenPosition;
    //	private TweenAlpha _tweenAlpha;
    private IPopupView _targetView;

    public AnimType animType;
    public Vector3 offset;

    public ExpandPopupAnimation (IPopupView popupView, float duration = DEFAULT_DURATION, PopupAnimationType aniType = PopupAnimationType.OpenOnly) : base(popupView, aniType, duration)
	{
        animType = AnimType.ExpandInShrinkOut;
        offset = Vector3.zero;
        _targetView = popupView;
    }

    private Vector3 GetPosition()
    {
        return this._targetView.localPosition;
    }

    private void SetPosition(Vector3 value)
    {
        this._targetView.localPosition = value;
    }

    private Vector3 GetScale()
    {
        return this._targetView.localScale;
    }

    private void SetScale(Vector3 value)
    {
        this._targetView.localScale = value;
    }

    public override void StartAnimation(Action<PopupParam> completeCallback, float duration, PopupParam context = null, bool reverse = false)
    {
        StopAnimation(); 
        base.StartAnimation (completeCallback, duration, context, reverse);
        if (!reverse)
        {
//            popupView.mainPanel.alpha = ORIGIN_ALPHA;
//            _tweenAlpha = TweenAlpha.Begin(popupView.gameObject, duration, 1f);
//            _tweenAlpha.method = UITweener.Method.EaseInOut;

            switch(animType)
            {
                case AnimType.ShrinkInExpandOut:
                case AnimType.ShrinkInShrinkOut:
                    this._targetView.localScale = Vector3.one * SHRINK_IN_ORIGIN_SCALE;
                    break;
                case AnimType.ExpandInShrinkOut:
                case AnimType.ExpandInExpandOut:
                default:
                    this._targetView.localScale = Vector3.one * EXPAND_IN_ORIGIN_SCALE;
                    break;
            }
            _tweenScale = DOTween.To(this.GetScale, this.SetScale, Vector3.one, duration);// TweenScale.Begin(popupView.gameObject, duration, Vector3.one);
            _tweenScale.SetEase(Ease.OutBack);

            if(offset != Vector3.zero)
            {
                switch(animType)
                {
                    case AnimType.ShrinkInExpandOut:
                    case AnimType.ShrinkInShrinkOut:
                        this._targetView.localPosition = offset * SHRINK_IN_ORIGIN_SCALE;
                        break;
                    case AnimType.ExpandInShrinkOut:
                    case AnimType.ExpandInExpandOut:
                    default:
                        this._targetView.localPosition = offset * EXPAND_IN_ORIGIN_SCALE;
                        break;
                }
                _tweenPosition = DOTween.To(this.GetPosition, this.SetPosition, Vector3.zero, duration);//TweenPosition.Begin(popupView.gameObject, duration, Vector3.zero);
                _tweenPosition.SetEase(Ease.InOutSine);
            }
        }
        else
        {
            this._targetView.localScale = Vector3.one;

            switch(animType)
            {
                case AnimType.ExpandInShrinkOut:
                case AnimType.ShrinkInShrinkOut:
                    _tweenScale = DOTween.To(this.GetScale, this.SetScale, Vector3.one * 0.1f, duration);// TweenScale.Begin(popupView.gameObject, duration, Vector3.one * 0.1f);
                    break;
                case AnimType.ExpandInExpandOut:
                case AnimType.ShrinkInExpandOut:
                default:
                    _tweenScale = DOTween.To(this.GetScale, this.SetScale, Vector3.one * SHRINK_IN_ORIGIN_SCALE, duration);//TweenScale.Begin(popupView.gameObject, duration, Vector3.one * SHRINK_IN_ORIGIN_SCALE);
                    break;
            }
            _tweenScale.SetEase(Ease.InSine);

            if(offset != Vector3.zero)
            {
                this._targetView.localPosition = Vector3.zero;
                switch(animType)
                {
                    case AnimType.ExpandInShrinkOut:
                    case AnimType.ShrinkInShrinkOut:
                        _tweenPosition = DOTween.To(this.GetPosition, this.SetPosition, offset, duration); //TweenPosition.Begin(popupView.gameObject, duration, offset);
                        break;
                    case AnimType.ExpandInExpandOut:
                    case AnimType.ShrinkInExpandOut:
                    default:
                        _tweenPosition = DOTween.To(this.GetPosition, this.SetPosition, offset * SHRINK_IN_ORIGIN_SCALE, duration); //TweenPosition.Begin(popupView.gameObject, duration, offset * SHRINK_IN_ORIGIN_SCALE);
                        break;
                }
                _tweenScale.SetEase(Ease.InSine);
            }
        }

        if (_tweenScale != null)
        {
            _tweenScale.SetAutoKill(true);
        }
        
        if (_tweenPosition != null)
        {
            _tweenPosition.SetAutoKill(true);
        }
	}

    protected override void AnimationEnds(int updator, object args, UpdateTimeInfo info)
	{
		if (_tweenScale != null)
		{
            if (!_tweenScale.IsComplete())
            {
                _tweenScale.Complete(false);
            }
            _tweenScale.Kill(false);
            _tweenScale = null;
        }

//		if (_tweenAlpha != null && _tweenAlpha.enabled)
//		{
//			_tweenAlpha.Sample(1, false);
//			_tweenAlpha.enabled = false;
//		}

		if (_tweenPosition != null)
		{
            if (!_tweenPosition.IsComplete())
            {
                _tweenPosition.Complete(false);
            }
            _tweenPosition.Kill(false);
            _tweenPosition = null;
		}
		base.AnimationEnds(updator, args, info);
	}

	public override void StopAnimation()
	{
		if (_tweenScale != null)
		{
            _tweenScale.Kill();
			_tweenScale = null;
		}
        if (_tweenPosition != null)
        {
            _tweenPosition.Kill();
            _tweenPosition = null;
        }

		base.StopAnimation();
	}
}

