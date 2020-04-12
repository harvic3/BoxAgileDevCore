using System.Net;

namespace BoxAgileDevCore.Result.Generic
{
    public interface IBaseResult<T> : IBaseResult
    {
        T Result { get; }

        void SetResult(T data);

        void SetSuccess(T data, HttpStatusCode statusCode = HttpStatusCode.OK);

        void SetSuccess(string message, HttpStatusCode statusCode = HttpStatusCode.OK);

        void SetSuccess(T data, string message, HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
