#if !UNITY_WEBGL || UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AndroidPackageImpl:IBaseStorageImpl
    {
	    private const string PACKAGE_PATH_PREFIX = "jar:file://";
	    
	    struct VisitContext
	    {
		    public Action<string> callback;

		    public void VisitProxy(string path)
		    {
			    this.callback(path);
		    }
	    }

	    private List<string> _allPackPrefixes = new List<string>();

	    public AndroidPackageImpl(string root)
	    {
		    this.root = root;
		    
		    AddAssetPackPaths();

		    string rootPrefix = root.EndsWith("/") ? root : root + "/";
		    _allPackPrefixes.Add(rootPrefix);
	    }
	    
	    private static Dictionary<TAndroidJavaKey, TAndroidJavaValue> ConvertJavaMap<TAndroidJavaKey, TAndroidJavaValue>(
		    AndroidJavaObject javaMap)
	    {
		    using (var entrySet = javaMap.Call<AndroidJavaObject>("entrySet"))
		    using (var entrySetIterator = entrySet.Call<AndroidJavaObject>("iterator"))
		    {
			    var results = new Dictionary<TAndroidJavaKey, TAndroidJavaValue>();
			    while (entrySetIterator.Call<bool>("hasNext"))
			    {
				    using (var entry = entrySetIterator.Call<AndroidJavaObject>("next"))
				    {
					    var key = entry.Call<TAndroidJavaKey>("getKey");
					    var value = entry.Call<TAndroidJavaValue>("getValue");
					    results.Add(key, value);
				    }
			    }

			    return results;
		    }
	    }

	    private void AddAssetPackPaths()
	    {
		    const string platformHelperClassName = "com.companyName.util.PlatformHelper";

		    AndroidJavaObject platformHelper = null;
		    try
		    {
			    using (var platformHelperFactory = new AndroidJavaClass(platformHelperClassName))
			    {
				    platformHelper = platformHelperFactory.CallStatic<AndroidJavaObject>("getInstance");
			    }
		    }
		    catch (Exception)
		    {
			    // ignored
		    }


		    if (platformHelper != null)
		    {
			    using (var javaPackMap = platformHelper.Call<AndroidJavaObject>("getPackageAssetPacks"))
			    {
				    if (javaPackMap != null)
				    {
					    var packMap = ConvertJavaMap<string, string>(javaPackMap);
					    foreach (var iter in packMap)
					    {
						    _allPackPrefixes.Add(iter.Value + "/");
					    }
				    }
			    }
			    platformHelper.Dispose();
		    }
	    }
	    
	    private Dictionary<string, string> _finalPathMap = new Dictionary<string, string>(4);
	    private string GetFinalPath(string path)
	    {
		    if (!CommonUtil.StartsWith(path, PACKAGE_PATH_PREFIX))
		    {
			    return path;
		    }

		    if (_finalPathMap.TryGetValue(path, out var finalPath))
		    {
			    return finalPath;
		    }

		    foreach (var prefix in _allPackPrefixes)
		    {
			    if (CommonUtil.StartsWith(path, prefix))
			    {
				    finalPath = path.Remove(0, prefix.Length);
				    _finalPathMap.Add(path, finalPath);
				    return finalPath;
			    }
		    }

		    return path;
	    }
	    
	    public string root { get; }

	    public bool Exists(string path, bool isFile = true)
	    {
		    var finalPath = GetFinalPath(path);
		    return AndroidNativeIO.existsInPackage(finalPath, isFile ? (byte)1 : (byte)0) == 1;
	    }

	    public byte[] ReadAllBytes(string path)
	    {
		    var finalPath = GetFinalPath(path);
		    var fd = DefaultNativeIO.openPackageFileRead(finalPath, out var fileLength, out var openError);
		    if (fd != IntPtr.Zero)
		    {
			    var result = new byte[fileLength];
			    unsafe
			    {
				    fixed (byte* resultPtr = result)
				    {
					    var readBytes = DefaultNativeIO.readPackageFile(fd, new IntPtr((void*) resultPtr), 0, (int) fileLength, out var error);
					    DefaultNativeIO.closePackageFile(fd);
					    if (readBytes != (int) fileLength)
					    {
						    return null;
					    }
				    }
			    }

			    return result;
		    }

		    return null;
	    }

	    public string ReadAllText(string path)
	    {
		    var bytes = ReadAllBytes(path);
		    if (bytes != null)
		    {
			    using(var ms = new MemoryStream(bytes))
			    using (var sr = new StreamReader(ms, System.Text.Encoding.UTF8, true))
			    {
				    return sr.ReadToEnd();
			    }
		    }

		    return null;
	    }

	    public void ListDirectory(string path, bool recursive, StatMode mode, Action<string> visitFunc)
	    {
		    var finalPath = GetFinalPath(path);
		    AndroidNativeIO.listDirectoryInPackage(finalPath, recursive ? (byte)1 : (byte)0, (int)mode, new VisitContext()
		    {
			    callback = visitFunc
		    }.VisitProxy);
	    }

	    public Stream OpenRead(string path)
	    {
		    var finalPath = GetFinalPath(path);
		    var fd = DefaultNativeIO.openPackageFileRead(finalPath, out var fileLength, out var error);
		    if (fd != IntPtr.Zero)
		    {
			    return new UnsafePackageStream(fd, fileLength);
		    }

		    return null;
	    }

	    public long GetFileSize(string path)
	    {
		    var finalPath = GetFinalPath(path);
		    return AndroidNativeIO.getPackageFileSize(finalPath);
	    }
    }
#endif