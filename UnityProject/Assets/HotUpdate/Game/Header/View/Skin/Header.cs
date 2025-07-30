

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 数据层
public class HeaderVO
{
    // 头像
    public int header;
    // 名字
    public string name;
    // Uid
    public long uid;
    // 是否是自己
    public bool isMine;
}

public class Header : BaseScriptItemRendererView
{
    
    private HeaderVO _data;

    public Header()
    {
        prefabPath = RenderNames.HeaderPrefabPath;
    }
    
    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as HeaderVO;
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
        // 测试头像
        spriteAdapter.SetSpriteToImageAsync(AtlasNames.Header, $"all_heads000{_data.header}", Icon);
        text.text = _data.name;
        mine_flag.SetActive(_data.isMine);
    }

    //auto generate propertyDef Start, Don't Delete it!
	public Image Icon;
	public TextMeshProUGUI text;
	public GameObject mine_flag;
	//auto generate propertyDef End, Don't Delete it!





    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.Icon = _viewSkin.GetSingleProperty("Icon", 0) as Image;
		this.text = _viewSkin.GetSingleProperty("text", 1) as TextMeshProUGUI;
		this.mine_flag = _viewSkin.GetSingleProperty("mine_flag", 2) as GameObject;
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
