#if RG_WECHAT_MINIGAME && !UNITY_EDITOR
using System;

/// <summary>
/// 微信小游戏摇杆操作状态
/// 用处是接收小游戏的手势状态
/// 1. 微信小游戏的手势状态更新时机不太完备，从update获取状态可能有收拾确实
/// 2. 用来支持小游戏手势离开屏幕时，继续操作摇杆
/// </summary>
public class WechatMiniGameEtcControl
{
    public static WechatMiniGameEtcControl instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WechatMiniGameEtcControl();
            }

            return _instance;
        }
    }

    private static WechatMiniGameEtcControl _instance;

    /// <summary>
    /// 配置同微信小游戏WXTouchCancelData
    /// </summary>
    public JoystickMode joystickMode = JoystickMode.ContinuePressed;

    /// <summary>
    /// 摇杆处理模式，小游戏的pc/mac环境下鼠标离屏接收不到状态，需要特殊处理
    /// 枚举值和微信小游戏WXTouchCancelData.TouchCancelActionEnum对应
    /// 不直接引用微信小游戏的枚举是为了避免引用微信小游戏的代码
    /// </summary>
    public enum JoystickMode
    {
        None = 0,
        
        /// <summary>
        /// 鼠标离开屏幕则摇杆回正
        /// </summary>
        SkipPressed = 1,

        /// <summary>
        /// 鼠标离开屏幕摇杆持续移动，并且鼠标回屏幕摇杆继续移动
        /// 直到新的TouchStart出现，摇杆复原
        /// </summary>
        ContinuePressed = 2,
    }


    /// <summary>
    /// 监听小游戏的摇杆离屏回调
    /// </summary>
    public void OnTouchCancel()
    {
    }

    private bool _touchStart = false;

    /// <summary>
    /// 获取点击Start状态
    /// </summary>
    /// <returns></returns>
    public bool IsTouchStart()
    {
        return _touchStart;
    }

    private bool _needRevertBeforePointerEnter = false;

    /// <summary>
    /// 接收特殊的点击按下，避免小游戏手势缺失
    /// </summary>
    public void OnTouchStart()
    {
        _touchStart = true;
        if (joystickMode == JoystickMode.ContinuePressed)
        {
            _needRevertBeforePointerEnter = true;
        }
    }

    /// <summary>
    /// 清理点击Start状态
    /// </summary>
    public void ClearTouchStart()
    {
        _touchStart = false;
    }

    public bool BeforeOnPointerEnter()
    {
        if (_needRevertBeforePointerEnter)
        {
            _needRevertBeforePointerEnter = false;
            return true;
        }

        return false;
    }
}

#endif