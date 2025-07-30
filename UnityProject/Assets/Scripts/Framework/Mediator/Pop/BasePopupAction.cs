using UnityEngine;

public abstract class BasePopupAction
{
	public BasePopupAction (uint popupMode)
	{
		mode = popupMode;
	}

	public uint mode 
	{ 
		get; 
		protected set; 
	}

	public IPopupFacade popupManagerDelegate
	{
		get;
		set;
	}

    public virtual void ExecuteBeforeShow(Transform popupRoot, IPopupView view, PopupParam popupParam)
	{}
	
	public virtual void ExecuteAfterShow(Transform popupRoot, IPopupView view, PopupParam popupParam)
	{}

    public virtual void ExecuteBeforeHide(Transform popupRoot, IPopupView view, PopupParam popupParam)
	{}
	
	public virtual void ExecuteAfterHide(Transform popupRoot, IPopupView view, PopupParam popupParam)
	{}

	public virtual void Refresh(IPopupView view, PopupParam popupParam)
	{}
	public virtual void ClearAction(bool cleanScene)
	{}
}

public abstract class CommonUIWidget
{
	protected int _orderOffset { get; private set; }

	public CommonUIWidget(uint popupMode, int orderOffset)
	{
		mode = popupMode;
		_orderOffset = orderOffset;
	}

	public uint mode { get; private set; }

	public IPopupFacade popupManagerDelegate { get; set; }

	public virtual void Refresh(PopupParam popupParam,bool cleanScene = false) { }
	public virtual void OnClear() { }
}

public abstract class PopupQueueAction
{
	public PopupQueueAction(uint popupMode)
	{
		mode = popupMode;
	}
	
	public uint mode { get; private set; }
	public bool active { get; protected set; } = false;
	
	public virtual void Execute(bool hasMode)
	{}
}