using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class AssetConfig
{
	public static string ASSET_CONFIG_FILE_NAME => "AssetConfig" + ASSET_CONFIG_EXT_NAME;
	public static string ASSET_CONFIG_EXT_NAME
	{
		// 写成属性，不影响生成代码
		get
		{
#if UNITY_WEBGL
			// 微信小游戏只读分包里不允许.bytes后缀，有个白名单。cdn对txt可设置压缩
			// https://developers.weixin.qq.com/minigame/dev/guide/framework/code-package.html
			return ".json";
#else
			return ".bytes";
#endif
		}

	}
	
	public const string ASSETBUNDLE_EXT_NAME = ".bytes";
	
	public string version;

	public AssetList resList;

	public AssetList patchList;

	public bool isResEmpty => resList == null || resList.nodeCount == 0;

	public bool isPatchEmpty => patchList == null || patchList.nodeCount == 0;

	private static AssetConfig _defaultConfig;
	public static AssetConfig defaultConfig
	{
		get
		{
			if (_defaultConfig == null)
			{
				byte[] localOrPackBytes = StorageManager.ReadAllBytesIfExist(Path.Combine(ResourcePathConst.REMOTE_ASSET_DIRECTORY, ASSET_CONFIG_FILE_NAME));
				if (localOrPackBytes == null)
				{
					localOrPackBytes = PackageManager.ReadAllBytes(ASSET_CONFIG_FILE_NAME);
				}
				_defaultConfig = AssetConfigSerializer.DeserializeAssetsConfig(localOrPackBytes, false);
				if (_defaultConfig == null)
				{
					_defaultConfig = new AssetConfig();
					_defaultConfig.version = "0";
					_defaultConfig.resList = new AssetList();
				}
			}

			return _defaultConfig;
		}
	}

	public static void UpdateDefault(AssetConfig newDefaultConfig, string outputPath)
	{
		_defaultConfig = newDefaultConfig;
		bool cacheToDisk = !string.IsNullOrEmpty(outputPath);
		if (cacheToDisk)
		{
			outputPath = Path.Combine(outputPath, ASSET_CONFIG_FILE_NAME);
			StorageManager.CreateDirectoryIfNotExist(outputPath);
			using (Stream fs = StorageManager.Open(outputPath,
				FileMode.OpenOrCreate, FileAccess.Write))
			{
				AssetConfigSerializer.SerializeAssetsConfig(fs, false, newDefaultConfig);
				fs.Flush();
				fs.Close();
			}
		}
	}
	
	/**
	 * 比较判定两个版本号
	 * @static
	 * @param {string} a 版本号a
	 * @param {string} b 版本号b
	 * @returns {number} 0表示两个版本号完全相同, 负数表示a小于b, 正数表示a大于b
	 * @memberOf Str
	 */
	public static int VersionCompare(string a, string b)
	{
		if ((string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b)) || (a.Length == 0 && b.Length == 0)) 
		{
			return 0;
		}

		var aVer = a.Split('.');
		var bVer = b.Split('.');

		var aVerLen = aVer.Length;
		var bVerLen = bVer.Length;
		var len = Math.Max(aVerLen, bVerLen);

		for (var i = 0; i < len; ++i)
		{
			var aSzVer = i < aVerLen ? aVer[i] : null;
			var bSzVer = i < bVerLen ? bVer[i] : null;

			int aNum = 0;
			int bNum = 0;
			if (!string.IsNullOrEmpty(aSzVer)) aNum = int.Parse(aSzVer);
			if (!string.IsNullOrEmpty(bSzVer)) bNum = int.Parse(bSzVer);

			if (aNum > bNum) return 1;
			else if (aNum < bNum) return -1;
		}

		return 0;
	}

	public static AssetConfig LoadFromPackage(string relativePath, bool compressed = false)
	{
		byte[] rawBytes = PackageManager.ReadAllBytes(relativePath);
		return AssetConfigSerializer.DeserializeAssetsConfig(rawBytes, compressed);
	}
	
	public static AssetConfig LoadFromDisk(string fullPath)
	{
		try
		{
			byte[] rawBytes = StorageManager.ReadAllBytes(fullPath);
			return AssetConfigSerializer.DeserializeAssetsConfig(rawBytes, false);
		}
		catch (Exception e)
		{
			UnityEngine.Debug.LogError("AssetConfig.LoadFromDisk error:" + e);
			return null;
		}
	}
	
	public static void FindUpdateAssets(AssetConfig local, AssetConfig remote, out List<AssetNode> updateOrAddAssets, out List<AssetNode> deleteAssets)
	{
		updateOrAddAssets = new List<AssetNode>();
		deleteAssets = new List<AssetNode>();
        if (local.isResEmpty)
        {
            if (!remote.isResEmpty)
            {
                updateOrAddAssets.AddRange(remote.resList.nodes);
            }
        }
        else if (remote.isResEmpty)
        {
            deleteAssets.AddRange(local.resList.nodes);
        }
        else
        {
            AssetList localResList = local.resList;
            AssetList remoteResList = remote.resList;
            AssetNode[] localNodes = localResList.nodes;
            AssetNode[] remoteNodes = remoteResList.nodes;

            for (int i = 0, l = localNodes.Length; i < l; ++i)
            {
                AssetNode lnode = localNodes[i];
                AssetNode rnode;
                if (!remoteResList.TryGetValue(lnode.id, out rnode))
                {
                    deleteAssets.Add(lnode);
                    continue;
                }

                if (lnode.md5 != rnode.md5)
                {
                    updateOrAddAssets.Add(rnode);
                }
            }

            for (int i = 0, l = remoteNodes.Length; i < l; ++i)
            {
                AssetNode rnode = remoteNodes[i];
                if (!localResList.Contains((rnode.id)))
                {
                    updateOrAddAssets.Add(rnode);
                }
            }
        }
    }
}
