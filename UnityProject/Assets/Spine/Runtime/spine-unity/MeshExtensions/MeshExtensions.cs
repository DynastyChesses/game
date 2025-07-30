using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class MeshExtensions
{
    public static readonly int VertexByte = 3 * 4;      // xyz float
    public static readonly int UVByte = 2 * 4;          // uv  float 但是可能并不准确，不确定uv一定是2通道，也不确定只有1套uv
    public static readonly int ColorByte = 1 * 4;       // rgba byte
    public static readonly int NormalByte = 3 * 4;      // xyz float
    public static readonly int TangentByte = 4 * 4;     // xyzw float
    public static readonly int Index16Byte = 1 * 2;     // mesh.mesh.IndexFormat
    public static readonly int Index32Byte = 1 * 4;     // mesh.mesh.IndexFormat

    /// <summary>
    /// 获取运行时内存，UV方面当前假设只有UV0且格式为Vector2
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="addNormals"></param>
    /// <param name="calculateTangents"></param>
    /// <returns></returns>
    public static long GetRuntimeMemorySizeLong(this Mesh mesh)
    {
        var result = 0L;

        var vertexSize = 0;

        vertexSize += VertexByte;
        vertexSize += UVByte;
        vertexSize += ColorByte;
        vertexSize += mesh.HasVertexAttribute(VertexAttribute.Normal) ? NormalByte : 0;
        vertexSize += mesh.HasVertexAttribute(VertexAttribute.Tangent) ? TangentByte : 0;

        // 
        result += mesh.vertexCount * vertexSize;

        for (int submeshIndex = 0; submeshIndex < mesh.subMeshCount; submeshIndex++)
        {
            result += mesh.GetIndexCount(submeshIndex) * (mesh.indexFormat == UnityEngine.Rendering.IndexFormat.UInt16 ? Index16Byte : Index32Byte);
        }

        result *= mesh.isReadable ? 2 : 1;

#if UNITY_2022_1_OR_NEWER  // 还不确定哪个版本修复的
        result += 1592 + 16;  // empty mesh 1592 and 16 addition

#if UNITY_EDITOR
        Debug.Assert(result == UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(mesh));
#endif
#else
        result += 2960 + 16;  // empty mesh 2960 and 16 addition
#endif

        return result;
    }
}
