using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class UseRefresh:BaseSkill
    
    {
        public static bool IsClosing{get;private set;}
        public static bool IsRefreshing{get;private set;}

        public static int MaxUseTime;

        public static float MaskMoveDurationFever = 2.2f;
        public static float MaskMoveDuration = 0.75f;
        
        private Vector3 _leftStartPos;
        private Vector3 _rightStartPos;

        private int _count = 0;
        private int _totalAnim = 3;

        private bool _isFever;
        
        public UseRefresh(bool isFever) : base(false)
        {
            _leftStartPos = GamePlay.instance.UI.maskLeft.transform.position;
            _rightStartPos = GamePlay.instance.UI.maskRight.transform.position;
            _isFever = isFever;
        }

        public new static void GlobalStart()
        {
            IsClosing = false;
            IsRefreshing = false;
            MaxUseTime = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_limit"].Value);

        }
        
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

        public void CloseMask(Action callback)
        {
            if(IsClosing)
                return;
            IsClosing = true;

            var count = 0;
            var total = 2;
            Action lambda = () =>
            {
                count++;
                if (count == total)
                {
                    _count = 0;
                    var ui = GamePlay.instance.UI;
                    ui.skelCoin.enabled = true;
                    var trackEntry = ui.skelCoin.AnimationState.SetAnimation(0, "close", false);
                    trackEntry.Complete += entry =>
                    {
                        var entry1 = ui.skelCoin.AnimationState.SetAnimation(0, "shake", false);
                        entry1.Complete += entry =>
                        {
                            _count ++;
                        };
                        
                    };

                    var entry = ui.skelMaskLeft.AnimationState.SetAnimation(0, "shake_l", false);
                    entry.Complete += entry =>
                    {
                        _count++;
                    };
                    

                    entry = ui.skelMaskRight.AnimationState.SetAnimation(0, "shake_r", false);
                    entry.Complete += entry =>
                    {
                        _count ++;
                    };
                    
                    callback?.Invoke();
                }
            };
            
            var leftTr = GamePlay.instance.UI.maskLeft;
            var rightTr = GamePlay.instance.UI.maskRight;
            var leftEndPos = GamePlay.instance.UI.maskLeftEndPos.transform.position;
            var rightEndPos = GamePlay.instance.UI.maskRightEndPos.transform.position;
            if (_isFever)
            {
                leftTr.transform.DOMove(leftEndPos, MaskMoveDurationFever).SetEase(Ease.InCubic).onComplete += lambda.Invoke;
                rightTr.transform.DOMove(rightEndPos, MaskMoveDurationFever).SetEase(Ease.InCubic).onComplete += lambda.Invoke;
            }
            else
            {
                leftTr.transform.DOMove(leftEndPos, MaskMoveDuration).SetEase(Ease.InCubic).onComplete += lambda.Invoke;
                rightTr.transform.DOMove(rightEndPos, MaskMoveDuration).SetEase(Ease.InCubic).onComplete += lambda.Invoke;
            }
            
        }

        public void Refresh(Action callback)
        {
            if(IsRefreshing)
                return;
            IsRefreshing = true;
            
            var gameData = GamePlay.instance.GamePlayData;
            
            //dispose stamp
            foreach (var cir in gameData.StampCover)
            {
                cir.Dispose();
            }
            gameData.StampCover.Clear();
            
            for(int i = 0; i< gameData.BoxVisibleRow;i++)
            for (int j = 0; j < gameData.BoxDisplayCol; j++)
            {
                gameData.IsStampCover[i][j] = false;
            }
            
            
            //arrangement box
            var list = gameData.FetchRemainBrick();
            GamePlay.instance.LevelData.BoxProduction.ReloadBox(list,(() =>
            {
                EquineScheduler.RunYieldProcedure(EndReload(callback));
            }));
        }

        private IEnumerator EndReload(Action callback)
        {
            var count = 0;
            var total = 2;
            Action lambda = () =>
            {
                count++;
                if (count == total)
                {
                    IsClosing = false;
                    IsRefreshing = false;
                    callback?.Invoke();
                }
            };

            while (true)
            {
                if (_count != _totalAnim)
                    yield return null;
                else
                {
                    break;
                }
            }
            
            var ui = GamePlay.instance.UI;
            ui.skelMaskLeft.AnimationState.SetAnimation(0, "normal_l", true);
            ui.skelMaskRight.AnimationState.SetAnimation(0, "normal_r", true);
            var trackEntry = ui.skelCoin.AnimationState.SetAnimation(0,"open", false);
            trackEntry.Complete += entry =>
            {
                ui.skelCoin.enabled = false;
            };
            var leftTr = GamePlay.instance.UI.maskLeft;
            var rightTr = GamePlay.instance.UI.maskRight;
            leftTr.transform.DOMove(_leftStartPos, MaskMoveDuration).SetEase(Ease.InCubic).onComplete += lambda.Invoke;
            rightTr.transform.DOMove(_rightStartPos, MaskMoveDuration).SetEase(Ease.InCubic).onComplete += lambda.Invoke;
        }
    }
}