
using TMPro;
using UnityEngine;

public class MainUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI Info;
	public Animator InfoAnimator;
	public TextMeshProUGUI time;
	//auto generate propertyDef End, Don't Delete it!




	public MainUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.Info = _viewSkin.GetSingleProperty("Info", 0) as TextMeshProUGUI;
		this.InfoAnimator = _viewSkin.GetSingleProperty("InfoAnimator", 1) as Animator;
		this.time = _viewSkin.GetSingleProperty("time", 2) as TextMeshProUGUI;
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
