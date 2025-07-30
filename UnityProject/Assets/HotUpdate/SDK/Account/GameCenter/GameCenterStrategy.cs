using System;
using UnityEngine;

public class GameCenterStrategy : IAccountStrategy
{
    private ILogger _logger = LoggerFactory.Get("MobileSDK:Account:GameCenter");

    /// <summary>
    /// 请求登录Game Center
    /// </summary>
    /// <param name="callback"></param>
    public void Auth(Action<bool, IUserInfo> callback)
    {
#if !UNITY_IOS
            throw new NotSupportedException("GameCenter is not supported on this platform");
#endif
        _logger.Debug($"RequestAuth");
        Social
            .localUser
            .Authenticate(
                (success) =>
                {
                    this._logger.Debug($"AuthCallback success:{success}");
                    if (success)
                    {
                        this._logger.Debug($"UserId: {Social.localUser.id}");
                        this._logger.Debug($"UserName: {Social.localUser.userName}");
                        callback(
                            success,
                            new GameCenterAccount()
                            {
                                UId = Social.localUser.id,
                                UserName = Social.localUser.userName
                            }
                        );
                        return;
                    }

                    callback(false, null);
                }
            );
    }
}

public class GameCenterAccount : IUserInfo
{
    public string UId { get; set; }

    public string UserName { get; set; }
}