using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BEPUphysics.PositionUpdating;
using FixMath.NET;
using Simulation;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using Vector3 = BEPUutilities.Vector3;

public partial class PhysicConfigWindow
{
    private Vector2 currentPhysicObjectScrollView;

    private void OnShowPhysicObjectWindow()
    {
    }
    
    private void DrawPhysicObjectWindow()
    {
        Color oldColor = GUI.color;
        currentPhysicObjectScrollView = GUILayout.BeginScrollView(currentPhysicObjectScrollView);
        GUILayout.BeginVertical("box");
        GUILayout.BeginHorizontal();
        EditorGUI.BeginChangeCheck();
        bool isDebug = PlayerPrefs.GetInt("PhysicDebug") == 1;
        GUI.color = isDebug ? Color.green : Color.red;
        if (GUILayout.Button("Debug显示"))
            PlayerPrefs.SetInt("PhysicDebug", isDebug ? 0 : 1);
        bool isWire = PlayerPrefs.GetInt("PhysicWire") == 1;
        GUI.color = isWire ? Color.green : Color.red;
        if (GUILayout.Button("线框显示"))
            PlayerPrefs.SetInt("PhysicWire", isWire ? 0 : 1);
        
        if (EditorGUI.EndChangeCheck() && allPhysicObject.Length > 0)
        {
            EditorUtility.SetDirty(allPhysicObject[0].gameObject);
        }
        GUI.color = oldColor;
        GUILayout.EndHorizontal();

        GUILayout.Label($"出生点：{allStartPoints.Length}");
        
        GUILayout.BeginHorizontal();
        DrawDynamicObjectInfo();
        DrawStaticObjectInfo();
        DrawLogicInfo();
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();
        GUI.color = Color.cyan;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("导出当前场景物理数据",GUILayout.Width(150)))
        {
            ExportLevelConfigJson(JsonFilePath,JsonFileName);
        }
        GUI.color = oldColor;
        EditorGUI.BeginChangeCheck();
        JsonFilePath = GUILayout.TextField(JsonFilePath);
        JsonFileName = GUILayout.TextField(JsonFileName);
        if (EditorGUI.EndChangeCheck())
        {
            PlayerPrefs.SetString("LevelConfigPath",JsonFilePath);
            PlayerPrefs.SetString("LevelConfigName",JsonFileName);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
        GUI.color = oldColor;
    }

    private Dictionary<PhysicDynamicObjectType, bool> dynamicFoldout = new Dictionary<PhysicDynamicObjectType, bool>();
    private bool allTriggerFoldout;
    private void DrawDynamicObjectInfo()
    {
        var oldColor = GUI.color;
        GUI.color = Color.cyan;
        GUILayout.BeginVertical("box",GUILayout.Width(this.position.width/3f));
        GUI.color = oldColor;
        int dynamicCount = allPhysicConfig[PhysicObjectType.Dynamic].Count;
        GUILayout.Label($"动态物体数量：{dynamicCount}");
        allTriggerFoldout = EditorGUILayout.Foldout(allTriggerFoldout,"所有触发器Trigger");
        if (allTriggerFoldout)
        {
            foreach (PhysicObjectConfig objectConfig in allPhysicConfig[PhysicObjectType.Dynamic])
            {
                if (!objectConfig.IsTrigger)
                    continue;
                GUILayout.BeginHorizontal("box");
                GUI.color = oldColor;
                if (objectConfig.DynamicObjectType == PhysicDynamicObjectType.DynamicMesh && objectConfig.Mesh == null)
                    GUI.color = Color.red;
                GUILayout.Label(objectConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {objectConfig.gameObject};
                }
                GUI.color = oldColor;
                GUILayout.EndHorizontal();
            }
        }
        foreach (var dynamicObject in dynamicObjects)
        {
            if (!dynamicFoldout.ContainsKey(dynamicObject.Key))
                dynamicFoldout.Add(dynamicObject.Key,false);
            dynamicFoldout[dynamicObject.Key] = EditorGUILayout.Foldout(dynamicFoldout[dynamicObject.Key],$"{dynamicObject.Key.ToString()}：{dynamicObject.Value.Count}");
            if (dynamicFoldout[dynamicObject.Key])
            {
                for (int i = 0; i < dynamicObject.Value.Count; i++)
                {
                    var objectConfig = dynamicObject.Value[i];
                    if (i%2==1)
                        GUI.color = Color.cyan;
                    else
                        GUI.color = Color.green;
                    GUILayout.BeginHorizontal("box");
                    GUI.color = oldColor;
                    
                    if (objectConfig.DynamicObjectType == PhysicDynamicObjectType.DynamicMesh)
                    {
                        if (objectConfig.Mesh == null)
                        {
                            GUI.color = Color.red;
                        }
                        else
                        {
                            int count = objectConfig.Mesh.vertices.Length;
                            if (count > 300)
                                GUI.color = Color.red;
                            GUILayout.Label($"顶点数量：{count}");
                            GUI.color = oldColor;
                        }
                    }
                    GUILayout.Label(objectConfig.gameObject.name);
                    if (GUILayout.Button("选中",GUILayout.Width(130)))
                    {
                        UnityEditor.Selection.objects = new Object[] {objectConfig.gameObject};
                    }
                    GUI.color = oldColor;
                    GUILayout.EndHorizontal();
                }
            }
        }

        GUI.color = oldColor;
        GUILayout.EndVertical();
    }

    private Dictionary<PhysicStaticObjectType, bool> staticFoldout = new Dictionary<PhysicStaticObjectType, bool>();
    private void DrawStaticObjectInfo()
    {
        var oldColor = GUI.color;
        GUI.color = Color.cyan;
        int staticCount = allPhysicConfig[PhysicObjectType.Static].Count;
        GUILayout.BeginVertical("box",GUILayout.Width(this.position.width/3f));
        GUI.color = oldColor;
        GUILayout.Label($"静态物体数量：{staticCount}");
        
        foreach (var staticObject in staticObjects)
        { 
            if (!staticFoldout.ContainsKey(staticObject.Key))
                staticFoldout.Add(staticObject.Key,false);
            staticFoldout[staticObject.Key] = EditorGUILayout.Foldout(staticFoldout[staticObject.Key],$"{staticObject.Key.ToString()}：{staticObject.Value.Count}");
            if (staticFoldout[staticObject.Key])
            {
                for (int i = 0; i < staticObject.Value.Count; i++)
                {
                    var objectConfig = staticObject.Value[i];
                    if (i%2==1)
                        GUI.color = Color.cyan;
                    else
                        GUI.color = Color.green;
                    GUILayout.BeginHorizontal("box");
                    GUI.color = oldColor;
                    if (objectConfig.StaticObjectType == PhysicStaticObjectType.StaticMesh)
                    {
                        if (objectConfig.Mesh == null)
                        {
                            GUI.color = Color.red;
                        }
                        else
                        {
                            int count = objectConfig.Mesh.vertices.Length;
                            if (count > 300)
                                GUI.color = Color.red;
                            GUILayout.Label($"顶点数量：{count}");
                            GUI.color = oldColor;
                        }
                    }
                    GUILayout.Label($"[ {objectConfig.gameObject.name} ]");
                    if (GUILayout.Button("选中",GUILayout.Width(130)))
                    {
                        UnityEditor.Selection.objects = new Object[] {objectConfig.gameObject};
                    }
                    GUI.color = oldColor;
                    GUILayout.EndHorizontal();
                }
            }
        }

        GUILayout.EndVertical();
    }

    private void DrawLogicInfo()
    {
        var oldColor = GUI.color;
        GUI.color = Color.cyan;
        GUILayout.BeginVertical("box",GUILayout.Width(this.position.width/3f));
        GUI.color = oldColor;
        int dynamicCount = allLuaLogic.Length;
        GUILayout.Label($"逻辑数量：：{dynamicCount}");

        showLogic = EditorGUILayout.Foldout(showLogic,$"逻辑List");
        if (showLogic)
        {
            foreach (var logicConfig in allLuaLogic)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(logicConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {logicConfig.gameObject};
                }
                GUILayout.EndHorizontal();
            }
        }
        GUI.color = Color.red;
        GUILayout.Label("错误检查： ");
        GUI.color = oldColor;
        foreach (var logicConfig in allLuaLogic)
        {
            foreach (var config in logicConfig.OtherLogicList)
            {
                if (config == null)
                {
                    GUI.color = Color.red;
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label("逻辑为空 "+logicConfig.gameObject.name);
                    if (GUILayout.Button("选中",GUILayout.Width(130)))
                    {
                        UnityEditor.Selection.objects = new Object[] {logicConfig.gameObject};
                    }
                    GUILayout.EndHorizontal();
                    GUI.color = oldColor;
                }
            }
            
            bool haveNull = false;
            bool notEntity = false;
            foreach (PhysicObjectConfig objectConfig in logicConfig.ObjectConfigList)
            {
                if (objectConfig == null)
                {
                    haveNull = true;
                    break;
                }
                else if(objectConfig.ObjectType == PhysicObjectType.Static)
                {
                    notEntity = true;
                }
            }
            foreach (var objectConfig in logicConfig.ConstraintConfigList)
            {
                if (objectConfig == null)
                {
                    haveNull = true;
                    break;
                }
            }

            if (notEntity)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("选中的Object非Entity"+logicConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {logicConfig.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }
            if (haveNull)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("未选Object "+logicConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {logicConfig.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }
            if (logicConfig.LuaName == LuaLogicType.None)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("未选逻辑 "+logicConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {logicConfig.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }

            if (logicConfig.ObjectConfigList.Count == 0 &&
                logicConfig.ConstraintConfigList.Count == 0 &&
                logicConfig.OtherLogicList.Count == 0)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("未选目标 "+logicConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {logicConfig.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }
        }

        foreach (PhysicConstraintConfig constr in allPhysicConstraint)
        {
            bool notEntity = false;
            if (constr.EntityA != null && constr.EntityA.ObjectType == PhysicObjectType.Static)
                notEntity = true;
            if (constr.EntityB != null && constr.EntityB.ObjectType == PhysicObjectType.Static)
                notEntity = true;

            if (notEntity)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("选中的Object非Entity"+constr.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {constr.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }

            if (constr.RotateAxis == Vector3.Zero)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("轴向为0"+constr.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {constr.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }
        }

        foreach (var objectConfig in allPhysicObject)
        {
            var scale = objectConfig.transform.lossyScale;
            if (scale.x <= 0 || scale.y <= 0 || scale.z <= 0)
            {
                GUI.color = Color.red;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("缩放为负："+objectConfig.gameObject.name);
                if (GUILayout.Button("选中",GUILayout.Width(130)))
                {
                    UnityEditor.Selection.objects = new Object[] {objectConfig.gameObject};
                }
                GUILayout.EndHorizontal();
                GUI.color = oldColor;
            }
        }
        
        
        
        GUILayout.EndVertical();
    }
    
    // private void DrawErrorCheck()
    // {
    //     var oldColor = GUI.color;
    //     EditorGUI.BeginChangeCheck();
    //     ErrorCheck = EditorGUILayout.Foldout(ErrorCheck, "错误检查");
    //     if (EditorGUI.EndChangeCheck())
    //     {
    //         PlayerPrefs.SetInt("PhysicErrorCheck",ErrorCheck?1:0);
    //     }
    //
    //     if (ErrorCheck)
    //     {
    //         EditorGUILayout.Space();
    //         GUI.color = Color.red;
    //         GUILayout.BeginHorizontal();
    //         GUILayout.BeginVertical("box");
    //         foreach (var config in allPhysicObject)
    //         {
    //             if (config.NodeType != PhysicObjectConfig.PhysicType.StaticMesh && 
    //                 (string.IsNullOrEmpty(config.PrefabName)||config.PrefabName.Length<3))
    //             {
    //                 GUILayout.Label($"{config.gameObject.name}:PrefabName为空！");
    //             }
    //         }
    //         GUI.color = oldColor;
    //         GUILayout.EndVertical();
    //         
    //         GUILayout.BeginVertical("box");
    //         
    //         if (allPhysicConfig.ContainsKey(PhysicObjectConfig.PhysicType.StaticMesh))
    //         {
    //             var list = allPhysicConfig[PhysicObjectConfig.PhysicType.StaticMesh];
    //             int verticeCount = 0;
    //             foreach (var config in list)
    //             {
    //                 if (config.Mesh == null)
    //                 {
    //                     EditorGUILayout.BeginHorizontal("box");
    //                     EditorGUILayout.HelpBox("Mesh为空: "+config.gameObject.name, MessageType.Error);
    //                     if (GUILayout.Button("选中",GUILayout.Height(35),GUILayout.Width(100)))
    //                     {
    //                         UnityEditor.Selection.objects = new Object[] {config.gameObject};
    //                     }
    //                     EditorGUILayout.EndHorizontal();
    //                     
    //                     continue;
    //                 }
    //                 if (config.Mesh.vertices.Length > 500)
    //                 {
    //                     GUI.color = Color.magenta;
    //                     GUILayout.Label($"单个静态网格顶点数过高！：{config.Mesh.vertices.Length} ----> {config.gameObject.name}");
    //                     GUI.color = oldColor;
    //                 }
    //                 verticeCount += config.Mesh.vertices.Length;
    //             }
    //             if (verticeCount > 1500)
    //             {
    //                 GUI.color = Color.red;
    //             }
    //             GUILayout.Label($"总静态网格顶点数：{verticeCount}");
    //         }
    //         GUI.color = oldColor;
    //         if (allPhysicConfig.ContainsKey(PhysicObjectConfig.PhysicType.DynamicMesh))
    //         {
    //             var list = allPhysicConfig[PhysicObjectConfig.PhysicType.DynamicMesh];
    //             int verticeCount = 0;
    //             foreach (var config in list)
    //             {
    //                 if (config.Mesh == null)
    //                 {
    //                     EditorGUILayout.BeginHorizontal("box");
    //                     EditorGUILayout.HelpBox("Mesh为空: "+config.gameObject.name, MessageType.Error);
    //                     if (GUILayout.Button("选中",GUILayout.Height(35)))
    //                     {
    //                         UnityEditor.Selection.objects = new Object[] {config.gameObject};
    //                     }
    //                     EditorGUILayout.EndHorizontal();
    //                     
    //                     continue;
    //                 }
    //                 verticeCount += config.Mesh.vertices.Length;
    //                 if (config.Mesh.vertices.Length > 500)
    //                 {
    //                     GUI.color = Color.magenta;
    //                     GUILayout.Label($"单个动态网格顶点数过高！：{config.Mesh.vertices.Length} ----> {config.gameObject.name}");
    //                     GUI.color = oldColor;
    //                 }
    //             }
    //             if (verticeCount > 1500)
    //             {
    //                 GUI.color = Color.red;
    //             }
    //             GUILayout.Label($"总动态网格顶点数：{verticeCount}");
    //         }
    //         GUILayout.EndVertical();
    //         GUILayout.EndHorizontal();
    //         EditorGUILayout.Space();
    //         GUI.color = oldColor;
    //     }
    //     
    //     
    // }
    
    public LevelGuideData ExportGuideConfig()
    {
        allGuidConfig = GameObject.FindObjectsOfType<GuideConfig>();
        LevelGuideData levelGuideData = new LevelGuideData();
        levelGuideData.GuideConfigDataList = new List<LevelGuideConfigData>();
        foreach (GuideConfig config in allGuidConfig)
        {
            LevelGuideConfigData configData = new LevelGuideConfigData();
            configData.Id = config.GetInstanceID();
            configData.TriggerType = config.Data.TriggerType;
            configData.TriggerObject = config.Data.TriggerObject.GetInstanceID();
            configData.EventConfigs = new List<GuideEventConfig>();
            for (int i = 0; i < config.Data.EventConfigs.Count; i++)
            {
                var eventConfig = config.Data.EventConfigs[i];
                GuideEventConfig guideEventConfig = new GuideEventConfig();
                guideEventConfig.WaitTime = eventConfig.WaitTime;
                guideEventConfig.EventType = eventConfig.EventType;
                if (eventConfig.EventType == GuideEventType.Talk)
                    guideEventConfig.TalkString = eventConfig.TalkString;
                else if (eventConfig.EventType == GuideEventType.ShowTips)
                    guideEventConfig.TalkString = eventConfig.TipsString;
                guideEventConfig.CameraPosition = eventConfig.CameraPosition;
                guideEventConfig.CameraRotation = eventConfig.CameraRotation;
                guideEventConfig.MoveToTargetList = new List<int>();
                if (eventConfig.Wall)
                    guideEventConfig.Wall = eventConfig.Wall.GetInstanceID();
                guideEventConfig.PointTargetList = new List<int>();
                for (int j = 0; j < eventConfig.MoveToTargetList.Count; j++)
                {
                    var objectConfig = eventConfig.MoveToTargetList[j];
                    guideEventConfig.MoveToTargetList.Add(objectConfig.GetInstanceID());
                }
                for (int j = 0; j < eventConfig.PointTargetList.Count; j++)
                {
                    var objectConfig = eventConfig.PointTargetList[j];
                    guideEventConfig.PointTargetList.Add(objectConfig.GetInstanceID());
                }
                configData.EventConfigs.Add(guideEventConfig);
            }
            levelGuideData.GuideConfigDataList.Add(configData);
        }

        return levelGuideData;
    }
    
    private void ExportLevelConfigJson(string filePath,string fileName)
    {
        GetPhysicObject();
        string path = Application.dataPath + filePath + fileName + ".json";
        PhysicLevelConfig levelConfig = new PhysicLevelConfig();
        levelConfig.LevelGuideData = ExportGuideConfig();
        levelConfig.LevelRulesData = new LevelRulesData()
        {
            LevelName = levelRulesConfig.LevelName,
            LevelDesc = levelRulesConfig.LevelDesc,
            LevelTargetDesc = levelRulesConfig.LevelTargetDesc,
            LevelModel = levelRulesConfig.LevelModel,
            Gravity = levelRulesConfig.Gravity,
            PlayerMoveSpeed = levelRulesConfig.PlayerMoveSpeed,
            PlayerAirSpeed = levelRulesConfig.PlayerAirSpeed,
            PlayerJumpSpeed = levelRulesConfig.PlayerJumpSpeed,
            DeadRules = levelRulesConfig.DeadRules,
            // VictoryRules = levelRulesConfig.VictoryRules,
            OverCheckerDataList = levelRulesConfig.OverCheckerDataList,
        };
        levelConfig.StartPoints = new List<StartPointData>();
        levelConfig.PhysicObjectConfigList = new List<ObjectConfig>();
        levelConfig.ConstraintConfigList = new List<ConstraintConfig>();
        levelConfig.LuaLogicConfigList = new List<LuaLogicConfig>();
        levelConfig.CameraPath = new List<Vector3>();
        levelConfig.CameraTargetPath = new List<Vector3>();
        for (int i = 0; i < allCameraPath.Length; i++)
        {
            if (allCameraPath[i].Value == 0)
            {
                for (int j = 0; j < allCameraPath[i].transform.childCount; j++)
                    levelConfig.CameraPath.Add((Vector3)(allCameraPath[i].transform.GetChild(j).position));
            }
            else
            {
                for (int j = 0; j < allCameraPath[i].transform.childCount; j++)
                    levelConfig.CameraTargetPath.Add((Vector3)(allCameraPath[i].transform.GetChild(j).position));
            }
        }

        for (int i = 0; i < allStartPoints.Length; i++)
        {
            // Debug.Log(allStartPoints[i].gameObject.name + "   =====   "+ (allStartPoints[i].transform.GetSiblingIndex() + 1));
            levelConfig.StartPoints.Add(new StartPointData()
            {
                Position = (Vector3)allStartPoints[i].transform.position, 
                Rotation = (BEPUutilities.Quaternion)allStartPoints[i].transform.rotation, 
                Index = allStartPoints[i].transform.GetSiblingIndex() + 1, 
            });
        }
        
        for (int i = 0; i < allPhysicObject.Length; i++)
        {
            var obj = allPhysicObject[i];
            ObjectConfig objectConfig = new ObjectConfig();
            objectConfig.Id = obj.GetInstanceID();
            objectConfig.PrefabName = obj.PrefabName;
            objectConfig.PhysicLayer = obj.PhysicLayer;
            objectConfig.ObjectType = obj.ObjectType;
            objectConfig.StaticType = obj.StaticObjectType;
            objectConfig.IsUseOffset = obj.IsUseOffset;
            
            objectConfig.CustomizeMaterial = obj.CustomizeMaterial;
            objectConfig.KineticFriction = (Fix64)obj.KineticFriction;
            objectConfig.StaticFriction = (Fix64)obj.StaticFriction;
            objectConfig.Bounciness = (Fix64)obj.Bounciness;
            
            if (objectConfig.IsUseOffset)
            {
                objectConfig.PositionOffset = obj.PositionOffset;
                objectConfig.RotationOffset = BEPUutilities.Quaternion.Euler(obj.RotationOffset);
            }
            // objectConfig.LuaScript = obj.LuaScript;
            // objectConfig.ParameterList = new List<LuaScriptParameter>();
            // foreach (ScriptParameter parameter in obj.ParameterList)
            // {
            //     objectConfig.ParameterList.Add(new LuaScriptParameter()
            //     {
            //         Name = parameter.Name,
            //         Value = parameter.Value
            //     });
            // }
            //
            if (objectConfig.ObjectType == PhysicObjectType.Dynamic)
            {
                objectConfig.DynamicType = obj.DynamicObjectType;
                objectConfig.UpdateMode = obj.UpdateMode;
                objectConfig.IsUseIndependentGravity = obj.IsUseIndependentGravity;
                objectConfig.Gravity = obj.Gravity;
                objectConfig.IsTrigger = obj.IsTrigger;
                objectConfig.Mass = (Fix64)obj.Mass;
                objectConfig.Size = obj.Size;
            }
            objectConfig.Transform = new TransformData()
            {
                Position = (BEPUutilities.Vector3)(obj.transform.position),
                Rotation = (BEPUutilities.Quaternion)(obj.transform.rotation),
                Scale = (BEPUutilities.Vector3)(obj.transform.lossyScale)
            };
            if (((objectConfig.ObjectType == PhysicObjectType.Dynamic && objectConfig.DynamicType == PhysicDynamicObjectType.DynamicMesh)||
                (objectConfig.ObjectType == PhysicObjectType.Static && objectConfig.StaticType == PhysicStaticObjectType.StaticMesh))
                && obj.Mesh != null)
            {
                objectConfig.MeshName = obj.Mesh.name;
            }

            objectConfig.ShapeDataList = new List<BepuPhysicShapeData>();
            foreach (PhysicShapeData shapeData in obj.ShapeDataList)
            {
                BepuPhysicShapeData bepuShapeData = new BepuPhysicShapeData()
                {
                    ShapeType = shapeData.ShapeType,
                    MassWeight = shapeData.MassWeight,
                    LocalPosition = shapeData.LocalPosition,
                    Rotation = shapeData.Rotation,
                    Scale = shapeData.Scale,
                    MeshName = shapeData.Mesh==null?"":shapeData.Mesh.name,
                };
                objectConfig.ShapeDataList.Add(bepuShapeData);
            }
            
            
            levelConfig.PhysicObjectConfigList.Add(objectConfig);
        }

        for (int i = 0; i < allPhysicConstraint.Length; i++)
        {
            var constraint = allPhysicConstraint[i];
            ConstraintConfig config = new ConstraintConfig();
            config.Id = constraint.GetInstanceID();
            config.ConstraintType = constraint.ConstraintType;
            config.CenterOffset = constraint.CenterOffset;
            config.RotateAxis = constraint.RotateAxis;
            config.MaxForce = constraint.MaxForce;
            config.GoalValue = constraint.GoalValue;
            config.EntityAId = constraint.EntityA != null?constraint.EntityA.GetInstanceID():0;
            config.EntityBId = constraint.EntityB.GetInstanceID();
            config.UseLimit = constraint.UseLimit;
            config.Minimum = constraint.Minimum;
            config.Maximum = constraint.Maximum;
            config.UseMotor = constraint.UseMotor;
            config.MotorMode = constraint.MotorMode;
            // config.LuaScript = constraint.LuaScript;
            //
            // config.ParameterList = new List<LuaScriptParameter>();
            // foreach (ScriptParameter parameter in constraint.ParameterList)
            // {
            //     config.ParameterList.Add(new LuaScriptParameter()
            //     {
            //         Name = parameter.Name,
            //         Value = parameter.Value
            //     });
            // }
            
            levelConfig.ConstraintConfigList.Add(config);
        }

        for (int i = 0; i < allLuaLogic.Length; i++)
        {
            var logic = allLuaLogic[i];
            LuaLogicConfig newConfig = new LuaLogicConfig();
            newConfig.Id = logic.GetInstanceID();
            newConfig.EntityIdList = new List<int>();
            newConfig.ConstraintIdList = new List<int>();
            newConfig.LuaLogicIdList = new List<int>();
            newConfig.LuaName = logic.LuaName.ToString();
            newConfig.StringParameterList = logic.StringList;
            newConfig.IntParameterList = logic.IntList;
            newConfig.Fix64ParameterList = logic.Fix64List;
            newConfig.V3ParameterList = logic.V3List;
            for (int j = 0; j < logic.ObjectConfigList.Count; j++)
                newConfig.EntityIdList.Add(logic.ObjectConfigList[j].GetInstanceID());
            for (int j = 0; j < logic.ConstraintConfigList.Count; j++)
                newConfig.ConstraintIdList.Add(logic.ConstraintConfigList[j].GetInstanceID());
            for (int j = 0; j < logic.OtherLogicList.Count; j++)
                newConfig.LuaLogicIdList.Add(logic.OtherLogicList[j].GetInstanceID());
            levelConfig.LuaLogicConfigList.Add(newConfig);
        }
        
        var json = JsonUtility.ToJson(levelConfig,true);

        var bytes = System.Text.Encoding.UTF8.GetBytes(json);
        File.WriteAllBytes(path, bytes);  
        Debug.Log("导出成功："+path);
        AssetDatabase.Refresh();
        this.ShowNotification(new GUIContent("导出成功："+fileName));
    }
}