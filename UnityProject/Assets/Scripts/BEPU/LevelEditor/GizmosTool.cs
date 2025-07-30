using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GizmosTool
{
    public static bool IsShowDebug => PlayerPrefs.GetInt("PhysicDebug") == 1;
    public static bool IsDrawWire => PlayerPrefs.GetInt("PhysicWire") == 1;
    

    public static void DrawSphere(Vector3 pos,Quaternion rot,Vector3 scale,float radius)
    {
        var oldColor = Gizmos.color;
        Gizmos.matrix = Matrix4x4.TRS(pos, rot, scale);
        Gizmos.color = Color.green;
        if (IsDrawWire)
            Gizmos.DrawWireSphere(UnityEngine.Vector3.zero,radius * scale.x);
        else
            Gizmos.DrawSphere(UnityEngine.Vector3.zero,radius * scale.x);
        Gizmos.color = oldColor;
    }

    public static void DrawBox(Vector3 pos,Quaternion rot,Vector3 scale)
    {
        var oldColor = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS(pos, rot, scale);
        
        if (IsDrawWire)
            Gizmos.DrawWireCube(Vector3.zero,Vector3.one);
        else
            Gizmos.DrawCube(Vector3.zero,Vector3.one);
        
        Gizmos.color = oldColor;
    }
    
    public static void DrawCapsule(Vector3 pos,Quaternion rot,Vector3 scale,float high,float radius)
    {
        high *= scale.y;
        Vector3 startPoint = new Vector3(0,high,0);
        Vector3 endPoint = new Vector3(0,-high,0);
        startPoint = rot * startPoint;
        endPoint = rot * endPoint;
        DebugExtension.DrawCapsule(pos + startPoint,pos + endPoint, Color.green, radius * scale.x);
    }
    public static void DrawCylinder(Vector3 pos,Quaternion rot,Vector3 scale,float high,float radius)
    {
        high /= 2f;
        high *= scale.y;
        Vector3 startPoint = new Vector3(0,high,0);
        Vector3 endPoint = new Vector3(0,-high,0);
        startPoint = rot * startPoint;
        endPoint = rot * endPoint;
        DebugExtension.DrawCylinder(pos + startPoint,pos + endPoint, Color.green, radius * scale.x);
    }
    
    public static void DrawCone(Vector3 pos,Quaternion rot,Vector3 scale,float high,float radius)
    {
        high *= scale.y;
        Vector3 topPos = pos + rot * (Vector3.up * (high / 2f));
        Vector3 direction = rot * (Vector3.down * high);
        
        Vector3 v1 = new Vector3(0,high,0);
        Vector3 v2 = new Vector3(radius * scale.x,high,0);
        var ang = Vector3.Angle(v1, v2);
        DebugExtension.DrawCone(topPos ,direction, Color.green, ang);
    }
    
    public static void DrawMesh(Mesh mesh)
    {
        if (mesh == null)
            return;
        var oldColor = Gizmos.color;
        Gizmos.color = Color.green;
        if (IsDrawWire)
            Gizmos.DrawWireMesh(mesh,Vector3.zero);
        else
            Gizmos.DrawMesh(mesh,Vector3.zero);
        Gizmos.color = oldColor;
    }
    
    
    
    
    
    
    
    
    
    
    
}
