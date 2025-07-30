using System;
using MobileSDK;
using MobileSDK.Account;
using MobileSDK.Account.GooglePlay;
using UnityEngine;

internal static class AuthSDKManager
{
    private static ILogger _logger = LoggerFactory.Get("AuthSDKManager");

    /// <summary>
    /// 获取上一次登录完成后保存的用户信息
    /// </summary>
    public static IUserInfo LastUserInfo => AccountManager.instance.LastUserinfo();

    /// <summary>
    /// 登录策略是否已加载完成
    /// </summary>
    public static bool StrategyLoaded { get; private set; }

    /// <summary>
    /// 当前是否可以进行删除角色
    /// </summary>
    /// <returns></returns>
    private static bool CanDeleted()
    {
        var userInfo = AccountManager.instance.LastUserinfo();

        return userInfo != null;
    }

    /// <summary>
    /// 删除此账号下对应的角色
    /// </summary>
    /// <param name="deleteRoleCallback"></param>
    public static void DeleteRoleOfAccount(Action<bool, int> deleteRoleCallback)
    {
        if (!CanDeleted())
        {
            _logger.Info("Can Deleted :false");
            deleteRoleCallback?.Invoke(true, 0);
            return;
        }

        var userInfo = AccountManager.instance.LastUserinfo();
        if (userInfo == null)
        {
            _logger.Info("GetUserInfo :null");
            return;
        }

        UnityEngine.Debug.LogError($"删除账号对应的角色 uid:{userInfo.UId} name:{userInfo.UserName}");
        // 删除帐号 TODO
        // HttpManager.Instance.DeleteAccountRequest(
        //     userInfo.UId,
        //     (bool ret) =>
        //     {
        //         _logger.Info($"删除账号角色结果:" + ret);
        //         deleteRoleCallback(true, 0);
        //     }
        // );
    }

    /// <summary>
    /// 请求登录验证
    /// </summary>
    /// <param name="callback"></param>
    public static void Auth(Action<bool, IUserInfo> callback)
    {
        AccountManager.instance.Auth(callback);
    }

    /// <summary>
    /// 选择登录平台
    /// </summary>
    public static void LoadStrategy(SignInStrategy strategy, Action<bool> resultCallback)
    {
        StrategyLoaded = false;
        void onLoadStrategyFinish(bool result, IAccountStrategy strategy)
        {
            if (result)
                AccountManager.instance.SetStrategy(strategy);

            StrategyLoaded = true;

            resultCallback(result);
        }

        switch (strategy)
        {
            // GameCenter登录
            case SignInStrategy.GameCenter:
                onLoadStrategyFinish(true, new GameCenterStrategy());
                break;

            //Facebook 登录
            case SignInStrategy.Facebook:
                // TODO
                break;
            // Steam登录
            case SignInStrategy.Steam:
                var steamStrategy = new SteamStrategy();
                onLoadStrategyFinish(true, steamStrategy);
                break;

            // 游客登陆
            case SignInStrategy.Guest:
                var guestStrategy = new GuestStrategy();
                onLoadStrategyFinish(true, guestStrategy);
                break;
            // GooglePlay登陆
            case SignInStrategy.GooglePlay:
                var googlePlayStrategy = new GooglePlayStrategy();
                googlePlayStrategy.Init();
                onLoadStrategyFinish(true, googlePlayStrategy);
                break;
            default:
                throw new NotImplementedException("Not Implement Strategy:" + strategy);
        }
    }
}

/// <summary>
/// 登录策略
/// </summary>
public enum SignInStrategy
{
    GameCenter,
    GooglePlay,
    Facebook,

    /// <summary>
    /// 使用游客登陆
    /// </summary>
    Guest,

    // TODO
    Steam
}
