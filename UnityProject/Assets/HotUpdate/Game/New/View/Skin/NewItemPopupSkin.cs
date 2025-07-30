
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewItemPopupSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI textName;
	public Image imgNewItem;
	public TextMeshProUGUI textDesc;
	public GameObject btnConfirm;
	public RectTransform effectLight;
	//auto generate propertyDef End, Don't Delete it!




	public NewItemPopupSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.textName = _viewSkin.GetSingleProperty("textName", 0) as TextMeshProUGUI;
		this.imgNewItem = _viewSkin.GetSingleProperty("imgNewItem", 1) as Image;
		this.textDesc = _viewSkin.GetSingleProperty("textDesc", 2) as TextMeshProUGUI;
		this.btnConfirm = _viewSkin.GetSingleProperty("btnConfirm", 3) as GameObject;
		this.effectLight = _viewSkin.GetSingleProperty("effectLight", 4) as RectTransform;
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
