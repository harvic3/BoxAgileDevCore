using System.Net;

namespace BoxAgileDev.Result.Generic
{
    public interface IBaseResult<T> : IBaseResult
    {
        T Data { get; }

        void SetData(T data);

        void Successful(T data, HttpStatusCode statusCode = HttpStatusCode.OK);

        void Successful(string message, HttpStatusCode statusCode = HttpStatusCode.OK);

        void Successful(T data, string message, HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
