using BoxAgileDevCore.Controller.Utils;
using BoxAgileDevCore.Result;
using Microsoft.AspNetCore.Mvc;

namespace BoxAgileDevCore.Controller
{
    public interface IControllerManager<T>
    {
        T Instance { get; }

        JsonUtils ApiUtils { get; }

        IActionResult HandlerResponse(IBaseResult result);
    }

}
