using System;
using FixMath.NET;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;

[Serializable]
public class PhysicShapeData
{
    public PhysicShapeType ShapeType = PhysicShapeType.Box;
    public Fix64 MassWeight = 1m;
    public Vector3 LocalPosition = Vector3.Zero;
    public Vector3 Rotation = Vector3.Zero;
    public Vector3 Scale = Vector3.Zero;
    public Mesh Mesh;
}
//
// [Serializable]
// public class ScriptParameter
// {
//     public string Name;
//     public Fix64 Value;
// }
