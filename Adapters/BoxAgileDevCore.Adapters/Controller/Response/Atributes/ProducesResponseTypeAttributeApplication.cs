using BoxAgileDevCore.Adapters.Controller.Response.Status;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BoxAgileDevCore.Adapters.Controller.Response.Atributes
{
  public class ProducesResponseTypeAttributeApplication : ProducesResponseTypeAttribute
  {
    public ProducesResponseTypeAttributeApplication( Type type, int httpStatusCode, string applicationStatusCode ) : base( type, httpStatusCode )
    {
      HttpStatusMapping.AddHttpStatusMapping( applicationStatusCode, (HttpStatusCode)httpStatusCode );
    }
  }
}
