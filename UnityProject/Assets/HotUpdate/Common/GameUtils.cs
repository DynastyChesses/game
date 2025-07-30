using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using LitJson;
using UnityEngine;


public class GameUtils:Singleton<GameUtils>
{
    public virtual void ShowTips(string msg)
    {
        // 直接加载
        var req = ResourceFacade.instance.LoadObjectAsync<GameObject>("Assets/Arts/Prefabs/Games/Common/InfoTips.prefab");
        req.callback = request =>
        {
            var o = request.asset as GameObject;
            InfoTips tips = new InfoTips();
            tips.Replace(o);
            o.transform.SetParent(UIManager.instance.topLayer, true);
            o.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -77f);
            o.transform.localScale = Vector3.one;
            InfoTipsVO vo = new InfoTipsVO();
            vo.message = msg;
            tips.data = vo;
            req.Dispose();
        };
    }
    
    

    public override void Dispose()
    {
        
    }
}