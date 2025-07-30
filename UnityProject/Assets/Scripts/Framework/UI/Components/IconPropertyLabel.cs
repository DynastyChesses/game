using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IconPropertyLabel :MonoBehaviour
{
	public Image img;
	
	public Text nameLbl;

	public Text valueLbl;
	
	public Text originalValueLbl;
	
	public GameObject originalValueBg;

	public void SetContent(Sprite icon, string propName, string propVal, string originalValue = "")
	{
		img.sprite = icon;
		nameLbl.text = propName;
		valueLbl.text = propVal;

		if (originalValueLbl) originalValueLbl.text = originalValue;
	}
}
