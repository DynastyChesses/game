using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class SubViewMediator : AbstractUIMediator
{
    protected BaseScriptView _baseView;
    protected RectTransform _rectTransform;

    public BaseScriptView baseView => _baseView;

    public bool _isActive;
    public override bool isActive => _isActive;

    // 记录UI面板的原始位置
    public Vector3 _orgViewPos = Vector3.zero;

    // 预加载调度器
    public int _preloadScheduler = EquineScheduler.INVALID;

    public SubViewMediator(string mediatorName) : base(mediatorName)
    {
    }

    public abstract void CreateView(Transform container, object data, bool preload = false);

    protected abstract void OnCreateView();
    

    public void ShowView(Transform container, object data, bool preload = false)
    {
        if (_isActive)
        {
            return;
        }

        // 有预加载调度器时移除
        if (_preloadScheduler != EquineScheduler.INVALID)
        {
            EquineScheduler.RemoveLimitUpdator(ref _preloadScheduler);
            _preloadScheduler = EquineScheduler.INVALID;
        }

        if (null == _baseView)
        {
            CreateView(container, data, preload);
        }
        else if (!preload)
        {
            // 恢复原始位置(处理预加载)
            var canvasGroup = _baseView.gameObject.GetComponent<CanvasGroup>();
            if (canvasGroup)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;
            }
            _baseView.gameObject.transform.localPosition = _orgViewPos;
            _baseView.gameObject.SetActive(true);
            OnShowView(data);
            _isActive = true;
        }
        
        
    }

    public void RefreshView(object data)
    {
        OnHideView();
        OnShowView(data);
    }

    public void HideView()
    {
        if (_isActive == false)
        {
            return;
        }

        // 有预加载调度器时移除
        if (_preloadScheduler != EquineScheduler.INVALID)
        {
            EquineScheduler.RemoveLimitUpdator(ref _preloadScheduler);
            _preloadScheduler = EquineScheduler.INVALID;
        }

        _isActive = false;
        OnHideView();

        if (null != _baseView)
        {
            _baseView.gameObject.SetActive(false);
        }
    }

    protected virtual void OnShowView(object data) { }

    protected virtual void OnHideView() { }

    public virtual void BeforeShowBaseView() { }
    public virtual void AfterShowBaseView() { }
    public virtual void BeforeHideBaseView() { }
    public virtual void AfterHideBaseView() { }

    private readonly List<IDisposable> _autoDisposeObjects = new List<IDisposable>();

    /// <summary>
    /// 注册自动释放对象
    /// </summary>
    /// <param name="obj">目标对象</param>
    /// <returns>目标对象自身</returns>
    public virtual object RegisterAutoDisposeObject(IDisposable obj)
    {
        if (obj == null) return null;
        _autoDisposeObjects.Add(obj);
        return obj;
    }

    public void Dispose()
    {
        if (null != _baseView)
        {
            OnDispose();

            // 自动释放对象处理
            foreach (var obj in _autoDisposeObjects)
            {
                obj?.Dispose();
            }
            _autoDisposeObjects.Clear();

            var go = _baseView.gameObject;
            _baseView.Dispose();
            _baseView = null;
            _isActive = false;
            if (_baseView?.helpBtn != null)
                UIEventListener.OnClick(_baseView.helpBtn).RemoveListener(HelpBtnClick);
            AfterDispose();
        }

    }

    protected void HelpBtnClick(GameObject button)
    {
        ApplicationFacade.instance.SendNotification("ShowCommonInfoPanel", _baseView.helpBtn.name);
    }

    protected virtual void OnDispose()
    {
    }
    
    protected virtual void AfterDispose()
    {
    }
}

public abstract class TSubViewMediator<T> : SubViewMediator where T : BaseScriptView
{
    // 预加载隐藏时间
    private const float PRELOAD_HIDE_TIME = 1f;

    private static readonly Vector3 MOVE_TO_SKY_POS = Vector3.up * 10000f;

    private T __view = null;
    protected T _view => __view ?? (__view = _baseView as T);

    // private Dictionary<string, IAsyncResourceRequest> subViewRequests = new Dictionary<string, IAsyncResourceRequest>();

    public TSubViewMediator(string mediatorName) : base(mediatorName)
    {
    }

    public override void CreateView(Transform container, object data, bool preload = false)
    {
        // if (subViewRequests.ContainsKey(_viewPath))
        // {
        //     return;
        // }

        void afterLoaded(GameObject go, bool isPreload)
        {
            var prefab = go;
            _baseView = (T)Activator.CreateInstance(typeof(T), new object[] { prefab });
            _rectTransform = _baseView.rectTransform;
            _rectTransform.SetParent(container);
            // CommonUtil.ResetRectTransform(_rectTransform);

            OnCreateView();

            // 若container是inactive状态说明此时主界面已经被关闭了
            if (!container.gameObject.activeSelf)
            {
                _baseView.gameObject.SetActive(false);
                _isActive = false;
                return;
            }

            _baseView.gameObject.SetActive(true);
            OnShowView(data);
            _isActive = !isPreload;

            // 记录原始位置
            if (!isPreload) _orgViewPos = _baseView.gameObject.transform.localPosition;
            if (isPreload)
            {
                // 预加载调度器, 指定时间后隐藏
                _preloadScheduler = EquineScheduler.CallOnce(PRELOAD_HIDE_TIME, (a, b, c) =>
                {
                    if (_baseView != null)
                    {
                        _baseView.gameObject.transform.localPosition = _orgViewPos;
                        _baseView.gameObject.SetActive(false);
                        OnHideView();
                    }
                    _preloadScheduler = EquineScheduler.INVALID;
                });
                var canvasGroup = _baseView.gameObject.GetComponent<CanvasGroup>();
                if (!canvasGroup)
                {
                    canvasGroup = _baseView.gameObject.AddComponent<CanvasGroup>();
                }
                if (canvasGroup)
                {
                    canvasGroup.alpha = 0;
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.interactable = false;
                }
                _baseView.gameObject.transform.localPosition = MOVE_TO_SKY_POS;
            }
            if (_baseView.helpBtn != null)
                UIEventListener.OnClick(_baseView.helpBtn).AddListener(HelpBtnClick);
        }
    }

    protected override void OnHideView()
    {
       
    }

    protected sealed override void AfterDispose()
    {
        __view = null;
    }
}