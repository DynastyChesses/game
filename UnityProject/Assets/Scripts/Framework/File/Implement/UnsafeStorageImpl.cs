#if !UNITY_WEBGL || UNITY_EDITOR
using System;
using System.IO;
public class UnsafeStorageImpl:DefaultStorageImpl
{
    enum Errno
    {
        FileNotFound = 2,
        FileAlreadyExisted = 17,
    }
    public UnsafeStorageImpl(string root) : base(root)
    {
    }

    public override Stream Open(string path, FileMode mode, FileAccess access)
    {
        if (access == FileAccess.Read)
        {
            switch (mode)
            {
                case FileMode.Append:
                    throw new ArgumentException("Append access can be requested only in write-only mode.");
                case FileMode.Create:
                case FileMode.Truncate:
                case FileMode.CreateNew:
                    throw new ArgumentException($"Combining FileMode: Read with FileAccess: {mode} is invalid.");
            }
        }
        var fullPath = GetFullPath(path);
        var fd = DefaultNativeIO.openPersistentFile(fullPath, (int) mode, (int) access, out var size, out var error);
        if (fd != IntPtr.Zero)
        {
            return new UnsafePersistentStream(fd, size);
        }

        switch (error)
        {
            case (int)Errno.FileAlreadyExisted:
                throw new IOException($"Could not create file \"{fullPath}\". File already exists.");
            case (int)Errno.FileNotFound:
                throw new IOException($"Could not find file \"{path}\"");
            default:
                break;
        }

        throw new IOException($"Unexpected IO error, code:{error}");
    }
}
#endif