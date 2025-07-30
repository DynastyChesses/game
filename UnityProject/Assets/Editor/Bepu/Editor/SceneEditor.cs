using UnityEditor;
using UnityEngine;

public class SceneEditor:UnityEditor.Editor
{
    // public static Vector3 DrawAxis(Vector3 pos)
    // {
    //     var oldColor = Handles.color;
    //     Vector3 newPosition = pos;
    //     float handlesize = HandleUtility.GetHandleSize(newPosition) * 0.6f;
    //
    //     Handles.color = new Color(0.99f, 0.50f, 0.35f);
    //     newPosition = Handles.Slider(newPosition, Vector3.right, handlesize, Handles.ArrowCap, 1);
    //     Handles.color = new Color(0.30f, 0.85f, 0.99f);
    //     newPosition = Handles.Slider(newPosition, Vector3.forward, handlesize, Handles.ArrowCap, 1);
    //     Handles.color = new Color(168/255.0f, 242/255.0f, 77/255.0f);
    //     newPosition = Handles.Slider(newPosition, Vector3.up, handlesize, Handles.ArrowCap, 1);
    //     Handles.color = oldColor;
    //     return newPosition;
    // }

    public static void DrawName(params Transform[] trans)
    {
        if (trans == null)
            return;

        foreach (Transform target in trans)
        {
            if (target == null)
                continue;

            Vector3 newPosition = target.position;
            string handleName = target.name;
            float center = HandleUtility.GetHandleSize(newPosition);

            GUIStyle style = new GUIStyle();
            style.active.textColor = Color.gray;
            style.normal.textColor = Color.green;
            style.onNormal.textColor = Color.yellow;
            style.alignment  = TextAnchor.MiddleCenter;

            Handles.Label(target.position + Vector3.up * center, handleName, style);
        }
    }
}