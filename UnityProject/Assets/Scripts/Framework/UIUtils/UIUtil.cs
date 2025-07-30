using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIUtil
{
    
#if UNITY_EDITOR
    public static string _uifollowTargetExVersion = "0.0.0";
#else
    public static string _uifollowTargetExVersion = "1.0.0";
#endif

#if UNITY_EDITOR
    public static string _uifollowTargetEdgeVersion = "0.0.0";
#else    
    public static string _uifollowTargetEdgeVersion = "0.0.0";
#endif
    
    public static Vector3 GetScreenWorldPosition(Vector3 worldPos)
    {
        return CameraUtil.GetScreenPos(UIContainer.mainCamera, UIContainer.uiCamera, worldPos);
    }

    public static Vector3 GetUIRootPositionWithUIWorldPos(Vector3 worldPos)
    {
        return UIContainer.uiRoot.transform.InverseTransformPoint(worldPos);
    }

    public static bool IsPositionAtScreenTop(Vector3 position)
    {
        return position.y > UIContainer.uiCamera.transform.position.y;
    }

    public static string GetCoordinateString(Vector2Int coordinate)
    {
        return GetCoordinateString(coordinate.x, coordinate.y);
    }

    public static string GetCoordinateString(int x, int y)
    {
        return string.Format("X:{0}   Y:{1}", x, y);
    }

    public static string GetCommaCoordinateString(int x, int y)
    {
        return string.Format("{0},{1}", x, y);
    }

    public static string GetSpaceCoordinateString(int x, int y)
    {
        return string.Format("X {0}  Y {1}", x, y);
    }

    public static string GetSpaceCoordinateString(int blockIndex, int x, int y)
    {
        return string.Format("# {0} X {1}  Y {2}", blockIndex, x, y);
    }

    public static void MoveParentTo(Transform parent, Vector3 position)
    {
        int childCount = parent.childCount;
        if (childCount > 0)
        {
            List<Transform> childTsfs = new List<Transform>();
            for (int i = 0; i < childCount; ++i) //先移动到同一层
            {
                Transform tsf = parent.GetChild(0);
                childTsfs.Add(tsf);
                tsf.SetParent(parent.parent);
            }

            parent.transform.position = position; //设置position
            for (int i = 0; i < childCount; ++i) //移回widget
            {
                Transform tsf = childTsfs[i];
                tsf.SetParent(parent);
            }
        }
    }


    public static void SetLayerVisible(this UGUILayerComponent layerComponent, bool visible)
    {
        layerComponent.layer = visible ? Layers.UI : Layers.DONT_SHOW;
        layerComponent.interactive = visible;
    }
    
    public static Canvas SetupCanvas(GameObject go, bool needRaycaster = true)
    {
        var canvas = go.GetComponent<Canvas>();
        if (canvas == null)
        {
            canvas = go.AddComponent<Canvas>();
        }

        canvas.overrideSorting = true;

        if (needRaycaster)
        {
            GraphicRaycaster raycaster = go.GetComponent<GraphicRaycaster>();
            if (raycaster == null)
            {
                raycaster = go.AddComponent<GraphicRaycaster>();
                raycaster.ignoreReversedGraphics = true;
            }
        }

        return canvas;
    }
    
    public static void FitNotchForTransform(RectTransform trans)
    {
        if (trans == null)
        {
            return;
        }

        var safeArea = Screen.safeArea;
#if UNITY_WEBGL
        safeArea = ScreenUtil.GetSafeArea();
#endif
        Vector2 anchorMin = safeArea.position;
        anchorMin.x     =  0;
        anchorMin.y     /= -Screen.height;
        trans.anchorMin =  anchorMin;

        Vector2 anchorMax = safeArea.position + safeArea.size;
        anchorMax.x     = 1;
        anchorMax.y     = Screen.height / anchorMax.y;
        trans.anchorMax = anchorMax;
    }
    
    public static Transform GetPopupLayer(int layer)
    {
        switch (layer)
        {
            case 0:
                return UIManager.instance.popLayer;
            case 1:
                return UIManager.instance.topLayer;
            case 2:
                return UIManager.instance.uiRoot;
            default: return UIManager.instance.popLayer;

        }
    }
    

}

