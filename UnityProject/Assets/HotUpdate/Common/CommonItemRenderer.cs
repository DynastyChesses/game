// 创建通用Item
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommonItemRenderContext
{
    public float scale = 1;
    public bool isCostContext = false;
    public bool isRangeContext = false;
    public bool isAutoHideCountLabelWhenSingleOrLessCount = true;//是否在自动隐藏道具数量当只有一个以及以下道具数量的时候
    public bool isShowNameLabel = false;
    public bool isShowSpEmpty = false;
    public bool isShowCanReceiveFx = false;
    public bool isShowGreenArrow = false;
    public bool isShowFXImg = false;//可领特效礼包角标
    public bool isGray = false;//黑遮罩
    // 增加一个布局方式
    public TextAnchor starLayout = TextAnchor.MiddleCenter;
    public Color color = Color.white;
    public float fontsize = 24f;
    public bool enable_click = true;
    public bool isCenter = false;
}

public partial class CommonItemRenderer: BaseScriptItemRendererView
{
    ///////////////////////////////////// 静态方法 /////////////////////////////////////
    // 数据类型 / Render类型
    private static Dictionary<Type, Type> itemMap = new Dictionary<Type, Type>();
    
    /// <summary>
    /// 动态类型
    /// </summary>
    ///
    private static Dictionary<Type, Type> dynamicItemMap = new Dictionary<Type, Type>();
    
    // 用来支持多模版循环列表
    public CommonItemRenderer()
    {
        
    }
    
    public override void Replace(GameObject viewObj)
    {
        parent = viewObj.transform;
        commonObj = viewObj;
    }
    
    // 定义注册
    public static bool RegisterItem(Type dataVo, Type cls)
    {
        bool succ = false;
        if (dataVo == null)
        {
            return succ;
        }
        if (!itemMap.ContainsKey(dataVo))
        {
            itemMap.Add(dataVo, cls);
            succ = true;
        }

        return succ;
    }
    
    // 取消注册
    public static bool UnRegisterItem(Type dataVo)
    {
        bool succ = false;
        if (dataVo == null)
        {
            return succ;
        }
        if (itemMap.ContainsKey(dataVo))
        {
            itemMap.Remove(dataVo);
            succ = true;
        }
        return succ;
    }
    
    
    // 动态注册
    public static bool DynamicRegisterItem(Type dataVo, Type cls)
    {
        bool succ = false;
        if (dataVo == null)
        {
            return succ;
        }
        if (!dynamicItemMap.ContainsKey(dataVo))
        {
            dynamicItemMap.Add(dataVo, cls);
            succ = true;
        }

        return succ;
    }
    
    // 动态反注册
    public static bool UnDynamicRegisterItem(Type dataVo, Type cls)
    {
        bool succ = false;
        if (dataVo == null)
        {
            return succ;
        }
        if (dynamicItemMap.ContainsKey(dataVo))
        {
            dynamicItemMap.Remove(dataVo);
            succ = true;
        }
        return succ;
    }
    
    
    // 取消注册所有
    public static void UnRegisterAll()
    {
        itemMap.Clear();
        dynamicItemMap.Clear();
    }


    ///////////////////////////////////// 方法 /////////////////////////////////////
    
    // 增加 Attach (*) 公用 DataVO
    private Dictionary<Type, BaseScriptItemRendererView> childRenders = null;
    private Dictionary<Type, string> childPositions = null;

    public void CheckAttach()
    {
        ClearAttach();
        if (_data is IAttachVo attachVo)
        {
            if (attachVo.attachList == null || attachVo.attachList.Count == 0)
                return;
            foreach (var cls in attachVo.attachList)
                if (attachVo.CheckAttach(cls))
                    Attach(cls);
        }
    }
    
    public void Attach(Type cls, string pos = "")
    {
        if (childRenders == null)
        {
            childRenders = new Dictionary<Type, BaseScriptItemRendererView>();
        }

        if (childRenders.ContainsKey(cls))
        {
            // 报错：已经Attach过
            Debug.LogError("已经[Attach]过类别：" + cls.ToString());
            return;
        }
        childRenders.Add(cls, null);
        if (!string.IsNullOrEmpty(pos))
        {
            if (childPositions == null)
            {
                childPositions = new Dictionary<Type, string>();
            }
            childPositions.Add(cls, pos);
        }
    }
    
    // 清空 Attach
    public void ClearAttach()
    {
        if (childRenders == null)
        {
            return;
        }

        foreach (var attach in childRenders)
        {
            if (attach.Value != null)
            {
                attach.Value.Dispose();
            }
        }
        childRenders.Clear();
        childPositions?.Clear();
    }
    
    // 关闭 Attach
    public void UnAttach(Type cls)
    {
        if (childRenders == null)
        {
            return;
        }
        if (childRenders.ContainsKey(cls))
        {
            if (childRenders[cls] != null)
            {
                childRenders[cls].Dispose();
            }
            childRenders.Remove(cls);
        }
    }
    
    public void CreateObject()
    {
        if (_data == null)
        {
            Debug.LogError("数据错误!!");
            return;
        }

        if (this.gameObject != null)
        {
            Debug.LogError("已经创建，无需再次创建");
            return;
        }
        
        if (req != null)
        {
            req.Dispose();
            req = null;
        }
        // 数据类别
        var t = _data.GetType();
        if (!itemMap.ContainsKey(t) && !dynamicItemMap.ContainsKey(t))
        {
            Debug.LogError($"没有注册数据类型为{t.ToString()}的Render");
            return;
        }
        // Render 类别
        // 先判断动态类型是否存在
        Type cls = null;
        if (dynamicItemMap.ContainsKey(t))
        {
            cls = dynamicItemMap[t];
        } else if (itemMap.ContainsKey(t))
        {
            cls = itemMap[t];
        }

        if (cls == null)
        {
            Debug.LogError($"没有注册数据类型为{t.ToString()}的Render");
            return;
        }
        render = Activator.CreateInstance(cls) as BaseScriptItemRendererView;
        if (render == null)
        {
            Debug.LogError($"注册render为非BaseScriptItemRendererView类型");
            return;
        }

        if (render.prefabPath == String.Empty)
        {
            Debug.LogError($"未制定其prefabPath路径");
            return;
        }
        
        render.common_item_mode_enable_recycled = true;
        render.host = _host;
        req = ResourceFacade.instance.LoadPrefabAsync(render.prefabPath);
        req.callback = request =>
        {
            if (req.asset == null)
            {
                Debug.LogError($"资源({render.prefabPath})加载失败");
                return;
            }
            gameObject = req.asset as GameObject;
            //
            if (gameObject != null)
            {
                gameObject.transform.SetParent(parent);
                
                // 位置判断是否存在 RectTransform
                var rect = gameObject.GetComponent<RectTransform>();
                if (rect != null)
                {
                    rect.pivot = Vector2.one * 0.5f;
                    rect.anchoredPosition = Vector2.zero;
                    rect.anchorMax = Vector2.one / 2;
                    rect.anchorMin = Vector2.one / 2;
                }
                else
                {
                    gameObject.transform.localPosition = Vector3.zero;
                }
                gameObject.transform.localScale = Vector3.one;
                if (_index >= 0)
                {
                    gameObject.name = _index.ToString();
                    gameObject.transform.SetSiblingIndex(_index);
                }
                render.Replace(gameObject);
                //
                if (old_gameObject != null)
                {
                    ResourceFacade.instance.Unload(old_gameObject);
                    old_gameObject = null;
                }
                SetValue();
                if (initCallBack != null)
                {
                    initCallBack.Invoke();
                }
            }
            req.Dispose();
            req = null;
        };
    }

    public void Invoke(string name, object[] parameters)
    {
        if (render != null)
        {
            var method = render.GetType().GetMethod(name);
            if (method != null)
            {
                method.Invoke(render, parameters);
            }
        }
    }

    // 检测 AttachList
    public void RenderAttachList()
    {
        // 判断childRenders
        if (childRenders != null)
        {
            childRenders.ToList().ForEach(pair =>
            {
                if (pair.Value == null)
                {
                    // 实例化
                    childRenders[pair.Key] = Activator.CreateInstance(pair.Key) as BaseScriptItemRendererView;
                    // 实例化对象
                    if (!string.IsNullOrEmpty(childRenders[pair.Key].prefabPath))
                    {
                        var req = ResourceFacade.instance.LoadPrefabAsync(childRenders[pair.Key].prefabPath);
                        req.callback = request =>
                        {
                            childRenders[pair.Key].Replace(request.asset as GameObject);
                            var childTr = childRenders[pair.Key].gameObject.transform;
                            // childPositions/root
                            if (childPositions != null && childPositions[pair.Key] != null)
                            {
                                Transform tr = null;
                                for (int i = 0; i < render.viewSkin.singlePropList.Count; i++)
                                {
                                    if (render.viewSkin.singlePropList[i].propName.Equals(childPositions[pair.Key]))
                                    {
                                        tr = render.viewSkin.singlePropList[i].propVal as Transform;
                                        break;
                                    }
                                }
                                if (tr != null)
                                {
                                    childRenders[pair.Key].AttachParent(tr);
                                }
                                else
                                {
                                    childRenders[pair.Key].gameObject.transform.SetParent(render.gameObject.transform);
                                }
                            }
                            else
                            {
                                childRenders[pair.Key].gameObject.transform.SetParent(render.gameObject.transform);
                            }

                            childTr.localPosition = Vector3.zero;
                            childTr.localScale = Vector3.one;
                            req.Dispose();
                            req = null;
                            if (childRenders[pair.Key].gameObject != null)
                            {
                                childRenders[pair.Key].data = _data;
                            }
                            return;
                        };
                    }
                }

                //
                if (childRenders[pair.Key].gameObject != null)
                {
                    childRenders[pair.Key].data = _data;
                }
            });
        }
    }
    
    
    //
    public void SetValue()
    {
        if (_host != null)
        {
            render.host = _host;
        }
        if (_index >= 0)
        {
            render.index = _index;
        }
        render.selectable = _selectable;
        render.selected = _selected;
        // 
        render.common_item_mode_enable_recycled = true;
        render.data = _data;
        RenderAttachList();
    }
    //
    public CommonItemRenderer(Transform tr)
    {
        // 用于布局占位
        parent = tr;
    }

    public override void Dispose()
    {
        if (req != null)
        {
            req.Dispose();
            req = null;
        }
        // 自动反注册
        ClearAttach();
        if (render != null)
        {
            render.Dispose();
            render = null;
        }
        base.Dispose();
    }
}

// 数据类
