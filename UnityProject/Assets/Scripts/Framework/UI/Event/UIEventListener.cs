using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class UIEventListener {

    public delegate void VoidDelegate (GameObject go);
    public delegate void BoolDelegate(GameObject go, bool state);
    public delegate void FloatDelegate(GameObject go, float delta);
    public delegate void VectorDelegate(GameObject go, Vector2 delta);
    public delegate void ObjectDelegate(GameObject go, GameObject obj);
    public delegate void KeyCodeDelegate(GameObject go, KeyCode key);
    public delegate void PointerEventDataDelegate(GameObject go, PointerEventData data);
    

    public static IEventTrigger<PointerEventDataDelegate> OnDrag(GameObject go)
    {
        return DragEventTrigger.Get(go);
    }
    
    public static IEventTrigger<PointerEventDataDelegate> OnPointerDown(GameObject go)
    {
        return PointDownEventTrigger.Get(go);
    }
    
    public static IEventTrigger<PointerEventDataDelegate> OnPointerUp(GameObject go)
    {
        return PointUpEventTrigger.Get(go);
    }
    
    public static IEventTrigger<PointerEventDataDelegate> OnDragBegin(GameObject go)
    {
        return DragBeginEventTrigger.Get(go);
    }
    
    public static IEventTrigger<PointerEventDataDelegate> OnDragEnd(GameObject go)
    {
        return DragEndTrigger.Get(go);
    }

    public static IEventTrigger<PointerEventDataDelegate> OnClickWithEventData(GameObject go)
    {
        return ClickEventWithDataTrigger.Get(go);
    }
    
    public static IEventTrigger<VoidDelegate> OnClick(GameObject go)
    {
        return ClickEventTrigger.Get(go);
    }

    public static IEventTrigger<VoidDelegate> OnLongClick(GameObject go)
    {
        return LongClickEventTrigger.Get(go);
    }

    public static IEventTrigger<BoolDelegate> OnPress(GameObject go)
    {
        return PressEventTrigger.Get(go);
    }
    public static IEventTrigger<BoolDelegate> OnLongPress(GameObject go)
    {
        return LongPressEventTrigger.Get(go);
    }
}

