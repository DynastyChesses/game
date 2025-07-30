
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public GameObject btnSettings;
	public GameObject btnDailyTask;
	public GameObject btn_RemoveAd;
	public TextMeshProUGUI textStamina;
	public TextMeshProUGUI textGold;
	public GameObject btnRight;
	public GameObject btnLeft;
	public GameObject btnShop;
	public TextMeshProUGUI textChapter;
	public RectTransform rectPos;
	public CanvasGroup btnLeftCG;
	public CanvasGroup btnRightCG;
	public TextMeshProUGUI textLevelId;
	public GameObject btnPlay;
	public RectTransform rectOriginPos;
	public RectTransform rectDeltaPos;
	public RectTransform rectAcquireImgPos;
	public Image imgAcquireImgMask;
	public Image imgAcquireImgEffectLight;
	public Image skelAcquireChEffectLightDown;
	public SkeletonGraphic skelAcquireChEffectLightUp;
	public GameObject goAcquireImg_Text;
	public Image imgLockBg;
	public Image imgLockText;
	public TextMeshProUGUI textStaminaTime;
	public SkinUObjectList<Image> naviRound;
	public SkinUObjectList<GameObject> levelGroup;
	//auto generate propertyDef End, Don't Delete it!






















	public LevelSelectionUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.btnSettings = _viewSkin.GetSingleProperty("btnSettings", 0) as GameObject;
		this.btnDailyTask = _viewSkin.GetSingleProperty("btnDailyTask", 1) as GameObject;
		this.btn_RemoveAd = _viewSkin.GetSingleProperty("btn_RemoveAd", 2) as GameObject;
		this.textStamina = _viewSkin.GetSingleProperty("textStamina", 3) as TextMeshProUGUI;
		this.textGold = _viewSkin.GetSingleProperty("textGold", 4) as TextMeshProUGUI;
		this.btnRight = _viewSkin.GetSingleProperty("btnRight", 5) as GameObject;
		this.btnLeft = _viewSkin.GetSingleProperty("btnLeft", 6) as GameObject;
		this.btnShop = _viewSkin.GetSingleProperty("btnShop", 7) as GameObject;
		this.textChapter = _viewSkin.GetSingleProperty("textChapter", 8) as TextMeshProUGUI;
		this.rectPos = _viewSkin.GetSingleProperty("rectPos", 9) as RectTransform;
		this.btnLeftCG = _viewSkin.GetSingleProperty("btnLeftCG", 10) as CanvasGroup;
		this.btnRightCG = _viewSkin.GetSingleProperty("btnRightCG", 11) as CanvasGroup;
		this.textLevelId = _viewSkin.GetSingleProperty("textLevelId", 12) as TextMeshProUGUI;
		this.btnPlay = _viewSkin.GetSingleProperty("btnPlay", 13) as GameObject;
		this.rectOriginPos = _viewSkin.GetSingleProperty("rectOriginPos", 14) as RectTransform;
		this.rectDeltaPos = _viewSkin.GetSingleProperty("rectDeltaPos", 15) as RectTransform;
		this.rectAcquireImgPos = _viewSkin.GetSingleProperty("rectAcquireImgPos", 16) as RectTransform;
		this.imgAcquireImgMask = _viewSkin.GetSingleProperty("imgAcquireImgMask", 17) as Image;
		this.imgAcquireImgEffectLight = _viewSkin.GetSingleProperty("imgAcquireImgEffectLight", 18) as Image;
		this.skelAcquireChEffectLightDown = _viewSkin.GetSingleProperty("skelAcquireChEffectLightDown", 19) as Image;
		this.skelAcquireChEffectLightUp = _viewSkin.GetSingleProperty("skelAcquireChEffectLightUp", 20) as SkeletonGraphic;
		this.goAcquireImg_Text = _viewSkin.GetSingleProperty("goAcquireImg_Text", 21) as GameObject;
		this.imgLockBg = _viewSkin.GetSingleProperty("imgLockBg", 22) as Image;
		this.imgLockText = _viewSkin.GetSingleProperty("imgLockText", 23) as Image;
		this.textStaminaTime = _viewSkin.GetSingleProperty("textStaminaTime", 24) as TextMeshProUGUI;
		this.naviRound = new SkinUObjectList<Image>(_viewSkin, "naviRound", 0);
		this.levelGroup = new SkinUObjectList<GameObject>(_viewSkin, "levelGroup", 1);
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
