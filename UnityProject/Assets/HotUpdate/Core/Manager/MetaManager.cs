using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using cfg;
using SimpleJSON;
using UnityEngine;

public class MetaManager: Singleton<MetaManager>
{
    public Tables Meta { get; private set; }
    private Dictionary<string, TextAsset> _caches = new Dictionary<string, TextAsset>();
    
    // 加载所有的表
    public void LoadMetas(Action cb)
    {
        //TODO: 反射拿字段就不用配置表了
        List<string> metas = new List<string>()
        {
            nameof(TbLanguage),
            nameof(TbLevelConfig),
            nameof(TbLevel),
            nameof(TbKV),
            nameof(TbGameUnlock),
            nameof(TbGuideLevel)
        };
        
        //luban runtime 使用小写
        metas = metas.Select(name => name.ToLower()).ToList();
        
        int curr = 0;
        foreach (var meta in metas)
        {
            ResourceFacade.instance.LoadObjectAsync<TextAsset>($"Assets/Arts/Data/{meta}.json", o =>
            {
                curr = curr + 1;
                _caches.TryAdd(meta, o);
                if (curr == metas.Count)
                {
                    Meta = new Tables(file => JSON.Parse(_caches[file].text));
                    cb?.Invoke();
                }
                return 0;
            });
        }
    }
    
    public override void Dispose()
    {
        _caches.Clear();
    }
}
