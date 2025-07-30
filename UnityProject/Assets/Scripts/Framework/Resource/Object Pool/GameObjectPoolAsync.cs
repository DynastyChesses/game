using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using UObject = UnityEngine.Object;

public class AsyncPoolInstantiateRequest : IAsyncResourceRequest
{
    private GameObject _asset;

    public UObject asset
    {
        get
        {
            _assetAccessed = true;
            return _asset;
        }
    }
    public string id { get; }
    public Action<IAsyncResourceRequest> callback { get; set; }
    public bool isDone { get; private set; }

    private bool _assetAccessed = false;
    
    private bool _disposed = false;

    public bool disposed => _disposed;

    public AsyncPoolInstantiateRequest(string assetId)
    {
        id = assetId;
    }

    public void Dispose()
    {
        _disposed = true;
        
        callback = null;
        var tAsset = _asset;
        _asset = null;

        if (!_assetAccessed && tAsset)
        {
            GameObjectPool.instance.Recycle(tAsset as GameObject);
        }
    }
    
    internal void OnComplete(GameObject go)
    {
        isDone = true;
        _asset = go;
        var c = callback;
        callback = null;
        if (c != null)
        {
            c(this);
            // 自动销毁，无回调不销毁
            Dispose();
        }
    }
}

public partial class GameObjectPool
{
    class InstantiateQueueItem : IDisposable
    {
        public string prefabPath;
        public bool autoActive;

        public AsyncPoolInstantiateRequest instantiateRequest;
        public AsyncResourceLoadRequest loadRequest;

        public Action<Object> onTemplateReady;
        
        public InstantiateQueueItem next;

        public void Dispose()
        {
            prefabPath = null;

            autoActive = false;

            instantiateRequest = null;
            loadRequest?.Dispose();
            loadRequest = null;
            onTemplateReady = null;

            next = null;
        }
    }

    // private InstantiateQueueItem _instantiateQueueHead;
    // private InstantiateQueueItem _instantiateQueueTail;

    // 待实例化队列
    private LinkedList<InstantiateQueueItem> _instantiateQueue = new LinkedList<InstantiateQueueItem>();
    // second
    private float _instantiateFrameLimit = 10f / 1000f;

    // 复用item的缓存池
    private readonly ObjectPool2<InstantiateQueueItem> _instantiateItemPool = 
        new ObjectPool2<InstantiateQueueItem>(64, () => new InstantiateQueueItem());

    public IAsyncResourceRequest SpawnAsync(string prefabPath, bool autoActive = true)
    {
        if (prefabPath == null)
        {
            return null;
        }
        
        var node = _instantiateItemPool.Allocate();
        node.prefabPath = prefabPath;
        node.autoActive = autoActive;
        node.instantiateRequest = new AsyncPoolInstantiateRequest(prefabPath);
        
        _instantiateQueue.AddLast(node);

        EquineScheduler.SetActive(_instantiateHandler, true);

        return node.instantiateRequest;
    }
    
    public IAsyncResourceRequest SpawnAsyncWithReady(string prefabPath, Action<Object> onTemplateReady, bool autoActive = true)
    {
        if (prefabPath == null)
        {
            return null;
        }
        
        var node = _instantiateItemPool.Allocate();
        node.prefabPath = prefabPath;
        node.autoActive = autoActive;
        node.instantiateRequest = new AsyncPoolInstantiateRequest(prefabPath);
        node.onTemplateReady = onTemplateReady;
        _instantiateQueue.AddLast(node);
        
        EquineScheduler.SetActive(_instantiateHandler, true);

        return node.instantiateRequest;
    }
    

    private void InstantiateQueueTick(int a, object context, UpdateTimeInfo timeInfo)
    {
        var enterTime = RealTimer.frameDuration;
        
        var iter = _instantiateQueue.First;
        while (iter != null)
        {
            var it = iter.Value;
            var prefabPath = it.prefabPath;
            var autoActive = it.autoActive;
            var removeIter = true;

            // 防止异常导致无法删除任务，导致每帧报错
            try
            {
                if (it.instantiateRequest != null && prefabPath != null && !it.instantiateRequest.disposed)
                {
                    removeIter = false;
                    GQueue availableQueue = SafelyGetAvailableQueue(prefabPath);
                    if (availableQueue.Count == 0)
                    {
                        if (it.loadRequest == null)
                        {
                            // bundle模式可能资源不存在而返回null，需要移除，防止不停报错
                            var req = (AsyncResourceLoadRequest)ResourceFacade.instance.LoadPrefabAsync(prefabPath);
                            if (req != null)
                            {
                                it.loadRequest = req;
                                req.callbackNoDispose = req2 =>
                                {
                                    it.onTemplateReady?.Invoke(req.originalAsset);
                                    it.onTemplateReady = null;  
                                };
                            }
                            else
                                removeIter = true;
                        }
                        else if (it.loadRequest.isDone)
                        {
                            removeIter = true;
                            // bugfix, 资源不存在时不实例化，防止每帧不停报错
                            if (it.loadRequest.originalAsset != null)
                            {
                                Allocate(it.loadRequest.originalAsset, prefabPath, 1);
                            }
                        }
                    }

                    if (availableQueue.Count > 0)
                    {
                        removeIter = true;
                        GPoolNode firstAvailableNode = availableQueue.Dequeue();
                        availableQueue.lastIdleTime = -1f;
                        GameObject gameObject = firstAvailableNode.go;
                        if (gameObject != null)
                        {
                            if (autoActive && !gameObject.activeSelf)
                                gameObject.SetActive(true);

                            spawnCount++;
                            firstAvailableNode.used = true;
                            it.instantiateRequest.OnComplete(gameObject);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                removeIter = true;
                Debug.LogException(e);
            }
            finally
            {
                var tmp = iter.Next;
                //remove
                if (removeIter)
                {
                    _instantiateQueue.Remove(iter);
                    _instantiateItemPool.Recycle(it);
                }
                iter = tmp;
            }
            

            var elapseTime = RealTimer.frameDuration - enterTime;
            if (elapseTime > _instantiateFrameLimit)
            {
                break;
            }
        }
        
        if (_instantiateQueue.Count == 0)
        {
            EquineScheduler.SetActive(_instantiateHandler, false);
        }
    }
}