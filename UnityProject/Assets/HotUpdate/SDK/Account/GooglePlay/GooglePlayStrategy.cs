using System;
using UnityEngine;

public class GooglePlayStrategy : IAccountStrategy
{
    private GoogleLibraryInterface _interface;

    public void Init()
    {
        this._interface = new GoogleLibraryInterface();
        this._interface.InitService();
    }

    public void Auth(Action<bool, IUserInfo> callback)
    {
        this._interface.Auth(callback);
    }
}