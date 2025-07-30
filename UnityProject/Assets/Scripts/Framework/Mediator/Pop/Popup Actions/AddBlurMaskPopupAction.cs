using UnityEngine;

public class AddBlurMaskPopupAction : AddMaskPopupMultiAction
{
    public static Color IMAGE_MASK_COLOR = new Color(0, 0, 0, 0.7f);
    public static Color IMAGE_MASK_INIT_COLOR = new Color(0, 0, 0, 0f);
    public Canvas _curCanvas = null;

    private static int _fullScreenCnt = 0;
    private static int _popCnt = 0;//非模糊界面不管
    private static bool _firstPop = true;
    private static bool _bluring = false;
    
    public AddBlurMaskPopupAction(uint popupMode, string maskPath) : base(popupMode, maskPath)
    {
    }

    protected override string maskPanelName => "BlurMaskPanel";

    protected override void OnStartLoadResource(IPopupView maskView)
    {
        if (maskView != null)
        {
            var blurBack2 = UIManager.instance.AcquireBlurBack();
            blurBack2.BlurBack(maskView);
            // _bluring = true;
        }
    }

    protected override void OnLoadResource(MaskContext maskView)
    {
        if (maskView.maskImage != null)
        {
            maskView.maskImage.color = IMAGE_MASK_INIT_COLOR;
        }
        if (maskView.rawImageBg != null)
        {
            var blurBack = UIManager.instance.AcquireBlurBack();
            maskView.rawImageBg.texture = blurBack.frameTexture;
            if (_firstPop)
            {
                maskView.rawImageBgCache.texture = blurBack.frameTextureCache;
            }
        }
        UIUtil.FitNotchForTransform(_context.gameObject?.GetComponent<RectTransform>());
    }
    
    protected override void OnMaskFinalHide(bool forceClean)
    {
        _context.rawImageBg.enabled = false;
        _context.rawImageBgCache.enabled = false;
        
        //切换场景就直接清掉
        if (forceClean)
        {
            UIManager.instance?.CleanBlurBackBuffer();
        }
        else
        {
            var blurBack = UIManager.instance?.AcquireBlurBack();
            blurBack?.RemoveCallback(BlurBackCallback);
            UIManager.instance?.DisposeBlurBack();
        }

        _firstPop = true;
        UIManager.instance?.ShowNoBlurCanvas();
        _fullScreenCnt = 0;
        _shareMaterial = null;
    }

    protected override void OnApplyContext(bool hide = false,bool blur = true)
    {
        if (_context.maskImage != null)
        {
            _context.maskImage.color = IMAGE_MASK_INIT_COLOR;
        }
        if (_context.rawImageBgCache.texture == null)
        {
            var blurBack1 = UIManager.instance.AcquireBlurBack();
            _context.rawImageBgCache.texture = blurBack1.frameTextureCache;
        }
        if (_context.view != null)
        {
            var pop = _context.view as AbstractPopupView;
            if (pop != null)
            {
                _curCanvas = pop.gameObject.GetComponent<Canvas>();
            }
        }
        _context.rawImageBg.enabled = false;
        
        if (_context.isFullScreen && _fullScreenCnt != 0)
        {
            var blurBack2 = UIManager.instance.AcquireBlurBack();
            blurBack2.BlurBack(_context.view);
            // _bluring = true;
            _context.rawImageBg.enabled = false;
            _context.rawImageBgCache.enabled = false;
            EnableTransparentBlack(false);
            return;
        }
        if (_popCnt == 1 && !_firstPop && !_bluring)
        {
            if (_context.maskImage != null)
            {
                _context.maskImage.color  = IMAGE_MASK_COLOR;
            }

            if (_context.rawImageBgCache.texture != null)
            {
                _context.rawImageBgCache.enabled = true;
            }
            EnableTransparentBlack(true);
            return;
        }
        if (_context.maskImage != null)
        {
            _context.maskImage.color = IMAGE_MASK_INIT_COLOR;
        }
        ShowAllCanvas();
        _context.rawImageBgCache.enabled = false;
        var blurBack = UIManager.instance.AcquireBlurBack();
        blurBack.AddCallback(BlurBackCallback);
        _bluring = true;
        UIManager.instance.HideNoBlurCanvas();
        if (blur)
        {
            blurBack.BlurBack(_context.view);
        }
        else
        {
            BlurBackCallback();
        }
        _firstPop = false;
        if (_context.rawImageBgCache.texture == null && blurBack.frameTextureCache != null)
        {
            _context.rawImageBgCache.texture = blurBack.frameTextureCache;
        }

    }

    private void BlurBackCallback()
    {
        _bluring = false;
        UIManager.instance.ShowNoBlurCanvas();
        _context.maskImage.color = IMAGE_MASK_COLOR;
        _context.rawImageBg.enabled = true;
        if (_context.rawImageBgCache.texture == null)
        {
            var blurBack = UIManager.instance.AcquireBlurBack();
            if (blurBack.frameTextureCache != null)
            {
                _context.rawImageBgCache.texture = blurBack.frameTextureCache;
            }
        }
        if (_fullScreenCnt > 0)
        {
            _context.rawImageBgCache.enabled = false;
            EnableTransparentBlack(false);
            return;
        }
        if (_popCnt > 1 && _context.rawImageBgCache.texture != null)
        {
            _context.rawImageBgCache.enabled = true;
        }
        else
        {
            _context.rawImageBgCache.enabled = false;
        }
        EnableTransparentBlack(_context.rawImageBgCache.enabled);
        
        CheckOtherPopVisible(_context.view);
    }

   
    public override void ExecuteBeforeShow(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {
        _popCnt++;
        if (popupParam.isFullScreen)
        {
            _fullScreenCnt++;
        }
        base.ExecuteBeforeShow( popupRoot,view,  popupParam);
    }

    public static bool canHandleMainUI = false;
    public override void ExecuteAfterShow(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {
        // 显示模糊背景时不渲染被遮住的东西
        UIManager.HideMainCamera();
        //有些界面自己管理mainui
        canHandleMainUI = !PopupFacade.instance.IsMainUIManaged();//统一在打开的时候判断是否要控制mainui
        if (canHandleMainUI)
        {
#if UNITY_EDITOR || DEBUG
            // Logger.Debug("BLUR ExecuteAfterShow HideMainUI "+view.name);
#endif
            UIManager.HideMainUI();  
        }
        UIManager.HideSceneUI();
        CheckOtherPopVisible(view);
    }

    public override void ExecuteBeforeHide(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {
        _popCnt--;
        // 恢复遮住东西的渲染
        UIManager.ShowMainCamera();
        canHandleMainUI = !PopupFacade.instance.IsMainUIManaged();//统一在打开的时候判断是否要控制mainui
        if (canHandleMainUI)
        {
#if UNITY_EDITOR || DEBUG
            // Logger.Debug("BLUR ExecuteBeforeHide ShowMainUI "+view.name);
#endif
            UIManager.ShowMainUI();  
        }
        UIManager.ShowSceneUI();
        if (popupParam.isFullScreen)
        {
            _fullScreenCnt--;
        }
    }

    public void CheckOtherPopVisible(IPopupView view)
    {
        PopupFacade.instance.HideViewBelow(view);
    }
    public void ShowAllCanvas()
    {
        var whitelist = UIManager.instance.blurWhiteList;
        if (whitelist != null && whitelist.Count > 0)
        {
            for (int i = 0; i < whitelist.Count; i++)
            {
                var canvas = whitelist[i];
                if (canvas != null && canvas.sortingOrder != 0)
                {
                    canvas.enabled = true;
                }
            }
            return;
        }
        PopupFacade.instance.ShowAllView();
    }
    private Material _shareMaterial = null;
    static readonly int _useTBlack = Shader.PropertyToID("_UseBlurTransParent");
    public void EnableTransparentBlack(bool tbMode)
    {
        if (_context == null)
        {
            return;
        }
        if (_shareMaterial == null)
        {
            _shareMaterial = _context.rawImageBg.material;
        }
        _shareMaterial?.SetInt(_useTBlack,tbMode?1:0);
    }

}