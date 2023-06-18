using BoxAgileDevCore.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoxAgileDevCore.Controller.Response
{
    /// <summary>
    /// Method for build a Http response with the http status code of transaction.
    /// </summary>    
    public class CommonResponse : IActionResult
    {
        private readonly IBaseResult result;

        /// <summary>
        /// Constructor for build IActionResult
        /// </summary>
        /// <param name="result">IBaseResult for request</param>
        public CommonResponse(IBaseResult result)
        {
            this.result = result;
        }

        /// <summary>
        /// Action for build a response
        /// </summary>
        /// <param name="context">ActionContext for controller</param>
        /// <returns></returns>
        public Task ExecuteResultAsync(ActionContext context)
        {
            var response = new ObjectResult( this.result)
            {
                StatusCode = Convert.ToInt32(this.result.StatusCode),
            };

            return response.ExecuteResultAsync(context);
        }

    }

}
