public interface ICommunicationMessageHandler
{
    void HandleMessage(object message, long responseTime);
}