using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LabelSpriteComponent :MonoBehaviour
{
	public Image bgSprite;

	public Text label;
	// Use this for initialization
	
	// public string bgUrl
	// {
	// 	get { return bgSprite.spriteName; }
	// 	set { bgSprite.spriteName = value; }
	// }

	public string text
	{
		get { return label.text; }
		set { label.text = value; }
	}

	private Collider _collider;

	// public bool interactive
	// {
	// 	get { return !bgSprite.disabled; }
	// 	set
	// 	{
	// 		if (bgSprite)
	// 		{
	// 			bgSprite.disabled = !value;
	// 		}
	// 		_collider = _collider ?? GetComponent<Collider>();
	// 		if (_collider)
	// 		{
	// 			_collider.enabled = value;
	// 		}
	// 	}
	// }

	public bool enableCollider
	{
		get
		{
			_collider = _collider ?? GetComponent<Collider>();
			if (_collider)
			{
				return _collider.enabled;
			}

			return false;
		}
		set
		{
			_collider = _collider ?? GetComponent<Collider>();
			if (_collider)
			{
				_collider.enabled = value;
			}
		}
	}

    // public bool disableBg
    // {
    //     get { return bgSprite.disabled; }
    //     set
    //     { 
    //         if (bgSprite)
    //         {
    //             bgSprite.disabled = value;
    //         }
    //     }
    // }

    [ContextMenu("SetValue")]
    void SetValue()
    {
        if(this.bgSprite == null)
            this.bgSprite = GetComponent<Image>();
        if(this.bgSprite == null)
            this.bgSprite = GetComponentInChildren<Image>();
        if(this.label == null)
            this.label = GetComponent<Text>();
        if(this.label == null)
            this.label = GetComponentInChildren<Text>();
    }
}
