
using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointUpEventTrigger: MonoBehaviour,
    IPointerUpHandler,
    IEventTrigger<UIEventListener.PointerEventDataDelegate>
{
    public UIEventListener.PointerEventDataDelegate onPointUp;

    public static IEventTrigger<UIEventListener.PointerEventDataDelegate> Get(GameObject go)
    {
        PointUpEventTrigger listener = go.GetComponent<PointUpEventTrigger>();
        if (listener == null) listener = go.AddComponent<PointUpEventTrigger>();
        return listener;
    }


    private void OnDestroy()
    {
        RemoveListener();
    }

    public void AddListener(UIEventListener.PointerEventDataDelegate t)
    {
        onPointUp += t;
    }
    public void RemoveListener()
    {
        onPointUp = null;
    }
    public void RemoveListener(UIEventListener.PointerEventDataDelegate t)
    {
        onPointUp -= t;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(onPointUp != null) onPointUp(gameObject,eventData);
    }
}
