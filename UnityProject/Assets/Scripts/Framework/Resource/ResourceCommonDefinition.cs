using System;
using UnityEngine;
using UObject = UnityEngine.Object;

public enum UnityObjectType
{
    Mesh,
    Texture,
    Material,
    Config,
    Audio,
    Other,
    None
}

public enum ResourceType
{
    Prefab,
    Material,
    Shader,
    Texture,
    TextAsset,
    SpriteAtlas,
    AnimatorOverrideController,
    AnimatorController,
    AnimationClip,
    Scriptable,
    AudioClip,
    Other,
}

public enum ResourceMode
{
    Default,
    AssetDatabase,
    AssetBundle
}

public enum ResourceError
{
    None = FMTaskError.None,
    Timeout = FMTaskError.Timeout,
    FileNotFound,
    AssetLoadError,
    BundleRequestNotComplete,
    LoadModeInvalid,
    HandleLostWhenLoadAsset,
    AsyncTaskGenerateError,
    DownloadAssetError,
    TaskError,
}

public interface ILongRunTask
{
    bool isCompleted { get; }

    float progress { get; }

    void Dispose();
}

public interface IUAssetBase
{
    UObject asset { get; }
}

public interface IAsyncBase
{
    bool isCompleted { get; }

    event Action<IAsyncBase> completeCallback;
}

public interface IAsyncResourceTask : IAsyncBase
{
    float progress { get; }

    string error { get; }
}

/// <summary>
/// 表示一个资源的加载，也表示一个资源。
/// 
/// </summary>
public interface IUAssetLoadHandle : IAsyncBase, IUAssetBase
{
}

public interface IResourceDownloadTask : IAsyncResourceTask
{
    string storagePath { get; }
}

public interface IAsyncResourceRequest : IUAssetBase
{
    string id { get; }

    Action<IAsyncResourceRequest> callback { get; set; }

    bool isDone { get; }

    void Dispose();
}

public interface IResourcePipelineCallback
{
    bool instantiated { get; } // 需要实例化

    bool destroyed { get; }


    /// <summary>
    /// 实例化队列优先级.越大越优先
    /// </summary>
    int priority { get; }

    void OnAssetLoadComplete(UObject asset);
}

public interface IResourceFacadeImplement
{
    UObject Instantiate(UObject asset, bool instantiated = true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="external">临时增加，true表示有资源管理外部进行的销毁、释放</param>
    /// <param name="delayTime"></param>
    void Destroy<T>(object obj, bool external, float delayTime = 0);
}

/// <summary>
/// 各种资源模式初始化的配置类
/// </summary>
public interface IResourceInitConfig
{
    ResourceMode resourceMode { get; }

    string prefabPathPrefix { get; }

    float releaseCheckInterval { get; }

    float unloadUnusedAssetsInterval { get; }
    int instanceQueueOneFrameLimit { get; }
}

public static class ResourcePathConst
{
    // 包外文件的保存路径
    public static string REMOTE_ASSET_DIRECTORY
    {
        // 写成属性，不影响生成代码
        get
        {
#if UNITY_WEBGL
            // 微信小游戏规定的缓存路径。这种可读写路径开头是http://usr或wxfile://usr
            return "__GAME_FILE_CACHE";
#else
            return "RemoteAssets";
#endif
        }
    }

    // 微信小游戏会识别url含StreamingAssets(可配)就会自动缓存到"__GAME_FILE_CACHE/StreamingAssets"，
    // 对应输出工程的webgl-min/StreamingAssets，也对应unity工程的Library\ProjectBuildCache\Upload\
    public const string WX_CACHEABLE_URL_TAG = "StreamingAssets";

    // 实际的bundle在xxx-cdn.yyy.com/{WX_CDN_PLATFORM_PATH}/{WX_CACHEABLE_URL_TAG}/Bundles/AllShader....
    // 要以/开头，但不要以/结尾，否则小游戏容易异常
    public const string WX_CDN_PLATFORM_PATH = "/APP/assets-wx";

    public const string TEMP_ASSET_DIRECTORY = "TempAssets";

    // 当要删除包外文件重新下载时，会把之前的文件放到这里，下载过程中这里有的就不下载
    public const string CACHE_ASSET_DIRECTORY = "CacheAssets";

    public const string ASSEMBLIES_DIRECTORY_PREFIX = "Assemblies/";

    public const string BUNDLE_DIRECTORY_PREFIX = "Bundles/";
}