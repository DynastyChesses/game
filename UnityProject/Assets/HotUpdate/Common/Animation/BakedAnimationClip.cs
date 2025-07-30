using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BakedFrameInfo
{
	
	public Vector3[] vertices;

	[NonSerialized]
	public Mesh mesh;
}

public class BakedAnimationClip :ScriptableObject
{
	public string clipName;
	public BakedFrameInfo[] frames;
	public float fps;
	public float speed = 1.0f;
	public bool loop = true;

	public float length
	{
		get { return frames != null ? frames.Length * (1 / fps) : 0; }
	}
}
