using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
	private StringBuilder _sbDebug = new StringBuilder();

	public const int SCENE_LAYER_ORDER = 0;

	public const int UI_LAYER_ORDER = 2000;

	public const int EFFECT_LAYER_ORDER = 4000;
	
	public const int GUIDE_LAYER_ORDER = 6000;
	
	public const int POPUP_LAYER_ORDER = 8000;
	
	public const int TOP_LAYER_ORDER = 10000;
	
	public const int MAX_LAYER_ORDER = short.MaxValue - 10000;
	
	
	// 最小屏幕高宽比, 低于此值将居中显示加黑边
	private const float SCREEN_RATIO_MIN = 1.5f;

	// 设计高宽比
	private const int REFERENCE_HEIGHT = 750;
	private const int REFERENCE_WIDTH = 1334;
	private const float REFERENCE_RATIO = REFERENCE_HEIGHT / (float)REFERENCE_WIDTH;

	/// <summary>
	/// 居中显示是否启用
	/// </summary>
	public bool CenterViewEnabled { get; private set; } = false;

	private const string PREF_SCREEN_CHANGE_NO_RESTART = "_screenChangeNoRestart";

	private bool? _screenChangeAutoRestart;

	/// <summary>
	/// 屏幕尺寸变化时自动重启
	/// </summary>
	public bool ScreenChangeAutoRestart
	{
		get
		{
			if (!_screenChangeAutoRestart.HasValue)
			{
				_screenChangeAutoRestart = PlayerPrefs.GetInt(PREF_SCREEN_CHANGE_NO_RESTART, 0) == 0;
            }
			return _screenChangeAutoRestart.Value;
		}
		set
		{
			PlayerPrefs.SetInt(PREF_SCREEN_CHANGE_NO_RESTART, value ? 0 : 1);
			_screenChangeAutoRestart = value;
		}
	}

    private static UIManager _instance;
    
    private int _frameUpdater = EquineScheduler.INVALID;  //
    private int _clickInterval = EquineScheduler.INVALID;
    public ParticleSystem clickEff = null;
    private IAsyncResourceRequest clickReq = null;
	private Vector2Int _oldScreenSize = Vector2Int.zero;
	private int _screenSizeChangeTimer = EquineScheduler.INVALID;

    public static UIManager instance
    {
		get
		{
			if (_instance == null)
			{
				throw new System.Exception("Please call Configure first");
			}
			return _instance;
		}
    }

	public static Rect cameraViewRect;

//	public static bool differentResolution = true;

//	private int _oriWidth;
//
//	private int _oriHeight;
	public static void Configure(GameObject uiManagerGo, bool enableCenterView = false)
	{
		if (_instance == null)
		{
			_instance = new UIManager();
		}
		_instance.ConfigureImpl(uiManagerGo, enableCenterView);
	}

	private void Update(int a, object b, UpdateTimeInfo c)
	{
		RepeatedClickDebug();
	}

	private const int REPEATED_CLICK_COUNT = 5;
	private const double REPEATED_CLICK_TIME = 1d;
	private Queue<double> _repeatedClickTimes = new Queue<double>();
	private PointerEventData _pointerEventData;
	List<RaycastResult> _raycastResults;

	private void RepeatedClickDebug()
	{
        // TODO
    }

    private StringBuilder _sbFullPath;
    private string GetFullPathInHierarchy(GameObject go)
    {
        _sbFullPath = _sbFullPath ?? new StringBuilder();
        _sbFullPath.Clear();
        while (go)
        {
            _sbFullPath.Insert(0, go.name);
            _sbFullPath.Insert(0, '/');
            go = go.transform.parent?.gameObject;
        }
        return _sbFullPath.ToString();
    }

    void ConfigureImpl(GameObject uiManagerGo, bool enableCenterView = false)
	{
		ScriptViewSkin uiManagerView = uiManagerGo ? uiManagerGo.GetComponent<ScriptViewSkin>() : null;
		Logger.Debug("uiManagerView " + (uiManagerView == null));
		if (!uiManagerView)
		{
			return;
		}
		uiRoot = uiManagerView.GetSingleProperty("uiRoot") as RectTransform;
		_effectLayerComponent = uiManagerView.GetSingleProperty("effectLayer") as UGUILayerComponent;
		_guideLayerComponent = uiManagerView.GetSingleProperty("guideLayer") as UGUILayerComponent;
		_popLayerComponent = uiManagerView.GetSingleProperty("popLayer") as UGUILayerComponent;
		_uiLayerComponent = uiManagerView.GetSingleProperty("uiLayer") as UGUILayerComponent;
		_sceneLayerComponent = uiManagerView.GetSingleProperty("sceneLayer") as UGUILayerComponent;
		_topLayerComponent = uiManagerView.GetSingleProperty("topLayer") as UGUILayerComponent;
		uiCamera = uiManagerView.GetSingleProperty("uiCamera") as Camera;
		_notchNode = uiManagerView.GetSingleProperty("notchNode") as GameObject;
		_uiCache = uiManagerView.GetSingleProperty("uiCache") as GameObject;
		_sideNode = uiManagerView.GetSingleProperty("sideNode") as GameObject;
		
		_notchNode?.SetActive(false);
		_sideNode?.SetActive(false);

        CenterViewEnabled = enableCenterView;
        _oldScreenSize = new Vector2Int(Screen.width, Screen.height);
#if UNITY_EDITOR
		CenterViewEnabled = true;
#endif
		if (CenterViewEnabled && ScreenChangeAutoRestart)
        {
            SetupCenterView();
		}

		UIContainer.Initialize(uiRoot, effectLayer, guideLayer, popLayer, uiLayer, topLayer, sceneLayer, uiCamera, _uiCache);

		Canvas canvas = _sceneLayerComponent.GetComponent<Canvas>();
		canvas.overrideSorting = true;
		canvas.sortingOrder = SCENE_LAYER_ORDER;
		
		canvas = _uiLayerComponent.GetComponent<Canvas>();
		canvas.overrideSorting = true;
		canvas.sortingOrder = UI_LAYER_ORDER;
		
		canvas = _effectLayerComponent.GetComponent<Canvas>();
		canvas.overrideSorting = true;
		canvas.sortingOrder = EFFECT_LAYER_ORDER;

		canvas = _guideLayerComponent.GetComponent<Canvas>();
		canvas.overrideSorting = true;
		canvas.sortingOrder = GUIDE_LAYER_ORDER;

		canvas = _popLayerComponent.GetComponent<Canvas>();
		canvas.overrideSorting = true;
		canvas.sortingOrder = POPUP_LAYER_ORDER;

		canvas = _topLayerComponent.GetComponent<Canvas>();
		canvas.overrideSorting = true;
		canvas.sortingOrder = TOP_LAYER_ORDER;

		ResetBlurCanvas();
		if (_frameUpdater != EquineScheduler.INVALID)
		{
			EquineScheduler.RemoveLimitUpdator(ref _frameUpdater);
		}
		//
		if (clickEff != null)
		{
			GameObjectPool.instance.Recycle(clickEff.transform.parent.gameObject);
			clickEff = null;
		}
		_frameUpdater = EquineScheduler.AddFrameLimitUpdator(1, Update);
		
	}


	// 设置居中显示
	// 只在屏幕高宽比低于设置值时生效
	private void SetupCenterView()
	{
		var canvas = uiRoot.GetComponent<Canvas>();
		if (!canvas)
		{
			Logger.Error("uiRoot上没有找到Canvas!");
			return;
		}

		// 重置
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		_sideNode?.SetActive(false);

		// 宽屏居中
		if (Screen.height / (float)Screen.width < SCREEN_RATIO_MIN)
        {

            // 计算UIContainer的实际大小
            var scale = Screen.height / (float)REFERENCE_HEIGHT;
			canvas.renderMode = RenderMode.WorldSpace;
			var rectTrans = canvas.transform as RectTransform;
			rectTrans.sizeDelta = new Vector2(REFERENCE_WIDTH, REFERENCE_HEIGHT);
			rectTrans.localScale *= scale;
			var width = REFERENCE_WIDTH * scale;

			// 开启黑边
            _sideNode?.SetActive(true);

			// 设置相机视口（只绘制居中部分，节省渲染压力）
			var widthRatio = width / Screen.width;
			mainCamera.rect = new Rect((1f - widthRatio) / 2f, 0, widthRatio, 1);
        }
	}

	private Dictionary<string, GameObject> _preloadCache = new Dictionary<string, GameObject>();

	/// <summary>
	/// 预载UI
	/// </summary>
	/// <param name="path"></param>
	public void PreloadUI(string path)
	{
		if (_preloadCache.ContainsKey(path)) return;
        var req = ResourceFacade.instance.LoadPrefabAsync(path);
        req.callback = request =>
        {
	        var go = request.asset as GameObject;
	        go.SetActive(false);
	        go.SetParent(_uiCache);
	        _preloadCache[path] = go;
        };
	}

	/// <summary>
	/// 是否预载了UI
	/// </summary>
	/// <param name="path"></param>
	/// <param name="go"></param>
	/// <returns></returns>
	public bool IsUIPreloaded(string path, out GameObject go)
	{
		go = null;
		if (_preloadCache.ContainsKey(path))
		{
			var cacheGo = _preloadCache[path];
			if (cacheGo)
			{
				go = cacheGo;
				return true;
			}
			else
			{
				_preloadCache.Remove(path);
			}
		}
		return false;
    }
	
	public static void AddGuideChild(GameObject child, bool autoAnchor = true)
	{
		if (child == null || instance.guideLayer)
		{
			Logger.Debug("Add Guide Child Fail!!!");
			return;
		}
		child.SetParent(instance.guideLayer);

		child.SetLocalRotation(Quaternion.identity);
		child.SetLocalScale(Vector3.one);
		child.SetLocalPosition(Vector3.one);
		
		if (autoAnchor)
		{
			RectTransform rect = child.GetComponent<RectTransform>();
			if (rect != null)
			{
				rect.anchorMin = Vector2.zero;
				rect.anchorMax = Vector2.one;
				rect.offsetMax = Vector2.zero;
				rect.offsetMin = Vector2.zero;
			}
		}
	}

	public static void AddUIChild(GameObject child, bool autoAnchor = true)
	{
		child.SetParent(instance.uiLayer);

		child.SetLocalRotation(Quaternion.identity);
		child.SetLocalScale(Vector3.one);
		child.SetLocalPosition(Vector3.one);
		
		if (autoAnchor)
		{
			RectTransform rect = child.GetComponent<RectTransform>();
			rect.anchorMin = Vector2.zero;
			rect.anchorMax = Vector2.one;
			rect.offsetMax = Vector2.zero;
			rect.offsetMin = Vector2.zero;
		}
	}

	public static void AddSceneChild(GameObject child, bool autoAnchor = true)
	{
		child.SetParent(instance.sceneLayer);

		child.SetLocalRotation(Quaternion.identity);
		child.SetLocalScale(Vector3.one);
		child.SetLocalPosition(Vector3.one);
		
		if (autoAnchor)
		{
			RectTransform rect = child.GetComponent<RectTransform>();
			rect.anchorMin = Vector2.zero;
			rect.anchorMax = Vector2.one;
			rect.offsetMax = Vector2.zero;
			rect.offsetMin = Vector2.zero;
		}
	}
	
	public static void AddTopChild(GameObject child, bool autoAnchor = true)
	{
		child.SetParent(instance.topLayer);

		child.SetLocalRotation(Quaternion.identity);
		child.SetLocalScale(Vector3.one);
		child.SetLocalPosition(Vector3.one);
		
		if (autoAnchor)
		{
			RectTransform rect = child.GetComponent<RectTransform>();
			rect.anchorMin = Vector2.zero;
			rect.anchorMax = Vector2.one;
			rect.offsetMax = Vector2.zero;
			rect.offsetMin = Vector2.zero;
		}
	}

	public void SetNotchActive(bool active = true)
	{
		// 主界面显示时不显示刘海图
		_notchNode?.SetActive(active && _mainUIVisibleCount > 0);
	}

	private static int _mainUIVisibleCount = 0;

	public static bool mainUIVisible
	{
		get { return _mainUIVisibleCount == 0; }
	}

	public static void ShowMainUI()
	{
		--_mainUIVisibleCount;
#if UNITY_EDITOR || DEBUG
		// Logger.Debug("ShowMainUI " + _mainUIVisibleCount);
#endif
		if (_mainUIVisibleCount < 0)
		{
			Debug.LogError($"ShowMainUI Count can not < 0 ({_mainUIVisibleCount})");
			_mainUIVisibleCount = 0;
		}

		if (_mainUIVisibleCount <= 0)
		{
			instance._uiLayerComponent.SetLayerVisible(true);
			instance.SetNotchActive();
			ApplicationFacade.instance.SendNotification("__after_main_ui_show");
		}
	}

	public static void HideMainUI()
	{
		if (_mainUIVisibleCount < 0)
		{
			_mainUIVisibleCount = 0;
		}
		
		if (_mainUIVisibleCount == 0)
		{
			++_mainUIVisibleCount;
			instance._uiLayerComponent.SetLayerVisible(false);
			instance.SetNotchActive();
		}
		else
		{
			++_mainUIVisibleCount;
		}
#if UNITY_EDITOR || DEBUG
		// Logger.Debug("HideMainUI " + _mainUIVisibleCount);
#endif
	}

	public static void FadeMainUI( bool fade )
	{
		var canvasGroup = instance._uiLayerComponent.gameObject.GetComponent<CanvasGroup>();
		if( canvasGroup == null )
			canvasGroup = instance._uiLayerComponent.gameObject.AddComponent<CanvasGroup>();
		canvasGroup.alpha = fade ? 0 : 1;
	}
	public static void FadeSceneLayer( bool fade )
	{
		var canvasGroup = instance._sceneLayerComponent.gameObject.GetComponent<CanvasGroup>();
		if( canvasGroup == null )
			canvasGroup = instance._sceneLayerComponent.gameObject.AddComponent<CanvasGroup>();
		canvasGroup.alpha = fade ? 0 : 1;
	}

	private static int _sceneUIVisibleCount = 0;

	public static void ShowSceneUI()
	{
#if UNITY_EDITOR
		// Logger.Debug("ShowSceneUI " + _sceneUIVisibleCount);
#endif
		--_sceneUIVisibleCount;
		if (_sceneUIVisibleCount == 0)
		{
			instance._sceneLayerComponent.SetLayerVisible(true);
		}
	}

	public static void HideSceneUI()
	{
		if (_sceneUIVisibleCount == 0)
		{
			instance._sceneLayerComponent.SetLayerVisible(false);
		}
		++_sceneUIVisibleCount;
#if UNITY_EDITOR
		// Logger.Debug("HideSceneUI " + _sceneUIVisibleCount);
#endif
	}
	
	public static void ForceShowSceneUI()
	{
#if UNITY_EDITOR
		// Logger.Debug("ForceShowSceneUI " + _sceneUIVisibleCount);
#endif
		instance._sceneLayerComponent.SetLayerVisible(true);
	}
	
	public static void RefreshSceneUIShowByVisibleCount()
	{
#if UNITY_EDITOR
		Logger.Debug("RefreshShowSceneUIByVisibleCount " + _sceneUIVisibleCount);
#endif
		if (_sceneUIVisibleCount == 0)
		{
			instance._sceneLayerComponent.SetLayerVisible(true);
		}
		else if (_sceneUIVisibleCount > 0)
		{
			instance._sceneLayerComponent.SetLayerVisible(false);
		}
		else
		{
			Logger.Error("RefreshShowSceneUIByVisibleCount _sceneUIVisibleCount can not < 0");
		}
	}
	
	private static int _mainCameraVisibleCount = 0;

	public static void ShowMainCameraForOneFrame()
	{
		instance.mainCamera.enabled = true;
		if (instance.uiCamera.clearFlags != CameraClearFlags.Depth)
		{
			instance.uiCamera.clearFlags = CameraClearFlags.Depth;
		}
		EquineScheduler.CallOnceFrame(30, (i, o, arg3) =>
			{
				
				instance.mainCamera.enabled = false;
				if (instance.uiCamera.clearFlags != CameraClearFlags.Depth)
				{
					instance.uiCamera.clearFlags = CameraClearFlags.Depth;
				}
			}
		);
	}

	public static void ShowMainCamera()
	{
#if UNITY_EDITOR
		// Logger.Debug("ShowMainCamera " + _mainCameraVisibleCount);
#endif
		--_mainCameraVisibleCount;
		if (_mainCameraVisibleCount == 0)
		{
			instance.mainCamera.enabled = true;
			if (instance.uiCamera.clearFlags != CameraClearFlags.Depth)
			{
				instance.uiCamera.clearFlags = CameraClearFlags.Depth;
			}
		}
	}

	public static void HideMainCamera()
	{
		if (_mainCameraVisibleCount == 0)
		{
			instance.mainCamera.enabled = false;

			if (instance.uiCamera.clearFlags != CameraClearFlags.SolidColor)
			{
				instance.uiCamera.clearFlags = CameraClearFlags.SolidColor;
				instance.uiCamera.backgroundColor = Color.black;
			}
		}
		++_mainCameraVisibleCount;
#if UNITY_EDITOR
		// Logger.Debug("HideMainCamera " + _mainCameraVisibleCount);
#endif
	}

	public static void ForceShowMainCamera()
	{
		instance.mainCamera.enabled = true;
		if (instance.uiCamera.clearFlags != CameraClearFlags.Depth)
		{
			instance.uiCamera.clearFlags = CameraClearFlags.Depth;
		}
	}
	
	public static void RefreshMainCameraStateByVisibleCount()
	{
		if (_mainCameraVisibleCount == 0)
		{
			instance.mainCamera.enabled = true;
			if (instance.uiCamera.clearFlags != CameraClearFlags.Depth)
			{
				instance.uiCamera.clearFlags = CameraClearFlags.Depth;
			}
		}
		else if(_mainCameraVisibleCount > 0)
		{
			instance.mainCamera.enabled = false;

			if (instance.uiCamera.clearFlags != CameraClearFlags.SolidColor)
			{
				instance.uiCamera.clearFlags = CameraClearFlags.SolidColor;
				instance.uiCamera.backgroundColor = Color.black;
			}
		}
		else
		{
#if UNITY_EDITOR
			Logger.Error("_mainCameraVisibleCount can not < 0 ");
#endif
		}
	}

	public static void ResetMainCamera()
	{
		_mainCameraVisibleCount = 0;
		instance.mainCamera.enabled = true;
		if (instance.uiCamera.clearFlags != CameraClearFlags.Depth)
		{
			instance.uiCamera.clearFlags = CameraClearFlags.Depth;
		}
	}

	private static int _popUIVisibleCount = 0;

	public static void ShowPopUI()
	{
#if UNITY_EDITOR
		Logger.Debug("ShowPopUI " + _popUIVisibleCount);
#endif
		--_popUIVisibleCount;
		if (_popUIVisibleCount == 0)
		{
			instance._popLayerComponent.SetLayerVisible(true);
//			instance.popLayer.SetAnchor(instance.uiRoot.gameObject);
		}
	}

	public static void HidePopUI()
	{
		if (_popUIVisibleCount == 0)
		{
//			instance.popLayer.SetAnchor((GameObject)null);
			instance._popLayerComponent.SetLayerVisible(false);
		}
		++_popUIVisibleCount;
#if UNITY_EDITOR
		Logger.Debug("HidePopUI " + _popUIVisibleCount);
#endif
	}

	public static void HideTopResourceBar()
	{
		instance._popLayerComponent.transform.Find("TopInfoArea").gameObject.SetActive(false);
	}

	public static void ShowTopResourceBar()
	{
		instance._popLayerComponent.transform.Find("TopInfoArea").gameObject.SetActive(true);
	}

	public static void ResetSceneUIVisible()
	{
		_sceneUIVisibleCount = 0;
		instance._sceneLayerComponent.SetLayerVisible(true);
	}

	public static void ResetPopUIVisible()
	{
		_popUIVisibleCount = 0;
		instance._popLayerComponent.SetLayerVisible(true);
//		instance.popLayer.SetAnchor(instance.uiRoot.gameObject);
	}

	public static void ResetMainUIVisible()
	{
		_mainUIVisibleCount = 0;
		instance._sceneLayerComponent.SetLayerVisible(true);
//		instance.uiLayer.SetAnchor(instance.uiRoot.gameObject);
	}

	public RectTransform effectLayer
	{
		get
		{
			return _effectLayerComponent.rect;
		}
	}

	public RectTransform guideLayer
	{
		get
		{
			return _guideLayerComponent.rect;
		}
	}

	public RectTransform popLayer
	{
		get
		{
			return _popLayerComponent.rect;
		}
	}

	public RectTransform uiLayer
	{
		get
		{
			return _uiLayerComponent.rect;
		}
	}

	public RectTransform sceneLayer
	{
		get
		{
			return _sceneLayerComponent.rect;
		}
	}
	
	public RectTransform topLayer
	{
		get
		{
			return _topLayerComponent.rect;
		}
	}

    public RectTransform uiRoot;

	public Camera uiCamera;

	private Camera _mainCamera;
	
	private UGUILayerComponent _effectLayerComponent;

	private UGUILayerComponent _guideLayerComponent;

	private UGUILayerComponent _popLayerComponent;

	private UGUILayerComponent _uiLayerComponent;

	private UGUILayerComponent _sceneLayerComponent;
	
	private UGUILayerComponent _topLayerComponent;
	
	private GameObject _notchNode;

	private GameObject _uiCache;

	private GameObject _sideNode;
	
	public Camera mainCamera
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
	}

	#region BlurBack & PawnShowSpace

	public void SetBlurMaskCanvasHide(bool hide)
	{
		for (int i = 0; i < popLayer.childCount; i++)
		{
			var pop = popLayer.GetChild(i);
			if (pop != null)
			{
				var popName = pop.gameObject.name;
				if (popName.StartsWith("BlurMaskPanel") || popName.StartsWith("MaskPanel"))
				{
					var canvas = pop.GetComponent<Canvas>();
					if (canvas != null && canvas.sortingOrder != 0)
					{
						canvas.enabled = !hide;
					}
				}
			}
		}
	}
	
	// TODO
	// add pawn show space

	public static string BLUR_FRAME_BUFFER_RID = "BlurFrameBuffer";
	private BlurFrameBuffer _blurFrameBuffer = null;
	private ResourceReleaseFacade.ResourceToken _blurFrameBufferToken = null;

	
	private List<Canvas> _blurBlackList = new List<Canvas>();
	private List<Canvas> _blurWhiteList = new List<Canvas>();

	public List<Canvas> blurWhiteList => _blurWhiteList;
	public void SetNoBlur(Canvas canvas)
	{
		if (!_blurBlackList.Contains(canvas))
		{
			_blurBlackList.Add(canvas);
		}
	}
	public void SetOnlyBlur(Canvas canvas)
	{
		if (!_blurWhiteList.Contains(canvas))
		{
			_blurWhiteList.Add(canvas);
		}
	}
	public void ClearOnlyBlur()
	{
		_blurWhiteList.Clear();
	}
	
	public void HideNoBlurCanvas()
	{
		for (int i = 0; i < _blurBlackList.Count; i++)
		{
			_blurBlackList[i].enabled = false;
		}
	}
	public void ResetBlurCanvas()
	{
		for (int i = 0; i < _blurBlackList.Count; i++)
		{
			_blurBlackList[i].enabled = true;
		}
		_blurBlackList.Clear();
	}
	public void ShowNoBlurCanvas()
	{
		for (int i = 0; i < _blurBlackList.Count; i++)
		{
			_blurBlackList[i].enabled = true;
		}
	}
	public BlurFrameBuffer AcquireBlurBack()
	{
		if (_blurFrameBufferToken != null)
		{
			_blurFrameBuffer = ResourceReleaseFacade.instance.Acquire(_blurFrameBufferToken) as BlurFrameBuffer;
			// _blurFrameBuffer?.ResetTexture();
			_blurFrameBufferToken = null;
		}
		else if (_blurFrameBuffer == null)
		{
			_blurFrameBuffer = new BlurFrameBuffer();
			_blurFrameBuffer.Load();
		}

		return _blurFrameBuffer;
	}

	public void DisposeBlurBack()
	{
		if (_blurFrameBuffer != null)
		{
			_blurFrameBuffer.ClearCallback();
			_blurFrameBuffer.ClearCache();
			_blurFrameBufferToken = ResourceReleaseFacade.instance.Recycle(_blurFrameBuffer, ReleaseBlurBackBuffer);
			_blurFrameBuffer = null;
		}
	}

	private void ReleaseBlurBackBuffer(IResourceUnit unit, ResourceReleaseFacade.ResourceToken token)
	{
		var blurFrameBuffer = unit as BlurFrameBuffer;
		blurFrameBuffer?.Dispose();
		_blurFrameBufferToken = null;
	}

	public void CleanBlurBackBuffer()
	{
		if (_blurFrameBuffer != null)
		{
			_blurFrameBuffer?.Dispose();
		}
		_blurFrameBufferToken = null;
		_blurFrameBuffer = null;
	}
	
    /// <summary>
    /// 设置模糊隐藏
    /// </summary>
    /// <param name="hide"></param>
    /// <param name="targetUI"></param>

	public static void SetBlurMaskCanvasHide(bool hide, GameObject targetUI = null)
	{
		var popRoot = UIManager.instance.popLayer.transform;
		for (int i = 0; i < popRoot.childCount; i++)
		{
			var pop = popRoot.GetChild(i);
			if (pop != null)
			{
				var popName = pop.gameObject.name;
				if (popName.StartsWith("BlurMaskPanel") || popName.StartsWith("MaskPanel"))
				{
					var canvas = pop.GetComponent<Canvas>();
					if (canvas != null && canvas.sortingOrder != 0)
					{
						canvas.enabled = !hide;
					}
				}
			}
		}
		
		var selfCanvas = targetUI != null ? targetUI.GetComponent<Canvas>() : null;
		if (selfCanvas != null)
		{
			if (hide)
			{
				UIManager.instance.SetOnlyBlur(selfCanvas);
			}
			else
			{
				UIManager.instance.ClearOnlyBlur();
			} 
		}
	}
	#endregion
}