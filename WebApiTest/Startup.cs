using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTest.Data.Interfaces;
using WebApiTest.Data.Repositories;
using WebApiTest.Modules.WeatherForecast;
using WebApiTest.Services.CommandServices;
using WebApiTest.Services.QueryServices;

namespace WebApiTest
{
  public class Startup
  {
    public Startup( IConfiguration configuration )
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices( IServiceCollection services )
    {
      services.AddHttpClient();

      services.AddTransient<IWeatherForecastService, WeatherForecastService>();
      services.AddTransient<IWeatherCommandService, WeatherCommandService>();
      services.AddTransient<IWeatherQueryService, WeatherQueryService>();
      services.AddTransient<IWeatherRepository, WeatherRepository>();

      /*
       * Observation:
            This is important for map the DataMember names into Dto.
            You can add Nuget Microsoft.AspNetCore.Mvc.NewtonsoftJson and 
            add extension mehod AddNewtonsoftJson();
       * If you are NOT going to use DataMember attributes you can omit this setting. 
      */
      services.AddControllers()
              .AddNewtonsoftJson();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
    {
      if ( env.IsDevelopment() )
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints( endpoints =>
      {
        endpoints.MapControllers();
      } );
    }
  }
}
