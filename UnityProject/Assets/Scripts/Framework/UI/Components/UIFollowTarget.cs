using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Attaching this script to an object will make it visibly follow another object, even if the two are using different cameras to draw them.
/// </summary>

public class UIFollowTarget : MonoBehaviour
{
	/// <summary>
	/// 3D target that this object will be positioned above.
	/// </summary>

	public Transform target;

	/// <summary>
	/// Game camera to use.
	/// </summary>

	public Camera gameCamera;

	/// <summary>
	/// UI camera to use.
	/// </summary>

	public Camera uiCamera;

	/// <summary>
	/// Whether the children will be disabled when this object is no longer visible.
	/// </summary>

	public bool disableIfInvisible = true;

	public enum DisableMethod
	{
		Inactive = 0,			// go.setactive(false), 会很重，但能关闭更新
		InvisableLayer = 1,		// 设置为"Invisiable"的layer，需要有canvas才能控制显隐，适合没有更新的情况
	}

	public DisableMethod disableMethod = DisableMethod.Inactive;
	protected static int _invisableLayerIndex = -1;
	protected int _orignalLayer;

	
	public bool scaleFollowCameraHeight = false;	// 默认是false，向前兼容
	public float standardCameraHeightOnScale = 25f;
	protected Vector3 _OriginScale = Vector3.one;

	[Obsolete("废弃，使用offsetUIValue")]
	public int offsetX
	{
		get => (int)_offsetUIValue.x;
		set => _offsetUIValue.x = value;
	}
	[Obsolete("废弃，使用offsetUIValue")]
	public int offsetY
	{
		get => (int)_offsetUIValue.y;
		set => _offsetUIValue.y = value;
	}

	protected Vector3 _offsetWorldValue = Vector3.zero;
	public Vector3 offsetWorldValue
	{
		get => _offsetWorldValue;
		set => _offsetWorldValue = value;
	}

	protected Vector3 _offsetUIValue = Vector3.zero;
	public  Vector3 offsetUIValue
	{
		get => _offsetUIValue;
		set => _offsetUIValue = value;
	}

	protected Transform mTrans;
	protected bool mIsVisible = true;

	public bool visible
	{
		get { return mIsVisible; }
	}

	protected static Camera _defaultUICamera;
	protected static Camera _defaultMainCamera;

	public static void ConfigureCamera(Camera uiCamera, Camera mainCamera = null)
	{
		_defaultUICamera = uiCamera;
		_defaultMainCamera = mainCamera;
	}

	protected bool mHasInit = false;

    public void ForceUpdate()
    {
        if(!mHasInit)
        {
            Awake();
            Start();
        }
        LateUpdate();
    }

    /// <summary>
    /// Cache the transform;
    /// </summary>
    protected void Awake()
    {
	    mTrans = transform;
	    _invisableLayerIndex = LayerMask.NameToLayer("DONT_SHOW");
    }

	/// <summary>
	/// Find both the UI camera and the game camera so they can be used for the position calculations
	/// </summary>
	protected void Start()
	{
		if (!mHasInit)
		{
			mHasInit = true;
			if (target != null)
			{
				if (gameCamera == null) 
				{
					if (!_defaultMainCamera)
					{
						_defaultMainCamera = Camera.main;
						if (_defaultMainCamera == null)
						{
							_defaultMainCamera = GameObject.FindWithTag("MainCamera")?.GetComponent<Camera>();
						}
					}
					gameCamera = _defaultMainCamera;
				}
				if (uiCamera == null) 
				{
					if (!_defaultUICamera)
					{
						var uicgo = GameObject.Find("UICamera");
						_defaultUICamera = uicgo ? uicgo.GetComponent<Camera>() : null;
					}
					uiCamera = _defaultUICamera;
				}
				SetVisible(false);
			}
			else
			{
				Debug.LogError("Expected to have 'target' set to a valid transform", this);
				enabled = false;
			}

			RectTransform rect = gameObject.GetComponent<RectTransform>();
			if (rect != null)
			{
				if (rect.anchorMin != _halfOne || rect.anchorMax != _halfOne)
				{
					Debug.LogError("This RectTransform has Anchors", this);
					enabled = false;
				}
			}

			_OriginScale = mTrans.localScale;
		}
	}

	protected void OnEnable()
	{
		// 外部逻辑可能设置本UI节点及子节点的active，position等属性
		// 为了防止mIsVisible为false、target在屏幕外、UI节点在屏幕内时不刷新的问题，需要初始化IsVisible为true
        //mIsVisible = true;
        SetVisible(true);
	}

	protected Vector2 _halfOne = new Vector2(0.5f,0.5f);

	/// <summary>
	/// Enable or disable child objects.
	/// </summary>
	public void SetVisible (bool val)
	{
		mIsVisible = val;
#if UNITY_EDITOR
		if (mTrans.childCount > 1)
		{
			Debug.Log($"实际子节点不能直接放在使用该组件的根节点下,需要增加一个二级节点！！, {mTrans.name}");
		}
#endif
		if (disableMethod == DisableMethod.Inactive)
		{
			for (int i = 0, imax = mTrans.childCount; i < imax; ++i)
			{
				mTrans.GetChild(i).gameObject.SetActive(val);
			}
		}
		else
		{
			if (val == false && _orignalLayer != transform.gameObject.layer)
				_orignalLayer = transform.gameObject.layer;
		}
	}

	protected static int _matrixCacheFrameIndex;
	protected static Matrix4x4 _matrixWorld2UI;	// 世界坐标转换到UI坐标系
	protected static Bounds _uiBounds;	// 可见ui的范围
	protected bool _UsePerfOpt = true;

	protected void CreateWorld2UIMatrix()
	{
		if (!_UsePerfOpt)
			return;
		
		if (_matrixCacheFrameIndex != Time.frameCount)
		{
			_matrixCacheFrameIndex = Time.frameCount;
			// 小游戏平台上WorldToViewportPoint和ViewportToWorldPoint会取屏幕宽高，额外费时所以缓存矩阵来优化
			// 理论上应该用toViewport或toScreen矩阵，先用project，可能透视相机存在问题
			// todo，换用更简单的矩阵构造方式
			_matrixWorld2UI = gameCamera.projectionMatrix * gameCamera.worldToCameraMatrix;

			// 居中显示变换矩阵
			Matrix4x4 mat = Matrix4x4.identity;
			mat.m00 = gameCamera.rect.width;
			mat.m11 = gameCamera.rect.height;
			_matrixWorld2UI = mat * _matrixWorld2UI;

			_matrixWorld2UI = uiCamera.cameraToWorldMatrix * uiCamera.projectionMatrix.inverse * _matrixWorld2UI;


            Vector2 min = uiCamera.ViewportToWorldPoint(gameCamera.rect.min);
			Vector2 max = uiCamera.ViewportToWorldPoint(gameCamera.rect.max);
            _uiBounds.SetMinMax(min, max);
		}
	}
	/// <summary>
	/// Update the position of the HUD object every frame such that is position correctly over top of its real world object.
	/// </summary>
	protected void LateUpdate ()	
	{
		if (target == null)
		{
			Debug.LogError(this.gameObject + " " + this.mTrans.parent);
			this.enabled = false;
			return;
		}
		CreateWorld2UIMatrix();

		Vector3 pos;
		if (_UsePerfOpt)
		{
			pos = _matrixWorld2UI.MultiplyPoint3x4(target.position + _offsetWorldValue);
            pos.z = 0;
		}
		else
		{
			pos = gameCamera.WorldToViewportPoint(target.position + _offsetWorldValue);
			pos.x *= gameCamera.rect.width;
			pos.x += gameCamera.rect.x;
			pos.y *= gameCamera.rect.height;
			pos.y += gameCamera.rect.y;
		}
		

		// Determine the visibility and the target alpha
		bool isVisible;
		if (_UsePerfOpt)
			isVisible = target.gameObject.activeInHierarchy && (gameCamera.orthographic || pos.z > 0f) && 
		                 (!disableIfInvisible || _uiBounds.Contains(pos));
		else
			isVisible = target.gameObject.activeInHierarchy && (gameCamera.orthographic || pos.z > 0f) && 
				(!disableIfInvisible || (pos.x > gameCamera.rect.min.x && pos.x < gameCamera.rect.max.x && pos.y > gameCamera.rect.min.y && pos.y < gameCamera.rect.max.y));

		// Update the visibility flag
		if (mIsVisible != isVisible)
			SetVisible(isVisible);
			
		// If visible, update the position
		if (isVisible)
		{
			if (_UsePerfOpt)
			{
				Vector3 s = transform.lossyScale;
				pos += new Vector3(offsetUIValue.x * s.x, offsetUIValue.y * s.y, _offsetUIValue.z * s.z);
				pos.z = 0f;
				if ((transform.position - pos).sqrMagnitude > 1e-6)	// 让很大值可以用粗略精度判等
					transform.position = pos;
			}
			else
			{
				transform.position = uiCamera.ViewportToWorldPoint(pos);
				// Vector3 t = _matrixWorld2UI.MultiplyPoint3x4(target.position + _offsetWorldValue);
				pos = mTrans.localPosition;
				pos = pos + offsetUIValue;
				pos.z = 0f;
				transform.localPosition = pos;
			}
			if (scaleFollowCameraHeight)
			{
				bool isOrthographic = gameCamera.orthographic;
				float curCameraScaleValue = isOrthographic ? gameCamera.orthographicSize : gameCamera.transform.localPosition.y;
				var curScale = standardCameraHeightOnScale / curCameraScaleValue;
				Vector3 newScale = _OriginScale * curScale;
				if (mTrans.localScale != newScale)
					mTrans.localScale = _OriginScale * curScale;
			}
		}
		OnUpdate(isVisible);
	}

	/// <summary>
	/// Custom update function.
	/// </summary>

	protected virtual void OnUpdate (bool isVisible) { }
}
