# Box Agile Dev Core (BADCore)

> BADCore is a `ToolBox` for the agile development of Net Core Web Api projects under the guide of a `WorkFlow`.

You can find the package on the nuget site by following the link:
- <a href="https://www.nuget.org/packages/Vickodev.Utility.BADCore/" target="_blank" >Go to Nuget org</a>

## Environment

> This library was made for Net Core platform.

## Installation

- Go to management Nuget Package in your project and searh BADCore and install the last versión of `Vickodev.Utility.BADCore`.
- Ok, once installed, go to any Class in the project and declare the library for use it, `using BoxAgileDevCore;` and ready.

## Tools in package

> `BaseResult`: is a class for flow business control and set the response data for request of your application.

> `CommonResponse`: is a class for management the response througt `IActionResult` interface of each request into called Controller method.

> `SimpleMapper`: is a simple tool for mapping object models with data models (Simple objects or collections, not work for mixtures for the moment).

> `ControllerManager`: is a class based in `ControllerBase` class for  for management the Controller methods and deserialize/serialize Json objects in object models (JsonUtil) into your application and get a method (HanlderResponse) for manage the result for current request.

> `JsonUtil`: is a tool class into `ControllerManager` with which you can deserialize/serialize objects in Json format to object models and viceversa.

> `CustomHttpClient`: is a class for manage a single instance of `HttpClient` class for manage your request through the Net Core `IHttpClientFactory` interface.
The advantages offered by this implementation is the optimal management of the HTTP requests avoiding the collapse of the system connection ports and injecting the headers in the HttpRequest messages and not in the client.


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

// This is a Business Service

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

## Important usage details

- Install the `BADCore` Package in your NetCore  API Project.

- If you use a classes with `DataContract` attribute you must do the following:

> Install the nuget Package `Microsoft.AspNetCore.Mvc.NewtonsoftJson` and use the extension method `.AddNewtonsoftJson()` in your Startup class as following:
```c#
public void ConfigureServices(IServiceCollection services)
{
    /*
        *
        your other settings

    */

    services.AddControllers()
            .AddNewtonsoftJson(); //This extension method is neccesary for map the DataMember in your DataContract classes.
}
```

