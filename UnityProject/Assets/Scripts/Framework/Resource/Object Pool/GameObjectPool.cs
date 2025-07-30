using UnityEngine;
using System.Collections.Generic;

public partial class GameObjectPool
{
	private float DEATH_TIME = 5 * 60f;
	
	class GPoolNode:System.IDisposable
	{
		public GameObject go;
		public string name;
		public bool used;

		public void Dispose()
		{
			go = null;
			name = null;
			used = false;
		}

		public static GPoolNode Allocate()
		{
			return new GPoolNode();
		}
	}

	class GQueue : Queue<GPoolNode>
	{
		public GQueue(int capacity) : base(capacity)
		{
		}

		public double lastIdleTime;

		public string name;

		public int totalAllocNum;
		
		public Vector3 scale;

		public int layer;
	}

	sealed class GQueuePool
	{
        sealed class GQueueInternal : GQueue
        {
            public GQueueInternal(int capacity) : base(capacity)
            {
            }

			public int idx;
        }

        private List<GQueueInternal> _queueList = new List<GQueueInternal>(10);

		private int _liveCount = 0;

		public int liveCount
		{
			get
			{
				return _liveCount;
			}
		}

		public GQueue GetLiveQueueAt(int index)
		{
			if (index >= 0 && index < _liveCount)
			{
				return _queueList[index];
			}
			return null;
		}

		public GQueue Allocate(int capacity, string name)
		{
			GQueueInternal queue = null;
			if (_liveCount < _queueList.Count)
			{
				queue = _queueList[_liveCount];
			}
			else
			{
				queue = new GQueueInternal(capacity);
				_queueList.Add(queue);
			}
			queue.idx = _liveCount;
			queue.name = name;
			queue.totalAllocNum = 0;
			queue.lastIdleTime = -1f;
			++_liveCount;
			return queue;
		}

		public void Recycle(GQueue queue)
		{
			GQueueInternal q = queue as GQueueInternal;
			q.Clear();
			if (_liveCount > 1)
			{
				--_liveCount;
				int oIdx = q.idx;
				GQueueInternal lastQ = _queueList[_liveCount];
				_queueList[_liveCount] = q;
				_queueList[oIdx] = lastQ;

				q.idx = _liveCount;
				lastQ.idx = oIdx;
			}
			else
			{
				_liveCount = 0;
			}
		}
	}

    private static GameObjectPool _instance;


	private ObjectPool2<GPoolNode> _nodePool = new ObjectPool2<GPoolNode>(100, GPoolNode.Allocate);

	private GQueuePool _queuePool = new GQueuePool();
	
	private Dictionary<string, GQueue> _availableNodesMap;

	/// <summary>
	/// Dictionary<go.name, Dictionary<go.GetInstanceID(), LinkedListNode<GameObject>>;
	/// </summary>
	private Dictionary<int, GPoolNode> _allNodeMap;
	// private Dictionary<string, Dictionary<int, LinkedListNode<GameObject>>> _linkedListNodeMaps;
	private double _lastCheckTime;
	
	private int _checkReleaseHandler;
	private int _instantiateHandler;
	
	private GameObject _emptyGOTemplate;
	public GameObject emptyGOTemplate
	{
		get
		{
			if(_emptyGOTemplate == null)
			{
				_emptyGOTemplate = new GameObject("EmptyParent");
				_emptyGOTemplate.SetActive(false);
				_emptyGOTemplate.transform.parent = poolParent;
			}
			return _emptyGOTemplate;
		}
	}
	
	private void Allocate (object prefabTemplateOrPath, string cacheKey, int count = 10)
	{
		if (prefabTemplateOrPath == null)
		{
			Debug.LogError($"GameObjPool Allocate failed:{cacheKey}");
			return;
		}
		string prefabPath = prefabTemplateOrPath as string;
		GQueue availableQueue = SafelyGetAvailableQueue(cacheKey);
		for (int i = 0; i < count; ++i)
		{
			GameObject newGameObject = prefabPath != null ? null : ResourceFacade.Instantiate(prefabTemplateOrPath as GameObject);
			if (newGameObject == null)
			{
				Debug.LogError($"GameObjPool Allocate failed2:{cacheKey}");
				return;
			}
			if (availableQueue.totalAllocNum == 0)
			{
				availableQueue.scale = newGameObject.transform.localScale;
				availableQueue.layer = newGameObject.layer;
			}
			++availableQueue.totalAllocNum;
			newGameObject.gameObject.SetActive(false);
			newGameObject.layer = availableQueue.layer;
			//newGameObject.name = key;
			newGameObject.transform.SetParent(GetPoolParent(newGameObject), false);

			GPoolNode node = _nodePool.Allocate();
			node.go = newGameObject;
			node.name = cacheKey;
			node.used = false;
			availableQueue.Enqueue(node);
			int newGameObjectId = newGameObject.GetInstanceID();
			_allNodeMap.Add(newGameObjectId, node);
		}
	}

	public void SetUIPoolContainer(Transform uiPoolContainer)
	{
		_uiPoolContainer = uiPoolContainer;
		if (_uiPoolParent)
		{
			_uiPoolParent.SetParent(uiPoolContainer, true);
		}
	}
	
	private Transform _uiPoolContainer;
	private Transform _uiPoolParent;
	public Transform uiPoolParent
	{
		get
		{
			if(_uiPoolParent == null)
			{
				_uiPoolParent = new GameObject("[UIPool]").transform;
                _uiPoolParent.transform.parent = _uiPoolContainer;
                _uiPoolParent.gameObject.layer = _uiPoolContainer ? _uiPoolContainer.gameObject.layer : LayerMask.NameToLayer("UI");
                var transform = _uiPoolParent.transform;
                transform.localScale = Vector3.one;
                transform.position = Vector3.zero;
			}
			return _uiPoolParent;
		}
	}
	private Transform _poolParent;
	public Transform poolParent
	{
		get
		{
			if(_poolParent == null)
			{
				_poolParent = new GameObject("[Pool]").transform;
				GameObject.DontDestroyOnLoad(_poolParent);
			}
			return _poolParent;
		}
	}
	
	public static GameObjectPool instance {
		get 
		{
			if (_instance == null)
			{
				_instance = new GameObjectPool ();
			}
			
			return _instance;
		}
	}
	
	public int spawnCount
	{
		get;
		private set;
	}
	
	public GameObjectPool ()
	{
		_availableNodesMap = new Dictionary<string, GQueue>(20);
		// _usingListMap = new Dictionary<string, LinkedList<GameObject>>();
		// _linkedListNodeMaps = new Dictionary<string, Dictionary<int, LinkedListNode<GameObject>>>();
		_allNodeMap = new Dictionary<int, GPoolNode>(100);
		_lastCheckTime = RealTimer.elapsedSeconds;
	}

	public void Initialize(float checkInternal, float deathTime, int instantiateLimit)
	{
		DEATH_TIME = deathTime;
		_instantiateFrameLimit = instantiateLimit / 1000f;
		
		_checkReleaseHandler = EquineScheduler.AddTimeLimitUpdator(checkInternal, Tick);
		_instantiateHandler = EquineScheduler.AddFrameLimitUpdator(1, InstantiateQueueTick);
	}

	public void Dispose()
	{
		Clear();
		EquineScheduler.RemoveLimitUpdator(ref _checkReleaseHandler);
		EquineScheduler.RemoveLimitUpdator(ref _instantiateHandler);
	}
	
	public void Tick(int a, object context, UpdateTimeInfo timeInfo)
	{
		_lastCheckTime = RealTimer.elapsedSeconds;
		for (int i = 0; i < _queuePool.liveCount; )
		{
			GQueue queue = _queuePool.GetLiveQueueAt(i);
			if (queue.lastIdleTime > 0 && RealTimer.elapsedSeconds - queue.lastIdleTime > DEATH_TIME)
			{
				DoClearQueue(queue);
			}
			else
			{
				++i;
			}
		}
	}
	
	public void Recycle (GameObject go, bool moveToPoolParent = true)
	{
		int goId = go.GetInstanceID();

		GPoolNode node;
		if(!_allNodeMap.TryGetValue(goId, out node))
		{
			Debug.LogError("Try to recycle a wrong GameObject " + go.name);
			GameObject.Destroy(go);
			return;
		}

		if (node.used == false)
		{
			Debug.LogError("Try to recycle a queued GameObject " + go.name);
			return;
		}
		
		spawnCount--;
		string key = node.name;
		GQueue availableList = SafelyGetAvailableQueue(key);
		
		if(moveToPoolParent)
		{
			go.transform.SetParent(GetPoolParent(go), false);
		}
		go.SetActive(false);
		node.used = false;
		availableList.Enqueue(node);

		go.transform.localScale = availableList.scale;

		if (availableList.Count == availableList.totalAllocNum)
		{
			availableList.lastIdleTime = RealTimer.elapsedSeconds;
		}
	}
	
	public void Clear()
	{
		var iter = _allNodeMap.GetEnumerator();
		while(iter.MoveNext())
		{
			GPoolNode node = iter.Current.Value;
			if (node.go == null)
			{
				Debug.LogError(node.name + " recycle error");
			}
			else
			{
				ResourceFacade.instance.Unload(node.go);
			}
			_nodePool.Recycle(node);
		}
		_allNodeMap.Clear();
		
		var iter2 = _availableNodesMap.GetEnumerator();
		while(iter2.MoveNext())
		{
			_queuePool.Recycle(iter2.Current.Value);
		}
		_availableNodesMap.Clear();
	}

	private static List<int> _cachedKeyList = new List<int>(100);
	public void Clear(string cacheName)
	{
		GQueue queue;
		if (_availableNodesMap.TryGetValue(cacheName, out queue))
		{
			DoClearQueue(queue);
		}
	}

	private void DoClearQueue(GQueue queue)
	{
		var iter = _allNodeMap.GetEnumerator();
		_cachedKeyList.Clear();
		string cacheName = queue.name;
		while(iter.MoveNext())
		{
			GPoolNode node = iter.Current.Value;
			if (node.name == cacheName)
			{
				if (node.go == null)
				{
					Debug.LogError(iter.Current.Key + " recycle error");
				}
				else
				{
					ResourceFacade.instance.Unload(node.go);
				}
				_nodePool.Recycle(node);
				_cachedKeyList.Add(iter.Current.Key);
			}
		}
		int count = _cachedKeyList.Count;
		for (int i = 0; i < count; ++i)
		{
			_allNodeMap.Remove(_cachedKeyList[i]);
		}

		_availableNodesMap.Remove(cacheName);

		_queuePool.Recycle(queue);
	}
	
	private Transform GetPoolParent(GameObject go)
	{
        if(go.layer == uiPoolParent.gameObject.layer)
			return uiPoolParent;
		else
			return poolParent;
	}
	
	/// <summary>
	/// 理论上不可能返回null？
	/// </summary>
	private GQueue SafelyGetAvailableQueue(string key)
	{
		GQueue availableQueue;
		if(!_availableNodesMap.TryGetValue(key, out availableQueue))
		{
			availableQueue = _queuePool.Allocate(10, key);
			_availableNodesMap.Add(key, availableQueue);
		}
		return availableQueue;
	}
}
