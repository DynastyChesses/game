
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWinUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI textLevel;
	public GameObject btnBaseGold;
	public Image imgProgress;
	public TextMeshProUGUI textProgress;
	public Image imgNewFeature;
	public SkeletonGraphic skelEffect1;
	public SkeletonGraphic skelEffect2;
	public SkeletonGraphic skelText;
	public GameObject goNewFeature;
	public GameObject btnRandomGold;
	public TextMeshProUGUI txtRandomGoldNum;
	public TextMeshProUGUI txtBaseGoldNum;
	public RectTransform rectPtr;
	//auto generate propertyDef End, Don't Delete it!







	public LevelWinUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.textLevel = _viewSkin.GetSingleProperty("textLevel", 0) as TextMeshProUGUI;
		this.btnBaseGold = _viewSkin.GetSingleProperty("btnBaseGold", 1) as GameObject;
		this.imgProgress = _viewSkin.GetSingleProperty("imgProgress", 2) as Image;
		this.textProgress = _viewSkin.GetSingleProperty("textProgress", 3) as TextMeshProUGUI;
		this.imgNewFeature = _viewSkin.GetSingleProperty("imgNewFeature", 4) as Image;
		this.skelEffect1 = _viewSkin.GetSingleProperty("skelEffect1", 5) as SkeletonGraphic;
		this.skelEffect2 = _viewSkin.GetSingleProperty("skelEffect2", 6) as SkeletonGraphic;
		this.skelText = _viewSkin.GetSingleProperty("skelText", 7) as SkeletonGraphic;
		this.goNewFeature = _viewSkin.GetSingleProperty("goNewFeature", 8) as GameObject;
		this.btnRandomGold = _viewSkin.GetSingleProperty("btnRandomGold", 9) as GameObject;
		this.txtRandomGoldNum = _viewSkin.GetSingleProperty("txtRandomGoldNum", 10) as TextMeshProUGUI;
		this.txtBaseGoldNum = _viewSkin.GetSingleProperty("txtBaseGoldNum", 11) as TextMeshProUGUI;
		this.rectPtr = _viewSkin.GetSingleProperty("rectPtr", 12) as RectTransform;
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
