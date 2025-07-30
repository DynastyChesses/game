using System.Collections;
using System.Collections.Generic;
using MobileSDK;
using MobileSDK.Ad;
using MobileSDK.Utils;
using UnityEngine;
public class AdService : Singleton<AdService>
{
    ILogger _logger;

    public AdService()
    {
        this._logger = LoggerFactory.Get("AdService");
        this._rewardedAdListeners = new List<IRewardedAdListener>();
    }

    private List<IRewardedAdListener> _rewardedAdListeners;

    /// <summary>
    ///
    /// </summary>
    private IRewardedAdProvider _rewardedAdProvider;

    /// <summary>
    /// 注册激励广告Provider
    /// </summary>
    /// <param name="provider"></param>
    public void SetRewardedAdProvider(IRewardedAdProvider provider)
    {
        this._logger.Debug($"SetRewardedAdProvider {provider}");
        this._rewardedAdProvider = provider;
        provider.OnRewardedAdDisplayed += this._onRewardedAdDisplayed;
        provider.OnRewardedAdHidden += this._onRewardedAdHidden;
        provider.OnRewardedAdLoaded += this._onRewardedAdLoaded;
        provider.OnRewardedAdReceivedReward += this._onRewardedReceivedReward;
        if (!provider.IsRewardedAdReady())
            _preloadNextRewardedAd();
    }

    public void SetUserConsentSharePrivacyAboutGDPR(bool share)
    {
        this._rewardedAdProvider.SetUserConsentSharePrivacyAboutGDPR(share);
    }

    public GDPRUserAcceptStatus GetUserConsentSharePrivacyAboutGDPR()
    {
        return this._rewardedAdProvider.GetUserConsentSharePrivacyAboutGDPR();
    }

    public void SetUserId(string userId)
    {
        this._rewardedAdProvider.SetUserId(userId);
    }

    /// <summary>
    /// 设置监听者
    /// </summary>
    /// <param name="listener"></param>
    public void SetRewardedAdListener(IRewardedAdListener listener)
    {
        this._logger.Debug($"RewardedAdListener: {listener}");
        this._rewardedAdListeners.Add(listener);
    }

    public void ShowRewardAd()
    {
        this._logger.Debug($"ShowRewardAd");
        this._rewardedAdProvider.ShowRewardedAd();
    }

    public bool IsRewardAdReady()
    {
        var isReady = this._rewardedAdProvider.IsRewardedAdReady();
        this._logger.Debug($"IsRewardAdReady:{isReady}");
        return isReady;
    }

    private void _onRewardedAdLoaded()
    {
        this._logger.Debug($"onReawrdedAdLoaded");
        this._rewardedAdListeners.ForEach(listener =>
        {
            listener.OnRewardedAdLoaded();
        });
    }

    private void _onRewardedAdDisplayed()
    {
        this._logger.Debug($"onRewardedAdDisplayed");
        this._rewardedAdListeners.ForEach(listener =>
        {
            listener.OnRewardedAdDisplayed();
            // 提前加载下一次的广告
            this._preloadNextRewardedAd();
        });
    }

    private void _onRewardedAdHidden()
    {
        this._logger.Debug($"onRewardedAdHidden");
        this._rewardedAdListeners.ForEach(listener =>
        {
            listener.OnRewardedAdHidden();
            this._preloadNextRewardedAd();
        });
    }

    private void _onRewardedReceivedReward()
    {
        this._logger.Debug($"onRewardedReceivedReward");
        this._rewardedAdListeners.ForEach(listener =>
        {
            listener.OnRewardedAdReceivedReward();
            this._preloadNextRewardedAd();
        });
    }

    private void _preloadNextRewardedAd()
    {
        this._logger.Debug($"preloadNextRewardedAd");
        this._rewardedAdProvider.LoadRewardedAd();
    }

    public override void Dispose()
    {
        //
    }
}
