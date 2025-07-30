using UnityEngine;

public interface IItemRendererFactory
{
	IItemRenderer CreateItem(GameObject template);
	void DestroyItem(IItemRenderer renderer);
}
