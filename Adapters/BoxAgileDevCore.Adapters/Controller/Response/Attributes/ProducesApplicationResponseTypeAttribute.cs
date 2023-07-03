using BoxAgileDevCore.Adapters.Controller.Response.Status;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BoxAgileDevCore.Adapters.Controller.Response.Attributes
{
  public class ProducesApplicationResponseTypeAttribute : ProducesResponseTypeAttribute
  {
    public ProducesApplicationResponseTypeAttribute( Type type, int httpStatusCode, string applicationStatusCode ) : base( type, httpStatusCode )
    {
      HttpStatusMapping.AddHttpStatusMapping( applicationStatusCode, (HttpStatusCode)httpStatusCode );
    }
  }
}
