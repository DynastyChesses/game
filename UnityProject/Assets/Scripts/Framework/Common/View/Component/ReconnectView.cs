using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReconnectView :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public GameObject alertArea;
	public GameObject waitingArea;
	public GameObject okButton;
	public Text waitingLabel;
	public TextMeshProUGUI titleLabel;
	public TextMeshProUGUI contentLabel;
	public TextMeshProUGUI okButtonText;
	//auto generate propertyDef End, Don't Delete it!

	public bool resetGameSessionId;
	
	public override uint removeAllFlag => PopupRemoveMode.TOP_LAYER;

	public ReconnectView(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.alertArea = _viewSkin.GetSingleProperty("alertArea", 0) as GameObject;
		this.waitingArea = _viewSkin.GetSingleProperty("waitingArea", 1) as GameObject;
		this.okButton = _viewSkin.GetSingleProperty("okButton", 2) as GameObject;
		this.waitingLabel = _viewSkin.GetSingleProperty("waitingLabel", 3) as Text;
		this.titleLabel = _viewSkin.GetSingleProperty("titleLabel", 4) as TextMeshProUGUI;
		this.contentLabel = _viewSkin.GetSingleProperty("contentLabel", 5) as TextMeshProUGUI;
		this.okButtonText = _viewSkin.GetSingleProperty("okButtonText", 6) as TextMeshProUGUI;
		//auto generate propertySet End, Don't Delete it!

		this.resetGameSessionId = true;
	}

	public override void Dispose()
    {
		//auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!


		base.Dispose();
    }
}
