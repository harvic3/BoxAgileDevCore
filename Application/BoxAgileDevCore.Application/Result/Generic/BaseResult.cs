using BoxAgileDevCore.Application.Status;
using System.Runtime.Serialization;

namespace BoxAgileDevCore.Application.Result.Generic
{
  [DataContract]
  public class BaseResult<T> : BaseResult, IBaseResult<T>
  {
    /// <summary>
    /// Property for data of transaction
    /// </summary>
    [DataMember( Name = "result" )]
    public T Result { get; private set; }

    /// <summary>
    /// Method for set data of transaction
    /// </summary>
    /// <param name="data">Result data for transaction</param>
    public void SetResult( T data )
    {
      this.Result = data;
    }

    /// <summary>
    /// Method for set a succesful transaction
    /// </summary>
    /// <param name="data">Result data for transaction</param>
    /// <param name="statusCode">StatusCode of transaction</param>
    public void SetSuccess( T data, string statusCode = ApplicationStatusBase.SUCCESSFUL )
    {
      this.SetSuccess();
      this.Result = data;
      this.SetStatusCode( statusCode );
    }

    /// <summary>
    /// Method for set a succesful transaction
    /// </summary>
    /// <param name="message">Message for transaction</param>
    /// <param name="statusCode">StatusCode of transaction</param>
    public void SetSuccess( string message, string statusCode = ApplicationStatusBase.SUCCESSFUL )
    {
      this.SetSuccess();
      this.AddMessage( message );
      this.SetStatusCode( statusCode );
    }

    /// <summary>
    /// Method for set data and message as a succesful transaction
    /// </summary>
    /// <param name="data">Result data for transaction</param>
    /// <param name="message">Message for transaction</param>
    /// <param name="statusCode">StatusCode of transaction</param>
    public void SetSuccess( T data, string message, string statusCode = ApplicationStatusBase.SUCCESSFUL )
    {
      this.Result = data;
      this.AddMessage( message );
      this.SetStatusCode( statusCode );
      this.SetSuccess();
    }
  }
}
