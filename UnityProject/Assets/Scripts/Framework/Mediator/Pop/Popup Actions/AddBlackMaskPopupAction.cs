using UnityEngine;

public class AddBlackMaskPopupAction : AddMaskPopupAction
{
    public AddBlackMaskPopupAction(uint popupMode, string maskPath)
        : base(popupMode, maskPath)
    {
    }

    protected override string maskPanelName => "BlackMaskPanel";

    protected override void OnLoadResource(MaskContext maskView)
    {
        if (maskView.rawImageBg != null)
        {
            Color color = maskView.rawImageBg.color;
            
            color.r = color.g = color.b = 0;
            color.a = 0.3f;
            maskView.rawImageBg.color = color;
        }
   
        UIUtil.FitNotchForTransform(_context.gameObject?.GetComponent<RectTransform>());
    }
    
    
    protected override void OnReleaseResource()
    {
        base.OnReleaseResource();
    }
}
