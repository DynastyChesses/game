#if PRODUCT_GLOBAL
using ILRuntimeDLL.BI;
using KR;
using System;

namespace ILRuntimeDLL.SDK
{
    internal static partial class AdManager
    {
        private enum RewardVideoStep
        {
            EntryDisplay = 0,   //激励入口展示
            EntryClick,         //激励入口点击
            Display,            //激励广告展示
            Cancel,             //激励广告取消
            LoadFail,           //激励广告加载失败
            EarnedReward        //激励广告领奖
        }
        
        // private static Action<ForRewardItem, bool> rewardVideoFinishCallback;
        // private static bool rewardFinished = false;
        // private static ForRewardItem _rewardItem;
        //
        // // public static void AddEarnedRewardEventListener(Action<ForRewardItem> outOnUserEarnedReward)
        // // {
        // //     outOnUserEarnedRewardCallback = outOnUserEarnedReward;
        // // }
        //
        // private static void AddEvents()
        // {
        //     FORADS.getInstance().onAdLoadedAction = OnAdLoaded;
        //     FORADS.getInstance().onAdClickedAction = OnAdClicked;
        //     FORADS.getInstance().onAdClosedAction = OnAdClosed;
        //     FORADS.getInstance().onAdDisplayedAction = OnAdDisplayed;
        //     FORADS.getInstance().onAdFailedToDisplayAction = OnAdFailedToDisplay;
        //     FORADS.getInstance().onAdFailedToLoadAction = OnAdFailedToLoad;
        //     FORADS.getInstance().onUserEarnedReward = OnUserEarnedReward;
        // }
        //
        // private static void log(string info)
        // {
        //     Log.Info(info);
        // }
        //
        // private static void OnAdLoaded(ForAd ad)
        // {
        //     log($"OnAdLoad:{ad}");
        // }
        //
        // private static void OnAdClicked(ForAd ad)
        // {
        //     log($"OnAdClicked:{ad}");
        // }
        //
        // private static void OnAdClosed(ForAd ad)
        // {
        //     log($"OnAdClosed:{ad}");
        //     if(ad.adType == ForAdType.REWARDEDAD) //激励视频
        //     {
        //         var e = BILogic.GetEvent<BIEvent_rewardAdsResult>();
        //         e.Action(AdEntryName, ad.platformDesc, ad.platformId, currentRewardECPM, rewardFinished ? 0 : 1);//播放完成result 0 中途推出位1
        //         e.Fire();
        //         
        //         if (rewardFinished)
        //         {
        //             rewardVideoFinishCallback?.Invoke(_rewardItem, true);
        //             TrackRewardAD(RewardVideoStep.EarnedReward, AdEntryName, ad);
        //             rewardFinished = false;
        //         }
        //         else
        //         {
        //             rewardVideoFinishCallback?.Invoke(_rewardItem, false);
        //             TrackRewardAD(RewardVideoStep.Cancel, AdEntryName, ad);
        //         }
        //     }
        // }
        //
        // private static void OnAdDisplayed(ForAd ad)
        // {
        //     log($"OnAdDisplayed:{ad}");
        //     if (ad.adType == ForAdType.REWARDEDAD) //激励视频
        //     {
        //         RecordRewardWatchTimes();
        //         var e = BILogic.GetEvent<BIEvent_rewardAdsShow>();
        //         e.Action(AdEntryName, ad.platformDesc, ad.platformId, currentRewardECPM);
        //         e.Fire();
        //         TrackRewardAD(RewardVideoStep.Display, AdEntryName, ad);
        //     }
        // }
        //
        // private static void OnAdFailedToDisplay(ForAd ad)
        // {
        //     log($"OnAdFailedToDisplay:{ad}");
        // }
        //
        // private static void OnAdFailedToLoad(ForAd ad)
        // {
        //     log($"OnAdFailedToLoad:{ad}");
        //     if (ad.adType == ForAdType.REWARDEDAD)
        //     {
        //         TrackRewardAD(RewardVideoStep.LoadFail, AdEntryName, ad);
        //     }
        // }
        //
        // private static void OnUserEarnedReward(ForRewardItem adItem)
        // {
        //     _rewardItem = adItem;
        //     rewardFinished = true;
        //     log($"OnUserEarnedReward:{adItem}");
        //     //outOnUserEarnedRewardCallback?.Invoke(adItem);
        // }
    }
}

#endif