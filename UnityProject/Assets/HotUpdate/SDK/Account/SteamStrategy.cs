using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobileSDK.Account;
using System;

public class SteamStrategy : IAccountStrategy
{
// #if !DISABLESTEAMWORKS
//     public void Auth(Action<bool, IUserInfo> callback)
//     {
//         SteamScript.Instance.StartSteam(
//             (result) =>
//             {
//                 if (!result)
//                 {
//                     callback(false, null);
//                     return;
//                 }
//                 var playerInfo = new SteamPlayerInfo(
//                     SteamScript.Instance.getUserName(),
//                     SteamScript.Instance.getUserID()
//                 );
//                 //
//                 long time = SteamScript.Instance.getBuyTime();
//                 UnityEngine.Debug.LogError("time:" + time);
//                 long during = SteamScript.Instance.getPlayDuring();
//                 UnityEngine.Debug.LogError("during:" + during);
//                 callback(true, playerInfo);
//             }
//         );
//     }
// #else
    public void Auth(Action<bool, IUserInfo> callback)
    {
        throw new NotSupportedException("SteamSDK is not supported in this platform!");
    }
// #endif
}

public class SteamPlayerInfo : IUserInfo
{
    private string _userName;
    private string _uid;

    public SteamPlayerInfo(string UserName, string UId)
    {
        this._userName = UserName;
        this._uid = UId;
    }

    public string UId => this._uid;

    public string UserName => this._userName;
}
