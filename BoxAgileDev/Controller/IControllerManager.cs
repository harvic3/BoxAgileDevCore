using BoxAgileDev.Controller.Utils;
using BoxAgileDev.Result;
using Microsoft.AspNetCore.Mvc;

namespace BoxAgileDev.Controller
{
    public interface IControllerManager<T>
    {
        T Instance { get; }

        JsonUtils ApiUtils { get; }

        IActionResult HandlerResponse(IBaseResult result);
    }

}
