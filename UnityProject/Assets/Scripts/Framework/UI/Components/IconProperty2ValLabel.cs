using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IconProperty2ValLabel :MonoBehaviour
{
	public Image img;

	public Text nameLbl;

	public Text valueLbl1;

	public Text valueLbl2;

	public void SetContent(Sprite icon, string propName, string propVal1, string propVal2)
	{
		img.sprite = icon;
		nameLbl.text = propName;
		valueLbl1.text = propVal1;
		valueLbl2.text = propVal2;
	}
	
	public void SetContent(string propVal1, string propVal2)
	{
		valueLbl1.text = propVal1;
		valueLbl2.text = propVal2;
	}
	
	public void SetName(string propName)
	{
		nameLbl.text = propName;
	}
}
