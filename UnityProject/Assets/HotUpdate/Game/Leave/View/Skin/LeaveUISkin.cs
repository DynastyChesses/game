
using UnityEngine;

public class LeaveUISkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public GameObject btnClose;
	public GameObject btnLeave;
	//auto generate propertyDef End, Don't Delete it!



	public LeaveUISkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.btnClose = _viewSkin.GetSingleProperty("btnClose", 0) as GameObject;
		this.btnLeave = _viewSkin.GetSingleProperty("btnLeave", 1) as GameObject;
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
