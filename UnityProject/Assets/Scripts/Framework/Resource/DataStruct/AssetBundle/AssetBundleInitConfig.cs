using System.Collections.Generic;

/// <summary>
/// AssetBundle资源模式的初始化配置类
/// </summary>
public class AssetBundleInitConfig : DefaultResourceInitConfig
{
    public AssetBundleInitConfig(string prefabPathPrefix = DEFAULT_PREFAB_PATH_PREFIX) : base(prefabPathPrefix)
    {
    }

    public AssetBundleInitConfig(string prefabPathPrefix, float releaseCheckInterval,
        float unloadUnusedAssetsInterval, int instanceQueueOneFrameLimit)
        : base(prefabPathPrefix, releaseCheckInterval, unloadUnusedAssetsInterval, instanceQueueOneFrameLimit)
    {
    }

    public override ResourceMode resourceMode
    {
        get { return ResourceMode.AssetBundle; }
    }


    // public List<string> cdnList;
    public string cdn;

    public AssetConfig config;

    private readonly List<SearchPath> _bundleSearchPath = new List<SearchPath>();

    public void AddBundleSearchPath(string pathPrefix, bool inPackage)
    {
        _bundleSearchPath.Add(new SearchPath(pathPrefix, inPackage ? PersistType.Package : PersistType.Disk));
    }
    
    public List<SearchPath> GetSearchPathList()
    {
        return _bundleSearchPath;
    }

    public bool unloadWhenDispose = true;
}