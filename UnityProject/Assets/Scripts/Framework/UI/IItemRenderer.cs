
using UnityEngine;

public class ItemRendererEventNames
{
	public const string CLICK = "Click";
	public const string DOUBLECLICK = "DoubleClick";
	public const string DRAG = "Drag";
	public const string DRAGBEGIN = "DragBegin";
	public const string DRAGEND = "DragEnd";
}

public interface IItemRendererHost
{
	void Reposition(bool asyncMode = true);
	void OnItemEventRaised(IItemRenderer render, string eventName, object param = null);

	object context
	{
		get;
	}
	
}

public interface  IItemRenderer
{
	GameObject viewObject
	{
		get;
	}

	RectTransform rectTransform
	{
		get;
	}

	object data
	{
		get;
		set;
	}

	int index
	{
		get;
		set;
	}

	bool selected
	{
		get;
		set;
	}
	
	bool selectable
	{
		get;
		set;
	}

	IItemRendererHost host
	{
		get;
		set;
	}

    Vector3 center
    {
        get;
    }


    void MarkSizeDirty();

    Vector2 size
    {
        get;
    }

	void Refresh();

	void OnUpdate();

    void Dispose();
}

public interface IReusableItemRenderer : IItemRenderer
{
    float GetSize();
}
