using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressEventTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    , IEventTrigger<UIEventListener.BoolDelegate>
{
    public UIEventListener.BoolDelegate onDown;

    public static IEventTrigger<UIEventListener.BoolDelegate> Get(GameObject go)
    {
        PressEventTrigger listener = go.GetComponent<PressEventTrigger>();
        if (listener == null) listener = go.AddComponent<PressEventTrigger>();
        return listener;
    }

    private void OnDestroy()
    {
        RemoveListener();
    }

    public void AddListener(UIEventListener.BoolDelegate t)
    {
        onDown += t;
    }

    public void RemoveListener()
    {
        onDown = null;
    }

    public void RemoveListener(UIEventListener.BoolDelegate t)
    {
        onDown -= t;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null)
            onDown(gameObject, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (onDown != null)
            onDown(gameObject, false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (onDown != null)
            onDown(gameObject, false);
    }
}