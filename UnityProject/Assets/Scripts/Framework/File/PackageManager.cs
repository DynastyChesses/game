using System;
using System.IO;
using UnityEngine;
public class PackageManager
{
    private static IBaseStorageImpl _impl = new DefaultStorageImpl(streamingAssetsPath);

    static string s_StreamingAssetsPath;

    /// <summary>
    /// 编辑器中修改路径，使开发更方便
    /// </summary>
    public static string streamingAssetsPath
    {
        get
        {
            if (string.IsNullOrEmpty(s_StreamingAssetsPath))
            {
                if (Application.isEditor)
                {
                    // 编辑器里用构建目录
                    var root = Path.GetDirectoryName(Application.dataPath);
                    s_StreamingAssetsPath = Path.Combine(root, "Library/ProjectBuildCache/Package");
                }
                else
                {
#if UNITY_WEBGL
                    s_StreamingAssetsPath = $"/{WXCodeSubPackageName}";
#else
                    s_StreamingAssetsPath = Application.streamingAssetsPath;
#endif
                }
            }

            return s_StreamingAssetsPath;
        }
    }


    public static void Initialize(IBaseStorageImpl impl)
    {
        _impl = impl;
    }

    public static IBaseStorageImpl storageImpl => _impl;
    

    public static bool Exists(string path, bool isFile = true)
    {
        return _impl.Exists(path, isFile);
    }
    
    public static byte[] ReadAllBytes(string path)
    {
        return _impl.ReadAllBytes(path);
    }
    
    public static string ReadAllText(string path)
    {
        return _impl.ReadAllText(path);
    }
    
    public static byte[] ReadAllBytesIfExist(string path)
    {
        return _impl.Exists(path) ? _impl.ReadAllBytes(path) : null;
    }

    public static void ListDirectory(string path, bool recursive, StatMode mode, Action<string> visitFunc)
    {
        _impl.ListDirectory(path, recursive, mode, visitFunc);
    }

    public static Stream OpenRead(string path)
    {
        return _impl.OpenRead(path);
    }

    public static long GetFileSize(string path)
    {
        return _impl.GetFileSize(path);
    }
}