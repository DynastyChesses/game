using System;

namespace MobileSDK.Account
{
    public class TestAccountStrategy : IAccountStrategy
    {
        public void Auth(Action<bool, IUserInfo> callback)
        {
            callback(true, new TestAccount());
        }
    }

    public class TestAccount : IUserInfo
    {
        public string UId => "testUId";

        public string UserName => "testUname";
    }
}
