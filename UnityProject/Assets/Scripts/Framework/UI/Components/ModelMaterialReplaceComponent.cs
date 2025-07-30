using System;
using UnityEngine;

public class ModelMaterialReplaceComponent :MonoBehaviour
{
	[Serializable]
	public class ModelRendererGroup
	{
		public Renderer renderer;

		public Material[] replaceMaterials;
	}

	public ModelRendererGroup[] renderers;

	private bool _inReplacement = false;

	public void ExchangeMaterial(bool useReplacement)
	{
		if (_inReplacement != useReplacement)
		{
			_inReplacement = useReplacement;

			int count = renderers != null ? renderers.Length : 0;

			for (int i = 0; i < count; ++i)
			{
				ModelRendererGroup group = renderers[i];
				if (group.renderer != null)
				{
					Material[] tmp = group.renderer.sharedMaterials;
					group.renderer.sharedMaterials = group.replaceMaterials;
					group.replaceMaterials = tmp;
				}
			}
		}
	}

#if UNITY_EDITOR
	[ContextMenu("Execute")]
	public void Execute()
	{
		ExchangeMaterial(!_inReplacement);
	}
#endif

}
