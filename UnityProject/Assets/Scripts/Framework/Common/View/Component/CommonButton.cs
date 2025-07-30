using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommonButton
{
    public const string DEFAULT_CLICK_AUDIO = "common_button_click";
    
    public GameObject btnGo;
    public bool mute = false;
    public string clickAudioName;
    
    public static CommonButton CreateButton(Button btn, Image colorTweenImg = null, Transform scaleTweenTarget = null, string clickAudioName = DEFAULT_CLICK_AUDIO)
    {
        Image img = colorTweenImg;
        Transform target = scaleTweenTarget;

        if (img == null)
        {
            img = btn.image;
        }

        if (target == null)
        {
            target = btn.transform;
        }

        if (string.IsNullOrEmpty(clickAudioName))
        {
            clickAudioName = DEFAULT_CLICK_AUDIO;
        }

        btn.transition = Selectable.Transition.None;
        
        return new CommonButton(btn.gameObject,img,target,clickAudioName);
    }

    public static CommonButton CreateButton(GameObject go, Image colorTweenImg = null, Transform scaleTweenTarget = null,
        string clickAudioName = DEFAULT_CLICK_AUDIO)
    {
        Image img = colorTweenImg;
        Transform target = scaleTweenTarget;
        if (img == null)
        {
            img = go.GetComponent<Image>();
        }

        if (target == null)
        {
            target = go.transform;
        }

        if (string.IsNullOrEmpty(clickAudioName))
        {
            clickAudioName = DEFAULT_CLICK_AUDIO;
        }

        var btn = go.GetComponent<Button>();
        if (btn)
        {
            btn.transition = Selectable.Transition.None;
            if (!img)
            {
                img = btn.image;
            }
        }

        return new CommonButton(go, img, target, clickAudioName);
    }

    private CommonButton(GameObject go, Image colorTweenImg, Transform scaleTweenTarget, string clickAudioName)
    {
        this.btnGo = go;
        this.clickAudioName = clickAudioName;
        Init();
    }

    public void Init()
    {
        UIEventListener.OnClick(this.btnGo).AddListener(OnClick);
    }

    public void Dispose()
    {
        UIEventListener.OnClick(this.btnGo).RemoveListener(OnClick);
    }
    private void OnClick(GameObject go)
    {
        if (!mute)
        {
            // TODO
        }
    }
}