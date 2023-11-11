using Framework.Domain;

namespace Hall.Domain.Models.Categories;

public class CategoryId : Id<Guid>
{
    public CategoryId(Guid value) : base(value)
    {
    }
}