namespace Framework.Domain
{
    public class EventProcessedMessage:Entity<long>
    {
        public Guid EventId { get; private set; }
        public EventProcessedMessage(Guid eventId )
        {
            EventId = eventId;
        }
        protected EventProcessedMessage( )
        {
        }
    }
}
