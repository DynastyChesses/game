using System;
using System.Collections.Generic;
using BEPUphysics.Constraints.TwoEntity.Motors;
using FixMath.NET;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;

public class PhysicConstraintConfig:MonoBehaviour
{
    
    private void Awake()
    {
        if (!Application.isEditor)
            Destroy(this);
    }
    
#if UNITY_EDITOR
    
    public ConstraintType ConstraintType = ConstraintType.RevoluteJoint;
    public Vector3 CenterOffset;
    public Vector3 RotateAxis;
    public PhysicObjectConfig EntityA;
    public PhysicObjectConfig EntityB;

    public bool UseLimit = false;
    public Fix64 Minimum = 0m;
    public Fix64 Maximum = 1m;
    
    
    public bool UseMotor = true;
    public MotorMode MotorMode = MotorMode.VelocityMotor;
    public Fix64 MaxForce = 1000m;
    public Fix64 GoalValue = 1m;

    // public string LuaScript;
    // public bool ShowParameterList;
    // public List<ScriptParameter> ParameterList = new List<ScriptParameter>();
    
    private void OnDrawGizmos()
    {
        switch (ConstraintType)
        {
            case ConstraintType.RevoluteJoint:
                DrawRevoluteJoint();
                break;
            case ConstraintType.PrismaticJoint:
                DrawPrismaticJoint();
                break;
            case ConstraintType.UniversalJoint:
                DrawUniversalJoint();
                break;
            case ConstraintType.WeldJoint:
                //焊接 无需
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawRevoluteJoint()
    {
        if (EntityB == null)
            return;
        
        var pos = EntityA != null ? EntityA.transform.position : EntityB.transform.position;
        var color = Gizmos.color;
        var matrix = Gizmos.matrix;
        Gizmos.color = Color.green;
        var gizmosPos = pos + (UnityEngine.Vector3)(CenterOffset);
        var axis = RotateAxis;// * (BEPUutilities.Quaternion) this.transform.rotation;
        Gizmos.matrix = Matrix4x4.TRS(gizmosPos, 
            Quaternion.LookRotation((UnityEngine.Vector3)(axis)), 
            UnityEngine.Vector3.one);
        Gizmos.DrawCube(UnityEngine.Vector3.zero, new UnityEngine.Vector3(0.05f,0.05f,10f));
        Gizmos.color = color;
        Gizmos.matrix = matrix;
    }
    private void DrawPrismaticJoint()
    {
        if (EntityB == null)
            return;
        var entity = EntityA != null ? EntityA : EntityB;
        var pos = entity.transform.position;
        var axis = RotateAxis;// * (BEPUutilities.Quaternion)entity.transform.rotation;
        var color = Gizmos.color;
        var matrix = Gizmos.matrix;
        Gizmos.color = Color.green;
        var gizmosPos = pos + (UnityEngine.Vector3)(CenterOffset);
        Gizmos.matrix = Matrix4x4.TRS(gizmosPos, Quaternion.LookRotation((UnityEngine.Vector3)(axis)), UnityEngine.Vector3.one);
        Gizmos.DrawCube(UnityEngine.Vector3.zero, new UnityEngine.Vector3(0.05f,0.05f,10f));
        Gizmos.color = color;
        Gizmos.matrix = matrix;
    }
    private void DrawUniversalJoint()
    {
        if (EntityB == null)
            return;
        var entity = EntityA != null ? EntityA : EntityB;
        var pos = entity.transform.position;
        var axis = RotateAxis;// * (BEPUutilities.Quaternion)entity.transform.rotation;
        var color = Gizmos.color;
        var matrix = Gizmos.matrix;
        Gizmos.color = Color.green;
        var gizmosPos = pos + (UnityEngine.Vector3)(CenterOffset);
        Gizmos.matrix = Matrix4x4.TRS(gizmosPos, Quaternion.LookRotation((UnityEngine.Vector3)(axis)), UnityEngine.Vector3.one);
        Gizmos.DrawCube(UnityEngine.Vector3.zero, new UnityEngine.Vector3(0.05f,0.05f,10f));
        Gizmos.DrawCube(UnityEngine.Vector3.zero, new UnityEngine.Vector3(0.05f,10f,0.05f));
        Gizmos.DrawCube(UnityEngine.Vector3.zero, new UnityEngine.Vector3(10f,0.05f,0.05f));
        Gizmos.color = color;
        Gizmos.matrix = matrix;
    }
    
    
#endif
    
    
}