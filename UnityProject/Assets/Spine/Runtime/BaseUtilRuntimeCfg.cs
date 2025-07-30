using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUtilRuntimeCfg : SingletonCfgBase
{
    // ------------- 子类必须实现的指定签名的静态单例方法才能显示在ProjectSetting界面
    static BaseUtilRuntimeCfg s_Inst;
    public static BaseUtilRuntimeCfg Instance
    {
        get
        {
            if (s_Inst == null)
                s_Inst = LoadOrCreate<BaseUtilRuntimeCfg>(runtimeAsset: true);
            return s_Inst;
        }
    }
    // --------------------------------------------

    // 开发代号，生命期内尽量不要变，BI中会用它区分项目
    public string devCodeName = "";

    public EngineBIConfig biConfig;

}

[System.Serializable]
public class EngineBIConfig
{
    // 只打印bi消息，不发送
    public bool onlyLoggingNotSend = false;

    // 测试用的bi项目id
    public string biTestAppId = "";

}