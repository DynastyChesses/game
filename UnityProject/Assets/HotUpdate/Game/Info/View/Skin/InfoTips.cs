

using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class InfoTipsVO
{
    public string message;
}

public class InfoTips : BaseScriptItemRendererView
{
    private InfoTipsVO _data;

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as InfoTipsVO;
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
        message.text = _data.message;
        // 等待1.5s 渐隐
        EquineScheduler.CallOnce(1.5f, (a, b, c) =>
        {
            BaseGameUtils.ValueTo(0.33f, f =>
            {
                canvasGroup.alpha = 1.0f * (1 - f);
            }, () =>
            {
                this.Dispose();
            });
        });
    }

    //auto generate propertyDef Start, Don't Delete it!
	public TextMeshProUGUI message;
	public CanvasGroup canvasGroup;
	//auto generate propertyDef End, Don't Delete it!
    

    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
		this.message = _viewSkin.GetSingleProperty("message", 0) as TextMeshProUGUI;
		this.canvasGroup = _viewSkin.GetSingleProperty("canvasGroup", 1) as CanvasGroup;
		//auto generate propertySet End, Don't Delete it!


        this.common_item_mode_enable_recycled = true;
        canvasGroup.alpha = 1.0f;

    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!





        base.Dispose();
    }
}

// 数据类
