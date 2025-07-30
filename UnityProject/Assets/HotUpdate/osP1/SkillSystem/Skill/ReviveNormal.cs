using System.Linq;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.ValueObject;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class ReviveNormal: BaseSkill
    {
        public static int RemainReviveTime;
        public static int OriginReviveTime;

        public new static void GlobalStart()
        {
            RemainReviveTime = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["revive_normal_limit"].Value);
            OriginReviveTime = RemainReviveTime;
        }
        
        public new static void GlobalUpdate(UpdateTimeInfo time){}
        
        public new static void GlobalEnd(){}
        
        public override void SkillStart()
        {
            base.SkillStart();
            //begin code

            
            AddSlot();

            var skill = new UseMagnet();
            SkillManager.instance.UseSkill(skill);

            SkillEnd();
            //end code
        }

        private void AddSlot()
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            var currentSlot = gameData.CurrentUnlockedSlotNum;
            var maxSlot = gameData.SlotMaxNum;
            if (currentSlot + 1 <= maxSlot)
            {
                gameData.CurrentUnlockedSlotNum++;
                
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderSlotLock,gameData.CurrentUnlockedSlotNum);
            }
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