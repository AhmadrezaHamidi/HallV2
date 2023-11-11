namespace Framework.Domain;

public class OutboxMessage
{
    public Guid EventId { get; private set; }
    public DateTime EventDate { get; private set; }
    public string Type { get; private set; }
    public string Body { get; private set; }
    public bool SentOnBus { get; set; }

    public OutboxMessage(Guid eventId, string type, DateTime eventDate, string body)
    {
        EventId = eventId;
        Type = type;
        EventDate = eventDate;
        Body = body;
        SentOnBus = false;
    }
}