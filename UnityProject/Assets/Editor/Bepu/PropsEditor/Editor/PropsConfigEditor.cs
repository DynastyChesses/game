using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FixMath.NET;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PropsConfig))]
public class PropsConfigEditor : UnityEditor.Editor
{
    private PropsConfig _propsConfig;
    private string[] TriggerStrArray;
    private string[] FilterStrArray;
    private string[] EffectStrArray;
    private Dictionary<string,int> EffectStrArrayIndexMap = new Dictionary<string, int>();
    private Dictionary<int, int> EffectStrArrayIndexMap2 = new Dictionary<int, int>();

    private GUIStyle GUIStyle1;
    private GUIStyle GUIStyle2;
    public void OnEnable()
    {
        _propsConfig = (PropsConfig) this.target;
        
        GUIStyle1 = new GUIStyle();
        GUIStyle1.fontSize = 26;
        GUIStyle1.normal.textColor = Color.green;
        GUIStyle1.font = Resources.Load<Font>("EditorFont");
        GUIStyle2 = new GUIStyle();
        GUIStyle2.fontSize = 16;
        GUIStyle2.normal.textColor = Color.green;
        GUIStyle2.font = Resources.Load<Font>("EditorFont");
        
        
        var values = Enum.GetValues(typeof(TriggerTypes));
        TriggerStrArray = new string[values.Length];
        foreach (var value in values)
        {
            string name = value.ToString();
            int index = (int) value;
            FieldInfo fieldInfo = value.GetType().GetField(name);
            AliasAttribute aliasAttribute = fieldInfo.GetCustomAttributes(typeof(AliasAttribute), false).FirstOrDefault() as AliasAttribute;
            if (aliasAttribute != null)
                TriggerStrArray[index] = aliasAttribute.Name;
        }
        
        values = Enum.GetValues(typeof(FilterTypes));
        FilterStrArray = new string[values.Length];
        foreach (var value in values)
        {
            string name = value.ToString();
            int index = (int) value;
            FieldInfo fieldInfo = value.GetType().GetField(name);
            AliasAttribute aliasAttribute = fieldInfo.GetCustomAttributes(typeof(AliasAttribute), false).FirstOrDefault() as AliasAttribute;
            if (aliasAttribute != null)
                FilterStrArray[index] = aliasAttribute.Name;
        }
        
        values = Enum.GetValues(typeof(EffectTypes));
        EffectStrArray = new string[values.Length];
        EffectStrArrayIndexMap.Clear();
        EffectStrArrayIndexMap2.Clear();
        int strIndex = 0;
        foreach (var value in values)
        {
            string name = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(name);
            AliasAttribute aliasAttribute = fieldInfo.GetCustomAttributes(typeof(AliasAttribute), false).FirstOrDefault() as AliasAttribute;
            if (aliasAttribute == null)
                EffectStrArray[strIndex] = name;
            else
                EffectStrArray[strIndex] = aliasAttribute.Name;
            EffectStrArrayIndexMap[name] = strIndex;
            EffectStrArrayIndexMap2[strIndex] = (int)value;
            strIndex++;
        }
    }


    public override void OnInspectorGUI()
    {
        Undo.RecordObject(_propsConfig,"_propsConfig"+_propsConfig.GetInstanceID());
        EditorGUI.BeginChangeCheck();
        var oldColor = GUI.color;
        EditorGUILayout.BeginHorizontal();
        var icon2D = AssetDatabase.LoadAssetAtPath<Texture2D>(_propsConfig.Icon);
        icon2D = (Texture2D)EditorGUILayout.ObjectField(icon2D, typeof(Texture2D),new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(100)});
        _propsConfig.Icon = AssetDatabase.GetAssetPath(icon2D);
        EditorGUILayout.BeginVertical();
        _propsConfig.Name = EditorGUILayout.TextField(_propsConfig.Name);
        _propsConfig.Desc = EditorGUILayout.TextField(_propsConfig.Desc,new GUILayoutOption[]{GUILayout.Height(60)});
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("道具ID:",GUILayout.Width(45));
        _propsConfig.PropsId = EditorGUILayout.IntField( _propsConfig.PropsId,GUILayout.Width(40));
        
        GUI.color = Color.green;
        if (GUILayout.Button("添加效果组"))
        {
            _propsConfig.EffectGroups.Add(new PropsEffectGroupConfig());
        }
        GUI.color = Color.red;
        if (GUILayout.Button("清空"))
        {
            _propsConfig.EffectGroups.Clear();
        }
        GUI.color = oldColor;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        
        for (int i = 0; i < _propsConfig.EffectGroups.Count; i++)
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("道具效果组",GUIStyle1,new GUILayoutOption[]{GUILayout.Height(30)});
            GUI.color = Color.red;
            if (GUILayout.Button("删除",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(30)}))
            {
                _propsConfig.EffectGroups.RemoveAt(i);
                i--;
                if (_propsConfig.EffectGroups.Count == 0)
                    return;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            var effectGroup = _propsConfig.EffectGroups[i];

            
#region Trigger


            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("触发器",GUIStyle2,new GUILayoutOption[]{GUILayout.Height(20)});
            GUI.color = Color.green;
            if (GUILayout.Button("+",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(20)}))
            {
                effectGroup.TriggerList.Add(new TriggerData());
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();

            foreach (var triggerData in effectGroup.TriggerList)
            {
                GUI.color = Color.cyan;
                EditorGUILayout.BeginVertical("box");
                GUI.color = oldColor;
                EditorGUILayout.BeginHorizontal();
                GUI.color = Color.magenta;
                EditorGUILayout.LabelField("触发器", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
                GUI.color = oldColor;
                triggerData.Trigger = (TriggerTypes)EditorGUILayout.Popup((int)triggerData.Trigger, TriggerStrArray);
                GUI.color = Color.red;
                if (GUILayout.Button("-",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(20)}))
                {
                    effectGroup.TriggerList.Remove(triggerData);
                    break;
                }
                GUI.color = oldColor;
                EditorGUILayout.EndHorizontal();
                if (triggerData.Trigger != TriggerTypes.None)
                    DrawPropsEffectData(triggerData);
                EditorGUILayout.EndVertical();
            }
#endregion
            
#region Fillter

            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("过滤器",GUIStyle2,new GUILayoutOption[]{GUILayout.Height(20)});
            GUI.color = Color.green;
            if (GUILayout.Button("+",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(20)}))
            {
                effectGroup.FilterList.Add(new FilterData());
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            
            foreach (var filterData in effectGroup.FilterList)
            {
                GUI.color = Color.cyan;
                EditorGUILayout.BeginVertical("box");
                GUI.color = oldColor;
                EditorGUILayout.BeginHorizontal();
                GUI.color = Color.magenta;
                EditorGUILayout.LabelField("筛选器", EditorStyles.boldLabel,new GUILayoutOption[]{GUILayout.Width(70)});
                GUI.color = oldColor;
                filterData.Filter = (FilterTypes)EditorGUILayout.Popup((int)filterData.Filter, FilterStrArray);
                GUI.color = Color.red;
                if (GUILayout.Button("-",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(20)}))
                {
                    effectGroup.FilterList.Remove(filterData);
                    break;
                }
                GUI.color = oldColor;
                EditorGUILayout.EndHorizontal();
                if (filterData.Filter != FilterTypes.None)
                    DrawPropsEffectData(filterData);
                EditorGUILayout.EndVertical();
            }
            
#endregion


#region Effect


            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("效果器",GUIStyle2,new GUILayoutOption[]{GUILayout.Height(20)});
            GUI.color = Color.green;
            if (GUILayout.Button("+",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(20)}))
            {
                effectGroup.EffectList.Add(new EffectData());
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            
            foreach (var effectData in effectGroup.EffectList)
            {
                GUI.color = Color.cyan;
                EditorGUILayout.BeginVertical("box");
                GUI.color = oldColor;
                EditorGUILayout.BeginHorizontal();
                GUI.color = Color.magenta;
                EditorGUILayout.LabelField("效果器", EditorStyles.boldLabel, new GUILayoutOption[] {GUILayout.Width(70)});
                GUI.color = oldColor;
                int arrayIndex = EffectStrArrayIndexMap[effectData.Effect.ToString()];
                arrayIndex = EditorGUILayout.Popup(arrayIndex, EffectStrArray);
                effectData.Effect = (EffectTypes)EffectStrArrayIndexMap2[arrayIndex];
                GUI.color = Color.red;
                if (GUILayout.Button("-",new GUILayoutOption[]{GUILayout.Width(100),GUILayout.Height(20)}))
                {
                    effectGroup.EffectList.Remove(effectData);
                    break;
                }
                GUI.color = oldColor;
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.EndVertical();
                if (effectData.Effect != EffectTypes.None)
                    DrawPropsEffectData(effectData);
            }

#endregion

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        GUI.color = oldColor;
        
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_propsConfig);
        }
    }

    
    private void DrawPropsEffectData(PropsEffectData effectData)
    {
        var oldColor = GUI.color;
        EditorGUILayout.BeginHorizontal();
        GUI.color = Color.green;
        if (GUILayout.Button("添加"))
        {
            var menu = new GenericMenu ();
            var typesArray = Enum.GetValues(typeof(PropsParameterTypes));
            foreach (var t in typesArray)
            {
                menu.AddItem(
                    new GUIContent (t.ToString()), false,
                    delegate(object data)
                    {
                        var parameterType = (PropsParameterTypes) data;
                        switch (parameterType)
                        {
                            case PropsParameterTypes.Int:
                                effectData.IntParameters.Add(new IntParameter());
                                break;
                            case PropsParameterTypes.Float:
                                effectData.FloatParameters.Add(new FloatParameter());
                                break;
                            case PropsParameterTypes.Vector3:
                                effectData.Vector3Parameters.Add(new Vector3Parameter());
                                break;
                            case PropsParameterTypes.Vector2:
                                effectData.Vector2Parameters.Add(new Vector2Parameter());
                                break;
                            case PropsParameterTypes.Bool:
                                effectData.BoolParameters.Add(new BoolParameter());
                                break;
                            case PropsParameterTypes.String:
                                effectData.StringParameters.Add(new StringParameter());
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }, t);
            }
            menu.ShowAsContext();
        }
        GUI.color = Color.red;
        if (GUILayout.Button("清空"))
        {
            effectData.IntParameters.Clear();
            effectData.FloatParameters.Clear();
            effectData.Vector3Parameters.Clear();
            effectData.Vector2Parameters.Clear();
            effectData.BoolParameters.Clear();
            effectData.StringParameters.Clear();
        }
        GUI.color = oldColor;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        
        foreach (IntParameter intParameter in effectData.IntParameters)
        {
            EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.BeginVertical();
            intParameter.Name = EditorGUILayout.TextField( intParameter.Name);
            intParameter.Value = EditorGUILayout.IntField( (int)intParameter.Value);
            // EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-", GUILayout.Width(18),GUILayout.Height(18)))
            {
                effectData.IntParameters.Remove(intParameter);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        foreach (var parameter in effectData.FloatParameters)
        {
            EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.BeginVertical();
            parameter.Name = EditorGUILayout.TextField( parameter.Name);
            parameter.Value = (Fix64)EditorGUILayout.FloatField((float)parameter.Value);
            // EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-", GUILayout.Width(18),GUILayout.Height(18)))
            {
                effectData.FloatParameters.Remove(parameter);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        foreach (var parameter in effectData.Vector3Parameters)
        {
            EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.BeginVertical();
            parameter.Name = EditorGUILayout.TextField(parameter.Name);
            parameter.Value = (BEPUutilities.Vector3)EditorGUILayout.Vector3Field(new GUIContent(""), (Vector3)parameter.Value);
            // EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-", GUILayout.Width(18),GUILayout.Height(18)))
            {
                effectData.Vector3Parameters.Remove(parameter);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        foreach (var parameter in effectData.Vector2Parameters)
        {
            EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.BeginVertical();
            parameter.Name = EditorGUILayout.TextField( parameter.Name);
            parameter.Value = (BEPUutilities.Vector2)EditorGUILayout.Vector2Field(new GUIContent(""), (Vector2)parameter.Value);
            // EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-", GUILayout.Width(18),GUILayout.Height(18)))
            {
                effectData.Vector2Parameters.Remove(parameter);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        foreach (var parameter in effectData.BoolParameters)
        {
            EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.BeginVertical();
            parameter.Name = EditorGUILayout.TextField(parameter.Name);
            parameter.Value = EditorGUILayout.Toggle( parameter.Value);
            // EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-", GUILayout.Width(18),GUILayout.Height(18)))
            {
                effectData.BoolParameters.Remove(parameter);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        foreach (var parameter in effectData.StringParameters)
        {
            EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.BeginVertical();
            parameter.Name = EditorGUILayout.TextField( parameter.Name);
            parameter.Value = EditorGUILayout.TextField( parameter.Value);
            // EditorGUILayout.EndVertical();
            GUI.color = Color.red;
            if (GUILayout.Button("-", GUILayout.Width(18),GUILayout.Height(18)))
            {
                effectData.StringParameters.Remove(parameter);
                break;
            }
            GUI.color = oldColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        
    }
    
}
