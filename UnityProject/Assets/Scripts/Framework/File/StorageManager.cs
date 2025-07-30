using System;
using System.Collections.Generic;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
public class StorageManager
{
#if UNITY_EDITOR
    private static IReadWriteStorageImpl _impl = new DefaultStorageImpl(persistentDataPath);
#else
        private static IReadWriteStorageImpl _impl = null;
#endif

        static string s_PersistentDataPath;
        public static string persistentDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(s_PersistentDataPath))
                {
                    if (Application.isEditor)
                    {
                        // 编辑器换用好找的目录
                        var root = Path.GetDirectoryName(Application.dataPath);
                        s_PersistentDataPath = Path.Combine(root, "Library/EditorPerssitent");
                    }
                    else
                    {
#if UNITY_WEBGL
                        s_PersistentDataPath = new WeChatWASM.WXEnv().USER_DATA_PATH;
#else
                        s_PersistentDataPath = Application.persistentDataPath;
#endif
                    }
                }

                return s_PersistentDataPath;
            }
        }

        public static void Initialize(IReadWriteStorageImpl impl)
        {
            _impl = impl;
        }

        public static IBaseStorageImpl storageImpl => _impl;

        public static bool Exists(string path, bool isFile = true)
        {
            return _impl.Exists(path, isFile);
        }

        public static void CreateDirectory(string path)
        {
            _impl.CreateDirectory(path);
        }

        /// <summary>
        /// 跨平台的处理文件路径或目录不存在时创建目录，尤其是微信平台
        /// </summary>
        /// <param name="path">可以是文件或目录路径，目录需以/结尾</param>
        public static void CreateDirectoryIfNotExist(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            // Path.GetDirectoryName对wxfile://usr/xx返回wxfile:/user，少个斜杠
#if UNITY_WEBGL
            if (path.Contains("://"))
                directoryName = directoryName.Replace(":/", "://");
#endif

            if (directoryName != null && !Exists(directoryName, false))
            {
                _impl.CreateDirectory(directoryName);
            }
        }
        
        public static byte[] ReadAllBytes(string path)
        {
            return _impl.ReadAllBytes(path);
        }
        
        public static byte[] ReadAllBytesIfExist(string path)
        {
            return _impl.Exists(path) ? _impl.ReadAllBytes(path) : null;
        }
        
        public static string ReadAllText(string path)
        {
            return _impl.ReadAllText(path);
        }
        
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            _impl.WriteAllBytes(path, bytes);
        }
        
        public static void WriteAllText(string path, string content)
        {
            _impl.WriteAllText(path, content);
        }

        public static void DeleteFile(string path)
        {
            _impl.DeleteFile(path);
        }

        public static void DeleteDirectory(string path, bool recursive = true)
        {
            _impl.DeleteDirectory(path, recursive);
        }

        public static void ListDirectory(string path, bool recursive, StatMode mode, Action<string> visitFunc)
        {
            _impl.ListDirectory(path, recursive, mode, visitFunc);
        }

        public static Stream Open(string path, FileMode mode, FileAccess access)
        {
            return _impl.Open(path, mode, access);
        }

        public static Stream OpenRead(string path)
        {
            return _impl.OpenRead(path);
        }

        public static Stream OpenWrite(string path)
        {
            return _impl.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
        }

        public static void CopyFile(string srcPath, string dstPath, bool overwrite)
        {
            _impl.CopyFile(srcPath, dstPath, overwrite);
        }

        public static void MoveFile(string srcPath, string dstPath)
        {
            _impl.MoveFile(srcPath, dstPath);
        }

        public static Stream CreateFile(string path)
        {
            return _impl.CreateFile(path);
        }

        public static void MoveDirectory(string srcDir, string dstDir)
        {
            _impl.MoveDirectory(srcDir, dstDir);
        }

        public static long GetFileSize(string path)
        {
            return _impl.GetFileSize(path);
        }
    }