using System.Collections.Generic;

namespace HotUpdate.osP1.EntitySystem
{
    public class EntityManager: Singleton<EntityManager>
    {
        private HashSet<IEntity> _entity = new HashSet<IEntity>();

        private int _updatorId = EquineScheduler.INVALID;
        
        public override void Init()
        {
            _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);
        }

        private void OnUpdate(int a,object b,UpdateTimeInfo time)
        {
            foreach (var entity in _entity)
            {
                entity.Update(time);
            }
        }
        
        public override void Dispose()
        {
            EquineScheduler.RemoveLimitUpdator(ref _updatorId);
        }

        

        public void AddEntity(IEntity entity)
        {
            if(_entity.Contains(entity))
                return;
            
            entity.Start();
            _entity.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            if (_entity.Contains(entity))
                _entity.Remove(entity);
        }
    }
}