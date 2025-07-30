using FixMath.NET;

namespace Simulation
{
    public static class FixMathTool
    {
        public static BEPUutilities.Vector3 UV3_To_FixV3(UnityEngine.Vector3 v3)
        {
            return new BEPUutilities.Vector3((Fix64)v3.x,(Fix64)v3.y,(Fix64)v3.z);
        }
    
        public static BEPUutilities.Quaternion UQuaternion_To_FixQuaternion(UnityEngine.Quaternion quaternion)
        {
            return new BEPUutilities.Quaternion((Fix64)quaternion.x,(Fix64)quaternion.y,(Fix64)quaternion.z,(Fix64)quaternion.w);
        }
    
        public static UnityEngine.Vector3 FixV3_To_UV3(BEPUutilities.Vector3 v3)
        {
            return new UnityEngine.Vector3((float)v3.X,(float)v3.Y,(float)v3.Z);
        }
        public static UnityEngine.Vector2 FixV2_To_UV2(BEPUutilities.Vector2 v2)
        {
            return new UnityEngine.Vector2((float)v2.X,(float)v2.Y);
        }
    
        public static UnityEngine.Quaternion FixQuaternion_To_UQuaternion(BEPUutilities.Quaternion quaternion)
        {
            return new UnityEngine.Quaternion((float)quaternion.X,(float)quaternion.Y,(float)quaternion.Z,(float)quaternion.W);
        }
        public static float Fix64ToFloat(Fix64 value)
        {
            return (float) value;
        }
    }
}