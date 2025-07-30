using UnityEngine;

public class HideCameraPopupAction : BasePopupAction
{
	public HideCameraPopupAction () : base (PopupMode.HIDE_CAMERA)
	{
	}
	
	private bool hideMainUI = false;
	public override void ExecuteAfterShow (Transform popupRoot, IPopupView view, PopupParam popupParam)
	{
		UIManager.instance.mainCamera.enabled = false;
		
		if( hideMainUI )
			return;
		hideMainUI = true;
		UIManager.HideMainUI();
	}
	
    public override void ExecuteBeforeHide(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {
		UIManager.instance.mainCamera.enabled = true;
		
		if( !hideMainUI )
			return;
		hideMainUI = false;
		UIManager.ShowMainUI();
    }

	public override void ExecuteAfterHide (Transform popupRoot, IPopupView view, PopupParam popupParam)
	{
	}
}

