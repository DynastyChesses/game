using System;
using System.Collections;
using System.Collections.Generic;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.Save;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject;
using UnityEngine;

namespace HotUpdate.osP1
{
    public enum GameItemType
    {
        MinLimit = -1,
        Magnet = 0,
        ForceChoose,
        Hammer,
        Refresh,
        MaxLimit,
    }
    
    public class GameItem
    {
        
        public UseForceChoose ForceChoose{get;set;}
        public UseHammer Hammer{get;set;}
        
        public Dictionary<GameItemType,string> Name{get;set;} = new Dictionary<GameItemType,string>();
        public Dictionary<GameItemType,string> Desc{get;set;} = new Dictionary<GameItemType,string>();
        
        public Dictionary<GameItemType,int> Price { get; set; } = new Dictionary<GameItemType,int>();

        
        public Dictionary<GameItemType,int> RemainUseNum { get; set; } =  new Dictionary<GameItemType,int>();

        public Dictionary<GameItemType,int> UseLimit { get; set; } = new Dictionary<GameItemType,int>();
        
        public Dictionary<GameItemType,int> CurrentNum { get; set; } = new Dictionary<GameItemType,int>();
        
        public Dictionary<GameItemType,bool> IsItemUnlocked { get; set; } = new Dictionary<GameItemType,bool>();
        


        private string _tip = " Can't use Now!";
        private int _updatorId = EquineScheduler.INVALID;

        

        private Dictionary<GameItemType,bool> _isReminding = new Dictionary<GameItemType,bool>();

        private Dictionary<GameItemType,bool>_isAlreadyRemind = new Dictionary<GameItemType,bool>();

        private Dictionary<GameItemType,bool> _isChecked = new Dictionary<GameItemType,bool>();

        private Dictionary<GameItemType,bool> _isUsing = new Dictionary<GameItemType,bool>();

        public static void ForeachItem(Action<GameItemType> action)
        {
            for (int i = 0; i < (int)GameItemType.MaxLimit; i++)
            {
                var itemType = (GameItemType)i;
                action.Invoke(itemType);
            }
        }
        

        public GameItem()
        {
            var levelId = GamePlay.instance.LevelId;
            
            _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);
            
            Price.Add(GameItemType.Magnet,int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_slingshot_gold"].Value));
            Price.Add(GameItemType.ForceChoose,int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_select_gold"].Value));
            Price.Add(GameItemType.Hammer,int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_hammer_gold"].Value));
            Price.Add(GameItemType.Refresh,int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_gold"].Value));

            //UseLimit
            UseLimit.Add(GameItemType.Magnet,
                int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_slingshot_limit"].Value));
            UseLimit.Add(GameItemType.ForceChoose,
                int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_select_limit"].Value));
            UseLimit.Add(GameItemType.Hammer,
                int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_hammer_limit"].Value));
            UseLimit.Add(GameItemType.Refresh,
                int.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_limit"].Value));
            
            ForeachItem(gameItemType =>
            {
                Name.Add(gameItemType,PreviewContentData.instance.ItemName[gameItemType]);
                Desc.Add(gameItemType, PreviewContentData.instance.ItemDesc[gameItemType]);
                
                //进入关卡的物品携带数量，取 使用上限 和 持有数量 的最小值
                CurrentNum.Add(gameItemType,Mathf.Min(PlayerSave.instance.PlayerAssets.GetItemNum(gameItemType), UseLimit[gameItemType]));
                
                //剩余使用数量
                RemainUseNum.Add(gameItemType,UseLimit[gameItemType]);
                
                var unlockLevel = PreviewContentData.instance.ItemRange[gameItemType].Item2;
                IsItemUnlocked.Add(gameItemType,levelId >= unlockLevel);
                
                _isReminding.Add(gameItemType,false);
                _isAlreadyRemind.Add(gameItemType,false);
                _isChecked.Add(gameItemType,false);
                _isUsing.Add(gameItemType,false);
            });
            
            ForceChoose = new UseForceChoose();
            Hammer = new UseHammer();
        }
        
        public void Dispose()
        {
            EquineScheduler.RemoveLimitUpdator(ref _updatorId);
            
        }

        public void ResetRemind()
        {
            ForeachItem(gameItemType =>
            {
                _isAlreadyRemind[gameItemType] = false;
                _isChecked[gameItemType] = false;
                _isAlreadyRemind[gameItemType] = false;
                InterruptRemind(gameItemType);
            });
        }

        private void OnUpdate(int a, object b, UpdateTimeInfo time)
        {
            CheckRemind(GameItemType.Magnet);
            CheckRemind(GameItemType.ForceChoose);
            CheckRemind(GameItemType.Hammer);
            CheckRemind(GameItemType.Refresh);
        }

        

        public bool IsCanUse(GameItemType item)
        {
            var gameData = GamePlay.instance.GamePlayData;
            var isAllAnimationFinished = GamePlay.instance.IsAllAnimationFinished;
            var ret = false;
            switch (item)
            {
                case GameItemType.Magnet:
                    ret = isAllAnimationFinished && !gameData.IsAllSlotEmpty();
                    break;
                case GameItemType.ForceChoose:
                    ret = isAllAnimationFinished;
                    break;
                case GameItemType.Hammer:
                    ret = isAllAnimationFinished;
                    break;
                case GameItemType.Refresh:
                    ret = isAllAnimationFinished;
                    break;
                default:
                    Debug.LogError($"Item {item} is over index");
                    ret = false;
                    break;
            }
            return ret;
        }

        private void CheckRemind(GameItemType item)
        {
            //因为动画停了才检测，所以检测一次可能是合理的
            if (_isChecked[item])
                return;
            if (_isAlreadyRemind[item])
                return;
            if (!IsCanUse(item))//动画都停了才能使用道具
                return;
            if(GamePlay.instance.IsGameWin || GamePlay.instance.IsGameOver)
                return;
            
            var needRemind = NeedRemind(item);
            _isChecked[item] = true;

            if (!needRemind)
                return;

            _isAlreadyRemind[item] = true;
            _isReminding[item] = true;
            Remind(item);
        }

        
        private bool NeedRemind(GameItemType item)
        {
            Func<bool> fallback = () =>
            {
                Debug.LogError("invalid item type");
                return false;
            };
            
            var ret = item switch
            {
                GameItemType.Magnet => NeedRemainMagnet(),
                GameItemType.ForceChoose => NeedRemainForceChoose(),
                GameItemType.Hammer => NeedRemindHammer(),
                GameItemType.Refresh => NeedRemindRefresh(),
                _ => fallback()
            };
            
            return ret;
        }

        private void Remind(GameItemType item)
        {
            switch (item)
            {
                case GameItemType.Magnet:
                    EquineScheduler.RunYieldProcedure(RemindMagnet());
                    break;
                case GameItemType.ForceChoose:
                    EquineScheduler.RunYieldProcedure(RemindForceChoose());
                    break;
                case GameItemType.Hammer:
                    EquineScheduler.RunYieldProcedure(RemindHammer());
                    break;
                case GameItemType.Refresh:
                    EquineScheduler.RunYieldProcedure(RemindRefresh());
                    break;
                default:
                    Debug.LogError($"invalid item type");
                    break;
            }
        }

        private void InterruptRemind(GameItemType item)
        {
            switch (item)
            {
                case GameItemType.Magnet:
                    InterruptRemindMagnet();
                    break;
                case GameItemType.ForceChoose:
                    InterruptRemindForceChoose();
                    break;
                case GameItemType.Hammer:
                    InterruptRemindHammer();
                    break;
                case GameItemType.Refresh:
                    InterruptRemindRefresh();
                    break;
                default:
                    Debug.LogError($"invalid item type");
                    break;
            }
        }

        public void Use(GameItemType item)
        {
            if (!IsCanUse(item))
            {
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.ShowTip,_tip);
                return;
            }

            if (CurrentNum[item] == 0)
            {
                //没有道具，不能使用
                ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_BUY_ITEM_POPUP,item);
                return;
            }

            if (item is GameItemType.Magnet or GameItemType.Refresh)
            {
                //立即使用的道具
                RemainUseNum[item]--;
                CurrentNum[item]--;
                PlayerSave.instance.PlayerAssets.RemoveItemNum(item,1);
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderItem,item);
            }
            
            
            
            switch (item)
            {
                case GameItemType.Magnet:
                    UseMagnet();
                    break;
                case GameItemType.ForceChoose:
                    UseForceChoose();
                    break;
                case GameItemType.Hammer:
                    UseHammer();
                    break;
                case GameItemType.Refresh:
                    UseRefresh();
                    break;
                default:
                    Debug.LogError($"Item {item} is over index");
                    break;
            }
        }


        #region ForceChoose

  
        private bool NeedRemainForceChoose()
        {
            return false;
        }

        private IEnumerator RemindForceChoose()
        {
            yield return null;

            _isReminding[GameItemType.ForceChoose] = false;
        }

        private void InterruptRemindForceChoose()
        {
            if (!_isReminding[GameItemType.ForceChoose])
                return;

            _isReminding[GameItemType.ForceChoose] = false;
        }

        private void UseForceChoose()
        {
            _isUsing[GameItemType.ForceChoose] = !_isUsing[GameItemType.ForceChoose];
            SkillManager.instance.UseSkill(ForceChoose);
        }

        

        #endregion

        #region Magnet

        


        private bool NeedRemainMagnet()
        {
            var gameData = GamePlay.instance.GamePlayData;

            //如果已选择托盘≥1 且 任选N个托盘（N=托盘剩余空位)，都无法击碎任意一个最前排的砖块


            return false;
        }

        private IEnumerator RemindMagnet()
        {
            yield return null;

            _isReminding[GameItemType.Magnet] = false;
        }

        private void InterruptRemindMagnet()
        {
            if (!_isReminding[GameItemType.Magnet])
                return;

            _isReminding[GameItemType.Magnet] = false;
        }

        private  void UseMagnet()
        {
            EnterUseMagnet();
        }

        private void EnterUseMagnet()
        {
            _isUsing[GameItemType.Magnet] = true;

            Action lambda = () => { ExitUseMagnet(); };

            AnimUseImmediateItem(GameItemType.Magnet, lambda);

            var skill = new UseMagnet();
            SkillManager.instance.UseSkill(skill);
        }

        private void ExitUseMagnet()
        {
            _isUsing[GameItemType.Magnet] = false;
        }

        #endregion

        #region Hammer
        
        private bool NeedRemindHammer()
        {
            return false;
        }

        private IEnumerator RemindHammer()
        {
            yield return null;


            _isReminding[GameItemType.Hammer] = false;
        }

        private void InterruptRemindHammer()
        {
            if (!_isReminding[GameItemType.Hammer])
                return;

            _isReminding[GameItemType.Hammer] = false;
        }

        private  void UseHammer()
        {
            _isUsing[GameItemType.Hammer] = !_isUsing[GameItemType.Hammer];
            
            SkillManager.instance.UseSkill(Hammer);
        }

        

        

        #endregion

        #region Refresh

        

        private bool NeedRemindRefresh()
        {
            var gameData = GamePlay.instance.GamePlayData;
            var lastRow = gameData.BrickVo[gameData.BrickVoLastRowIndex];
            var allBox = new List<BoxVo>();
            for (int i = 0; i < gameData.BoxVisibleRow; i++)
            {
                allBox.AddRange(gameData.BoxVo[i]);
            }

            var bulletColorNum = new Dictionary<BattleColor, int>();
            foreach (var boxVo in allBox)
            {
                foreach (var bulletVo in boxVo.Bullets)
                {
                    var color = bulletVo.Color;
                    var num = bulletVo.Number;
                    if (!bulletColorNum.ContainsKey(color))
                    {
                        bulletColorNum.Add(color, num);
                    }
                    else
                    {
                        bulletColorNum[color] += num;
                    }
                }
            }

            //如果 所有托盘中的小球 加起来都无法打碎 最前排的任意一个 砖块
            var ret = true;
            foreach (var brickVo in lastRow)
            {
                if (brickVo.State == BrickState.Dead)
                    continue;
                var color = brickVo.Color;
                var num = brickVo.Life;
                if (bulletColorNum.ContainsKey(color) && bulletColorNum[color] >= num)
                {
                    ret = false;
                    break;
                }
            }


            return ret;
        }

        private IEnumerator RemindRefresh()
        {
            var ui = GamePlay.instance.UI;
            ui.itemSkel[(int)GameItemType.Refresh].AnimationState.SetAnimation(0, "tip", true);

            yield return 0;
        }

        private void InterruptRemindRefresh()
        {
            if (!_isReminding[GameItemType.Refresh])
                return;

            if (_isUsing[GameItemType.Refresh])
                return;

            var ui = GamePlay.instance.UI;
            ui.itemSkel[(int)GameItemType.Refresh].AnimationState.SetAnimation(0, "normal", true);

            _isReminding[GameItemType.Refresh] = false;
        }

        private  void UseRefresh()
        {
            EnterUseRefresh();
        }

        private void EnterUseRefresh()
        {
            _isUsing[GameItemType.Refresh] = true;

            var count = 0;
            var total = 2;
            Action lambda = () =>
            {
                count++;
                if (count == total)
                    ExitUseRefresh();
            };

            GamePlay.instance.UI.itemBtn[(int)GameItemType.Refresh].interactable = false;

            //item anim
            AnimUseImmediateItem(GameItemType.Refresh, lambda);

            //refresh anim
            MoveBox2Slot.IsAllowClick = false;
            LoadBullet.ForceLoadBullet();
            var skill = new UseRefresh(false);
            SkillManager.instance.UseSkill(skill);
            skill.CloseMask((() => { skill.Refresh(lambda); }));
        }

        private void ExitUseRefresh()
        {
            _isUsing[GameItemType.Refresh] = false;

            GamePlay.instance.UI.itemBtn[(int)GameItemType.Refresh].interactable = true;

            MoveBox2Slot.IsAllowClick = true;
        }

        public void ResetUseRefresh()
        {
            GamePlay.instance.UI.itemBtn[(int)GameItemType.Refresh].interactable = true;

            MoveBox2Slot.IsAllowClick = true;
        }

        #endregion


        private void AnimUseImmediateItem(GameItemType item, Action callback = null)
        {
            if (item != GameItemType.Refresh && item != GameItemType.Magnet)
            {
                Debug.LogError($"Item {item} is not Immediate Item");
                return;
            }

            //点击即用的道具
            var ui = GamePlay.instance.UI;
            var trackEntry = ui.itemSkel[(int)item].AnimationState.SetAnimation(0, "use", false);
            trackEntry.Complete += entry =>
            {
                ui.itemSkel[(int)item].AnimationState.SetAnimation(0, "normal", true);
                callback?.Invoke();
            };
        }

        

        

        

        

        

        
    }
}