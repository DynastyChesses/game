using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointDownEventTrigger: MonoBehaviour,
    IPointerDownHandler,
    IEventTrigger<UIEventListener.PointerEventDataDelegate>
{
    public UIEventListener.PointerEventDataDelegate onPointDown;

    public static IEventTrigger<UIEventListener.PointerEventDataDelegate> Get(GameObject go)
    {
        PointDownEventTrigger listener = go.GetComponent<PointDownEventTrigger>();
        if (listener == null) listener = go.AddComponent<PointDownEventTrigger>();
        return listener;
    }

    private void OnDestroy()
    {
        RemoveListener();
    }

    public void AddListener(UIEventListener.PointerEventDataDelegate t)
    {
        onPointDown += t;
    }
    public void RemoveListener()
    {
        onPointDown = null;
    }
    public void RemoveListener(UIEventListener.PointerEventDataDelegate t)
    {
        onPointDown -= t;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(onPointDown != null) onPointDown(gameObject,eventData);
    }
}
