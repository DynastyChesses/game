using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteAtlasWrapper
{
    private const int ATLAS_DISPOSE_TIME = 5;
    public static SpriteAtlas HeaderAtlas = null;
    public static Sprite DefaultSprite = null;
    
    public class Adapter : IDisposable
    {
        private bool _disposed;
        private List<Tuple<string, string>> _loaded;

        public Adapter()
        {
            _disposed = false;
            _loaded = new List<Tuple<string, string>>();
        }

        ~Adapter()
        {
            DisposeInternal();
        }
        
        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }
        
        void DisposeInternal()
        {
            if (_disposed)
            {
                return;
            }

            for (int i = 0,count = _loaded.Count; i < count; i++)
            {
                var it = _loaded[i];
                ReleaseSprite(it.Item1, it.Item2);
            }

            _disposed = true;
        }
        
        // 回调里不能使用ref参数，所以只好传image进来
        public void SetSpriteToImageAsync(string atlasName, string spriteName, SpriteRenderer image, bool pureAsync = true, Action failedAction = null, Action<Sprite> successAction = null)
        {
            if (image == null)
            {
                Logger.Error("Image is null");
                return;
            }

            // 使用实例ID以防止之后image对象被销毁
            var instId = image.GetInstanceID();

            // 防止重复调用时异步时序问题
            if (pureAsync && _reqCache.TryGetValue(instId, out var lastReq))
            {
                lastReq?.Dispose();
                _reqCache.Remove(instId);
            }

            var req = GetSpriteAtlasAsync(atlasName, atlasItem =>
            {
                //异步加载，在回调中需要对持有的image进行判空操作，以防加载完成后对象实际已被销毁
                if (atlasItem != null && image!=null)
                {
                    var sprite = atlasItem.GetSprite(spriteName);
                    if (sprite != null)
                        _loaded.Add(new Tuple<string, string>(atlasName, spriteName));
                    else
                    {
                        sprite = DefaultSprite;
                        if (failedAction != null)
                        {
                            failedAction.Invoke();
                            return;
                        }
                    }
                    image.enabled = true;
                    image.sprite = sprite;
                    // image?.gameObject.SetActive(true);
                    if (successAction != null)
                    {
                        successAction.Invoke(sprite);
                    }
                }
                _reqCache.Remove(instId);
            }, pureAsync);

            if (pureAsync && req != null)
            {
                _reqCache[instId] = req;
            }
        }
        
        public void SetSpriteToImageAsync(string atlasName, string spriteName, Image image, bool pureAsync = true, Action failedAction = null, Action<Sprite> successAction = null)
        {
            if (image == null)
            {
                Logger.Error("Image is null");
                return;
            }
    
            // 使用实例ID以防止之后image对象被销毁
            var instId = image.GetInstanceID();

            // 防止重复调用时异步时序问题
            if (pureAsync && _reqCache.TryGetValue(instId, out var lastReq))
            {
                lastReq?.Dispose();
                _reqCache.Remove(instId);
            }
            
            var req = GetSpriteAtlasAsync(atlasName, atlasItem =>
            {
                //异步加载，在回调中需要对持有的image进行判空操作，以防加载完成后对象实际已被销毁
                if (atlasItem != null && image!=null)
                {
                    var sprite = atlasItem.GetSprite(spriteName);
                    if (sprite != null)
                        _loaded.Add(new Tuple<string, string>(atlasName, spriteName));
                    else
                    {
                        sprite = DefaultSprite;
                        if (failedAction != null)
                        {
                            failedAction.Invoke();
                            return;
                        }
                    }
                    image.enabled = true;
                    image.sprite = sprite;
                    // image?.gameObject.SetActive(true);
                    if (successAction != null)
                    {
                        successAction.Invoke(sprite);
                    }
                }
                _reqCache.Remove(instId);
            }, pureAsync);

            if (pureAsync && req != null)
            {
                _reqCache[instId] = req;
            }
        }
        
        public void SetSpriteToImageAsync(string atlasName, string spriteName, int instId, bool pureAsync = true, Action failedAction = null, Action<Sprite> successAction = null)
        {
            // 防止重复调用时异步时序问题
            if (pureAsync && _reqCache.TryGetValue(instId, out var lastReq))
            {
                lastReq?.Dispose();
                _reqCache.Remove(instId);
            }

            var req = GetSpriteAtlasAsync(atlasName, atlasItem =>
            {
                //异步加载，在回调中需要对持有的image进行判空操作，以防加载完成后对象实际已被销毁
                if (atlasItem != null)
                {
                    var sprite = atlasItem.GetSprite(spriteName);
                    if (sprite != null)
                        _loaded.Add(new Tuple<string, string>(atlasName, spriteName));
                    else
                    {
                        sprite = DefaultSprite;
                        if (failedAction != null)
                        {
                            failedAction.Invoke();
                            return;
                        }
                    }
                    // image?.gameObject.SetActive(true);
                    if (successAction != null)
                    {
                        successAction.Invoke(sprite);
                    }
                }
                _reqCache.Remove(instId);
            }, pureAsync);

            if (pureAsync && req != null)
            {
                _reqCache[instId] = req;
            }
        }
    }
    
    private class _Item
    {
        private SpriteAtlas _atlas = null;
        public bool enable => _atlas != null;
        public SpriteAtlas atlas => _atlas;
        public int totalRefCount { get; private set; }
        public double timestamp;

        private Dictionary<string, Sprite> _loadedSprites = null;

        public _Item(SpriteAtlas atlas)
        {
            _atlas = atlas;
            _loadedSprites = new Dictionary<string, Sprite>(_atlas.spriteCount);
        }
        
        public void SetAtlas(SpriteAtlas atlas)
        {
            _atlas = atlas;
        }

        public void Dispose()
        {
            ResourceFacade.instance.Unload(_atlas);
            _atlas = null;
            _loadedSprites.Clear();
        }

        public Sprite GetSprite(string spriteName)
        {
            if (string.IsNullOrEmpty(spriteName))
                return null;
            
            if (!_loadedSprites.TryGetValue(spriteName, out var sprite))
            {
                sprite = _atlas.GetSprite(spriteName);
                if (sprite != null)
                {
                    _loadedSprites.Add(spriteName, sprite);
                }
                else
                {
                    return null;
                }
            }

            totalRefCount++;
            return sprite;
        }
        
        public void ReleaseSprite(string spriteName)
        {
            if (string.IsNullOrEmpty(spriteName))
                return;
            
            if (_loadedSprites.ContainsKey(spriteName))
            {
                totalRefCount--;

                if (totalRefCount == 0)
                {
                    timestamp = RealTimer.elapsedSeconds + ATLAS_DISPOSE_TIME;
                }
            }
        }
    }
    
    
    
    private Dictionary<string, _Item> _atlases = new Dictionary<string, _Item>();
    private static Dictionary<int, IAsyncResourceRequest> _reqCache = new Dictionary<int, IAsyncResourceRequest>();

    public static SpriteAtlasWrapper _instance;
    public static SpriteAtlasWrapper instance
    {
        get
        {
            _instance = _instance ?? new SpriteAtlasWrapper();
            return _instance;
        }
    }
    
    // [Obsolete("废弃，使用异步版本GetSpriteToImageAsync")]
    // public static Sprite GetSprite(string atlasName, string spriteName)
    // {
    //     var atlas = GetSpriteAtlas(atlasName);
    //     return atlas?.GetSprite(spriteName);
    // } 
    
    // 回调里不能使用ref参数，所以只好传image进来

    public static void StopSpriteReq(int instId)
    {
        if (_reqCache == null)
        {
            return;
        }

        if (_reqCache.ContainsKey(instId))
        {
            _reqCache[instId].Dispose();
            _reqCache.Remove(instId);
        }
    }

    public static void SetSpriteToImageAsync(string atlasName, string spriteName, Image image, bool pureAsync = true,
        Action loadCb = null, Action failCb = null, bool forceSyncLoad = false)
    {
        if (image == null)
        {
            return;
        }
        
        // 使用实例ID以防止之后image对象被销毁
        var instId = image.GetInstanceID();
        
        // 防止重复调用时异步时序问题
        if (pureAsync && _reqCache.TryGetValue(instId, out var lastReq))
        {
            lastReq?.Dispose();
            _reqCache.Remove(instId);
        }
        
        
        var req = GetSpriteAtlasAsync(atlasName, atlasItem =>
        {
            if (atlasItem != null && image != null)
            {
                image.sprite = atlasItem.GetSprite(spriteName);
            }
            else
            {
                failCb?.Invoke();
            }
            loadCb?.Invoke();
            _reqCache.Remove(instId);
        }, pureAsync);

        if (pureAsync && req != null)
        {
            _reqCache[instId] = req;
        }
    }

    public static void SetSpriteToImageAsync(string atlasName, string spriteName, SpriteRenderer image, bool pureAsync = true, Action loadCb = null)
    {
        if (image == null)
        {
            Logger.Error("SpriteRenderer is null");
            return;
        }

        // 使用实例ID以防止之后image对象被销毁
        var instId = image.GetInstanceID();

        // 防止重复调用时异步时序问题
        if (pureAsync && _reqCache.TryGetValue(instId, out var lastReq))
        {
            lastReq?.Dispose();
            _reqCache.Remove(instId);
        }

        var req = GetSpriteAtlasAsync(atlasName, atlasItem =>
        {
            if (atlasItem != null)
            {
                image.sprite = atlasItem.GetSprite(spriteName);
            }
            loadCb?.Invoke();
            _reqCache.Remove(instId);
        }, pureAsync);

        if (pureAsync && req != null)
        {
            _reqCache[instId] = req;
        }
    }

    public static void SetSpriteToImageAsync(string atlasName, string spriteName, Sprite defSprite, Action<Sprite> callback, bool pureAsync = true)
    {
        GetSpriteAtlasAsync(atlasName, atlasItem => {
            Sprite sprite = defSprite;
            if (atlasItem != null)
            {
                sprite = atlasItem.GetSprite(spriteName);
            }
            if (sprite == null)
            {
                sprite = defSprite;
            }
            callback?.Invoke(sprite);
        }, pureAsync);
    }

    private static IAsyncResourceRequest GetSpriteAtlasAsync(string atlasName, Action<_Item> callback, bool pureAsync = true)
    {
        if (string.IsNullOrEmpty(atlasName))
        {
            Logger.Debug("atlasname is null");
            callback?.Invoke(null);
            return null;
        }

        if (pureAsync || !instance._atlases.TryGetValue(atlasName, out var atlas) || !atlas.enable)
        {
            var req = ResourceFacade.instance.LoadObjectAsync<SpriteAtlas>(atlasName);
            // 老版框架可能返回null req
            if (req == null)
            {
                Debug.LogError($"asset not found:{atlasName}");
            }
            else
            {
                req.callback = request =>
                {
                    var newAtlas = request.asset as SpriteAtlas;
                    request.Dispose();
                    _Item atlasItem = null;
                    if (!instance._atlases.TryGetValue(atlasName, out atlasItem))
                    {
                        atlasItem = new _Item(newAtlas);
                        instance._atlases.Add(atlasName, atlasItem);
                    }
                    else if (!atlasItem.enable)
                    {
                        atlasItem.SetAtlas(newAtlas);
                    }
                    callback?.Invoke(atlasItem);
                };
            }
            return req;
        }
        else
        {
            callback?.Invoke(atlas);
        }
        return null;
    }

    private static void ReleaseSprite(string atlasName, string spriteName)
    {
        if (string.IsNullOrEmpty(atlasName))
            return;
        try
        {
            if (instance._atlases.TryGetValue(atlasName, out var atlas) && atlas.enable)
            {
                atlas.ReleaseSprite(spriteName);
            }
        }
        catch
        {
            // TODO
        }
        instance._atlases.Clear();
    }
    
    public void CheckLoadedResource()
    {
        var now = RealTimer.elapsedSeconds;
        var it = _atlases.GetEnumerator();
        while (it.MoveNext())
        {
            var value = it.Current.Value;
            if (value.enable && value.totalRefCount <= 0 && value.timestamp >= now)
            {
                value.Dispose();
            }
        }
        it.Dispose();
    }
    
    public static void Dispose()
    {
        if (_reqCache != null)
        {
            foreach (var req in _reqCache.Values)
            {
                req?.Dispose();
            }
            _reqCache.Clear();
        }
        var itor = instance._atlases.GetEnumerator();
        while (itor.MoveNext())
        { 
            itor.Current.Value.Dispose();
        }
        itor.Dispose();
        instance._atlases.Clear();
    }
}