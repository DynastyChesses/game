using System;
using System.Collections.Generic;
using BEPUphysics.PositionUpdating;
using UnityEditor;
using UnityEngine;

public class PhysicObjectConfig : MonoBehaviour
{
    private void Awake()
    {
        if (!Application.isEditor)
            Destroy(this);
    }

    
#if UNITY_EDITOR


    [ContextMenu("GetMeshSize")]
    void GetMeshSize()
    {
        var mesh = transform.GetComponentInChildren<MeshFilter>();
        if (mesh == null)
            return;
        var aa = mesh.transform.localRotation * mesh.sharedMesh.bounds.size;
        Size = (BEPUutilities.Vector3)aa;
        Debug.Log(aa);
    }
    
    [ContextMenu("6X6")]
    void AutoCopy ()
    {
        bool isThis = true;

        var prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(gameObject);
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (isThis)
                {
                    isThis = false;
                    continue;
                }
                var newObj = (GameObject)PrefabUtility.InstantiatePrefab(prefab, this.transform.parent);
                newObj.name = $"{i}-{j}";
                newObj.transform.position = transform.position + new Vector3(10f * j, 0, 10f * i);
            }
        }
        Debug.Log("自动生成6X6");
    }
    
    //Debug....
    public bool IsShowDebug => PlayerPrefs.GetInt("PhysicDebug") == 1;
    public bool IsDrawWire => PlayerPrefs.GetInt("PhysicWire") == 1;
    public Color Color = Color.white;

    public bool IsShowFix64Info
    {
        get
        {
            return PlayerPrefs.GetInt("IsShowFix64Info") == 1;
        }
        set
        {
            PlayerPrefs.SetInt("IsShowFix64Info",value?1:0);
        }
    }
    public bool IsShowShapeDataList = true;
    
    
    //Config...
    public PhysicLayer PhysicLayer;
    public PhysicObjectType ObjectType;
    public PhysicDynamicObjectType DynamicObjectType = PhysicDynamicObjectType.Box;
    public PhysicStaticObjectType StaticObjectType;
    public bool IsTrigger = false;
    public float Mass = 1;
    public bool CustomizeMaterial = true;//自定义材质
    public float KineticFriction = 0f;//动摩擦
    public float StaticFriction = 0f;//静摩擦
    public float Bounciness = 0f;//弹性
    public PositionUpdateMode UpdateMode;//位置更新方式
    public bool IsUseIndependentGravity = false;//是否使用独立重力
    public BEPUutilities.Vector3 Gravity = new BEPUutilities.Vector3(0,-9.81m,0);//当前实体的独立引力
    
    public bool IsUseOffset = true;
    public Mesh Mesh;
    public List<PhysicShapeData> ShapeDataList = new List<PhysicShapeData>();

    public BEPUutilities.Vector3 PositionOffset = BEPUutilities.Vector3.Zero;
    public BEPUutilities.Vector3 RotationOffset = BEPUutilities.Vector3.Zero;
    public BEPUutilities.Vector3 Size = new BEPUutilities.Vector3(0,0,0);
    
    
    //待定。。。
    public string PrefabName;
    // public string LuaScript;//Lua备注，用于给Lua侧信息。
    // public bool ShowParameterList;
    // public List<ScriptParameter> ParameterList = new List<ScriptParameter>();
    
    private void OnDrawGizmos()
    {
        if (!IsShowDebug)
            return;

        switch (ObjectType)
        {
            case PhysicObjectType.Dynamic:
                DrawDynamic();
                break;
            case PhysicObjectType.Static:
                DrawStatic();
                break;
        }
    }

    private void DrawDynamic()
    {
        var size = (UnityEngine.Vector3)(Size);
        switch (DynamicObjectType)
        {
            case PhysicDynamicObjectType.DynamicMesh:
                DrawMesh();
                break;
            case PhysicDynamicObjectType.CompoundBody:
                DrawShapeGizmos();
                break;
            case PhysicDynamicObjectType.Box:
                DrawBox();
                break;
            case PhysicDynamicObjectType.Capsule:
                GizmosTool.DrawCapsule(transform.position, transform.rotation, transform.lossyScale,size.y,size.x);
                break;
            case PhysicDynamicObjectType.Cone:
                GizmosTool.DrawCone(transform.position, transform.rotation, transform.lossyScale,size.y,size.x);
                break;
            case PhysicDynamicObjectType.Cylinder:
                GizmosTool.DrawCylinder(transform.position, transform.rotation, transform.lossyScale,size.y,size.x);
                break;
            case PhysicDynamicObjectType.Sphere:
                DrawSphere();
                break;
            case PhysicDynamicObjectType.Triangle:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawBox()
    {
        var oldColor = Gizmos.color;
        var oldMatrix = Gizmos.matrix;
        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        
        var size = (UnityEngine.Vector3)(Size);
        size = new Vector3(size.x , size.y, size.z);
        if (IsDrawWire)
            Gizmos.DrawWireCube(UnityEngine.Vector3.zero,size);
        else
            Gizmos.DrawCube(UnityEngine.Vector3.zero,size);
        
        Gizmos.matrix = oldMatrix;
        Gizmos.color = oldColor;
    }
    private void DrawSphere()
    {
        var oldColor = Gizmos.color;
        var oldMatrix = Gizmos.matrix;
        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        
        var size = (UnityEngine.Vector3)(Size);
        size = new Vector3(size.x , size.y, size.z);
        if (IsDrawWire)
            Gizmos.DrawWireSphere(UnityEngine.Vector3.zero,size.x );
        else
            Gizmos.DrawSphere(UnityEngine.Vector3.zero,size.x );
        
        Gizmos.matrix = oldMatrix;
        Gizmos.color = oldColor;
    }
    private void DrawStatic()
    {
        switch (StaticObjectType)
        {
            case PhysicStaticObjectType.StaticMesh:
                DrawMesh();
                break;
            case PhysicStaticObjectType.StaticGroup:
                DrawShapeGizmos();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void DrawShapeGizmos()
    {
        var oldColor = Gizmos.color;
        var oldMatrix = Gizmos.matrix;
        //Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.color = Color.green;
        foreach (PhysicShapeData shapeData in ShapeDataList)
        {
            var localPos = (UnityEngine.Vector3) shapeData.LocalPosition;
            localPos = new Vector3(
                localPos.x * transform.lossyScale.x,
                localPos.y * transform.lossyScale.y, 
                localPos.z * transform.lossyScale.z);
            localPos = transform.rotation * localPos;
            var pos = transform.position +  localPos;

            var localRotation = (UnityEngine.Vector3) (shapeData.Rotation);
            Gizmos.matrix = Matrix4x4.TRS(pos, 
                transform.rotation * Quaternion.Euler(localRotation), 
                transform.lossyScale);
            switch (shapeData.ShapeType)
            {
                case PhysicShapeType.Box:
                    if (IsDrawWire)
                        Gizmos.DrawWireCube(Vector3.zero, (UnityEngine.Vector3)(shapeData.Scale));
                    else
                        Gizmos.DrawCube(Vector3.zero, (UnityEngine.Vector3)(shapeData.Scale));
                    break;
                case PhysicShapeType.Capsule:
                    GizmosTool.DrawCapsule(Vector3.zero, Quaternion.identity,
                        (UnityEngine.Vector3)shapeData.Scale,
                        1,1);
                    break;
                case PhysicShapeType.Cone:
                    GizmosTool.DrawCone(Vector3.zero, Quaternion.identity,
                        (UnityEngine.Vector3)shapeData.Scale,
                        1,1);
                    break;
                case PhysicShapeType.ConvexHull:
                    break;
                case PhysicShapeType.Cylinder:
                    GizmosTool.DrawCylinder(Vector3.zero, Quaternion.identity,
                        (UnityEngine.Vector3)shapeData.Scale,
                        1,1);
                    break;
                case PhysicShapeType.Sphere:
                    var size = (UnityEngine.Vector3)(shapeData.Scale);
                    if (IsDrawWire)
                        Gizmos.DrawWireSphere(UnityEngine.Vector3.zero,size.x );
                    else
                        Gizmos.DrawSphere(UnityEngine.Vector3.zero,size.x );
                    break;
                case PhysicShapeType.Triangle:
                    break;
                case PhysicShapeType.Mesh:
                    GizmosTool.DrawMesh(shapeData.Mesh);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        Gizmos.matrix = oldMatrix;
        Gizmos.color = oldColor;
    }
    private void DrawMesh()
    {
        if (Mesh == null)
            return;
        
        var oldColor = Gizmos.color;
        var oldMatrix = Gizmos.matrix;
        if (IsUseOffset)
        {
            var posOffset = (UnityEngine.Vector3)(PositionOffset);
            var rotOffset = (UnityEngine.Vector3)(RotationOffset);
            var rotation = transform.rotation * Quaternion.Euler(rotOffset);
            posOffset = transform.rotation * posOffset;
            Gizmos.matrix = Matrix4x4.TRS(transform.position+posOffset, rotation, transform.lossyScale);
        }
        else
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        }
        GizmosTool.DrawMesh(this.Mesh);
        Gizmos.matrix = oldMatrix;
    }
    
    
    
    
    
    
#endif



}
