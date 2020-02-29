using BoxAgileDev.Result;
using Newtonsoft.Json;
using System.Net.Http;

namespace BoxAgileDev.Response
{
    /// <summary>
    /// Method for build a Http response with the http status code of transaction.
    /// </summary>    
    public class HttpResponse
    {
        /// <summary>
        /// Method for build http response
        /// </summary>
        /// <param name="result">Result of process</param>
        /// <param name="request">Request of client</param>
        /// <returns></returns>
        public HttpResponseMessage HandleResult(IBaseResult result, HttpRequestMessage request)
        {            
            return request.CreateResponse(result.StatusCode, result);
        }

        /// <summary>
        /// Method for serialize object
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns></returns>
        public string SerializeDynamic(object obj)
        {
            string result = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.Default,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                FloatFormatHandling = FloatFormatHandling.DefaultValue
            });

            return result;
        }
    }
}
