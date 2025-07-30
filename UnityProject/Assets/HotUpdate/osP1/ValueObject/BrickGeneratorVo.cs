using System;
using System.Collections.Generic;
using DG.Tweening;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using Spine.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HotUpdate.osP1.ValueObject
{
    public class BrickGeneratorVo : BrickVo
    {
        public static bool IsGenerating => _generatingNum != 0;
        private static int _generatingNum = 0;
        
        private static readonly Vector2[] GeneratePos = new[]
        {
            new Vector2(-1, -1),
            new Vector2(-1, 0),
            new Vector2(-1, 1),

            new Vector2(0, -1),
            new Vector2(0, 1),

            new Vector2(1, -1),
            new Vector2(1, 0),
            new Vector2(1, 1),
        };
        
        private Dictionary<BattleColor, string> _colorSkinRelation = new Dictionary<BattleColor, string>()
        {
            { BattleColor.Yellow, "h" },
            { BattleColor.Blue, "l" },
            { BattleColor.Cyan, "q" },
            { BattleColor.Red, "r" },
            { BattleColor.Pink, "f" },
            { BattleColor.Green, "lv" },
            { BattleColor.Purple, "zi" },
            { BattleColor.Brown, "z" }
        };
        
        private List<(int,int)> _bricks = new List<(int,int)>();

        public BrickGeneratorVo(BrickState state) : base(state)
        {
        }

        public override BrickVo Clone()
        {
            var brickVo = new BrickGeneratorVo(State);
            brickVo._bricks = _bricks;
            CopyValue(brickVo,this);
            return brickVo;
        }

        public override void BeforeDead()
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            foreach (var bias in GeneratePos)
            {
                var row = Row + (int)bias.x;
                var col = Col + (int)bias.y;
                
                if(row < 0 || row > gameData.BrickVoExtraRowIndex)
                    continue;
                
                if(col < 0 || col >= gameData.BrickDisplayCol)
                    continue;
                
                
                var brick = gameData.BrickVo[row][col];
                
                //brick.Life > 0，是因为 LoadBullet 里 AimBrickInBrickGenerator 会消除生命
                if (GenerateGroup == brick.GenerateGroup && brick.Life > 0)
                {
                    brick.State = BrickState.Live;
                    _bricks.Add((row, col));
                    
                }
            }
            
            _generatingNum++;
        }

        public override void AfterDead(Action callback = null)
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            var countAnim = 0;
            var totalAnim = _bricks.Count;
            Action afterDeadCallback = () =>
            {
                countAnim++;
                if (countAnim == totalAnim)
                {
                    callback?.Invoke();
                    _generatingNum--;
                    
                    
                }
            };
            foreach (var (row, col) in _bricks)
            {
                var request = ResourceFacade.instance.LoadPrefabAsync("Games/osP1/ShardAnim");
                request.callback += resourceRequest =>
                {
                    var count = 0;
                    var total = 2;
                    
                    
                    var brick = gameData.BrickVo[row][col];
                    var cir = gameData.BrickView[row - gameData.IndexBias][col];
                    var gameObject = resourceRequest.asset as GameObject;
                    gameObject.transform.SetParent(GamePlay.instance.UI.gameObject.transform);
                    gameObject.transform.localScale = Vector3.one;
                    
                    Action lambda = () =>
                    {

                        count++;
                        if (count == total)
                        {
                            brick.State = BrickState.Live;
                            (brick.Item as ICommonBrick).Revive(); //cir不是新创建的，所以不会执行replace，所以使用Revive替代
                            cir.data = brick;
                            cir.gameObject.transform.position = gameData.BrickPos[row - gameData.IndexBias][col];
                            
                            //动画
                            (brick.Item as ICommonBrick).AnimAdd();
                            
                            
                            afterDeadCallback.Invoke();
                        }
                        
                    };
                    
                    
                    var skeletonGraphic = gameObject.GetComponent<SkeletonGraphic>();
                    skeletonGraphic.Skeleton.SetSkin(_colorSkinRelation[brick.Color]);
                    var trackEntry = skeletonGraphic.AnimationState.SetAnimation(0, "fly", false);
                    trackEntry.Event += (entry, @event) =>
                    {
                        if (@event.Data.Name == "add")
                        {
                            lambda.Invoke();
                        }
                    };
                    trackEntry.Complete += entry => Object.Destroy(gameObject);
                    
                    
                    var endPos = gameData.BrickPos[row - gameData.IndexBias][col];
                    var duration = skeletonGraphic.SkeletonData.FindAnimation("fly").Duration;
                    gameObject.transform.position = Item.gameObject.transform.position;
                    gameObject.transform.DOMove(endPos, duration).onComplete += lambda.Invoke;
                    
                    request.Dispose();
                };
                
                
                
            }
            _bricks.Clear();
            
        }

        public void ReviveData4BrickVo(int row1, int col1)
        {
            var gameData = GamePlay.instance.GamePlayData;

            foreach (var bias in GeneratePos)
            {
                var row = row1 + (int)bias.x;
                var col = col1 + (int)bias.y;
                
                if(row < 0 || row > gameData.BrickVoExtraRowIndex)
                    continue;
                
                if(col < 0 || col >= gameData.BrickDisplayCol)
                    continue;
                
                var brick = gameData.Data4BrickVo[row][col];
                
                if (GenerateGroup == brick.GenerateGroup)
                {
                    brick.State = BrickState.Live;
                }

            }
        }
        
        
    }
}