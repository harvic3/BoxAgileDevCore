using System.Collections.Generic;
using System.Net;

namespace BoxAgileDevCore.Result
{
    public interface IBaseResult
    {
        HttpStatusCode StatusCode { get; }

        List<string> Messages { get; }

        bool Success { get; }

        void SetStatusCode(HttpStatusCode statusCode);

        void SetMessage(string message, HttpStatusCode statusCode );

        void AddMessage(string message);

        void SetSuccess();

        void SetError(string message, HttpStatusCode statusCode);

        void AddError( string message);

        bool HasErrors();

        bool HasMessages();
    }

}
