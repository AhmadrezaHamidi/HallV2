using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tama.Domain.BaseDomain;
using tama.ViewModels;

namespace tama.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransActionContoller : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private TamasaContext _tamasaContext;
        private readonly PassarGadModel _passargad;
        private readonly KaveNegarModel _kaveNegar;

        public TransActionContoller(ILogger<WeatherForecastController> logger, TamasaContext tamasaContext, PassarGadModel passargad, KaveNegarModel kaveNegar)
        {
            _logger = logger;
            _tamasaContext = tamasaContext;
            _passargad = passargad;
            _kaveNegar = kaveNegar;
        }
       
    }
        

}