using BoxAgileDevCore.Result;
using System.Threading.Tasks;
using BoxAgileDevCore.Result.Generic;
using System.Collections.Generic;
using WebApiTest.Services.CommandServices;
using WebApiTest.Services.QueryServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApiTest.Domain;

namespace WebApiTest.Modules.WeatherForecast
{
  public class WeatherForecastService : IWeatherForecastService
  {
    private readonly IServiceProvider serviceProvider;

    public WeatherForecastService( IServiceProvider serviceProvider )
    {
      this.serviceProvider = serviceProvider;
    }

    public async Task<IBaseResult> GetWeatherForecast()
    {
      BaseResult<IEnumerable<Weather>> result = new();

      var data = await serviceProvider.GetService<IWeatherQueryService>().GetAll();
      result.SetSuccess( data );

      return await Task.FromResult( result );
    }

    public async Task<IBaseResult> AddWeatherForeCast( Weather weather )
    {
      BaseResult<Weather> result = new();

      result.SetSuccess( await serviceProvider.GetService<IWeatherCommandService>().Add( weather ) );

      return result;
    }

  }
}