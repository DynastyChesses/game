
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickEventTrigger : MonoBehaviour,IPointerClickHandler,IEventTrigger<UIEventListener.VoidDelegate>
{
    public UIEventListener.VoidDelegate onClick;
    public float clickInterval = 0.1f;
    private double _lastClickTime = -1f;
    public bool messageDisabled = false;
    
    public static IEventTrigger<UIEventListener.VoidDelegate> Get(GameObject go)
    {
        ClickEventTrigger listener = go.GetComponent<ClickEventTrigger>();
        if (listener == null) listener = go.AddComponent<ClickEventTrigger>();
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
            onClick(gameObject);
        }
    }

    public void AddListener(UIEventListener.VoidDelegate t)
    {
        onClick += t;
    }
    public void RemoveListener(UIEventListener.VoidDelegate t)
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
