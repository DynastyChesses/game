namespace Simulation
{
    public interface IUpdate
    {
        /// <summary>
        /// 物理更新之后
        /// </summary>
        void PhysicsUpdateBefore();

        /// <summary>
        /// 物理更新之后
        /// </summary>
        void PhysicsUpdateAfter();
    }
}