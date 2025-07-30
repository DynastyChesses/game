using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class SearchPath
{
    private Dictionary<string, string> _fullPathMap = new Dictionary<string, string>();
    private const bool k_CacheFullPath = false; // 安卓上fullpath较长，每个能有300多B，几千个占内存可观，不缓存试试

    private string _finalPrefix;    // 某root开头+prefix
    private string _prefix; // root后的搜索路径
    public string prefix => _prefix;

    private IBaseStorageImpl _impl;

    public IBaseStorageImpl storageImpl => _impl;

    private PersistType _persistType;
    public PersistType persistType => _persistType;

    public bool writable
    {
        get { return _impl is IReadWriteStorageImpl; }
    }

    public SearchPath(string prefix, PersistType persistType, bool useRelativePath = false)
    {
        this._persistType = persistType;
        this._impl = persistType == PersistType.Package ? PackageManager.storageImpl : StorageManager.storageImpl;
        this._prefix = prefix;
        if (!string.IsNullOrEmpty(this._prefix))
        {
            this._finalPrefix = useRelativePath ? this._prefix : Path.Combine(this._impl.root, this._prefix);
            if (this._finalPrefix[this._finalPrefix.Length - 1] != Path.AltDirectorySeparatorChar)
            {
                this._finalPrefix += Path.AltDirectorySeparatorChar;
            }
        }
        else if (useRelativePath)
        {
            this._finalPrefix = "";
        }
        else
        {
            this._finalPrefix = this._impl.root + Path.AltDirectorySeparatorChar;
        }
    }

    public string GetRootFullPath()
    {
        return string.IsNullOrEmpty(this._finalPrefix) ? this._impl.root : _finalPrefix;
    }

    public string GetFullPath(string relativePath)
    {
        if (string.IsNullOrEmpty(_finalPrefix))
        {
            return relativePath;
        }

        string result;
        if (!k_CacheFullPath || !_fullPathMap.TryGetValue(relativePath, out result))
        {
            result = Path.Combine(_finalPrefix, relativePath);
            if (k_CacheFullPath)
                _fullPathMap.Add(relativePath, result);
        }

        return result;
    }
}