using System;
using System.Collections.Generic;

namespace BoxAgileDevCore.Application.Trace
{
  public interface IUseCaseTrace
  {
    string? UseCaseContext { get; set; }
    DateTime StartDate { get; set; }
    DateTime? EndDate { get; set; }
    bool Successful { get; set; }
    string StatusCode { get; set; }
    object? Payload { get; set; }
    IDictionary<string, string> QueryParams { get; }
    IDictionary<string, string> Parameters { get; }
    IDictionary<string, object> Metadata { get; }

    void SetUseCaseContext( string useCaseContext );
    void SetSuccessful();
    void AddMetadata( string key, object value );
    void SetStatusCode( string statusCode );
    void SetPayload( object payload );
    void SetQueryParams( IDictionary<string, string> value );
    void AddQueryParam( string key, string queryValue );
    void SetParameters( IDictionary<string, string> parameters );
    void AddParameter( string key, string value );
    void SetEndDate( DateTime endDate );
  }
}
