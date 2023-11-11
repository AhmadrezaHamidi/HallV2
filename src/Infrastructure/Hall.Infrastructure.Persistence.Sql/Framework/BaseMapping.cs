using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Framework.Domain;

namespace Framework.EntityFrameworkCore
{
    public abstract class BaseMapping<TBase, TKey> : IEntityTypeConfiguration<TBase> where TBase : Entity<TKey>
    {
        public abstract void Configure(EntityTypeBuilder<TBase> builder);
    }
}
