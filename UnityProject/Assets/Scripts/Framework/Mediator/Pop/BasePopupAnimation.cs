using System;

public class BasePopupAnimation
{
	public PopupAnimationType animationType { get; protected set; }
	
	public float defaultDuration { get; protected set; }

    public bool isPlaying { get { return _isPlaying && !_reverse; } }
    public bool isPlayingReverse { get { return _isPlaying && _reverse; } }

    private bool _isPlaying;
	private bool _reverse;
	private IPopupView _popupView;
	private PopupParam _context;
	private Action<PopupParam> _onAnimationEnds;
	private int _stopAnimationHandle;

	public BasePopupAnimation (IPopupView popupView, PopupAnimationType animationType, float duration)
	{
		this._popupView = popupView;
		this.animationType = animationType;
		defaultDuration = duration;
	}

	public virtual void StartAnimation (Action<PopupParam> completeCallback, float duration, PopupParam context = null, bool reverse = false)
	{
		//        Logger.Debug("~StartAnimation: " + reverse);
		this._context = context;
		this._onAnimationEnds = completeCallback;
		this._reverse = reverse;

		SetPlayingState(true);

//		popupView.mainPanel.StopAllCoroutines();//理论上是没有再用mainPanel的StartCoroutines了
		if (_popupView.visibleInHierarchy)
		{
            //if(_stopAnimationHandle != GlobalScheduler.INVALID)//再次调用StartAnimation的时候，要先把之前正在播放的Animation的结束事件Cancel掉
            {
	            EquineScheduler.RemoveLimitUpdator(ref _stopAnimationHandle);
            }
			_stopAnimationHandle = EquineScheduler.CallOnce(duration, this.AnimationEnds, _context);
//			LogUtility.Log("BasePopupAnimation StartAnimation " + Time.frameCount);
		}
		else
		{
			SetPlayingState(false);

			this._onAnimationEnds = null;
			if (completeCallback != null && _context!= null)
				completeCallback(_context);
		}
	}

	public virtual void StopAnimation()
	{
//        Logger.Debug("StopAnimation: " + _reverse);
		SetPlayingState(false);
		if (_popupView != null)
		{
            //if(_stopAnimationHandle != GlobalScheduler.INVALID)
            {
	            EquineScheduler.RemoveLimitUpdator(ref _stopAnimationHandle);
            }
			// _popupView = null;
		}
		this._onAnimationEnds = null;
	}

	protected virtual void AnimationEnds(int updator, object args, UpdateTimeInfo info)
	{
        PopupParam context = args as PopupParam;
		if (this._context != context)
        {
			return;
        }
        _stopAnimationHandle = EquineScheduler.INVALID;

		SetPlayingState(false);

		//        Logger.Debug("AnimationEnds: " + animationType + " " +  _reverse);
		Action<PopupParam> completeCallback = this._onAnimationEnds;
		this._onAnimationEnds = null;
		if (completeCallback != null && _context != null)
			completeCallback(_context);
	}

	private void SetPlayingState(bool state)
	{
        _isPlaying = state;
//		if (!_reverse)
//			isPlaying = state;
//		else
//			isPlayingReverse = state;
	}
}

