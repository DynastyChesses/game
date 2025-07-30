using System.Collections.Generic;
using Google.Protobuf;

public class BaseCommunicationMessageHandlerRegistry : ICommunicationMessageHandlerRegistry
{
    private Dictionary<string, ICommunicationMessageHandler> handlerMap = new Dictionary<string, ICommunicationMessageHandler>();


    public void RegistMessageHandler(string signatrue, ICommunicationMessageHandler handler)
    {
        if (this.handlerMap.ContainsKey(signatrue))
            return;
        this.handlerMap.Add(signatrue, handler);
    }

    public void UnRegistMessageHandler(string signatrue)
    {
        if (!this.handlerMap.ContainsKey(signatrue))
            return;
        this.handlerMap.Remove(signatrue);
    }

    public ICommunicationMessageHandler GetMessageHandler(string signature)
    {
        ICommunicationMessageHandler messageHandler = (ICommunicationMessageHandler) null;
        this.handlerMap.TryGetValue(signature, out messageHandler);
        return messageHandler;
    }

    public void Reset() => this.handlerMap.Clear();
}