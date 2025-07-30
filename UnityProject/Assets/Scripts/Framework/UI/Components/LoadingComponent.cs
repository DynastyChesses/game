using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingComponent:MonoBehaviour
{
	public Text progressLabel;
	public Image progress;

	public Text restartLabel;

	public Image bgTex;

	public Text percentLabel;

	public Text versionLabel;

	[NonSerialized]
	public int nguiWidth;

	public void SetActive(bool value)
	{
		this.gameObject.SetActive(value);
		if (restartLabel != null)
		{
			restartLabel.gameObject.SetActive(value);
		}
		if (bgTex != null)
		{
			bgTex.gameObject.SetActive(value);
		}
	}

	private float _currentProgress = 0f;
	private Tweener _progressTween = null;

	public void ResetProgress()
	{
		_currentProgress = 0f;
		ClearProgress(0f);
		if (percentLabel != null)
		{
			percentLabel.text = "00.0%";
		}

	}

	public float GetCurrentProgress()
	{
		return _currentProgress;
	}

	public void SetCurrentProgress(float value)
	{
		float lastProgress = _currentProgress;
		_currentProgress = value;
		SetProgress(progress, _currentProgress);
		if (percentLabel != null)
		{
			if ((int)(lastProgress * 1000) != (int)(_currentProgress * 1000))
			{
				percentLabel.text = value.ToString("00.0%");
			}
		}
	}

	public void ClearProgress(float value)
	{
		if (_progressTween != null)
		{
			_progressTween.Kill();
			_progressTween = null;
		}
		this.SetCurrentProgress(value);
	}

	public void TweenProgressTo(float value)
	{
		if (_progressTween != null/* && _progressTween.IsPlaying()*/)
		{
			_progressTween.ChangeValues(_currentProgress, value, (value - _currentProgress) * 100 / 15f);
			if (!_progressTween.IsPlaying())
			{
				_progressTween.Play();
			}
		}
		else// if (value - _currentProgress > .01f)
		{
			_progressTween =
				DOTween.To(this.GetCurrentProgress, this.SetCurrentProgress, value, (value - _currentProgress) * 100 / 15f)
					.SetAutoKill(false);
		}
	}

	private void SetProgress(Image tex, float value)
	{
		if (tex.type == Image.Type.Filled)
		{
			tex.fillAmount = value;
		}
	}
}
