using UnityEngine;

public abstract class AbstractListComponent : IItemRendererHost
{
    public delegate void OnItemEvent(IItemRenderer render, string eventName, object param);
    public delegate void OnSelectItemChanged(int oldIndex, object oldData, int newIndex, object newData);

    #region IItemRendererHost implementation

    public abstract void Reposition(bool asyncMode = true);

    public abstract void OnItemEventRaised(IItemRenderer render, string eventName, object param);

    public abstract object context
    {
        get;
        set;
    }

    #endregion


}