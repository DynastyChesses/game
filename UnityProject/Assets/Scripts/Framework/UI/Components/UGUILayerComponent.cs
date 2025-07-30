using UnityEngine;
using UnityEngine.UI;

public class UGUILayerComponent : MonoBehaviour
{
    public RectTransform rect;

    private GraphicRaycaster _raycaster;

    private void Awake()
    {
        _raycaster = rect.GetComponent<GraphicRaycaster>();
    }

    public int layer
    {
        get
        {
            return rect.gameObject.layer;
        }

        set
        {
            rect.gameObject.layer = value;
        }
    }

    public bool interactive
    {
        get
        {
            return _raycaster && _raycaster.enabled;
        }

        set
        {
            if (_raycaster)
            {
                _raycaster.enabled = value;
            }
        }
    }
    
}
