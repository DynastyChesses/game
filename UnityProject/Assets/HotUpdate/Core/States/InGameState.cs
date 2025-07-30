using System;
using System.Collections;
using System.Collections.Generic;
using HotUpdate.osP1;
using osP1.Helper;
using UnityEngine;
using PureMVC.Patterns;
using UnityEngine.Networking;

public partial class InGameState : ClientState
{
    public InGameState(ClientStateManager context) : base(context, GameStateConst.IN_GAME)
    {
    }

    private List<string> _registeredMediators = new List<string>();
    private List<string> _registeredSceneProxys = new List<string>();

    public override void OnEnterState(int prevState, object context)
    {
        Logger.Debug("进入游戏状态");
        EnterGame();
    }

    public override void OnLeaveState(int nextState, object context)
    {
        // TODO
    }

    public IEnumerator Init(Action cb)
    {
#if DEBUG
        Debug.Log($"注册所有协议");
#endif
        // 注册所有协议
        NetFacade.instance.RegisterProxies(new List<Proxy>()
        {
            new UserProxy(),
            new TimeProxy(),
            new GameProxy(),
        });

        yield return null;

        // 判断网络情况
        // if (Application.internetReachability == NetworkReachability.NotReachable)
        // {
        //     // 设置IP为127.0.0.1
        //     NetFacade.instance.IP = "127.0.0.1";
        //     NetFacade.instance.netState = NetState.Unable;
        //     yield return null;
        // }
        // else
        // {
        //     NetFacade.instance.netState = NetState.Wifi;
        //     UnityWebRequest req = UnityWebRequest.Get("https://miaokids-test.oss-cn-beijing.aliyuncs.com/game/ip.txt");
        //     yield return req.SendWebRequest();
        //     NetFacade.instance.IP = req.downloadHandler.text;
        //     Debug.LogError($"服务器IP:{NetFacade.instance.IP}");
        // }

        // 网络连接
        // NetFacade.instance.CreateConnect();

        var isLoadExcelFinished = false;
        // 加载所有的表
        MetaManager.instance.LoadMetas(() =>
        {
            Dictionary<string, string> currentLangData = new Dictionary<string, string>();
            // 缓存Lang表
            var datas = MetaManager.instance.Meta.TbLanguage.DataList;
            // 语言判断
            string current_lan = PlayerPrefs.GetString("CUR_LANGUAGE", "zh_cn");
#if UNITY_EDITOR
            // TODO
#else
#endif
            string choose = Language.GetSystemLanguageFullName(current_lan);
            for (int i = 0; i < datas.Count; i++)
            {
                switch (choose)
                {
                    case "ChineseSimplified":
                        currentLangData.Add(datas[i].Key, datas[i].ChineseSimplified);
                        break;
                    case "English":
                        currentLangData.Add(datas[i].Key, datas[i].English);
                        break;
                    case "Japanese":
                        currentLangData.Add(datas[i].Key, datas[i].Japanese);
                        break;
                    case "French":
                        currentLangData.Add(datas[i].Key, datas[i].French);
                        break;
                    case "Russian":
                        currentLangData.Add(datas[i].Key, datas[i].Russian);
                        break;
                    case "ChineseTraditional":
                        currentLangData.Add(datas[i].Key, datas[i].ChineseTraditional);
                        break;
                }
            }

            Language.SetLanguageInfo(current_lan, "1.0", currentLangData);
            isLoadExcelFinished = true;
        });

        //补充AOT元数据
        var isLoadMetaDataFinished = false;
        HybridCLRHelper.LoadMetaData4AOT((() => isLoadMetaDataFinished = true));

        var isLoadGamePlayCacheFinished = false;
        GameImgCache.instance.Load((() => isLoadGamePlayCacheFinished = true));

        while (!(isLoadExcelFinished && isLoadMetaDataFinished && isLoadGamePlayCacheFinished))
        {
            yield return new WaitForEndOfFrame();
        }

        cb.Invoke();
    }

    void RegisterSceneController()
    {
        // 注册主场景
        SceneScheduler.RegisterSceneController(new GameMainScene());
    }

    private void EnterGame()
    {
        RegisterSceneController();
        GameLaunch.Instance.RunCoroutine(Init(() =>
        {
            // 等待1s
            EquineScheduler.CallOnce(1.0f, (a, b, c) =>
            {
                // ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_GROUND);
                // ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_MATCHING_PANEL);
                //ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_MAIN_PANEL);
                // 通知关闭 GlobalLoadPanel
                ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_GLOBAL_LOAD_PANEL);
                // HideView();
                
                ApplicationFacade.instance.SendNotification(NotificationConst.LOAD_GAME_MAP);
                // ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEVEL_SELECTION_U_I);
            });
        }));
    }

    private bool _hideMainUI = false;
}