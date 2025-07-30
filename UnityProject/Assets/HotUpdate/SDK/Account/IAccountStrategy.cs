using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface for account platform
/// </summary>
public interface IAccountStrategy
{
    /// <summary>
    /// SignIn
    /// </summary>
    /// <param name="callback"></param>
    public void Auth(Action<bool, IUserInfo> callback);
}