using System.Collections.Generic;
public class UnityRefObjectCachePool
{
	private UnityObjectType _type;
	
	private readonly Dictionary<string, UnityRefCacheObject> _assetDic;

	private readonly Dictionary<int, UnityRefCacheObject> _indexDic;

	private readonly Dictionary<string, UnityRefCacheObject> _recycleDic;

	public UnityRefObjectCachePool ()
	{
		_assetDic = new Dictionary<string, UnityRefCacheObject>(200);
		_indexDic = new Dictionary<int, UnityRefCacheObject>(200);
		_recycleDic = new Dictionary<string, UnityRefCacheObject>(200);
	}

	public void Dispose ()
	{
		var iter = _recycleDic.GetEnumerator();
		while (iter.MoveNext())
		{
			UnityRefCacheObject cache = iter.Current.Value;

			UnityRefCacheObject.DestroyDelegate destroyCallback = cache.onDestroy;
			if (destroyCallback != null)
			{
				cache.onDestroy = null;
				destroyCallback(cache.obj as UnityEngine.Object);
			}
			else
			{
				ResourceFacade.instance.Unload(cache.obj as UnityEngine.Object);
			}
		}
		iter.Dispose();

		iter = _assetDic.GetEnumerator();
		while (iter.MoveNext())
		{
			UnityRefCacheObject cache = iter.Current.Value;

			UnityRefCacheObject.DestroyDelegate destroyCallback = cache.onDestroy;
			if (destroyCallback != null)
			{
				cache.onDestroy = null;
				destroyCallback(cache.obj as UnityEngine.Object);
			}
			else
			{
				ResourceFacade.instance.Unload(cache.obj as UnityEngine.Object);
			}
		}
		iter.Dispose();

		_assetDic.Clear();
		_indexDic.Clear();
		_recycleDic.Clear();
	}

	public void Cache(UnityEngine.Object obj, string cacheName, float life, UnityRefCacheObject.DestroyDelegate destroyCallback = null)
	{
		UnityRefCacheObject cache = null;
		if (!_assetDic.TryGetValue(cacheName, out cache))
		{
			cache = new UnityRefCacheObject(life);
			cache.id = obj.GetInstanceID();
			cache.objName = cacheName;
			cache.obj = obj;
			cache.remainingLife = life;
			cache.referCount = 1;
			cache.onDestroy = destroyCallback;

			_assetDic.Add(cacheName, cache);
			_indexDic.Add(cache.id, cache);
		}
		else
		{
			cache.referCount++;
		}
	}

	public UnityEngine.Object Retrieve (string objName)
	{
		UnityRefCacheObject cache = null;
		if (_assetDic.TryGetValue(objName, out cache))
		{
			cache.referCount++;
			return cache.obj as UnityEngine.Object;
		}

		if (_recycleDic.TryGetValue(objName, out cache))
		{
			_recycleDic.Remove(objName);
			_assetDic.Add(objName, cache);
			_indexDic.Add(cache.id, cache);

			cache.referCount = 1;
			cache.remainingLife = cache.life;

			return cache.obj as UnityEngine.Object;
		}
		return null;
	}

	public void Release (UnityEngine.Object obj)
	{
		int id = obj.GetInstanceID();

		UnityRefCacheObject cache = null;

		if (_indexDic.TryGetValue(id, out cache))
		{
			cache.referCount--;
			if (cache.life > 0 && cache.referCount <= 0)
			{
				_recycleDic.Add(cache.objName, cache);
				_assetDic.Remove(cache.objName);
				_indexDic.Remove(cache.id);
			}
		}
	}

	private readonly Queue<string> nameQueue = new Queue<string>(100);

	public void Tick (float deltaTime)
	{
		if (nameQueue.Count > 0)
		{
			nameQueue.Clear();
		}

		var iter = _recycleDic.GetEnumerator();
		while(iter.MoveNext())
		{
			UnityRefCacheObject cache = iter.Current.Value;
			cache.remainingLife -= deltaTime;
			if (cache.remainingLife <= 0)
				nameQueue.Enqueue(cache.objName);
		}
		iter.Dispose();

		while(nameQueue.Count > 0)
		{
			string name = nameQueue.Dequeue();
			UnityRefCacheObject cache = _recycleDic[name];
			_recycleDic.Remove(name);

			UnityRefCacheObject.DestroyDelegate destroyCallback = cache.onDestroy;
			if (destroyCallback != null)
			{
				cache.onDestroy = null;
				destroyCallback(cache.obj as UnityEngine.Object);
			}
			else
			{
				ResourceFacade.instance.Unload(cache.obj as UnityEngine.Object);
			}
		}
	}

}

