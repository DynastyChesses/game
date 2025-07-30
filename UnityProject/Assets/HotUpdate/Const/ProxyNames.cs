using System;
using System.Collections.Generic;
using Google.Protobuf;
using Google.Protobuf.Reflection;

public class ProxyNames
{
    //
    public static Dictionary<int, MessageDescriptor> reflect_maps = new Dictionary<int, MessageDescriptor>()
    {
        {1, MiracleWar.GcUserInfo.Descriptor},
        {2, MiracleWar.CgUserInfo.Descriptor},
        {3, MiracleWar.CgStartGame.Descriptor},
        {4, MiracleWar.GcTimeSync.Descriptor},
        {5, MiracleWar.CgTimeSync.Descriptor},
        {6, MiracleWar.GcUserLogout.Descriptor},
        {7, MiracleWar.GcAllUsers.Descriptor},
        {8, MiracleWar.GcStartGame.Descriptor},
    };

    public static int GetId(string name)
    {
        foreach (var item in reflect_maps)
        {
            if (item.Value.FullName == name)
            {
                return item.Key;
            }
        }

        return -1;
    }
    
    // 用户
    public const string User = "User";
    public const string Time = "Time";
    public const string Game = "Game";

}