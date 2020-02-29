using BoxAgileDev.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BoxAgileDev.Extensions.Controller
{
    /// <summary>
    /// Class for Management (BM) to process control.
    /// </summary>
    public class HttpApi<T> : ApiController
    {
        private HttpResponse _httpUtility;
        private PostUtil _postUtility;
        private T _instance;

        /// <summary>
        /// Instance of Business Logic Controller for this service. (BM)
        /// </summary>
        public T Instance
        {
            get
            {
                bool isEmpty = EqualityComparer<T>.Default.Equals(_instance, default(T));
                _instance = isEmpty == true ? Activator.CreateInstance<T>() : _instance;
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        /// <summary>
        /// Method for build a HttpResponse
        /// </summary>
        public HttpResponse HttpUtility
        {
            get
            {
                _httpUtility = _httpUtility ?? new HttpResponse();
                return _httpUtility;
            }
        }

        /// <summary>
        /// Function for convert data in format Json to other Type. 
        /// </summary>
        public PostUtil PostUtility
        {
            get
            {
                _postUtility = _postUtility ?? new PostUtil();
                return _postUtility;
            }
        }
    }

    /// <summary>
    /// Class for convert data in JSon to other object Type.
    /// </summary>
    public class PostUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Generic type to return</typeparam>
        /// <param name="data">Object y Json</param>
        /// <returns></returns>
        public T Get<T>(dynamic data)
        {
            if (data != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                return JsonConvert.DeserializeObject<T>(data.ToString(), settings);
            }
            return default(T);
        }
    }
}
