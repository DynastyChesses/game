#if PRODUCT_GLOBAL
using KR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILRuntime.Define;
using UnityEngine;
using ILRuntimeDLL.BI;
using ILRuntimeDLL.Controller;
using KR.Manager;
using MobileSDK;
using MobileSDK.Ad;

namespace ILRuntimeDLL.SDK
{
    internal static partial class AdManager
    {
        private static string AdEntryName = "init";
        private static string currentRewardECPM = String.Empty;

        public static void Initialize()
        {
            var isDebug = RunVariants.CurrentSetting.startupParam.SDKDebug;

            if (GetAdSpaceIds().Length == 0)
                return;

            if (Application.isEditor)
                return;
            // FORADS.setLogPrintEnable(isDebug);
            // FORADS.init(isDebug);

            // AddEvents();
        }

        public static void LoadAd()
        {
            if (Application.isEditor)
                return;
            // FORADS.getInstance().loadAd(GetAdSpaceIds());
        }

        public static bool IsRewardAdLoaded()
        {
            if (Application.isEditor)
                return true;

            return AdService.Instance.IsRewardAdReady();
        }

        // public static void DisplayRewardAd(string entryName, Action<ForRewardItem, bool> onRewardVideoFinished)
        // {
        //     if (Application.isEditor)
        //     {
        //         TimerManager.Instance.doFrameOnce(1, () => onRewardVideoFinished?.Invoke(new ForRewardItem(), true));
        //         return;
        //     }
        //     if (!IsRewardAdLoaded())
        //     {
        //         FORADS.getInstance().loadAd(GetRewardAdSpaceId());
        //         return;
        //     }
        //     AdEntryName = entryName;
        //     rewardVideoFinishCallback = onRewardVideoFinished;
        //     rewardFinished = false;
        //     currentRewardECPM = GetRewardECPM();
        //     var raid = GetRewardAdSpaceId();
        //     FORADS.getInstance().displayAd(raid);
        // }

        // public static void ShowTestAdView()
        // {
        //     if (Application.isEditor)
        //         return;
        //     FORADS.getInstance().showTestAdView();
        // }
        //
        // public static void SetUserTags(string[] tags)
        // {
        //     FORADS.setUserTags(tags);
        // }

        public static string GetRewardECPM()
        {
            var raid = GetRewardAdSpaceId();
            return GetECPM(raid);
        }

        public static void RewardEntryShown(string entryName)
        {
            AdEntryName = entryName;
            var e = BILogic.GetEvent<BIEvent_rewardAdsEnter>();
            e.Action(AdEntryName, IsRewardAdLoaded());
            e.Fire();
            // TrackRewardAD(RewardVideoStep.EntryDisplay, AdEntryName, new ForAd(){positionId = GetRewardAdSpaceId()});
        }

        public static void RewardEntryClicked(string entryName)
        {
            AdEntryName = entryName;
            var e = BILogic.GetEvent<BIEvent_rewardAdsClick>();
            e.Action(AdEntryName);
            e.Fire();
        }

        public static void ShowWatchAdTip(WatchAdTipsCtrl.WatchAdTipsContext context)
        {
            RewardEntryClicked(context.adEntryName);
            UIManager.Instance.Open(UINames.WatchAdTips, context);
        }

        public static void ShowWatchAdTip2(WatchAdTipsCtrl.WatchAdTipsContext context)
        {
            RewardEntryClicked(context.adEntryName);
            UIManager.Instance.Open(UINames.WatchAdTips2, context);
        }
    }
}
#endif
