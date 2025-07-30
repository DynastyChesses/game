
using UnityEngine;

public class CommonRewardPanelV2Skin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public RectTransform rewardContent;
	public GameObject returnBtn;
	public RectTransform animateTr;
	public RectTransform CommonReturnTipsTr;
	public RectTransform CommonClickMaskTr;
	public UIButton closeButton2;
	//auto generate propertyDef End, Don't Delete it!



	public CommonRewardPanelV2Skin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.rewardContent = _viewSkin.GetSingleProperty("rewardContent", 0) as RectTransform;
		this.returnBtn = _viewSkin.GetSingleProperty("returnBtn", 1) as GameObject;
		this.animateTr = _viewSkin.GetSingleProperty("animateTr", 2) as RectTransform;
		this.CommonReturnTipsTr = _viewSkin.GetSingleProperty("CommonReturnTipsTr", 3) as RectTransform;
		this.CommonClickMaskTr = _viewSkin.GetSingleProperty("CommonClickMaskTr", 4) as RectTransform;
		this.closeButton2 = _viewSkin.GetSingleProperty("closeButton2", 5) as UIButton;
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
