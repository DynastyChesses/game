
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class GlobalLoadPanelSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public Image Bar;
	public TextMeshProUGUI Info;
	public TextMeshProUGUI progress;
	//auto generate propertyDef End, Don't Delete it!




	public GlobalLoadPanelSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.Bar = _viewSkin.GetSingleProperty("Bar", 0) as Image;
		this.Info = _viewSkin.GetSingleProperty("Info", 1) as TextMeshProUGUI;
		this.progress = _viewSkin.GetSingleProperty("progress", 2) as TextMeshProUGUI;
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
