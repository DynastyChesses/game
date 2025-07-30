using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = BEPUutilities.Vector3;
public class StartPointConfig : MonoBehaviour
{
    // public int Value;
#if UNITY_EDITOR

    //Index从1开始
    //编辑器自动根据Hierarchy面板层级来划分
    //个人赛就正常按照顺序设置复活点即可
    //组队赛 2 队伍，前8个是队伍1，后8个是队伍2
    //组队赛 4 队伍，前4个是队伍1，然后4个是队伍2，以此类推。
    
    private void OnDrawGizmos()
    {
        DebugExtension.DrawPoint(transform.position,Color.red);
    }
#else
    
    private void OnDrawGizmos()
    {
        // DebugExtension.DrawPoint(transform.position,Color.red);
    }
#endif
    
}
