using System.Linq;
using HotUpdate.osP1.ValueObject;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class ReviveBomb: BaseSkill
    {
        public new static void GlobalStart(){}
        
        public new static void GlobalUpdate(UpdateTimeInfo time){}
        
        public new static void GlobalEnd(){}
        
        public override void SkillStart()
        {
            base.SkillStart();
            //begin code
            
            SkillEnd();
            //end code
        }

        public override void SkillUpdate(UpdateTimeInfo time)
        {
            base.SkillUpdate(time);
            //begin code
            //end code
        }

        public override void SkillEnd()
        {
            //begin code
            //end code
            base.SkillEnd();
        }
    }
}