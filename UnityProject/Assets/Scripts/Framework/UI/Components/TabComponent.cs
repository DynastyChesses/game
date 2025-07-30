using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TabComponent : MonoBehaviour {

    public Toggle toggle;
    public Text label;
    public Image icon;
    public Color selectedColor = new Color(69f/255f, 69f/255f, 69f/255f);
    public Color unselectedColor = Color.white;
    public Text redLabel;

	// Use this for initialization
	void Start () {
        toggle.onValueChanged.AddListener(OnToggleChange);
        UpdateColor();
	}

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnToggleChange);
    }
    
    void OnToggleChange(bool val)
    {
        UpdateColor();
    }

    void UpdateColor()
    {
        if (toggle.isOn)
        {
            label.color = selectedColor;
        }
        else
        {
            label.color = unselectedColor;
        }

        if (icon != null)
        {
            icon.color = label.color;
        }
    }

    public void SetNewNum(int count)
    {
        if (redLabel != null)
        {
            redLabel.gameObject.SetActive(count > 0);
            redLabel.text = count > 99 ? "99" : count.ToString();
        }
    }

}
