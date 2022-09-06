using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ServiceB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient httpClient1;
        public WeatherForecastController(HttpClient httpClient)
        {
            httpClient1 = httpClient;


        }

        [HttpGet(Name = "GetTraceID")]
        public string Get()
        {
            var serviceBTraceId = httpClient1.GetAsync("https://localhost:7224/WeatherForecast").Result.Content.ReadAsStringAsync().Result;
            return $"Service A Traceparent {Activity.Current.Id}. Service B Traceparent {serviceBTraceId}";
        }
    }
}