using System;
using System.Collections.Generic;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Profiling;
using UObject = UnityEngine.Object;

public class ResourcePool
{
    // 增加池化
    public static Dictionary<Type, Dictionary<string, List<object>>>  object_pool = new Dictionary<Type, Dictionary<string, List<object>>>();
    public static Dictionary<Type, Dictionary<int, string>> maps = new Dictionary<Type, Dictionary<int, string>>();
    
    //
    public static void NextFrame(Action cb)
    {
        // 思考是否可以脱管??
        EquineScheduler.CallOnceFrame(1, (a, b, c) =>
        {
            cb.Invoke();
        });
    }
    
    // Pop 保证其一定是UObject
    public static void Pop<T>(string path, Action<T, bool> callback)
    {
        // 从池子拿
        var t = typeof(T);
        if (object_pool.ContainsKey(t) && object_pool[t].ContainsKey(path) && object_pool[t][path].Count > 0)
        {
            object o = (T)object_pool[t][path][0];
            if (o is UObject)
            {
                object_pool[t][path].RemoveAt(0);
                // next帧
                NextFrame(() =>
                {
                    callback.Invoke((T)o, false);
                });
            }
        }
        else
        {
            var ret = Addressables.LoadAssetAsync<T>(path);
            ret.Completed += handle =>
            {
                object o = handle.Result;
                if (o is UObject)
                {
                    callback.Invoke((T)o, true);
                }
            };
        }
    }
    
    // Push
    public static void Push<T>(object o)
    {
        // 简化方法，直接进池
        var t = typeof(T);
        if (!maps.ContainsKey(t))
        {
            // 异常太严厉了!
            // throw new Exception($"{typeof(T)}类别进池无效!");
            // 
            Debug.LogError($"{typeof(T)}类别进池无效!");
        }
        
        if (o is UObject && o is T)
        {
            var instId = ((UObject)o).GetInstanceID();
            if (maps[t].ContainsKey(instId))
            {
                var path = maps[t][instId];
                if (!object_pool.ContainsKey(t))
                {
                    object_pool[t] = new Dictionary<string, List<object>>();
                }

                if (!object_pool[t].ContainsKey(path))
                {
                    object_pool[t][path] = new List<object>();
                }
                object_pool[t][path].Add(o);
                // 如果是GameObject 放到 Pool 中
                if (o is GameObject)
                {
                    ((GameObject)o).transform.SetParent(GameLaunch.Instance.pool, true);
                    ((GameObject)o).transform.position = Vector3.zero;
                }
                // 从map中清除
                maps[t].Remove(instId);
            }
            else
            {
                Debug.LogError($"[池化]无法进池，对象类别不对");
            }
        }
        else
        {
            Debug.LogError($"[池化]当前对象不是Unity对象");
        }
    }
}

public abstract partial class AbstractResourceFacadeImpl : IResourceFacadeImplement
{
    public AbstractResourceFacadeImpl()
    {
        
    }
    
    
    public void Initialize(IResourceInitConfig initConfig)
    {
        this.DoInitialize(initConfig);
    }

    protected virtual void DoInitialize(IResourceInitConfig initConfig)
    {
        
    }

    public abstract string GenerateLoadURL(string prefix, string localPath, string extension);


    /// <summary>
    /// 准备简化这个过程
    /// 使用 ResourcePool 进行对象存储
    /// </summary>
    internal AsyncResourceLoadRequest LoadObjectAsync<T>(string assetId, bool create, int priority)
    {
        // 直接关闭pipeline的方式 
        var type = typeof(T);
        string fullName = assetId;
        AsyncResourceLoadRequest request = new AsyncResourceLoadRequest(assetId);
        ResourcePool.Pop<T>(fullName, (o, is_inst) =>
        {
            var t = typeof(T);
            var instId = request.OnAssetLoadComplete<T>(o, is_inst);
            if (!ResourcePool.maps.ContainsKey(t))
            {
                ResourcePool.maps[t] = new Dictionary<int, string>();
            }
            if (!ResourcePool.maps[t].ContainsKey(instId))
            {
                ResourcePool.maps[t][instId] = assetId;
            }
        });
        return request;
    }

    public UObject Instantiate(UObject original, bool instantiated = true)
    {
        UObject newObj = null;
        newObj = UObject.Instantiate(original);
        return newObj;
    }

    public GameObject NewGameObject(string name = "")
    {
        var go = new GameObject(name);
        return go;
    }

    /// <summary>
    /// 释放资源，外部逻辑会调用到此接口，用于减计数
    /// 计数达到要求时会放入回收队列，等待进一步处理
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="external"></param>
    /// <param name="delayTime"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Destroy<T>(object obj, bool external, float delayTime = 0)
    {
        // 如果是null则返回
        if (obj == null)
        {
            return;
        }
        // 分别判断
        if (obj is GameObject)
        {
            ResourcePool.Push<GameObject>(obj);
        }
        else if (obj is AudioClip)
        {
            ResourcePool.Push<AudioClip>(obj);
        }
        else if (obj is TextMeshProUGUI)
        {
            ResourcePool.Push<TextMeshProUGUI>(obj);
        }
        else if (obj is Texture2D)
        {
            ResourcePool.Push<Texture2D>(obj);
        }
        else if (obj is Material)
        {
            ResourcePool.Push<Material>(obj);
        }
        else if (obj is ScriptableObject)
        {
            ResourcePool.Push<ScriptableObject>(obj);
        }
        else
        {
            ResourcePool.Push<T>(obj);
        }
    }
    
    
    public void Dispose()
    {
        this.UnloadAll();
    }

    protected abstract void UnloadAll();
}
