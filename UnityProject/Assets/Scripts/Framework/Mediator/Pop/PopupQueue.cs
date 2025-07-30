using UnityEngine;
using System;
using System.Collections.Generic;

public class PopupQueue
{
	private List<IPopupView> list;

	private object mutex;

	public PopupQueue ()
	{
		mutex = new object();

		list = new List<IPopupView>();
	}

	public int Count
	{
		get
		{
			return list.Count;
		}
	}

	public void AddToFront (IPopupView popup)
	{
		lock (mutex)
		{
			list.Insert(0, popup);
		}
	}

	public void AddToBack (IPopupView popup)
	{
		lock (mutex)
		{
			list.Add(popup);
		}
	}

	public IPopupView Unshift ()
	{
		lock (mutex)
		{
			IPopupView popup = null;
			if (list.Count > 0)
			{
				popup = list[0];
				list.RemoveAt(0);
			}
			return popup;
		}
	}

	public void Clear()
	{
		lock(mutex)
		{
			list.Clear();
		}
	}
}

