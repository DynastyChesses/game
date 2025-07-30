using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DefaultStorageImpl:StorageImplBase, IReadWriteStorageImpl
{
    public DefaultStorageImpl(string root):base(root)
    {
    }
    
    public bool Exists(string path, bool isFile = true)
    {
        var fullPath = GetFullPath(path);
        return isFile ? File.Exists(fullPath) : Directory.Exists(fullPath);
    }

    public void CreateDirectory(string path)
    {
        var fullPath = GetFullPath(path); 
        Directory.CreateDirectory(fullPath);
    }

    public byte[] ReadAllBytes(string path)
    {
        var fullPath = GetFullPath(path);
        return File.Exists(fullPath) ? File.ReadAllBytes(fullPath) : null;
    }

    public string ReadAllText(string path)
    {
        var fullPath = GetFullPath(path);
        return File.Exists(fullPath) ? File.ReadAllText(fullPath) : null;
    }

    public void WriteAllBytes(string path, byte[] bytes)
    {
        var fullPath = GetFullPath(path);
        File.WriteAllBytes(fullPath, bytes);
    }

    public void WriteAllText(string path, string content)
    {
        var fullPath = GetFullPath(path);
        File.WriteAllText(fullPath, content);
    }

    public void DeleteFile(string path)
    {
        var fullPath = GetFullPath(path);
        File.Delete(fullPath);
    }

    public void DeleteDirectory(string path, bool recursive)
    {
        var fullPath = GetFullPath(path);
        if (Directory.Exists(fullPath))
        {
            Directory.Delete(fullPath, recursive);
        }
    }

    public void CopyFile(string srcPath, string dstPath, bool overwrite)
    {
        var srcFullPath = GetFullPath(srcPath);
        var dstFullPath = GetFullPath(dstPath);
        File.Copy(srcFullPath, dstFullPath, overwrite);
    }

    public void MoveFile(string srcPath, string dstPath)
    {
        var srcFullPath = GetFullPath(srcPath);
        var dstFullPath = GetFullPath(dstPath);
        File.Move(srcFullPath, dstFullPath);
    }

    public void MoveDirectory(string srcPath, string dstPath)
    {
        var srcFullPath = GetFullPath(srcPath);
        var dstFullPath = GetFullPath(dstPath);
        Directory.Move(srcFullPath, dstFullPath);
    }

    public Stream CreateFile(string path)
    {
        return File.Create(GetFullPath(path));
    }

    public void ListDirectory(string path, bool recursive, StatMode mode, Action<string> visitFunc)
    {
        var fullPath = GetFullPath(path);
        var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        var searchPattern = "*";
        string[] result = null;
        switch (mode)
        {
            case StatMode.File:
                result = Directory.GetFiles(fullPath, searchPattern, searchOption);
                break;
            case StatMode.Directory:
                result = Directory.GetDirectories(fullPath, searchPattern, searchOption);
                break;
            case StatMode.Both:
                result = Directory.GetFileSystemEntries(fullPath, searchPattern, searchOption);
                break;
        }

        if (result != null)
        {
            foreach (var p in result)
            {
                visitFunc?.Invoke(p);
            }
        }
    }
    
    public Stream OpenRead(string path)
    {
        return Open(path, FileMode.Open, FileAccess.Read);
    }

    public virtual Stream Open(string path, FileMode mode, FileAccess access)
    {
        var fullPath = GetFullPath(path);
        return File.Open(fullPath, mode, access, FileShare.Read);
    }

    public long GetFileSize(string path)
    {
        var fullPath = GetFullPath(path);
        var fileInfo = new FileInfo(fullPath);
        return fileInfo.Exists ? fileInfo.Length : -1;
    }
}