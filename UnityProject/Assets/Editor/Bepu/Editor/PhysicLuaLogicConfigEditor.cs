using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BEPUphysics.PositionUpdating;
using FixMath.NET;
using Simulation;
using UnityEditor;
using UnityEditor.Graphs;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;

[CustomEditor(typeof(PhysicLuaLogicConfig))]
public class PhysicLuaLogicConfigEditor:UnityEditor.Editor
{
    
    private PhysicLuaLogicConfig _logicConfig;
    void Awake()
    {
        _logicConfig = this.target as PhysicLuaLogicConfig;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        Undo.RecordObject(_logicConfig,"Logic"+_logicConfig.gameObject.name);
        DrawObjectList();
        EditorGUILayout.Space();
        DrawConstraintList();
        EditorGUILayout.Space();
        DrawLogicList();
        EditorGUILayout.Space();
        DrawLuaList();
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_logicConfig.gameObject);
            EditorUtility.SetDirty(target);
        }
    }

    private void DrawObjectList()
    {
        var oldColor = GUI.color;
        _logicConfig.ShowObjectList = EditorGUILayout.Foldout(_logicConfig.ShowObjectList, "物理对象列表");
        if (_logicConfig.ShowObjectList)
        {
            GUILayout.BeginHorizontal("box");
            GUI.color = Color.green;
            if (GUILayout.Button("新增"))
            {
                _logicConfig.ObjectConfigList.Add(null);
            }

            if (GUILayout.Button("GetChild"))
            {
                for (int i = 0; i < _logicConfig.transform.childCount; i++)
                {
                    var objConfig = _logicConfig.transform.GetChild(i).GetComponent<PhysicObjectConfig>();
                    if (objConfig != null)
                        _logicConfig.ObjectConfigList.Add(objConfig);    
                }
            }

            GUI.color = Color.red;
            if (GUILayout.Button("清空"))
            {
                _logicConfig.ObjectConfigList.Clear();
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < _logicConfig.ObjectConfigList.Count; i++)
            {
                GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                GUILayout.BeginHorizontal("box");
                _logicConfig.ObjectConfigList[i] = 
                    (PhysicObjectConfig)EditorGUILayout.ObjectField(_logicConfig.ObjectConfigList[i],typeof(PhysicObjectConfig));
                
                if (GUILayout.Button("删除"))
                {
                    _logicConfig.ObjectConfigList.RemoveAt(i);
                    i--;
                }
                GUILayout.EndHorizontal();
            }
        }

        GUI.color = oldColor;
    }
    private void DrawConstraintList()
    {
        var oldColor = GUI.color;
        _logicConfig.ShowConstraintList = EditorGUILayout.Foldout(_logicConfig.ShowConstraintList, "约束列表");
        if (_logicConfig.ShowConstraintList)
        {
            GUILayout.BeginHorizontal("box");
            GUI.color = Color.green;
            if (GUILayout.Button("新增"))
            {
                _logicConfig.ConstraintConfigList.Add(null);
            }

            GUI.color = Color.red;
            if (GUILayout.Button("清空"))
            {
                _logicConfig.ConstraintConfigList.Clear();
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < _logicConfig.ConstraintConfigList.Count; i++)
            {
                GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                GUILayout.BeginHorizontal("box");
                _logicConfig.ConstraintConfigList[i] = 
                    (PhysicConstraintConfig)EditorGUILayout.ObjectField(_logicConfig.ConstraintConfigList[i],typeof(PhysicConstraintConfig));
                
                if (GUILayout.Button("删除"))
                {
                    _logicConfig.ConstraintConfigList.RemoveAt(i);
                    i--;
                }
                GUILayout.EndHorizontal();
            }
        }
        GUI.color = oldColor;
    }
    
    private void DrawLogicList()
    {
        var oldColor = GUI.color;
        _logicConfig.ShowOtherLogicList = EditorGUILayout.Foldout(_logicConfig.ShowOtherLogicList, "其他关联逻辑代码");
        if (_logicConfig.ShowOtherLogicList)
        {
            GUILayout.BeginHorizontal("box");
            GUI.color = Color.green;
            if (GUILayout.Button("新增"))
            {
                _logicConfig.OtherLogicList.Add(null);
            }
            if (GUILayout.Button("GetChild"))
            {
                var logicConfigArray = _logicConfig.transform.GetComponentsInChildren<PhysicLuaLogicConfig>();
                foreach (PhysicLuaLogicConfig config in logicConfigArray)
                {
                    _logicConfig.OtherLogicList.Add(config);    
                }
                // for (int i = 0; i < _logicConfig.transform.childCount; i++)
                // {
                //     var objConfig = _logicConfig.transform.GetChild(i).GetComponent<PhysicLuaLogicConfig>();
                //     if (objConfig != null)
                //         _logicConfig.OtherLogicList.Add(objConfig);    
                // }
            }
            GUI.color = Color.red;
            if (GUILayout.Button("清空"))
            {
                _logicConfig.OtherLogicList.Clear();
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < _logicConfig.OtherLogicList.Count; i++)
            {
                GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                GUILayout.BeginHorizontal("box");
                _logicConfig.OtherLogicList[i] = 
                    (PhysicLuaLogicConfig)EditorGUILayout.ObjectField(_logicConfig.OtherLogicList[i],typeof(PhysicLuaLogicConfig));
                
                if (GUILayout.Button("删除"))
                {
                    _logicConfig.OtherLogicList.RemoveAt(i);
                    i--;
                }
                GUILayout.EndHorizontal();
            }
        }
        GUI.color = oldColor;
    }
    
    private void DrawLuaList()
    {
        var oldColor = GUI.color;
        _logicConfig.ShowLuaList = EditorGUILayout.Foldout(_logicConfig.ShowLuaList, "逻辑脚本");
        if (_logicConfig.ShowLuaList)
        {
            var values = Enum.GetValues(typeof(LuaLogicType));
            string[] nameArray = new string[values.Length];
            foreach (var value in values)
            {
                string name = value.ToString();
                int index = (int) value;
                FieldInfo fieldInfo = value.GetType().GetField(name);
                AliasAttribute aliasAttribute = fieldInfo.GetCustomAttributes(typeof(AliasAttribute), false).FirstOrDefault() as AliasAttribute;
                if (aliasAttribute != null)
                    nameArray[index] = aliasAttribute.Name;
            }

            _logicConfig.LuaName = (LuaLogicType)EditorGUILayout.Popup((int)_logicConfig.LuaName, nameArray.ToArray());
            _logicConfig.LuaName = (LuaLogicType)EditorGUILayout.EnumPopup("Lua名称：", _logicConfig.LuaName);
            ShowTips();
            _logicConfig.ShowString = EditorGUILayout.Foldout(_logicConfig.ShowString, "参数:String");
            if (_logicConfig.ShowString)
            {
                GUILayout.BeginHorizontal("box");
                GUI.color = Color.green;
                if (GUILayout.Button("新增参数"))
                {
                    _logicConfig.StringList.Add(new StringParameterData());
                }
                GUI.color = Color.red;
                if (GUILayout.Button("清空参数"))
                {
                    _logicConfig.StringList.Clear();
                }
                GUILayout.EndHorizontal();
                for (int i = 0; i < _logicConfig.StringList.Count; i++)
                {
                    GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                    GUILayout.BeginHorizontal("box");

                    _logicConfig.StringList[i].Name = EditorGUILayout.TextField(_logicConfig.StringList[i].Name);
                    _logicConfig.StringList[i].Value = EditorGUILayout.TextField(_logicConfig.StringList[i].Value);

                    if (GUILayout.Button("删除"))
                    {
                        _logicConfig.StringList.RemoveAt(i);
                        i--;
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUI.color = oldColor;
            _logicConfig.ShowInt = EditorGUILayout.Foldout(_logicConfig.ShowInt, "参数:Int");
            if (_logicConfig.ShowInt)
            {
                GUILayout.BeginHorizontal("box");
                GUI.color = Color.green;
                if (GUILayout.Button("新增参数"))
                {
                    _logicConfig.IntList.Add(new IntParameterData());
                }
                GUI.color = Color.red;
                if (GUILayout.Button("清空参数"))
                {
                    _logicConfig.IntList.Clear();
                }
                GUILayout.EndHorizontal();
                for (int i = 0; i < _logicConfig.IntList.Count; i++)
                {
                    GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                    GUILayout.BeginHorizontal("box");
                    _logicConfig.IntList[i].Name = EditorGUILayout.TextField(_logicConfig.IntList[i].Name);
                    _logicConfig.IntList[i].Value = EditorGUILayout.IntField(_logicConfig.IntList[i].Value);
                    if (GUILayout.Button("删除"))
                    {
                        _logicConfig.IntList.RemoveAt(i);
                        i--;
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUI.color = oldColor;
            _logicConfig.ShowFix64 = EditorGUILayout.Foldout(_logicConfig.ShowFix64, "参数:Fix64");
            if (_logicConfig.ShowFix64)
            {
                GUILayout.BeginHorizontal("box");
                GUI.color = Color.green;
                if (GUILayout.Button("新增参数"))
                {
                    _logicConfig.Fix64List.Add(new Fix64ParameterData());
                }
                GUI.color = Color.red;
                if (GUILayout.Button("清空参数"))
                {
                    _logicConfig.Fix64List.Clear();
                }
                GUILayout.EndHorizontal();
                for (int i = 0; i < _logicConfig.Fix64List.Count; i++)
                {
                    GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                    GUILayout.BeginHorizontal("box");

                    _logicConfig.Fix64List[i].Name = EditorGUILayout.TextField(_logicConfig.Fix64List[i].Name);
                    _logicConfig.Fix64List[i].Value = (Fix64)EditorGUILayout.FloatField((float)_logicConfig.Fix64List[i].Value);

                    if (GUILayout.Button("删除"))
                    {
                        _logicConfig.Fix64List.RemoveAt(i);
                        i--;
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUI.color = oldColor;
            _logicConfig.ShowV3 = EditorGUILayout.Foldout(_logicConfig.ShowV3, "参数:Vector3");
            if (_logicConfig.ShowV3)
            {
                GUILayout.BeginHorizontal("box");
                GUI.color = Color.green;
                if (GUILayout.Button("新增参数"))
                {
                    _logicConfig.V3List.Add(new V3ParameterData());
                }
                GUI.color = Color.red;
                if (GUILayout.Button("清空参数"))
                {
                    _logicConfig.V3List.Clear();
                }
                GUILayout.EndHorizontal();
                for (int i = 0; i < _logicConfig.V3List.Count; i++)
                {
                    GUI.color = i%2 == 1 ? Color.cyan : Color.green;
                    GUILayout.BeginHorizontal("box");

                    _logicConfig.V3List[i].Name = EditorGUILayout.TextField(_logicConfig.V3List[i].Name);
                    _logicConfig.V3List[i].Value = (BEPUutilities.Vector3)EditorGUILayout.Vector3Field("",(UnityEngine.Vector3)(_logicConfig.V3List[i].Value));

                    if (GUILayout.Button("删除"))
                    {
                        _logicConfig.V3List.RemoveAt(i);
                        i--;
                    }
                    GUILayout.EndHorizontal();
                }
            }
        }
        GUI.color = oldColor;
    }

    private void ShowTips()
    {
        _logicConfig.ShowTips = EditorGUILayout.Foldout(_logicConfig.ShowTips, "脚本说明");
        if (_logicConfig.ShowTips)
        {
            switch (_logicConfig.LuaName)
            {
                case LuaLogicType.None:
                    EditorGUILayout.HelpBox("请选择逻辑", MessageType.Error);
                    break;
                case LuaLogicType.CheckPoint:
                    EditorGUILayout.HelpBox("检查点：仅需一个物理对象(非静态)", MessageType.Info);
                    break;
                case LuaLogicType.WinnerBox:
                    EditorGUILayout.HelpBox("胜利区域：仅需一个物理对象(非静态)\n玩家碰到就胜利", MessageType.Info);
                    break;
                case LuaLogicType.Cannon:
                    EditorGUILayout.HelpBox("大炮：未完成", MessageType.Info);
                    break;
                case LuaLogicType.Conveyor:
                    EditorGUILayout.HelpBox("传送带：需要物理对象\n参数：MoveSpeed 移动速度", MessageType.Info);
                    break;
                case LuaLogicType.DeadBox:
                    EditorGUILayout.HelpBox("死亡区域：仅需一个物理对象(非静态)\n玩家碰到就死亡", MessageType.Info);
                    break;
                case LuaLogicType.Drawbridge:
                    EditorGUILayout.HelpBox("吊桥：需要约束\nDelayTime：延迟时间\nIntervalTime:间隔时间", MessageType.Info);
                    break;
                case LuaLogicType.FallDown:
                    EditorGUILayout.HelpBox("玩家摔倒：仅需一个物理对象(非静态)\n玩家碰到就会摔倒", MessageType.Info);
                    break;
                case LuaLogicType.PathMove:
                    EditorGUILayout.HelpBox("路径移动：仅需一个物理对象(非静态)\n物体会根据预设路径移动", MessageType.Info);
                    break;
                case LuaLogicType.Pendulum:
                    EditorGUILayout.HelpBox("钟摆：需要约束\n无参数\n速度由约束参数决定", MessageType.Info);
                    break;
                case LuaLogicType.Track:
                    EditorGUILayout.HelpBox("轨道：需要约束\nDelayTime：延迟时间", MessageType.Info);
                    break;
                case LuaLogicType.Trampoline:
                    EditorGUILayout.HelpBox("蹦床：需要物理对象\nY:弹跳向上的力", MessageType.Info);
                    break;
                case LuaLogicType.VanishFloor:
                    EditorGUILayout.HelpBox("消失的地板：需要物理对象\nIntervalTime:间隔时间\nnDelayTime:延迟时间\nTime:持续时间", MessageType.Info);
                    break;
                case LuaLogicType.WindZone:
                    EditorGUILayout.HelpBox("风区：需要物理对象\nX,Y,Z:风向力", MessageType.Info);
                    break;
                case LuaLogicType.TrapFloor:
                    EditorGUILayout.HelpBox("地砖陷阱：踩上去可能掉落", MessageType.Info);
                    break;
                case LuaLogicType.TrapFloorGroup:
                    EditorGUILayout.HelpBox("地砖陷阱：需要6x6物理对象", MessageType.Info);
                    break;
                case LuaLogicType.Billboard:
                    EditorGUILayout.HelpBox("第4关 广告牌", MessageType.Info);
                    break;
                case LuaLogicType.BillboardFloor:
                    EditorGUILayout.HelpBox("第4关 广告牌地板", MessageType.Info);
                    break;
                case LuaLogicType.BillboardController:
                    EditorGUILayout.HelpBox("第4关 广告牌控制器", MessageType.Info);
                    break;
                case LuaLogicType.PropsBox:
                    EditorGUILayout.HelpBox("道具盒子，碰 噼里啪啦！", MessageType.Info);
                    break;
                case LuaLogicType.Level7FlipFloor:
                    EditorGUILayout.HelpBox("Level7", MessageType.Info);
                    break;
                case LuaLogicType.Level9FlipFloor:
                    EditorGUILayout.HelpBox("Level9", MessageType.Info);
                    break;
                case LuaLogicType.Star:
                    EditorGUILayout.HelpBox("星星", MessageType.Info);
                    break;
                case LuaLogicType.Level9RandomStar:
                    EditorGUILayout.HelpBox("Level9RandomStar", MessageType.Info);
                    break;
                case LuaLogicType.Dyed:
                    EditorGUILayout.HelpBox("Dyed", MessageType.Info);
                    break;
                case LuaLogicType.Jam:
                    EditorGUILayout.HelpBox("果酱，啫喱", MessageType.Info);
                    break;
                case LuaLogicType.CustomizeEvents:
                    EditorGUILayout.HelpBox("CustomizeEvents，CustomizeEvents", MessageType.Info);
                    break;
                case LuaLogicType.SwitchBridge:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.ObjectResurrection:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.PushBallTraining:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.TrainVanishFloor:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.TrainVanishFloorController:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.PropsTraining:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.AutoCamera:
                    EditorGUILayout.HelpBox(" ", MessageType.Info);
                    break;
                case LuaLogicType.Football:
                    EditorGUILayout.HelpBox("足球 引用2个球门Trigger ", MessageType.Info);
                    break;
                case LuaLogicType.TramplingTrapFloor:
                    EditorGUILayout.HelpBox("踩踏 会消失的地板\nWarningTime为踩踏后多久地板消失。\nResetTime为消失后多久恢复地板，如果不设置则永远不恢复。 ", MessageType.Info);
                    break;
                case LuaLogicType.AcceleratedRotation:
                    EditorGUILayout.HelpBox("加速旋转\nDelayTime 可不配置\nStartVelocity\nEndVelocity\nLerpTime", MessageType.Info);
                    break;
                case LuaLogicType.PropTarget:
                case LuaLogicType.AngularVelocity:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
}