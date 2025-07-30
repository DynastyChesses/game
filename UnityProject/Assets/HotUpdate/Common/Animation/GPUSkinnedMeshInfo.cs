using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUSkinnedMeshInfo:ScriptableObject
{
	[Serializable]
	public class ClipData
	{
		public string name;
		public int totalFrame;
		public int offset;

		[NonSerialized]
		public int nameHash;
	}

	public int perBonePixelNum;
	public int boneCount;
	public int bonePixelOffset;
	public ClipData[] clipDataArray;

	private Dictionary<int, ClipData> _clipMap;

	public Dictionary<int, ClipData> clipMap
	{
		get
		{
			if (_clipMap == null)
			{
				_clipMap = new Dictionary<int, ClipData>(clipDataArray.Length);
				foreach (var clipData in clipDataArray)
				{
					int nameHash = clipData.nameHash = Animator.StringToHash(clipData.name);
					_clipMap.Add(nameHash, clipData);
				}
			}

			return _clipMap;
		}
	}
}
