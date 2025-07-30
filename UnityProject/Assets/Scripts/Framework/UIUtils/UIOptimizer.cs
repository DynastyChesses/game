#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIOptimizer : MonoBehaviour
{
    public List<Image> invisibleImage;
    
    void FindInvisilbeImage()
    {
        invisibleImage.Clear();
        var images = GetComponentsInChildren<Image>();
        foreach (var v in images)
        {
            var cr = v.GetComponent<CanvasRenderer>();
            if ((v.sprite == null || v.color.a == 0) && (cr == null || cr.cullTransparentMesh == false))
                invisibleImage.Add(v);
        }
    }

    void DisableInvisibleImageFound()
    {
        FindInvisilbeImage();
        foreach (var v in invisibleImage)
        {
            if (v != null)
            {
                var cr = v.GetComponent<CanvasRenderer>();
                if (cr != null)
                    cr.cullTransparentMesh = true;
            }
        }
    }
}

#endif