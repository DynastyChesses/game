
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class EventManager
{
    /// <summary>
    /// 事件占用
    /// </summary>
    public static bool useEvent = false;
    
    private List<IEvent>[] eventArr;

    public EventManager(int priorityNum = 10)
    {
        eventArr = new List<IEvent>[priorityNum];
        InitEasyTouch();
    }
    
    public void Dispose()
    {
        eventArr = null;
        DisposeEasyTouch();
    }

    // 判定在显示区域内（居中显示时有用）
    private bool InDisplayArea(Vector2 screenPos)
    {
        var cam = UIManager.instance.mainCamera;
        if (cam == null) return false;
        if (cam.rect.width < 1f || cam.rect.height < 1f)
        {
            var dx = screenPos.x / Screen.width;
            var dy = screenPos.y / Screen.height;
            return dx >= cam.rect.x && dx <= cam.rect.x + cam.rect.width &&
                   dy >= cam.rect.y && dy <= cam.rect.y + cam.rect.height;
        }
        return true;
    }
    
    private void InitEasyTouch()
    {
        EasyTouch.instance.longTapTime = 0.5f;
        EasyTouch.SetUICompatibily(true);
        
        EasyTouch.On_SimpleTap += EasyTouch_On_SimpleTap;
        EasyTouch.On_LongTapStart += EasyTouch_OnLongTapStart;
        EasyTouch.On_LongTapEnd += EasyTouch_OnLongTapEnd;

        EasyTouch.On_SwipeStart += EasyTouch_On_SwipeStart;
        EasyTouch.On_SwipeEnd += EasyTouch_On_SwipeEnd;
        EasyTouch.On_Swipe += EasyTouch_On_Swipe;
        
        EasyTouch.On_DragStart += EasyTouch_On_DragStart;
        EasyTouch.On_DragEnd += EasyTouch_On_DragEnd;
        EasyTouch.On_Drag += EasyTouch_On_Drag;
        
        EasyTouch.On_PinchIn += EasyTouch_On_PinchIn;
        EasyTouch.On_PinchOut += EasyTouch_On_PinchOut;
        EasyTouch.On_PinchEnd += EasyTouch_On_PinchEnd;

        EasyTouch.On_UIElementTouchUp += EasyTouch_On_UIElementTouchUp;
        EasyTouch.On_TouchStart       += EasyTouch_On_TouchStart;
        EasyTouch.On_TouchDown       += EasyTouch_On_TouchDown;
        EasyTouch.On_TouchUp       += EasyTouch_On_TouchUp;

        // EasyTouch.instance.eventInterceptor = DebugInterceptor;
    }

    private void DisposeEasyTouch()
    {
        EasyTouch.On_SimpleTap -= EasyTouch_On_SimpleTap;
        EasyTouch.On_LongTapStart -= EasyTouch_OnLongTapStart;
        EasyTouch.On_LongTapEnd -= EasyTouch_OnLongTapEnd;

        EasyTouch.On_SwipeStart -= EasyTouch_On_SwipeStart;
        EasyTouch.On_SwipeEnd -= EasyTouch_On_SwipeEnd;
        EasyTouch.On_Swipe -= EasyTouch_On_Swipe;
        
        EasyTouch.On_DragStart -= EasyTouch_On_DragStart;
        EasyTouch.On_DragEnd -= EasyTouch_On_DragEnd;
        EasyTouch.On_Drag -= EasyTouch_On_Drag;

        EasyTouch.On_PinchIn -= EasyTouch_On_PinchIn;
        EasyTouch.On_PinchOut -= EasyTouch_On_PinchOut;
        EasyTouch.On_PinchEnd -= EasyTouch_On_PinchEnd;

        EasyTouch.On_UIElementTouchUp -= EasyTouch_On_UIElementTouchUp;
        EasyTouch.On_TouchStart       -= EasyTouch_On_TouchStart;
        EasyTouch.On_TouchDown       -= EasyTouch_On_TouchDown;
        EasyTouch.On_TouchUp       -= EasyTouch_On_TouchUp;
    }

    public void AddEvent(IEvent customEvent)
    {
        var priority = Mathf.Clamp(customEvent.priority, 0, 9);
        
        if (eventArr[priority] == null)
            eventArr[priority] = new List<IEvent>();
        
        if (eventArr[priority].Contains(customEvent))
            return;
        
        eventArr[priority].Add(customEvent);
    }

    public void RemoveEvent(IEvent customEvent)
    {
        foreach (var list in eventArr)
        {
            if (list != null && list.Contains(customEvent))
                list.Remove(customEvent);
        }
    }

    #region Event

    /// <summary>
    /// 点击
    /// </summary>
    /// <param name="gesture"></param>
    void EasyTouch_On_SimpleTap(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnSimpleTap(gesture);
                }
            }
        }
        
        useEvent = false;
    }
    
    /// <summary>
    /// 长按
    /// </summary>
    /// <param name="gesture"></param>
    void EasyTouch_OnLongTapStart(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnLongTap(gesture);
                }
            }
        }
        
        useEvent = false;
    }

    void EasyTouch_OnLongTapEnd(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnLongTapEnd(gesture);
                }
            }
        }
        useEvent = false;
    }
    
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="gesture"></param>
    void EasyTouch_On_DragStart(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        if (gesture.touchCount > 1)
        {
            return;
        }
        
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnStartDrag(gesture);
                }
            }
        }
        useEvent = false;
    }
    
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="gesture"></param>
    void EasyTouch_On_DragEnd(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        if (gesture.touchCount > 1)
        {
            return;
        }
        
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnEndDrag(gesture);
                }
            }
        }
        
        useEvent = false;
    }
    
    /// <summary>
    /// 拖拽中
    /// </summary>
    /// <param name="gesture"></param>
    void EasyTouch_On_Drag(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        if (gesture.touchCount > 1)
        {
            return;
        }
        
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnDrag(gesture);
                }
            }
        }

        useEvent = false;
    }

    /// <summary>
    /// 向内缩放
    /// 缩放时不允许其他操作，所以不取消事件占用
    /// </summary>
    /// <param name="gesture"></param>
    private void EasyTouch_On_PinchIn(Gesture gesture)
    {
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnPinchIn(gesture);
                }
            }
        }

        useEvent = false;
    }

    /// <summary>
    /// 向外缩放
    /// 缩放时不允许其他操作，所以不取消事件占用
    /// </summary>
    /// <param name="gesture"></param>
    private void EasyTouch_On_PinchOut(Gesture gesture)
    {
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnPinchOut(gesture);
                }
            }
        }

        useEvent = false;
    }

    /// <summary>
    /// 缩放结束
    /// </summary>
    /// <param name="gesture"></param>
    private void EasyTouch_On_PinchEnd(Gesture gesture)
    {
        foreach (var list in eventArr)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnPinchEnd(gesture);
                }
            }
        }

        useEvent = false;
    }
    
    private void EasyTouch_On_SwipeStart(Gesture gesture)
    {
        EasyTouch_On_DragStart(gesture);
    }
    
    private void EasyTouch_On_Swipe(Gesture gesture)
    {
        EasyTouch_On_Drag(gesture);
    }
    
    private void EasyTouch_On_SwipeEnd(Gesture gesture)
    {
        EasyTouch_On_DragEnd(gesture);
    }

    private void EasyTouch_On_UIElementTouchUp(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnUIElementTouchUp(gesture);
                }
            }
        }

        useEvent = false;
    }

    private void EasyTouch_On_TouchStart(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnTouchStart(gesture);
                }
            }
        }
        useEvent = false;
        
    }
    private void EasyTouch_On_TouchDown(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnTouchDown(gesture);
                }
            }
        }
        useEvent = false;
        
    }
    private void EasyTouch_On_TouchUp(Gesture gesture)
    {
        if (!InDisplayArea(gesture.position)) return;
        foreach (var list in eventArr)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var evn in list)
                {
                    if (useEvent)
                        break;
                    evn.OnTouchUp(gesture);
                }
            }
        }
        useEvent = false;
        
    }
    
    #endregion
    
}