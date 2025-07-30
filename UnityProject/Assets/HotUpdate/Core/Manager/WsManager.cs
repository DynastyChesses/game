using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP.WebSocket;
using UnityEngine;

public class WsManager : Singleton<WsManager> 
{
    private WebSocket webSocket;
    // 基于 BestHTTP
    public void init(string url)
    {
        webSocket = new WebSocket(new Uri(url));
        webSocket.OnOpen += OnWebSocketOpen;
        webSocket.OnMessage += OnMessageReceived;
        webSocket.OnBinary += OnBinaryMessageReceived;
        webSocket.OnClosed += OnWebSocketClosed;
        webSocket.OnError += OnError;
        webSocket.Open();
    }
    
    /// <summary>
    /// 服务器字符串消息
    /// </summary>
    /// <param name="webSocket"></param>
    /// <param name="message"></param>
    protected void OnMessageReceived(WebSocket webSocket, string message)
    {
        //Debug.Log("Text Message received from server: " + message);
    }
    
    /// <summary>
    /// 连接回调
    /// </summary>
    /// <param name="webSocket"></param>
    protected void OnWebSocketOpen(WebSocket webSocket)
    {
        Debug.Log("WebSocket Open!");
    }
    /// <summary>
    /// 服务器二进制消息
    /// </summary>
    /// <param name="webSocket"></param>
    /// <param name="message"></param>
    protected void OnBinaryMessageReceived(WebSocket webSocket, byte[] bytes)
    {
        // TODO
    }
    
    /// <summary>
    /// 关闭连接回调
    /// </summary>
    /// <param name="webSocket"></param>
    /// <param name="code"></param>
    /// <param name="message"></param>
    protected void OnWebSocketClosed(WebSocket webSocket, UInt16 code, string message)
    {
        Debug.Log("WebSocket Closed!");
    }
    /// <summary>
    /// 错误通知
    /// </summary>
    /// <param name="ws"></param>
    /// <param name="ex"></param>
    protected void OnError(WebSocket ws, string ex)
    {
        string errorMsg = string.Empty;
        if (ws.InternalRequest.Response != null)
        {
            errorMsg = string.Format("Status Code from Server: {0} and Message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);
        }
        Debug.Log("An error occured: " + (ex != null ? ex : "Unknown: " + errorMsg));
    }
    /// <summary>
    /// 发送字符串: 
    /// </summary>
    /// <param name="msg"></param>
    public void OnSend(string msg)
    {
        webSocket.Send(msg);
    }
    /// <summary>
    /// 发送二进制流: 
    /// </summary>
    /// <param name="msg"></param>
    public void OnSend(byte[] buffer)
    {
        webSocket.Send(buffer);
    }
    
    /// <summary>
    /// 断开连接
    /// </summary>
    public void OnClose()
    {
        webSocket.Close();
    }
    
    public override void Dispose()
    {
        //
    }
}
