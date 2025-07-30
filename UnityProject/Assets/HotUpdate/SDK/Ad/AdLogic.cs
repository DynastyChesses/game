using System;
using UnityEngine;

public enum UserAcceptStatus { UAS_UNKNOWN,UAS_ACCEPTED, UAS_DECLINE ,USA_ERROR};

    public abstract partial class AdLogic
    {
        private static AdLogic _instance;
        public static AdLogic Instance
        {
            get
            {
                if (_instance == null)
                {
#if PRODUCT_GLOBAL
                    _instance = new AdLogic4Global();
#else
                    // _instance = new AdLogic4JP();
#endif
                }

                return _instance;
            }
        }

        public static string GetEntryName(int adId)
        {
            switch (adId)
            {
                case AdConst.adShop0_99:
                    return "storead";
                default:
                    break;
            }
            return adId.ToString();
        }

        public virtual void Initialize()
        {
            Debug.LogError($"AdLogic.Initialize() ");
        }

        public virtual (int useTimes, int totalTimes) GetTimes(int adId)
        {
            return (0, 0);
        }

        public virtual int GetId(int type, int value)
        {
            return 0;
        }

        /// <summary>
        /// 获取剩余可观看次数
        /// </summary>
        /// <param name="adId">广告Id</param>
        public virtual int GetLeftTimes(int adId)
        {
            return 0;
        }

        public virtual int GetCoupon()
        {
            return 0;
        }

        public virtual bool IsLimited(int adId)
        {
            return true;
        }

        public virtual void LoadAd()
        {

        }

        public virtual bool IsRewardAdLoaded()
        {
            return false;
        }

        public virtual void DisplayRewardAd(string entryName, Action<RewardAdObject, bool> onRewardVideoFinished)
        {
            onRewardVideoFinished?.Invoke(null, false);
        }

        public virtual void ShowTestAdView()
        {

        }

        public virtual void SetUserTags(string[] tags)
        {

        }

        public virtual string GetRewardECPM()
        {
            return null;
        }

        public virtual void RewardEntryShown(int adId)
        {

        }

        public virtual void RewardEntryClicked(int adId)
        {

        }

        public virtual UserAcceptStatus UserAccepted
        {
            get => UserAcceptStatus.UAS_DECLINE;
            set { }
        }

        // public virtual bool OpenAd(int adId, Action<GC_AD_REWARD> method, string args = default)
        // {
        //     method?.Invoke(null);
        //
        //     return false;
        // }
        //
        // public virtual bool OpenAd2(int adId, Action<GC_AD_REWARD> method, string args = default)
        // {
        //     method?.Invoke(null);
        //
        //     return false;
        // }
    }

    public class AdObject
    {
        //变现联盟的广告类型，如插播、激励、banner等等
        public string adType;
        //变现联盟的广告位ID
        public string positionId;
        //渠道名称，如admob
        public string platform;
        //第三方的广告ID
        public string platformId;
        //广告描述，忽略
        public string platformDesc;
        //网络请求标识，uuid
        public string bid;
    }

    public class RewardAdObject : AdObject
    {
        public string rewardType;
        public string rewardAmount;
    }