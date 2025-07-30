
using UnityEngine;

public class LevelLoseUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public GameObject btnRestart;
	public GameObject btnBack;
	//auto generate propertyDef End, Don't Delete it!



	public LevelLoseUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.btnRestart = _viewSkin.GetSingleProperty("btnRestart", 0) as GameObject;
		this.btnBack = _viewSkin.GetSingleProperty("btnBack", 1) as GameObject;
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
