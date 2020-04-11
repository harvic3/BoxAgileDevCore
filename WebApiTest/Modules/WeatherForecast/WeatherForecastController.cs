using BoxAgileDev.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiTest.Modules.WeatherForecast;

namespace WebApiTest.Modules.Weather
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerManager<IWeatherForecastService>
    {
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
            :base(weatherForecastService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            var result = await Instance.GetWeatherForecast();

            return this.HandlerResponse(result);
        }
    }
}
