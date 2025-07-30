using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Simulation;
// using Spine.Unity.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = BEPUutilities.Vector3;

public partial class PhysicConfigWindow:EditorWindow
{
    [MenuItem("Tools/PhysicConfigWindow")]

    static void Init()
    {
        PhysicConfigWindow myWindow = (PhysicConfigWindow)EditorWindow.GetWindow(typeof(PhysicConfigWindow), false, "物理配置", false);
        myWindow.Show(true);
        myWindow.GetPhysicObject();
        if (PlayerPrefs.HasKey("LevelConfigPath"))
        {
            myWindow.JsonFilePath = PlayerPrefs.GetString("LevelConfigPath");
        }
        if (PlayerPrefs.HasKey("LevelConfigName"))
        {
            myWindow.JsonFileName = PlayerPrefs.GetString("LevelConfigName");
        }
        if (PlayerPrefs.HasKey("PhysicErrorCheck"))
        {
            myWindow.ErrorCheck = PlayerPrefs.GetInt("PhysicErrorCheck") == 1;
        }

    }

    private void OnCloseScene(Scene scene)
    {
        GetPhysicObject();
    }
    private void OnOpenScene(Scene scene, OpenSceneMode mode)
    {
        GetPhysicObject();
        JsonFileName = scene.name;
    }
    private void OnEnable()
    {
        EditorSceneManager.sceneClosed += OnCloseScene;
        EditorSceneManager.sceneOpened += OnOpenScene;
        GetPhysicObject();
        switch (currentWindowType)
        {
            case WindowType.PhysicObject:
                OnShowPhysicObjectWindow();
                break;
            case WindowType.PhysicConstraint:
                OnShowPhysicConstraintWindow();
                break;
            case WindowType.MeshData:
                OnShowMeshDataWindow();
                break;
        }
    }

    private void OnDisable()
    {
        EditorSceneManager.sceneClosed -= OnCloseScene;
        EditorSceneManager.sceneOpened -= OnOpenScene;
    }

    private void Update()
    {
        UpdateConstraintWindow();
    }

    private StartPointConfig[] allStartPoints;
    private PhysicObjectConfig[] allPhysicObject;
    private PhysicConstraintConfig[] allPhysicConstraint;
    private PhysicLuaLogicConfig[] allLuaLogic;
    private CameraPathConfig[] allCameraPath;
    private LevelRulesConfig levelRulesConfig;
    private GuideConfig[] allGuidConfig;
    private bool showLogic;

    private Dictionary<PhysicObjectType, List<PhysicObjectConfig>> allPhysicConfig = new Dictionary<PhysicObjectType, List<PhysicObjectConfig>>();
    private Dictionary<PhysicDynamicObjectType, List<PhysicObjectConfig>> dynamicObjects = new Dictionary<PhysicDynamicObjectType, List<PhysicObjectConfig>>();
    private Dictionary<PhysicStaticObjectType, List<PhysicObjectConfig>> staticObjects = new Dictionary<PhysicStaticObjectType, List<PhysicObjectConfig>>();
    private void GetPhysicObject()
    {
        allStartPoints = GameObject.FindObjectsOfType<StartPointConfig>();
        allPhysicObject = GameObject.FindObjectsOfType<PhysicObjectConfig>();
        allPhysicConstraint = GameObject.FindObjectsOfType<PhysicConstraintConfig>();
        allLuaLogic = GameObject.FindObjectsOfType<PhysicLuaLogicConfig>();
        allCameraPath = GameObject.FindObjectsOfType<CameraPathConfig>();
        var rulesArr = GameObject.FindObjectsOfType<LevelRulesConfig>();
        if (rulesArr.Length > 0)
            levelRulesConfig = rulesArr[0];
        dynamicObjects.Clear();
        staticObjects.Clear();
        allPhysicConfig.Clear();
        allPhysicConfig.Add(PhysicObjectType.Dynamic,new List<PhysicObjectConfig>());
        allPhysicConfig.Add(PhysicObjectType.Static,new List<PhysicObjectConfig>());
        foreach (PhysicObjectConfig objectConfig in allPhysicObject)
        {
            allPhysicConfig[objectConfig.ObjectType].Add(objectConfig);
            switch (objectConfig.ObjectType)
            {
                case PhysicObjectType.Dynamic:
                    if (!dynamicObjects.ContainsKey(objectConfig.DynamicObjectType))
                        dynamicObjects.Add(objectConfig.DynamicObjectType,new List<PhysicObjectConfig>());
                    dynamicObjects[objectConfig.DynamicObjectType].Add(objectConfig);
                    break;
                case PhysicObjectType.Static:
                    if (!staticObjects.ContainsKey(objectConfig.StaticObjectType))
                        staticObjects.Add(objectConfig.StaticObjectType,new List<PhysicObjectConfig>());
                    staticObjects[objectConfig.StaticObjectType].Add(objectConfig);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }

    private enum WindowType
    {
        PhysicObject,
        PhysicConstraint,
        MeshData,
    }

    public bool ErrorCheck = true;
    public string JsonFilePath = "/Game/playguys/LevelConfig/";
    public string JsonFileName = "Level.json";
    private WindowType currentWindowType = WindowType.PhysicObject;
    private void OnGUI()
    {
        Color oldColor = GUI.color;
        if (GUILayout.Button("刷新Physic"))
        {
            GetPhysicObject();
        }
        EditorGUILayout.Space();
        
        GUILayout.BeginHorizontal("box");
        if (currentWindowType == WindowType.PhysicObject)
            GUI.color = Color.green;
        if (GUILayout.Button("物体"))
        {
            currentWindowType = WindowType.PhysicObject;
            OnShowPhysicObjectWindow();
        }
        GUI.color = oldColor;
        
        if (currentWindowType == WindowType.PhysicConstraint)
            GUI.color = Color.green;
        if (GUILayout.Button("约束"))
        {
            currentWindowType = WindowType.PhysicConstraint;
            OnShowPhysicConstraintWindow();
        }
        GUI.color = oldColor;
        
        if (currentWindowType == WindowType.MeshData)
            GUI.color = Color.green;
        if (GUILayout.Button("Mesh网格"))
        {
            currentWindowType = WindowType.MeshData;
            OnShowMeshDataWindow();
        }
        GUI.color = oldColor;
        
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();

        switch (currentWindowType)
        {
            case WindowType.PhysicObject:
                DrawPhysicObjectWindow();
                break;
            case WindowType.PhysicConstraint:
                DrawPhysicConstraintWindow();
                break;
            case WindowType.MeshData:
                DrawMeshData();
                break;
        }
        

        GUI.color = oldColor;
    }

    
    
}