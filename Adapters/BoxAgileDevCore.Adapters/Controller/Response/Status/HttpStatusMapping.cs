using System.Collections.Generic;
using System.Net;

namespace BoxAgileDevCore.Adapters.Controller.Response.Status
{
  public static class HttpStatusMapping
  {
    private static readonly HttpStatusCode DefaultHttpStatusCode = HttpStatusCode.Continue;

    private static readonly IDictionary<string, HttpStatusCode> HttpStatusDictionary = new Dictionary<string, HttpStatusCode>();

    public static void SetOrphanStatusCodes( IDictionary<string, HttpStatusCode> values )
    {
      foreach ( var value in values )
      {
        if ( !HttpStatusDictionary.ContainsKey( value.Key ) )
        {
          HttpStatusDictionary.Add( value.Key, value.Value );
        }
      }
    }

    public static void AddHttpStatusMapping( string applicationStatusCode, HttpStatusCode httpStatusCode )
    {
      if ( !HttpStatusDictionary.ContainsKey( applicationStatusCode ) )
      {
        HttpStatusDictionary.Add( applicationStatusCode, httpStatusCode );
      }
    }

    public static int GetHttpCode( string applicationStatusCode )
    {
      if ( HttpStatusDictionary.ContainsKey( applicationStatusCode ) )
      {
        return (int)HttpStatusDictionary[applicationStatusCode];
      }

      return (int)DefaultHttpStatusCode;
    }
  }
}
