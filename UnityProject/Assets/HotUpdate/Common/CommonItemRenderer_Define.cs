// 创建通用Item
using System;
using System.Collections.Generic;
using HotUpdate;
using UnityEngine;
public interface IAttachVo
{
    List<Type> attachList { get; }
    bool CheckAttach(Type type);
}
public partial class CommonItemRenderer: BaseScriptItemRendererView
{
    //
    public Transform parent = null;
    // Render 对象  
    public BaseScriptItemRendererView render;
    // GameObject 对象
    public GameObject gameObject;
    // 双指针 (只替换的时候使用)
    private GameObject old_gameObject;
    //
    private IAsyncResourceRequest req = null;

    private int _index = -1;
    private bool _selected;
    private bool _selectable;
    private IItemRendererHost _host;
    private object _data;

    public override GameObject viewObject => commonObj ?? render?.commonObj;
    
    public override int index
    {
        get
        {
            if (render != null)
            {
                return render.index;
            }
            else
            {
                return _index;
            }
        }
        set
        {
            _index = value;
            if (render != null)
            {
                render.index = value;
            }
        }
    }

    public override bool selected
    {
        get
        {
            if (render != null)
            {
                return render.selected;
            }
            else
            {
                return _selected;
            }
        }
        set
        {
            _selected = value;
            if (render != null)
            {
                render.selected = value;
            }
        }
    }

    public override bool selectable
    {
        get
        {
            if (render != null)
            {
                return render.selectable;
            }
            else
            {
                return _selectable;
            }
        }
        set
        {
            _selectable = value;
            if (render != null)
            {
                render.selectable = value;
            }
        }
    }

    public override IItemRendererHost host
    {
        get
        {
            if (render != null)
            {
                return render.host;
            }
            else
            {
                return _host;
            }
        }
        set
        {
            _host = value;
            if (render != null)
            {
                render.host = value;
            }
        }
    }
    
    public Vector3 center
    {
        get
        {
            HostArray<Vector3> worldcorners = HostArray<Vector3>.Create(4);
            (gameObject??parent.gameObject).GetComponent<RectTransform>().GetWorldCorners(worldcorners.ToMonoArray());
            return (worldcorners[0] + worldcorners[2])/2;
        }
    }
    
    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            if (value == null)
            {
                _data = null;
                return;
            }
            
            // 存在数据
            if (gameObject == null)
            {
                _data = value;
                CheckAttach();
                CreateObject();
            }
            else
            {
                bool isDirty = (_data == null || (_data.GetType() != value.GetType()));
                _data = value;
                CheckAttach();
                // 判断更新的数据是否一致
                if (isDirty)
                {
                    // 显示 Type
                    Debug.LogError($"{_data.GetType()}:{value.GetType().ToString()}");
                    
                    // 为了防止异步造成的闪帧问题, 在完成创建后回收
                    render.common_item_mode_enable_recycled = false;
                    old_gameObject = gameObject;
                    // Dispose();
                    gameObject = null;
                    // 再次创建
                    CreateObject();
                }
                else
                {
                    SetValue();
                }
            }
        }
    }
}

// 数据类
