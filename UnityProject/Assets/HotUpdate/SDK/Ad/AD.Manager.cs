using MobileSDK;
using MobileSDK.Ad;

public class ADManager : IRewardedAdListener
{
    private ILogger _logger;

    public ADManager()
    {
        this._logger = LoggerFactory.Get("ADManager");
    }

    public void Initialize()
    {
        this._logger.Debug($"Initialize");
        AdService.instance.SetRewardedAdListener(this);
    }

    public void OnRewardedAdDisplayed()
    {
        this._logger.Debug($"OnRewaredAdDisplayed");
    }

    public void OnRewardedAdHidden()
    {
        this._logger.Debug($"OnRewaredAdHidden");
    }

    public void OnRewardedAdLoaded()
    {
        this._logger.Debug($"OnRewaredAdLoaded");
    }

    public void OnRewardedAdReceivedReward()
    {
        this._logger.Debug($"OnRewaredAdReceivedReward");
    }
}
