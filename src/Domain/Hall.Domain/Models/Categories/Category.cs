
using Framework.Domain;

namespace Hall.Domain.Models.Categories;

public class Category:AggregateRoot<CategoryId>
{
    public string Title { get; private set; }
    public string UrlName { get; private set; }
    public string ImageName { get; private set; }

    public Category(string title, string urlName, string imageName)
    {
        Id = new (Guid.NewGuid());
        Title = title;
        UrlName = urlName;
        ImageName = imageName;
    }
}