using System;
using UnityEngine;

/// <summary>
/// Event Hook class lets you easily add remote event listener functions to an object.
/// Example usage: MonoEventListener.Get(gameObject).onEnable += MyEnableFunction;
/// </summary>

[AddComponentMenu("Mono Visible Event Listener")]
public class MonoVisibleEventListener : MonoBehaviour
{
    public Action<GameObject> onEnable;
    public Action<GameObject> onDisable;
    public Action<GameObject> onDestroy;

    void OnEnable ()                { if (onEnable != null) onEnable(gameObject); }
    void OnDisable ()               { if (onDisable != null) onDisable(gameObject); }

    void OnDestroy()
    {
        if (onDestroy != null) onDestroy(gameObject);
        onEnable = null;
        onDisable = null;
        onDestroy = null;
    }
    
    /// <summary>
    /// Get or add an event listener to the specified game object.
    /// </summary>
    
    static public MonoVisibleEventListener Get (GameObject go)
    {
        MonoVisibleEventListener listener = go.GetComponent<MonoVisibleEventListener>();
        if (listener == null) listener = go.AddComponent<MonoVisibleEventListener>();
        return listener;
    }
}
