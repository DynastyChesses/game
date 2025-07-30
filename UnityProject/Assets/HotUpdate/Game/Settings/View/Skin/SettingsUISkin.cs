
using UnityEngine;

public class SettingsUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public GameObject btnMusic;
	public GameObject btnSound;
	public GameObject btnSupport;
	public GameObject btnPrivacyPolicy;
	public GameObject btnRestorePurchase;
	public GameObject btnClose;
	public GameObject btnHome;
	//auto generate propertyDef End, Don't Delete it!





	public SettingsUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.btnMusic = _viewSkin.GetSingleProperty("btnMusic", 0) as GameObject;
		this.btnSound = _viewSkin.GetSingleProperty("btnSound", 1) as GameObject;
		this.btnSupport = _viewSkin.GetSingleProperty("btnSupport", 2) as GameObject;
		this.btnPrivacyPolicy = _viewSkin.GetSingleProperty("btnPrivacyPolicy", 3) as GameObject;
		this.btnRestorePurchase = _viewSkin.GetSingleProperty("btnRestorePurchase", 4) as GameObject;
		this.btnClose = _viewSkin.GetSingleProperty("btnClose", 5) as GameObject;
		this.btnHome = _viewSkin.GetSingleProperty("btnHome", 6) as GameObject;
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
