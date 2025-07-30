using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Protobuf;
using MiracleWar;
using UnityEngine;

public class UserProxy : TBaseProxy<UserProxy>
{
    
    // 更换为Dic
    private Dictionary<long, HeaderVO> _vos = new Dictionary<long, HeaderVO>();

    public List<HeaderVO> vos
    {
        get
        {
            return _vos.Values.ToList();
        }
    }
    
    // Append Id
    public void AppendId(long id)
    {
        if (!_vos.ContainsKey(id))
        {
            _vos[id] = new HeaderVO();
            _vos[id].uid = id;
            _vos[id].header = (int)Math.Abs(id % 10);
            var index = Math.Abs(id) % NickNames.names.Count;
            _vos[id].name = NickNames.names[(int)index];
            _vos[id].isMine = false;
        }
    }

    // 用户基本信息
    private long _uid = -1;
    public long uid
    {
        get
        {
            return _uid;
        }
    }
    
    // 获取nickName(根据uid来)
    public string NickName
    {
        get
        {
            var index = Math.Abs(uid) % NickNames.names.Count;
            return NickNames.names[(int)index];
        }
    }
    
    // udid 唯一标识
    public string _udid = string.Empty;

    public string udid
    {
        get
        {
            return _udid;
        }
    }

    // 发送消息
    public void SendUserInfo()
    {
        _uid = 99999;
        _udid = "Editor";
#if UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _udid = UnityEngine.iOS.Device.vendorIdentifier.ToString();
            _uid = ProtobufMgr.StringToMD5Hash(_udid);
        }
#else
        if (Application.platform == RuntimePlatform.Android)
        {
            // TODO 做跨平台
        }
#endif
        CgUserInfo info = new CgUserInfo()
        {
            Sex = 1,
            Uid = uid,
            UserName = _udid
        };
        NetFacade.instance.SendMessage(info);
    }
    
    public override void OnRegister()
    {
        base.OnRegister();
        // 注册监听 Gc
        RegisterMessageHandler(GcUserInfo.Descriptor.FullName, OnUserInfo);
        RegisterMessageHandler(GcUserLogout.Descriptor.FullName, OnUserLogout);
        RegisterMessageHandler(GcAllUsers.Descriptor.FullName, OnAllUsers);
        RegisterMessageHandler(GcStartGame.Descriptor.FullName, OnStartGame);
    }

    private void OnStartGame(IMessage obj)
    {
        // 开始游戏
        GcStartGame msg = obj as GcStartGame;
        // 发起通知
        ApplicationFacade.instance.SendNotification(NotificationConst.START_GAME, msg);
    }

    private void OnAllUsers(IMessage obj)
    {
        GcAllUsers msg = (GcAllUsers)obj;
        if (msg != null)
        {
            // 更新vos
            for (int i = 0; i < msg.Users.Count; i++)
            {
                Debug.Log($"更新用户信息:{msg.Users[i].UserName}");
                // 更新
                if (!_vos.ContainsKey(msg.Users[i].Uid))
                {
                    _vos[msg.Users[i].Uid] = new HeaderVO();
                }
                _vos[msg.Users[i].Uid].uid = msg.Users[i].Uid;
                _vos[msg.Users[i].Uid].header = (int)Math.Abs(msg.Users[i].Uid % 10);
                var index = Math.Abs(msg.Users[i].Uid) % NickNames.names.Count;
                _vos[msg.Users[i].Uid].name = NickNames.names[(int)index];
                _vos[msg.Users[i].Uid].isMine = msg.Users[i].Uid == uid;
            }
            // 通知用户登录
            ApplicationFacade.instance.SendNotification(NotificationConst.USER_LOGIN);
        }
    }

    private void OnUserLogout(IMessage obj)
    {
        GcUserLogout msg = (GcUserLogout)obj;
        // 更新数据
        if (msg != null)
        {
            if (_vos.ContainsKey(msg.Uid))
            {
                _vos.Remove(msg.Uid);
            }
        }
        // 通知用户登出
        ApplicationFacade.instance.SendNotification(NotificationConst.USER_LOGOUT, msg);
    }

    private void OnUserInfo(IMessage obj)
    {
        // TODO
    }
    

    public UserProxy() : base(ProxyNames.User)
    {
        
    }
}
