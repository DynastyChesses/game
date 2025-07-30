using System;
using System.Collections.Generic;
using UnityEngine;

public class BakedAnimationUpdateFacade :MonoBehaviour
{
	public static List<Mesh> allMeshes = new List<Mesh>();

	public Action<float> updateEvent;

	public static void ClearAllMesh()
	{
		int count = allMeshes.Count;
		for (int i = 0; i < count; ++i)
		{
			Destroy(allMeshes[i]);
		}
		allMeshes.Clear();
	}

	void Update()
	{
		if (updateEvent != null)
		{
			updateEvent(Time.smoothDeltaTime);
		}
	}

	private void OnDestroy()
	{
		updateEvent = null;
	}
}
