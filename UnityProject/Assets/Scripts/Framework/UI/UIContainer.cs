using UnityEngine;

public class UIContainer
{
    public static Transform effectLayer;

    public static Transform guideLayer;

    public static Transform popLayer;

    public static Transform uiLayer;

    public static Transform sceneLayer;
    
    public static Transform topLayer;

    public static Transform uiRoot;

    public static Camera uiCamera;

    public static GameObject uiCache;

    private static Camera _mainCamera;

    public static Camera mainCamera
    {
        get
        {
            if (!_mainCamera)
            {
                _mainCamera = Camera.main;
                if (_mainCamera == null)
                {
                    _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
                }
            }
            return _mainCamera;
        }
        set
        {
            _mainCamera = value;
        }
    }

    public static void Initialize(Transform root, Transform effect, Transform guide, Transform pop, Transform flatui, Transform top,Transform scene, Camera uiCam, GameObject cache)
    {
        uiRoot = root;
        effectLayer = effect;
        guideLayer = guide;
        popLayer = pop;
        uiLayer = flatui;
        topLayer = top;
        sceneLayer = scene;
        uiCamera = uiCam;
        uiCache = cache;
    }
}
