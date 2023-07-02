using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTest.Data.Interfaces;
using WebApiTest.Data.Repositories;
using WebApiTest.Modules.WeatherForecast;
using WebApiTest.Services.CommandServices;
using WebApiTest.Services.QueryServices;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddTransient<IWeatherCommandService, WeatherCommandService>();
builder.Services.AddTransient<IWeatherQueryService, WeatherQueryService>();
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();

/*
       * Observation:
            This is important for map the DataMember names into Dto.
            You can add Nuget Microsoft.AspNetCore.Mvc.NewtonsoftJson and 
            add extension mehod AddNewtonsoftJson();
       * If you are NOT going to use DataMember attributes you can omit this setting. 
      */
builder.Services.AddControllers()
        .AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
  app.UseDeveloperExceptionPage();
}

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
