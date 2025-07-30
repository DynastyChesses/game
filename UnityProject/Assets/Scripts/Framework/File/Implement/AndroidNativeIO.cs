using System;
using System.Runtime.InteropServices;

public class AndroidNativeIO
{
    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte existsInPackage(string path, byte isFile);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern void listDirectoryInPackage(string path, byte recursive, int mode,
        Action<string> visitFunc);

    [DllImport("native_helper", CallingConvention = CallingConvention.Cdecl)]
    public static extern long getPackageFileSize(string path);
}