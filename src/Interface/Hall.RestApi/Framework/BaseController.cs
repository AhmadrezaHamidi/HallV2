using Microsoft.AspNetCore.Mvc;

namespace Framework.RestApi
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
      
    }
}