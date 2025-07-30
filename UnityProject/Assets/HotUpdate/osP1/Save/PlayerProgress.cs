using System;
using UnityEngine;

namespace HotUpdate.osP1.Save
{
    [Serializable]
    public class PlayerProgress
    {
        public static readonly string Key = nameof(PlayerProgress);

        public static readonly int BaseCh1 = 0;
        public static readonly int BaseCh2 = 6;
        public static readonly int BaseCh3 = 15;
        public static readonly int BaseCh4 = 24;
        public static readonly int BaseCh5 = 36;
        public static readonly int BaseCh6 = 48;

        public static readonly int MinCh = 1;
        public static readonly int MaxCh = 5;
        public static readonly int MinLevel = 1;
        public static readonly int MaxLevel = 48;
        
        
        public int CurrentLevelId;
        public int CurrentLevelEffectId;

        private PlayerProgress()
        {
            
        }

        public static PlayerProgress Create()
        {
            PlayerProgress playerProgress = new PlayerProgress();
            playerProgress.CurrentLevelId = 1;
            playerProgress.CurrentLevelEffectId = 1;
            return playerProgress;
        }

        public void CompleteLevel()
        {
            CurrentLevelId++;
            ApplicationFacade.instance.SendNotification(LevelSelectionUIEvent.RenderBtnPlay, CurrentLevelId);
        }

        public static int GetCurrentCh(int level)
        {
            var ret = 0;
            if (PlayerProgress.BaseCh1 < level&& level <= PlayerProgress.BaseCh2)
            {
                ret = 1;
            }else if (PlayerProgress.BaseCh2 < level && level <= PlayerProgress.BaseCh3)
            {
                ret = 2;
            }else if (PlayerProgress.BaseCh3 < level && level<= PlayerProgress.BaseCh4)
            {
                ret = 3;
            }else if (PlayerProgress.BaseCh4 < level && level <= PlayerProgress.BaseCh5)
            {
                ret = 4;
            }else if (PlayerProgress.BaseCh5 < level && level <= PlayerProgress.BaseCh6)
            {
                ret = 5;
            }
            else
            {
                ret = 6;
            }

            ret = Mathf.Min(MaxCh, ret);
            return ret;
        }

        public static int GetChMinLevelId(int chapter)
        {
            return chapter switch
            {
                1 => PlayerProgress.BaseCh1,
                2 => PlayerProgress.BaseCh2,
                3 => PlayerProgress.BaseCh3,
                4 => PlayerProgress.BaseCh4,
                5 => PlayerProgress.BaseCh5,
                6 => PlayerProgress.BaseCh6,
                7 => 64//第六章最后一关是64
            };
        }
    }
}