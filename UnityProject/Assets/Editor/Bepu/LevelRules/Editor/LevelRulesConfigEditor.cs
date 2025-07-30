using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FixMath.NET;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LevelRulesConfig))]
public class LevelRulesConfigEditor : UnityEditor.Editor
{
    private LevelRulesConfig _levelRulesConfig;
    private GUIStyle _guiStyle1;
    private string[] _deadRulesStrArray;
    // private string[] _victoryRulesStrArray;
    private string[] _gameOverCheckerStrArray;
    private string[] _levelModelStrArray;
    public void OnEnable()
    {
        _levelRulesConfig = (LevelRulesConfig) this.target;
        
        _guiStyle1 = new GUIStyle();
        _guiStyle1.fontSize = 26;
        _guiStyle1.normal.textColor = Color.green;
        _guiStyle1.font = Resources.Load<Font>("EditorFont");

        ParseEnum(typeof(DeadRules), ref _deadRulesStrArray);
        // ParseEnum(typeof(VictoryRules), ref _victoryRulesStrArray);
        ParseEnum(typeof(GameOverChecker), ref _gameOverCheckerStrArray);
        ParseEnum(typeof(LevelModelTypes), ref _levelModelStrArray);
    }

    public override void OnInspectorGUI()
    {
        var oldColor = GUI.color;
        
        Undo.RecordObject(_levelRulesConfig,"_levelRulesConfig"+_levelRulesConfig.GetInstanceID());
        EditorGUI.BeginChangeCheck();
        
        EditorGUILayout.LabelField("关卡基本信息",_guiStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("关卡名称：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        _levelRulesConfig.LevelName = EditorGUILayout.TextField(_levelRulesConfig.LevelName);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("关卡介绍：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        _levelRulesConfig.LevelDesc = EditorGUILayout.TextField(_levelRulesConfig.LevelDesc,new GUILayoutOption[]{GUILayout.Height(60)});
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("关卡目标：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        _levelRulesConfig.LevelTargetDesc = EditorGUILayout.TextField(_levelRulesConfig.LevelTargetDesc);
        EditorGUILayout.EndHorizontal();
        
        // EditorGUILayout.LabelField("关卡模式",_guiStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("关卡模式：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        _levelRulesConfig.LevelModel = (LevelModelTypes)EditorGUILayout.Popup((int)_levelRulesConfig.LevelModel, _levelModelStrArray);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("关卡重力：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        _levelRulesConfig.Gravity = (BEPUutilities.Vector3)EditorGUILayout.Vector3Field("", (Vector3)_levelRulesConfig.Gravity);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.LabelField("玩家信息",_guiStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("玩家移动速度：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(80)});
        _levelRulesConfig.PlayerMoveSpeed = (Fix64)EditorGUILayout.FloatField((float)_levelRulesConfig.PlayerMoveSpeed);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("玩家空中速度：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(80)});
        _levelRulesConfig.PlayerAirSpeed = (Fix64)EditorGUILayout.FloatField((float)_levelRulesConfig.PlayerAirSpeed);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("玩家跳跃速度：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(80)});
        _levelRulesConfig.PlayerJumpSpeed = (Fix64)EditorGUILayout.FloatField((float)_levelRulesConfig.PlayerJumpSpeed);
        EditorGUILayout.EndHorizontal();
        
        
        EditorGUILayout.LabelField("玩家死亡规则",_guiStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("死亡规则：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        _levelRulesConfig.DeadRules = (DeadRules)EditorGUILayout.Popup((int)_levelRulesConfig.DeadRules, _deadRulesStrArray);
        EditorGUILayout.EndHorizontal();
        
        // EditorGUILayout.LabelField("玩家胜利规则",_guiStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
        // EditorGUILayout.BeginHorizontal();
        // EditorGUILayout.LabelField("胜利规则：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
        // _levelRulesConfig.VictoryRules = (VictoryRules)EditorGUILayout.Popup((int)_levelRulesConfig.VictoryRules, _victoryRulesStrArray);
        // EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("游戏结束规则",_guiStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
        GUI.color = Color.green;
        if (GUILayout.Button("+",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(30)}))
        {
            _levelRulesConfig.OverCheckerDataList.Add(new OverCheckerData());
        }
        GUI.color = oldColor;
        EditorGUILayout.EndHorizontal();
        for (int i = 0; i < _levelRulesConfig.OverCheckerDataList.Count; i++)
        {
            var overCheck = _levelRulesConfig.OverCheckerDataList[i];
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("结束规则：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
            overCheck.OverChecker = (GameOverChecker)EditorGUILayout.Popup((int)overCheck.OverChecker, _gameOverCheckerStrArray);
            EditorGUILayout.EndHorizontal();
            if (overCheck.OverChecker == GameOverChecker.TimeChecker)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Value：", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
                overCheck.Value = EditorGUILayout.IntField(overCheck.Value);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(40)}))
            {
                _levelRulesConfig.OverCheckerDataList.Remove(overCheck);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
        }
        
        
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_levelRulesConfig);
        }
    }

    private void ParseEnum(Type enumType,ref string[] strArr)
    {
        var values = Enum.GetValues(enumType);
        strArr = new string[values.Length];
        foreach (var value in values)
            if (value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(AliasAttribute), false).FirstOrDefault() is AliasAttribute aliasAttribute)
                strArr[(int) value] = aliasAttribute.Name;
    }

}
