using System;
using System.Text;
using BEPUphysics.PositionUpdating;
using FixMath.NET;
using Simulation;
// using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Graphs;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;

[CustomEditor(typeof(PhysicObjectConfig))]
public class PhysicObjectConfigEditor:UnityEditor.Editor
{
    private PhysicObjectConfig _objectConfig;
    void Awake()
    {
        _objectConfig = this.target as PhysicObjectConfig;
    }
    public override void OnInspectorGUI()
    {
        Undo.RecordObject(_objectConfig,"Offset"+_objectConfig.gameObject.name);
        // 更新serializedObject，在OnInspectorGUI一开始就要调用该函数
        serializedObject.Update();
        var oldColor = GUI.color;
        
        EditorGUI.BeginChangeCheck();
        DrawHead();
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("PrefabName:",GUILayout.Width(100));
        _objectConfig.PrefabName = GUILayout.TextField(_objectConfig.PrefabName);
        if (GUILayout.Button("ThisObject",GUILayout.Width(130)))
        {
            _objectConfig.PrefabName = _objectConfig.gameObject.name;
        }
        GUILayout.EndHorizontal();
        
        DrawType();
        DrawPhysicInfo();
        // if (_objectConfig.ObjectType == PhysicObjectType.Dynamic)
        // {
        //     GUILayout.BeginHorizontal("box");
        //     GUILayout.Label("LuaScript:",GUILayout.Width(100));
        //     _objectConfig.LuaScript = GUILayout.TextField(_objectConfig.LuaScript);
        //     GUILayout.EndHorizontal();
        //     DrawParameterList();
        // }
        
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_objectConfig.gameObject);
            EditorUtility.SetDirty(target);
        }
        GUI.color = oldColor;
        //OnSceneGUI();
        // 保存所有对脚本修改的值
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawHead()
    {
        // //Debug颜色
        // EditorGUILayout.BeginHorizontal();
        // var colorStrSize = EditorStyles.label.fontSize * ColorStr.Length;
        // GUILayout.Label(ColorStr,GUILayout.Width(colorStrSize));
        // _objectConfig.Color = EditorGUILayout.ColorField(_objectConfig.Color);
        // EditorGUILayout.EndHorizontal();

        //坐标显示
        _objectConfig.IsShowFix64Info = EditorGUILayout.Foldout(_objectConfig.IsShowFix64Info, "定点数");
        if (_objectConfig.IsShowFix64Info)
        {
            GUILayout.BeginVertical("box");
            BEPUutilities.Vector3 bepuPosition = (BEPUutilities.Vector3)(_objectConfig.transform.position);
            BEPUutilities.Vector3 bepuScale = (BEPUutilities.Vector3)(_objectConfig.transform.lossyScale);
            BEPUutilities.Quaternion bepuRotation = (BEPUutilities.Quaternion)(_objectConfig.transform.rotation);
            GUILayout.Label($"坐标：\nX:{bepuPosition.X}\nY:{bepuPosition.Y}\nZ:{bepuPosition.Z}\n旋转：\n{bepuRotation}\n缩放：\nX:{bepuScale.X}\nY:{bepuScale.Y}\nZ:{bepuScale.Z}\n");
            GUILayout.EndVertical();
        }
    }
    private void DrawType()
    {
        _objectConfig.PhysicLayer = (PhysicLayer)EditorGUILayout.EnumPopup(new GUIContent("物理层级"),_objectConfig.PhysicLayer);
        _objectConfig.ObjectType = (PhysicObjectType)EditorGUILayout.EnumPopup(new GUIContent("动静类型"),_objectConfig.ObjectType);
        switch (_objectConfig.ObjectType)
        {
            case PhysicObjectType.Dynamic:
                DrawDynamicCommonInfo();
                _objectConfig.DynamicObjectType = (PhysicDynamicObjectType)EditorGUILayout.EnumPopup(new GUIContent("动态类型"),_objectConfig.DynamicObjectType);
                break;
            case PhysicObjectType.Static:
                _objectConfig.StaticObjectType = (PhysicStaticObjectType)EditorGUILayout.EnumPopup(new GUIContent("静态类型"),_objectConfig.StaticObjectType);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void DrawPhysicInfo()
    {
        switch (_objectConfig.ObjectType)
        {
            case PhysicObjectType.Dynamic:
                DrawDynamicInfo();
                break;
            case PhysicObjectType.Static:
                DrawStaticInfo();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawDynamicCommonInfo()
    {
        var oldColor = GUI.color;
        GUI.color = Color.cyan;
        EditorGUILayout.BeginVertical("box");
        GUI.color = oldColor;
        //动态通用信息
        GUILayout.Label("动态物理通用信息：");
        _objectConfig.UpdateMode = (PositionUpdateMode)EditorGUILayout.EnumPopup("碰撞方式",_objectConfig.UpdateMode);
        switch (_objectConfig.UpdateMode)
        {
            case PositionUpdateMode.Discrete:
                EditorGUILayout.HelpBox("离散碰撞：性能最好，但速度过快可能穿模。", MessageType.Info);
                break;
            case PositionUpdateMode.Passive:
                EditorGUILayout.HelpBox("半离散碰撞：保持离散碰撞，当与连续碰撞物理在同一区域时可能被动使用连续碰撞。", MessageType.Info);
                break;
            case PositionUpdateMode.Continuous:
                EditorGUILayout.HelpBox("连续碰撞：性能消耗比离散高出一个数量级，但效果最好 不会出现穿模。推荐仅在关键物体上使用。", MessageType.Warning);
                break;
        }
        _objectConfig.IsTrigger = EditorGUILayout.Toggle("触发器",_objectConfig.IsTrigger);
        _objectConfig.Mass = EditorGUILayout.FloatField("质量", _objectConfig.Mass);
        if (_objectConfig.Mass <= 0)
            EditorGUILayout.HelpBox("质量<=0会开启运动学，拥有无限大质量和惯性，可以当静态物理使用。 ", MessageType.Info);
        _objectConfig.CustomizeMaterial = EditorGUILayout.Toggle("自定义材质",_objectConfig.CustomizeMaterial);
        if (_objectConfig.CustomizeMaterial)
        {
            EditorGUILayout.BeginVertical("box");
            _objectConfig.KineticFriction = EditorGUILayout.FloatField("动摩擦", _objectConfig.KineticFriction);
            _objectConfig.StaticFriction = EditorGUILayout.FloatField("静摩擦", _objectConfig.StaticFriction);
            _objectConfig.Bounciness = EditorGUILayout.FloatField("弹性", _objectConfig.Bounciness);
            EditorGUILayout.EndVertical();
        }
        _objectConfig.IsUseIndependentGravity = EditorGUILayout.Toggle("使用独立重力",_objectConfig.IsUseIndependentGravity);
        if (_objectConfig.IsUseIndependentGravity)
        {
            EditorGUI.BeginChangeCheck();
            var v3 = EditorGUILayout.Vector3Field("重力方向", (UnityEngine.Vector3)(_objectConfig.Gravity));
            if (EditorGUI.EndChangeCheck())
                _objectConfig.Gravity = (BEPUutilities.Vector3)(v3);
        }
        EditorGUILayout.EndVertical();
    }
    private void DrawDynamicInfo()
    {
        if (_objectConfig.ObjectType != PhysicObjectType.Dynamic)
            return;
        var oldColor = GUI.color;
        GUI.color = Color.cyan;
        EditorGUILayout.BeginVertical("box");
        GUI.color = oldColor;

        switch (_objectConfig.DynamicObjectType)
        {
            case PhysicDynamicObjectType.DynamicMesh:
                DrawMeshInfo();
                DrawOffsetInfo();
                break;
            case PhysicDynamicObjectType.CompoundBody:
                DrawShapeDataList();
                break;
            case PhysicDynamicObjectType.Box:
                DrawBoxInfo();
                break;
            case PhysicDynamicObjectType.Capsule:
                DrawCapsuleInfo();
                //EditorGUILayout.HelpBox("没做完，暂不可用。", MessageType.Error);
                break;
            case PhysicDynamicObjectType.Cone:
                DrawConeInfo();
                EditorGUILayout.HelpBox("中心坐标计算可能存在小误差。", MessageType.Warning);
                break;
            case PhysicDynamicObjectType.Cylinder:
                DrawCylinderInfo();
                // EditorGUILayout.HelpBox("没做完，暂不可用。", MessageType.Error);
                break;
            case PhysicDynamicObjectType.Sphere:
                DrawSphereInfo();
                break;
            case PhysicDynamicObjectType.Triangle:
                EditorGUILayout.HelpBox("没做完，暂不可用。", MessageType.Error);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        EditorGUILayout.EndVertical();
    }
    private void DrawStaticInfo()
    {
        if (_objectConfig.ObjectType != PhysicObjectType.Static)
            return;
        var oldColor = GUI.color;
        GUI.color = Color.cyan;
        EditorGUILayout.BeginVertical("box");
        GUI.color = oldColor;
        switch (_objectConfig.StaticObjectType)
        {
            case PhysicStaticObjectType.StaticMesh:
                DrawMeshInfo();
                DrawOffsetInfo();
                break;
            case PhysicStaticObjectType.StaticGroup:
                DrawShapeDataList();
                break;
        }
        _objectConfig.CustomizeMaterial = EditorGUILayout.Toggle("自定义材质",_objectConfig.CustomizeMaterial);
        if (_objectConfig.CustomizeMaterial)
        {
            EditorGUILayout.BeginVertical("box");
            _objectConfig.KineticFriction = EditorGUILayout.FloatField("动摩擦", _objectConfig.KineticFriction);
            _objectConfig.StaticFriction = EditorGUILayout.FloatField("静摩擦", _objectConfig.StaticFriction);
            _objectConfig.Bounciness = EditorGUILayout.FloatField("弹性", _objectConfig.Bounciness);
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndVertical();
    }

    private PhysicShapeData copyData;
    private void DrawShapeDataList()
    {
        var oldColor = GUI.color;
        GUI.color = Color.black;
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.BeginHorizontal("box");
        GUI.color = Color.white;
        _objectConfig.IsShowShapeDataList = EditorGUILayout.Foldout(_objectConfig.IsShowShapeDataList, new GUIContent("形状列表:"));
        GUI.color = Color.green;
        if (GUILayout.Button("新增"))
        {
            _objectConfig.ShapeDataList.Add(new PhysicShapeData());
        }
        GUI.color = Color.red;
        if (GUILayout.Button("清空"))
        {
            _objectConfig.ShapeDataList.Clear();
        }
        GUI.color = Color.magenta;
        if (GUILayout.Button("GetChild"))
        {
            _objectConfig.ShapeDataList.Clear();
            PhysicObjectConfig[] allObjects = _objectConfig.gameObject.GetComponentsInChildren<PhysicObjectConfig>();
            for (int i = 0; i < allObjects.Length; i++)
            {
                if (allObjects[i].ShapeDataList == null || allObjects[i].ShapeDataList.Count == 0)
                    continue;
                var localPos = allObjects[i].transform.position - _objectConfig.transform.position;
                var scale = allObjects[i].transform.lossyScale;
                var rotation = allObjects[i].transform.rotation;
                
                foreach (PhysicShapeData shapeData in allObjects[i].ShapeDataList)
                {
                    var newData = new PhysicShapeData()
                    {
                        LocalPosition = shapeData.LocalPosition + (Vector3)localPos,
                        MassWeight = shapeData.MassWeight,
                        Mesh = shapeData.Mesh,
                        Rotation = (Vector3)(rotation * UnityEngine.Quaternion.Euler((UnityEngine.Vector3)(shapeData.Rotation))).eulerAngles,
                        Scale = shapeData.Scale * (Vector3)scale,
                        ShapeType = shapeData.ShapeType
                    };
                    _objectConfig.ShapeDataList.Add(newData);
                }
            }
        }
        GUI.color = oldColor;
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.HelpBox("联合体不可以使用Transform自身的Scale", MessageType.Info);
        if (_objectConfig.IsShowShapeDataList)
        {
            for (int i = 0; i < _objectConfig.ShapeDataList.Count; i++)
            {
                GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                EditorGUILayout.BeginVertical("box");
                var shapeData = _objectConfig.ShapeDataList[i];
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("拷贝"))
                {
                    copyData = new PhysicShapeData()
                    {
                        ShapeType = shapeData.ShapeType,
                        LocalPosition = shapeData.LocalPosition,
                        MassWeight = shapeData.MassWeight,
                        Rotation = shapeData.Rotation,
                        Scale = shapeData.Scale,
                        Mesh = shapeData.Mesh,
                    };
                }
                if (GUILayout.Button("黏贴"))
                {
                    if (copyData != null)
                    {
                        shapeData.ShapeType = copyData.ShapeType;
                        shapeData.LocalPosition = copyData.LocalPosition;
                        shapeData.MassWeight = copyData.MassWeight;
                        shapeData.Rotation = copyData.Rotation;
                        shapeData.Scale = copyData.Scale;
                        shapeData.Mesh = copyData.Mesh;
                    }
                }

                var oldColor2 = GUI.color;
                GUI.color = Color.red;
                if (GUILayout.Button("删除"))
                {
                    _objectConfig.ShapeDataList.RemoveAt(i);
                    i--;
                }
                GUI.color = oldColor2;
                
                
                EditorGUILayout.EndHorizontal();
                shapeData.ShapeType = (PhysicShapeType)EditorGUILayout.EnumPopup("形状",shapeData.ShapeType);
                if (shapeData.ShapeType == PhysicShapeType.Mesh)
                {
                    EditorGUILayout.HelpBox("有错误，暂不可用。", MessageType.Error);
                }

                shapeData.MassWeight = (Fix64)EditorGUILayout.FloatField("质量权重", (float)shapeData.MassWeight);
                EditorGUI.BeginChangeCheck();
                var localPos = EditorGUILayout.Vector3Field("本地坐标", (UnityEngine.Vector3)(shapeData.LocalPosition));
                var localRotation = EditorGUILayout.Vector3Field("本地旋转", (UnityEngine.Vector3)(shapeData.Rotation));
                var localScale = EditorGUILayout.Vector3Field("本地缩放", (UnityEngine.Vector3)(shapeData.Scale));
                if (shapeData.ShapeType == PhysicShapeType.Mesh)
                {
                    shapeData.Mesh = (Mesh)EditorGUILayout.ObjectField("物理网格", shapeData.Mesh, typeof(Mesh));
                    int count = shapeData.Mesh == null?0:shapeData.Mesh.vertices.Length;
                    GUILayout.Label($"     网格顶点数量：{count}");
                }
                if (EditorGUI.EndChangeCheck())
                {
                    shapeData.LocalPosition = (BEPUutilities.Vector3)(localPos);
                    shapeData.Rotation = (BEPUutilities.Vector3)(localRotation);
                    shapeData.Scale = (BEPUutilities.Vector3)(localScale);
                }
                EditorGUILayout.EndVertical();
            }
        }
        EditorGUILayout.EndVertical();
        GUI.color = oldColor;
    }
    private void DrawOffsetInfo()
    {
        var oldColor = GUI.color;
        GUI.color=Color.cyan;
        EditorGUILayout.BeginVertical("box");
        GUI.color = oldColor;
        _objectConfig.IsUseOffset = EditorGUILayout.Toggle("启用偏移：",_objectConfig.IsUseOffset);
        if (_objectConfig.IsUseOffset)
        {
            EditorGUI.BeginChangeCheck();
            var posOffset = EditorGUILayout.Vector3Field("坐标偏移", (UnityEngine.Vector3)(_objectConfig.PositionOffset));
            var eulerAngles = EditorGUILayout.Vector3Field("旋转偏移", (UnityEngine.Vector3)(_objectConfig.RotationOffset));
            if (EditorGUI.EndChangeCheck())
            {
                _objectConfig.PositionOffset = (BEPUutilities.Vector3)(posOffset);
                _objectConfig.RotationOffset = (BEPUutilities.Vector3)(eulerAngles);
            }
        }
        EditorGUILayout.EndVertical();
        GUI.color = oldColor;
    }
    private void DrawMeshInfo()
    {
        _objectConfig.Mesh = (Mesh)EditorGUILayout.ObjectField("物理网格", _objectConfig.Mesh, typeof(Mesh));
        int count = _objectConfig.Mesh == null?0:_objectConfig.Mesh.vertices.Length;
        GUILayout.Label($"     网格顶点数量：{count}");
    }
    private void DrawBoxInfo()
    {
        EditorGUI.BeginChangeCheck();
        var size = EditorGUILayout.Vector3Field("Size", (UnityEngine.Vector3)(_objectConfig.Size));
        if (EditorGUI.EndChangeCheck())
        {
            _objectConfig.Size = (BEPUutilities.Vector3)(size);
        }
    }
    private void DrawSphereInfo()
    {
        _objectConfig.Size.X = (Fix64)EditorGUILayout.FloatField("半径", (float) _objectConfig.Size.X);
    }
    private void DrawCapsuleInfo()
    {
        _objectConfig.Size.X = (Fix64)EditorGUILayout.FloatField("半径", (float) _objectConfig.Size.X);
        _objectConfig.Size.Y = (Fix64)EditorGUILayout.FloatField("高度", (float) _objectConfig.Size.Y);
    }

    private void DrawCylinderInfo()
    {
        _objectConfig.Size.X = (Fix64)EditorGUILayout.FloatField("半径", (float) _objectConfig.Size.X);
        _objectConfig.Size.Y = (Fix64)EditorGUILayout.FloatField("高度", (float) _objectConfig.Size.Y);
    }
    private void DrawConeInfo()
    {
        _objectConfig.Size.X = (Fix64)EditorGUILayout.FloatField("半径", (float) _objectConfig.Size.X);
        _objectConfig.Size.Y = (Fix64)EditorGUILayout.FloatField("高度", (float) _objectConfig.Size.Y);
    }

    // private void DrawParameterList()
    // {
    //     var oldColor = GUI.color;
    //     _objectConfig.ShowParameterList = EditorGUILayout.Foldout(_objectConfig.ShowParameterList, "Lua参数");
    //     if (_objectConfig.ShowParameterList)
    //     {
    //         EditorGUILayout.BeginHorizontal("box");
    //         GUI.color = Color.green;
    //         if (GUILayout.Button("新增"))
    //         {
    //             _objectConfig.ParameterList.Add(new ScriptParameter());
    //         }
    //         GUI.color = Color.red;
    //         if (GUILayout.Button("清空"))
    //         {
    //             _objectConfig.ParameterList.Clear();
    //         }
    //         GUI.color = oldColor;
    //         EditorGUILayout.EndHorizontal();
    //         for (int i = 0; i < _objectConfig.ParameterList.Count; i++)
    //         {
    //             var data = _objectConfig.ParameterList[i];
    //             
    //             GUI.color = i%2 == 1 ? Color.cyan : Color.green;
    //             EditorGUILayout.BeginHorizontal("box");
    //             data.Name = EditorGUILayout.TextField(data.Name);
    //             data.Value = (Fix64)EditorGUILayout.FloatField((float) data.Value);
    //
    //             GUI.color = Color.red;
    //             if (GUILayout.Button("删除"))
    //             {
    //                 _objectConfig.ParameterList.RemoveAt(i);
    //                 i--;
    //             }
    //             GUI.color = oldColor;
    //             EditorGUILayout.EndHorizontal();
    //         }
    //     }
    //     GUI.color = oldColor;
    // }


    private enum HandleType
    {
        Position,
        Rotation,
        Scale,
    }
    
    private HandleType currentHandleType = HandleType.Position;
    private void OnSceneGUI()
    {
        var e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.W)
        {
            currentHandleType = HandleType.Position;
        }
        else if (e.type == EventType.KeyDown && e.keyCode == KeyCode.E)
        {
            currentHandleType = HandleType.Rotation;
        }
        else if (e.type == EventType.KeyDown && e.keyCode == KeyCode.R)
        {
            currentHandleType = HandleType.Scale;
        }
        
        Undo.RecordObject(_objectConfig,"坐标:"+_objectConfig.gameObject.name);
        if (_objectConfig.ObjectType == PhysicObjectType.Dynamic && _objectConfig.DynamicObjectType == PhysicDynamicObjectType.CompoundBody || 
            _objectConfig.ObjectType == PhysicObjectType.Static && _objectConfig.StaticObjectType == PhysicStaticObjectType.StaticGroup)
        {
            var oldColor = Handles.color;
            var oldMatrix = Handles.matrix;
            var transform = _objectConfig.transform;
            Handles.matrix = Matrix4x4.TRS(transform.position, transform.rotation, UnityEngine.Vector3.one);
            for (int i = 0; i < _objectConfig.ShapeDataList.Count; i++)
            {
                var shapeData = _objectConfig.ShapeDataList[i];
                var v3Pos = (UnityEngine.Vector3) shapeData.LocalPosition;// + _objectConfig.transform.position;
                var v3Rotation = (UnityEngine.Vector3) shapeData.Rotation;
                var v3Scale = (UnityEngine.Vector3) shapeData.Scale;
                float hSize = HandleUtility.GetHandleSize(v3Pos);
                Handles.color = Color.red;
                Handles.lighting = true;
                switch (currentHandleType)
                {
                    case HandleType.Position:
                        var v3 = Handles.PositionHandle(v3Pos, Quaternion.Euler(v3Rotation));
                        shapeData.LocalPosition = (Vector3) v3;//(v3 - _objectConfig.transform.position);
                        break;
                    case HandleType.Rotation:
                        shapeData.Rotation = (Vector3) Handles.RotationHandle(Quaternion.Euler(v3Rotation),v3Pos).eulerAngles;
                        break;
                    case HandleType.Scale:
                        shapeData.Scale = (Vector3) Handles.ScaleHandle(v3Scale,v3Pos,Quaternion.Euler(v3Rotation), hSize);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            Handles.color = oldColor;
            Handles.matrix = oldMatrix;
        }
        
        // Handles.BeginGUI();
        // GUIWindow();
        // Handles.EndGUI();
    }
    
    

    //Scene GUI Window
    Rect Window1=new Rect(20,20,200,200);
    private void GUIWindow()
    {
        Window1 = GUILayout.Window(1, Window1, id =>
        {
            GUI.contentColor = Color.white;
            EditorGUILayout.LabelField("this is window");
            EditorGUILayout.ColorField(Color.cyan);
            EditorGUILayout.Toggle("Toggle", false);
            GUILayout.Button("Button");
            GUI.DragWindow();
        }, "Window");
    }
    
}