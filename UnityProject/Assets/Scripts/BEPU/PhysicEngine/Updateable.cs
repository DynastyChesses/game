using System.Collections.Generic;
using BEPUphysics;
using BEPUphysics.UpdateableSystems;

namespace Simulation
{
    public class Updateable: ISpaceUpdateable
    {
        protected Updateable()
        {
            IsUpdating = true;
        }
        private Space space;
        Space ISpaceObject.Space
        {
            get => space;
            set => space = value;
        }

        public Space Space => space;

        /// <summary>
        /// 获取或设置与此对象关联的用户数据。
        /// </summary>
        public object Tag { get; set; }
        /// <summary>
        /// 获取并设置可更新对象是否应由其管理器更新。
        /// </summary>
        public bool IsUpdating
        {
            get;
            set;
        }        
        List<UpdateableManager> managers = new List<UpdateableManager>();
        List<UpdateableManager> ISpaceUpdateable.Managers
        {
            get
            {
                return managers;
            }
        }
        private bool isUpdatedSequentially = true;
        public bool IsUpdatedSequentially
        {
            get { return isUpdatedSequentially; }
            set
            {
                bool oldValue = isUpdatedSequentially;
                isUpdatedSequentially = value;
                if (value != oldValue)
                    for (int i = 0; i < managers.Count; i++)
                    {
                        managers[i].SequentialUpdatingStateChanged(this);
                    }
            }
        }
        
        public virtual void OnAdditionToSpace(Space newSpace) { }
        public virtual void OnRemovalFromSpace(Space oldSpace) { }
    }
}