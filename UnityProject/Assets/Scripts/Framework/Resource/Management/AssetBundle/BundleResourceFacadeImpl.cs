using System;

public class BundleResourceFacadeImpl : AbstractResourceFacadeImpl
{
    public override string GenerateLoadURL(string prefix, string localPath, string extension)
    {
        // 替换Path
        if (!string.IsNullOrEmpty(extension))
        {
            string[] pathArr = localPath.Split(".");
            string fullPath = pathArr[0] + extension;
            if (!fullPath.StartsWith("Assets"))
            {
                fullPath = "Assets/Arts/Prefabs/" + fullPath;
            }
            return fullPath;
        }
        // 如果不存在Assets
        if (!localPath.StartsWith("Assets"))
        {
            localPath = "Assets/Arts/Prefabs/" + localPath;
        }
        
        return localPath;
    }
    
    protected override void DoInitialize(IResourceInitConfig initConfig)
    {
        AssetBundleInitConfig bundleInitConfig = initConfig as AssetBundleInitConfig;

        var searchPaths = bundleInitConfig.GetSearchPathList();

        if (searchPaths.Count > 2)
        {
            throw new Exception("Can't support bundle search path size > 2");
        }

        SearchPath packageBundleSearchPath = null;
        foreach (var path in searchPaths)
        {
            if (path.persistType == PersistType.Package)
            {
                packageBundleSearchPath = path;
                break;
            }
        }
    }

    protected override void UnloadAll()
    {
        // TODO
    }
}
