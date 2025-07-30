using System;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.Save;
using HotUpdate.osP1.ValueObject;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class UseHammer : BaseSkill
    {
        public static bool IsUsing = false;
        
        public new static void GlobalStart()
        {
            IsUsing = false;
        }

        public new static void GlobalUpdate(UpdateTimeInfo time)
        {
        }

        public new static void GlobalEnd()
        {
        }

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
            ShowUseHammerMask();
            AnimUseItem();
        }

        private void ExitState()
        {
            HideUseHammerMask();
            AnimUseItemEnd();
        }

        public void DestroyBrick(BrickVo vo)
        {
            IsUsing = false;
            ExitState();
            
            //移除道具
            GamePlay.instance.GameItem.RemainUseNum[GameItemType.Hammer]--;
            GamePlay.instance.GameItem.CurrentNum[GameItemType.Hammer]--;
            PlayerSave.instance.PlayerAssets.RemoveItemNum(GameItemType.Hammer,1);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,GameItemType.Hammer);
            
            var gameData = GamePlay.instance.GamePlayData;
            MoveBox2Slot.IsAllowClick = false;
            AudioFacade.instance.PlayClip("Sound_Die", false);
            FireBullet.NeedWaitItem++;

            //BrickVo
            var originLife = vo.Life;
            vo.Life = 0;
            vo.State = BrickState.Dead;

            vo.BeforeDead();

            if (gameData.IsLastRowBrickAllDead() && gameData.IsExtraRowBrickAllDead())
            {
                FireBullet.ExternBrickMatrixMoveDown();
            }
            else
            {
                gameData.SetAllSlotNotLoad();
            }

            //data4BrickVo
            var data4BrickVo = gameData.Data4BrickVo[vo.OriginRow][vo.OriginCol];
            data4BrickVo.Life = 0;
            data4BrickVo.State = BrickState.Dead;

            if (data4BrickVo is BrickGeneratorVo brickGeneratorVo)
            {
                brickGeneratorVo.ReviveData4BrickVo(brickGeneratorVo.OriginRow, brickGeneratorVo.OriginCol);
            }

            while (gameData.IsNeedSetAttackIndex() && gameData.AttackIndex != 0)
            {
                gameData.SetAttackIndex();
            }

            for (int i = 0; i < originLife; i++)
                GamePlay.instance.KillOneLife(vo.Color);


            var ui = GamePlay.instance.UI;
            ui.skelHammer.enabled = true;
            ui.skelHammer.transform.position = gameData.BrickPos[vo.Row - gameData.IndexBias][vo.Col];
            var trackEntry = ui.skelHammer.AnimationState.SetAnimation(0, "attack", false);
            trackEntry.Event += (entry, @event) =>
            {
                if (@event.Data.Name == "die")
                {
                    var row = vo.Row;
                    var col = vo.Col;
                    var commonBrick = gameData.BrickView[vo.Row - gameData.IndexBias][vo.Col].render as ICommonBrick;
                    if (commonBrick is BrickGenerator)
                    {
                        commonBrick.AnimationDead((() =>
                        {
                            gameData.PassVo2BrickView(row, col);

                            FireBullet.NeedWaitItem--;
                            IsUsing = false;
                            MoveBox2Slot.IsAllowClick = true;
                            GamePlay.instance.CheckGameWin();
                            GamePlay.instance.GameItem.ResetRemind();
                            
                        }));
                    }
                    else
                    {
                        commonBrick.AnimationDead((() =>
                        {
                            gameData.PassVo2BrickView(row, col);


                            vo.AfterDead((() =>
                            {
                                FireBullet.NeedWaitItem--;
                                IsUsing = false;
                                MoveBox2Slot.IsAllowClick = true;
                                GamePlay.instance.CheckGameWin();
                                GamePlay.instance.GameItem.ResetRemind();
                                
                            }));
                        }));
                    }
                }
            };
            
            
            
        }
        
        private void ShowUseHammerMask()
        {
            var ui = GamePlay.instance.UI;
            ui.imgItemUse.enabled = true;
            ui.textItemUse.text = GamePlay.instance.GameItem.Desc[GameItemType.Hammer];

            var gameData = GamePlay.instance.GamePlayData;
            
            //设置砖块父节点
            for (int i = 0; i < gameData.BrickDisplayRow; i++)
            {
                for (int j = 0; j < gameData.BrickDisplayCol; j++)
                {
                    gameData.BrickView[i][j].gameObject.transform.SetParent(ui.imgItemUse.transform);
                }
            }
            //设置锤子父节点
            var hammerGo = ui.item.GetItem((int)GameItemType.Hammer);
            hammerGo.transform.SetParent(ui.imgItemUse.transform);
        }
        
        private void HideUseHammerMask()
        {
            var ui = GamePlay.instance.UI;
            var gameData = GamePlay.instance.GamePlayData;
            
            //设置砖块父节点
            for (int i = 0; i < gameData.BrickDisplayRow; i++)
            {
                for (int j = 0; j < gameData.BrickDisplayCol; j++)
                {
                    gameData.BrickView[i][j].gameObject.transform.SetParent(ui.brickLayout);
                }
            }
            //设置锤子父节点
            var hammerGo = ui.item.GetItem((int)GameItemType.Hammer);
            hammerGo.transform.SetParent(ui.itemLayout.transform);
            hammerGo.transform.SetSiblingIndex((int)GameItemType.Hammer);
            
            ui.textItemUse.text = "";
            ui.imgItemUse.enabled = false;
        }
        
        private void AnimUseItemEnd()
        {
            var ui = GamePlay.instance.UI;
            var trackEntry = ui.itemSkel[(int)GameItemType.Hammer].AnimationState.SetAnimation(0, "waiting_end", false);
            trackEntry.Complete += entry =>
            {
                
            };
        }
        
        private void AnimUseItem()
        {
            //点击后再选其他单位的道具
            var ui = GamePlay.instance.UI;
            var trackEntry = ui.itemSkel[(int)GameItemType.Hammer].AnimationState.SetAnimation(0, "wait_start", false);
            trackEntry.Complete += entry =>
            {
                ui.itemSkel[(int)GameItemType.Hammer].AnimationState.SetAnimation(0, "waiting", true);
            };
        }
    }
}