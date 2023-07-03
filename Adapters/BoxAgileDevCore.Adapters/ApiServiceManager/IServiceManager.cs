namespace BoxAgileDevCore.Adapters.ApiServicesManager
{
  public interface IServiceManager
  {
    TService GetService<TService>();
  }
}
