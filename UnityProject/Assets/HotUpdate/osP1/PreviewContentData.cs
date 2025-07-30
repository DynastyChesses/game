using System.Collections.Generic;

namespace HotUpdate.osP1
{
    public enum NewFeature
    {
        Bomb,
        RandomBox,
        BrickGenerator,
        BoxGenerator,
    }

    
    
    public class PreviewContentData:Singleton<PreviewContentData>
    {
        public Dictionary<NewFeature, (int, int)> FeatureRange { get; private set; }
        public Dictionary<NewFeature, string> FeatureName{ get; private set; }
        public Dictionary<NewFeature, string> FeatureDesc{ get; private set; }
        
        public Dictionary<GameItemType,(int,int)> ItemRange { get; private set; }
        
        public Dictionary<GameItemType,string> ItemName{ get; private set; }
        
        public Dictionary<GameItemType, string> ItemDesc{ get; private set; }
        
        
        public override void Dispose()
        {
            //feature
            FeatureRange.Clear();
            FeatureName.Clear();
            FeatureDesc.Clear();
            //item
            ItemRange.Clear();
            ItemName.Clear();
            ItemDesc.Clear();
        }

        public override void Init()
        {
            //feature
            FeatureRange = new Dictionary<NewFeature, (int,int)>();
            FeatureName = new Dictionary<NewFeature, string>();
            FeatureDesc = new Dictionary<NewFeature, string>();
        
            var bomb = MetaManager.instance.Meta.TbGameUnlock.DataMap[201];
            var randomBox = MetaManager.instance.Meta.TbGameUnlock.DataMap[202];
            var brickGenerator = MetaManager.instance.Meta.TbGameUnlock.DataMap[203];
            var boxGenerator = MetaManager.instance.Meta.TbGameUnlock.DataMap[204];

            FeatureRange[NewFeature.Bomb] = (bomb.Show, bomb.Unlock);
            FeatureRange[NewFeature.RandomBox] = (randomBox.Show, randomBox.Unlock);
            FeatureRange[NewFeature.BrickGenerator] = (brickGenerator.Show, brickGenerator.Unlock);
            FeatureRange[NewFeature.BoxGenerator] = (boxGenerator.Show, boxGenerator.Unlock);

            FeatureName[NewFeature.Bomb] = bomb.Name;
            FeatureName[NewFeature.RandomBox] = randomBox.Name;
            FeatureName[NewFeature.BrickGenerator] = brickGenerator.Name;
            FeatureName[NewFeature.BoxGenerator] = boxGenerator.Name;

            FeatureDesc[NewFeature.Bomb] = bomb.Desc;
            FeatureDesc[NewFeature.RandomBox] = randomBox.Desc;
            FeatureDesc[NewFeature.BrickGenerator] = brickGenerator.Desc;
            FeatureDesc[NewFeature.BoxGenerator] = boxGenerator.Desc;
            
            //item
            ItemRange = new Dictionary<GameItemType, (int,int)>();
            ItemName = new Dictionary<GameItemType, string>();
            ItemDesc = new Dictionary<GameItemType, string>();
            
            var refresh = MetaManager.instance.Meta.TbGameUnlock.DataMap[101];
            var magnet = MetaManager.instance.Meta.TbGameUnlock.DataMap[102];
            var forceChoose = MetaManager.instance.Meta.TbGameUnlock.DataMap[103];
            var hammer = MetaManager.instance.Meta.TbGameUnlock.DataMap[104];
            
            ItemRange[GameItemType.Refresh] = (refresh.Show, refresh.Unlock);
            ItemRange[GameItemType.Magnet] = (magnet.Show, magnet.Unlock);
            ItemRange[GameItemType.ForceChoose] = (forceChoose.Show, forceChoose.Unlock);
            ItemRange[GameItemType.Hammer] = (hammer.Show, hammer.Unlock);
            
            ItemName[GameItemType.Refresh] = refresh.Name;
            ItemName[GameItemType.Magnet] = magnet.Name;
            ItemName[GameItemType.ForceChoose] = forceChoose.Name;
            ItemName[GameItemType.Hammer] = hammer.Name;
            
            ItemDesc[GameItemType.Refresh] = refresh.Desc;
            ItemDesc[GameItemType.Magnet] = magnet.Desc;
            ItemDesc[GameItemType.ForceChoose] = forceChoose.Desc;
            ItemDesc[GameItemType.Hammer] = hammer.Desc;
            
        }
    }
}