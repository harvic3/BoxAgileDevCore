namespace BoxAgileDevCore.Application.Result.Generic
{
  public interface IBaseResult<T> : IBaseResult
  {
    T Result { get; }

    void SetResult( T data );

    void SetSuccess( T data, string statusCode );

    void SetSuccess( string message, string statusCode );

    void SetSuccess( T data, string message, string statusCode );
  }
}
