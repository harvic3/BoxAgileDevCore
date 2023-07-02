using BoxAgileDevCore.Adapters.Controller.Response.Status;
using BoxAgileDevCore.Application.Result;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BoxAgileDevCore.Adapters.Controller.Extensions
{
  public static class ControllerExtension
  {
    /// <summary>
    /// Method for handle a result as an IActionResult
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IActionResult HandleActionResult( this ControllerBase controller, IBaseResult result )
    {
      if ( controller is null )
      {
        throw new ArgumentNullException( nameof( controller ) );
      }

      return new ObjectResult( result );
    }

    /// <summary>
    /// Method for handle a result as a BaseResult
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IBaseResult HandleResult( this ControllerBase controller, IBaseResult result )
    {
      if ( controller is null )
      {
        throw new ArgumentNullException( nameof( controller ) );
      }
      controller.HttpContext.Response.StatusCode = HttpStatusMapping.GetHttpCode( result.StatusCode.ToString() );

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
