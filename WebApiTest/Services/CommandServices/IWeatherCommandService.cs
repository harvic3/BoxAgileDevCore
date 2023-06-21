using System.Threading.Tasks;
using WebApiTest.Domain;

namespace WebApiTest.Services.CommandServices
{
  public interface IWeatherCommandService
  {
    Task<Weather> Add( Weather weather );
  }
}
