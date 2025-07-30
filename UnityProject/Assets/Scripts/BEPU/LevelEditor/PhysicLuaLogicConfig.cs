using System;
using System.Collections.Generic;
using BEPUphysics.Constraints.TwoEntity.Motors;
using FixMath.NET;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;


public class PhysicLuaLogicConfig:MonoBehaviour
{
    private void Awake()
    {
        if (!Application.isEditor)
            Destroy(this);
    }
    
    
#if UNITY_EDITOR
    public bool ShowObjectList = true;
    //动态物体
    public List<PhysicObjectConfig> ObjectConfigList = new List<PhysicObjectConfig>();
    public bool ShowConstraintList = true;
    //约束
    public List<PhysicConstraintConfig> ConstraintConfigList = new List<PhysicConstraintConfig>();
    public bool ShowLuaList = true;

    public bool ShowOtherLogicList = false;
    //其他逻辑代码List
    public List<PhysicLuaLogicConfig> OtherLogicList = new List<PhysicLuaLogicConfig>();
    
    public LuaLogicType LuaName;
    //LuaList
    public bool ShowTips = true;
    public bool ShowString = false;
    public List<StringParameterData> StringList = new List<StringParameterData>();
    public bool ShowInt = false;
    public List<IntParameterData> IntList = new List<IntParameterData>();
    public bool ShowFix64 = false;
    public List<Fix64ParameterData> Fix64List = new List<Fix64ParameterData>();
    public bool ShowV3 = false;
    public List<V3ParameterData> V3List = new List<V3ParameterData>();
    
    private void OnDrawGizmos()
    {
        var oldcolor = Gizmos.color;
        Gizmos.color = Color.red;
        foreach (var objectConfig in ObjectConfigList)
        {
            if (objectConfig == null)
                continue;
            Gizmos.DrawLine(transform.position,objectConfig.transform.position);
        }
        foreach (var obj in ConstraintConfigList)
        {
            if (obj == null)
                continue;
            Gizmos.DrawLine(transform.position,obj.transform.position);
        }

        Gizmos.color = oldcolor;
    }
    
    
#endif


}