using System;
using UnityEngine;
using UnityEngine.UI;

public class MaskContext:IResourceUnit
{
	public RectTransform rect;
	public GameObject clickArea;
	public bool clickable;
	public Image maskImage;
	public RawImage rawImageBg;
	public RawImage rawImageBgCache;
	
	public bool isFullScreen = false;
	public IPopupView view;

	public GameObject gameObject;

	public Canvas canvas;
	

	private Transform _trans;
	private Action<GameObject, MaskContext> _clickHandler;
	
	public MaskContext(GameObject maskCtxGo, Action<GameObject, MaskContext> clickHandler)
	{
		Initialize(maskCtxGo.GetComponent<ScriptViewSkin>(), clickHandler);
	}

	protected virtual ScriptViewSkin Initialize(ScriptViewSkin maskCtxView, Action<GameObject, MaskContext> clickHandler)
    {
		_trans = maskCtxView.transform;
		gameObject = maskCtxView.gameObject;
		rect = maskCtxView.GetSingleProperty("rect") as RectTransform;
		clickArea = maskCtxView.GetSingleProperty("clickArea") as GameObject;
		rawImageBg = maskCtxView.GetSingleProperty("rawImageBg") as RawImage;
		maskImage = maskCtxView.GetSingleProperty("maskImage") as Image;
		rawImageBgCache = maskCtxView.GetSingleProperty("rawImageBgCache") as RawImage;

		// 居中显示支持
		var mainCamera = UIManager.instance.mainCamera;
        rawImageBg.transform.localScale = Vector3.one;
		if (rawImageBgCache) rawImageBgCache.transform.localScale = Vector3.one;
		if (mainCamera.rect.width < 1f || mainCamera.rect.height < 1f)
		{
			rawImageBg.transform.localScale = new Vector3(1f / mainCamera.rect.width, 1f / mainCamera.rect.height, 1);
			if (rawImageBgCache) rawImageBgCache.transform.localScale = rawImageBg.transform.localScale;
        }
		
		canvas = gameObject.GetComponent<Canvas>();
		if (canvas == null)
		{
			canvas = gameObject.AddComponent<Canvas>();
		}

		GraphicRaycaster raycaster = gameObject.GetComponent<GraphicRaycaster>();
		if (raycaster == null)
		{
			raycaster = gameObject.AddComponent<GraphicRaycaster>();
			raycaster.ignoreReversedGraphics = true;
		}

		canvas.overrideSorting = true;
		_clickHandler = clickHandler;
		return maskCtxView;
	}

	public string resId;

	public string id
	{
		get
		{
			return resId;
		}
	}

	public Transform cachedTransform
	{
		get
		{
			return this._trans;
		}
	}

	public void OnMaskClickProxy(GameObject go)
	{
		if (_clickHandler != null)
		{
			_clickHandler(go, this);
		}
	}

	public void Dispose()
	{
		this.DoDispose();
		_clickHandler = null;
		if (gameObject != null)
		{
			ResourceFacade.instance.Unload(gameObject);
			gameObject = null;
		}
		_trans = null;
		clickArea = null;
		view = null;
	}

	protected virtual void DoDispose()
    {
		
    }
}
