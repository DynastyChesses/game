using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IconProgressComponent : MonoBehaviour
{
	public Image progressIcon;
	public Scrollbar progressBar;
	public Text progressLabel;

	public void SetVaule(Sprite icon, float progress, string label)
	{
		progressIcon.sprite = icon;
		progressBar.value = progress;
		progressLabel.text = label;
	}
}

