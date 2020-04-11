using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Domain;

namespace WebApiTest.Services.CommandServices
{
    public class WeatherCommandService : IWeatherCommandService
    {
        public Task<Weather> Add(Weather weather)
        {
            throw new NotImplementedException();
        }
    }
}
