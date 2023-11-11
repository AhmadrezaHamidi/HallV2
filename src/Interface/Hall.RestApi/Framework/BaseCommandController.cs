
using Framework.Application;

namespace Framework.RestApi
{
    public class BaseCommandController : BaseController
    {
        protected readonly ICommandBus Bus;
        public BaseCommandController(ICommandBus bus)
        {
            Bus = bus;
        }
    }
}