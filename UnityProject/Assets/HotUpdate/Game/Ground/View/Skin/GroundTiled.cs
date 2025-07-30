

using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 定义GoundTileVO
public class GroundTileVO
{
    public int tid;
    public int x;
    public int y;
    public int index;
    public string info;
    // 是否为城镇
    public bool isCity;
    // 为谁的占领地
    public int ownId;
    // 是否为资源
    public bool isRes;
    // 是否为水池
    public bool isWater;
    // 是否为山地
    public bool isHill;
    // 是否有鱼
    public bool hasFish;
    // 是否存在金属
    public bool hasMatel;
}

public class GroundTiled : BaseScriptItemRendererView
{
    private TweenerCore<Vector3, Vector3, VectorOptions> ld;
    
    private GroundTileVO _data;

    public GroundTiled()
    {
        prefabPath = RenderNames.TildPrefabPath;
    }
    
    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as GroundTileVO;
            Refresh();
        }
    }

    public int getIndex()
    {
        return _data.index;
    }

    public void enableWater()
    {
        water.gameObject.SetActive(true);
        img.enabled = false;
    }

    public void disableWater()
    {
        water.gameObject.SetActive(false);
        img.enabled = true;
    }

    public override void Refresh()
    {
        base.Refresh();
        if (_data == null)
            return;
        Render();
    }
    
    // 放大/缩小
    public void ClickAnimation()
    {
        if (ld != null)
        {
            ld.Kill();
            ld = null;
            rect.gameObject.transform.localScale = Vector3.one;
        }
        ld = rect.gameObject.transform.DOScale(Vector3.one * 1.1f, 0.17f);
        ld.OnComplete(() =>
        {
            ld = rect.gameObject.transform.DOScale(Vector3.one * 1f, 0.17f);
            ld.OnComplete(() =>
            {
                ld = null;
            });
        });
        
    }

    public void Render()
    {
        if (img != null)
        {
            img.sprite = Terrains[_data.tid];
        }
        // 设置位置，从上到下，从左到右
        // TODO
        
        // 更新txt
        this.coodTxt.text = $"({_data.x},{_data.y})";

        // if (_data.isCity)
        // {
        //     this.gameObject.SetActive(false);
        // }
    }

    public void InitData()
    {
    }

    //auto generate propertyDef Start, Don't Delete it!
	public Image img;
	public RectTransform rect;
	public TextMeshProUGUI coodTxt;
	public GameObject water;
	public SkinUObjectList<Sprite> Terrains;
	public SkinUObjectList<Sprite> Mountains;
	public SkinUObjectList<Sprite> Forests;
	//auto generate propertyDef End, Don't Delete it!










    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.img = _viewSkin.GetSingleProperty("img", 0) as Image;
		this.rect = _viewSkin.GetSingleProperty("rect", 1) as RectTransform;
		this.coodTxt = _viewSkin.GetSingleProperty("coodTxt", 2) as TextMeshProUGUI;
		this.water = _viewSkin.GetSingleProperty("water", 3) as GameObject;
		this.Terrains = new SkinUObjectList<Sprite>(_viewSkin, "Terrains", 0);
		this.Mountains = new SkinUObjectList<Sprite>(_viewSkin, "Mountains", 1);
		this.Forests = new SkinUObjectList<Sprite>(_viewSkin, "Forests", 2);
		//auto generate propertySet End, Don't Delete it!




        if (img != null) img.alphaHitTestMinimumThreshold = 0.5f;
    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!





        base.Dispose();
    }
}

// 数据类
