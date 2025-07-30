

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityItemRenderVO
{
    public string model;
    public int x;
    public int y;
}

public class CityItemRender : BaseScriptItemRendererView
{
    
    private CityItemRenderVO _data;

    public CityItemRender()
    {
        prefabPath = RenderNames.CityPrefabPath;
    }

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as CityItemRenderVO;
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
        // 更换图片
        string imgPath = _data.model.Split("/")[^1].Split(".")[0];
        spriteAdapter.SetSpriteToImageAsync(AtlasNames.Buildings, imgPath, img);
    }

    //auto generate propertyDef Start, Don't Delete it!
	public Image img;
	public RectTransform rect;
	//auto generate propertyDef End, Don't Delete it!





    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.img = _viewSkin.GetSingleProperty("img", 0) as Image;
		this.rect = _viewSkin.GetSingleProperty("rect", 1) as RectTransform;
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
