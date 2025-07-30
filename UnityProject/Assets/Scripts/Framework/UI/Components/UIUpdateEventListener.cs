using System;
using UnityEngine;

public class UIUpdateEventListener :MonoBehaviour
{
	private Action _updateDelegate;

	public event Action updateEvent
	{
		add
		{
			_updateDelegate += value;
		}

		remove
		{
			_updateDelegate -= value;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (_updateDelegate != null)
		{
			_updateDelegate();
		}
	}

	void OnDestroy()
	{
		_updateDelegate = null;
	}

	static public UIUpdateEventListener Get(GameObject go)
	{
		UIUpdateEventListener listener = go.GetComponent<UIUpdateEventListener>();
		if (listener == null)
			listener = go.AddComponent<UIUpdateEventListener>();
		return listener;
	}
}
