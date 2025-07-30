using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIText), true), CanEditMultipleObjects]
public class UITextEditor : TMP_EditorPanelUI
{
    private SerializedProperty _localize_key;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        _localize_key = serializedObject.FindProperty("key");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_localize_key);
        this.serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}