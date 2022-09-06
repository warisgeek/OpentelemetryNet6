using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTraceID")]
        public string Get()
        {
            _logger.Log(LogLevel.Information,"trace id", Activity.Current.Id);
            return Activity.Current.Id;
        }
    }
}