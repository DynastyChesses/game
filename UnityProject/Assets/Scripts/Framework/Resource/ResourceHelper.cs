
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;

public class ResourceHelper
{
	public static unsafe void Copy(byte[] source, int sourceOffset, byte[] target,
		int targetOffset, int count)
	{
		// If either array is not instantiated, you cannot complete the copy.
		if ((source == null) || (target == null))
		{
			throw new System.ArgumentException();
		}

		// If either offset, or the number of bytes to copy, is negative, you
		// cannot complete the copy.
		if ((sourceOffset < 0) || (targetOffset < 0) || (count < 0))
		{
			throw new System.ArgumentException();
		}

		// If the number of bytes from the offset to the end of the array is 
		// less than the number of bytes you want to copy, you cannot complete
		// the copy. 
		if ((source.Length - sourceOffset < count) ||
			(target.Length - targetOffset < count))
		{
			throw new System.ArgumentException();
		}

		// The following fixed statement pins the location of the source and
		// target objects in memory so that they will not be moved by garbage
		// collection.
		fixed (byte* pSource = source, pTarget = target)
		{
			// Set the starting points in source and target for the copying.
			byte* ps = pSource + sourceOffset;
			byte* pt = pTarget + targetOffset;

			// Copy the specified number of bytes from source to target.
			for (int i = 0; i < count; i++)
			{
				*pt = *ps;
				pt++;
				ps++;
			}
		}
	}

	private static StringBuilder _cachedBuilder = new StringBuilder(100);
	/// <summary>
	/// 拼接文件路径，形如{prefix}/{platform}/{relativeURLWithoutExtention}{_version}{relativeURLExtension}
	/// 其中platform, version可选，可以拼出cdnUrl，本地存储路径（带md5，不带md5，编辑器构建用的，带前缀运行时保存用的）
	/// </summary>
	/// <param name="prefix"></param>
	/// <param name="relativeURL"></param>
	/// <param name="version">md5当作版本</param>
	/// <param name="usePlatform">添加平台相关的，prefix后，文件前的中缀</param>
	/// <returns></returns>
    public static string GetAssetURL(string prefix, string relativeURL, string version, bool usePlatform = true)
	{
		// 该框架不需要
		return "";
	}

	/// <summary>
	/// 获取文件实际的存储路径，相对于REMOTE_ASSET_DIRECTORY
	/// webgl下都是有内容md5的，小游戏要基于md5删除旧文件
	/// 其他平台保存路径没md5，会覆盖同名文件
	/// </summary>
	/// <param name="originalUrl"></param>
	/// <param name="md5"></param>
	/// <returns></returns>
	public static string GetRuntimeSavePath(string originalUrl, string md5)
	{
#if UNITY_WEBGL
		return GetAssetURL(ResourcePathConst.WX_CACHEABLE_URL_TAG, originalUrl, md5, false);
#else
	    return originalUrl;
#endif

	}
	

    /// <summary>
    /// 通过资源列表获取assetcfg中依赖的所有文件，
    /// </summary>
    /// <param name="resList"></param>
    /// <param name="assets">路径是assetNode的id，跟assetDB文件后会可能不同</param>
    /// <param name="fileWithMd5">true返回带md5的部署文件路径，false返回资源id</param>
    /// <returns></returns>
    public static List<string> GetAllDependenciesUrlByAssets(AssetList resList, string[] assets, bool fileWithMd5)
    {
	    List<AssetNode> set = GetAllDependenciesNodeByAssets(resList, assets);

	    List<string> res = new List<string>();
	    foreach (var v in set)
	    {
		    if (fileWithMd5)
			    res.Add(GetAssetURL("", v.url, v.md5, false));
		    else
			    res.Add(v.id);
	    }
	    
	    // StringBuilder sb = new StringBuilder();
	    // foreach (var v in res)
		   //  sb.AppendLine(v);
	    // Debug.LogError(sb);

	    return res;
    }
    
    /// <summary>
    /// 通过资源列表获取assetcfg中依赖的所有节点，
    /// </summary>
    /// <param name="resList"></param>
    /// <param name="assets"></param>
    /// <returns></returns>
    public static List<AssetNode> GetAllDependenciesNodeByAssets(AssetList resList, string[] assets)
    {
	    HashSet<AssetNode> set = new HashSet<AssetNode>();
	    foreach (var v in assets)
	    {
		    if (string.IsNullOrEmpty(v))
			    continue;
		    if (resList.TryGetValue(v, out var node))
		    {
			    AddDependency(resList, node, set);
		    }
		    else
		    {
			    Debug.LogError($"assetConfig没找到资源对应文件，可能要用修改的后缀: {v}");
		    }
	    }

	    return set.ToList();
    }
    private static void AddDependency(AssetList resList, AssetNode node, HashSet<AssetNode> set)
    {
	    if (set.Contains(node))
		    return;
	    set.Add(node);
	    if (node.dependIndexes != null)
	    {
		    foreach (var v in node.dependIndexes)
		    {
			    AddDependency(resList, resList[v], set);
		    }
	    }
    }

    public static void SaveWebRequestData(UnityWebRequest req, string path)
    {
	    if (req == null || string.IsNullOrEmpty(path)) return;
	    var data = req.downloadHandler.data;
	    if (data == null || data.Length == 0)
		    Debug.LogError($"webReq has no data, {req.url}");
	    StorageManager.CreateDirectoryIfNotExist(path);
	    StorageManager.WriteAllBytes(path, data);
    }

    public static string GetDebugCdn()
    {
	    // 不需要
	    return "";
    }

    public static bool IsDebugStreamPlay => false;

}
