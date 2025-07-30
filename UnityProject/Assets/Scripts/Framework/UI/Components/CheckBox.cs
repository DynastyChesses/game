using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckBox :MonoBehaviour
{
	public Image fg;
	private bool _selected = true;

	public bool selected
	{
		get { return _selected; }
		set
		{
			if (_selected != value)
			{
				_selected = value;
				if (fg != null)
				{
					fg.gameObject.SetActive(_selected);
				}
			}
		}
	}

	void Awake()
	{
		_selected = fg != null && fg.gameObject.activeSelf;
	}
}
