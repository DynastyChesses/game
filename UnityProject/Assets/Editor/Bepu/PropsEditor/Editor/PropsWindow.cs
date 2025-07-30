using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


public class PropsWindow : EditorWindow
{
    [MenuItem("Tools/道具总览")]

    static void Open()
    {
        PropsWindow myWindow = (PropsWindow)EditorWindow.GetWindow(typeof(PropsWindow), false, "道具总览", false);
        myWindow.Show(true);
    }

    public string PropsExportPath;
    public List<PropsConfig> PropsConfigList = new List<PropsConfig>();

    private GUIStyle GUIStyle1;
    private Vector2 currentScrollView;
    
    private void OnEnable()
    {
        GUIStyle1 = new GUIStyle();
        GUIStyle1.fontSize = 30;
        GUIStyle1.normal.textColor = Color.green;
        GUIStyle1.font = Resources.Load<Font>("EditorFont");
        

        if (PlayerPrefs.HasKey("PropsExportPath"))
        {
            PropsExportPath = PlayerPrefs.GetString("PropsExportPath");
        }

        RefreshBtn();
    }

    private void OnGUI()
    {
        var oldColor = GUI.color;

        currentScrollView = EditorGUILayout.BeginScrollView(currentScrollView);
        
        
        int hCount = (int)Mathf.Floor(this.position.width / 80);
        hCount--;
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("道具总览",GUIStyle1);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();


        GUI.color = Color.cyan;
        EditorGUILayout.BeginHorizontal("box");
        if (GUILayout.Button("刷新",GUILayout.Width(60)))
            RefreshBtn();
        GUI.color = oldColor;
        GUILayout.Label("导出路径:",GUILayout.Width(60));
        PropsExportPath = EditorGUILayout.TextField(PropsExportPath);
        GUI.color = Color.green;
        if (GUILayout.Button("导出"))
        {
            RefreshBtn();
            ExportJson();
            Debug.Log("导出路径： " + PropsExportPath);
            if (!string.IsNullOrEmpty(PropsExportPath))
                PlayerPrefs.SetString("PropsExportPath",PropsExportPath);
        }
        GUI.color = oldColor;
        EditorGUILayout.EndHorizontal();
        
        
        int times = 0;
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        foreach (PropsConfig config in PropsConfigList)
        {
            EditorGUILayout.BeginVertical(GUILayout.Width(80),GUILayout.Height(100));
            var icon2D = AssetDatabase.LoadAssetAtPath<Texture2D>(config.Icon);
            GUIContent guiContent = new GUIContent(icon2D, config.Desc);
            if (GUILayout.Button(guiContent,GUILayout.Width(80),GUILayout.Height(80)))
                UnityEditor.Selection.objects = new Object[] {config};
            EditorGUILayout.BeginHorizontal(GUILayout.Width(80));
            GUILayout.FlexibleSpace();
            GUILayout.Label($"{config.Name}:{config.PropsId}");
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            times++;
            if (times >= hCount)
            {
                times -= hCount;
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
            }
        }
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        
        
        EditorGUILayout.EndScrollView();
        
        GUI.color = oldColor;
    }

    private void RefreshBtn()
    {
        PropsConfigList.Clear();
        var guidArray = AssetDatabase.FindAssets("t:PropsConfig");
        foreach (string guid in guidArray)
        {   
            string targetPath = AssetDatabase.GUIDToAssetPath(guid);
            PropsConfig config = (PropsConfig)AssetDatabase.LoadAssetAtPath(targetPath, typeof(PropsConfig));
            PropsConfigList.Add(config);            
        }
        
        PropsConfigList.Sort(delegate(PropsConfig config, PropsConfig propsConfig)
        {
            return config.PropsId > propsConfig.PropsId ? 1:-1;
        });
    }

    private void ExportJson()
    {
        PropsTable table = new PropsTable();
        foreach (var config in PropsConfigList)
        {
            var json = JsonUtility.ToJson(config,true);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            var path = Application.dataPath + PropsExportPath + config.name + ".json";
            File.WriteAllBytes(path, bytes);  
            table.DataList.Add(new PropsTableData(){Id = config.PropsId,PropsFileName = config.name});
            Debug.Log("导出成功："+path);
        }
        var tableJson = JsonUtility.ToJson(table,true);
        var tableBytes = System.Text.Encoding.UTF8.GetBytes(tableJson);
        var tablePath = Application.dataPath + PropsExportPath + "PropsTable.json";
        File.WriteAllBytes(tablePath, tableBytes);  
        AssetDatabase.Refresh();
        this.ShowNotification(new GUIContent($"导出成功，共计{PropsConfigList.Count}个。"));
    }
    
    [Serializable]
    public class PropsTable
    {
        public List<PropsTableData> DataList = new List<PropsTableData>();
    }
    [Serializable]
    public class PropsTableData
    {
        public int Id;
        public string PropsFileName;
    }
}
