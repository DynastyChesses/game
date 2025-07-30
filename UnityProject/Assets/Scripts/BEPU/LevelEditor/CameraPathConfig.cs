using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = BEPUutilities.Vector3;

public class CameraPathConfig : MonoBehaviour
{

#if UNITY_EDITOR
    public int Value;
    private void OnDrawGizmos()
    {
        if (transform.childCount > 0)
            for (int i = 0; i < transform.childCount; i++)
                DebugExtension.DrawPoint(transform.GetChild(i).position,Color.magenta);
    }
    
#endif
    
}
