using Framework.Application;
using Framework.RestApi;
using Microsoft.AspNetCore.Mvc;

namespace Hall.RestApi.Controllers.V1.Categories;

[ApiVersion("1.0")]
public class CategoryCommandController:BaseCommandController
{
    public CategoryCommandController(ICommandBus bus) : base(bus)
    {
    }
}