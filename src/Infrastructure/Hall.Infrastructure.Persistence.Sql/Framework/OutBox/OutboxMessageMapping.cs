using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Framework.Domain;

namespace Framework.EntityFrameworkCore.OutBox
{
    public class OutboxMessageMapping : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessage");
            builder.Property(a => a.Body).IsRequired();
            builder.Property(a => a.EventDate).IsRequired();
            builder.HasKey(a => a.EventId);
            builder.Property(a => a.Type).IsRequired();
        }
    }
}