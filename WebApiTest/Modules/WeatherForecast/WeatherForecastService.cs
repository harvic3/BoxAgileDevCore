using BoxAgileDev.Result;
using System.Threading.Tasks;
using BoxAgileDev.Result.Generic;
using System.Collections.Generic;
using WebApiTest.Services.CommandServices;
using WebApiTest.Services.QueryServices;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            Result<IEnumerable<Domain.Weather>> result = new Result<IEnumerable<Domain.Weather>>();

            var data = await this.weatherQueryService.GetAll();
            result.Successful(data);

            return await Task.FromResult(result);
        }

        public async Task<IBaseResult> AddWeatherForeCast(Domain.Weather weather)
        {
            Result<Domain.Weather> result = new Result<Domain.Weather>();

            result.Successful(this.weatherCommandService.Add())

            return result;
        }

    }
}