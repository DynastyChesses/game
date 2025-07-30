using BEPUphysics;
using BEPUphysics.Constraints.SingleEntity;
using BEPUphysics.Constraints.TwoEntity.Motors;
using BEPUphysics.Entities;
using BEPUphysics.UpdateableSystems;
using BEPUutilities;
using FixMath.NET;

namespace Simulation
{
    /// <summary>
    /// 弹簧抓取约束
    /// </summary>
    public class MotorizedGrabSpring : Updateable,IEndOfFrameUpdateable
    {
        SingleEntityLinearMotor linearMotor;
        SingleEntityAngularMotor angularMotor;

        public MotorizedGrabSpring()
        {
            linearMotor = new SingleEntityLinearMotor();
            angularMotor = new SingleEntityAngularMotor();
            linearMotor.Settings.Mode = MotorMode.Servomechanism;
        }
        
        /// <summary>
        /// 获取抓取的实体
        /// </summary>
        public Entity Entity
        {
            get
            {
                return linearMotor.Entity;
            }
            private set
            {
                if (linearMotor.Entity != value) 
                {
                    linearMotor.Entity = value;
                    angularMotor.Entity = value;
                    if (value != null)
                    {
                        linearMotor.IsActive = true;
                        angularMotor.IsActive = true;
                        IsUpdating = true;
                    }
                    else
                    {
                        linearMotor.IsActive = false;
                        angularMotor.IsActive = false;
                        IsUpdating = false;
                    }
                }
            }
        }
        /// <summary>
        /// 获取实体将被拉向的位置。
        /// </summary>
        public Vector3 GoalPosition
        {
            get
            {
                return linearMotor.Settings.Servo.Goal;
            }
            set
            {
                linearMotor.Settings.Servo.Goal = value;
            }
        }
        /// <summary>
        /// 抓取位置的偏移量
        /// </summary>
        public Vector3 LocalOffset
        {
            get
            {
                return linearMotor.LocalPoint;
            }
            private set
            {
                linearMotor.LocalPoint = value;
            }
        }
        /// <summary>
        /// 获取实体表面上抓取位置的最后更新位置。
        /// </summary>
        public Vector3 GrabbedPosition { get; private set; }
        /// <summary>
        /// 是否正在抓取
        /// </summary>
        public bool IsGrabbing
        {
            get
            {
                return Entity != null;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e">抓取的实体</param>
        /// <param name="grabLocation">抓取的位置</param>
        public void Setup(Entity e, Vector3 grabLocation)
        {
            linearMotor.Settings.Servo.SpringSettings.Stiffness = 60000 * e.Mass;
            linearMotor.Settings.Servo.SpringSettings.Damping = 9000 * e.Mass;
            angularMotor.Settings.VelocityMotor.Softness = 0.1m / e.Mass;
            linearMotor.Settings.MaximumForce = 1000 * e.Mass;

            Entity = e;
            LocalOffset = Quaternion.Transform(grabLocation - e.Position, Quaternion.Conjugate(e.Orientation));
            angularMotor.Settings.Servo.Goal = e.Orientation;
            GoalPosition = grabLocation;
        }
        public void Release()
        {
            Entity = null;
        }
        
        /// <summary>
        /// 更新抓取约束的位置
        /// </summary>
        void IEndOfFrameUpdateable.Update(Fix64 dt)
        {

            GrabbedPosition = Matrix3x3.Transform(LocalOffset, Entity.BufferedStates.InterpolatedStates.OrientationMatrix) + Entity.BufferedStates.InterpolatedStates.Position;
        }

        public void OnAdditionToSpace(Space newSpace)
        {
            newSpace.Add(linearMotor);
            newSpace.Add(angularMotor);
        }

        public void OnRemovalFromSpace(Space oldSpace)
        {
            oldSpace.Remove(linearMotor);
            oldSpace.Remove(angularMotor);
        }
        
        
        
        
        
        
        
        
        
        
        
    }
}