using System;
using System.Collections;
using System.Collections.Generic;

public interface IPopupFacade
{
    /// <summary>
    /// 判断面板是否正在显示
    /// </summary>
    /// <returns>如果面板正在显示返回<c>true</c>; 否则返回<c>false</c>.</returns>
    /// <param name="view">弹窗实例.</param>
    /// <param name="includeHiding">是否包括正在消失中的面板</param>
	bool HasPopup(IPopupView view, bool includeHiding = true);

	/// <summary>
	/// 是否有弹出的面板
	/// </summary>
	/// <returns></returns>
	bool HasAnyPopup();
	
	/// <summary>
	/// 弹出面板的数量
	/// </summary>
	/// <returns></returns>
	int GetPopupCount();

	/// <summary>
	/// 判断面板是不是正在消失中
	/// </summary>
	/// <param name="view">弹窗实例</param>
	/// <returns></returns>
	bool IsHiding(IPopupView view);

	/// <summary>
    /// 强制移除掉正在消失的面板(有的面板只有一个实例，并且有打开和关闭动画，所以如果正隐藏的过程中再次弹出，就需要调用这个方法，先强制把正在消失的面板移除）
	/// </summary>
	/// <param name="view">弹窗实例</param>
	/// <param name="withExitNotify">是否需要发送AfterExit通知</param>
	void ForceRemoveHidingPanel(IPopupView view, bool withExitNotify = false);

	/// <summary>
	/// 创建并展示一个面板。面板会被缓存，因此该方法可重复调用。
	/// </summary>
	/// <param name="view">弹窗实例.</param>
	/// <param name="popupMode">模式标识.</param>
	/// <param name="queueMode">队列标识.</param>
	/// <param name="paramDic">参数字典.</param>
	/// <param name="popupLayer">弹出层索引.</param>
	void AddPopup(IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null,
		int popupLayer = -1, PopupQueueMode queueMode = PopupQueueMode.QueueBack, bool isFullScreen = false);
	
	void RefreshPopup(IPopupView view, uint popupMode, Dictionary<uint, object> paramDic = null,
		int popupLayer = -1);

	/// <summary>
	/// 移除一个已知面板。
	/// </summary>
	/// <param name="view">面板.</param>
	/// <param name="removeNow">是否立即移除</param>
	void RemovePopup(
		IPopupView view, 
		bool removeNow = false
		);

	/// <summary>
	/// 移除所有已添加面板。
	/// </summary>
	void RemoveAllPopup(uint removeMode = PopupRemoveMode.DEFAULT, bool clearScene = false);

	void Clear();

	bool IsTopView(IPopupView view);
	
	//界面放到最底下一些主界面类似的HUD
	void ManageMainUI(IPopupView view);
	void ResetManageMainUI();
	void SetViewShow(IPopupView view, bool show);
	
	void Stash();
	void StashPop();
	void HideViewBelow(IPopupView targetView);
	void ShowAllView();
	bool IsMainUIManaged();
	
	IPopupView GetTopView();

	bool CloseTopView(IPopupView except = null);

	void RefreshPopupAction(IPopupView view, uint popupMode, object actionParam);
	void RefreshPopupParam(IPopupView view, uint popupMode, object actionParam);
}

