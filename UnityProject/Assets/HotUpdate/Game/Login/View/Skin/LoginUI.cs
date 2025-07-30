

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : BaseScriptItemRendererView
{
    
    private object _data;

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
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
    }

    //auto generate propertyDef Start, Don't Delete it!
	public Button NewGame_btn;
	public Button MultiPlayer_btn;
	public Button Setting_btn;
	public Button Score_btn;
	public Button ThroneRoom_btn;
	public Button About_btn;
	//auto generate propertyDef End, Don't Delete it!




    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.NewGame_btn = _viewSkin.GetSingleProperty("NewGame_btn", 0) as Button;
		this.MultiPlayer_btn = _viewSkin.GetSingleProperty("MultiPlayer_btn", 1) as Button;
		this.Setting_btn = _viewSkin.GetSingleProperty("Setting_btn", 2) as Button;
		this.Score_btn = _viewSkin.GetSingleProperty("Score_btn", 3) as Button;
		this.ThroneRoom_btn = _viewSkin.GetSingleProperty("ThroneRoom_btn", 4) as Button;
		this.About_btn = _viewSkin.GetSingleProperty("About_btn", 5) as Button;
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
