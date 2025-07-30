using System;
using UnityEngine;

public class FullScreenAdapt : MonoBehaviour
{
    public enum AdatptRatio
    {
        ScreenRatio,
        SelfRatio,
    }
    
    public enum AdaptWith
    {
        Scale,
        Size,
    }
    
    public Vector2 defaultResolusion = new Vector2(750, 1334);
    public AdatptRatio ratio = AdatptRatio.ScreenRatio;
    public AdaptWith adaptWith = AdaptWith.Size;
    public bool useScreenSize = false;
    private RectTransform _canvas;
    private Vector2 _currResolusion;

    private void Awake()
    {
        _canvas = GameObject.Find("UIContainer").GetComponent<RectTransform>();
        Adjust();
    }

    private void Update()
    {
        Adjust();
    }

    /// <summary>
    /// 调整适配
    /// </summary>
    private void Adjust()
    {
        if( _canvas.Equals( null ) ) return;
        // 屏幕尺寸无变化
        if (_currResolusion == _canvas.sizeDelta)
            return;
        
        _currResolusion = _canvas.sizeDelta;
        
        var scaleW = _currResolusion.x / defaultResolusion.x;
        var scaleH = _currResolusion.y / defaultResolusion.y;
        var safeRect = ScreenUtil.GetSafeArea();
        if (useScreenSize)
        {
            //逆向计算安全区域计算后的缩放
            scaleW /= safeRect.width / Screen.width;
            scaleH /= safeRect.height / Screen.height;
        }
        switch (ratio)
        {
            case AdatptRatio.ScreenRatio:
                float scaleFactor = Mathf.Max(scaleW, scaleH);
                ChangeSize(scaleFactor, scaleFactor);
                break;
            case AdatptRatio.SelfRatio:
                ChangeSize(scaleW, scaleH);
                break;
        }
        

    }

    void ChangeSize(float scaleW, float scaleH)
    {
        switch (adaptWith)
        {
            case AdaptWith.Scale:
                transform.localScale = new Vector3(scaleW, scaleH, 1);
                break;
            case AdaptWith.Size:
                ((RectTransform)transform).sizeDelta =
                    new Vector2(defaultResolusion.x * scaleW, defaultResolusion.y * scaleH);
                break;
        }
    }

}
