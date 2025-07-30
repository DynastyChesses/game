using System;
using UnityEngine;

/// <summary>
/// Event Hook class lets you easily add remote event listener functions to an object.
/// Example usage: MonoEventListener.Get(gameObject).onEnable += MyEnableFunction;
/// </summary>

[AddComponentMenu("Mono Event Listener")]
public class MonoEventListener : MonoBehaviour
{
    public Action<GameObject> onStart;
    public Action<GameObject> onFixedUpdate;
    public Action<GameObject> onUpdate;
    public Action<GameObject> onLateUpdate;
    public Action<GameObject> onEnable;
    public Action<GameObject> onDisable;
    public Action<GameObject> onDestroy;
    public Action<GameObject> onBecameVisible;
    public Action<GameObject> onBecameInvisible;

    void Start ()                   { if (onStart != null) onStart(gameObject); }
    void FixedUpdate ()             { if (onFixedUpdate != null) onFixedUpdate(gameObject); }
    void Update ()                  { if (onFixedUpdate != null) onFixedUpdate(gameObject); }
    void LateUpdate ()              { if (onLateUpdate != null) onLateUpdate(gameObject); }
    void OnEnable ()                { if (onEnable != null) onEnable(gameObject); }
    void OnDisable ()               { if (onDisable != null) onDisable(gameObject); }

    void OnDestroy()
    {
        if (onDestroy != null) onDestroy(gameObject);
        onStart = null;
        onFixedUpdate = null;
        onUpdate = null;
        onLateUpdate = null;
        onEnable = null;
        onDisable = null;
        onDestroy = null;
        onBecameVisible = null;
        onBecameInvisible = null;
    }
    void OnBecameVisible ()         { if (onBecameVisible != null) onBecameVisible(gameObject); }
    void OnBecameInvisible ()       { if (onBecameInvisible != null) onBecameInvisible(gameObject); }
    
    /// <summary>
    /// Get or add an event listener to the specified game object.
    /// </summary>
    
    static public MonoEventListener Get (GameObject go)
    {
        MonoEventListener listener = go.GetComponent<MonoEventListener>();
        if (listener == null) listener = go.AddComponent<MonoEventListener>();
        return listener;
    }
}
