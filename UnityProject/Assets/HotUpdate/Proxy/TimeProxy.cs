using System.Collections;
using System.Collections.Generic;
using Google.Protobuf;
using MiracleWar;
using UnityEngine;

public class TimeProxy : TBaseProxy<TimeProxy>
{

    public override void OnRegister()
    {
        base.OnRegister();
        // 注册监听 Gc
        RegisterMessageHandler(GcTimeSync.Descriptor.FullName, OnTimeSync);
    }
    
    private void OnTimeSync(IMessage obj)
    {
        // 
        GcTimeSync msg = (GcTimeSync)obj;
        EquineConfig.serverBaseTime = msg.Timestamp;
    }
    
    public TimeProxy() : base(ProxyNames.Time)
    {
        
    }
}
