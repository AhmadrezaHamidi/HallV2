using Framework.EntityFrameworkCore;
using Hall.Domain.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hall.Infrastructure.Persistence.Sql.Mappings;

public class CategoryMapping:BaseMapping<Category,CategoryId>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category").HasKey(p=>p.Id);
          
        builder.Property(a => a.Id).ValueGeneratedNever().HasConversion(new CategoryIdValueConverter());

        builder.Property(p => p.Title).HasMaxLength(150).IsRequired();

        builder.Property(p => p.UrlName).HasMaxLength(200).IsRequired();

        builder.Property(p => p.ImageName).HasMaxLength(300).IsRequired();

    }
}  
public class CategoryIdValueConverter : ValueConverter<CategoryId, Guid>
    {
        public CategoryIdValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                id => id.Value,
                value => new CategoryId(value), 
                mappingHints
            ) { }
    }

