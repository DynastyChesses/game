using System;
using UnityEngine;

public class AddMaskPopupAction : CommonUIWidget
{
    protected string _maskPath;
    private bool _isLoading;

    protected virtual string maskPanelName => "MaskPanel";

    public AddMaskPopupAction(uint popupMode, string maskPath)
        : base(popupMode, -1)
    {
        _maskPath = maskPath;
    }

    protected MaskContext _context = null;
    private ResourceReleaseFacade.ResourceToken _token = null;
    private IPopupView _targetView = null;

    protected bool isClickHide(PopupParam popupParam)
    {
        object param = popupParam != null ? popupParam.GetExternalParam(mode) : null;
        if (param == null)
        {
            return true;
        }
        if (param.GetType() != typeof(bool))
        {
            return true;
        }
        return (bool)param;
    }

    private void GetResource(Action callback = null)
    {
        // create resource
        if (_token != null)
        {
            _context = ResourceReleaseFacade.instance.Acquire(_token) as MaskContext;
            _context.gameObject.SetActive(true);
            _token = null;
            OnGetResource(_context);
            callback.Invoke();
        }
        else if(_context == null)
        {
            if (_isLoading)
            {
                return;
            }
            _isLoading = true;
            IAsyncResourceRequest request = ResourceFacade.instance.LoadPrefabAsync(_maskPath);
            request.callback = (req) =>
            {
                var maskGo = req.asset as GameObject;
                RectTransform commonBgTransform = maskGo.transform as RectTransform;
                if (commonBgTransform != null)
                {
                    commonBgTransform.name = maskPanelName;
                    Transform popupRoot = UIUtil.GetPopupLayer(0);
                    commonBgTransform.SetParent(popupRoot);
                    commonBgTransform.anchoredPosition = Vector2.zero;
                    commonBgTransform.localScale = Vector3.one;
                    commonBgTransform.anchorMin = Vector2.zero;
                    commonBgTransform.anchorMax = Vector2.one;
                    commonBgTransform.offsetMax = Vector2.zero;
                    commonBgTransform.offsetMin = Vector2.zero;
                    _context = new MaskContext(maskGo, this.OnMaskClick);
                    _context.resId = _maskPath;
                
                    commonBgTransform.anchorMin = Vector2.zero;
                    commonBgTransform.anchorMax = Vector2.one;
                    OnLoadResource(_context);
                    _isLoading = false;
                
                    UIEventListener.OnClick(_context.clickArea).AddListener(_context.OnMaskClickProxy);
                    OnGetResource(_context);
                    callback.Invoke();
                    request.Dispose();
                    request = null;
                }

                req?.Dispose();
            };
        }
        else
        {
            OnGetResource(_context);
            callback.Invoke();
        }
        UIUtil.FitNotchForTransform(_context?.gameObject?.GetComponent<RectTransform>());
    }
    
    
    protected virtual void OnGetResource(MaskContext maskView)
    {
        
    }
    
    protected virtual void OnLoadResource(MaskContext maskView)
    {
        
    }
    

    private void ReleaseResource()
    {
        if (_context != null && _token == null)
        {
            OnReleaseResource();

            _context.gameObject.SetActive(false);
            _token = ResourceReleaseFacade.instance.Recycle(_context, DelayReleaseResource);
            _context = null;
        }
    }
    
    private void DelayReleaseResource(IResourceUnit unit, ResourceReleaseFacade.ResourceToken token)
    {
        MaskContext bg = unit as MaskContext;
        if (bg != null)
        {
            GameObject bgGo = bg.gameObject;
            if (bgGo != null && bgGo.activeSelf)//如果当前正在使用就别删了
            {
                _token = null;
                return;
            }
            bg.Dispose();
        }
        _token = null;
    }
    
    protected virtual void OnReleaseResource()
    {
        
    }

    public override void Refresh(PopupParam popupParam,bool cleanScene = false)
    {
        if (popupParam != null)
        {
            if (_targetView != popupParam.popupView)
            {
                _targetView = popupParam.popupView;
                GetResource(() =>
                {
                    if (_targetView == null)
                    {
                        ReleaseResource();
                        return;
                    }
                
                    // change depth
                    var depth = popupParam.popDepth + _orderOffset;
                    var clickHide = isClickHide(popupParam);
                    ApplyContext(popupParam.popupView, depth, clickHide);
                });
            }
        }
        else
        {
            _targetView = null;
            ReleaseResource();
            
            if (cleanScene)
            {
                _token = null;
            }
        }
    }

    private void ApplyContext(IPopupView view, int depth, bool clickHide)
    {
        _context.canvas.sortingOrder = depth;
        _context.clickable = clickHide;
        _context.canvas.enabled = true;
        OnApplyContext();
    }

    protected virtual void OnApplyContext()
    {
        
    }

    private void OnMaskClick(GameObject go, MaskContext context)
    {
        if (context != null && _targetView != null && context.clickable)
        {
            if (_targetView.maskInteractive && _targetView.onMaskClick != null)
                _targetView.onMaskClick();
        }
    }
}


