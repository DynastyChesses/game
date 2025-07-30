using System;
using Newtonsoft.Json;
using UnityEngine;

namespace HotUpdate.osP1.Save
{
    public class PlayerSave: Singleton<PlayerSave>
    {
        public PlayerAssets PlayerAssets { get;private set; }
        
        public PlayerProgress PlayerProgress { get;private set; }
        
        public PlayerUnlock PlayerUnlock { get;private set; }
        
        public PlayerSettings PlayerSettings { get;private set; }

        private int _updatorId = EquineScheduler.INVALID;
        
        public void Load()
        {
            var jsonStr =  PlayerPrefs.GetString(PlayerAssets.Key, string.Empty);
            if (jsonStr == string.Empty)
            {
                PlayerAssets = PlayerAssets.Create();
            }
            else
            {
                PlayerAssets = JsonConvert.DeserializeObject<PlayerAssets>(jsonStr);
            }
            
            
            jsonStr = PlayerPrefs.GetString(PlayerProgress.Key, string.Empty);
            if (jsonStr == string.Empty)
            {
                PlayerProgress = PlayerProgress.Create();
            }
            else
            {
                PlayerProgress = JsonConvert.DeserializeObject<PlayerProgress>(jsonStr);
            }
            
            jsonStr = PlayerPrefs.GetString(PlayerUnlock.Key, string.Empty);
            if (jsonStr == string.Empty)
            {
                PlayerUnlock = PlayerUnlock.Create();
            }
            else
            {
                PlayerUnlock= JsonConvert.DeserializeObject<PlayerUnlock>(jsonStr);
            }
            
            jsonStr = PlayerPrefs.GetString(PlayerSettings.Key, string.Empty);
            if (jsonStr == string.Empty)
            {
                PlayerSettings = PlayerSettings.Create();
            }
            else
            {
                PlayerSettings= JsonConvert.DeserializeObject<PlayerSettings>(jsonStr);
            }
            
            //init
            (PlayerAssets as IPlayerSave).OnLoad();
            (PlayerSettings as IPlayerSave).OnLoad();

            _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);
        }

        private void OnUpdate(int a, object b, UpdateTimeInfo time)
        {
            (PlayerAssets as IPlayerSave).OnUpdate(time);
            (PlayerSettings as IPlayerSave).OnUpdate(time);
        }

        public void Save()
        {
            (PlayerAssets as IPlayerSave).OnSave();
            (PlayerSettings as IPlayerSave).OnSave();
            //TODO: remove Update
            
            //assets
            var jsonStr = JsonConvert.SerializeObject(PlayerAssets);
            PlayerPrefs.SetString(PlayerAssets.Key, jsonStr);
            
            //progress
            jsonStr = JsonConvert.SerializeObject(PlayerProgress);
            PlayerPrefs.SetString(PlayerProgress.Key, jsonStr);
            
            //unlock
            jsonStr = JsonConvert.SerializeObject(PlayerUnlock);
            PlayerPrefs.SetString(PlayerUnlock.Key, jsonStr);
            
            //settings
            jsonStr = JsonConvert.SerializeObject(PlayerSettings);
            PlayerPrefs.SetString(PlayerSettings.Key, jsonStr);
            
            PlayerPrefs.Save();
        }

        public override void Dispose()
        {
            EquineScheduler.RemoveLimitUpdator(ref _updatorId);
        }
    }
}
    
