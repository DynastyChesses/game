using System.Collections.Generic;
using System.IO;

public class StorageImplBase
{
    private readonly Dictionary<string, string> _fullPathCache = new Dictionary<string, string>();
    private string _root;

    public StorageImplBase(string root)
    {
        _root = root;
    }

    public string root => _root;

    protected string GetFullPath(string path)
    {
        if (string.IsNullOrEmpty(_root)
            || Path.IsPathRooted(path)
#if UNITY_WEBGL
                || path.StartsWith("http") // 微信开发工具
                || path.StartsWith("wxfile") // 微信真机
#endif
           )
        {
            return path;
        }

        if (!_fullPathCache.TryGetValue(path, out var fullPath))
        {
            fullPath = Path.Combine(_root, path);
            _fullPathCache.Add(path, fullPath);
        }

        return fullPath;
    }
}