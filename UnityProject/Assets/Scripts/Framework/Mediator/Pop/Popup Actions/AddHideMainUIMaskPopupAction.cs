using UnityEngine;

public class AddHideMainUIMaskPopupAction : AddMaskPopupAction
{
	public AddHideMainUIMaskPopupAction(uint popupMode, string maskPath) : base(popupMode, maskPath)
	{
	}


	private bool hideMainUI = false;
	protected override void OnGetResource( MaskContext maskView )
	{
		if (maskView.rawImageBg != null)
		{
			Color color = maskView.rawImageBg.color;
            
			color.r = color.g = color.b = 0;
			color.a = 0.3f;
			maskView.rawImageBg.color = color;
		}
		base.OnGetResource( maskView );
		if( hideMainUI )
			return;

		hideMainUI = true;
		UIManager.HideMainUI();
		
		UIUtil.FitNotchForTransform(_context.gameObject?.GetComponent<RectTransform>());
	}
	
	protected override void OnReleaseResource()
	{
		base.OnReleaseResource();
		
		if( !hideMainUI )
			return;
		hideMainUI = false;
		UIManager.ShowMainUI();
	}

}


