using Framework.Domain;

namespace Hall.Infrastructure.Persistence.Sql.Repositories;


public static class EventProcessedMessageRepository
{
    public static void AddMessage(DataBaseContext dbContext ,EventProcessedMessage  message)
        =>  dbContext.EventProcessedMessages.Add(message);
}
