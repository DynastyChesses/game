namespace HotUpdate.osP1.SkillSystem
{
    public class BaseSkill
    {
        private int _updatorId = EquineScheduler.INVALID;

        protected int CurrentFrame { get; private set; } = -1;
        
        protected bool IsNeedUpdate { get; private set;}

        protected BaseSkill(bool isNeedUpdate = false)
        {
            IsNeedUpdate = isNeedUpdate;
        }
        
        public static void GlobalStart()
        {
            
        }

        public static void GlobalUpdate(UpdateTimeInfo time)
        {
            
        }

        public static void GlobalEnd()
        {
            
        }

        public virtual void SkillStart()
        {
            if(IsNeedUpdate)
                _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);
        }

        public virtual void SkillUpdate(UpdateTimeInfo time)
        {
            CurrentFrame++;
        }

        public virtual void SkillEnd()
        {
            if(IsNeedUpdate)
                EquineScheduler.RemoveLimitUpdator(ref _updatorId);
        }

        
        
        private void OnUpdate(int a, object b, UpdateTimeInfo time)
        {
            SkillUpdate(time);
        }
    }
}