

using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public partial class PhysicConfigWindow
{
    private Vector2 currentPhysicConstraintScrollView;
    private void OnShowPhysicConstraintWindow()
    {
        
    }

    private void UpdateConstraintWindow()
    {
        if (sceneViewTargetPosition == Vector3.zero)
            return;
        moveSceneViewTimer += Time.deltaTime;
        var value = moveSceneViewTimer / moveSceneViewTime;
        SceneView.lastActiveSceneView.pivot = Vector3.Lerp(sceneViewPosition, sceneViewTargetPosition, value);
        if (value > 1)
            sceneViewTargetPosition = Vector3.zero;
        
        SceneView.lastActiveSceneView.Repaint();
    }

    
    [NonSerialized]
    private float moveSceneViewTimer;
    [NonSerialized]
    private float moveSceneViewTime = 2f;
    [NonSerialized]
    private Vector3 sceneViewPosition;
    [NonSerialized]
    private Vector3 sceneViewTargetPosition;
    private void DrawPhysicConstraintWindow()
    {
        var oldColor = GUI.color;
        currentPhysicConstraintScrollView = GUILayout.BeginScrollView(currentPhysicConstraintScrollView);
        GUILayout.BeginVertical("box");
        foreach (PhysicConstraintConfig constraintConfig in this.allPhysicConstraint)
        {
            if (constraintConfig == null)
                continue;
            if (constraintConfig.EntityA == null || constraintConfig.EntityB == null)
            {
                GUI.color = Color.red;
            }
            EditorGUILayout.BeginHorizontal("box");
            GUILayout.Label(constraintConfig.gameObject.name + " : " + constraintConfig.ConstraintType);
            if (GUILayout.Button("选中",GUILayout.Width(100)))
            {
                UnityEditor.Selection.objects = new Object[] {constraintConfig.gameObject};
                sceneViewPosition = SceneView.lastActiveSceneView.pivot;
                sceneViewTargetPosition = constraintConfig.transform.position;
                moveSceneViewTimer = 0;
            }

            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            // SerializedObject so = new SerializedObject(constraintConfig);
            // GUILayout.Label(so.FindProperty("ConstraintType").type);
            // EditorGUILayout.ObjectField(so.FindProperty("ConstraintType"));
            // foreach (SerializedProperty obj in so.FindProperty("ConstraintType"))
            // {
            //     GUILayout.Label(obj.type);
            //     EditorGUILayout.ObjectField(obj);
            // }
        }
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
    }
}