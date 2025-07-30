using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using DG.Tweening;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.ValueObject;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class MoveBox2Slot : BaseSkill
    {
        public static bool IsAnimationFinished => _movingBoxNum == 0;

        public static bool IsAllowClick { get; set; } = true;

        private static int _movingBoxNum;

        private int _boxRow;
        private int _boxCol;
        private int _slotIndex;
        private BoxVo _boxVo;

        //animation params
        

        public MoveBox2Slot(int boxRow,int boxCol, int slotIndex)
        {
            _boxRow = boxRow;
            _boxCol = boxCol;
            _slotIndex = slotIndex;
        }

        public new static void GlobalStart()
        {
            _movingBoxNum = 0;
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

            var gameData = GamePlay.instance.GamePlayData;
            
            _boxVo = gameData.BoxVo[_boxRow][_boxCol];
            
            
            var startPos = gameData.BoxPos[_boxRow][_boxCol]; ;
            var endPos = gameData.SlotPos[_slotIndex];


            _movingBoxNum++;
            CommonItemRenderer cir = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
            BoxVo newBoxVo;
            if (_boxVo is RandomBoxVo randomBoxVo)
            {
                newBoxVo = randomBoxVo.ToBoxVo();
            }
            else
            {
                newBoxVo = _boxVo.Clone();
            }
            
            newBoxVo.State = BoxState.Move2Slot;
            for (int i = 0; i < newBoxVo.Bullets.Count; i++)
            {
                newBoxVo.Bullets[i].State = StackableBulletState.Move2Slot;
            }
            cir.data = newBoxVo;
            cir.initCallBack += () =>
            {
                cir.gameObject.transform.position = gameData.BoxPos[_boxRow][_boxCol];
                var box = cir.render as Box;
                box.AnimationMove2Slot(startPos,endPos,() =>
                {
                    newBoxVo.State = BoxState.InSlot;
                    newBoxVo.SlotIndex = _slotIndex;
                    newBoxVo.Cir = cir;
                    for (int i = 0; i < newBoxVo.Bullets.Count; i++)
                    {
                        newBoxVo.Bullets[i].State = StackableBulletState.InPanel;
                    }
                    newBoxVo.Data4Ai = newBoxVo.Clone(); 
                    gameData.SlotSet.Add(newBoxVo);
                    newBoxVo.Cir.data = newBoxVo;

            
                    EntityManager.instance.AddEntity(newBoxVo);
                    
                    _movingBoxNum--;
                    
                    if (GamePlay.instance.IsGuideMode && GamePlay.instance.GuidePhase == 2)
                    {
                        GameLaunch.PauseGame();
                        ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GuideNextPhase);
                        GamePlay.instance.GuidePhase++;
                    }

                    
                });
                
            };

            
            
            SkillEnd();
        }

        public override void SkillUpdate(UpdateTimeInfo updateTimeInfo)
        {
            base.SkillUpdate(updateTimeInfo);
        }

        public override void SkillEnd()
        {
            base.SkillEnd();
        }
    }
}