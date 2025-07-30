using System.Collections;
using UnityEngine;

public class AnimationHelper :MonoBehaviour
{
	public string[] states;

	public float delayTime = 1f;

	public IEnumerator Play()
	{
		if (delayTime > 0)
		{
			yield return new WaitForSeconds(delayTime);
		}
		Animation animation = this.GetComponent<Animation>();
		for (int i = 0; i < states.Length; ++i)
		{
			if (i == 0)
			{
				animation.CrossFade(states[i]);
			}
			else
			{
				animation.CrossFadeQueued(states[i]);
			}
		}
	}

	public void OnEnable()
	{
		StartCoroutine(Play());
	}
}
