using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class LoadBullet : BaseSkill
    {
        public static bool IsAnimationFinished =>
            _animationPayload.IsFinished && _animationQueue.Count == 0 && _movingBulletNum == 0 && _dropBoxAnimNum == 0;

        //animation params
        private float LoadBulletInterval = 0.05f;

        private float BulletJumpToBarrelSpeed =
            float.Parse(MetaManager.instance.Meta.TbKV.DataMap["bullet_move_speed"].Value);
        
        private static Queue<Action<AnimPayload>> _animationQueue;
        private static AnimPayload _animationPayload;
        private static int _movingBulletNum;


        private bool _isAimAll;
        private BoxVo _boxVo;
        private Action _callback;

        private static int _dropBoxAnimNum;

        public LoadBullet(BoxVo boxVo, bool isAimAll = false)
        {
            _boxVo = boxVo;
            _isAimAll = isAimAll;
        }


        public new static void GlobalStart()
        {
            _animationQueue = new Queue<Action<AnimPayload>>();
            _animationPayload = new AnimPayload
            {
                IsFinished = true
            };
            _movingBulletNum = 0;
            _dropBoxAnimNum = 0;
        }

        public new static void GlobalUpdate(UpdateTimeInfo time)
        {
            if (!_animationPayload.IsFinished)
                return;


            if (_animationQueue.Count > 0 && GamePlay.instance.IsBarrelEmpty[GamePlay.instance.BarrelCapacity - 1])
            {
                _animationPayload.IsFinished = false;
                var func = _animationQueue.Dequeue();
                func(_animationPayload);
            }
        }

        public new static void GlobalEnd()
        {
            _animationQueue = null;
            _animationPayload = null;
        }

        public override void SkillStart()
        {
            base.SkillStart();

            AimBrick(_isAimAll);

            SkillEnd();
        }

        public override void SkillUpdate(UpdateTimeInfo time)
        {
            base.SkillUpdate(time);
        }

        public override void SkillEnd()
        {
            base.SkillEnd();
        }


        private void AimBrick(bool isAimAll)
        {
            var boxVo = _boxVo.Data4Ai;
            if (boxVo.State == BoxState.PlaceHolder)
                return;

            var gameData = GamePlay.instance.GamePlayData;

            if (!isAimAll)
            {
                var needLoadAgain = false;
                var isLoadAgain = false;
                do
                {
                    //如果循环了至少一次，那么 isLoadAgain 设置为true
                    if(needLoadAgain)
                        isLoadAgain = true;
                    
                    //每次次循环，必须重置该变量
                    needLoadAgain = false;
                    
                    //获取攻击列表
                    var extraAttackList = gameData.Data4BrickVo[gameData.ExtraAttackIndex];
                    var normalAttackList = gameData.Data4BrickVo[gameData.AttackIndex];
                    var bombAttackList = new List<BrickVo>();
                    foreach (var vo in normalAttackList)
                    {
                        if (vo is BombVo)
                            bombAttackList.Add(vo);
                    }

                    if (AimBrickInner(boxVo, extraAttackList))
                    {
                        needLoadAgain = true;
                        continue;
                    }

                    if (AimBrickInner(boxVo, bombAttackList))
                    {
                        needLoadAgain = true;
                        continue;
                    }

                    if (AimBrickInner(boxVo, normalAttackList))
                    {
                        needLoadAgain = true;
                        continue;
                    }
                    
                } while (needLoadAgain);
                
                if(isLoadAgain)
                    NotifyOtherSlotLoadBullet();
            }
            else
            {
                //AimAll 必须消耗箱子
                var allBrickList = new List<BrickVo>();

                for (int i = gameData.ExtraAttackIndex; i >= 0; i--)
                for (int j = 0; j < gameData.BrickDisplayCol; j++)
                {
                    allBrickList.Add(gameData.Data4BrickVo[i][j]);
                }
                //先攻击正常方块
                
                AimBrickInner(boxVo, allBrickList);
                if (!gameData.IsBoxEmpty(boxVo)) //寻找BrickGenerator中隐藏的方块
                    AimBrickInBrickGenerator(boxVo,allBrickList);
                
                if(!gameData.IsBoxEmpty(boxVo))//如果此处箱子还不空，而直接扔，需要动画排队，因为怕 AimBrickInner 发射了部分
                    _animationQueue.Enqueue(payload =>
                    {
                        DropBox();
                        payload.IsFinished = true;
                    });
                
            }
        }

        private bool AimBrickInner(BoxVo boxVo, List<BrickVo> attackList)
        {
            var gameData = GamePlay.instance.GamePlayData;


            if (gameData.IsBoxEmpty(boxVo))
                return false;

            var needLoadAgain = false;
            foreach (var stackableBullet in boxVo.Bullets)
            {
                for (var i = 0; i < attackList.Count; i++)
                {
                    var vo = attackList[i];

                    if (vo.State == BrickState.Dead)
                        continue;
                    if (vo.Color != stackableBullet.Color && !GamePlay.instance.Fever.IsFever)
                        continue;

                    if (stackableBullet.State == StackableBulletState.Empty)
                        break;

                    var number = stackableBullet.Number <= vo.Life ? stackableBullet.Number : vo.Life;

                    //use stackableBullet
                    var loadStackableBulletVo = new StackableBulletVo(StackableBulletState.InPanel);
                    loadStackableBulletVo.Color = stackableBullet.Color;
                    loadStackableBulletVo.Number = number;
                    loadStackableBulletVo.AttackTargetRow = vo.Row;
                    loadStackableBulletVo.AttackTargetCol = vo.Col;
                    loadStackableBulletVo.IsFeverStackableBullet = stackableBullet.IsFeverStackableBullet;

                    //remain stackableBullet
                    stackableBullet.Number -= number;
                    if (stackableBullet.Number == 0)
                        stackableBullet.State = StackableBulletState.Empty;

                    //Data4Brick
                    vo.Life -= number;
                    if (vo.Life == 0)
                    {
                        vo.Life = 0;
                        vo.State = BrickState.Dead;
                        if (vo is BrickGeneratorVo brickGeneratorVo)
                        {
                            var row = brickGeneratorVo.OriginRow;
                            var col = brickGeneratorVo.OriginCol;
                            brickGeneratorVo.ReviveData4BrickVo(row, col);
                            needLoadAgain = true;
                        }

                        //while 为了跳过空行
                        while (gameData.IsNeedSetAttackIndex() && gameData.AttackIndex != 0)
                        {
                            gameData.SetAttackIndex();
                            needLoadAgain = true;
                        }
                    }

                    var currentBoxVo = boxVo.Clone(); //必须声明一下，否则会在lambda表达式执行的时候复制
                    _animationQueue.Enqueue(payload => Load(payload, loadStackableBulletVo, currentBoxVo));
                }
            }

            return needLoadAgain;
        }
        
        private void AimBrickInBrickGenerator(BoxVo boxVo, List<BrickVo> attackList)
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            foreach (var stackableBullet in boxVo.Bullets)
            {
                for (var i = 0; i < attackList.Count; i++)
                {
                    var vo = attackList[i];

                    if(vo.GenerateGroup == 0)
                        continue;
                    
                    if(vo.Life <= 0)//此处不能用 BrickState.Dead判断
                        continue;
                    
                    if (vo.Color != stackableBullet.Color && !GamePlay.instance.Fever.IsFever)
                        continue;

                    if (stackableBullet.State == StackableBulletState.Empty)
                        break;

                    var number = stackableBullet.Number <= vo.Life ? stackableBullet.Number : vo.Life;
                    
                    //boxVo stackableBullet
                    stackableBullet.Number -= number;
                    if (stackableBullet.Number == 0)
                        stackableBullet.State = StackableBulletState.Empty;
                    
                    //Data4Brick
                    vo.Life -= number;
                    
                    //BrickVo
                    var brickVo = gameData.BrickVo[vo.Row][vo.Col];
                    brickVo.Life -= number;
                    
                    //game progress
                    for(int j = 0;j <number;j++)
                        GamePlay.instance.KillOneLife(vo.Color);

                    
                }
            }
            
            if(gameData.IsBoxEmpty(boxVo))
                _animationQueue.Enqueue(payload =>
                {
                   DropBox();
                   payload.IsFinished = true;
                });
            
        }

        private void Load(AnimPayload payload, StackableBulletVo stackableBulletVo, BoxVo currentBoxVo)
        {
            var gameData = GamePlay.instance.GamePlayData;

            var stackableBullet = new CommonItemRenderer(GamePlay.instance.UI.bg.transform);
            stackableBullet.data = stackableBulletVo;


            _boxVo.Bullets = currentBoxVo.Bullets;
            _boxVo.State = currentBoxVo.State;
            _boxVo.Cir.data = currentBoxVo;


            if (gameData.IsBoxEmpty(currentBoxVo))
            {
                DropBox();
            }

            stackableBullet.initCallBack += () =>
            {
                //date update -> stackable bullet
                stackableBulletVo.CommonItemRenderer = stackableBullet;

                var bulletTr = stackableBullet.gameObject.transform;
                bulletTr.localScale = Vector3.one * StackableBulletVo.StackableBulletScaleInScene;
                var startPos = gameData.SlotPos[_boxVo.SlotIndex];
                bulletTr.position = startPos;
                var endPos = new Vector3();

                //从后往前遍历
                bool isSet = false;
                for (int i = GamePlay.instance.IsBarrelEmpty.Count - 1; i > 0; i--)
                {
                    if (!GamePlay.instance.IsBarrelEmpty[i - 1])
                    {
                        //遇到的第一个不空的，使用它后面的位置
                        GamePlay.instance.BarrelQueue.Enqueue(stackableBulletVo);
                        GamePlay.instance.IsBarrelEmpty[i] = false;
                        endPos = GamePlay.instance.UI.path[i].transform.position;
                        stackableBulletVo.BarrelIndex = i;
                        isSet = true;
                        break;
                    }
                }

                if (!isSet)
                {
                    GamePlay.instance.BarrelQueue.Enqueue(stackableBulletVo);
                    GamePlay.instance.IsBarrelEmpty[0] = false;
                    endPos = GamePlay.instance.UI.path[0].transform.position;
                    stackableBulletVo.BarrelIndex = 0;
                }

                var duration = Vector3.Distance(startPos, endPos) / BulletJumpToBarrelSpeed;
                _movingBulletNum++;
                bulletTr.DOMove(endPos, duration).SetEase(Ease.Linear).onComplete += () =>
                {
                    _movingBulletNum--;

                    EntityManager.instance.AddEntity(stackableBulletVo);
                    GamePlay.instance.PlayBarrelAnimation();
                };

                //等待装弹间隔结束
                DOVirtual.DelayedCall(LoadBulletInterval, () => { payload.IsFinished = true; });
            };
        }

        private void DropBox()
        {
            var gameData = GamePlay.instance.GamePlayData;

            _dropBoxAnimNum++;

            _boxVo.State = BoxState.PlaceHolder;
            EntityManager.instance.RemoveEntity(_boxVo);
            gameData.SlotSet.Remove(_boxVo);
            gameData.IsSlotEmpty[_boxVo.SlotIndex] = true;

            _dropBoxAnimNum--;

            var box = _boxVo.Item as Box;
            AudioFacade.instance.PlayClip("Sound_BoxDiscard", false);
            box.AnimationUseUp((() =>
            {
                _boxVo.Cir.Dispose();
                GamePlay.instance.CheckGameWin();//
            }));
        }

        private void NotifyOtherSlotLoadBullet()
        {
            var gameData = GamePlay.instance.GamePlayData;
            foreach (var boxVo in gameData.SlotSet)
            {
                if(boxVo == _boxVo)//排除自己，因为自己已经能装的都装完了
                    continue;
                var skill = new LoadBullet(boxVo);
                SkillManager.instance.UseSkill(skill);
            }
        }

        public static void ForceLoadBullet()
        {
            foreach (var boxVo in GamePlay.instance.GamePlayData.SlotSet)
            {
                var skill = new LoadBullet(boxVo);
                SkillManager.instance.UseSkill(skill);
                boxVo.IsLoadBullet = true;
            }
        }
    }
}