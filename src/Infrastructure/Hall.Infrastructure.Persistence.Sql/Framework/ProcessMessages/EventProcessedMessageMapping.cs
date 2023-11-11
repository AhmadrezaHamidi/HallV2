using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Framework.Domain;

namespace Framework.EntityFrameworkCore.ProcessMessages
{
    public class EventProcessedMessageMapping : IEntityTypeConfiguration<EventProcessedMessage>
    {
        public void Configure(EntityTypeBuilder<EventProcessedMessage> builder)
        {
            builder.ToTable("EventProcessedMessage").HasKey(p=>p.Id);
            builder.Property(p => p.EventId).IsRequired();
        }
    }
}