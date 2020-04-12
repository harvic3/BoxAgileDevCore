# Box Agile Dev Core (BAD)

> BADCore is a `ToolBox` for the agile development of Net Core Web Api projects under the guide of a `WorkFlow`.


## Environment

> This library was made for Net Core platform.

## Installation

- Go to management Nuget Package in your project and searh BADCore and install the last versión of `Vickodev.Utility.BADCore`.
- Ok, once installed, go to any Class in the project and declare the library for use it, `using BoxAgileDevCore;` and ready.

## Tools in package

> `BaseResult`: is a class for flow business control and set the response data for request of your application.

> `CommonResponse`: is a class for management the response througt IActionResult of request into Controller method.

> `SimpleMapper`: is a simple tool for mapping object models with data models (Simple obects or colections, not work for mixtures for the moment).

> `ControllerManager`: is a class based in ControllerBase for  for management the ControllerBase and deserialize/serialize Json objects in object models (JsonUtil) into your application and get a method (HanlderResponse) for manage the result for current request.

> `JsonUtil`: is a class into ControllerManager with which you can deserialize/serialize objects in Json format to object models and viceversa.

> `CustomHttpCient`: is a class for manage a single instance of HttpClient class for manage your request through the Net Core `IHttpClientFactory` interface.
The advantages offered by this implementation is the optimal management of the HTTP connections avoiding the collapse of the system connection ports and injecting the headers in the HttpRequest messages and not in the client.


## Example 

The following is a cursory look at the usage of the package, however for more details you can review the testing `Net Core API` at the following link:

- <a href="https://github.com/harvic3/BoxAgileDevCore/tree/master/WebApiTest" target="_blank" >Go to WebApiTest</a>


```c#
// This is a Controller

using BoxAgileDevCore.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiTest.Modules.WeatherForecast
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

// This is a Businnes Service

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

// This is a query service

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTest.Data.Interfaces;
using WebApiTest.Domain;

namespace WebApiTest.Services.QueryServices
{
    public class WeatherQueryService : IWeatherQueryService
    {
        private readonly IWeatherRepository weatherRepository;

        public WeatherQueryService(IWeatherRepository weatherRepository)
        {
            this.weatherRepository = weatherRepository;
        }

        public async Task<IEnumerable<Weather>> GetAll()
        {
            return await this.weatherRepository.GetAll();
        }
    }
}
```

## Usage

