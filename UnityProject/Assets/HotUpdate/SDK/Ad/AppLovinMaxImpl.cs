using System;
using System.Collections;
using System.Collections.Generic;
using MobileSDK.Ad;
using UnityEngine;

public class AppLovinMaxImpl : IRewardedAdProvider
{
    /// <summary>
    /// 激励广告加载完成
    /// </summary>
    public Action OnRewardedAdLoaded { get; set; }

    /// <summary>
    /// 激励广告已显示
    /// </summary>
    public Action OnRewardedAdDisplayed { get; set; }

    /// <summary>
    /// 激励广告隐藏
    /// </summary>
    public Action OnRewardedAdHidden { get; set; }

    /// <summary>
    /// 激励广告奖励已发放
    /// </summary>
    public Action OnRewardedAdReceivedReward { get; set; }

    private string adIdentifier;
    private ILogger _logger;

    public AppLovinMaxImpl()
    {
        this._logger = LoggerFactory.Get("ApplovinImpl");
    }

    public void Init(string sdkKey, string rewardedAdId, Action onInitFinished)
    {
        this.adIdentifier = rewardedAdId;
        MaxSdkCallbacks.OnSdkInitializedEvent += (configuration) =>
        {
            this._logger.Debug($"OnSdkInitialized");
            onInitFinished();
        };
        MaxSdk.SetSdkKey(sdkKey);
        MaxSdk.InitializeSdk();
        this._listenRewardedAdEvents();
    }

    /// <summary>
    /// 显示激励广告
    /// </summary>
    /// <param name="adIdentifier"></param>
    public void ShowRewardedAd()
    {
        this._logger.Debug($"ShowRewardedAd {adIdentifier}");
        MaxSdk.ShowRewardedAd(adIdentifier);
    }

    /// <summary>
    /// 监听激励广告的事件
    /// </summary>
    private void _listenRewardedAdEvents()
    {
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += (id, adInfo) =>
        {
            this._logger.Debug(
                $"RewardAdLoadedEvent id:{id} adInfo:{adInfo.DspName} {adInfo.NetworkName}"
            );
            this.OnRewardedAdLoaded?.Invoke();
        };

        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += (id, adInfo) =>
        {
            this._logger.Debug($"RewardedAdDisplayedEvent id:{id} adInfo:{adInfo.DspName}");
            this.OnRewardedAdDisplayed?.Invoke();
        };

        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += (id, adInfo) =>
        {
            this._logger.Debug($"RewardedAdHiddenEvent id:{id} adInfo:{adInfo}");
            this.OnRewardedAdHidden?.Invoke();
        };

        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += (id, reward, adInfo) =>
        {
            this._logger.Debug($"RewardedAdReceivedRewardEvent id:{id} adInfo:{adInfo}");
            this.OnRewardedAdReceivedReward?.Invoke();
        };
    }

    public bool IsRewardedAdReady()
    {
        return MaxSdk.IsRewardedAdReady(adIdentifier);
    }

    public void LoadRewardedAd()
    {
        MaxSdk.LoadRewardedAd(adIdentifier);
        }

        public void SetUserConsentSharePrivacyAboutGDPR(bool accepted)
        {
            MaxSdk.SetHasUserConsent(accepted);
        }

        public GDPRUserAcceptStatus GetUserConsentSharePrivacyAboutGDPR()
        {
            var iseUserConsentSet = MaxSdk.IsUserConsentSet();
            if (iseUserConsentSet)
            {
                return MaxSdk.HasUserConsent()
                    ? GDPRUserAcceptStatus.Accepted
                    : GDPRUserAcceptStatus.Decline;
            }
            return GDPRUserAcceptStatus.Unknow;
        }

        public void SetUserId(string userId)
        {
            MaxSdk.SetUserId(userId);
        }
    }
