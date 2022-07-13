using Microsoft.AspNetCore.Mvc;

namespace marine_tp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        [Route("/")]
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
