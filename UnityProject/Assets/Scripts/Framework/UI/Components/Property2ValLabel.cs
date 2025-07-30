using UnityEngine;
using UnityEngine.UI;

public class Property2ValLabel :MonoBehaviour
{
	public Text nameLbl;

	public Text valueLbl1;

	public Text valueLbl2;

	public void SetContent(string propName, string propVal1, string propVal2)
	{
		nameLbl.text = propName;
		valueLbl1.text = propVal1;
		valueLbl2.text = propVal2;
	}

}
