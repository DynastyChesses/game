using System;
using UnityEngine;

[AddComponentMenu("Animation Event Listener")]
public class AnimationEventListener : MonoBehaviour
{
    public delegate void VoidFrameEventDelegate ();
    public delegate void FloatFrameEventDelegate(float param);
    public delegate void IntFrameEventDelegate(int param);
    public delegate void StringFrameEventDelegate(string param);
    public delegate void ObjectFrameEventDelegate(object param);

    public VoidFrameEventDelegate onVoidFrame;
    public FloatFrameEventDelegate onFloatFrame;
    public IntFrameEventDelegate onIntFrame;
    public StringFrameEventDelegate onStringFrame;
    public ObjectFrameEventDelegate onObjectFrame;

    void VoidFrameEvent ()
    {
        if (onVoidFrame != null) onVoidFrame();
    }
    void FloatFrameEvent(float param)
    {
        if (onFloatFrame != null) onFloatFrame(param);
    }
    void IntFrameEvent(int param)
    {
        if (onIntFrame != null) onIntFrame(param);
    }
    void StringFrameEvent(string param)
    {
        if (onStringFrame != null) onStringFrame(param);
    }
    void ObjectFrameEvent(string param)
    {
        if (onObjectFrame != null) onObjectFrame(param);
    }

    /// <summary>
    /// Get or add an event listener to the specified game object.
    /// </summary>

    public static AnimationEventListener Get(GameObject go, bool addNew = false)
    {
        AnimationEventListener listener = go.GetComponentInChildren<AnimationEventListener>();
        if (listener == null && addNew)
        {
            Animator animator = go.GetComponentInChildren<Animator>();
            if (animator == null)
            {
                Debug.LogError("Can't find a child with Aniamtor.");
                return null;
            }
            else
            {
                listener = animator.gameObject.AddComponent<AnimationEventListener>();
            }
        }
        return listener;
    }

    private void OnDestroy()
    {
        onFloatFrame = null;
        onIntFrame = null;
        onObjectFrame = null;
        onStringFrame = null;
        onVoidFrame = null;
    }
}
