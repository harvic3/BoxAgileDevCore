using System.Collections.Generic;
using System.Net.Http;

namespace BoxAgileDevCore.Infraestructure.Extensions
{
    public static class HttpRequestMessageExtension
    {
        public static HttpRequestMessage SetHeaders(this HttpRequestMessage requestMessage, IDictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> header in headers)
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return requestMessage;
        }
    }

}
