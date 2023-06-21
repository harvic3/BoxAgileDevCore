using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTest.Domain;

namespace WebApiTest.Data.Interfaces
{
  public interface IWeatherRepository
  {
    Task<IEnumerable<Weather>> GetAll();

    Task<Weather> Add( Weather weather );
  }
}
