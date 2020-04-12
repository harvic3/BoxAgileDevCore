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
        private readonly IWeatherCommandService weatherCommandService;
        private readonly IWeatherQueryService weatherQueryService;

        public WeatherForecastService(IServiceProvider serviceProvider)
        {
            this.weatherCommandService = serviceProvider.GetService<IWeatherCommandService>();
            this.weatherQueryService = serviceProvider.GetService<IWeatherQueryService>();
        }               

        public async Task<IBaseResult> GetWeatherForecast()
        {
            BaseResult<IEnumerable<Weather>> result = new BaseResult<IEnumerable<Weather>>();

            var data = await this.weatherQueryService.GetAll();
            result.SetSuccess(data);

            return await Task.FromResult(result);
        }

        public async Task<IBaseResult> AddWeatherForeCast(Weather weather)
        {
            BaseResult<Domain.Weather> result = new BaseResult<Weather>();

            result.SetSuccess(await this.weatherCommandService.Add(weather));

            return result;
        }

    }
}