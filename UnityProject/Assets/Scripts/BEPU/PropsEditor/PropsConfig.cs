using System;
using System.Collections;
using System.Collections.Generic;
using FixMath.NET;
using UnityEngine;




[Serializable]
[CreateAssetMenu(menuName = "Props/NewProps")]
public class PropsConfig : ScriptableObject
{
    public int PropsId = 1;
    public string Icon;
    public string Name = "道具名字";
    public string Desc = "道具介绍";
    public List<PropsEffectGroupConfig> EffectGroups = new List<PropsEffectGroupConfig>();
}

[Serializable]
public class PropsEffectGroupConfig
{
    public List<TriggerData> TriggerList = new List<TriggerData>();
    public List<FilterData> FilterList = new List<FilterData>();
    public List<EffectData> EffectList = new List<EffectData>();
}

[Serializable]
public class PropsEffectData
{
    public List<IntParameter> IntParameters = new List<IntParameter>();
    public List<FloatParameter> FloatParameters = new List<FloatParameter>();
    public List<Vector2Parameter> Vector2Parameters = new List<Vector2Parameter>();
    public List<Vector3Parameter> Vector3Parameters = new List<Vector3Parameter>();
    public List<BoolParameter> BoolParameters = new List<BoolParameter>();
    public List<StringParameter> StringParameters = new List<StringParameter>();
}

[Serializable]
public class TriggerData:PropsEffectData
{
    public TriggerTypes Trigger = TriggerTypes.Active;
}
[Serializable]
public class FilterData:PropsEffectData
{
    public FilterTypes Filter = FilterTypes.None;
}
[Serializable]
public class EffectData:PropsEffectData
{
    public EffectTypes Effect = EffectTypes.ThrowObject;
}
public enum TriggerTypes
{
    [Alias("空")]
    None = 0,
    [Alias("主动")]
    Active = 1,
    [Alias("定时器")]
    Timer = 2,
    [Alias("添加时")]
    OnAdd = 3,
    [Alias("销毁时")]
    OnRemove = 4,
}
public enum FilterTypes
{
    [Alias("空")]
    None = 0,
    [Alias("通过")]
    Pass = 1,
    [Alias("冷却")]
    CoolDown = 2,
    [Alias("不予通过")]
    DontPass = 3,
}
public enum EffectTypes
{
    [Alias("空")]
    None = 0,
    [Alias("投掷物/Test")]
    ThrowObject = 1,
    [Alias("投掷物/炸弹")]
    Bomb = 2,
    [Alias("投掷物/烟雾弹")]
    Smoke = 3,
    [Alias("投掷物/放置Buff陷阱")]
    BananaPeel = 4,
    [Alias("投掷物/Buff炸弹")]
    BuffBomb = 5,
    [Alias("投掷物/Buff飞镖")]
    Darts = 6,
    [Alias("Buff/体积变化")]
    BodySize = 7,
    [Alias("Buff/加速")]
    SpeedUp = 8,
    [Alias("Buff/失重")]
    GravityHood = 9,
    [Alias("Buff/弹力")]
    BouncinessHood = 10,
    [Alias("删除道具")]
    RemoveProps = 11,
    [Alias("Buff/冰冻")]
    Frozen = 12,
    [Alias("View/特效")]
    ViewFx = 13,
    [Alias("Buff/滑倒")]
    SlipFall = 14,
    [Alias("View/瞄准线")]
    AimLine = 15,
    [Alias("添加Buff-给自身")]
    AddBuff = 16,
    // [Alias("Auto投掷物/放置Buff陷阱")]
    // AutoBananaPeel = 17,
}

public enum PropsParameterTypes
{
    Int = 1,
    Float = 2,
    Vector3 = 3,
    Vector2 = 4,
    Bool = 5,
    String = 6,
}


[Serializable]
public class ParameterBase
{
    public string Name = "参数名";
}

[Serializable]
public class IntParameter:ParameterBase
{
    public int Value;
}
[Serializable]
public class FloatParameter:ParameterBase
{
    public Fix64 Value;
}
[Serializable]
public class BoolParameter:ParameterBase
{
    public bool Value;
}
[Serializable]
public class Vector2Parameter:ParameterBase
{
    public BEPUutilities.Vector2 Value;
}
[Serializable]
public class Vector3Parameter:ParameterBase
{
    public BEPUutilities.Vector3 Value;
}
[Serializable]
public class StringParameter:ParameterBase
{
    public string Value;
}






