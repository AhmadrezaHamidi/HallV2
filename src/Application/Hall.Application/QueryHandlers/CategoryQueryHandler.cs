using Framework.Application;
using Hall.Application.Contract.Queries.Categories;
using Hall.Application.QueryResults.Categories;
using Hall.Domain.Models.Categories;

namespace Hall.Application.QueryHandlers;

public class CategoryQueryHandler:IQueryHandler<AllCategoryQuery,List<AllCategoryQueryResult>>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<List<AllCategoryQueryResult>> Handle(AllCategoryQuery query)
    {
        var categories = await _categoryRepository.All();
        return categories.Select(c => new AllCategoryQueryResult(c.Id.Value, c.Title, c.UrlName, c.ImageName)).ToList();
    }
}