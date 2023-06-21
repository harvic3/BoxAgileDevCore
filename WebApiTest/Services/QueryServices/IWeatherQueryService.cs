using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTest.Domain;

namespace WebApiTest.Services.QueryServices
{
  public interface IWeatherQueryService
  {
    Task<IEnumerable<Weather>> GetAll();
  }
}
