using System;
using System.Collections.Generic;
using UnityEngine;

public class InitializeState:ClientState
{
    private ClientStateManager _innerCSM;
    // 资源配置
    private static List<string> allLabels = new List<string>()
    {
        "base",
        "font",
        "res",
        "data",
        // "spriteatlas",
        "audio",
        "mat",
        "texture",
        "spine"
        //"dll"
        
    };
    
    public InitializeState(IClientStateManager context):base(context, GameStateConst.INITIALIZE_STATE)
    {
        // TODO
    }

    public override void OnEnterState(int prevState, object context)
    {
        Logger.Debug("进入初始化状态");
        _innerCSM = new ClientStateManager(GameStateManager.NONE_STATE);
        LoadingInitSettingState.InitPopup();
        LoadingInitSettingState.RegisterUIPanelConfig();
        LoadingInitSettingState.RegisterCommonItem();
        SceneFacade.instance.InitMediator();
        // 开启监听
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_GLOBAL_LISTENER);
        // 开启Loading
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_GLOBAL_LOAD_PANEL);
        // 资源配置
        GameLaunch.Instance.StartCoroutine(AssetMgr.Instance.DownloadOrLoad(allLabels));
    }

    public override void OnLeaveState(int nextState, object context)
    {
        _innerCSM.Dispose();
        Logger.Debug("离开初始化状态");
    }
}