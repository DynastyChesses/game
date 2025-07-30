/// <summary>
/// 编辑器中的AssetDatabase资源模式的初始化配置类
/// </summary>
public class AssetDBInitConfig:DefaultResourceInitConfig
{
    private string _globalPrefix;

    public string globalPrefix => _globalPrefix;

    public override ResourceMode resourceMode
    {
        get
        {
            return ResourceMode.AssetDatabase;
        }
    }

    public AssetDBInitConfig(string prefix = "",
        string prefabPrefix = DEFAULT_PREFAB_PATH_PREFIX, 
        float releaseCheckInterval = DEFAULT_RELEASE_CHECK_INTERVAL, 
        float unloadUnusedAssetsInterval = DEFAULT_UNLOAD_UNUSED_ASSETS_INTERVAL)
        :base(prefabPrefix, releaseCheckInterval, unloadUnusedAssetsInterval)
    {
        _globalPrefix = prefix;
    }

    public AssetDBInitConfig(string prefix,
        string prefabPrefix, 
        float releaseCheckInterval, 
        float unloadUnusedAssetsInterval,
        int instanceQueueOneFrameLimit)
        :base(prefabPrefix, releaseCheckInterval, unloadUnusedAssetsInterval,instanceQueueOneFrameLimit)
    {
        _globalPrefix = prefix;
    }
}