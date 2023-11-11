namespace Framework.Domain;

public interface IEvent
{
    Guid EventId { get; }
}