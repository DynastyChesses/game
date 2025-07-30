
public interface IEvent
{
    int  priority { get; }
    void OnSimpleTap(Gesture        gesture);
    void OnLongTap(Gesture          gesture);
    void OnLongTapEnd(Gesture       gesture);
    void OnStartDrag(Gesture        gesture);
    void OnDrag(Gesture             gesture);
    void OnEndDrag(Gesture          gesture);
    void OnPinchIn(Gesture          gesture);
    void OnPinchOut(Gesture         gesture);
    void OnPinchEnd(Gesture         gesture);
    void OnUIElementTouchUp(Gesture gesture);

    void OnTouchStart(Gesture gesture);
    void OnTouchDown(Gesture  gesture);
    void OnTouchUp(Gesture    gesture);
}

public abstract class BaseTouchEvent : IEvent
{
    public abstract int priority { get; }

    /// <summary>
    /// 点击
    /// </summary>
    /// <param name="gesture"></param>
    public virtual void OnSimpleTap(Gesture gesture)
    {
    }

    /// <summary>
    /// 长按
    /// </summary>
    /// <param name="gesture"></param>
    public virtual void OnLongTap(Gesture gesture)
    {
    }

    public virtual void OnLongTapEnd(Gesture gesture)
    {
    }

    /// <summary>
    /// 拖拽开始
    /// </summary>
    /// <param name="gesture"></param>
    public virtual void OnStartDrag(Gesture gesture)
    {
    }

    /// <summary>
    /// 拖拽中
    /// </summary>
    /// <param name="gesture"></param>
    public virtual void OnDrag(Gesture gesture)
    {
    }

    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="gesture"></param>
    public virtual void OnEndDrag(Gesture gesture)
    {
    }

    public virtual void OnPinchIn(Gesture gesture)
    {
    }

    public virtual void OnPinchOut(Gesture gesture)
    {
    }

    public virtual void OnPinchEnd(Gesture gesture)
    {
    }

    public virtual void OnUIElementTouchUp(Gesture gesture)
    {
    }

    public virtual void OnTouchStart(Gesture gesture)
    {
    }

    public virtual void OnTouchDown(Gesture gesture)
    {
    }

    public virtual void OnTouchUp(Gesture gesture)
    {
    }
}