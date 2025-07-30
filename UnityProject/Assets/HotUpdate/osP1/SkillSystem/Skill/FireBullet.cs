using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.ValueObject;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class FireBullet : BaseSkill
    {
        public static bool IsAnimationFinished =>
            _animPayload.IsFinished && 
            _animQueue.Count == 0 && 
            _animPayloadPriority.IsFinished &&
            _animQueuePriority.Count == 0 && 
            _firedBullet == 0 && 
            NeedWaitItem == 0 && 
            !_isFire;

        private static int _firedBullet;

        public static int NeedWaitItem;


        private static Queue<Action<AnimPayload>> _animQueue;
        private static AnimPayload _animPayload;

        private static Queue<Action<AnimPayload>> _animQueuePriority;
        private static AnimPayload _animPayloadPriority;


        private BrickVo _brickVo;
        private BaseScriptItemRendererView _brickView;

        private StackableBulletVo _stackableBulletVo;

        private static bool _isFire;

        //animation params
        public static float BulletFireSpeed =
            float.Parse(MetaManager.instance.Meta.TbKV.DataMap["bullet_fire_speed"].Value);

        private float FireInterval = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fire_interval"].Value);

        private float Barrel2HandSpeed =
            float.Parse(MetaManager.instance.Meta.TbKV.DataMap["barrel_to_hand_speed"].Value);


        public FireBullet(StackableBulletVo stackableBulletVo)
        {
            var gameData = GamePlay.instance.GamePlayData;

            _stackableBulletVo = stackableBulletVo;
        }

        public new static void GlobalStart()
        {
            _animQueue = new Queue<Action<AnimPayload>>();
            _animPayload = new AnimPayload
            {
                IsFinished = true
            };
            _animQueuePriority = new Queue<Action<AnimPayload>>();
            _animPayloadPriority = new AnimPayload()
            {
                IsFinished = true
            };

            NeedWaitItem = 0;
            _firedBullet = 0;
            _isFire = false;
        }

        public new static void GlobalUpdate(UpdateTimeInfo time)
        {
            if (GamePlay.instance.BarrelQueue.Count > 0)
            {
                var stackableBulletVo = GamePlay.instance.BarrelQueue.Peek();
                if (stackableBulletVo.IsReady && !_isFire)
                {
                    _isFire = true;
                    for (int i = 0; i < stackableBulletVo.Number; i++)
                    {
                        var skill = new FireBullet(stackableBulletVo);
                        SkillManager.instance.UseSkill(skill);
                        EntityManager.instance.RemoveEntity(stackableBulletVo);
                    }
                }
            }

            if (!_animPayload.IsFinished || !_animPayloadPriority.IsFinished)
                return;

            if (_animQueuePriority.Count > 0) //虽然是优先队列，但是现在只有砖块矩阵下落动画
            {
                if (_firedBullet != 0)
                    return; //等当前子弹的动画都播完了再下来
                if (NeedWaitItem != 0)
                    return; //锤子
                if (GamePlay.instance.GamePlayData.IsBrickMatrixMoving())
                    return; //矩阵整体移动的时候需要等待
                
                _animPayloadPriority.IsFinished = false;
                var func = _animQueuePriority.Dequeue();
                func(_animPayloadPriority);
                return;
            }

            if (_animQueue.Count > 0 && !BrickGeneratorVo.IsGenerating &&
                !GamePlay.instance.GamePlayData.IsBrickMatrixLastRowMoving())
            {
                //保证进入的时候最后一排已经到位
                _animPayload.IsFinished = false;
                var func = _animQueue.Dequeue();
                func(_animPayload);
            }
        }

        public new static void GlobalEnd()
        {
        }

        public override void SkillStart()
        {
            base.SkillStart();

            _animQueue.Enqueue(payload => Fire(payload));

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


        private void Fire(AnimPayload payload)
        {
            var gameData = GamePlay.instance.GamePlayData;

            _brickVo = gameData.BrickVo[_stackableBulletVo.AttackTargetRow][_stackableBulletVo.AttackTargetCol];
            var rowIndex = _stackableBulletVo.AttackTargetRow - gameData.IndexBias;
            bool isInBrickMatrix;
            if (rowIndex < 0)
            {
                isInBrickMatrix = false;
            }
            else
            {
                isInBrickMatrix = true;
                _brickView =
                    gameData.BrickView[_stackableBulletVo.AttackTargetRow - gameData.IndexBias][
                        _stackableBulletVo.AttackTargetCol];
            }


            _firedBullet++;


            _brickVo.Life--;
            if (_brickVo.Life == 0)
            {
                _brickVo.State = BrickState.Dead;

                _brickVo.BeforeDead();

                if (gameData.IsLastRowBrickAllDead() && gameData.IsExtraRowBrickAllDead())
                {
                    _animQueuePriority.Enqueue(BrickMatrixMoveDown);
                }
                else
                {
                    gameData.SetAllSlotNotLoad();
                }
            }

            var currentBrickVo = _brickVo.Clone();

            //可堆叠子弹，飞到开火点
            //render update -> stackableBullet
            var vo = _stackableBulletVo;
            var newSBulletVo = vo.Clone();
            newSBulletVo.Number = 1;
            var fakeStackableBullet = new CommonItemRenderer(GamePlay.instance.UI.bg.transform);
            fakeStackableBullet.data = newSBulletVo;
            fakeStackableBullet.initCallBack += () =>
            {
                //dispose之前获取
                var startPos = vo.Item.viewObject.transform.position;

                vo.Number--;
                if (vo.Number == 0)
                {
                    GamePlay.instance.IsBarrelEmpty[0] = true;
                    GamePlay.instance.BarrelQueue.Dequeue();
                    _isFire = false;
                    vo.CommonItemRenderer.Dispose();
                }
                else
                {
                    vo.CommonItemRenderer.data = vo;
                }

                var fakeStackableBulletTr = fakeStackableBullet.gameObject.transform;
                fakeStackableBulletTr.position = startPos;
                fakeStackableBulletTr.localScale = Vector3.one * StackableBulletVo.StackableBulletScaleInScene;

                var firePos = GamePlay.instance.UI.firePoint.transform.position;
                var durationStart2Fire = Vector3.Distance(startPos, firePos) / Barrel2HandSpeed;
                fakeStackableBulletTr.DOMove(firePos, durationStart2Fire).SetEase(Ease.Linear).onComplete += () =>
                {
                    //子弹，攻击砖块
                    var bulletVo = new BulletVo();
                    bulletVo.Color = _stackableBulletVo.Color;
                    bulletVo.IsFeverBullet = _stackableBulletVo.IsFeverStackableBullet;
                    var rowIndex = _brickVo.Row - gameData.IndexBias; //有可能会攻击到未显示的砖块，此时动画表现上攻击 显示的砖块 最后一排中间的
                    if (rowIndex >= 0)
                        bulletVo.TargetPos = gameData.BrickPos[_brickVo.Row - gameData.IndexBias][_brickVo.Col];
                    else
                        bulletVo.TargetPos = gameData.BrickPos[0][3];

                    var bulletCir = new CommonItemRenderer(GamePlay.instance.UI.bg.transform);
                    bulletCir.data = bulletVo;
                    bulletCir.initCallBack += () =>
                    {
                        var isAddFeverEnergy = bulletVo.Color == _brickVo.Color; //非彩虹球才会增加fever能量
                        GamePlay.instance.Fever.AddCombo(isAddFeverEnergy);

                        var capybaraVo = new CapybaraVo();
                        capybaraVo.CapybaraAction = GamePlay.instance.Fever.IsFever
                            ? CapybaraAction.AttackHighForm
                            : CapybaraAction.AttackLowForm;
                        GamePlay.instance.Capybara.data = capybaraVo;

                        fakeStackableBullet.Dispose();


                        var endPos = bulletVo.TargetPos;

                        var bullet = bulletCir.render as Bullet;
                        AudioFacade.instance.PlayClip("Sound_Shoot", false);
                        bullet.AnimMove(firePos, endPos, bulletCir, () =>
                        {
                            GamePlay.instance.KillOneLife(currentBrickVo.Color);

                            if (isInBrickMatrix)
                                _brickView.data = currentBrickVo;

                            if (currentBrickVo.State == BrickState.Dead)
                            {
                                AudioFacade.instance.PlayClip("Sound_Die", false);

                                if (currentBrickVo.IsGuideFever)
                                {
                                    GamePlay.instance.Fever.GuideFillEnergy();
                                    if (GamePlay.instance.IsGuideMode && GamePlay.instance.GuidePhase == 5)
                                    {
                                        ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GuideNextPhase);
                                        GamePlay.instance.GuidePhase++;
                                    }
                                }

                                //brickGeneratorVo需要等待其死亡之后再施放子弹，否则可能出现问题
                                bool isWaitDead = currentBrickVo is BrickGeneratorVo;

                                if (isInBrickMatrix)
                                {
                                    var commonBrick = (_brickView as CommonItemRenderer).render as ICommonBrick;
                                    commonBrick.AnimationDead((() =>
                                    {
                                        if (isWaitDead)
                                        {
                                            _firedBullet--;

                                            GamePlay.instance.CheckGameWin();
                                        }
                                    }));
                                }

                                if (!isWaitDead)
                                {
                                    _firedBullet--;

                                    GamePlay.instance.CheckGameWin();
                                }
                            }
                            else
                            {
                                _firedBullet--;

                                if (rowIndex >= 0) //有可能会攻击到未显示的砖块
                                {
                                    //anim hurt
                                    AudioFacade.instance.PlayClip("Sound_Hit", false);
                                    (_brickVo.Item as ICommonBrick).AnimationHurt();
                                }
                            }
                        });
                    };
                };
            };


            DOVirtual.DelayedCall(FireInterval, (() => { payload.IsFinished = true; }));
        }

        private static void BrickMatrixMoveDown(AnimPayload payload)
        {
            var gameData = GamePlay.instance.GamePlayData;

            
            for (var i = 0; i < gameData.BrickDisplayRow - 1; i++)
            for (var j = 0; j < gameData.BrickDisplayCol; j++)
            {
                var brickVo = gameData.BrickVo[i + gameData.IndexBias][j];
                var brick = gameData.BrickVo[i + gameData.IndexBias][j].Item;


                var endPos = gameData.BrickPos[i + 1][j];
                brickVo.IsMoving = true;
                (brick as ICommonBrick).AnimationMove(endPos, (gameData.BrickDisplayRow - 2 - i) * 0.1f,
                    (() => { brickVo.IsMoving = false; }));
            }

            UpdateMatrixVo();

            //需要等待最后一排创建完
            UpdateMatrixView((() => { payload.IsFinished = true; }));

            if (gameData.IsLastRowBrickAllDead() && !gameData.IsBrickAllDead()) //有一行为空的话，处理
                _animQueuePriority.Enqueue(BrickMatrixMoveDown);
            else
            {
                gameData.SetAllSlotNotLoad();
            }
        }

        private static void UpdateMatrixVo()
        {
            var gameData = GamePlay.instance.GamePlayData;

            for (var i = gameData.BrickVoExtraRowIndex; i > 0; i--)
            {
                for (var j = 0; j < gameData.BrickDisplayCol; j++)
                {
                    gameData.BrickVo[i][j] = gameData.BrickVo[i - 1][j];
                }
            }

            for (var j = 0; j < gameData.BrickDisplayCol; j++)
            {
                gameData.BrickVo[gameData.BrickVoFirstRowIndex][j] = new BrickVo(BrickState.Dead);
            }

            gameData.AssignBrickRowCol();
            BombVo.CheckBombActive();
        }

        private static void UpdateMatrixView(Action callback)
        {
            var gameData = GamePlay.instance.GamePlayData;

            for (var i = gameData.BrickViewExtraRowIndex; i > 0; i--)
            for (var j = 0; j < gameData.BrickDisplayCol; j++)
            {
                if (i == gameData.BrickViewExtraRowIndex)
                {
                    gameData.BrickView[i][j].Dispose();
                    gameData.BrickView[i][j] = null;
                }

                gameData.BrickView[i][j] = gameData.BrickView[i - 1][j];
            }

            var count = 0;
            var total = gameData.BrickDisplayCol;
            for (int j = 0; j < gameData.BrickDisplayCol; j++)
            {
                var index = gameData.BrickViewFirstRowIndex;

                gameData.BrickView[index][j] = new CommonItemRenderer(GamePlay.instance.UI.brickLayout);

                gameData.PassVo2BrickView(index + gameData.IndexBias, j);

                //设置位置
                var iLambda = index;
                var jLambda = j;
                gameData.BrickView[index][j].initCallBack += () =>
                {
                    gameData.BrickView[iLambda][jLambda].gameObject.transform.position =
                        gameData.BrickPos[iLambda][jLambda];

                    count++;
                    if (count == total)
                    {
                        callback?.Invoke();
                    }
                };
            }
        }

        public static void ExternBrickMatrixMoveDown()
        {
            _animQueuePriority.Enqueue(BrickMatrixMoveDown);
        }
    }
}