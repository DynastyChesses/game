

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextMeshProUtil
{

    public static bool TextMeshProLinkClick(TMP_Text text, PointerEventData evendata, string key = null)
    {
        if (string.IsNullOrEmpty(key))
            return false;
        Vector3 pos = new Vector3(evendata.position.x, evendata.position.y, 0);
        bool flag = true;
        int linkIndex =  TMP_TextUtilities.FindIntersectingLink(text, pos, UIManager.instance.uiCamera); //--UI相机
        if (linkIndex > -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            string linkKey = linkInfo.GetLinkID();
            if (linkKey == key)
            {
                return true;
            }
        }
        return false;
    }
    
}
