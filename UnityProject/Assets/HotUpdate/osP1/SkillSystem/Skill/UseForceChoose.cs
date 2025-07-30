using System;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.Save;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class UseForceChoose: BaseSkill
    {
        //无需等待
        //public static bool IsAnimationFinish;
        public static int MaxUseTime;
        
        public static bool IsUsing { get; private set; }

        

        public new static void GlobalStart()
        {
            IsUsing = false;
            MaxUseTime = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_select_limit"].Value);
        }
        
        public new static void GlobalUpdate(UpdateTimeInfo time){}
        
        public new static void GlobalEnd(){}
        
        public override void SkillStart()
        {
            base.SkillStart();
            //begin code
            
            IsUsing = !IsUsing;
            if (IsUsing)
                EnterState();
            else
                ExitState();
            
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

        private void EnterState()
        {
            ShowUseForceChooseMask();
            AnimUseItem();
        }

        private void ExitState()
        {
            HideUseForceChooseMask();
            AnimUseItemEnd();
        }

        public void ChooseBox()
        {
            IsUsing = false;
            GamePlay.instance.GameItem.RemainUseNum[GameItemType.ForceChoose]--;
            GamePlay.instance.GameItem.CurrentNum[GameItemType.ForceChoose]--;
            PlayerSave.instance.PlayerAssets.RemoveItemNum(GameItemType.ForceChoose,1);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,GameItemType.ForceChoose);
            
            ExitState();
        }
        
        private void ShowUseForceChooseMask()
        {
            var ui = GamePlay.instance.UI;
            ui.imgItemUse.enabled = true;
            ui.textItemUse.text = "Select any trays";
            
            var gameData = GamePlay.instance.GamePlayData;
            
            //设置盒子父级
            for (int i = 1; i < gameData.BoxVisibleRow; i++)
            {
                for (int j = 0; j < gameData.BoxDisplayCol; j++)
                {
                    var render = gameData.BoxView[i][j].render;
                    if(render is BoxGenerator)
                        continue;
                    
                    gameData.BoxView[i][j].gameObject.transform.SetParent(ui.imgItemUse.transform);
                }
            }
            
            //设置 item 父级
            var forceChooseGo = ui.item.GetItem((int)GameItemType.ForceChoose);
            forceChooseGo.transform.SetParent(ui.imgItemUse.transform);
        }
        
        private void HideUseForceChooseMask()
        {
            var ui = GamePlay.instance.UI;
            var gameData = GamePlay.instance.GamePlayData;
            
            //设置盒子父级
            for (int i = 1; i < gameData.BoxVisibleRow; i++)
            {
                for (int j = 0; j < gameData.BoxDisplayCol; j++)
                {
                    var render = gameData.BoxView[i][j].render;
                    if(render is BoxGenerator)
                        continue;
                    
                    gameData.BoxView[i][j].gameObject.transform.SetParent(ui.boxLayout);
                }
            }
            
            //设置 item 父级
            var forceChooseGo = ui.item.GetItem((int)GameItemType.ForceChoose);
            forceChooseGo.transform.SetParent(ui.itemLayout.transform);
            forceChooseGo.transform.SetSiblingIndex((int)GameItemType.ForceChoose);

            ui.textItemUse.text = "";
            ui.imgItemUse.enabled = false;
        }
        
        private void AnimUseItem()
        {
            //点击后再选其他单位的道具
            var ui = GamePlay.instance.UI;
            var trackEntry = ui.itemSkel[(int)GameItemType.ForceChoose].AnimationState.SetAnimation(0, "wait_start", false);
            trackEntry.Complete += entry =>
            {
                ui.itemSkel[(int)GameItemType.ForceChoose].AnimationState.SetAnimation(0, "waiting", true);
            };
        }
        
        private void AnimUseItemEnd()
        {
            var ui = GamePlay.instance.UI;
            var trackEntry = ui.itemSkel[(int)GameItemType.ForceChoose].AnimationState.SetAnimation(0, "waiting_end", false);
            trackEntry.Complete += entry =>
            {
                
            };
        }
    }
}