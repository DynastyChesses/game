using DG.Tweening;
using UnityEngine;

namespace Simulation
{
    // public class ViewObject : MonoBehaviour
    // {
    //     public FixEntityBase FixEntity;
    //
    //     private void Awake()
    //     {
    //         EventManager.Inst.AddEvent(EventName.FixPhysicsUpdateAfter,OnUpdateAfter);
    //     }
    //
    //     private void OnDestroy()
    //     {
    //         EventManager.Inst.RemoveEvent(EventName.FixPhysicsUpdateAfter,OnUpdateAfter);
    //     }
    //
    //     private void OnUpdateAfter(string arg1, object arg2)
    //     {
    //         float fixtime = (float) arg2;
    //         Vector3 pos = new Vector3((float)FixEntity.Entity.Position.x,(float)FixEntity.Entity.Position.y,(float)FixEntity.Entity.Position.z);
    //         Quaternion rotate= new Quaternion((float)FixEntity.Entity.Orientation.X,(float)FixEntity.Entity.Orientation.Y,(float)FixEntity.Entity.Orientation.Z,(float)FixEntity.Entity.Orientation.W);
    //
    //         // if (true)
    //         // {
    //         transform.DORotateQuaternion(rotate, fixtime).SetEase(Ease.Linear);
    //         transform.DOMove(pos, fixtime).SetEase(Ease.Linear);
    //         // }
    //         // else
    //         // {
    //         //     transform.position = pos;
    //         //     transform.rotation = rotate;
    //         // }
    //     }
    // }

}