namespace BoxAgileDevCore.Adapters.ApiServicesManager
{
  public interface IServiceManager<T>
  {
    TService? GetService<TService>();
    TService GetUseCaseService<TService>() where TService : T;
  }
}
