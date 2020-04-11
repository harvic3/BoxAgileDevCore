using Microsoft.AspNetCore.Mvc;
using BoxAgileDev.Controller.Utils;
using BoxAgileDev.Controller.Response;
using BoxAgileDev.Result;

namespace BoxAgileDev.Controller
{
    /// <summary>
    /// Class for management the service class.
    /// </summary>
    public class ControllerManager<TService> : ControllerBase, IControllerManager<TService>
    {
        private JsonUtils apiUtils;

        /// <summary>
        /// Constructor for service provider
        /// </summary>
        public ControllerManager(TService service)
        {
            this.Instance = service;
        }

        /// <summary>
        /// Instance of service for this controller
        /// </summary>
        public TService Instance { get; }

        /// <summary>
        /// Member for convert serialize data to other type or viceversa. 
        /// </summary>
        public JsonUtils ApiUtils
        {
            get
            {
                apiUtils = apiUtils ?? new JsonUtils();
                return apiUtils;
            }
        }

        /// <summary>
        /// ControllerBase extension method for create a response based on result data.
        /// </summary>
        /// <param name="result">IBaseResult data</param>
        /// <returns></returns>
        public IActionResult HandlerResponse(IBaseResult result)
        {
            return new CommonResponse(result);
        }

    }

}
