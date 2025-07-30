using Google.Protobuf;

public interface ICommunicationMessageHandlerRegistry
{
    void RegistMessageHandler(string signatrue, ICommunicationMessageHandler handler);

    void UnRegistMessageHandler(string signature);

    ICommunicationMessageHandler GetMessageHandler(string signature);

    void Reset();
}