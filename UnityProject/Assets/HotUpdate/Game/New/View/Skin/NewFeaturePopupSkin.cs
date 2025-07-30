
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewFeaturePopupSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI textName;
	public Image imgNewFeature;
	public TextMeshProUGUI textDesc;
	public GameObject btnConfirm;
	//auto generate propertyDef End, Don't Delete it!




	public NewFeaturePopupSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.textName = _viewSkin.GetSingleProperty("textName", 0) as TextMeshProUGUI;
		this.imgNewFeature = _viewSkin.GetSingleProperty("imgNewFeature", 1) as Image;
		this.textDesc = _viewSkin.GetSingleProperty("textDesc", 2) as TextMeshProUGUI;
		this.btnConfirm = _viewSkin.GetSingleProperty("btnConfirm", 3) as GameObject;
		//auto generate propertySet End, Don't Delete it!



	}

	public override void Dispose()
    {
		//auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!



		base.Dispose();
    }

    // __ANIMATE__
}
