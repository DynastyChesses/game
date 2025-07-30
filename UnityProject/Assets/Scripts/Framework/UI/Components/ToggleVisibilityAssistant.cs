using UnityEngine;
using UnityEngine.UI;

public class ToggleVisibilityAssistant : MonoBehaviour
{
	public GameObject target;

	public bool invert;

	public void OnStateChange(Toggle toggle)
	{
		if (target != null)
		{
			target.SetActive(invert ? !toggle.isOn : toggle.isOn);
		}	
	}
}
