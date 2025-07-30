using System.Collections.Generic;
using UnityEngine;

public class AddMaskPopupMultiAction : BasePopupAction
{
    class MaskPanelBgContext
    {
        public IPopupView view;
        public int depth;
        public bool idFullScreen;
        public bool clickHide;
        private static Queue<MaskPanelBgContext> _pool = new Queue<MaskPanelBgContext>();

        public static MaskPanelBgContext Allocate()
        {
            if (_pool.Count > 0)
            {
                return _pool.Dequeue();
            }
            return new MaskPanelBgContext();
        }

        public static void Release(MaskPanelBgContext context)
        {
            context.view = null;
            context.depth = 0;
            context.clickHide = true;
            context.idFullScreen = false;
            _pool.Enqueue(context);
        }
    }

    private const int Z_MASK_INCREMENT = 3;

    protected string _maskPath;

    protected virtual string maskPanelName
    {
        get
        {
            return "MaskPanel";
        }
    }

    public AddMaskPopupMultiAction(uint popupMode, string maskPath) : base(popupMode)
    {
        _maskPath = maskPath;
    }

    private IAsyncResourceRequest _prefabReq = null;
    private List<MaskPanelBgContext> _depthList = new List<MaskPanelBgContext>();
    private Dictionary<int, MaskPanelBgContext> _depthPanelMap = new Dictionary<int, MaskPanelBgContext>();
    protected MaskContext _context = null;
    private ResourceReleaseFacade.ResourceToken _token = null;

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

    protected virtual void OnMaskFirstShow()
    {

    }

    protected virtual void OnMaskFinalHide(bool forceClean)
    {

    }

    protected virtual void OnStartLoadResource(IPopupView maskView)
    {
        
    }
    protected virtual void OnLoadResource(MaskContext maskView)
    {
        
    }

    private static List<PopupParam> _popupParamsCache = null;
    public override void ExecuteBeforeShow(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {
        if (popupRoot != null && view != null)
        {
            if (_depthPanelMap.Count == 0)
            {
                if (_token != null)
                {
                    ResourceReleaseFacade.instance.Acquire(_token);
                    if (_context == null || _context.gameObject == null)
                    {
                        Logger.Error($"ExecuteBeforeShow _context.gameObject == null view = {view?.name}");
                    }
                    _context?.gameObject?.SetActive(true);
                    if (popupParam != null && _context != null)
                    {
                        _context.isFullScreen = popupParam.isFullScreen;
                    }
                    else
                    {
                        Logger.Error($"ExecuteBeforeShow popupParam == null || _context == null view = {view?.name}");
                    }
                    _token = null;
                    DoRefreshMask(view,popupParam);
                }
                else
                {
                    if (_popupParamsCache == null)
                    {
                        _popupParamsCache = new List<PopupParam>();
                    }
                    _popupParamsCache.Add(popupParam);//缓存起来
                    _prefabReq?.Dispose();
                    _prefabReq = null;
                    _prefabReq = ResourceFacade.instance.LoadPrefabAsync(_maskPath);
                    OnStartLoadResource(view);
                    _prefabReq.callback = request =>
                    {
                        if (request == null || request.asset == null)
                        {
                            Logger.Error($"ExecuteBeforeShow maskGo Load prefab failed view{view?.name} path = {_maskPath}");
                            return;
                        }
                        GameObject maskGo = request.asset as GameObject;
                        if (maskGo == null)
                        {
                            Logger.Error($"ExecuteBeforeShow maskGo == null view = {view?.name} path = {_maskPath}");
                            return;
                        }
                        RectTransform commonBgTransform = maskGo.transform as RectTransform;
                        if (commonBgTransform != null)
                        {
                            commonBgTransform.name = maskPanelName;
                            commonBgTransform.SetParent(popupRoot);
                            commonBgTransform.anchoredPosition = Vector2.zero;
                            commonBgTransform.localScale = Vector3.one;
                            commonBgTransform.anchorMin = Vector2.zero;
                            commonBgTransform.anchorMax = Vector2.one;
                            commonBgTransform.offsetMax = Vector2.zero;
                            commonBgTransform.offsetMin = Vector2.zero;
                            _context = new MaskContext(maskGo, this.OnMaskClick);
                            _context.resId = _maskPath;
                            _context.view = view;
                            if (popupParam != null)
                            {
                                _context.isFullScreen = popupParam.isFullScreen;
                            }
                            else
                            {
                                Logger.Error($"ExecuteBeforeShow isFullScreen init context ===== popupParam = null view = {view?.name}");
                            }
                            commonBgTransform.anchorMin = Vector2.zero;
                            commonBgTransform.anchorMax = Vector2.one;
                            OnLoadResource(_context);
                            if (_popupParamsCache.Count > 1)
                            {
                                for (int i = 0; i < _popupParamsCache.Count; i++)
                                {
                                    var param = _popupParamsCache[i];
                                    DoRefreshMask( param.popupView,  param);//首次加载不要blur了
                                }
                            }
                            else
                            {
                                DoRefreshMask( view,  popupParam, false, true);
                            }

                            _popupParamsCache.Clear();
                        }
                    };
                }
                OnMaskFirstShow();
            }
            else
            {
                DoRefreshMask( view,  popupParam); 
            }
        }
    }

    private void DoRefreshMask(IPopupView view, PopupParam popupParam, bool blur = true, bool onloadTime = false)
    {
        if (view == null )
        {
            return;
        }
        if ( onloadTime && view.visible == false)
        {
            _context?.gameObject?.SetActive(false);
            return;
        }
        MaskPanelBgContext depthContext = MaskPanelBgContext.Allocate();
        if (popupParam != null)
        {
            depthContext.depth = popupParam.popDepth - Z_MASK_INCREMENT;
            depthContext.clickHide = isClickHide(popupParam);
            depthContext.idFullScreen = popupParam.isFullScreen;
            if (_context != null)
            {
                _context.isFullScreen = popupParam.isFullScreen;
            }
        }
        else
        {
            Logger.Error($"ExecuteBeforeShow check isClickHide ===== popupParam = null view = {view?.name}");
        }
        depthContext.view = view;
        _depthPanelMap[view.popupId] = depthContext;
        _depthList.Add(depthContext);
        for (int i = _depthList.Count - 1; i > 0; i--)
        {
            if (_depthList[i].depth < _depthList[i - 1].depth)
            {
                (_depthList[i], _depthList[i - 1]) = (_depthList[i - 1], _depthList[i]);
            }
        }
        if (_context != null)
        {
            ApplyContext(_depthList[_depthList.Count - 1],false,blur);
        }
    }

    public override void ExecuteAfterShow(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {

    }
    

    private void ApplyContext(MaskPanelBgContext ctx, bool hide = false, bool blur = true)
    {
        // 保护性处理+日志 重构一下context 防止意外情况销毁了
        if (_context == null)
        {
            if (ctx != null && ctx.view != null)
            {
                _prefabReq?.Dispose();
                _prefabReq = null;
                _prefabReq = ResourceFacade.instance.LoadPrefabAsync(_maskPath);
                _prefabReq.callback = request =>
                {
                    if (request == null || request.asset == null)
                    {
                        return;
                    }
                    GameObject maskGo = request.asset as GameObject;
                    if (maskGo == null)
                    {
                        return;
                    }
                    RectTransform commonBgTransform = maskGo.transform as RectTransform;
                    if (commonBgTransform != null)
                    {
                        commonBgTransform.name = maskPanelName;
                        commonBgTransform.SetParent(ctx.view.parent);
                        commonBgTransform.anchoredPosition = Vector2.zero;
                        commonBgTransform.localScale = Vector3.one;
                        commonBgTransform.anchorMin = Vector2.zero;
                        commonBgTransform.anchorMax = Vector2.one;
                        commonBgTransform.offsetMax = Vector2.zero;
                        commonBgTransform.offsetMin = Vector2.zero;
                        
                        _context = new MaskContext(maskGo, this.OnMaskClick);
                        _context.resId = _maskPath;
                        
                        _context.canvas.sortingOrder = ctx.depth;
                        _context.view = ctx.view;
                        _context.isFullScreen = ctx.idFullScreen;
                        OnLoadResource(_context);
                        OnApplyContext(hide,blur);
                        if (_context.clickArea) UIEventListener.OnClick(_context.clickArea).RemoveListener();
                        if (ctx.clickHide)
                        {
                            if (_context.clickArea) UIEventListener.OnClick(_context.clickArea).AddListener(_context.OnMaskClickProxy);
                        }
                    }
                };
                Logger.Error($"AddMaskPopupMultiAction.ApplyContext Context Is Null And Has been Restructed!");
            }
            else
            {
                Logger.Error($"AddMaskPopupMultiAction.ApplyContext ctx.view is NUll!");
            }
            return;
        }

        _context.canvas.sortingOrder = ctx.depth;
        _context.view = ctx.view;
        _context.isFullScreen = ctx.idFullScreen;
        OnApplyContext(hide,blur);
        if (_context.clickArea) UIEventListener.OnClick(_context.clickArea).RemoveListener();
        if (ctx.clickHide)
        {
            if (_context.clickArea) UIEventListener.OnClick(_context.clickArea).AddListener(_context.OnMaskClickProxy);
        }
    }
    protected virtual void OnApplyContext(bool hide = false,bool blur = true)
    {
        
    }

    public override void ExecuteAfterHide(Transform popupRoot, IPopupView view, PopupParam popupParam)
    {
        if (!_depthPanelMap.ContainsKey(view.popupId))
        {
            return;
        }
        MaskPanelBgContext delDepthContext = _depthPanelMap[view.popupId];
        _depthPanelMap.Remove(view.popupId);
        int delIndex = _depthList.IndexOf(delDepthContext);
        _depthList.RemoveAt(delIndex);
        MaskPanelBgContext.Release(delDepthContext);

        if (_depthList.Count == 0)
        {
            if (_context != null)
            {
                OnMaskFinalHide(false);
                _context.gameObject.SetActive(false);
                UIEventListener.OnClick(_context.clickArea).RemoveListener();
                _token = ResourceReleaseFacade.instance.Recycle(_context, DelayReleaseTexture);
            }
            else
            {
                Logger.Info("[UIHide] ExecuteAfterHide 1 _context is null.", null, LogTargetType.Runtime | LogTargetType.Network);
            }
        }
        else if (_context != null)
        {
            ApplyContext(GetMaxDepthPanelBgContext(view),true);
        }
        else
        {
            Logger.Info("[UIHide] ExecuteAfterHide 2 _context is null.", null, LogTargetType.Runtime | LogTargetType.Network);
        }
    }

    public override void ClearAction(bool cleanScene)
    {
        foreach (var depth in _depthList)
        {
            MaskPanelBgContext.Release(depth);
        }
        _depthPanelMap.Clear();
        _depthList.Clear();
        if (_context != null)
        {
            OnMaskFinalHide(cleanScene);
            _context.gameObject.SetActive(false);
            UIEventListener.OnClick(_context.clickArea).RemoveListener();
            _token = ResourceReleaseFacade.instance.Recycle(_context, DelayReleaseTexture);
        }
    }

    public override void Refresh(IPopupView view, PopupParam popupParam)
    {
        if (view == null && popupParam == null)
        {
            ClearAction(false);
            return;
        }
        if (!_depthPanelMap.ContainsKey(view.popupId))
        {
            return;
        }
        MaskPanelBgContext curViewDepthContext = _depthPanelMap[view.popupId];
        if (curViewDepthContext == GetMaxDepthPanelBgContext(null))
        {
            curViewDepthContext.depth = popupParam.popDepth - Z_MASK_INCREMENT;
            ApplyContext(curViewDepthContext);
        }
    }

    private void OnMaskClick(GameObject go, MaskContext context)
    {
        if (context != null)
        {
            if (context.view != null && context.view.maskInteractive && context.view.onMaskClick != null)
            {
                context.view.onMaskClick();
            }
        }
    }

    private void DelayReleaseTexture(IResourceUnit unit, ResourceReleaseFacade.ResourceToken token)
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
       
        _prefabReq?.Dispose();
        _prefabReq = null;
        
        _context = null;
        _token = null;
    }

    private MaskPanelBgContext GetMaxDepthPanelBgContext(IPopupView hidingView)
    {
        MaskPanelBgContext maskContext = null;
        for (int i = 0; i < _depthList.Count; i++)
        {
            if (hidingView != null && _depthList[i].view.popupId == hidingView.popupId)
            {
                continue;
            }
            if (maskContext == null)
            {
                maskContext = _depthList[i];
            }
            else if(maskContext.view.depth < _depthList[i].view.depth)
            {
                maskContext = _depthList[i];
            }
        }
        return maskContext;
    }
}


