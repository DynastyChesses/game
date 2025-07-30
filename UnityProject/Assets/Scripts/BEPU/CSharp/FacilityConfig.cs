using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityConfig : MonoBehaviour
{
#if UNITY_EDITOR
    public static bool ShowGizmos = false;
    public int Id;
    private void OnDrawGizmos()
    {
        if (!ShowGizmos)
            return;
        DrawPoint(transform.position,Color.red);
    }

    private void DrawPoint(Vector3 position, Color color, float scale = 1.0f)
    {
        Color oldColor = Gizmos.color;
        Gizmos.color = color;		
        Gizmos.DrawCube(position, Vector3.one * scale);
        Gizmos.color = oldColor;
    }
#endif
}
