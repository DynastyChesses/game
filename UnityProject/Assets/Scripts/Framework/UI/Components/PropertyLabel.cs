using UnityEngine;
using UnityEngine.UI;

public class PropertyLabel : MonoBehaviour
{
	public Text nameLbl;

	public Text valueLbl;
	public void SetContent(string propName, string propVal)
	{
        if(null != nameLbl)
        {
            nameLbl.text = propName;
        }
        if(null != valueLbl)
        {
            valueLbl.text = propVal;
        }
	}
}
