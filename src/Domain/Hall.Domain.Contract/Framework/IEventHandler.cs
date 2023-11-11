namespace Framework.Domain;


public interface IEventHandler<T> where T : IEvent
{
    void Handle(T @event);
}