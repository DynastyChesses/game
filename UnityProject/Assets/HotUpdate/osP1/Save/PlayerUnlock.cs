using System;
using System.Collections.Generic;

namespace HotUpdate.osP1.Save
{
    [Serializable]
    public class PlayerUnlock
    {
        public static readonly string Key = nameof(PlayerUnlock);
        
        public Dictionary<NewFeature,bool> IsPopNewFeature;
        
        public Dictionary<GameItemType,bool> IsPopNewItem;

        private PlayerUnlock()
        {
            
        }
        public static PlayerUnlock Create()
        {
            var ret = new PlayerUnlock();
            ret.IsPopNewFeature = new Dictionary<NewFeature, bool>();
            ret.IsPopNewFeature[NewFeature.Bomb] = false;
            ret.IsPopNewFeature[NewFeature.RandomBox] = false;
            ret.IsPopNewFeature[NewFeature.BrickGenerator] = false;
            ret.IsPopNewFeature[NewFeature.BoxGenerator] = false;
            
            ret.IsPopNewItem = new Dictionary<GameItemType, bool>();
            ret.IsPopNewItem[GameItemType.Refresh] = false;
            ret.IsPopNewItem[GameItemType.Magnet] = false;
            ret.IsPopNewItem[GameItemType.ForceChoose] = false;
            ret.IsPopNewItem[GameItemType.Hammer] = false;
            return ret;
        }
    }
}