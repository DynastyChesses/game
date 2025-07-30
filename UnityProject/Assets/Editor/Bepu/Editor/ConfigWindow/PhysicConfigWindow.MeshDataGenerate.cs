using System;
using System.Collections.Generic;
using System.IO;
using BEPUphysics.PositionUpdating;
using Simulation;
using UnityEditor;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;

public partial class PhysicConfigWindow
{
    private List<Mesh> GenerateMeshDataList = new List<Mesh>();
    private string MeshDataPath = "/Game/playguys/MeshConfig/";

    private void OnShowMeshDataWindow()
    {
        OnScanSceneMeshBtnClick();
    }

    private Vector2 currentMeshDataScrollView;
    private void DrawMeshData()
    {
        var oldColor = GUI.color;
        if (GUILayout.Button("刷新当前场景中用到的网格"))
        {
            OnScanSceneMeshBtnClick();
        }

        currentMeshDataScrollView = GUILayout.BeginScrollView(currentMeshDataScrollView);
        GUILayout.BeginVertical("box");
        GUILayout.BeginHorizontal();
        GUI.color = Color.green;
        if (GUILayout.Button("导出当前Mesh数据",GUILayout.Width(130)))
        {
            ExportMeshDataJson();
        }
        GUI.color = oldColor;
        MeshDataPath = GUILayout.TextField(MeshDataPath);
        GUILayout.EndHorizontal();
        
        for (int i = 0; i < GenerateMeshDataList.Count; i++)
        {
            if (i % 2 == 1)
                GUI.color = new Color(0, 0.5f, 0.5f, 1);
            else
                GUI.color = new Color(0.5f, 0.5f, 0, 1);
            GUILayout.BeginHorizontal("box");
            GUI.color = oldColor;
            GenerateMeshDataList[i] = (Mesh)EditorGUILayout.ObjectField("Mesh", GenerateMeshDataList[i], typeof(Mesh));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
        
        GUI.color = oldColor;
    }

    private void OnScanSceneMeshBtnClick()
    {
        GetPhysicObject();
        List<int> meshIdCheckList = new List<int>();//Mesh查重
        GenerateMeshDataList.Clear();
        for (int i = 0; i < allPhysicObject.Length; i++)
        {
            var obj = allPhysicObject[i];
            switch (obj.ObjectType)
            {
                case PhysicObjectType.Dynamic:
                    if (obj.DynamicObjectType != PhysicDynamicObjectType.DynamicMesh)
                        continue;
                    break;
                case PhysicObjectType.Static:
                    if (obj.StaticObjectType != PhysicStaticObjectType.StaticMesh)
                        continue;
                    break;
            }
            
            if (obj.Mesh == null)
            {
                EditorGUILayout.HelpBox("有Mesh配置为空！！", MessageType.Error);
                continue;
            }
            var id = obj.Mesh.GetInstanceID();
            if (meshIdCheckList.Contains(id))
                continue;
            GenerateMeshDataList.Add(obj.Mesh);
            meshIdCheckList.Add(id);
        }
        for (int i = 0; i < allPhysicObject.Length; i++)
        {
            var obj = allPhysicObject[i];
            if (obj.DynamicObjectType != PhysicDynamicObjectType.CompoundBody && 
                obj.StaticObjectType != PhysicStaticObjectType.StaticGroup)
            {
                continue;
            }

            foreach (PhysicShapeData shapeData in obj.ShapeDataList)
            {
                if (shapeData.Mesh == null)
                    continue;
                var id = shapeData.Mesh.GetInstanceID();
                if (meshIdCheckList.Contains(id))
                    continue;
                GenerateMeshDataList.Add(shapeData.Mesh);
                meshIdCheckList.Add(id);
            }
        }
    }

    //当前每个Mesh都单独生成一个文件。需要哪个加载哪个。
    private void ExportMeshDataJson()
    {
        List<MeshData> allMeshData = new List<MeshData>();
        for (int i = 0; i < GenerateMeshDataList.Count; i++)
        {
            var obj = GenerateMeshDataList[i];
            MeshData meshData = new MeshData();
            meshData.MeshName = obj.name;
            meshData.Id = obj.GetInstanceID();
            meshData.Vertices = new Vector3[obj.vertices.Length];
            for (int j = 0; j < obj.vertices.Length; j++)
                meshData.Vertices[j] = (BEPUutilities.Vector3)obj.vertices[j];
            meshData.Indices = obj.GetIndices(0);
            allMeshData.Add(meshData);
            
            var json = JsonUtility.ToJson(meshData,true);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            
            
            var path = Application.dataPath + MeshDataPath + meshData.MeshName + ".json";
            File.WriteAllBytes(path, bytes);  
            Debug.Log("导出成功："+path);
        }
        AssetDatabase.Refresh();
        this.ShowNotification(new GUIContent($"Mesh数据导出成功,共计{allMeshData.Count}个。"));
    }
}