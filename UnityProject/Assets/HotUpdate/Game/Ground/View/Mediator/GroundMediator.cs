

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MiracleWar;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;


public partial class GroundMediator : TBaseUIMediator<GroundSkin>
{
    // 多指
    private bool isMutiTouch = false;
    private float prev_distance = -1f;
    private Vector2 pinch_center = Vector2.zero;
    // 当前屏幕坐标
    private Vector2 current = new Vector2(-1, -1);
    //
    private int _update_interval = EquineScheduler.INVALID;
    //
    private Vector2 currVec;
    private int touchNumber = 0;
    // 定义 TouchBegin 和 TouchEnded
    private Vector2 touchBegin;
    private Vector2 touchEnded;
    private int touchBeginFrame;
    private int touchEndedFrame;
    private bool isDrag = false;
    
    //
    private int TouchBegin_Frame = -1;
    private int TouchMov_Frame = -1;
    private int TouchEnded_Frame = -1;
    //
    private bool isTouching = false;
    // 当前对象
    private GroundTiled currPickObj = null;
    
    // 已经选中的对象
    private GroundTiled choosed = null;
    // 屏幕斜边
    private float hypotenuse = 0.0f;
    
    
    // 当前文件处理【消息】和【交互逻辑】
    public GroundMediator() : base(MediatorNames.GROUND,NotificationConst.SHOW_GROUND,NotificationConst.HIDE_GROUND)
    {
        // TODO
    }

    protected override void OnCreateView(object data)
    {
        Application.targetFrameRate = 60;
        base.OnCreateView(data);
        
        // 开启 MatchingPanel
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_MATCHING_PANEL);
        
        // 选择地图为 NORMAL
        // var type = MAP_TYEP.NORMAL;
        // InitGround(type);
        // 添加EasyTouch
        EasyTouch.instance.enable = true;
        EasyTouch.On_OverUIElement += OnTouchDown;
        EasyTouch.On_UIElementTouchUp += OnTouchUp;
        EasyTouch.On_Pinch += OnPinch;
        EasyTouch.On_PinchEnd += OnPinchEnd;
        // 开启LateUpdate计时器
        GameLaunch.Instance.RegisterUpdate("Gound", Update);
        // 
        // ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_MAIN_U_I);
    }
    
    // 多指操作
    public void OnPinchEnd(Gesture gesture)
    {
        // 重置 Distance
        prev_distance = -1;
    }
    public void OnPinch(Gesture gesture)
    {
        isMutiTouch = true;
        if (prev_distance < 0)
        {
            // 开始
            prev_distance = gesture.twoFingerDistance;
            pinch_center = gesture.position;
            hypotenuse = (float)Math.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
        }
        else
        {
            var delta_distance = gesture.twoFingerDistance - prev_distance;
            prev_distance = gesture.twoFingerDistance;
            // 和屏幕的斜边比较
            float speed = delta_distance / hypotenuse;
            // Root 判断 (0.25 - 0.88)
            // < 0 缩小
            // > 0 放大
            var scale = _view.RootTr.localScale.x + speed * 0.4f;
            if (scale < 0.25)
            {
                scale = 0.25f;
            }

            if (scale > 0.88f)
            {
                scale = 0.88f;
            }
            // Debug.LogError($"当前Scale：{scale}");
            _view.RootTr.localScale = Vector3.one * scale;
        }
        
    }

    public void Update()
    {
        // 判断是否mov
        if (!isMutiTouch)
        {
            if (touchNumber > 0 && (touchBegin - currVec).magnitude > 5)
            {
                // 获取偏移值
                if ((current - currVec).magnitude > 0)
                {
                    // 
                    Vector2 off = currVec - current;
                    current = currVec;
                    // 当前对象移动
                    var vec_off = Vector2.LerpUnclamped(Vector2.zero, off, 0.5f);
                    isDrag = true;
                    _view.RootTr.anchoredPosition += vec_off;
                }
            }
        }
    }

    public void OnTouchDown(Gesture gesture)
    {
        if (gesture.touchCount == 1 && !isMutiTouch)
        {
            // 单指操作
            if (TouchBegin_Frame < Time.frameCount)
            {
                TouchBegin_Frame = Time.frameCount;
                if (!isTouching)
                {
                    isTouching = true;
                    isDrag = false;
                    currPickObj = _view.getTiled(gesture.pickedUIElement);
                    current = gesture.position;
                    touchBegin = gesture.position;
                    touchBeginFrame = Time.frameCount;
                    touchNumber = 0;
                }
                else
                {
                    touchNumber++;
                    currVec = gesture.position;
                }
            }
        }
        
    }

    public void OnTouchUp(Gesture gesture)
    {
        prev_distance = -1;
        if (gesture.touchCount == 1 && !isMutiTouch)
        {
            if (isTouching)
            {
                if (TouchEnded_Frame < Time.frameCount)
                {
                    TouchEnded_Frame = Time.frameCount;
                    isTouching = !isTouching;
                    touchNumber = 0;
                    //
                    if (!isDrag)
                    {
                        if (Time.frameCount - touchBeginFrame > 30)
                        {
                            // 长按
                            Debug.LogError("长按!");
                        }
                        else
                        {
                            // Tap
                            if (currPickObj != null)
                            {
                                currPickObj?.ClickAnimation();
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("拖动!");
                    }
                    // Clear Obj
                    currPickObj = null;
                }
            }
        }
        isMutiTouch = false;
    }

    protected override void OnShowViewAndRefresh(object data)
    {
        // 更新数据
    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
        EasyTouch.On_OverUIElement -= OnTouchDown;
        EasyTouch.On_UIElementTouchUp -= OnTouchUp;
        EasyTouch.On_Pinch -= OnPinch;
        EasyTouch.On_PinchEnd -= OnPinchEnd;
        //
        GameLaunch.Instance.UnRegisterUpdate("Gound");
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }
}
