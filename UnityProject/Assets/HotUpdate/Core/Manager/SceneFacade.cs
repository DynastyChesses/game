using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class SceneFacade : DefaultFacadeImpl
{
    private static bool InitedMainUI = false;
    private IFacade _facade = Facade.Instance;
    private List<string> _registeredSceneProxys = new List<string>();
    private List<string> _registeredSceneMediators = new List<string>();
    protected void RegisterSceneMediators(List<Mediator> mediators)
    {
        int count = mediators != null ? mediators.Count : 0;
        for (int i = 0; i < count; ++i)
        {
            _facade.RegisterMediator(mediators[i]);
            _registeredSceneMediators.Add(mediators[i].MediatorName);
        }
    }
    
    private static readonly object _staticSyncRoot = new object();
    private static SceneFacade _instance;
    public static  SceneFacade instance
    {
        get 
        {
            if (_instance == null)
            {
                lock (_staticSyncRoot)
                {
                    if (_instance == null) 
                    {
                        _instance = new SceneFacade();
                        Facade.implement = _instance;
                    }
                }
            }
			
            return _instance;
        }
    }
    
    public void InitMediator()
    {
        // 主界面全局注册一次,不销毁
        if( !InitedMainUI )
        {
            InitedMainUI = true;
        }
        
        // 尝试注册
        RegisterSceneMediators(new List<Mediator>()
        {
            new ImageMediator(),
            new GlobalListenerMediator(),
            new GroundMediator(),
            new GlobalLoadPanelMediator(),
            new CommonRewardPanelV2Mediator(),
            new MainPanelMediator(),
            new GamePlayMediator(),
            new LevelSelectionUIMediator(),
            new LevelWinUIMediator(),
            new ReviveUIMediator(),
            new NewFeaturePopupMediator(),
            new NewItemPopupMediator(),
            new SettingsUIMediator(),
            new LeaveUIMediator(),
            new BuyItemPopupMediator(),
            new LevelLoseUIMediator(),
            new BuyStaminaPopupMediator(),
        });
    }
}
