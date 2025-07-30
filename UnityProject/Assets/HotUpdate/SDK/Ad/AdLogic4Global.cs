#if PRODUCT_GLOBAL
using System;
using ILRuntime.Common;
using ILRuntime.Define;
using ILRuntimeDLL.Controller;
using KR.Manager;
using MobileSDK;
using MobileSDK.Ad;

namespace ILRuntimeDLL.SDK
{
    public partial class AdLogic4Global : AdLogic, IRewardedAdListener
    {
        private DBManager _dbMgr => DBManager.Instance;

        /// <summary>
        /// 广告数据表
        /// </summary>
        private DataTable _table;

        /// <summary>
        /// 广告数据（服务器数据）
        /// </summary>
        private AdModule _module;

        public override void Initialize()
        {
            Log.Debug($"AdLogic4Global.Initialize() ");

            if (_table == null)
            {
                _table = _dbMgr.ReadFullTable("ad");
            }
            if (_module == null)
            {
                _module = new AdModule();
            }

            _module.Init(_table);

            // 监听网络
            AddListener();

            // [Tag] 请求广告数据
            NetManager.AddLoginCallbackListener(AdListRequest);
            AdService.Instance.SetRewardedAdListener(this);

            AdManager.Initialize();
        }

        private void Destroy()
        {
            _table = null;
            _module = null;

            // 移除监听
            RemoveListener();

            // [Tag] 请求广告数据
            NetManager.RemoveLoginCallbackListener(AdListRequest);

            //base.Destroy();
        }

        public override (int useTimes, int totalTimes) GetTimes(int adId)
        {
            if (adId == 0)
            {
                return (0, 0);
            }

            return _module.GetTimes(adId);
        }

        public override int GetId(int type, int value)
        {
            return _module.GetId(type, value);
        }

        public override int GetLeftTimes(int adId)
        {
            (int useTimes, int totalTimes) = GetTimes(adId);

            return totalTimes - useTimes;
        }

        //public override int SetCoupon(int count)
        //{
        //    return _module.Set(count);
        //}

        public override int GetCoupon()
        {
            return _module.Coupon;
        }

        public override bool IsLimited(int adId)
        {
            return _module.IsLimited(adId);
        }

        public override void LoadAd()
        {
            AdManager.LoadAd();
        }

        public override bool IsRewardAdLoaded()
        {
            return AdManager.IsRewardAdLoaded();
        }

        private Action<RewardAdObject, bool> onRewardVideoFinished;

        public override void DisplayRewardAd(
            string entryName,
            Action<RewardAdObject, bool> onRewardVideoFinished
        )
        {
            this.onRewardVideoFinished = onRewardVideoFinished;
            AdService.Instance.ShowRewardAd();
        }

        public override void ShowTestAdView()
        {
            // AdManager.ShowTestAdView();
        }

        public override void SetUserTags(string[] tags)
        {
            // AdManager.SetUserTags(tags);
        }

        public override string GetRewardECPM()
        {
            return AdManager.GetRewardECPM();
        }

        public override void RewardEntryShown(int adId)
        {
            AdManager.RewardEntryShown(GetEntryName(adId));
        }

        public override void RewardEntryClicked(int adId)
        {
            AdManager.RewardEntryClicked(GetEntryName(adId));
        }

        public override UserAcceptStatus UserAccepted
        {
            get => AdManager.UserAccepted;
            set => AdManager.UserAccepted = value;
        }

        // private RewardAdObject ConvertAD(ForRewardItem rewardItem)
        // {
        //     if (rewardItem == null)
        //         return null;
        //     return new RewardAdObject()
        //     {
        //         adType = ForAdType.REWARDEDAD,
        //         positionId = rewardItem.forPosId,
        //         platform = rewardItem.platform,
        //         platformId = rewardItem.platformPosId,
        //         bid = rewardItem.bid,
        //         rewardType = rewardItem.rewardType,
        //         rewardAmount = rewardItem.rewardAmount
        //     };
        // }
        //
        // private AdObject ConvertAD(ForAd ad)
        // {
        //     if (ad == null)
        //         return null;
        //     return new AdObject()
        //     {
        //         adType = ad.adType,
        //         positionId = ad.positionId,
        //         platform = ad.platformDesc,
        //         platformId = ad.platformId,
        //         platformDesc = ad.platformDesc,
        //         bid = ad.bid
        //     };
        // }

        private WatchAdTipsCtrl.WatchAdTipsContext _context;

        /// <summary>
        /// 打开广告
        /// </summary>
        /// <param name="adId">广告对接类型（参见：AdConst.cs）</param>
        /// <param name="method">返回服务器广告协议，GC_AD_REWARD==null表示[未观看]或[观看失败]</param>
        /// <param name="args">广告对接参数</param>
        /// <returns></returns>
        public override bool OpenAd(int adId, Action<GC_AD_REWARD> method, string args = default)
        {
            if (_context != null)
            {
                // 观看中（按钮被连点了...）
                if (_context.adId == adId)
                {
                    return true;
                }

                Log.Error($"AdLogic4Global.OpenAd() adId={_context.adId}. adId={adId}");

                return false;
            }

            // 观看广告次数已达上限
            if (_module.IsLimited(adId) && adId != AdConst.adFight)
            {
                (int index, int count) = _module.GetTimes(adId);

                Log.Error($"AdLogic4Global.OpenAd() adId={adId}, index={index}, count={count}");

                return false;
            }

            _context = new WatchAdTipsCtrl.WatchAdTipsContext()
            {
                adId = adId,
                passCount = _module.Coupon,
                args = args,
                adReward = method,
                callback = CloseTipsCallback
            };

            AdManager.ShowWatchAdTip(_context);

            return true;
        }

        public override bool OpenAd2(int adId, Action<GC_AD_REWARD> method, string args = default)
        {
            if (_context != null)
            {
                // 观看中（按钮被连点了...）
                if (_context.adId == adId)
                {
                    return true;
                }

                Log.Error($"AdLogic4Global.OpenAd() adId={_context.adId}. adId={adId}");

                return false;
            }

            _context = new WatchAdTipsCtrl.WatchAdTipsContext()
            {
                adId = adId,
                passCount = _module.Coupon,
                args = args,
                adReward = method,
                callback = CloseTipsCallback
            };

            AdManager.ShowWatchAdTip2(_context);

            return true;
        }

        private void CloseTipsCallback(WatchAdTipsCtrl.WatchAdTipsContext context)
        {
            if (_context == null)
            {
                Log.Error($"AdLogic4Global.CloseTipsCallback() adId={context.adId}");

                return;
            }

            if (_context.adId != context.adId)
            {
                Log.Error(
                    $"AdLogic4Global.CloseTipsCallback() adId={_context.adId},  adId={context.adId}"
                );

                return;
            }

            Log.Debug(
                $"AdLogic4Global.CloseTipsCallback() adId={_context.adId},  option={context.option}, args={context.args}"
            );

            if (context.option == AdConst.adOptionWatch) // 开始看广告
            {
                AdRewardRequest(context.adId, context.option, context.args);
            }
            else if (context.option == AdConst.adOptionCoupon) // 点券跳广告
            {
                AdRewardRequest(context.adId, context.option, context.args);
            }
            else // 取消看广告
            {
                _context.adReward?.Invoke(null);
                _context = null;
            }
        }

        /// <summary>
        /// 广告奖励
        /// </summary>
        private void AdReward(GC_AD_REWARD msg)
        {
            if (_context == null)
            {
                Log.Error($"AdLogic4Global.AdReward() _context is null, adId={msg.adId}");

                return;
            }

            if (_context.adId == msg.adId)
            {
                _context.adReward?.Invoke(msg);
                _context = null;

                return;
            }

            _context = null;

            Log.Error($"AdLogic4Global.AdReward() adId={_context.adId}, adId={msg.adId}");
        }

        public void OnRewardedAdLoaded()
        {
            //nothing
        }

        public void OnRewardedAdDisplayed()
        {
            // nothing
        }

        public void OnRewardedAdHidden()
        {
            this.onRewardVideoFinished?.Invoke(null, false);
            this.onRewardVideoFinished = null;
        }

        public void OnRewardedAdReceivedReward()
        {
            UnityEngine.Debug.Log("OnRewardedAdReceivedReward");
            this.onRewardVideoFinished?.Invoke(new RewardAdObject(), true);
            this.onRewardVideoFinished = null;
        }
    }
}
#endif
