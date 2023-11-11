namespace Framework.Domain;

public interface IAggregateRoot
{
    void Publish<T>(T domainEvent) where T : DomainEvent;

    IReadOnlyList<DomainEvent> GetChanges();

    void ClearChanges();
}