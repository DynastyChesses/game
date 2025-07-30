using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using HotUpdate.osP1.ValueObject;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem.Skill
{
    public class BoxMatrixMoveUp : BaseSkill
    {
        private int _boxRow;
        private int _boxCol;

        //animation params
        public const float BoxMatrixMoveUpDuration = 0.33f;
        
        public static bool IsAnimationFinished => IsAllowClick.All(value => value == true);

        public static List<bool> IsAllowClick;
        

        public BoxMatrixMoveUp(int boxRow,int boxCol)
        {
            _boxRow = boxRow;
            _boxCol = boxCol;
        }

        public new static void GlobalStart()
        {
            IsAllowClick = new List<bool>();
            for (int i = 0; i < GamePlay.instance.GamePlayData.BoxDisplayCol; i++)
            {
                IsAllowClick.Add(true);
            }
            
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

            IsAllowClick[_boxCol] = false;

            var gameData = GamePlay.instance.GamePlayData;
            
            var box = gameData.BoxView[_boxRow][_boxCol].render as ICommonBox;

            var firstBox = gameData.BoxVo[0][_boxCol];
            firstBox.Row = -1;//防止被点击
            
            
            //hide choose box
            box.CanvasGroup.alpha = 0;
            box.CanvasGroup.interactable = false;
            box.CanvasGroup.blocksRaycasts = false;

            
            if (IsCutDown(out var normalMoveUpperLimitIndex, out var boxGeneratorVo))
            {
                var vo = boxGeneratorVo.BoxQueue.Dequeue();
                if (GamePlay.instance.Fever.IsFever)
                {
                    foreach (var stackableBulletVo in vo.Bullets)
                    {
                        stackableBulletVo.IsFeverStackableBullet = true;
                    }
                }
                boxGeneratorVo.ChildNumber--;
                if (boxGeneratorVo.ChildNumber == 0)
                    boxGeneratorVo.State = BoxState.PlaceHolder;
                
                var countAnim = 0;
                var totalAnim = normalMoveUpperLimitIndex + 1; // 上移数量 + 出盒数量(1)
                if (boxGeneratorVo.ChildNumber == 0)//如果box没了，需要他播放消失动画，所以会+1
                    totalAnim += 1;
                
                vo = GamePlay.instance.LevelData.UpgradeSpecialBox(vo, _boxCol, true);
                vo.Row = -1;//设置一个非零值，为了不显示描边，后续动画完成后会赋值正确的Row
                
                var cir = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
                cir.data = vo;
                
                Action lambda = () =>
                {
                    countAnim++;
                    if (countAnim == totalAnim)
                        OnAnimationFinished4CutDown(normalMoveUpperLimitIndex, vo, cir);
                };
                
                if(boxGeneratorVo.ChildNumber == 0)
                    IsAllowClick[boxGeneratorVo.Col] = false;

                //出盒动画
                cir.initCallBack += () =>
                {
                    var boxGenerator = gameData.BoxView[boxGeneratorVo.Row][boxGeneratorVo.Col].render as BoxGenerator;
                    boxGenerator.AnimationProduct(boxGeneratorVo.Direction);
                    
                    cir.gameObject.transform.SetAsFirstSibling();
                    
                    var startPos = gameData.BoxPos[boxGeneratorVo.Row][boxGeneratorVo.Col];
                    var endPos = boxGeneratorVo.Direction == BoxGeneratorDirection.up
                        ? gameData.BoxPos[boxGeneratorVo.Row - 1][_boxCol]
                        : gameData.BoxPos[boxGeneratorVo.Row][_boxCol];

                   

                    var commonBox = cir.render as ICommonBox;
                    switch (boxGeneratorVo.Direction)
                    {
                        case BoxGeneratorDirection.left:
                            commonBox.AnimationMoveLeft(startPos,endPos, lambda);
                            break;
                        case BoxGeneratorDirection.right:
                            commonBox.AnimationMoveRight(startPos,endPos, lambda);
                            break;
                        case BoxGeneratorDirection.up:
                            commonBox.AnimationMoveUp(startPos,endPos, lambda);
                            break;
                    }
                    
                    //render box generator
                    if (boxGeneratorVo.ChildNumber != 0)
                    {
                        gameData.PassVo2BoxView(boxGeneratorVo.Row, boxGeneratorVo.Col);
                    }
                    else
                    {
                        boxGenerator.AnimationDisappear(() =>
                        {
                            gameData.PassVo2BoxView(boxGeneratorVo.Row, boxGeneratorVo.Col);
                        
                            var startRowIndex = boxGeneratorVo.Row + 1;
                            var colIndex = boxGeneratorVo.Col;
                            var countAnim1 = 0;
                            var totalAnim1 = gameData.BoxDisplayRow - startRowIndex;

                            for (int i = startRowIndex; i < gameData.BoxDisplayRow; i++)
                            {
                                var moveVo = gameData.BoxVo[i][colIndex];
                                moveVo.IsMoving = true;

                                var commonBox = gameData.BoxView[i][colIndex].render as ICommonBox;
                                var startPos = gameData.BoxPos[i][colIndex];
                                var endPos = gameData.BoxPos[i - 1][colIndex];
                                commonBox.AnimationMoveUp(startPos,endPos, (() =>
                                {
                                    moveVo.IsMoving = false;
                                    countAnim1++;
                                    if (countAnim1 == totalAnim1)
                                    {
                                        OnBoxGeneratorAnimationFinished(boxGeneratorVo);
                                        lambda.Invoke();
                                    }
                                }));
                            }
                        });
                    }
                };

                //盒子上移动画
                for (var i = _boxRow + 1; i <= _boxRow + normalMoveUpperLimitIndex; i++)
                {
                    var moveVo = gameData.BoxVo[i][_boxCol];
                    moveVo.IsMoving = true;
                    var commonBox = gameData.BoxView[i][_boxCol].render as ICommonBox;
                    var startPos = gameData.BoxPos[i][_boxCol];
                    var endPos = gameData.BoxPos[i - 1][_boxCol];
                    commonBox.AnimationMoveUp(startPos,endPos, (() =>
                    {
                        moveVo.IsMoving = false;
                        lambda.Invoke();
                    }));
                }
                
                
            }
            else
            {
                var animFinishedNum = 0;
                var totalAnim = gameData.BoxDisplayRow - (1 + _boxRow);
                for (var i = _boxRow + 1; i < gameData.BoxDisplayRow; i++)
                {
                    var moveVo = gameData.BoxVo[i][_boxCol];
                    moveVo.IsMoving = true;

                    var commonBox = gameData.BoxView[i][_boxCol].render as ICommonBox;
                    var startPos = gameData.BoxPos[i][_boxCol];
                    var endPos = gameData.BoxPos[i - 1][_boxCol];
                    commonBox.AnimationMoveUp(startPos,endPos, () =>
                    {
                        moveVo.IsMoving = false;
                        animFinishedNum++;
                        if (animFinishedNum == totalAnim)
                            OnAnimationFinished();
                        
                    });
                }
            }
        }
        
        private bool IsCutDown(out int normalMoveUpperLimitIndex,out BoxGeneratorVo boxGeneratorVo)
        {
            var gameData = GamePlay.instance.GamePlayData;

            var row = 100;

            normalMoveUpperLimitIndex = -1;
            boxGeneratorVo = null;
            var ret = false;
            
            //check up
            for (int i = _boxRow + 1; i < gameData.BoxDisplayRow; i++)
            {
                if (gameData.BoxVo[i][_boxCol] is BoxGeneratorVo vo)
                {
                    if (vo.IsActive && vo.Direction == BoxGeneratorDirection.up)
                    {
                        normalMoveUpperLimitIndex = vo.Row - 1 - _boxRow;
                        boxGeneratorVo = vo;
                        row = vo.Row;
                        ret = true;
                    }
                }
            }

            //check left
            if (_boxCol - 1 >= 0)
            {
                for (int i = _boxRow; i < gameData.BoxDisplayRow; i++)
                {
                    if (gameData.BoxVo[i][_boxCol - 1] is BoxGeneratorVo vo)
                    {
                        if(vo.Row >= row)
                            break;
                        
                        if (vo.IsActive && vo.Direction == BoxGeneratorDirection.right && !vo.IsMoving)
                        {
                            normalMoveUpperLimitIndex = vo.Row - _boxRow;
                            boxGeneratorVo = vo;
                            row = vo.Row;
                            ret = true;
                        }
                    }
                }
            }

            //check right
            if (_boxCol + 1 < gameData.BoxDisplayCol)
            {
                for (int i = _boxRow; i < gameData.BoxDisplayRow; i++)
                {
                    if (gameData.BoxVo[i][_boxCol + 1] is BoxGeneratorVo vo)
                    {
                        if(vo.Row >= row)
                            break;
                        
                        if (vo.IsActive && vo.Direction == BoxGeneratorDirection.left && !vo.IsMoving)
                        {
                            
                            
                            normalMoveUpperLimitIndex = vo.Row - _boxRow;
                            boxGeneratorVo = vo;
                            row = vo.Row;
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        private void OnAnimationFinished()
        {
            //从底向上升，会创建新的
            
            var gameData = GamePlay.instance.GamePlayData;


            if (GamePlay.instance.LevelId != 1)
            {
                //vo
                for (int i = _boxRow; i < gameData.BoxDisplayRow - 1; i++)
                {
                    gameData.BoxVo[i][_boxCol] = gameData.BoxVo[i + 1][_boxCol];
                }

                gameData.BoxVo[gameData.BoxDisplayRow - 1][_boxCol] =
                    GamePlay.instance.LevelData.UpgradeSpecialBox(GamePlay.instance.LevelData.GetOneBox(), _boxCol);
                
                if (GamePlay.instance.Fever.IsFever)
                {
                    foreach (var stackableBulletVo in gameData.BoxVo[gameData.BoxDisplayRow - 1][_boxCol].Bullets)
                    {
                        stackableBulletVo.IsFeverStackableBullet = true;
                    }
                }
            }
            else
            {
                for (int i = _boxRow; i < gameData.BoxVo.Count - 1; i++)
                {
                    gameData.BoxVo[i][_boxCol] = gameData.BoxVo[i + 1][_boxCol];
                }

                gameData.BoxVo[^1][_boxCol] = new BoxVo(BoxState.PlaceHolder);
            }
            
            gameData.AssignBoxRowCol();

            //view
            for (int i = _boxRow; i < gameData.BoxDisplayRow - 1; i++)
            {
                if (i == _boxRow)
                {
                    gameData.BoxView[i][_boxCol].Dispose();
                    gameData.BoxView[i][_boxCol] = null;
                }

                gameData.BoxView[i][_boxCol] = gameData.BoxView[i + 1][_boxCol];
            }

            var cir = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
            gameData.BoxView[gameData.BoxDisplayRow - 1][_boxCol] = cir;

            cir.data = gameData.BoxVo[gameData.BoxDisplayRow - 1][_boxCol];
            cir.initCallBack += () =>
            {
                gameData.BoxView[gameData.BoxDisplayRow - 1][_boxCol].gameObject.transform
                    .position = gameData.BoxPos[gameData.BoxDisplayRow - 1][_boxCol];
                
                //创建完成后进行，进行渲染，避免最后一个没有创建完，盒子就可以被点击
                
                for (int i = _boxRow; i < gameData.BoxDisplayRow; i++)
                {
                    //渲染
                    gameData.PassVo2BoxView(i, _boxCol);
                }
                IsAllowClick[_boxCol] = true;
                
            };
            
            CheckStamp();
        }

        private void OnAnimationFinished4CutDown(int moveUpNum, BoxVo vo, CommonItemRenderer itemRenderer)
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            //vo
            for (int i = _boxRow; i < _boxRow + moveUpNum; i++)
            {
                gameData.BoxVo[i][_boxCol] = gameData.BoxVo[i + 1][_boxCol];
            }

            gameData.BoxVo[_boxRow+moveUpNum][_boxCol] = vo;

            gameData.AssignBoxRowCol();

            //view
            gameData.BoxView[_boxRow][_boxCol].Dispose();
            gameData.BoxView[_boxRow][_boxCol] = null;
            for (int i = _boxRow; i < _boxRow + moveUpNum; i++)
            {
                gameData.BoxView[i][_boxCol] = gameData.BoxView[i + 1][_boxCol];
            }

            gameData.BoxView[_boxRow + moveUpNum][_boxCol] = itemRenderer;
            
            //渲染
            for (int i = _boxRow; i < gameData.BoxDisplayRow; i++)
            {
                gameData.PassVo2BoxView(i, _boxCol);
            }
            
            IsAllowClick[_boxCol] = true;
        }

        private void OnBoxGeneratorAnimationFinished(BoxGeneratorVo vo)
        {
            //从底向上升，会创建新的
            
            var gameData = GamePlay.instance.GamePlayData;
            
            //vo
            for (int i = vo.Row; i < gameData.BoxDisplayRow - 1; i++)
            {
                gameData.BoxVo[i][vo.Col] = gameData.BoxVo[i + 1][vo.Col];
            }

            gameData.BoxVo[gameData.BoxDisplayRow - 1][vo.Col] =
                GamePlay.instance.LevelData.UpgradeSpecialBox(GamePlay.instance.LevelData.GetOneBox(), vo.Col);
            
            if (GamePlay.instance.Fever.IsFever)
            {
                foreach (var stackableBulletVo in gameData.BoxVo[gameData.BoxDisplayRow - 1][vo.Col].Bullets)
                {
                    stackableBulletVo.IsFeverStackableBullet = true;
                }
            }
            
            gameData.AssignBoxRowCol();
            
            //view
            for (int i = vo.Row; i < gameData.BoxDisplayRow - 1; i++)
            {
                if (i == vo.Row)
                {
                    gameData.BoxView[i][vo.Col].Dispose();
                    gameData.BoxView[i][vo.Col] = null;
                }

                gameData.BoxView[i][vo.Col] = gameData.BoxView[i + 1][vo.Col];
            }

            var cir = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
            cir.data = gameData.BoxVo[gameData.BoxDisplayRow - 1][vo.Col];
            cir.initCallBack += () =>
            {
                gameData.BoxView[gameData.BoxDisplayRow - 1][vo.Col].gameObject.transform
                    .position = gameData.BoxPos[gameData.BoxDisplayRow - 1][vo.Col];
                
                
                for (int i = vo.Row; i < gameData.BoxDisplayRow; i++)
                {
                    gameData.PassVo2BoxView(i, vo.Col);
                }
                
                IsAllowClick[vo.Col] = true;
            };
            gameData.BoxView[gameData.BoxDisplayRow - 1][vo.Col] = cir;

            CheckStamp();
        }

        private void CheckStamp()
        {
            var gameData = GamePlay.instance.GamePlayData;
            for (int i = 0; i < gameData.BoxVisibleRow; i++)
            {
                if (gameData.BoxVo[i][_boxCol].State == BoxState.PlaceHolder && !gameData.IsStampCover[i][_boxCol])
                {
                    gameData.IsStampCover[i][_boxCol] = true;
                    //logic play
                    var goldBox = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
                    var goldBoxVo = new GoldBoxVo(BoxState.InMatrix);
                    goldBox.data = goldBoxVo;
                    var iLambda = i;
                    goldBox.initCallBack += () =>
                    {
                        goldBox.gameObject.transform.position = gameData.BoxPos[iLambda][_boxCol];
                    };
                    
                    gameData.StampCover.Add(goldBox);
                }
            }
        }


        public override void SkillUpdate(UpdateTimeInfo time)
        {
            base.SkillUpdate(time);
        }

        public override void SkillEnd()
        {
            base.SkillEnd();
        }
    }
}