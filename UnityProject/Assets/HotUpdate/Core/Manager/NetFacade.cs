using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using PureMVC.Patterns;
using UnityEngine;

// 定义 ReceiveMsgVO
public class ReceiveMsgVO
{
    public Socket socket;
    public byte[] buffer = null;
    public int size = 0;
}


class MsgReceiveHelper
{
    public Socket socket;
    public byte[] buffer = null;
}

public enum ConnectStatus
{
    UnConnect = 1,
    Connecting = 2,
    Connected = 3,
    Closed = 4,
    Error = 5,
}

public enum NetState
{
    Wifi = 1,
    PhoneNet = 2,
    Unable = 3
}

public class NetFacade : Singleton<NetFacade>
{
    // 当前网络状态 (默认有网)
    public NetState netState = NetState.Wifi;

    // 只存在一个 Client 
    public Socket _socketClient;
    // 64kb缓冲区
    const int DEFAULT_RECEIVE_SIZE = 64 * 1024;
    const int DEFAULT_SEND_SIZE = 8 * 1024;

    private IPAddress address;
    // 默认
    public string IP = "127.0.0.1";
    private string _lastConnectAdress = "";
    
    private Action<bool> _sendMsgHandler;
    
    // 当前的连接状态
    private ConnectStatus _status = ConnectStatus.UnConnect;
    
    private List<string> _registeredSceneProxys = new List<string>();
    
    private BaseCommunicationMessageHandlerRegistry _messageHandlerRegistry;


    public BaseCommunicationMessageHandlerRegistry messageHandlerRegistry
    {
        get
        {
            return _messageHandlerRegistry;
        }
    }
    
    public ConnectStatus status
    {
        get
        {
            return _status;
        }
    }

    public override void Init()
    {
        base.Init();
        _messageHandlerRegistry = new BaseCommunicationMessageHandlerRegistry();
    }

    public void RegistMessageHandler(string signature, ICommunicationMessageHandler handler)
    {
        _messageHandlerRegistry.RegistMessageHandler(signature, handler);
    }

    public void UnRegistMessageHandler(string signature)
    {
        _messageHandlerRegistry.UnRegistMessageHandler(signature);
    }
    
    public void RegisterProxies(List<Proxy> proxies)
    {
        var facade = ApplicationFacade.instance;
        int count = proxies != null ? proxies.Count : 0;
        for (int i = 0; i < count; ++i)
        {
            facade.RegisterProxy(proxies[i]);
            _registeredSceneProxys.Add(proxies[i].ProxyName);
        }
    }
    
    public void UnRegisterProxies()
    {
        var facade = ApplicationFacade.instance;
        int count = _registeredSceneProxys.Count;
        for (int i = 0; i < count; ++i)
        {
            facade.RemoveProxy(_registeredSceneProxys[i]);
        }
        _registeredSceneProxys.Clear();
    }

    private string ConnectInfo = string.Empty;
    
    //
    public void CreateConnect()
    {
        address = IPAddress.Parse(IP);
        _lastConnectAdress = IP;
        _socketClient = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        _socketClient.Blocking = false;
        _socketClient.ReceiveBufferSize = DEFAULT_RECEIVE_SIZE;
        _socketClient.SendBufferSize = DEFAULT_SEND_SIZE;
        _socketClient.ReceiveTimeout = 30000;
        _socketClient.SendTimeout = 30000;
        _socketClient.NoDelay = true;
        _socketClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
        EndPoint ep = new IPEndPoint(address, 8001);
        _socketClient.BeginConnect (ep, new AsyncCallback (ConnectCallback), _socketClient);
        // 状态 
        _status = ConnectStatus.Connecting;
    }
    
    private void ConnectCallback (IAsyncResult ar)
    {
        try {
            Socket socket = (Socket)ar.AsyncState;
            if (!socket.Connected)
            {
                _status = ConnectStatus.Error;
                string info = _lastConnectAdress + " connect failed!, try connect again";
                ConnectInfo = info;
                Debug.LogError(info);
            } 
            else 
            {
                socket.EndConnect (ar);
                // 连接
                Debug.LogError("连接成功!!");
                // 发起通知
                _status = ConnectStatus.Connected;
                ApplicationFacade.instance.SendNotification("WARGAME_CONNECTED");
                this.StartRecevieMsg ();
            }
        } catch (Exception e)
        {
            string info = e.ToString();
            Debug.LogError(info);
        }
    }
    
    private void StartRecevieMsg()
    {
        MsgReceiveHelper receiveHelper = new MsgReceiveHelper ();
        receiveHelper.socket = this._socketClient;
        receiveHelper.buffer = new byte[DEFAULT_RECEIVE_SIZE];
        this._socketClient?.BeginReceive (receiveHelper.buffer, 0, receiveHelper.buffer.Length, SocketFlags.None, new AsyncCallback (ReceiveMsgCallback), receiveHelper);
    }
    
    private void ReceiveMsgCallback (IAsyncResult receiveRes)
    {
        MsgReceiveHelper receiveHelper = null;
        try {
            int recSize = this._socketClient.EndReceive (receiveRes);
            if (recSize > 0) {
                receiveHelper = (MsgReceiveHelper)receiveRes.AsyncState;
                ReceiveMsgVO vo = new ReceiveMsgVO();
                vo.buffer = receiveHelper.buffer;
                vo.socket = receiveHelper.socket;
                vo.size = recSize;
                ApplicationFacade.instance.SendNotification("WARGAME_RECVMSG", vo);
            } else {
                return;
            }
        }
        catch (SocketException se) {
            // ConnectInfo = se.ToString();
            // Debug.LogError(ConnectInfo);
            if (!se.SocketErrorCode.Equals (SocketError.WouldBlock)) {
                return;
            }
        } catch (Exception e) {
            _status = ConnectStatus.Error;
            ConnectInfo = e.ToString();
            Debug.LogError(ConnectInfo);
        } finally {
            if (receiveHelper != null) {
                receiveHelper.socket.BeginReceive (receiveHelper.buffer, 0, receiveHelper.buffer.Length, SocketFlags.None, new AsyncCallback (ReceiveMsgCallback), receiveHelper);
            } else {
                this.StartRecevieMsg ();
            }
        }
    }

    public void SendMessage (IMessage msg)
    {
        byte[] bytes = null;
        if (ProtobufMgr.Serialize(msg, out bytes))
        {
            Socket tmp = _socketClient;
            string exceptionMsg = null;
            bool sendError = false;
            try
            {
                if (tmp == null || !tmp.Connected)
                {
                    sendError = true;
                }
                else
                {
                    tmp.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, SendMsgCallback, tmp);
                }
            }
            catch (Exception ex)
            {
                sendError = true;
                exceptionMsg = ex.ToString();
            }

            if (sendError && !string.IsNullOrEmpty(exceptionMsg))
            {
                tmp = ClearSocket();
                DoCloseSocket(tmp);
            }

            if (sendError && _sendMsgHandler != null)
            {
                Action<bool> callback = _sendMsgHandler;
                _sendMsgHandler = null;
                callback(false);
            }
        }
    }
    
    public void SetSendMessageCallback(Action<bool> callback)
    {
        _sendMsgHandler = callback;
    }
    
    private Socket ClearSocket()
    {
        Socket tmp = _socketClient;
        _socketClient = null;

        return tmp;
    }
    
    private void SendMsgCallback (IAsyncResult sendRes)
    {
        bool sendMsgSuccess = true;
        string exceptionMsg = null;
        Socket socket = null;
        try
        {
            socket = (Socket)sendRes.AsyncState;
            int nSentByte = socket.EndSend(sendRes);
            if (nSentByte <= 0)
            {
                sendMsgSuccess = false;
            }
        }
        catch (Exception e)
        {
            exceptionMsg = e.ToString();
            sendMsgSuccess = false;
        }

			
        if (_sendMsgHandler != null)
        {
            Action<bool> callback = _sendMsgHandler;
            _sendMsgHandler = null;
            callback(sendMsgSuccess);
        }
    }
    
    public bool IsConnected ()
    {
        Socket tmp = _socketClient;
        return (null != tmp && tmp.Connected);
    }
    
    private void DoCloseSocket(Socket tmp)
    {
        _messageHandlerRegistry.Reset(); // reset()是将所有注册的消息解释全部清空
        try 
        {
            if (tmp.Connected)
            {
                tmp.Shutdown(SocketShutdown.Both);
            }
        }
        catch (SocketException)
        {
            // TODO
        }
        try
        {
            ((IDisposable)tmp).Dispose();
        }
        catch (Exception)
        {
            // ignored
        }

        _status = ConnectStatus.Closed;
    }
    
    public override void Dispose()
    {
        // 
        if (_socketClient != null)
        {
            DoCloseSocket(_socketClient);
            _socketClient.Dispose();
            _socketClient = null;
        }
        
    }
}
