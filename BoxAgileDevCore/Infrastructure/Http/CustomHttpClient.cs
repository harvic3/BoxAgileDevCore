using BoxAgileDevCore.Infrastructure.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAgileDevCore.Infrastructure.Http
{
  public sealed class CustomHttpClient : IDisposable
  {
    private readonly HttpClient httpClient;

    private bool disposed = false;

    /// <summary>
    /// Constructor for CustomHttpClient
    /// </summary>
    /// <param name="clientFactory">HttpClientFactory class</param>
    public CustomHttpClient( IHttpClientFactory clientFactory, string clientName = "custom" )
    {
      this.httpClient = clientFactory.CreateClient( clientName );
    }

    /// <summary>
    /// Method for do a http request for content and result json
    /// </summary>
    /// <typeparam name="TResponse">Response data model for request</typeparam>
    /// <typeparam name="TError">Error data model for request</typeparam>
    /// <param name="url">Endpoint for request</param>
    /// <param name="method">HttpMethod for request</param>
    /// <param name="headers">Headers for request</param>
    /// <param name="content">HttpContent for request</param>
    /// <returns>(TResponse response, TError error, HttpStatusCode statusCode)</returns>
    public async Task<(TResponse response, TError error, HttpStatusCode statusCode)> SendAsync<TResponse, TError>(
      string url,
      HttpMethod method,
      IDictionary<string, string> headers,
      HttpContent? content = null,
      JsonSerializerSettings? jsonSerializerSettings = null
      )
    {
      var (reqMessage, cancellationToken) = this.CreateRequestMessage( url, method, headers, content );

      HttpResponseMessage responseMessage = await this.httpClient.SendAsync( reqMessage, cancellationToken );

      return await this.DeserializeResponse<TResponse, TError>( responseMessage, jsonSerializerSettings );
    }

    public async Task<(TResponse response, TError[] errors, HttpStatusCode statusCode)> SendRetryAsync<TResponse, TError>(
     string url,
     HttpMethod method,
     IDictionary<string, string> headers,
     HttpContent? content,
     int retries = 0,
     int retryTimeount = 0,
     JsonSerializerSettings? jsonSerializerSettings = null )
    {
      int iterartions = 0;
      TError[] errors = new TError[retries == 0 ? 1 : retries];
      HttpStatusCode statusCode;

      do
      {
        var (reqMessage, cancellationToken) = this.CreateRequestMessage( url, method, headers, content );

        HttpResponseMessage responseMessage = await this.httpClient.SendAsync( reqMessage, cancellationToken );

        if ( responseMessage.IsSuccessStatusCode )
        {
          var iteration = await this.DeserializeResponse<TResponse, TError>( responseMessage, jsonSerializerSettings );
          return (iteration.response, errors, iteration.statusCode);
        }
        else
        {
          var iteration = await this.DeserializeResponse<TResponse, TError>( responseMessage, jsonSerializerSettings );
          statusCode = iteration.statusCode;
          errors[iterartions] = iteration.error;
          iterartions++;
          await Task.Delay( retryTimeount );
        }
      } while ( iterartions <= retries );

      return (default( TResponse ), errors, statusCode);
    }

    /// <summary>
    /// Set headers for HttpRequestMessage
    /// </summary>
    /// <param name="headers">Headers for request</param>
    /// <param name="reqMessage">HttpRequestMessage for request transaction</param>
    private void SetHeaders( IDictionary<string, string> headers, HttpRequestMessage reqMessage )
    {
      this.httpClient.DefaultRequestHeaders.Clear();
      reqMessage.SetHeaders( headers );
    }

    private (HttpRequestMessage reqMessage, CancellationToken cancellationToken) CreateRequestMessage(
      string url, HttpMethod method, IDictionary<string, string> headers, HttpContent? request )
    {
      var reqMessage = new HttpRequestMessage( method, url );
      this.SetHeaders( headers, reqMessage );

      if ( request != null )
        reqMessage.Content = request;

      return (reqMessage, new CancellationToken());
    }

    private async Task<(TResponse response, TError error, HttpStatusCode statusCode)> DeserializeResponse<TResponse, TError>(
      HttpResponseMessage responseMessage,
      JsonSerializerSettings? jsonSerializerSettings
    )
    {
      try
      {
        HttpStatusCode statusCode = responseMessage.StatusCode;
        string stringResponse = await responseMessage.Content.ReadAsStringAsync();

        if ( string.IsNullOrEmpty( stringResponse ) )
        {
          return (default( TResponse ), default( TError ), statusCode);
        }

        var serializerSettings = jsonSerializerSettings ??
          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Include };

        if ( responseMessage.IsSuccessStatusCode )
        {
          TResponse response = JsonConvert.DeserializeObject<TResponse>( stringResponse, serializerSettings );
          return (response, default( TError ), statusCode);
        }
        else
        {
          TError response = JsonConvert.DeserializeObject<TError>( stringResponse, serializerSettings );
          return (default( TResponse ), response, statusCode);
        }
      }
      catch ( Exception )
      {
        return (default( TResponse ), default( TError ), HttpStatusCode.InternalServerError);
      }
    }

    public void Dispose()
    {
      Dispose( true );
      GC.SuppressFinalize( this );
    }

    private void Dispose( bool disposing )
    {
      if ( disposed )
        return;

      if ( disposing )
      {
        httpClient.Dispose();
      }

      disposed = true;
    }
  }
}
