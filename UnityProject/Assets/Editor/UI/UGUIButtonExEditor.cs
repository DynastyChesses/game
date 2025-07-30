
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(UGUIButtonEx))]
public class UGUIButtonExEditor:UnityEditor.UI.ButtonEditor
{
    private SerializedProperty pressScaleProp, normalScaleProp;
    private SerializedProperty pressColorProp, normalColorProp;
    private SerializedProperty pressSpriteProp;
    private SerializedProperty clickIntervalProp;
    
    private SerializedProperty transitionProp;
    private SerializedProperty disabledSpriteProp;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        pressScaleProp = serializedObject.FindProperty( "pressScale" );
        normalScaleProp = serializedObject.FindProperty( "normalScale" );
        pressColorProp = serializedObject.FindProperty( "pressColor" );
        normalColorProp = serializedObject.FindProperty( "normalColor" );
        clickIntervalProp = serializedObject.FindProperty( "clickInterval" );
        pressSpriteProp = serializedObject.FindProperty("pressSprite");
        
        transitionProp = serializedObject.FindProperty("m_Transition");
        disabledSpriteProp = serializedObject.FindProperty("m_SpriteState.m_DisabledSprite");
    }

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        UGUIButtonEx btn = (UGUIButtonEx)target;
        btn.scaleTweemTarget = EditorGUILayout.ObjectField("Scale Tween Target",btn.scaleTweemTarget, typeof(Transform), true) as Transform;
        
        if (btn.scaleTweemTarget != null)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(pressScaleProp);
            EditorGUILayout.PropertyField(normalScaleProp);
            EditorGUI.indentLevel--;
        }

        
        EditorGUILayout.PropertyField(clickIntervalProp);
        btn.animMode = (ButtonAnimMode) EditorGUILayout.EnumPopup("AnimMode:", btn.animMode);

        if (btn.animMode == ButtonAnimMode.Color)
        {
            btn.colorTweenTarget = EditorGUILayout.ObjectField("Color Tween Target",btn.colorTweenTarget, typeof(Graphic), true) as Graphic;
            if (btn.colorTweenTarget != null)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(pressColorProp);
                EditorGUILayout.PropertyField(normalColorProp);
                EditorGUI.indentLevel--;
            }

        }else if (btn.animMode == ButtonAnimMode.SpriteSwap)
        {
            btn.colorTweenTarget = EditorGUILayout.ObjectField("Target",btn.colorTweenTarget, typeof(Graphic), true) as Graphic;
            if (btn.colorTweenTarget != null)
            {            
                EditorGUILayout.PropertyField(pressSpriteProp);
            }
        }

        EditorGUILayout.PropertyField(transitionProp);
        EditorGUILayout.PropertyField(disabledSpriteProp);
        
        serializedObject.ApplyModifiedProperties();
    }
}
