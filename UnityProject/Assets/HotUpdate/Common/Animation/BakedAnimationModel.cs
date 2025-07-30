using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class SubMeshTriangle
{
	public int[] triangles;
}

public class BakedAnimationModel :ScriptableObject
{
	public Vector2[] uv;

	public int[] triangles;

	public SubMeshTriangle[] subMeshTriangles;
}
