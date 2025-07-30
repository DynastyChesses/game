using System;
using JetBrains.Annotations;
using MobileSDK.Utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace MobileSDK.Account
{
    public class AccountManager : Singleton<AccountManager>
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public IUserInfo UserInfo => this._userInfo;

        private ILogger _logger;
        private IAccountStrategy _strategy;
        private IUserInfo _userInfo;

        public AccountManager()
        {
            this._logger = LoggerFactory.Get("Account");
        }

        public void SetStrategy(IAccountStrategy strategy)
        {
            this._strategy = strategy;
        }

        /// <summary>
        /// 请求进行登录验证
        /// </summary>
        /// <param name="callback"></param>
        public void Auth(Action<bool, IUserInfo> callback)
        {
            _logger.Debug($"Auth: {this._strategy}");
            _checkStrategyIsNotNull();
            this._strategy.Auth(
                (result, info) =>
                {
                    if (result)
                    {
                        _logger.Debug($"Auth success: UId:{info.UId} UName:{info.UserName}");
                        this._userInfo = info;
                        this._cacheLastUserInfo(this._userInfo);
                    }
                    callback(result, info);
                }
            );
        }

        /// <summary>
        /// 最后一次登录成功的用户信息
        /// </summary>
        public IUserInfo LastUserinfo()
        {
            var cache = PlayerPrefs.GetString("AccountManager:UserInfoCache");
            if (string.IsNullOrEmpty(cache))
                return null;

            return JsonUtility.FromJson<UserInfoCached>(cache);
        }

        private void _checkStrategyIsNotNull()
        {
            if (this._strategy == null)
                throw new Exception("AccountStrategy is null, please set it first.");
        }

        /// <summary>
        /// 缓存用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        private void _cacheLastUserInfo(IUserInfo userInfo)
        {
            var userInfoCached = new UserInfoCached(userInfo.UId, userInfo.UserName);
            var json = JsonUtility.ToJson(userInfoCached);
            PlayerPrefs.SetString("AccountManager:UserInfoCache", json);
        }

        public override void Dispose()
        {
            
        }
    }

    [Serializable]
    public class UserInfoCached : IUserInfo
    {
        [SerializeField]
        private string uId;

        [SerializeField]
        private string username;

        public UserInfoCached(string uId, string username)
        {
            this.uId = uId;
            this.username = username;
        }

        public string UId => this.uId;

        public string UserName => this.username;
    }
}
