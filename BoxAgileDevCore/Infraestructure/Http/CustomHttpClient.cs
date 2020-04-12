using BoxAgileDevCore.Infraestructure.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAgileDevCore.Infraestructure.Http
{
    public class CustomHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Constructor for CustomHttpClient
        /// </summary>
        /// <param name="clientFactory">HttpClientFactory class</param>
        public CustomHttpClient(IHttpClientFactory clientFactory, string clientName = "custom")
        {
            this.httpClient = clientFactory.CreateClient(clientName);
        }

        /// <summary>
        /// Method for do a http request for content and result json
        /// </summary>
        /// <typeparam name="TResponse">Response data model for request</typeparam>
        /// <typeparam name="TError">Error data model for request</typeparam>
        /// <param name="url">Endpoint for request</param>
        /// <param name="method">HttpMethod for request</param>
        /// <param name="content">HttpContent for request</param>
        /// <param name="headers">Headers for request</param>
        /// <param name="jsonSerializerSettings">Json settings serializer</param>
        /// <returns>(TResponse response, TError error, HttpStatusCode statusCode)</returns>
        public async Task<(TResponse response, TError error, HttpStatusCode statusCode)> SendRequestAsync<TResponse, TError>(string url,
                                                                                                                             HttpMethod method,
                                                                                                                             HttpContent content,
                                                                                                                             IDictionary<string, string> headers, 
                                                                                                                             JsonSerializerSettings jsonSerializerSettings = null)
        {
            var reqMessage = new HttpRequestMessage(method, url);
            this.SetHeaders(headers, reqMessage);

            reqMessage.Content = content;

            var cancellationToken = new CancellationToken();
            HttpResponseMessage responseMessage = await this.httpClient.SendAsync(reqMessage, cancellationToken);

            HttpStatusCode statusCode = responseMessage.StatusCode;
            string stringResponse = await responseMessage.Content.ReadAsStringAsync();

            try
            {
                var serializerSettings = jsonSerializerSettings ?? 
                                         new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                if (responseMessage.IsSuccessStatusCode)
                {
                    TResponse response = JsonConvert.DeserializeObject<TResponse>(stringResponse, serializerSettings);
                    return (response, default(TError), HttpStatusCode.OK);
                }
                else
                {
                    TError response = JsonConvert.DeserializeObject<TError>(stringResponse, serializerSettings);
                    return (default(TResponse), response, statusCode);
                }
            }
            catch (Exception)
            {
                return (default(TResponse), default(TError), HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Set headers for HttpRequestMessage
        /// </summary>
        /// <param name="headers">Headers for request</param>
        /// <param name="reqMessage">HttpRequestMessage for request transaction</param>
        private void SetHeaders(IDictionary<string, string> headers, HttpRequestMessage reqMessage)
        {
            this.httpClient.DefaultRequestHeaders.Clear();
            reqMessage.SetHeaders(headers);
        }

    }
}
