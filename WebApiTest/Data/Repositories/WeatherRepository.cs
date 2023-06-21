using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Data.Interfaces;
using WebApiTest.Data.DataModels;
using WebApiTest.Domain;
using BoxAgileDevCore.Mapping;

namespace WebApiTest.Data.Repositories
{
  public class WeatherRepository : IWeatherRepository
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private static readonly string[] Cities = new[]
    {
            "Medellín", "Bogotá", "Cali"
        };

    public Task<Weather> Add( Weather weather )
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Weather>> GetAll()
    {
      var rng = new Random();
      var data = Enumerable.Range( 1, 5 ).Select( index => new WeatherDto
      {
        Date = DateTime.Now.AddDays( index ),
        TemperatureC = rng.Next( -20, 55 ),
        Summary = Summaries[rng.Next( Summaries.Length )],
        City = Cities[rng.Next( Cities.Length )],
      } )
      .ToList();
      return await Task.FromResult( SimpleMapper.MapCollection<WeatherDto, Weather>( data ) );
    }

  }
}
