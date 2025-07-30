using System;
using System.Collections.Generic;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject;
using Spine.Unity;
using UnityEngine;

namespace HotUpdate.osP1
{
    public class GameImgCache : Singleton<GameImgCache>
    {
        public Dictionary<BattleColor, Sprite> TargetBrickImg { get; private set; } =
            new Dictionary<BattleColor, Sprite>();

        public Dictionary<string, Sprite> ComboImg { get; private set; } = new Dictionary<string, Sprite>();

        public Dictionary<string, Sprite> LevelSelectionImg { get; private set; } = new Dictionary<string, Sprite>();

        public Dictionary<NewFeature, Sprite> NewFeatureImg { get; private set; } =
            new Dictionary<NewFeature, Sprite>();
        
        public Dictionary<GameItemType, Sprite> GameItemImg { get; private set; } = new Dictionary<GameItemType, Sprite>();
        
        public Dictionary<int,Sprite> FeverBgImg { get; private set; } = new Dictionary<int,Sprite>();
        
        public Dictionary<ConsumeType, Sprite> ConsumeImg { get; private set; } = new Dictionary<ConsumeType, Sprite>();

        private readonly Dictionary<string, BattleColor> _targetBrickPath = new Dictionary<string, BattleColor>()
        {
            { "Assets/Arts/Textures/Play/mubiao_huang.png", BattleColor.Yellow },
            { "Assets/Arts/Textures/Play/mubiao_lan.png", BattleColor.Blue },
            { "Assets/Arts/Textures/Play/mubiao_qing.png", BattleColor.Cyan },
            { "Assets/Arts/Textures/Play/mubiao_hong.png", BattleColor.Red },
            { "Assets/Arts/Textures/Play/mubiao_fen.png", BattleColor.Pink },
            { "Assets/Arts/Textures/Play/mubiao_lv.png", BattleColor.Green },
            { "Assets/Arts/Textures/Play/mubiao_zi.png", BattleColor.Purple },
            { "Assets/Arts/Textures/Play/mubiao_zong.png", BattleColor.Brown }
        };

        private readonly Dictionary<string, string> _comboPath = new Dictionary<string, string>()
        {
            { "Assets/Arts/Textures/Play/good job.png", "GoodJob" },
            { "Assets/Arts/Textures/Play/good job_bg.png", "GoodJobBg" },

            { "Assets/Arts/Textures/Play/awesome.png", "Awesome" },
            { "Assets/Arts/Textures/Play/awesome_bg.png", "AwesomeBg" },

            { "Assets/Arts/Textures/Play/amazing.png", "Amazing" },
            { "Assets/Arts/Textures/Play/amazing_bg.png", "AmazingBg" },

            { "Assets/Arts/Textures/Play/fantastic.png", "Fantastic" },
            { "Assets/Arts/Textures/Play/fantastic_bg.png", "FantasticBg" },

            { "Assets/Arts/Textures/Play/perfect.png", "Perfect" },
            { "Assets/Arts/Textures/Play/perfect_bg.png", "PerfectBg" },
        };

        private readonly Dictionary<string, string> _levelSelectionImgPath = new Dictionary<string, string>()
        {
            { "Assets/Arts/Textures/Lobby/daohang_01.png", "BigRound" },
            { "Assets/Arts/Textures/Lobby/daohang_02.png", "SmallRound" },
        };

        private readonly Dictionary<string, NewFeature> _newFeatureImgPath =
            new Dictionary<string, NewFeature>()
            {
                { "Assets/Arts/Textures/Popup/popuo_yugao_zhadan.png", NewFeature.Bomb },
                { "Assets/Arts/Textures/Popup/popuo_yugao_suijipanzi.png", NewFeature.RandomBox },
                { "Assets/Arts/Textures/Popup/popuo_yugao_xiangzi.png", NewFeature.BrickGenerator },
                { "Assets/Arts/Textures/Popup/popuo_yugao_cheku.png", NewFeature.BoxGenerator }
            };
        
        private readonly Dictionary<string, GameItemType> _newItemImgPath =
            new Dictionary<string, GameItemType>()
            {
                { "Assets/Arts/Textures/Popup/popuo_daoju_zhuanhuan.png", GameItemType.Refresh },
                { "Assets/Arts/Textures/Popup/popuo_daoju_dangong.png", GameItemType.Magnet },
                { "Assets/Arts/Textures/Popup/popuo_daoju_xuanze.png", GameItemType.ForceChoose },
                { "Assets/Arts/Textures/Popup/popuo_daoju_chuizi.png", GameItemType.Hammer }
            };

        private readonly Dictionary<string, int> _feverBgImgPath = new Dictionary<string, int>()
        {
            { "Assets/Arts/Textures/Play/fever_bg_01.png", 0 },
            { "Assets/Arts/Textures/Play/fever_bg_02.png", 1 },
            { "Assets/Arts/Textures/Play/fever_bg_03.png", 2 },
            { "Assets/Arts/Textures/Play/fever_bg_04.png", 3 },
            { "Assets/Arts/Textures/Play/fever_bg_05.png", 4 },
            { "Assets/Arts/Textures/Play/fever_bg_06.png", 5 },
        };

        private readonly Dictionary<string, ConsumeType> _consumeIconPath = new Dictionary<string, ConsumeType>()
        {
            {"Assets/Arts/Textures/Popup/icon_coin_small.png",ConsumeType.Gold},
            {"Assets/Arts/Textures/Popup/icon_ad_small.png",ConsumeType.AdTicket},
            {"Assets/Arts/Textures/Popup/btn_icon_ad.png",ConsumeType.Ad}
        };

        public override void Dispose()
        {
        }

        public void Load(Action cb)
        {
            var count = 0;
            var total = 7;

            Action lambda = () =>
            {
                count++;
                if (count == total)
                    cb?.Invoke();
            };
            
            
            LoadCustom(_targetBrickPath, TargetBrickImg, lambda);
            LoadCustom(_comboPath, ComboImg, lambda);
            LoadCustom(_levelSelectionImgPath, LevelSelectionImg, lambda);
            LoadCustom(_newFeatureImgPath, NewFeatureImg, lambda);
            LoadCustom(_newItemImgPath, GameItemImg, lambda);
            LoadCustom(_feverBgImgPath,FeverBgImg, lambda);
            LoadCustom(_consumeIconPath, ConsumeImg, lambda);
        }


        private void LoadCustom<T>(Dictionary<string, T> resPath, Dictionary<T, Sprite> resCache, Action cb)
        {
            var count = 0;
            var total = resPath.Count;
            foreach (var (path, cacheKey) in resPath)
            {
                ResourceFacade.instance.LoadObjectAsync<Sprite>(path, sprite =>
                {
                    resCache[cacheKey] = sprite;

                    count++;
                    if (count == total)
                        cb?.Invoke();

                    return 0;
                });
            }
        }
    }
}