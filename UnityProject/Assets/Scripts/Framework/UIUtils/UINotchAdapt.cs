using System;
using UnityEngine;

public class UINotchAdapt : MonoBehaviour
{
    private void Awake()
    {
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortraitUpsideDown = false;
        
        trans = GetComponent<RectTransform>();
    }
    
    private void Update()
    {
        RefreshSafeArea();
    }

    public RectTransform trans;
    public bool topValid = true;
    public bool bottomValid = true;
    public bool calculateOffset = true;
    private Rect LastSafeArea = new Rect(0, 0, 0, 0);
    void RefreshSafeArea()
    {
        Rect safeArea = Screen.safeArea;
#if UNITY_WEBGL
        safeArea = ScreenUtil.GetSafeArea();
#endif
        if (safeArea != LastSafeArea)
        {
            LastSafeArea = safeArea;

            Vector2 anchorMin = safeArea.position;
            anchorMin.x = 0; // anchorMin.x /= Screen.width;
            anchorMin.y = bottomValid ? anchorMin.y / Screen.height : 0; // anchorMin.y /= Screen.height;
            trans.anchorMin = anchorMin;

            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMax.x = 1; // anchorMax.x /= Screen.width;
            anchorMax.y = topValid ? anchorMax.y / Screen.height + GetAnchorMaxYOffset() : 1;  // anchorMax.y /= Screen.height;
            trans.anchorMax = anchorMax;
        }
    }

    float GetAnchorMaxYOffset()
    {
        if (!calculateOffset)
        {
            return 0;
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            switch (SystemInfo.deviceModel)
            {
                case "iPhone10,3":  // iPhone X (A1865/A1902)
                case "iPhone10,6":  // iPhone X (A1901)
                case "iPhone11,2":  // iPhone XS
                    return 0.018f;
                case "iPhone11,4":  // iPhone XS Max China ?
                case "iPhone11,6":  // iPhone XS Max
                    return 0.015f;
                case "iPhone11,8":  // iPhone XR
                    return 0.013f;
                case "iPhone12,1":  // iPhone 11
                case "iPhone12,3":  // iPhone 11 Pro ?
                case "iPhone12,5":  // iPhone 11 Pro Max ?
                    return 0.012f;
                case "iPhone13,1":  // iPhone 12 mini
                    return 0.019f;
                case "iPhone13,2":  // iPhone 12
                    return 0.017f;
                case "iPhone13,3":  // iPhone 12 Pro
                    return 0.016f;
                case "iPhone13,4":  // iPhone 12 Pro Max
                    return 0.015f;
                case "iPhone14,2":  // iPhone 13 Pro
                case "iPhone14,3":  // iPhone 13 Pro Max
                case "iPhone14,4":  // iPhone 13 mini
                case "iPhone14,5":  // iPhone 13
                case "iPhone14,7":  // iPhone 14
                case "iPhone14,8":  // iPhone 14 Plus
                case "iPhone15,2":  // iPhone 14 Pro
                case "iPhone15,3":  // iPhone 14 Pro Max
                case "iPhone15,4":  // iPhone 15
                case "iPhone15,5":  // iPhone 15 Plus
                case "iPhone16,1":  // iPhone 15 Pro
                case "iPhone16,2":  // iPhone 15 Pro Max
                    return 0.012f;
            }

            var safeArea = Screen.safeArea;
#if UNITY_WEBGL
            safeArea = ScreenUtil.GetSafeArea();
#endif
            // 如果是ios
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                // 有刘海屏
                if (Screen.height > safeArea.yMax)
                {
                    return 0.012f;
                }
            }
        }
        return 0;
    }

}