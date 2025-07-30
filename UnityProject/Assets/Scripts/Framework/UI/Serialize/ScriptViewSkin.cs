using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public class ScriptViewSkin : MonoBehaviour
{

	public enum ExportType
	{
		Normal,
		Popup,
		ItemRenderer
	}

	[System.Serializable]
	public class SkinSingleProperty
	{
		public string propName;
        public Object propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
		public bool generateScript = true;
	}

	[System.Serializable]
	public class SkinMultipleProperty
	{
		public string propName;
		public Object[] propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
        public bool generateScript = true;
	}

	//TODO 下次强更时删掉
	public UIEventListener.VoidDelegate onClick;
	public UIEventListener.FloatDelegate onScroll;
	public UIEventListener.PointerEventDataDelegate onDrag;
	public UIEventListener.PointerEventDataDelegate onDragBegin;
	public UIEventListener.PointerEventDataDelegate onDragEnd;

	[NonSerialized]
	public bool messageDisabled = false;

	private void OnEnable()
	{
		if (!messageDisabled)
		{
			UIEventListener.OnClick(gameObject).AddListener(OnClick);
			UIEventListener.OnDragBegin(gameObject).AddListener(OnDragBegin);
			UIEventListener.OnDrag(gameObject).AddListener(OnDrag);
			UIEventListener.OnDragEnd(gameObject).AddListener(OnDragEnd);
		}
	}

	private void OnDragBegin(GameObject go, PointerEventData data)
	{
		if (onDragBegin != null)
		{
			onDragBegin(go,data);
		}
	}

	private void OnDrag(GameObject go, PointerEventData data)
	{
		if (onDrag != null)
		{
			onDrag(go,data);
		}
	}

	private void OnDragEnd(GameObject go, PointerEventData data)
	{
		if (onDragEnd != null)
		{
			onDragEnd(go,data);
		}
	}

	private void OnDisable()
	{
		UIEventListener.OnClick(gameObject).RemoveListener(OnClick);
		UIEventListener.OnDragBegin(gameObject).RemoveListener(OnDragBegin);
		UIEventListener.OnDrag(gameObject).RemoveListener(OnDrag);
		UIEventListener.OnDragEnd(gameObject).RemoveListener(OnDragEnd);
	}

	void OnClick(GameObject go)
	{
		if (onClick != null)
		{
			onClick(go);
		}
	}

	// void OnPress(bool isPressed)
	// {
	// 	if (isColliderEnabled && onPress != null)
	// 		onPress(gameObject, isPressed);
	// }
	//
	// void OnScroll(float delta)
	// {
	// 	if (isColliderEnabled && onScroll != null)
	// 		onScroll(gameObject, delta);
	// }
	//
	// void OnDrag(Vector2 delta)
	// {
	// 	if (onDrag != null)
	// 		onDrag(gameObject, delta);
	// }

#if !UNITY_EDITOR
		[NonSerialized]
#endif
	public string exportId;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
	public string exportPath;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
	public ExportType exportType;

	public List<SkinSingleProperty> singlePropList;

	public List<SkinMultipleProperty> multiplePropList;

	public Object GetSingleProperty(string propName, int predicateIndex = -1)
	{
		int singleLen = singlePropList != null ? singlePropList.Count : 0;
		//由于外部基本是自动生成代码，可以通过生成代码传入的预测索引加速获取
		if (predicateIndex >= 0 && predicateIndex < singleLen && singlePropList[predicateIndex].propName == propName)
		{
			return singlePropList[predicateIndex].propVal;
		}
		for (int i = 0; i < singleLen; ++i)
		{
			if (singlePropList[i].propName == propName)
			{
				return singlePropList[i].propVal;
			}
		}
		return null;
	}

#if UNITY_EDITOR
	public bool HasSingleProperty(string propName, int predicateIndex = -1)
	{
		int singleLen = singlePropList != null ? singlePropList.Count : 0;
		//由于外部基本是自动生成代码，可以通过生成代码传入的预测索引加速获取
		if (predicateIndex >= 0 && predicateIndex < singleLen && singlePropList[predicateIndex].propName == propName)
		{
			return true;
		}
		for (int i = 0; i < singleLen; ++i)
		{
			if (singlePropList[i].propName == propName)
			{
				return true;
			}
		}
		return false;
	}
#endif

	public Object[] GetMultipleProperty(string propName, out int length, int predicateIndex = -1)
	{
		int multiLen = multiplePropList != null ? multiplePropList.Count : 0;
		Object[] propVal = null;
		if (predicateIndex >= 0 && predicateIndex < multiLen && multiplePropList[predicateIndex].propName == propName)
		{
			propVal = multiplePropList[predicateIndex].propVal;
		}
		if (propVal == null)
		{
			for (int i = 0; i < multiLen; ++i)
			{
				if (multiplePropList[i].propName == propName)
				{
					propVal = multiplePropList[i].propVal;
					break;
				}
			}
		}

		length = propVal != null ? propVal.Length : 0;

		return propVal;
	}

	private void OnDestroy()
	{
		onClick = null;
		onDrag = null;
		onScroll = null;
		onDragBegin = null;
		onDragEnd = null;
	}
}
