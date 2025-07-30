using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 面板队列模式
/// </summary>
public enum PopupQueueMode
{
	/// 新面板不排队
	NoQueue,
	/// 新面板排至队尾
	QueueBack,
	/// 新面板排至队头
	QueueFront,
	/// 新面板排至队头，并立即展示。旧面板隐藏，排至队头。
	QueueFrontShow,
}

public enum PopupAnimationType
{
	All = 0,
	OpenOnly,
	CloseOnly
}

public class PopupParamKey
{
	/// <summary>
	/// 用于设置FlyingPopupAnimation的动画目标
	/// </summary>
	public const uint CUSTOM_ANIMATION_TARGET = 100;
}

public class PopupConfig
{
	// public const int INITIALIZE_POPUP_DEPTH = 9999;

	public const int INITIALIZE_POPUP_Z = 5100;

	// public const int DEPTH_LAYER_GAP = 1000;

	public const int DEPTH_INCREMENT = 10;
	//
	// public const int Z_INCREMENT = -1500;
}

public class PopupRemoveMode
{
	public const uint FORCE = 0xFFFFFFFF;
	public const uint DEFAULT = 0x00000001;
	public const uint TOP_LAYER = 0x00000002;
}