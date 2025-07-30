using System;
using BEPUphysics.Constraints.TwoEntity.Motors;
using FixMath.NET;
using Simulation;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PhysicConstraintConfig))]
public class PhysicConstraintConfigEditor:UnityEditor.Editor
{
    
    private PhysicConstraintConfig _constraintConfig;
 
    void Awake()
    {
        _constraintConfig = this.target as PhysicConstraintConfig;
    }


    public override void OnInspectorGUI()
    {
        Undo.RecordObject(_constraintConfig,"Offset"+_constraintConfig.gameObject.name);
        serializedObject.Update();
        var oldColor = GUI.color;
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.BeginHorizontal();
        
        
        GUILayout.Label("约束类型",GUILayout.Width(100));
        _constraintConfig.ConstraintType = (ConstraintType)EditorGUILayout.EnumPopup(_constraintConfig.ConstraintType);
        EditorGUILayout.EndHorizontal();

        switch (_constraintConfig.ConstraintType)
        {
            case ConstraintType.RevoluteJoint:
                OnDrawRotateJoint();
                break;
            case ConstraintType.PrismaticJoint:
                OnDrawPrismaticJoint();
                break;
            case ConstraintType.UniversalJoint:
                OnDrawUniversalJoint();
                break;
            case ConstraintType.WeldJoint:
                OnDrawWeldJoint();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_constraintConfig.gameObject);
            EditorUtility.SetDirty(target);
        }
        
        GUI.color = oldColor;
        serializedObject.ApplyModifiedProperties();
    }

    
    private void OnDrawRotateJoint()
    {
        DrawSampleIcon("旋转.png","旋转。");
        EditorGUI.BeginChangeCheck();
        
        _constraintConfig.EntityA = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityA",_constraintConfig.EntityA,typeof(PhysicObjectConfig));
        if (_constraintConfig.EntityA == null)
        {
            EditorGUILayout.HelpBox("EntityA为空,将会自动创建并根据EntityB的位置和中心偏移计算位置!!", MessageType.Warning);
        }
        _constraintConfig.EntityB = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityB",_constraintConfig.EntityB,typeof(PhysicObjectConfig));
        if (null == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityB不可以为空!!", MessageType.Error);
        }
        else if (_constraintConfig.EntityA == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityA和EntityB不可以是同一个!!", MessageType.Error);
        }
        
        
        var offset = EditorGUILayout.Vector3Field("中心偏移", (UnityEngine.Vector3)(_constraintConfig.CenterOffset));
        if (EditorGUI.EndChangeCheck())
            _constraintConfig.CenterOffset = (BEPUutilities.Vector3)(offset);
        
        EditorGUI.BeginChangeCheck();
        var axis = EditorGUILayout.Vector3Field("旋转轴向", (UnityEngine.Vector3)(_constraintConfig.RotateAxis));
        if (EditorGUI.EndChangeCheck())
            _constraintConfig.RotateAxis = (BEPUutilities.Vector3)(axis);

        _constraintConfig.UseLimit = EditorGUILayout.Toggle("开启限制", _constraintConfig.UseLimit);
        if (_constraintConfig.UseLimit)
        {
            _constraintConfig.Minimum = (Fix64)EditorGUILayout.FloatField("最小Ang(角度)", (float) _constraintConfig.Minimum);
            _constraintConfig.Maximum = (Fix64)EditorGUILayout.FloatField("最大Ang(角度)", (float) _constraintConfig.Maximum);
        }

        _constraintConfig.UseMotor = EditorGUILayout.Toggle("开启电机", _constraintConfig.UseMotor);
        
        if (_constraintConfig.UseMotor)
        {
            _constraintConfig.MotorMode = (MotorMode)EditorGUILayout.EnumPopup("电机模式", _constraintConfig.MotorMode);
            string goalValueStr = "电机速度";
            switch (_constraintConfig.MotorMode)
            {
                case MotorMode.VelocityMotor:
                    goalValueStr = "电机速度";
                    break;
                case MotorMode.Servomechanism:
                    goalValueStr = "目标角度（顺时针）";
                    break;
            }
            GUILayout.BeginHorizontal();
            _constraintConfig.MaxForce = (Fix64)EditorGUILayout.FloatField("最大力度", (float) _constraintConfig.MaxForce);
            if (GUILayout.Button("最大值"))
            {
                _constraintConfig.MaxForce = Fix64.MaxValue*0.9m;
            }
            GUILayout.EndHorizontal();
            _constraintConfig.GoalValue = (Fix64)EditorGUILayout.FloatField(goalValueStr, (float) _constraintConfig.GoalValue);
        }

    }

    private void OnDrawPrismaticJoint()
    {
        DrawSampleIcon("平移.png","平移。");
        //_constraintConfig.EntityA = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityA",_constraintConfig.EntityA,typeof(PhysicObjectConfig));
        _constraintConfig.EntityB = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityB",_constraintConfig.EntityB,typeof(PhysicObjectConfig));
        if (null == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityB不可以为空!!", MessageType.Error);
        }
        
        EditorGUI.BeginChangeCheck();
        var axis = EditorGUILayout.Vector3Field("轴向", (UnityEngine.Vector3)(_constraintConfig.RotateAxis));
        if (EditorGUI.EndChangeCheck())
            _constraintConfig.RotateAxis = (BEPUutilities.Vector3)(axis);
        
        _constraintConfig.UseLimit = EditorGUILayout.Toggle("开启限制", _constraintConfig.UseLimit);
        if (_constraintConfig.UseLimit)
        {
            _constraintConfig.Minimum = (Fix64)EditorGUILayout.FloatField("最小", (float) _constraintConfig.Minimum);
            _constraintConfig.Maximum = (Fix64)EditorGUILayout.FloatField("最大", (float) _constraintConfig.Maximum);
        }
        
        _constraintConfig.UseMotor = EditorGUILayout.Toggle("开启电机", _constraintConfig.UseMotor);
        if (_constraintConfig.UseMotor)
        {
            _constraintConfig.MotorMode = (MotorMode)EditorGUILayout.EnumPopup("电机模式", _constraintConfig.MotorMode);
            string goalValueStr = "电机速度";
            // switch (_constraintConfig.MotorMode)
            // {
            //     case MotorMode.VelocityMotor:
            //         goalValueStr = "电机速度";
            //         break;
            //     case MotorMode.Servomechanism:
            //         goalValueStr = "目标角度（顺时针）";
            //         break;
            // }
            GUILayout.BeginHorizontal();
            _constraintConfig.MaxForce = (Fix64)EditorGUILayout.FloatField("最大力度", (float) _constraintConfig.MaxForce);
            if (GUILayout.Button("最大值"))
            {
                _constraintConfig.MaxForce = Fix64.MaxValue*0.9m;
            }
            GUILayout.EndHorizontal();
            _constraintConfig.GoalValue = (Fix64)EditorGUILayout.FloatField(goalValueStr, (float) _constraintConfig.GoalValue);
        }
    }

    
    private void OnDrawUniversalJoint()
    {
        EditorGUI.BeginChangeCheck();
        DrawSampleIcon("万向节.jpg","万向节。");
        _constraintConfig.EntityA = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityA",_constraintConfig.EntityA,typeof(PhysicObjectConfig));
        if (_constraintConfig.EntityA == null)
        {
            EditorGUILayout.HelpBox("EntityA不可以为空!!", MessageType.Error);
        }
        _constraintConfig.EntityB = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityB",_constraintConfig.EntityB,typeof(PhysicObjectConfig));
        if (null == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityB不可以为空!!", MessageType.Error);
        }
        else if (_constraintConfig.EntityA == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityA和EntityB不可以是同一个!!", MessageType.Error);
        }
        
        
        var offset = EditorGUILayout.Vector3Field("中心偏移", (UnityEngine.Vector3)(_constraintConfig.CenterOffset));
        if (EditorGUI.EndChangeCheck())
            _constraintConfig.CenterOffset = (BEPUutilities.Vector3)(offset);
        

        _constraintConfig.UseLimit = EditorGUILayout.Toggle("开启限制", _constraintConfig.UseLimit);
        if (_constraintConfig.UseLimit)
        {
            _constraintConfig.Minimum = (Fix64)EditorGUILayout.FloatField("最小Ang(角度)", (float) _constraintConfig.Minimum);
            _constraintConfig.Maximum = (Fix64)EditorGUILayout.FloatField("最大Ang(角度)", (float) _constraintConfig.Maximum);
        }

        _constraintConfig.UseMotor = EditorGUILayout.Toggle("开启电机", _constraintConfig.UseMotor);
        
        if (_constraintConfig.UseMotor)
        {
            _constraintConfig.MotorMode = (MotorMode)EditorGUILayout.EnumPopup("电机模式", _constraintConfig.MotorMode);
            string goalValueStr = "电机速度";
            switch (_constraintConfig.MotorMode)
            {
                case MotorMode.VelocityMotor:
                    goalValueStr = "电机速度";
                    break;
                case MotorMode.Servomechanism:
                    goalValueStr = "目标角度（顺时针）";
                    break;
            }
            GUILayout.BeginHorizontal();
            _constraintConfig.MaxForce = (Fix64)EditorGUILayout.FloatField("最大力度", (float) _constraintConfig.MaxForce);
            if (GUILayout.Button("最大值"))
            {
                _constraintConfig.MaxForce = Fix64.MaxValue*0.9m;
            }
            GUILayout.EndHorizontal();
            _constraintConfig.GoalValue = (Fix64)EditorGUILayout.FloatField(goalValueStr, (float) _constraintConfig.GoalValue);
        }

    }
    
    private void OnDrawWeldJoint()
    {
        EditorGUI.BeginChangeCheck();
        DrawSampleIcon("焊接.png","焊接，刚性固定两个Entity。");
        _constraintConfig.EntityA = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityA",_constraintConfig.EntityA,typeof(PhysicObjectConfig));
        if (_constraintConfig.EntityA == null)
        {
            EditorGUILayout.HelpBox("EntityA不可以为空!!", MessageType.Error);
        }
        _constraintConfig.EntityB = (PhysicObjectConfig)EditorGUILayout.ObjectField("EntityB",_constraintConfig.EntityB,typeof(PhysicObjectConfig));
        if (null == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityB不可以为空!!", MessageType.Error);
        }
        else if (_constraintConfig.EntityA == _constraintConfig.EntityB)
        {
            EditorGUILayout.HelpBox("EntityA和EntityB不可以是同一个!!", MessageType.Error);
        }
    }

    private void DrawSampleIcon(string path,string desc)
    {
        var icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Game/minimart/EditorOnly/Editor/Resource/"+path);
        float v = icon.width / (float)icon.height;
        GUIContent guiContent = new GUIContent(icon);
        EditorGUILayout.BeginHorizontal("box");
        GUILayout.Button(guiContent, GUILayout.Width(120*v), GUILayout.Height(120));
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField(desc);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }
}