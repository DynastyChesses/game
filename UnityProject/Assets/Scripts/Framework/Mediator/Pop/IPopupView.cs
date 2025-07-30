using System;
using UnityEngine;

public interface IPopupView
{
	int popupId
	{
		get;
	}

	string name
	{
		get;
	}

	bool isValid
	{
		get;
	}

	bool maskInteractive
	{
		get;
		set;
	}

	Action onMaskClick
	{
		get;
		set;
	}

	Transform parent
	{
		get;
		set;
	}

	bool visible
	{
		get;
		set;
	}

	bool visibleInHierarchy
	{
		get;
	}

	Vector3 localPosition
	{
		get;
		set;
	}

	Quaternion localRotation
	{
		get;
		set;
	}

	Vector3 localScale
	{
		get;
		set;
	}

	int depth
	{
		get;
		set;
	}

	BasePopupAnimation popupAnimation
	{
		get;
	}

	uint removeAllFlag
	{
		get;
	}

	void ResetTransform();
	void Dispose();
	void BeforeEnter();
	void AfterEnter();
	void BeforeExit();
	void AfterExit();
	
	// first enter
	void ShowViewAndRefresh();
	void ShowViewAndNoRefresh();

	void MoveToSky(bool toSky);
}