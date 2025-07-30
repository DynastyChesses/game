using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public enum GuideTriggerType{
    [LabelText("物理触发")]
    Trigger = 1,//物理触发
    [LabelText("计时器")]
    Timer = 2,//计时器
}

public enum GuideEventType
{
    [LabelText("对话")]
    Talk = 1,
    [LabelText("隐藏-对话")]
    HideTalk = -1,
    [LabelText("移动到多个目标")]
    MoveToMultiTarget = 2,
    [LabelText("旋转屏幕引导")]
    ShowRotateGuide = 3,
    [LabelText("跳跃引导")]
    ShowJumpGuide = 4,
    [LabelText("移动引导")]
    ShowMoveGuide = 5,
    [LabelText("自动移动引导")]
    AutoMoveGuide = 6,
    [LabelText("推门引导")]
    PushDoor = 7,
    [LabelText("相机-移动到目标")]
    CameraMove = 8,
    [LabelText("相机-返回")]
    CameraBack = 9,
    [LabelText("使用道具引导")]
    UseProps = 10,
    [LabelText("关闭玩家输入")]
    CloseInput = 11,
    [LabelText("启用玩家输入")]
    EnableInput = 12,
    [LabelText("指向目标")]
    PointTarget = 13,
    [LabelText("隐藏-指向目标")]
    HidePointTarget = 14,
    [LabelText("显示Tips目标")]
    ShowTips = 15,
    [LabelText("隐藏Tips目标")]
    HideTips = 16,
    [LabelText("停止自动移动")]
    StopMove = 17,
}

[Serializable]
public class EventConfig
{
    [LabelText("等待时间")]
    public float WaitTime = 0;
    public GuideEventType EventType = GuideEventType.Talk;
    
    [TextArea][HideLabel]
    [ShowIf("EventType",GuideEventType.Talk)]
    public string TalkString;
    [TextArea][HideLabel]
    [ShowIf("EventType",GuideEventType.ShowTips)]
    public string TipsString;
    
    [LabelText("移动到的目标List")]
    [ShowIf("EventType",GuideEventType.MoveToMultiTarget)]
    public List<PhysicObjectConfig> MoveToTargetList = new List<PhysicObjectConfig>();
    [LabelText("空气墙")]
    [ShowIf("EventType",GuideEventType.MoveToMultiTarget)]
    public PhysicObjectConfig Wall;
    
    [LabelText("指示目标")]
    [ShowIf("EventType",GuideEventType.PointTarget)]
    public List<PhysicObjectConfig> PointTargetList = new List<PhysicObjectConfig>();

    
    [LabelText("相机移动-坐标")]
    [ShowIf("EventType",GuideEventType.CameraMove)]
    public Vector3 CameraPosition;
    [LabelText("相机移动-旋转")]
    [ShowIf("EventType",GuideEventType.CameraMove)]
    public Vector3 CameraRotation;
}

[Serializable]
public class GuideConfigData
{
    [LabelText("触发类型")]
    public GuideTriggerType TriggerType = GuideTriggerType.Trigger;
    [LabelText("用于触发的物理体")]
    [ShowIf("TriggerType",GuideTriggerType.Trigger)]
    public PhysicObjectConfig TriggerObject;

    [LabelText("总时长")]
    [ShowInInspector]
    [GUIColor(0,1,1)]
    public float AllTime
    {
        get
        {
            return EventConfigs.Sum(config => config.WaitTime);
        }
    }
    
    [LabelText("事件列表")]
    public List<EventConfig> EventConfigs = new List<EventConfig>();



}


public class GuideConfig : MonoBehaviour
{
    [HideLabel]
    public GuideConfigData Data;
}
