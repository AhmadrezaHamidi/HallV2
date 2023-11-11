namespace Framework.Domain;

public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    private List<DomainEvent> _uncommittedEvents = new List<DomainEvent>();
    private IEventPublisher _publisher;

    public AggregateRoot() => this._uncommittedEvents = new List<DomainEvent>();

    public void Publish<T>(T domainEvent) where T : DomainEvent
    {
        this._uncommittedEvents.Add((DomainEvent) domainEvent);
        this._publisher.Publish<T>(domainEvent);
    }

    public IReadOnlyList<DomainEvent> GetChanges() => (IReadOnlyList<DomainEvent>) this._uncommittedEvents;

    public void ClearChanges() => this._uncommittedEvents.Clear();

    public void SetPublisher(IEventPublisher publisher) => this._publisher = publisher;

    protected AggregateRoot(IEventPublisher publisher) => this._publisher = publisher;
}