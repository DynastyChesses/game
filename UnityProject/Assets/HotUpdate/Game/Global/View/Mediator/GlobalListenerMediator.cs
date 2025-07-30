

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Google.Protobuf;
using MiracleWar;
using osP1.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

// 主要用户全局能力，比如网络
public class GlobalListenerMediator : TBaseUIMediator<GlobalListenerSkin>
{
    
    // 增加一个消息消费队列，保证主线程处理
    private List<ReceiveMsgVO> msgList = new List<ReceiveMsgVO>();

    public GlobalListenerMediator() : base(MediatorNames.GLOBAL_LISTENER,NotificationConst.SHOW_GLOBAL_LISTENER,NotificationConst.HIDE_GLOBAL_LISTENER)
    {
        // 全局监听函数
        RegisterNotificationHandler(NotificationConst.WARGAME_CONNECTED, OnWargameConnected);
        RegisterNotificationHandler(NotificationConst.WARGAME_RECVMSG, OnWargameRecvmsg);
        // 网络
        RegisterNotificationHandler("NET_REGIST_MESSAGE_HANDLER", OnRegistMessageHandler);
        RegisterNotificationHandler("NET_UN_REGIST_MESSAGE_HANDLER", OnUnRegistMessageHandler);
        //
        RegisterNotificationHandler("DESTROY", OnDestroy);
        
        // 新增加一个
        RegisterNotificationHandler(NotificationConst.LOAD_GAME_MAP, OnLoadGameMap);
    }

    private void OnLoadGameMap(object obj)
    {
        // 开始创建地图
        Debug.Log("开始创建地图!!!");
        // 通过CommonItemRender
        CommonItemRenderer mapObj = new CommonItemRenderer(null);
        // 定义数据
        MapVO mapVo = new MapVO();
        mapVo.height = 5;
        mapVo.width = 5;
        for (int i = 0; i < mapVo.height; i++)
        {
            List<int> row = new List<int>();
            for (int j = 0; j < mapVo.width; j++)
            {
                row.Add(1);
            }
            mapVo.datas.Add(row);
        }
        // 赋值
        mapObj.data = mapVo;
    }

    private void OnDestroy(object obj)
    {
        //
        Debug.Log($"退出程序");
        NetFacade.instance.Dispose();
    }

    private void OnUnRegistMessageHandler(object obj)
    {
        string key = (string)obj;
        NetFacade.instance.UnRegistMessageHandler(key);
    }

    private void OnRegistMessageHandler(object obj)
    {
        RegisterNetProxyVO vo = (RegisterNetProxyVO)obj;
        NetFacade.instance.RegistMessageHandler(vo.key, vo.handler);
    }

    private void OnWargameRecvmsg(object obj)
    {
        ReceiveMsgVO vo = (ReceiveMsgVO)obj;
        msgList.Add(vo);
    }

    private void OnWargameConnected(object obj)
    {
        // 连接成功，发起用户协议
        UserProxy.instance.SendUserInfo();
    }

    private void Update(int arg1, object arg2, UpdateTimeInfo arg3)
    {
        if (msgList.Count > 0)
        {
            for (int i = 0; i < msgList.Count; i++)
            {
                DecodeMsg (msgList[i].buffer, msgList[i].size);
            }
        }
        msgList.Clear();
    }

    private void OnUpdate1000(int i, object o, UpdateTimeInfo arg3)
    {
        
    }
    
    private bool DecodeMsg (byte[] receiveBytes, int size)
    {
        if (size > 4)
        {
            // 前2位表示 Message Id
            int cmdId = receiveBytes[0] * 256 + receiveBytes[1];
            int cmdLen = receiveBytes[2] * 256 + receiveBytes[3];
            if (cmdLen + 4 < size)
            {
                // 需要分包，压入消息队列
                Debug.LogError($"网络阻塞，进行了分包!!!!");
                // DecodeMsg 5->end
                int len = size - (cmdLen + 4);
                if (len > 0)
                {
                    byte[] nextMsg = new byte[len];
                    System.Array.Copy(receiveBytes, cmdLen + 4, nextMsg, 0, len);
                    DecodeMsg(nextMsg, len);
                }
            }
            else
            {
                // 接收到消息ID
                // Debug.LogError($"接收到消息ID: {cmdId} - 长度: {cmdLen}");
                if (cmdLen > 0)
                {
                    byte[] encodeMsg = new byte[cmdLen];
                    System.Array.Copy(receiveBytes, 4, encodeMsg, 0, cmdLen);
                    if (ProxyNames.reflect_maps.ContainsKey(cmdId) && cmdLen > 0)
                    {
                        // 有数据再进行解析
                        try
                        {
                            var t = ProxyNames.reflect_maps[cmdId];
                            var msg = t.Parser.ParseFrom(encodeMsg);
                            ICommunicationMessageHandler messageHandler = NetFacade.instance.messageHandlerRegistry.GetMessageHandler(msg.Descriptor.FullName);
                            // 第二个参数：0，后续要改!!
                            if (messageHandler != null)
                                messageHandler.HandleMessage(msg, 0);
                            return true;
                        }
                        catch (Exception e)
                        {
                            Debug.LogError($"**消息格式异常，请确认问题");
                            return false;
                        }
                    }
                }
            }
            
        }
        
        return false;
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);
        // 连接成功后，开启1s一次的心跳
        EquineScheduler.AddTimeLimitUpdator(1.0f, OnUpdate1000);
        // 开启全局Update
        EquineScheduler.AddFrameLimitUpdator(1, Update);

    }

    protected override void OnShowViewAndRefresh(object data)
    {

    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        // 不再关闭
        // HideView();
        // base.DoOnReturnMaskClick();
    }
}
