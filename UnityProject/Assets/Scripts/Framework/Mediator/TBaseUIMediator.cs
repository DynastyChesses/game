using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TBaseUIMediator<T> : BaseUIMediator where T : BaseGamePopupView
{
	private T __view = null;
	protected T _view => __view ?? (__view = _baseView as T);
	
	private UIPanelConfig _uiConfig = null;
	private Dictionary<int, SubViewMediator> _subViewMediators = new Dictionary<int, SubViewMediator>();
	protected SubViewMediator _currentSubViewMediator = null;
	protected bool _multiSubView => _uiConfig.multiSubView;
	
	private string viewMediatorName = null;

	protected TBaseUIMediator(string mediatorName, string showNotification, string hideNotification = null) : base(mediatorName, showNotification, hideNotification)
	{
		if (_uiConfig == null)
		{
			_uiConfig = UIConfig.instance.GetPanelConfig(MediatorName);
		}

		viewMediatorName = mediatorName;
	}

	protected override void OnClearBaseView()
	{
		__view = null;
	}

	public override void OnRegister()
	{
		base.OnRegister();
		// Sub
	}
	
	public override void OnRemove()
	{
		base.OnRemove();
		// var it = _subViewMediators.GetEnumerator();
		// while (it.MoveNext())
		// {
		// 	var value = it.Current.Value;
		// 	Facade.RemoveMediator(value.MediatorName);
		// }
		_subViewMediators.Clear();
		
	}

	protected override void BeforeViewDispose()
	{
		base.BeforeViewDispose();
		
		var it = _subViewMediators.GetEnumerator();
		while (it.MoveNext())
		{
			var value = it.Current.Value;
			if (value.isActive)
			{
				value.HideView();
			}
			value.Dispose();
		}
		it.Dispose();
	}

	protected sealed override void OnDispose()
	{
		__view = null;
	}

	protected override string GetUIPrefabPath(object data)
	{
		return _uiConfig.panelPath;
	}

	protected override BaseGamePopupView CreateView(GameObject prefab, object data)
	{
		if (prefab.activeSelf == false)
		{
			prefab.SetActive(true);
		}

		try
		{
			_baseView = (T) Activator.CreateInstance(typeof(T), new object[] {prefab});
			_baseView.uiConfig = _uiConfig;
		}
		catch (Exception e)
		{
			Debug.LogError($"BaseGamePopupView CreateView {prefab.name} : {e.Message}");
		}

		OnCreateView(data);

		return _baseView;
	}

	protected virtual void OnCreateView(object data)
	{
		
	}

	protected override int GetLayer()
	{
		return _uiConfig.uiLayer;
	}

	protected override uint GetPopupMode()
	{
		return _uiConfig.popupMode;
	}
	
	protected override bool GetIsFullScreen()
	{
		return _uiConfig.isFullScreen;
	}
	
	protected override Dictionary<uint, object> GetParamDic(object data)
	{
		Dictionary<uint, object> paramDic = new Dictionary<uint, object>();
		if ((_uiConfig.popupMode & PopupMode.ADD_TOP_RESOURCE_VIEW) != 0)
		{
			paramDic.Add(PopupMode.ADD_TOP_RESOURCE_VIEW, _uiConfig.topInfoMode);
		}

		if ((_uiConfig.popupMode & PopupMode.AUTO_HIDE) != 0)
		{
			paramDic.Add(PopupMode.AUTO_HIDE, _uiConfig.autoHideTime);
		}

		return paramDic;
	}

	protected void HideSubView(int type)
	{
		SubViewMediator subMediator;
		if(_subViewMediators.TryGetValue(type, out subMediator))
		{
			if (subMediator.isActive)
			{
				subMediator.HideView();
				if (_currentSubViewMediator == subMediator)
				{
					_currentSubViewMediator = null;
				}
			}
		}
	}

    protected void ShowSubView(int type, GameObject container, object data = null, bool preload = false)
	{
		// TODO
	}

	protected override void BeforeShowView()
	{
		base.BeforeShowView();
		
		var it = _subViewMediators.GetEnumerator();
		while (it.MoveNext())
		{
			var value = it.Current.Value;
			value.BeforeShowBaseView();
		}
		it.Dispose();
	}

	protected override void AfterShowView()
	{
		base.AfterShowView();
		
		var it = _subViewMediators.GetEnumerator();
		while (it.MoveNext())
		{
			var value = it.Current.Value;
			value.AfterShowBaseView();
		}
		it.Dispose();
	}

	protected override void BeforeHideView()
	{
		base.BeforeHideView();
		
		var it = _subViewMediators.GetEnumerator();
		while (it.MoveNext())
		{
			var value = it.Current.Value;
			value.BeforeHideBaseView();
		}
		it.Dispose();
		
		_currentSubViewMediator = null;
	}

	protected override void AfterHideView()
	{
		base.AfterHideView();
		
		var it = _subViewMediators.GetEnumerator();
		while (it.MoveNext())
		{
			var value = it.Current.Value;
			value.AfterHideBaseView();
			if (value.isActive)
			{
				value.HideView();
			}
		}
		it.Dispose();
	}

	protected override void PlayReturnButtonClickSound(GameObject button)
	{
		// TODO
	}
}