using System.Collections.Generic;

namespace BoxAgileDevCore.Application.Result
{
  public interface IBaseResult
  {
    string StatusCode { get; }

    List<string> Messages { get; }

    bool Success { get; }

    void SetStatusCode( string statusCode );

    void SetMessage( string message, string statusCode );

    void AddMessage( string message );

    void SetSuccess();

    void SetError( string message, string statusCode );

    void AddError( string message );

    bool HasErrors();

    bool HasMessages();
  }

}
