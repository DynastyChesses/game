namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class UseMagnet:BaseSkill
    {
        //调用了LoadBullet，所以动画停止与否处于LoadBullet中
        //public static bool IsAnimationFinished;
        public static int MaxUseTime;

        public new static void GlobalStart()
        {
            MaxUseTime = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_slingshot_limit"].Value);

        }
        
        public new static void GlobalUpdate(UpdateTimeInfo time){}
        
        public new static void GlobalEnd(){}
        
        public override void SkillStart()
        {
            base.SkillStart();
            //begin code
            
            
            var gameData = GamePlay.instance.GamePlayData;
            var index = -1;
            for (int i = 0; i < gameData.CurrentUnlockedSlotNum; i++)
            {
                if (!gameData.IsSlotEmpty[i])
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return;
            }

            foreach (var vo in gameData.SlotSet)
            {
                if (vo.SlotIndex == index)
                {
                    vo.IsLoadBullet = true;
                    var skill = new LoadBullet(vo, true);
                    SkillManager.instance.UseSkill(skill);
                    break;
                }
            }
            
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