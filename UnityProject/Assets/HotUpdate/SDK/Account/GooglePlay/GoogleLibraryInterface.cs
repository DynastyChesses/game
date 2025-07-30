using System;
using MobileSDK.IAP.GoogleBilling;
using UnityEngine;
public class GoogleLibraryInterface
{
    private AndroidJavaObject _playServiceClient;
    private ILogger _logger;

    public GoogleLibraryInterface()
    {
        this._logger = LoggerFactory.Get("GoogleLibraryInterface");
    }

    public Action OnConsumeResult;

    /// <summary>
    /// 请求登录验证
    /// </summary>
    /// <param name="callback"></param>
    public void Auth(Action<bool, PlayerInfo> callback)
    {
        var jCallback = new JsonCallbackWithUnitySynchronizationContext<SignInResult>(
            (signInResult) =>
            {
                this._logger.Debug($"OnBillingSetupFinished: {signInResult.result}");
                bool result = signInResult.result == "ok";
                if (!result)
                {
                    callback(false, null);
                    return;
                }
                callback(
                    result,
                    new PlayerInfo()
                    {
                        playerId = signInResult.playerId,
                        playerName = signInResult.playerName
                    }
                );
            }
        );

        this._playServiceClient.Call("auth", jCallback);
    }

    /// <summary>
    /// 初始google play game services
    /// </summary>
    public void InitService()
    {
        this._logger.Debug($"InitService");
        using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>(
                "currentActivity"
            );
            this._playServiceClient = new AndroidJavaObject(
                "com.ethan.googlelibrary.PlayServiceManager"
            );

            this._playServiceClient.Call("init", currentActivity);
        }
    }
}