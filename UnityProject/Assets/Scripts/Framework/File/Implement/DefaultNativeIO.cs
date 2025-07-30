using System;
using System.Runtime.InteropServices;
public class DefaultNativeIO
{
    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr openPersistentFile(string path, int mode, int access, out int size, out int error);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern int readPersistentFile(IntPtr fd, IntPtr ptr, int offset, int count, out int error);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern int writePersistentFile(IntPtr fd, IntPtr ptr, int offset, int count);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern void closePersistentFile(IntPtr fd);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern int setPersistentFileLength(IntPtr fd, int length);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern void flushPersistentFile(IntPtr fd);
        
    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr openPackageFileRead(string path, out int fileLength, out int error);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern int readPackageFile(IntPtr fd, IntPtr ptr, int offset, int count, out int error);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern void closePackageFile(IntPtr fd);
}