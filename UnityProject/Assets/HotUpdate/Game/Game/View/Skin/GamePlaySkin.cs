
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlaySkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public RectTransform brickLayout;
	public RectTransform slotLayout;
	public RectTransform boxLayout;
	public GameObject bg;
	public RectTransform firePoint;
	public SkeletonGraphic skelDuck;
	public SkeletonGraphic skelBucket;
	public SkeletonGraphic skelBucketEx;
	public RectTransform rectInfo;
	public TextMeshProUGUI textLevelNum;
	public RectTransform slotLock;
	public RectTransform arrows;
	public RectTransform lines;
	public RectTransform maskRight;
	public RectTransform maskLeft;
	public RectTransform fever;
	public TextMeshProUGUI comboNum;
	public Image comboBg;
	public Image comboImg;
	public RectTransform maskRightEndPos;
	public RectTransform maskLeftEndPos;
	public Image feverBarP1;
	public Image feverBarP2;
	public Image feverBarP3;
	public SkeletonGraphic skelFeverBtn;
	public Image ImgFeverBg_Low;
	public BottomRightTriangle ImgFeverBgEx_Low;
	public RectTransform feverStartPos;
	public RectTransform feverEndPos;
	public RectTransform rectFeverDucks;
	public RectTransform rectGuide1;
	public RectTransform rectGuide2;
	public RectTransform rectGuide3;
	public RectTransform rectGuide4;
	public RectTransform rectGuide5;
	public SkeletonGraphic skelHammer;
	public SkeletonGraphic skelCoin;
	public SkeletonGraphic skelMaskLeft;
	public SkeletonGraphic skelMaskRight;
	public Image ImgFeverBg_High;
	public BottomRightTriangle ImgFeverBgEx_High;
	public RectTransform capybaraPos;
	public GameObject tip;
	public TextMeshProUGUI textTip;
	public Image imgItemUse;
	public TextMeshProUGUI textItemUse;
	public Image imgThreeLines;
	public GameObject btnSettings;
	public GridLayoutGroup itemLayout;
	public Image imgHard;
	public SkeletonGraphic skelHard;
	public Image frameHard;
	public SkinUObjectList<RectTransform> path;
	public SkinUObjectList<GameObject> target;
	public SkinUObjectList<GameObject> feverDucks;
	public SkinUObjectList<GameObject> item;
	public SkinUObjectList<GameObject> itemBtnGameObject;
	public SkinUObjectList<SkeletonGraphic> itemSkel;
	public SkinUObjectList<UGUIButtonEx> itemBtn;
	public SkinUObjectList<GameObject> itemText;
	public SkinUObjectList<GameObject> itemTextLevel;
	public SkinUObjectList<GameObject> itemImgLock;
	public SkinUObjectList<GameObject> itemBgNumber;
	public SkinUObjectList<GameObject> itemNumber;
	public SkinUObjectList<GameObject> itemImgPlus;
	public SkinUObjectList<GameObject> itemMask;
	//auto generate propertyDef End, Don't Delete it!













































































	public GamePlaySkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.brickLayout = _viewSkin.GetSingleProperty("brickLayout", 0) as RectTransform;
		this.slotLayout = _viewSkin.GetSingleProperty("slotLayout", 1) as RectTransform;
		this.boxLayout = _viewSkin.GetSingleProperty("boxLayout", 2) as RectTransform;
		this.bg = _viewSkin.GetSingleProperty("bg", 3) as GameObject;
		this.firePoint = _viewSkin.GetSingleProperty("firePoint", 4) as RectTransform;
		this.skelDuck = _viewSkin.GetSingleProperty("skelDuck", 5) as SkeletonGraphic;
		this.skelBucket = _viewSkin.GetSingleProperty("skelBucket", 6) as SkeletonGraphic;
		this.skelBucketEx = _viewSkin.GetSingleProperty("skelBucketEx", 7) as SkeletonGraphic;
		this.rectInfo = _viewSkin.GetSingleProperty("rectInfo", 8) as RectTransform;
		this.textLevelNum = _viewSkin.GetSingleProperty("textLevelNum", 9) as TextMeshProUGUI;
		this.slotLock = _viewSkin.GetSingleProperty("slotLock", 10) as RectTransform;
		this.arrows = _viewSkin.GetSingleProperty("arrows", 11) as RectTransform;
		this.lines = _viewSkin.GetSingleProperty("lines", 12) as RectTransform;
		this.maskRight = _viewSkin.GetSingleProperty("maskRight", 13) as RectTransform;
		this.maskLeft = _viewSkin.GetSingleProperty("maskLeft", 14) as RectTransform;
		this.fever = _viewSkin.GetSingleProperty("fever", 15) as RectTransform;
		this.comboNum = _viewSkin.GetSingleProperty("comboNum", 16) as TextMeshProUGUI;
		this.comboBg = _viewSkin.GetSingleProperty("comboBg", 17) as Image;
		this.comboImg = _viewSkin.GetSingleProperty("comboImg", 18) as Image;
		this.maskRightEndPos = _viewSkin.GetSingleProperty("maskRightEndPos", 19) as RectTransform;
		this.maskLeftEndPos = _viewSkin.GetSingleProperty("maskLeftEndPos", 20) as RectTransform;
		this.feverBarP1 = _viewSkin.GetSingleProperty("feverBarP1", 21) as Image;
		this.feverBarP2 = _viewSkin.GetSingleProperty("feverBarP2", 22) as Image;
		this.feverBarP3 = _viewSkin.GetSingleProperty("feverBarP3", 23) as Image;
		this.skelFeverBtn = _viewSkin.GetSingleProperty("skelFeverBtn", 24) as SkeletonGraphic;
		this.ImgFeverBg_Low = _viewSkin.GetSingleProperty("ImgFeverBg_Low", 25) as Image;
		this.ImgFeverBgEx_Low = _viewSkin.GetSingleProperty("ImgFeverBgEx_Low", 26) as BottomRightTriangle;
		this.feverStartPos = _viewSkin.GetSingleProperty("feverStartPos", 27) as RectTransform;
		this.feverEndPos = _viewSkin.GetSingleProperty("feverEndPos", 28) as RectTransform;
		this.rectFeverDucks = _viewSkin.GetSingleProperty("rectFeverDucks", 29) as RectTransform;
		this.rectGuide1 = _viewSkin.GetSingleProperty("rectGuide1", 30) as RectTransform;
		this.rectGuide2 = _viewSkin.GetSingleProperty("rectGuide2", 31) as RectTransform;
		this.rectGuide3 = _viewSkin.GetSingleProperty("rectGuide3", 32) as RectTransform;
		this.rectGuide4 = _viewSkin.GetSingleProperty("rectGuide4", 33) as RectTransform;
		this.rectGuide5 = _viewSkin.GetSingleProperty("rectGuide5", 34) as RectTransform;
		this.skelHammer = _viewSkin.GetSingleProperty("skelHammer", 35) as SkeletonGraphic;
		this.skelCoin = _viewSkin.GetSingleProperty("skelCoin", 36) as SkeletonGraphic;
		this.skelMaskLeft = _viewSkin.GetSingleProperty("skelMaskLeft", 37) as SkeletonGraphic;
		this.skelMaskRight = _viewSkin.GetSingleProperty("skelMaskRight", 38) as SkeletonGraphic;
		this.ImgFeverBg_High = _viewSkin.GetSingleProperty("ImgFeverBg_High", 39) as Image;
		this.ImgFeverBgEx_High = _viewSkin.GetSingleProperty("ImgFeverBgEx_High", 40) as BottomRightTriangle;
		this.capybaraPos = _viewSkin.GetSingleProperty("capybaraPos", 41) as RectTransform;
		this.tip = _viewSkin.GetSingleProperty("tip", 42) as GameObject;
		this.textTip = _viewSkin.GetSingleProperty("textTip", 43) as TextMeshProUGUI;
		this.imgItemUse = _viewSkin.GetSingleProperty("imgItemUse", 44) as Image;
		this.textItemUse = _viewSkin.GetSingleProperty("textItemUse", 45) as TextMeshProUGUI;
		this.imgThreeLines = _viewSkin.GetSingleProperty("imgThreeLines", 46) as Image;
		this.btnSettings = _viewSkin.GetSingleProperty("btnSettings", 47) as GameObject;
		this.itemLayout = _viewSkin.GetSingleProperty("itemLayout", 48) as GridLayoutGroup;
		this.imgHard = _viewSkin.GetSingleProperty("imgHard", 49) as Image;
		this.skelHard = _viewSkin.GetSingleProperty("skelHard", 50) as SkeletonGraphic;
		this.frameHard = _viewSkin.GetSingleProperty("frameHard", 51) as Image;
		this.path = new SkinUObjectList<RectTransform>(_viewSkin, "path", 0);
		this.target = new SkinUObjectList<GameObject>(_viewSkin, "target", 1);
		this.feverDucks = new SkinUObjectList<GameObject>(_viewSkin, "feverDucks", 2);
		this.item = new SkinUObjectList<GameObject>(_viewSkin, "item", 3);
		this.itemBtnGameObject = new SkinUObjectList<GameObject>(_viewSkin, "itemBtnGameObject", 4);
		this.itemSkel = new SkinUObjectList<SkeletonGraphic>(_viewSkin, "itemSkel", 5);
		this.itemBtn = new SkinUObjectList<UGUIButtonEx>(_viewSkin, "itemBtn", 6);
		this.itemText = new SkinUObjectList<GameObject>(_viewSkin, "itemText", 7);
		this.itemTextLevel = new SkinUObjectList<GameObject>(_viewSkin, "itemTextLevel", 8);
		this.itemImgLock = new SkinUObjectList<GameObject>(_viewSkin, "itemImgLock", 9);
		this.itemBgNumber = new SkinUObjectList<GameObject>(_viewSkin, "itemBgNumber", 10);
		this.itemNumber = new SkinUObjectList<GameObject>(_viewSkin, "itemNumber", 11);
		this.itemImgPlus = new SkinUObjectList<GameObject>(_viewSkin, "itemImgPlus", 12);
		this.itemMask = new SkinUObjectList<GameObject>(_viewSkin, "itemMask", 13);
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
