using System;
using UnityEngine;

namespace MobileSDK.Account.GooglePlay
{
    public class GooglePlayStrategy : IAccountStrategy
    {
        private IAccountStrategy _accountStrategyImplementation;
        // private GoogleLibraryInterface _interface;
        //
        // public void Init()
        // {
        //     this._interface = new GoogleLibraryInterface();
        //     this._interface.InitService();
        // }
        //
        // public void Auth(Action<bool, IUserInfo> callback)
        // {
        //     this._interface.Auth(callback);
        // }
        public void Auth(Action<bool, IUserInfo> callback)
        {
            // throw new NotImplementedException();
        }
    }
}
