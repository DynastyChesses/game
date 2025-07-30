using System;
using UnityEngine;

/// <summary>
	/// 表示一个可加载资源或文件。
	/// 1. 可加载资源：工程中可加载目录下的一个资源文件(id)及其对应的bundle文件(_a)，和bundle文件信息，
	/// 2. bundle文件：被可加载资源依赖的一个bundle，用于计算依赖，其对应的资源id可以不是可加载目录的资源
	/// 3. 其他文件：dll、mp4
	/// 例如
	/* 
"version": "1.0.1",
    "resList": {
        "nodes": [
            {
                "_a": "Bundles/AllShaders.asset(cc63995608be59c79f96bb0008dc7d36).bytes",
                "_b": "c8ff68097b77c7cc699c23d851bfde8a",
                "_c": 30573,
                "_d": 0,
                "_e": [],
                "_f": false,
                "_g": 2423940198,
                "_i": false,
                "id": "Assets/BundleResources/AllShaders.asset"
            },
			{
				"_a": "Bundles/Human.controller(16493a1dc97ca0c82048559370c441a5).bytes",
				"_b": "9de422ee1b57ad01e92f8a1df9577faa",
				"_c": 31490,
				"_d": 0,
				"_e": [],
				"_f": true,
				"_g": 3499980222,
				"_i": false,
				"id": "Assets/BundleResources/Hero/Animation/Lower/Climb.anim"
			},
			{
				"_a": "Assemblies/FMCommon.dll",
				"_b": "89aeca157a0822a43587ef3d77adff22",
				"_c": 57344,
				"_d": 36676,
				"_e": [],
				"_f": false,
				"_g": 887213762,
				"_i": false,
				"id": "FMCommon.dll"
			},
		*/
	/// </summary>
[Serializable]
public class AssetNode
{
	[SerializeField] private string _a;
	[SerializeField] private string _b;
	[SerializeField] private ulong _c;
	[SerializeField] private ulong _d;
	[SerializeField] private int[] _e;
	[SerializeField] private bool _f;
	[SerializeField] private uint _g;
	[SerializeField] private bool _i;

	/// <summary>
	/// AssetDatabase中的路径，如"Assets/BundleResources/AllShaders.asset"
	/// </summary>
	public string id;

	/// <summary>
	/// bundle文件路径，不具有原目录结构，
	/// 如"Bundles/AllShaders.asset(cc63995608be59c79f96bb0008dc7d36).bytes"
	/// </summary>
	/// <value></value>
	public string url
	{
		get { return _a; }

		set { _a = value; }
	}

	/// <summary>
	/// 原始未压缩bundle的md5
	/// </summary>
	public string md5
	{
		get { return _b; }
		set { _b = value; }
	}

	public ulong size
	{
		get { return _c; }
		set { _c = value; }
	}

	public ulong compressedSize
	{
		get { return _d; }
		set { _d = value; }
	}

	/// <summary>
	/// 依赖项的AssetList索引，似乎是直接依赖
	/// </summary>
	/// <value></value>
	public int[] dependIndexes
	{
		get { return _e; }

		set { _e = value; }
	}

	/// <summary>
	/// 工程中的一个可加载文件被合并到别的资源bundle（假设为X）中，就标记为占位符，
	/// 此时除id外的其他属性值都跟X的一样。只能表示资源路径对应哪个bundle文件
	/// </summary>
	/// <value></value>
	public bool placeHolder
	{
		get { return _f; }
		set { _f = value;  }
	}

	public uint crc32
	{
		get { return _g; }
		set { _g = value; }
	}

	/// <summary>
	/// 自己是否被其他依赖
	/// </summary>
	/// <value></value>
	public bool otherDepend
	{
		get { return _i; }
		set { _i = value; }
	}

	public bool compressed
	{
		get
		{
			return compressedSize > 0 && compressedSize != size;
		}
	}

	public bool isAssetBundleFile => true;

}

