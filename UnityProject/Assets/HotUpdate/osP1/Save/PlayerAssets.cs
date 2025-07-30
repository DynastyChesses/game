using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace HotUpdate.osP1.Save
{
    [Serializable]
    public class PlayerAssets: IPlayerSave
    {
        public static readonly string Key = nameof(PlayerAssets);
        
        //public 为了序列化
        public Dictionary<int,bool> BoolMap = new Dictionary<int,bool>();
        public Dictionary<int,int> IntMap = new Dictionary<int,int>();
        public Dictionary<int,float> FloatMap = new Dictionary<int,float>();
        public Dictionary<int,string> StringMap = new Dictionary<int,string>();

        [NonSerialized]
        public readonly int StaminaUpperLimit;
        [NonSerialized]
        public readonly int StaminaRestoreSecond;
        [NonSerialized]
        public readonly int InitGold;
        [NonSerialized]
        public readonly int LevelFinishedGold;

        public bool IsGuarantyStamina
        {
            get => BoolMap[_isGuarantyStamina];
            private set => BoolMap[_isGuarantyStamina] = value;
        }

        public int Stamina
        {
            get => IntMap[_stamina];
            private set => IntMap[_stamina] = value;
        }

        public int Gold
        {
            get => IntMap[_gold];
            private set => IntMap[_gold] = value;
        }

        public int AdTicket
        {
            get => IntMap[_adTicket];
            private set => IntMap[_adTicket] = value;
        }

        public int Magnet
        {
            get => IntMap[_magnet];
            private set => IntMap[_magnet] = value;
        }

        public int ForceChoose
        {
            get => IntMap[_forceChoose];
            private set => IntMap[_forceChoose] = value;
        }

        public int Hammer
        {
            get => IntMap[_hammer];
            private set => IntMap[_hammer] = value;
        }

        public int Refresh
        {
            get => IntMap[_refresh];
            private set => IntMap[_refresh] = value;
        }

        public float PassedTime
        {
            get => FloatMap[_passedTime];
            private set => FloatMap[_passedTime] = value;
        }

        public string LastOffLineTime
        {
            get => StringMap[_lastOffLineTime];
            private set => StringMap[_lastOffLineTime] = value;
        }

        
        
        
        //bool
        private const int _isGuarantyStamina = 0;
        private const int _boolMaxLimit = 1;
        
        //int
        private const int _stamina = 0;
        private const int _gold = 1;
        private const int _adTicket = 2;
        
        private const int _magnet = 3;
        private const int _forceChoose = 4;
        private const int _hammer = 5;
        private const int _refresh = 6;
        private const int _intMaxLimit = 7;
        
        //float
        //为了恢复体力经过了多长时间
        private const int _passedTime = 0;
        private const int _floatMaxLimit = 1;
        
        //string
        //上一次离线时间
        private const int _lastOffLineTime = 0;
        private const int _stringMaxLimit = 1;

        
        
        private PlayerAssets()
        {
            StaminaUpperLimit = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["stamina_limit"].Value);
            StaminaRestoreSecond = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["stamina_time"].Value);
            InitGold = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["gold_initial"].Value);
            LevelFinishedGold = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["level_gold_base"].Value);
        }

        public static PlayerAssets Create()
        {
            PlayerAssets playerAssets = new PlayerAssets();
            playerAssets.BoolMap = new Dictionary<int, bool>();
            playerAssets.IntMap = new Dictionary<int, int>();
            playerAssets.FloatMap = new Dictionary<int, float>();
            playerAssets.StringMap = new Dictionary<int, string>();

            for (int i = 0; i < _boolMaxLimit; i++)
            {
                playerAssets.BoolMap.Add(i, default);
            }

            for (int i = 0; i < _intMaxLimit; i++)
            {
                playerAssets.IntMap.Add(i, default);
            }

            for (int i = 0; i < _floatMaxLimit; i++)
            {
                playerAssets.FloatMap.Add(i, default);
            }

            for (int i = 0; i < _stringMaxLimit; i++)
            {
                playerAssets.StringMap.Add(i, string.Empty);
            }

            playerAssets.IntMap[_stamina] = 5;
            playerAssets.IntMap[_gold] = playerAssets.InitGold;
            
            return playerAssets;
        }

        private void UpdateSave()
        {
            for (int i = 0; i < _boolMaxLimit; i++)
            {
                BoolMap.TryAdd(i, default);
            }

            for (int i = 0; i < _intMaxLimit; i++)
            {
                IntMap.TryAdd(i, default);
            }

            for (int i = 0; i < _floatMaxLimit; i++)
            {
                FloatMap.TryAdd(i, default);
            }

            for (int i = 0; i < _stringMaxLimit; i++)
            {
                StringMap.TryAdd(i, string.Empty);
            }
        }
        
        /// <summary>
        /// 防止用户进入 GamePlay 后，退出游戏
        /// </summary>
        /// <param name="isGuarantyStamina"></param>
        public void SetCacheRemoveStamina(bool isGuarantyStamina)
        {
            IsGuarantyStamina= isGuarantyStamina;    
        }

        public void AddStamina(int number,bool notifyRender = true)
        {
            if(Stamina + number >= StaminaUpperLimit)
                Stamina = StaminaUpperLimit;
            else
                Stamina += number;
            
            //增加体力后时间清零
            PassedTime = 0f;
            
            if(notifyRender)
                ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderStamina, Stamina);
            
        }

        public void RemoveStamina(int number,bool notifyRender = true)
        {
            Stamina -= number;
            if(Stamina <= 0)
                Stamina = 0;
            
            if(notifyRender)
                ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderStamina, Stamina);
        }
        
        public void AddGold(int number)
        {
            Gold += number;
            ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderGold, Gold);
        }

        public void RemoveGold(int number)
        {
            Gold -= number;
            if(Gold <= 0)
                Gold = 0;
            ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderGold, Gold);
        }
        
        public void AddAdTicket(int number)
        {
            AdTicket += number;
            ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderAdTicket, AdTicket);
        }

        public void RemoveAdTicket(int number)
        {
            AdTicket -= number;
            if(AdTicket <= 0)
                AdTicket = 0;
            ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderAdTicket, AdTicket);
        }

        public int GetItemNum(GameItemType item)
        {
            var ret = 0;
            switch (item)
            {
                case GameItemType.Magnet:
                    ret = Magnet;
                    break;
                case GameItemType.ForceChoose:
                    ret = ForceChoose;
                    break;
                case GameItemType.Hammer:
                    ret = Hammer;
                    break;
                case GameItemType.Refresh:
                    ret = Refresh;
                    break;
                default:
                    ret = 0;
                    Debug.LogError("invalid item type");
                    break;
            }
            return ret;
        }

        public void AddItemNum(GameItemType item, int amount)
        {
            switch (item)
            {
                case GameItemType.Magnet:
                    Magnet += amount;
                    break;
                case GameItemType.ForceChoose:
                    ForceChoose += amount;
                    break;
                case GameItemType.Hammer:
                    Hammer += amount;
                    break;
                case GameItemType.Refresh:
                    Refresh += amount;
                    break;
                default:
                    Debug.LogError("invalid item type");
                    break;
            }
        }

        public void RemoveItemNum(GameItemType item, int amount)
        {
            switch (item)
            {
                case GameItemType.Magnet:
                    Magnet -= amount;
                    if (Magnet <= 0)
                        Magnet = 0;
                    break;
                case GameItemType.ForceChoose:
                    ForceChoose -= amount;
                    if (ForceChoose <= 0)
                        ForceChoose = 0;
                    break;
                case GameItemType.Hammer:
                    Hammer -= amount;
                    if (Hammer <= 0)
                        Hammer = 0;
                    break;
                case GameItemType.Refresh:
                    Refresh -= amount;
                    if (Refresh <= 0)
                        Refresh = 0;
                    break;
                default:
                    Debug.LogError("invalid item type");
                    break;
            }
        }
        
        

        
        void IPlayerSave.OnLoad()
        {
            UpdateSave();
            
            if (IsGuarantyStamina)
            {
                SetCacheRemoveStamina(false);
                //说明上一次游戏，没有胜利就退出了，所以要进行体力扣除
                Stamina--;
                if(Stamina <= 0)
                    Stamina = 0;
            }
            
            //处理登录时间
            if (LastOffLineTime != "")
            {
                var lastTime = DateTime.Parse(LastOffLineTime);
                var currentTime = DateTime.UtcNow;
                var duration = (currentTime - lastTime).TotalSeconds;
                
                //make sure do not over int Max Value
                if(duration >= StaminaUpperLimit * StaminaRestoreSecond)
                    duration = StaminaUpperLimit * StaminaRestoreSecond + 0.1;
            
                var intDuration = (int)duration;
                intDuration += (int)PassedTime;//为了恢复体力而经过的时间
                var restoreStamina = intDuration / StaminaRestoreSecond;
                var remainSecond = intDuration % StaminaRestoreSecond;
            
                //添加体力
                AddStamina(restoreStamina,false);
            
                //剩余时间
                if (Stamina == StaminaUpperLimit)
                {
                    PassedTime = 0f;
                }
                else
                {
                    PassedTime = remainSecond;
                }
            }
            
        }

        void IPlayerSave.OnUpdate(UpdateTimeInfo time)
        {
            if(Stamina == StaminaUpperLimit)
                return;
            
            PassedTime += time.deltaTime;
            if (PassedTime >= StaminaRestoreSecond)
            {
                PassedTime = 0f;
                AddStamina(1);
            }
            ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderStaminaTime, StaminaRestoreSecond - (int)PassedTime);
        }

        void IPlayerSave.OnSave()
        {
            LastOffLineTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void DebugSetRemainTime(int seconds)
        {
            PassedTime = StaminaRestoreSecond - seconds;
        }
    }
}