using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameMain
{
    private static void StartGame()
    {
        // 进入初始化状态
        GameStateManager.instance.Input(GameStateConst.INITIALIZE_STATE, false);
    }
    
    // 主入口
    public static void Run(GameObject go)
    {
        Debug.Log("游戏开始!!");
        // #if UNITY_EDITOR
        // NotificationConst.UniqueChecker();
        // #endif
        
        //
#if !UNITY_WEBGL || UNITY_EDITOR        
        CommonUtil.mainThreadId = Thread.CurrentThread.ManagedThreadId;
#endif
        Time.timeScale = 1f;
        RealTimer.Reset();
        ConfigureLogger();
        // 当前运行时状态
        // 平台管理器 TODO
        // 声音管理器 TODO
        // UI初始化
        if (go != null)
        {
            UIManager.Configure(go, false);
            Debug.Log("UIManager 初始化!!");
        }
        // HTTP初始化
        BestHTTPAdapter.Configure();
        // BI管理 TODO
        // 远程日志上报 TODO
        // 判断设备等级 TODO
        // 状态机启动
        RegisterGameState();
        // 是否后台运行 
        // Application.runInBackground = true;
        // Deeplink TODO
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartGame();
        Application.targetFrameRate = 60;
    }
    
    private static void RegisterGameState()
    {
        GameStateManager gsm = GameStateManager.instance;
        gsm.RegisterState(new InitializeState(gsm));
        // 不需要注册状态
        gsm.RegisterState(new LoginState(gsm));
        gsm.RegisterState(new InGameState(gsm));
    }
    
    private static void ConfigureLogger()
    {
        // 定义Log等级 TODO
    }

    public static void CleanUp()
    {
        // 退出
    }
}
