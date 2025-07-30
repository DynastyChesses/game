public enum PhysicObjectType
{
    Dynamic = 0,//动态
    Static = 1,//静态
}
public enum PhysicDynamicObjectType
{
    DynamicMesh = 0,//动态网格
    CompoundBody = 1,//联合体
    
    Box = 2,//盒子
    Capsule = 3,//胶囊
    Cone = 4,//圆锥
    Cylinder = 5,//圆柱
    Sphere = 6,//球形
    Triangle = 7,//三角形
}
public enum PhysicStaticObjectType
{
    StaticMesh = 0,//静态网格
    StaticGroup = 1,//静态形状组
}

//形状类型
public enum PhysicShapeType
{
    Box = 0,//盒子
    Capsule = 1,//胶囊
    Cone = 2,//圆锥
    ConvexHull = 3,//自定义顶点凸包,TODO 未完成
    Cylinder = 4,//圆柱
    Sphere = 5,//球形
    Triangle = 6,//三角形
    Mesh = 7,
}

public enum PhysicLayer
{
    Default = 0,
    Static = 1,
    Dynamic = 2,
    Role = 3,
    WinnerPrison = 4,
}
















