using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongPressEventTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler
    , IEventTrigger<UIEventListener.BoolDelegate>
{
    public UIEventListener.BoolDelegate onPressStateChange;
    public float longPressTime = 0.2f;
    private int _pressingState = 0; // 0 没按压，1开始按压，2长按中
    private float _pressingTime;

    public static IEventTrigger<UIEventListener.BoolDelegate> Get(GameObject go)
    {
        LongPressEventTrigger listener = go.GetComponent<LongPressEventTrigger>();
        if (listener == null) listener = go.AddComponent<LongPressEventTrigger>();
        return listener;
    }

    private void OnDestroy()
    {
        RemoveListener();
    }

    public void AddListener(UIEventListener.BoolDelegate t)
    {
        onPressStateChange += t;
    }

    public void RemoveListener()
    {
        onPressStateChange = null;
    }

    public void RemoveListener(UIEventListener.BoolDelegate t)
    {
        onPressStateChange -= t;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressingState = 1;
        _pressingTime = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_pressingState == 2)
            TriggerPress(false);
        _pressingState = 0;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_pressingState == 2)
            TriggerPress(false);
        _pressingState = 0;
    }
    void Update()
    {
        if (_pressingState == 1)
        {
            _pressingTime += Time.deltaTime;
            if (_pressingTime > longPressTime)
            {
                TriggerPress(true);
                _pressingState = 2;
            }
        }
    }
    public void TriggerPress(bool islongPress)
    {
        if (onPressStateChange != null)
            onPressStateChange(gameObject, islongPress);
    }
}