using Framework.Application;
using Framework.RestApi;
using Hall.Application.Contract.Queries.Categories;
using Hall.Application.QueryResults.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Hall.RestApi.Controllers.V1.Categories;

[ApiVersion("1.0")]
public class CategoryQueryController:BaseQueryController
{
    public CategoryQueryController(IQueryBus bus) : base(bus)
    {
    }

    [HttpGet("All")]
    public async Task<ActionResult<List<AllCategoryQueryResult>>> AllCategories()
    {
        return Ok(await Bus.Dispatch<AllCategoryQuery, List<AllCategoryQueryResult>>(new()));
    }
}