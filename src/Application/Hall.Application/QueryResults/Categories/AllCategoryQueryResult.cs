using Framework.Application;

namespace Hall.Application.QueryResults.Categories;

public class AllCategoryQueryResult:IQueryResult
{
    public Guid Id { get; set; }
    public string Title { get;  set; }
    public string UrlName { get;  set; }
    public string ImageName { get;  set; }

    public AllCategoryQueryResult(Guid id, string title, string urlName, string imageName)
    {
        Id = id;
        Title = title;
        UrlName = urlName;
        ImageName = imageName;
    }
}