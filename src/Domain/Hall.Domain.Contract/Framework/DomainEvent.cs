namespace Framework.Domain;


public class DomainEvent : IEvent
{
    public Guid EventId { get; private set; }
          public DateTime PublishDateTime { get; private set; }
          public DomainEvent(Guid eventId, DateTime publishDateTime)
          {
              this.EventId = eventId;
              this.PublishDateTime = publishDateTime;
          }
}