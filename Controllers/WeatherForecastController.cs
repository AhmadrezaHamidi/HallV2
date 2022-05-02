using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using tama.Domain.BaseDomain;
using tama.Domain.Entity;
using tama.ViewModels;

namespace tama.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    ///[Authorize] ///all the serveses need token 
    [AllowAnonymous]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private TamasaContext _tamasaContext;
        private readonly PassarGadModel _passargad;
        private readonly KaveNegarModel _kaveNegar;   
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IOptions<PassarGadModel> passarGad,
        IOptions<KaveNegarModel> KaveNegar,TamasaContext tamasaContext)
        {
            _logger = logger;
            _passargad = passarGad.Value;
            _kaveNegar = KaveNegar.Value;
            _tamasaContext = tamasaContext;
        }

        [HttpGet]
        public IEnumerable<TransActionEntity> GetTranActions()
        {
            var trsn = _tamasaContext.TransActionTb.ToList();
            return trsn;
        }

        [HttpGet]
        public IActionResult GetTranActionById(string Id)
        {
            var trsn = _tamasaContext.TransActionTb.
            FirstOrDefault(x => x.Id.Equals(Id));
            
            
            
            if(trsn is null)
              return BadRequest();
            
            
            
            return Ok(trsn);
        }
        
    }
}
