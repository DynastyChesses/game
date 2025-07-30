using System;

namespace HotUpdate.osP1.ValueObject
{
    public class BombVo: BrickVo
    {
        public int CountDown;

        public bool IsLaunch;

        public bool IsAlreadyBoom;
        
        public bool IsInActiveRow => Row > (GamePlay.instance.GamePlayData.BrickVoLastRowIndex - CountDownRow);

        
        private static readonly int CountDownRow = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["countDown_row"].Value);

        public static void UpdateCountDown()
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            foreach (var row in gameData.BrickVo)
            {
                foreach (var vo in row)
                {
                    if (vo is BombVo bombVo)
                    {
                        if (bombVo.IsInActiveRow && bombVo.State == BrickState.Live && !bombVo.IsAlreadyBoom)
                        {
                            bombVo.CountDown--;
                            gameData.BrickView[bombVo.Row - gameData.IndexBias][bombVo.Col].data = bombVo;
                            if (bombVo.CountDown <= 0)
                            {
                                bombVo.IsAlreadyBoom = true;
                                var bomb = gameData.BrickView[bombVo.Row - gameData.IndexBias][bombVo.Col].render as Bomb;
                                AudioFacade.instance.PlayClip("Sound_Boom",false);

                                
                                GamePlay.instance.CheckGameOver(GameOverType.Bomb);
                                
                                GamePlay.instance.BombBoomNum++;
                                bomb.AnimationBoom((() =>
                                {
                                    GamePlay.instance.BombBoomNum--;
                                }));
                                
                                
                            }
                        }
                    }
                }
            }
        }

        public static void CheckBombActive()
        {
            var gameData = GamePlay.instance.GamePlayData;
            
            foreach (var row in gameData.BrickVo)
            {
                foreach (var vo in row)
                {
                    if (vo is BombVo bombVo)
                    {
                        if (bombVo.IsInActiveRow && bombVo.State == BrickState.Live && !bombVo.IsLaunch)
                        {
                            bombVo.IsLaunch = true;
                        }
                    }
                }
            }
        }
        
        
        public BombVo(BrickState state) : base(state)
        {
            
        }

        public override BrickVo Clone()
        {
            var bombVo = new BombVo(State)
            {
                CountDown = CountDown,
                IsLaunch = IsLaunch,
            };
            CopyValue(bombVo,this);

            return bombVo;
        }
        
        

        
        
    }
}