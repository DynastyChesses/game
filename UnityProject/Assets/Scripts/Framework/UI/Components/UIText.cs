using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : TextMeshProUGUI
{
    public string key;

    void Awake()
    {
        base.Awake();
        if (Application.isPlaying)
        {
            this.text = Language.GetContent(key);
        }
    }
}
