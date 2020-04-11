using System.Collections.Generic;
using System.Net;

namespace BoxAgileDev.Result
{
    public interface IBaseResult
    {
        HttpStatusCode StatusCode { get; }

        List<string> Messages { get; }

        bool Success { get; }

        void SetStatusCode(HttpStatusCode statusCode);

        void AddMessage(string message);

        void Successful();

        void SetError(string message, HttpStatusCode statusCode);
    }

}
