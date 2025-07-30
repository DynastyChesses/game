
using UnityEngine;

public class MainPanelSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public GameObject returnBtn;
	public RectTransform CommonClickMaskTr;
	public UGUIButtonEx clickTest;
	//auto generate propertyDef End, Don't Delete it!




	public MainPanelSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.returnBtn = _viewSkin.GetSingleProperty("returnBtn", 0) as GameObject;
		this.CommonClickMaskTr = _viewSkin.GetSingleProperty("CommonClickMaskTr", 1) as RectTransform;
		this.clickTest = _viewSkin.GetSingleProperty("clickTest", 2) as UGUIButtonEx;
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
