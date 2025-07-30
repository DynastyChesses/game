using System;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class GameMainScene : BaseSceneManager, BackKeyInterceptManager.IInterceptor
{
    public override string sceneName
    {
        get { return "GameMainScene"; }
    }

    public override int id => 1;

    private int _checkLostOrderID = EquineScheduler.INVALID;

    private const int CHECK_LOST_ORDER_INTERVAL = 5 * 60;
    private int _checkLostOrderToForegroundID = EquineScheduler.INVALID;


    #region Manager

    private EventManager _eventManager;

    #endregion
    
    // 增加预热
    public static bool isPreload = false;
    public static IEnumerator<int> PreloadPrefab(string path, int count)
    {
        // path
        List<IAsyncResourceRequest> requests = new List<IAsyncResourceRequest>();
        if (path != null)
        {
            for (int i = 0; i < count; i++)
            {
                IAsyncResourceRequest req = ResourceFacade.instance.LoadPrefabAsync(path);
                requests.Add(req);
            }
        }
        bool wait = true;
        while (wait)
        {
            wait = false;
            for (int i = 0; i < requests.Count; i++)
            {
                if (!requests[i].isDone)
                {
                    wait = true;
                }
                else
                {
                    var obj = requests[i].asset as GameObject;
                    if (obj != null)
                    {
                        obj.transform.localScale = Vector3.one;
                        // 默认不显示
                        obj.gameObject.SetActive(false);
                    }
                }
            }
            yield return default;
        }
        // 回收
        for (int i = 0; i < requests.Count; i++)
        {
            var o = (requests[i].asset) as GameObject;
            if (o != null)
            {
                o.transform.localScale = Vector3.one;
                GameObjectPool.instance.Recycle(o);
            }
        }
        yield return default;
        for (int i = 0; i < requests.Count; i++)
        {
            requests[i].Dispose();
        }
        requests.Clear();
    }
#if !UNITY_WEBGL
    // 需要预热的资源
    public List<string> preload_res_path = new List<string>()
    {
        // TOOD
    };
#else
    public List<string> preload_res_path = new List<string>();
#endif


    protected override IEnumerator<int> DoEnterScene(string prevScene, string currentScene, object switchContext)
    {
        InitMediator();
        InitManager();
        InitProxy();
        InitAnimator();

        //镜头初始化一下 后边要用视口进行entity刷新
        InitCameraPos(switchContext);

        InitHomeEvent();
        
        // 缓存，只进入执行一次
        if (!isPreload)
        {
            for (int i = 0; i < preload_res_path.Count; i++)
            {
                string[] item = preload_res_path[i].Split(',');
                if (item.Length > 1)
                {
                    yield return EquineScheduler.RunYieldProcedure(PreloadPrefab(item[0], int.Parse(item[1])));
                }
                else
                {
                    yield return EquineScheduler.RunYieldProcedure(PreloadPrefab(preload_res_path[i], 4));
                }
            }
            isPreload = true;
        }
        
        
        // 打开主ui
        
        // 其他逻辑 TODO
    }

    private void InitCameraPos(object switchContext)
    {
        // 初始化相机
    }

    protected override void DoLeaveScene(string currentScene, string nextScene)
    {
        base.DoLeaveScene(currentScene, nextScene);
    }

    #region HomeEvent
    /// <summary>
    /// 初始化场景事件
    /// </summary>
    private void InitHomeEvent()
    {
        
    }
    #endregion
    /// <summary>
    /// 初始化manager
    /// </summary>
    private void InitManager()
    {
        // TODO
    }

    private static bool InitedMainUI = false; // 主界面只new一次,不销毁
    
    /// <summary>
    /// 初始化Mediator
    /// </summary>
    private void InitMediator()
    {
        // TODO
    }

    /// <summary> 
    /// 初始化Proxy
    /// </summary>
    private void InitProxy()
    {
        // TODO
        RegisterSceneProxies(new List<Proxy>()
        {
        });
    }
    
    /// <summary>
    /// 初始化动画
    /// </summary>
    private void InitAnimator()
    {
        
    }

    public int priority { get; }

    BackKeyInterceptManager.InterceptResult BackKeyInterceptManager.IInterceptor.OnExecute()
    {
        // 接收Back返回
        return BackKeyInterceptManager.InterceptResult.Break;
    }
}