using System;
using System.Collections.Generic;

namespace HotUpdate.osP1.Save
{
    [Serializable]
    public class PlayerSettings: IPlayerSave
    {
        public static readonly string Key = nameof(PlayerSettings);
        
        //bool
        public const int BoolMinIndex = 0;
        public const int IsMusicOn = 0;
        public const int IsSoundOn = 1;
        public const int BoolMaxIndex = 1;
        
        //int
        public const int IntMinIndex = 0;
        public const int IntMaxIndex = 0;
        
        //float
        public const int FloatMinIndex = 0;
        public const int FloatMaxIndex = 0;

        

        public List<bool> BoolList;
        public List<int> IntList;
        public List<float> FloatList;

        private PlayerSettings()
        {
            
        }

        public static PlayerSettings Create()
        {
            var ret = new PlayerSettings();
            ret.BoolList = new List<bool>();
            ret.IntList = new List<int>();
            ret.FloatList = new List<float>();
            
            //bool
            for (int i = BoolMinIndex; i <= BoolMaxIndex; i++)
            {
                ret.BoolList.Add(false);
            }
            
            //int
            for (int i = IntMinIndex; i <= IntMaxIndex; i++)
            {
                ret.IntList.Add(default);
            }
            
            //float
            for (int i = FloatMinIndex; i <= FloatMaxIndex; i++)
            {
                ret.FloatList.Add(default);
            }
            ret.Init();
            
            return ret;
        }

        protected virtual void Init()
        {
            BoolList[IsMusicOn] = true;
            BoolList[IsSoundOn] = true;
        }

        public bool ReverseMusic()
        {
            BoolList[IsMusicOn] = !BoolList[IsMusicOn];
            AudioFacade.instance.IsMusicOn = BoolList[IsMusicOn];
            AudioFacade.instance.SetMusicOn(BoolList[IsMusicOn]);
            return BoolList[IsMusicOn];
        }

        public bool ReverseSound()
        {
            BoolList[IsSoundOn] = !BoolList[IsSoundOn];
            AudioFacade.instance.IsSoundOn = BoolList[IsSoundOn];
            AudioFacade.instance.SetSoundOn(BoolList[IsSoundOn]);
            return BoolList[IsSoundOn];
        }
        
        void IPlayerSave.OnLoad()
        {
            AudioFacade.instance.IsMusicOn = BoolList[IsMusicOn];
            AudioFacade.instance.IsSoundOn = BoolList[IsSoundOn];
        }

        void IPlayerSave.OnUpdate(UpdateTimeInfo time)
        {
            
        }

        void IPlayerSave.OnSave()
        {
            
        }
    }
}