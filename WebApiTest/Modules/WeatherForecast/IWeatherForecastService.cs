using BoxAgileDevCore.Result;
using System.Threading.Tasks;
using WebApiTest.Domain;

namespace WebApiTest.Modules.WeatherForecast
{
  public interface IWeatherForecastService
  {
    Task<IBaseResult> GetWeatherForecast();

    Task<IBaseResult> AddWeatherForeCast( Weather weather );
  }
}
