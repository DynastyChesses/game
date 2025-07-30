
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemPopupSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI txtAdTicketNum;
	public TextMeshProUGUI txtGoldNum;
	public GameObject btnAdTicketPlus;
	public GameObject btnGoldPlus;
	public TextMeshProUGUI txtTitle;
	public RectTransform trEffectLight;
	public Image imgItem;
	public TextMeshProUGUI txtDesc;
	public GameObject btnBuy;
	public TextMeshProUGUI txtRemain;
	public Image imgBtnBuy;
	public TextMeshProUGUI txtBtnBuy;
	//auto generate propertyDef End, Don't Delete it!



	public BuyItemPopupSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.txtAdTicketNum = _viewSkin.GetSingleProperty("txtAdTicketNum", 0) as TextMeshProUGUI;
		this.txtGoldNum = _viewSkin.GetSingleProperty("txtGoldNum", 1) as TextMeshProUGUI;
		this.btnAdTicketPlus = _viewSkin.GetSingleProperty("btnAdTicketPlus", 2) as GameObject;
		this.btnGoldPlus = _viewSkin.GetSingleProperty("btnGoldPlus", 3) as GameObject;
		this.txtTitle = _viewSkin.GetSingleProperty("txtTitle", 4) as TextMeshProUGUI;
		this.trEffectLight = _viewSkin.GetSingleProperty("trEffectLight", 5) as RectTransform;
		this.imgItem = _viewSkin.GetSingleProperty("imgItem", 6) as Image;
		this.txtDesc = _viewSkin.GetSingleProperty("txtDesc", 7) as TextMeshProUGUI;
		this.btnBuy = _viewSkin.GetSingleProperty("btnBuy", 8) as GameObject;
		this.txtRemain = _viewSkin.GetSingleProperty("txtRemain", 9) as TextMeshProUGUI;
		this.imgBtnBuy = _viewSkin.GetSingleProperty("imgBtnBuy", 10) as Image;
		this.txtBtnBuy = _viewSkin.GetSingleProperty("txtBtnBuy", 11) as TextMeshProUGUI;
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
