using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace marine_tp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        [Route("weather")]
        public string Weather()
        {
            return "this route '/weather' return this";   
        }

        [HttpGet]
        [Route("sun")]
        public string Sun()
        {
            return "this route '/sun' return this";
        }
    }
}
