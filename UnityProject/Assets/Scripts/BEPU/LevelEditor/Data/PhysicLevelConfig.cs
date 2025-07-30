using System;
using System.Collections.Generic;
using BEPUphysics.Constraints.TwoEntity.Motors;
using BEPUphysics.PositionUpdating;
using BEPUutilities;
using FixMath.NET;

#region 新手引导

[Serializable]
public struct GuideEventConfig
{
    public float WaitTime;
    public GuideEventType EventType;
    public string TalkString;
    public List<int> MoveToTargetList;
    public int Wall;//空气墙
    public List<int> PointTargetList;
    public UnityEngine.Vector3 CameraPosition;
    public UnityEngine.Vector3 CameraRotation;
}
[Serializable]
public struct LevelGuideConfigData
{
    public int Id;
    public GuideTriggerType TriggerType;
    public int TriggerObject;
    public List<GuideEventConfig> EventConfigs;
}
[Serializable]
public struct LevelGuideData
{
    public List<LevelGuideConfigData> GuideConfigDataList;
}

    #endregion


[Serializable]
public struct PhysicLevelConfig
{
    public LevelRulesData LevelRulesData;
    public List<StartPointData> StartPoints;
    public List<ObjectConfig> PhysicObjectConfigList;
    public List<ConstraintConfig> ConstraintConfigList;
    public List<LuaLogicConfig> LuaLogicConfigList;
    public List<Vector3> CameraPath;
    public List<Vector3> CameraTargetPath;
    public LevelGuideData LevelGuideData;
}

[Serializable]
public struct LevelRulesData
{
    public string LevelName;
    public string LevelDesc;
    public string LevelTargetDesc;
    public LevelModelTypes LevelModel;
    public BEPUutilities.Vector3 Gravity ;
    public Fix64 PlayerMoveSpeed ;
    public Fix64 PlayerAirSpeed ;
    public Fix64 PlayerJumpSpeed;
    public DeadRules DeadRules;
    // public VictoryRules VictoryRules;
    public List<OverCheckerData> OverCheckerDataList ;
}

[Serializable]
public struct ObjectConfig
{
    //通用信息
    public int Id;//Prefab Id
    public string PrefabName;//可以为空，为空不加载。
    public TransformData Transform;
    public PhysicLayer PhysicLayer;
    public PhysicObjectType ObjectType;
    public PhysicDynamicObjectType DynamicType;
    public PhysicStaticObjectType StaticType;
    public string MeshName;
    public bool IsUseOffset;//偏移
    public Vector3 PositionOffset;
    public Quaternion RotationOffset;
    public Vector3 Size;
    
    public List<BepuPhysicShapeData> ShapeDataList;
    //动态物体
    public Fix64 Mass;
    public bool CustomizeMaterial;//自定义材质
    public Fix64 KineticFriction;//动摩擦
    public Fix64 StaticFriction;//静摩擦
    public Fix64 Bounciness;//弹性
    public PositionUpdateMode UpdateMode;
    public bool IsTrigger;
    public bool IsUseIndependentGravity;
    public Vector3 Gravity;
    
    // public string LuaScript;
    // public List<LuaScriptParameter> ParameterList;
}

public enum ConstraintType
{
    RevoluteJoint = 1,
    PrismaticJoint = 2,
    UniversalJoint = 3,
    WeldJoint = 4,
}

[Serializable]
public struct ConstraintConfig
{
    public int Id;
    public ConstraintType ConstraintType;
    
    public Vector3 CenterOffset;
    public Vector3 RotateAxis;
    public int EntityAId;
    public int EntityBId;
    
    public bool UseLimit;
    public Fix64 Minimum;
    public Fix64 Maximum;
    
    public bool UseMotor;
    public MotorMode MotorMode;
    public Fix64 MaxForce;
    public Fix64 GoalValue;
    
    // public string LuaScript;
    // public List<LuaScriptParameter> ParameterList;
}


[Serializable]
public struct LuaLogicConfig
{
    public int Id;
    public List<int> EntityIdList;
    public List<int> ConstraintIdList;
    public List<int> LuaLogicIdList;

    public string LuaName;
    public List<StringParameterData> StringParameterList;
    public List<IntParameterData> IntParameterList;
    public List<Fix64ParameterData> Fix64ParameterList;
    public List<V3ParameterData> V3ParameterList;
}

[Serializable]
public class StringParameterData
{
    public string Name;
    public string Value;
}

[Serializable]
public class IntParameterData
{
    public string Name;
    public int Value;
}

[Serializable]
public class Fix64ParameterData
{
    public string Name;
    public Fix64 Value;
}
[Serializable]
public class V3ParameterData
{
    public string Name;
    public Vector3 Value;
}



[Serializable]
public struct TransformData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;
}
[Serializable]
public struct StartPointData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public int Index;
}

[Serializable]
public struct MeshData
{
    public int Id;
    public string MeshName;
    public Vector3[] Vertices;
    public int[] Indices;
}

[Serializable]
public struct BepuPhysicShapeData
{
    public PhysicShapeType ShapeType;
    public Fix64 MassWeight;
    public Vector3 LocalPosition;
    public Vector3 Rotation;
    public Vector3 Scale;
    public string MeshName;
}

[Serializable]
public struct LuaScriptParameter
{
    public string Name;
    public Fix64 Value;
}



public enum LuaLogicType
{
    [Alias("空")]
    None = 0,
    [Alias("区域检测/检查点")]
    CheckPoint = 1,
    [Alias("区域检测/胜利区域")]
    WinnerBox = 2,
    [Alias("大炮")]
    Cannon = 3,
    [Alias("传送带")]
    Conveyor = 4,
    [Alias("区域检测/死亡区域")]
    DeadBox = 5,
    [Alias("约束/吊桥")]
    Drawbridge = 6,
    [Alias("玩家跌倒")]
    FallDown = 7,
    [Alias("路径移动")]
    PathMove = 8,
    [Alias("约束/钟摆")]
    Pendulum = 9,
    [Alias("约束/轨道")]
    Track = 10,
    [Alias("蹦床")]
    Trampoline = 11,
    [Alias("周期消失地板")]
    VanishFloor = 12,
    [Alias("风")]
    WindZone = 13,
    [Alias("陷阱地砖/地砖")]
    TrapFloor = 14,
    [Alias("陷阱地砖/地砖Group")]
    TrapFloorGroup = 15,
    [Alias("Level4/广告牌")]
    Billboard = 16,
    [Alias("Level4/广告牌地板")]
    BillboardFloor = 17,
    [Alias("Level4/广告牌控制器")]
    BillboardController = 18,
    [Alias("道具盒")]
    PropsBox = 19,
    [Alias("Level7/翻转地板")]
    Level7FlipFloor = 20,
    [Alias("Level9/翻转地板")]
    Level9FlipFloor = 21,
    [Alias("Level9/星星")]
    Star = 22,
    [Alias("Level9/随机星星")]
    Level9RandomStar = 23,
    [Alias("涂色地板")]
    Dyed = 24,
    [Alias("果酱")]
    Jam = 25,
    [Alias("自定义事件")]
    CustomizeEvents = 26,
    [Alias("开关桥")]
    SwitchBridge = 27,
    [Alias("复活")]
    ObjectResurrection = 28,
    [Alias("训练/推球训练")]
    PushBallTraining = 29,
    [Alias("训练/消失地板")]
    TrainVanishFloor = 30,
    [Alias("训练/消失地板控制器")]
    TrainVanishFloorController = 31,
    [Alias("训练/投掷道具")]
    PropsTraining = 32,
    [Alias("相机/自动相机")]
    AutoCamera = 33,
    [Alias("足球")]
    Football = 34,
    [Alias("踩踏陷阱地板")]
    TramplingTrapFloor = 35,
    [Alias("约束/加速旋转")]
    AcceleratedRotation = 36,
    [Alias("道具/被锁定目标")]
    PropTarget = 37,
    [Alias("角速度")]
    AngularVelocity = 38,
}

public class AliasAttribute : Attribute
{
    public string Name;
    public AliasAttribute(string name)
    {
        Name = name;
    }
}

