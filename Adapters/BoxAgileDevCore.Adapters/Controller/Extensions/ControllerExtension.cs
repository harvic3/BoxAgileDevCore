using BoxAgileDevCore.Adapters.Controller.Response.Status;
using BoxAgileDevCore.Application.Result;
using BoxAgileDevCore.Application.Result.Generic;
using BoxAgileDevCore.Application.Trace;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoxAgileDevCore.Adapters.Controller.Extensions
{
  public static class ControllerExtension
  {
    private static void SetStatusCode( this ControllerBase controller, string statusCode )
    {
      controller.HttpContext.Response.StatusCode = HttpStatusMapping.GetHttpCode( statusCode );
    }

    /// <summary>
    /// Method for get a trace from HttpContext
    /// </summary>
    /// <param name="controller"></param>
    /// <returns></returns>
    public static IUseCaseTrace? GetUseCaseTrace( this ControllerBase controller )
    {
      return controller.HttpContext.Items["UseCaseTrace"] as IUseCaseTrace;
    }

    /// <summary>
    /// Method for handle a result as an IActionResult
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="useCaseToExecute"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<IActionResult> HandleActionResultAsync<T>( this ControllerBase controller, Task<T>? useCaseToExecute ) where T : IBaseResult
    {
      if ( controller is null )
      {
        throw new ArgumentNullException( nameof( controller ) );
      }
      if ( useCaseToExecute is null )
      {
        throw new ArgumentNullException( nameof( IBaseResult ) );
      }

      var result = await useCaseToExecute;
      controller.SetStatusCode( result.StatusCode );

      return new ObjectResult( result );
    }

    /// <summary>
    /// Method for handle a result internal response as an IActionResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Out"></typeparam>
    /// <param name="controller"></param>
    /// <param name="useCaseToExecute"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<IActionResult> HandleActionResultDtoAsync<T>( this ControllerBase controller, Task<IBaseResult<T?>> useCaseToExecute )
    {
      if ( controller == null )
      {
        throw new ArgumentNullException( "controller" );
      }

      if ( useCaseToExecute == null )
      {
        throw new ArgumentNullException( "IBaseResult" );
      }

      var result = await useCaseToExecute;
      controller.SetStatusCode( result.StatusCode );
      bool hasData = result.Success && result.Result is not null;

      return new ObjectResult( result.Success && hasData ? result.Result : result.Messages.FirstOrDefault() );
    }

    /// <summary>
    /// Method for handle a result as a BaseResult
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="useCaseToExecute"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<IBaseResult> HandleResultAsync<T>( this ControllerBase controller, Task<T>? useCaseToExecute ) where T : IBaseResult
    {
      if ( controller is null )
      {
        throw new ArgumentNullException( nameof( controller ) );
      }
      if ( useCaseToExecute is null )
      {
        throw new ArgumentNullException( nameof( IBaseResult ) );
      }

      var result = await useCaseToExecute;

      ControllerExtension.SetStatusCode( controller, result.StatusCode );

      return result;
    }

    /// <summary>
    /// Method for set a media type for response
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="mediaType"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void SetResponseMediaType( this ControllerBase controller, string mediaType )
    {
      if ( controller is null )
      {
        throw new ArgumentNullException( nameof( controller ) );
      }

      controller.HttpContext.Response.Headers.Add( "Accept", mediaType );
    }
  }
}
