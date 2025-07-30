using UnityEngine;

public class AnimatorRandomPlayer :MonoBehaviour
{
	public Animator[] anis;
	public string[] stateNames;
	// Use this for initialization
	void OnEnable()
	{
		int count = anis != null ? anis.Length : 0;
		for (int i = 0; i < count; ++i)
		{
			Animator ani = anis[i];
			int stateHash = !string.IsNullOrEmpty(stateNames[i])
			? Animator.StringToHash(stateNames[i])
			: ani.GetCurrentAnimatorStateInfo(0).fullPathHash;
//			StartCoroutine(StartPlay());
			ani.Play(stateHash, 0, Random.value);
		}
	}

//	IEnumerator StartPlay()
//	{
//		
//		yield return new WaitForSeconds(Random.value * 2f);
//		ani.enabled = true;
//	}

}
