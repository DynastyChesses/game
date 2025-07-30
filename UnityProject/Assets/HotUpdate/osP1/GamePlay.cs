using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace HotUpdate.osP1
{
    public enum GameOverType
    {
        SlotFilled,
        Bomb,
        Timeout
    }
    
    public class AnimPayload
    {
        public bool IsFinished;
    }


    public class GamePlay : Singleton<GamePlay>
    {

        public bool IsFreezePlayerInput = false;

        public bool IsGameWin => _isGameWin;
        public bool IsGameOver => _isGameOver;
        
        public GamePlayData GamePlayData { get; private set; }

        public GamePlaySkin UI { get; private set; }

        //level config
        public LevelData LevelData { get; private set; }
        
        public int LevelId { get; private set; }

        //target
        public WinCondition WinCondition { get; private set; }
        public int NeedKillNum { get; private set; }

        public Dictionary<BattleColor, int> SpecificNeedKillNum { get; private set; } =
            new Dictionary<BattleColor, int>();

        public int KillTotalProgress { get; private set; }

        public float CurrentKillProgress => WinCondition switch
        {
            WinCondition.Any => (float)(KillTotalProgress - NeedKillNum) / KillTotalProgress,
            WinCondition.Specific => (float)(KillTotalProgress - SpecificNeedKillNum.Sum(pair => pair.Value)) /
                                     KillTotalProgress,
        };

        //barrel
        public int BarrelCapacity => UI.path.length;
        public Queue<StackableBulletVo> BarrelQueue { get; private set; } = new Queue<StackableBulletVo>();
        public List<bool> IsBarrelEmpty { get; private set; } = new List<bool>();


        public Fever Fever { get; private set; }
        public GameItem GameItem { get; private set; }
        
        public CommonItemRenderer Capybara { get; private set; }


        public bool IsGameStart { get; private set; }
        
        public bool IsGuideMode { get; set; }
        public int GuidePhase { get; set; } = 1;
        
       
        
        //game state
        private bool _isGameWin;
        private bool _isGameOver;

        public int BombBoomNum;
        


        private int _updatorId = EquineScheduler.INVALID;


        private readonly List<Type> _skillList = new List<Type>()
        {
            typeof(MoveBox2Slot),
            typeof(BoxMatrixMoveUp),
            typeof(LoadBullet),
            typeof(FireBullet),
            typeof(ReviveNormal),
            typeof(ReviveBomb),
            typeof(UseForceChoose),
            typeof(UseMagnet),
            typeof(UseHammer),
            typeof(UseRefresh),
        };

        

        public void PlayBarrelAnimation()
        {
            var skelDuck = UI.skelDuck;
            var trackEntryDuck = skelDuck.AnimationState.SetAnimation(0, "yazi_jinru", false);
            trackEntryDuck.MixDuration = 0f;
            trackEntryDuck.Complete += entry =>
            {
                skelDuck.AnimationState.SetAnimation(entry.TrackIndex, "yazi_idle", true);
            };

            var skelBucket = UI.skelBucket;
            var trackEntryBucket = skelBucket.AnimationState.SetAnimation(0, "jinru", false);
            trackEntryBucket.MixDuration = 0f;
            trackEntryBucket.Complete += entry =>
            {
                skelBucket.AnimationState.SetAnimation(entry.TrackIndex, "idle", true);
            };

            var skelBucketEx = UI.skelBucketEx;
            var trackEntryBucketEx = skelBucketEx.AnimationState.SetAnimation(0, "jinru_zhedang", false);
            trackEntryBucketEx.MixDuration = 0f;
            trackEntryBucketEx.Complete += entry =>
            {
                skelBucketEx.AnimationState.SetAnimation(entry.TrackIndex, "idle_zhedang", true);
            };
        }

        public override void Dispose()
        {
            UI.itemLayout.enabled = true;

            
            Fever.Dispose();
            Capybara.Dispose();
            SkillManager.instance.UnRegisterSkill(_skillList);
            GameItem.Dispose();
            GamePlayData.Dispose();
            EquineScheduler.RemoveLimitUpdator(ref _updatorId);


        }

        public void InitGame(GamePlaySkin gamePlaySkin, LevelData levelData,int levelId)
        {
            var countInitItem = 0;
            var totalInitItem = 2;
            Action endInitCallback = () =>
            {
                countInitItem++;
                if (countInitItem == totalInitItem)
                {
                    IsGameStart = true;
                }
            };
            
            UI = gamePlaySkin;
            LevelData = levelData;
            LevelId = levelId;

            levelData.BoxProduction.IsDebug = false;
            WinCondition = levelData.WinCondition;
            switch (levelData.WinCondition)
            {
                case WinCondition.Any:
                    NeedKillNum = levelData.WinConditionAnyAmount;
                    KillTotalProgress = NeedKillNum;
                    break;
                case WinCondition.Specific:
                    SpecificNeedKillNum =
                        levelData.WinConditionSpecificAmount.ToDictionary(pair => pair.Key, pair => pair.Value);
                    KillTotalProgress = SpecificNeedKillNum.Sum(pair => pair.Value);
                    break;
            }

            GamePlayData = new GamePlayData(gamePlaySkin, levelData,levelId);

            CommonItemRenderer.DynamicRegisterItem(typeof(BrickVo), typeof(Brick));
            CommonItemRenderer.DynamicRegisterItem(typeof(BombVo), typeof(Bomb));
            CommonItemRenderer.DynamicRegisterItem(typeof(BrickGeneratorVo), typeof(BrickGenerator));

            CommonItemRenderer.DynamicRegisterItem(typeof(BoxVo), typeof(Box));
            CommonItemRenderer.DynamicRegisterItem(typeof(RandomBoxVo), typeof(RandomBox));
            CommonItemRenderer.DynamicRegisterItem(typeof(BoxGeneratorVo), typeof(BoxGenerator));

            CommonItemRenderer.DynamicRegisterItem(typeof(StackableBulletVo), typeof(StackableBullet));
            CommonItemRenderer.DynamicRegisterItem(typeof(BulletVo), typeof(Bullet));
            
            CommonItemRenderer.DynamicRegisterItem(typeof(CapybaraVo), typeof(Capybara));
            CommonItemRenderer.DynamicRegisterItem(typeof(GoldBoxVo), typeof(GoldBox));


            for (int i = 0; i < BarrelCapacity; i++)
            {
                IsBarrelEmpty.Add(true);
            }

            IsGameStart = false;
            GamePlayData.Init(endInitCallback);
            Capybara = new CommonItemRenderer(UI.capybaraPos);
            Capybara.data = new CapybaraVo()
            {
                CapybaraAction = CapybaraAction.IdleLowForm,
            };
            Capybara.initCallBack += endInitCallback;
            
            EquineScheduler.RunYieldProcedure(StartGame());
        }

        private IEnumerator StartGame()
        {
            MoveBox2Slot.IsAllowClick = false;

            while (!IsGameStart)
                yield return null;
            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderSlotLock,
                GamePlayData.CurrentUnlockedSlotNum);


            BombVo.CheckBombActive();


            SkillManager.instance.RegisterSkill(_skillList);
            
            _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);

            Fever = new Fever();
            
            GameItem = new GameItem();
            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItemLock);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,GameItemType.Magnet);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,GameItemType.ForceChoose);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,GameItemType.Hammer);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,GameItemType.Refresh);
            
            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderNewfeaturePopup);
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderNewItemPopup);

            UI.itemLayout.enabled = false;
            
            MoveBox2Slot.IsAllowClick = true;

            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GameStartFinished);
        }


        private void OnUpdate(int interval, object param, UpdateTimeInfo time)
        {
            var gameData = GamePlayData;
            if (!gameData.IsExistSlotEmpty() && IsAllAnimationFinished)
            {
                CheckGameOver(GameOverType.SlotFilled);
            }
        }
        
        public bool IsAllAnimationFinished => GamePlayData.IsAllLoadBullet()
                                               && MoveBox2Slot.IsAnimationFinished
                                               && BoxMatrixMoveUp.IsAnimationFinished
                                               && LoadBullet.IsAnimationFinished
                                               && FireBullet.IsAnimationFinished
                                               && !Fever.IsFever
                                               && !UseRefresh.IsClosing
                                               && !UseRefresh.IsRefreshing
                                               && BarrelQueue.Count == 0;
        
        public void KillOneLife(BattleColor killedBrickColor)
        {
            if (WinCondition == WinCondition.Any)
            {
                NeedKillNum--;
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.TotalKillNumberUpdate, NeedKillNum);
            }
            else if (WinCondition == WinCondition.Specific)
            {
                if (SpecificNeedKillNum.ContainsKey(killedBrickColor))
                {
                    SpecificNeedKillNum[killedBrickColor]--;
                    ApplicationFacade.instance.SendNotification(GamePlayUIEvent.SpecialKillNumberUpdate,
                        (killedBrickColor, SpecificNeedKillNum[killedBrickColor]));
                }
            }
        }

        public bool CheckGameWin()
        {
            if (_isGameOver)
                return false;

            if (_isGameWin)
                return true;

            if (WinCondition == WinCondition.Any)
            {
                _isGameWin = NeedKillNum == 0;
            }
            else
            {
                _isGameWin = SpecificNeedKillNum.Sum(pair => pair.Value) == 0;
            }

            if (_isGameWin)
            {
                IsFreezePlayerInput = true;
                EquineScheduler.RunYieldProcedure(RaiseGameWin());
                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerator RaiseGameWin()
        {
            while (!IsAllAnimationFinished)
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(1f);
            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GameWin);
        }

        

        public bool CheckGameOver(GameOverType gameOverType)
        {
            if (_isGameOver)
                return true;

            if (_isGameWin)
                return false;

            IsFreezePlayerInput = true;
            switch (gameOverType)
            {
                case GameOverType.SlotFilled:
                    EquineScheduler.RunYieldProcedure(RaiseGameOver(gameOverType));
                    _isGameOver = true;
                    break;
                case GameOverType.Bomb:
                    EquineScheduler.RunYieldProcedure(RaiseGameOver(gameOverType));
                    _isGameOver = true;
                    break;
                case GameOverType.Timeout:
                    EquineScheduler.RunYieldProcedure(RaiseGameOver(gameOverType));
                    _isGameOver = true;
                    break;
            }
            
            
            return true;
        }
        
        

        

        public IEnumerator RaiseGameOver(GameOverType gameOverType)
        {
            
            while (!IsAllAnimationFinished)
            {
                yield return null;
            }
            
            //等炸弹炸
            if(gameOverType == GameOverType.Bomb)
                while (BombBoomNum != 0)
                {
                    yield return null;
                }
            
            
            yield return new WaitForSeconds(1f);
            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GameOver, gameOverType);
        }
        
        
        public void Revive(GameOverType gameOverType)
        {
            switch (gameOverType)
            {
                case GameOverType.SlotFilled:
                    BaseSkill skill = new ReviveNormal();
                    SkillManager.instance.UseSkill(skill);
                    break;
                case GameOverType.Bomb:
                    skill = new ReviveBomb();
                    SkillManager.instance.UseSkill(skill);
                    break;
            }

            _isGameOver = false;
            IsFreezePlayerInput = false;
        }

        public void DebugGameWin()
        {
            if (_isGameWin || _isGameOver)
                return;
            _isGameWin = true;
            IsFreezePlayerInput = true;
            EquineScheduler.RunYieldProcedure(RaiseGameWin());
        }

        public void ChooseBox(int row, int col)
        {
            if (_isGameWin || _isGameOver)
                return;

            if (!MoveBox2Slot.IsAllowClick)
                return;
            
            if(!BoxMatrixMoveUp.IsAllowClick[col])
                return;

            if (UseHammer.IsUsing)
            {
                AudioFacade.instance.PlayClip("Sound_TapWrong", false);
                return;
            }

            if (!UseForceChoose.IsUsing)
            {
                if (row != 0)
                {
                    AudioFacade.instance.PlayClip("Sound_TapWrong", false);
                    return;
                }
                else
                {
                    AudioFacade.instance.PlayClip("Sound_Tap", false);
                }
            }
            else
            {
                AudioFacade.instance.PlayClip("Sound_Tap", false);
                GameItem.ForceChoose.ChooseBox();
            }


            if (!GamePlayData.IsExistSlotEmpty())
            {
                return;
            }


            //后插
            // if (!GamePlayData.IsSlotEmpty[GamePlayData.CurrentUnlockedSlotNum - 1])
            //     return;

            if (IsGuideMode && GuidePhase == 1)
            {
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GuideNextPhase);
                GuidePhase++;
            }
            
            //后插需要改遍历方向

            var slotIndex = -1;
            for (var i = 0; i <= GamePlayData.CurrentUnlockedSlotNum - 1; i++)
            {
                if (GamePlayData.IsSlotEmpty[i])
                {
                    GamePlayData.IsSlotEmpty[i] = false;
                    slotIndex = i;

                    break;
                }
                
                //后插
                // if (i == 0)
                // {
                //     GamePlayData.IsSlotEmpty[i] = false;
                //     slotIndex = i;
                //     break;
                // }

                // if (!GamePlayData.IsSlotEmpty[i - 1])
                // {
                //     GamePlayData.IsSlotEmpty[i] = false;
                //     slotIndex = i;
                //
                //     break;
                // }
            }
            
            if (slotIndex == -1)
                return;
            
            var useNum = 0;
            for (var i = 0; i <= GamePlayData.CurrentUnlockedSlotNum - 1; i++)
            {
                if (!GamePlayData.IsSlotEmpty[i])
                {
                    useNum++;
                }
            }

            if (useNum == GamePlayData.CurrentUnlockedSlotNum - 1)
            {
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.ShowTip,"One Space Left!");
            }
            
            GameItem.ResetRemind();

            LevelData.BoxProduction.ComboNum++;


            var skillMoveBox2Slot = new MoveBox2Slot(row, col, slotIndex);
            SkillManager.instance.UseSkill(skillMoveBox2Slot);

            var skillBoxMatrixMoveUp = new BoxMatrixMoveUp(row,col);
            SkillManager.instance.UseSkill(skillBoxMatrixMoveUp);

            //更新炸弹倒计时
            BombVo.UpdateCountDown();
        }
    }
}