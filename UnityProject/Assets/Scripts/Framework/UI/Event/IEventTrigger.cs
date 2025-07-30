
public interface IEventTrigger<T>
{
    void AddListener(T t);
    void RemoveListener();
    void RemoveListener(T t);
}
