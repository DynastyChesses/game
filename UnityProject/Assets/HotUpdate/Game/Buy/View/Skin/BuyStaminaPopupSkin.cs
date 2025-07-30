
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyStaminaPopupSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI txtAdTicketNum;
	public TextMeshProUGUI txtGoldNum;
	public TextMeshProUGUI txtTime;
	public GameObject btnRefill;
	public GameObject btnOneMoreLife;
	public TextMeshProUGUI txtConsumeGoldNum;
	public Image imgBtnOneMoreLife;
	public TextMeshProUGUI txtBtnOneMoreLife;
	//auto generate propertyDef End, Don't Delete it!






	public BuyStaminaPopupSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.txtAdTicketNum = _viewSkin.GetSingleProperty("txtAdTicketNum", 0) as TextMeshProUGUI;
		this.txtGoldNum = _viewSkin.GetSingleProperty("txtGoldNum", 1) as TextMeshProUGUI;
		this.txtTime = _viewSkin.GetSingleProperty("txtTime", 2) as TextMeshProUGUI;
		this.btnRefill = _viewSkin.GetSingleProperty("btnRefill", 3) as GameObject;
		this.btnOneMoreLife = _viewSkin.GetSingleProperty("btnOneMoreLife", 4) as GameObject;
		this.txtConsumeGoldNum = _viewSkin.GetSingleProperty("txtConsumeGoldNum", 5) as TextMeshProUGUI;
		this.imgBtnOneMoreLife = _viewSkin.GetSingleProperty("imgBtnOneMoreLife", 6) as Image;
		this.txtBtnOneMoreLife = _viewSkin.GetSingleProperty("txtBtnOneMoreLife", 7) as TextMeshProUGUI;
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
