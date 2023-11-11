using Framework.Domain;
using Newtonsoft.Json;


namespace Framework.EntityFrameworkCore.OutBox;


public static class OutboxItemFactory
{
    public static List<OutboxMessage> CreateOutboxItemsFromAggregateRoots(List<IAggregateRoot> aggregateRoots)
    {
        return aggregateRoots.SelectMany(a => a.GetChanges()).Select(MapToOutboxItem).ToList();
    }

    private static OutboxMessage MapToOutboxItem(DomainEvent @event)
    {
        return new OutboxMessage(@event.EventId, @event.GetType().AssemblyQualifiedName, @event.PublishDateTime, JsonConvert.SerializeObject(@event));
    }
}