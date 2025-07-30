using UnityEngine;
using UnityEngine.UI;

public class PropertyProgressLabel : MonoBehaviour
{
	public Image icon;
	public Text valueLbl;
	public Image progressBg;
	public void SetContent(Sprite sp, string propVal)
	{
        if(null != icon)
        {
	        icon.sprite = sp;
        }
        if(null != valueLbl)
        {
            valueLbl.text = propVal;
        }
	}
}
