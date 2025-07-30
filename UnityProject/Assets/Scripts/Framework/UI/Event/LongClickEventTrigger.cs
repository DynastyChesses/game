using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongClickEventTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    , IEventTrigger<UIEventListener.VoidDelegate>
{
    public UIEventListener.VoidDelegate onLongClick;

    public static IEventTrigger<UIEventListener.VoidDelegate> Get(GameObject go)
    {
        LongClickEventTrigger listener = go.GetComponent<LongClickEventTrigger>();
        if (listener == null) listener = go.AddComponent<LongClickEventTrigger>();
        return listener;
    }

    private void OnDestroy()
    {
        RemoveListener();
    }

    public void AddListener(UIEventListener.VoidDelegate t)
    {
        onLongClick += t;
    }

    public void RemoveListener()
    {
        onLongClick = null;
    }

    public void RemoveListener(UIEventListener.VoidDelegate t)
    {
        onLongClick -= t;
    }

    private float _longTime = 0.5f;
    private bool _isPress = false;
    private float _timer = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        _timer = 0f;
        _isPress = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPress = false;
        _timer = 0;
    }

    private void Update()
    {
        if (_isPress)
        {
            _timer += Time.unscaledDeltaTime;
            if (_timer >= _longTime)
            {
                if (onLongClick != null)
                    onLongClick(gameObject);
                _isPress = false;
                _timer = 0;
            }
        }
    }
}