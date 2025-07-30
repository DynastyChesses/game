

using System;
using System.Collections.Generic;
using UnityEngine;

public class Ground_TiledVO
{
    // 使用的图片名
    public string sprite_name;
    // 层级
    public int order;
    // x,y
    public int x;
    public int y;
}

public class Ground_Tiled : BaseScriptItemRendererView
{
    
    private Ground_TiledVO _data;

    public Ground_Tiled()
    {
        prefabPath = "Ground_Tiled";
    }
    
    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as Ground_TiledVO;
            Refresh();
        }
    }

    public override void Refresh()
    {
        base.Refresh();
        if (_data == null)
            return;
        Render();
    }

    public void Render()
    {
        // 根据x,y设置位置 
        this.gameObject.transform.localPosition = new Vector3(_data.x * 3.0f, _data.y * 3.0f, 0);
    }

    //auto generate propertyDef Start, Don't Delete it!
	public SpriteRenderer sprite;
	//auto generate propertyDef End, Don't Delete it!




    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.sprite = _viewSkin.GetSingleProperty("sprite", 0) as SpriteRenderer;
		//auto generate propertySet End, Don't Delete it!


    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!


        base.Dispose();
    }
}

// 数据类
