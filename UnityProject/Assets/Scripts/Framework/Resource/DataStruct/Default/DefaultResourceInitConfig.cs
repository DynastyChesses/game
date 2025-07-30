/// <summary>
/// Resources目录资源模式的初始化配置类
/// </summary>
public class DefaultResourceInitConfig : IResourceInitConfig
{
    public const string DEFAULT_PREFAB_PATH_PREFIX = "Prefabs/";

    public const float DEFAULT_RELEASE_CHECK_INTERVAL = 60f;

    public const float DEFAULT_UNLOAD_UNUSED_ASSETS_INTERVAL = 180f;

    public const int DEFAULT_INSTANCE_QUEUE_ONE_FRAME_LIMIT = 16;
    
    public DefaultResourceInitConfig(string prefabPathPrefix = DEFAULT_PREFAB_PATH_PREFIX, 
        float releaseCheckInterval = DEFAULT_RELEASE_CHECK_INTERVAL, 
        float unloadUnusedAssetsInterval = DEFAULT_UNLOAD_UNUSED_ASSETS_INTERVAL)
    {
        this._prefabPathPrefix = prefabPathPrefix ?? "";
        this._releaseCheckInterval = releaseCheckInterval <= 0 ? 
            DEFAULT_RELEASE_CHECK_INTERVAL : releaseCheckInterval;
        this._unloadUnusedAssetsInterval = unloadUnusedAssetsInterval <= 0 ? 
            DEFAULT_UNLOAD_UNUSED_ASSETS_INTERVAL : unloadUnusedAssetsInterval;
        this._instanceQueueOneFrameLimit = DEFAULT_INSTANCE_QUEUE_ONE_FRAME_LIMIT;
    }

    public DefaultResourceInitConfig(string prefabPathPrefix, float releaseCheckInterval, 
        float unloadUnusedAssetsInterval, int instanceQueueOneFrameLimit)
    {
        this._prefabPathPrefix = prefabPathPrefix ?? "";
        this._releaseCheckInterval = releaseCheckInterval <= 0 ? 
            DEFAULT_RELEASE_CHECK_INTERVAL : releaseCheckInterval;
        this._unloadUnusedAssetsInterval = unloadUnusedAssetsInterval <= 0 ? 
            DEFAULT_UNLOAD_UNUSED_ASSETS_INTERVAL : unloadUnusedAssetsInterval;
        this._instanceQueueOneFrameLimit = instanceQueueOneFrameLimit <= 0 ? 
            DEFAULT_INSTANCE_QUEUE_ONE_FRAME_LIMIT : instanceQueueOneFrameLimit;
    }

    public virtual ResourceMode resourceMode
    {
        get
        {
            return ResourceMode.Default;
        }
    }

    private readonly string _prefabPathPrefix;

    public string prefabPathPrefix
    {
        get
        {
            return _prefabPathPrefix;
        }
    }

    private readonly float _unloadUnusedAssetsInterval;

    public float unloadUnusedAssetsInterval
    {
        get
        {
            return _unloadUnusedAssetsInterval;
        }
    }

    private readonly float _releaseCheckInterval;

    public float releaseCheckInterval
    {
        get
        {
            return _releaseCheckInterval;
        }
    }
    
    private readonly int _instanceQueueOneFrameLimit;
    public int instanceQueueOneFrameLimit
    {
        get
        {
            return _instanceQueueOneFrameLimit;
        }
    }
}