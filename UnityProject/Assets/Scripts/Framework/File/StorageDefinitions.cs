using System;
using System.Collections.Generic;
using System.IO;

public enum ReadOption
{
    AbsolutePath = 0,
    SearchPath = 1,
}

public enum PersistType
{
    Package,
    Disk
}

public enum StatMode
{
    File,
    Directory,
    Both,
}
    
public interface IBaseStorageImpl
{
    string root { get; }

    bool Exists(string path, bool isFile = true);

    byte[] ReadAllBytes(string path);

    string ReadAllText(string path);

    void ListDirectory(string path, bool recursive, StatMode mode, Action<string> visitFunc);

    Stream OpenRead(string path);

    long GetFileSize(string path);
}
    
public interface IReadWriteStorageImpl : IBaseStorageImpl
{
    void CreateDirectory(string path);

    void WriteAllBytes(string path, byte[] bytes);

    void WriteAllText(string path, string content);

    void DeleteFile(string path);

    void DeleteDirectory(string path, bool recursive);

    void CopyFile(string srcPath, string dstPath, bool overwrite);

    void MoveFile(string srcPath, string dstPath);

    void MoveDirectory(string srcPath, string dstPath);

    Stream CreateFile(string path);

    Stream Open(string path, FileMode mode, FileAccess access);
}