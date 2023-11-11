


using Framework.Application;

namespace Framework.RestApi
{

    public class BaseQueryController : BaseController
    {
        protected readonly IQueryBus Bus;
        public BaseQueryController(IQueryBus bus)
        {
            Bus = bus;
        }
    }
}