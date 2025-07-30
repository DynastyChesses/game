using System;
using System.Collections.Generic;
using Google.Protobuf;
using PureMVC.Patterns;

public class RegisterNetProxyVO
{
	public ICommunicationMessageHandler handler;
	public string key = String.Empty;
}

public class BaseProxy :Proxy, ICommunicationMessageHandler
{
	private readonly Dictionary<string, Action<IMessage>> _messageMapping = new Dictionary<string, Action<IMessage>>();

    // ILRuntime改造-添加无参构造函数
    public BaseProxy()
    {

    }
    public BaseProxy(string proxyName):base(proxyName)
	{
	}
	
	public void HandleMessage(object message, long responseTime)
	{
		IMessage tmsg = message as IMessage;
        string key = tmsg.Descriptor.FullName;
		Action<IMessage> handler;
		if (_messageMapping.TryGetValue(key, out handler))
		{
			handler(tmsg);
		}
	}

	public sealed override void OnRemove()
	{
		DoOnRemove();
		if (_messageMapping.Count > 0)
		{
			Dictionary<string, Action<IMessage>>.Enumerator iter = _messageMapping.GetEnumerator();
			while(iter.MoveNext())
			{
				// 发起通知删除
				ApplicationFacade.instance.SendNotification("NET_UN_REGIST_MESSAGE_HANDLER", iter.Current.Key);
			}
			_messageMapping.Clear();
		}
	}

	protected virtual void DoOnRemove()
	{
		
	}

    /// <summary>
    /// 注册要监听的服务器返回的Message，需要Unregister。
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="action">Action.</param>
    protected void RegisterMessageHandler(string key, Action<IMessage> action)
    {
	    #if CUSTOM_DEBUG
	    UnityEngine.Debug.LogError($"注册函数:{key}");
	    #endif
	    RegisterNetProxyVO vo = new RegisterNetProxyVO();
	    vo.key = key;
	    vo.handler = this;
	    ApplicationFacade.instance.SendNotification("NET_REGIST_MESSAGE_HANDLER", vo);
	    if (_messageMapping.ContainsKey(key))
	    {
		    _messageMapping[key] = action;
	    }
	    else
	    {
		    _messageMapping.Add(key, action);
	    }
    }
    
    /// <summary>
    /// 注销监听服务器返回的Message
    /// </summary>
    /// <param name="key">Key.</param>
    protected void UnRegisterMessageHandler(string key)
    {
	    ApplicationFacade.instance.SendNotification("NET_UN_REGIST_MESSAGE_HANDLER", key);
	    if (_messageMapping.ContainsKey(key))
	    {
		    _messageMapping.Remove(key);
	    }
    }
}
