using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Data",menuName = "ArtTools/Create Mesh Resource Pack")]
public class MeshResourceSetPack :ScriptableObject
{
    public Mesh[] meshes;
    public Material[] materials;
    public Shader[] shaders;
}
