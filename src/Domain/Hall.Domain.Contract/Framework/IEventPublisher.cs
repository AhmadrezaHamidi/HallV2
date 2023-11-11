namespace Framework.Domain;


public interface IEventPublisher
{
    void Publish<T>(T eventToPublish) where T : IEvent;
}