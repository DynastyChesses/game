using System;
using UnityEngine;

public static class GameObjectExtension
{
    public static void SetLocalPosition(this GameObject go, Vector3 pos)
    {
        if (go)
        {
            go.transform.localPosition = pos;
        }
    }

    public static void SetLocalRotation(this GameObject go, Quaternion rot)
    {
        if (go)
        {
            go.transform.localRotation = rot;
        }
    }

    public static void SetLocalScale(this GameObject go, Vector3 scale)
    {
        if (go)
        {
            go.transform.localScale = scale;
        }
    }

    public static void SetParent(this GameObject go, GameObject parent)
    {
        if (go)
        {
            go.SetParent(parent.transform);
        }
    }

    public static void SetParent(this GameObject go, Transform parent)
    {
        if (go)
        {
            go.transform.SetParent(parent);
        }
    }

    public static void SetLayer(this GameObject go, int layer)
    {
        if (go)
        {
            SetLayerRecursively(go.transform, layer);
        }
    }

    private static void SetLayerRecursively(Transform tr, int layer)
    {
        tr.gameObject.layer = layer;
        if (tr.childCount > 0)
        {
            for (int i = 0, imax = tr.childCount; i < imax; ++i)
            {
                Transform child = tr.GetChild(i);
                SetLayerRecursively(child, layer);
            }
        }
    }

    public static Component GetComponentOrAdd(this GameObject go, Type type)
    {
        Component component = go.GetComponent(type);
        if (!component)
        {
            component = go.AddComponent(type);
        }

        return component;
    }
}