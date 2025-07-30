using System.Collections.Generic;
using BEPUphysics.BroadPhaseEntries;
using BEPUphysics.Entities;
using BEPUphysics.Entities.Prefabs;
using BEPUutilities;
using Simulation;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PhysicDisplay:MonoBehaviour
{
    public struct MeshDisplayData
    {
        public Mesh Mesh;
        public Vector3 Position;
        public Quaternion Rotation;
    }
    private List<MeshDisplayData> AllStaticMesh = new List<MeshDisplayData>();
    public void Refresh()
    {
        foreach (Entity entity in GameSimulation.Inst.PhysicsWorld.Entities)
        {
            if (entity is Box box)
            {
                
            }
            else if (entity is Capsule capsule)
            {
                
            }
            else if (entity is Cylinder cylinder)
            {
                
            }
            else if (entity is Sphere sphere)
            {
                
            }
            else if (entity is MobileMesh mobileMesh)
            {
                
            }
            else
            {
                Debug.Log("未处理的类型: "+entity.GetType());
            }
        }

        // foreach (StaticMesh staticMesh in GameSimulation.Inst.AllStaticMesh)
        // {
        //     
        //     // staticMesh.WorldTransform.Translation
        //     var meshData = staticMesh.Mesh.Data;
        //     UnityEngine.Vector3[] vertices = new Vector3[meshData.Vertices.Length];
        //     for (int i = 0; i < meshData.Vertices.Length; i++)
        //         vertices[i] = (UnityEngine.Vector3)(meshData.Vertices[i]);
        //
        //     Mesh mesh = new Mesh();
        //     mesh.vertices = vertices;
        //     mesh.SetIndices(meshData.Indices,MeshTopology.Triangles,0);
        //
        //
        //
        // }
        
        
        
        
        
    }

    private void OnDrawGizmos()
    {
        foreach (MeshDisplayData displayData in AllStaticMesh)
            DrawMesh(displayData);
    }

    private void DrawMesh(MeshDisplayData data)
    {
        var color = Gizmos.color;
        var matrix = Gizmos.matrix;
        Gizmos.color = Color.magenta;
        Gizmos.matrix = Matrix4x4.TRS(data.Position, data.Rotation, UnityEngine.Vector3.one);
        Gizmos.DrawWireMesh(data.Mesh,UnityEngine.Vector3.zero,Quaternion.identity,Vector3.one);
        Gizmos.color = color;
        Gizmos.matrix = matrix;
    }
    
    
}