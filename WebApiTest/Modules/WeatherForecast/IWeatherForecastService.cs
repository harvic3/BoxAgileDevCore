using BoxAgileDev.Result;
using System.Threading.Tasks;

namespace WebApiTest.Modules.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<IBaseResult> GetWeatherForecast();

        Task<IBaseResult> AddWeatherForeCast();
    }
}
