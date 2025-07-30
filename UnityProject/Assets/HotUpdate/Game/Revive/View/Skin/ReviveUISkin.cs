
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviveUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI textLose;
	public TextMeshProUGUI textProgress;
	public GameObject btnKeepPlaying;
	public GameObject btnGiveUp;
	public RectTransform rectCapybara;
	public RectTransform rectMostPlayer;
	public TextMeshProUGUI textRemainRevive;
	public TextMeshProUGUI txtStaminaNum;
	public TextMeshProUGUI txtStaminaTime;
	public TextMeshProUGUI txtAdTicketNum;
	public TextMeshProUGUI txtGoldNum;
	public Image imgBtnRevive;
	public TextMeshProUGUI txtBtnRevive;
	//auto generate propertyDef End, Don't Delete it!








	public ReviveUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.textLose = _viewSkin.GetSingleProperty("textLose", 0) as TextMeshProUGUI;
		this.textProgress = _viewSkin.GetSingleProperty("textProgress", 1) as TextMeshProUGUI;
		this.btnKeepPlaying = _viewSkin.GetSingleProperty("btnKeepPlaying", 2) as GameObject;
		this.btnGiveUp = _viewSkin.GetSingleProperty("btnGiveUp", 3) as GameObject;
		this.rectCapybara = _viewSkin.GetSingleProperty("rectCapybara", 4) as RectTransform;
		this.rectMostPlayer = _viewSkin.GetSingleProperty("rectMostPlayer", 5) as RectTransform;
		this.textRemainRevive = _viewSkin.GetSingleProperty("textRemainRevive", 6) as TextMeshProUGUI;
		this.txtStaminaNum = _viewSkin.GetSingleProperty("txtStaminaNum", 7) as TextMeshProUGUI;
		this.txtStaminaTime = _viewSkin.GetSingleProperty("txtStaminaTime", 8) as TextMeshProUGUI;
		this.txtAdTicketNum = _viewSkin.GetSingleProperty("txtAdTicketNum", 9) as TextMeshProUGUI;
		this.txtGoldNum = _viewSkin.GetSingleProperty("txtGoldNum", 10) as TextMeshProUGUI;
		this.imgBtnRevive = _viewSkin.GetSingleProperty("imgBtnRevive", 11) as Image;
		this.txtBtnRevive = _viewSkin.GetSingleProperty("txtBtnRevive", 12) as TextMeshProUGUI;
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
