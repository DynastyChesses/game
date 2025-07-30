using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BaseScriptItemRendererView : BaseScriptView, IItemRenderer
{
    // private UIWidget _widget;
    // private bool _initWidget = false;
    
    
    /// <summary>
    /// 只作用于 CommonItemRender 模式(*)
    /// </summary>
    public bool common_item_mode_enable_recycled = false;
    /// <summary>
    /// 只作用于 CommonItemRender 模式(*)
    /// </summary>
    public string prefabPath = String.Empty;
    /// <summary>
    /// 只作用于 CommonItemRender 模式(*)
    /// </summary>
    public Action initCallBack = null;
    /// <summary>
    /// 只作用于 CommonItemRender 模式(*)
    /// </summary>
    public GameObject commonObj = null;

    /// <summary>
    /// 只作用于 CommonItemRender 模式(*)
    /// </summary>
    public void AttachParent(Transform tr)
    {
        this.gameObject.transform.SetParent(tr);
    } 

    public BaseScriptItemRendererView()
    {
    }

    public override void Replace(GameObject viewObj)
    {
        //base.Replace(viewObj);
        SetObjectAndViewSkin(viewObj);

        if (_viewSkin != null)
        {
            UIEventListener.OnClick(_viewSkin.gameObject).AddListener(OnClick);
            UIEventListener.OnDragBegin(_viewSkin.gameObject).AddListener(OnDragBegin);
            UIEventListener.OnDrag(_viewSkin.gameObject).AddListener(OnDrag);
            UIEventListener.OnDragEnd(_viewSkin.gameObject).AddListener(OnDragEnd);
        }
    }

    public override void Dispose()
    {
        if (_viewSkin != null)
        {
            UIEventListener.OnClick(_viewSkin.gameObject).RemoveListener(OnClick);
            UIEventListener.OnDragBegin(_viewSkin.gameObject).RemoveListener(OnDragBegin);
            UIEventListener.OnDrag(_viewSkin.gameObject).RemoveListener(OnDrag);
            UIEventListener.OnDragEnd(_viewSkin.gameObject).RemoveListener(OnDragEnd);
        }
        
        //
        if (common_item_mode_enable_recycled && gameObject != null)
        {
            // 直接回收到 ResourcePool
            ResourcePool.Push<GameObject>(this.gameObject);
            this.gameObject.transform.localScale = Vector3.one;
        }

        initCallBack = null;
        commonObj = null;
        
        base.Dispose();
    }

    public virtual void Refresh()
    {

    }

    public virtual GameObject viewObject
    {
        get
        {
            return gameObject;
        }
    }

    public virtual object data
    {
        get;
        set;
    }

    public virtual int index
    {
        get;
        set;
    }

    public virtual bool selected
    {
        get;
        set;
    }

    public virtual bool selectable
    {
        get;
        set;
    }

    public virtual IItemRendererHost host
    {
        get;
        set;
    }

    private bool _isSizeDirty = true;
    public Vector3 center { get; }

    public void MarkSizeDirty()
    {
        _isSizeDirty = true;
    }

    private Vector2 _size;
    public virtual Vector2 size
    {
        get
        {
            if (_isSizeDirty)
            {
                _size = CalculateItemRendererSize();
                _isSizeDirty = false;
            }
            return _size;
        }
    }

    public virtual void OnUpdate()
    {

    }

    /// <summary>
    /// Drag the object along the plane.
    /// </summary>

    void OnDrag(GameObject go, PointerEventData pointerEventData)
    {
        if (host != null && this.gameObject.activeInHierarchy)
        {
            host.OnItemEventRaised(this, ItemRendererEventNames.DRAG, pointerEventData);
        }
        DoDrag(pointerEventData);
    }


    private void OnDragBegin(GameObject go, PointerEventData pointerEventData)
    {
        if (host != null && this.gameObject.activeInHierarchy)
        {
            host.OnItemEventRaised(this, ItemRendererEventNames.DRAGBEGIN, pointerEventData);
        }
        DoDragBegin(pointerEventData);
    }

    private void OnDragEnd(GameObject go, PointerEventData pointerEventData)
    {
        if (host != null && this.gameObject.activeInHierarchy)
        {
            host.OnItemEventRaised(this, ItemRendererEventNames.DRAGEND, pointerEventData);
        }
        DoDragEnd(pointerEventData);
    }

    protected virtual void DoDrag(PointerEventData pointerEventData)
    {

    }
    protected virtual void DoDragBegin(PointerEventData pointerEventData)
    {

    }
    protected virtual void DoDragEnd(PointerEventData pointerEventData)
    {

    }
    void OnClick(GameObject go)
    {
        if (host != null && enabled && this.gameObject.activeInHierarchy)
        {
            host.OnItemEventRaised(this, ItemRendererEventNames.CLICK, null);
        }
        DoClick(go);
    }

    protected virtual void DoClick(GameObject go)
    {

    }

    private Vector2 CalculateItemRendererSize()
    {
        Transform t = gameObject.transform;
        Bounds b = UIMath.BOUNDS(t);
        Vector3 scale = t.localScale;
        b.min = Vector3.Scale(b.min, scale);
        b.max = Vector3.Scale(b.max, scale);
        return b.size;
    }
}
