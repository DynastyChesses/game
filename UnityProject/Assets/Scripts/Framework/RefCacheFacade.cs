using UnityEngine;
using System.Collections.Generic;

public class RefCacheFacade
{
	public const float TICK_INTERVAL = 5f;

	private Dictionary<int, UnityRefObjectCachePool> _unityCachePoolDic;
	private List<UnityRefObjectCachePool> _unityCachePoolList;
	private Dictionary<string, DisposableCacheObject> _autoDisposableObjectPool;
	private double _lastUpdateTime;

	private static RefCacheFacade _instance = null;

	public static RefCacheFacade instance
	{
		get
		{
			_instance = _instance ?? new RefCacheFacade();
			return _instance;
		}
	}

	public RefCacheFacade ()
	{
		_unityCachePoolDic = new Dictionary<int, UnityRefObjectCachePool>();
		_unityCachePoolList = new List<UnityRefObjectCachePool>();
		_autoDisposableObjectPool = new Dictionary<string, DisposableCacheObject> ();
		_lastUpdateTime = RealTimer.elapsedMilliseconds;
	}

	public void Dispose ()
	{
		int count = _unityCachePoolList.Count;
		for (int i = 0; i < count; ++i)
		{
			_unityCachePoolList[i].Dispose();
		}
		_unityCachePoolList.Clear();
		_unityCachePoolDic.Clear();

		Dictionary<string, DisposableCacheObject>.Enumerator iter = _autoDisposableObjectPool.GetEnumerator ();
		while (iter.MoveNext ())
		{
			System.Action<System.IDisposable> onDestroy = iter.Current.Value.onDestroy;
			if (onDestroy != null)
			{
				onDestroy (iter.Current.Value.obj);
			} else
			{
				iter.Current.Value.obj.Dispose ();
			}
		}
		_autoDisposableObjectPool.Clear ();
	}


	/// <summary>
	/// 此方法只可用来缓存可复用的对象，比如像材质，贴图这类东西
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="cacheName"></param>
	/// <param name="remainLife"></param>
	/// <param name="destroyCallback"></param>

	public void SaveCache (UnityEngine.Object obj, string cacheName, float remainLife = -1f ,
		UnityRefCacheObject.DestroyDelegate destroyCallback = null)
	{
		UnityObjectType assetType = getUnityAssetType(obj);

		if (assetType != UnityObjectType.None)
		{
			UnityRefObjectCachePool pool = null;
			if (!_unityCachePoolDic.TryGetValue((int)assetType, out pool))
			{
				pool = new UnityRefObjectCachePool();
				_unityCachePoolDic.Add((int)assetType, pool);
				_unityCachePoolList.Add(pool);
			}
			pool.Cache(obj, cacheName, remainLife, destroyCallback);
		}
		else
		{
			Logger.Error("Unknown cache type: " + obj.ToString());
		}
	}

	public void AddObjectToAutoDisposePool(System.IDisposable obj, string cacheName, float remainLife = 1f, 
		System.Action<System.IDisposable> destroyCallback = null)
	{
		if (obj != null && remainLife > 0)
		{
			if (!_autoDisposableObjectPool.ContainsKey (cacheName))
			{
				_autoDisposableObjectPool.Add (cacheName, new DisposableCacheObject () { 
					objName = cacheName,
					startTime = RealTimer.elapsedMilliseconds,
					remainingLife = remainLife,
					obj = obj,
					onDestroy = destroyCallback
				});
			}
		}
		else
		{
			Logger.Error("Argument is error: " + cacheName + " " + remainLife);
		}
	}

	public UnityEngine.Object RetrieveCache (UnityObjectType type, string cacheName)
	{
		UnityRefObjectCachePool pool = null;
		if (_unityCachePoolDic.TryGetValue((int)type, out pool))
		{
			UnityEngine.Object obj = pool.Retrieve(cacheName);
			return obj;
		}
		return null;
	}

	public System.IDisposable RetrieveObjectFromDisposePool(string cacheName)
	{
		DisposableCacheObject obj;
		if (_autoDisposableObjectPool.TryGetValue (cacheName, out obj))
		{
			_autoDisposableObjectPool.Remove (cacheName);
			return obj.obj;
		}
		return null;
	}

	public void ReleaseObjectInPool(string cacheName)
	{
		if (_autoDisposableObjectPool.ContainsKey (cacheName))
		{
			_autoDisposableObjectPool.Remove (cacheName);
		}
	}

	public void ReleaseCache (UnityEngine.Object obj)
	{
		if (obj == null)
		{
			Logger.Error("Object you want to release is null!");
			return;
		}

		UnityObjectType assetType = getUnityAssetType(obj);

		if (assetType != UnityObjectType.None)
		{
			UnityRefObjectCachePool pool = null;
			if (_unityCachePoolDic.TryGetValue((int)assetType, out pool))
			{
				pool.Release(obj);
			}
			else
			{
				Logger.Error("Cache pool doesn't exist: " + assetType.ToString());
			}
		}
		else
		{
			Logger.Error("Unknown cache type: " + obj.ToString());
		}
	}

	private readonly Queue<DisposableCacheObject> recyleObjQueue = new Queue<DisposableCacheObject>(100);

	public static void Tick(ref UpdateTimeInfo info)
	{
		instance.DoTick();
	}
	private void DoTick ()
	{
		var now = RealTimer.elapsedMilliseconds;
		float deltaTime = (float)(now - _lastUpdateTime);
		_lastUpdateTime = now;
		
		int count = _unityCachePoolList.Count;
		for (int i = 0; i < count; ++i)
		{
			_unityCachePoolList[i].Tick(deltaTime);
		}

		if (recyleObjQueue.Count > 0)
		{
			recyleObjQueue.Clear();
		}

		Dictionary<string, DisposableCacheObject>.Enumerator iter = _autoDisposableObjectPool.GetEnumerator ();
		while (iter.MoveNext ())
		{
			DisposableCacheObject cacheObj = iter.Current.Value;
			if (cacheObj.remainingLife <= RealTimer.elapsedMilliseconds - cacheObj.startTime)
			{
				recyleObjQueue.Enqueue (cacheObj);
			}
		}

		while(recyleObjQueue.Count > 0)
		{
			DisposableCacheObject cacheObj = recyleObjQueue.Dequeue();
			_autoDisposableObjectPool.Remove (cacheObj.objName);

			System.Action<System.IDisposable> onDestroy = cacheObj.onDestroy;
			if (onDestroy != null)
			{
				onDestroy (cacheObj.obj);
			} else
			{
				cacheObj.obj.Dispose ();
			}
		}
//		System.GC.Collect();
	}

	private UnityObjectType getUnityAssetType(UnityEngine.Object obj)
	{
		if (obj is Material)
		{
			return UnityObjectType.Material;
		}

		if (obj is Texture)
		{
			return UnityObjectType.Texture;
		}

		if (obj is Mesh)
		{
			return UnityObjectType.Mesh;
		}

		if (obj is TextAsset)
		{
			return UnityObjectType.Config;
		}

		if (obj is AudioClip)
		{
			return UnityObjectType.Audio;
		}

		if (obj is ScriptableObject || obj is Component || obj is GameObject)
		{
			return UnityObjectType.Other;
		}

		return UnityObjectType.None;
	}
}

