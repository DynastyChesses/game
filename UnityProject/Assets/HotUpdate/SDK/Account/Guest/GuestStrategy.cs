using System;
using UnityEngine;

namespace MobileSDK.Account
{
    /// <summary>
    /// 游客账号登录
    /// 使用UUID生成uid并使用PlayerPrefs保存
    /// 玩家名用Guest+UUID后四位拼接
    /// </summary>
    public class GuestStrategy : IAccountStrategy
    {
        private static readonly string _prefsKey = "GuestStrategy:UId";
        private ILogger _logger = LoggerFactory.Get("GuestStrategy");

        public void Auth(Action<bool, IUserInfo> callback)
        {
            this._logger.Debug("Auth");
            var guestUId = PlayerPrefs.GetString(_prefsKey);
            if (string.IsNullOrEmpty(guestUId))
            {
                this._logger.Debug($"there is no cache, create a new guest uid");
                guestUId = Guid.NewGuid().ToString();
                PlayerPrefs.SetString(_prefsKey, guestUId);
            }
            var userName = $"Guest-{guestUId.Substring(guestUId.Length - 4)}";
            callback(true, new GuestInfo(guestUId, userName));
        }
    }
}
