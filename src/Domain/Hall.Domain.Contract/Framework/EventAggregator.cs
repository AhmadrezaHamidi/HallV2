namespace Framework.Domain;


public class EventAggregator : IEventListener, IEventPublisher
{
    private readonly List<object> _subscriber = new List<object>();

    public void Publish<T>(T eventToPublish) where T : IEvent => this._subscriber.OfType<IEventHandler<T>>().ToList<IEventHandler<T>>().ForEach((Action<IEventHandler<T>>) (x => x.Handle(eventToPublish)));

    public void Subscribe<T>(IEventHandler<T> handler) where T : IEvent => this._subscriber.Add((object) handler);

    public void UnSubscribe<T>(T eventToPublish) where T : IEvent => this._subscriber.Remove((object) eventToPublish);
}