using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEventWithDataTrigger: MonoBehaviour,IPointerClickHandler,IEventTrigger<UIEventListener.PointerEventDataDelegate>
{
    public UIEventListener.PointerEventDataDelegate onClick;
    public float clickInterval = 0.1f;
    private double _lastClickTime = -1f;
    public bool messageDisabled = false;
    
    public static IEventTrigger<UIEventListener.PointerEventDataDelegate> Get(GameObject go)
    {
        ClickEventWithDataTrigger listener = go.GetComponent<ClickEventWithDataTrigger>();
        if (listener == null) listener = go.AddComponent<ClickEventWithDataTrigger>();
        return listener;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (messageDisabled || RealTimer.elapsedSeconds - _lastClickTime < clickInterval)
        {
            return;
        }
        if (onClick != null)
        {
            _lastClickTime = RealTimer.elapsedSeconds;
            onClick(gameObject,eventData);
        }
    }

    public void AddListener(UIEventListener.PointerEventDataDelegate t)
    {
        onClick += t;
    }
    public void RemoveListener(UIEventListener.PointerEventDataDelegate t)
    {
        onClick -= t;
    }
    public void RemoveListener()
    {
        onClick = null;
    }

    private void OnDestroy()
    {
        RemoveListener();
    }
}
