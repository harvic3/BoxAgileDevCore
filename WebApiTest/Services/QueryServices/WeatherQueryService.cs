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
