using System.Runtime.Serialization;
using System.Collections.Generic;
using BoxAgileDevCore.Application.Status;

namespace BoxAgileDevCore.Application.Result
{
  [DataContract]
  public class BaseResult : IBaseResult
  {
    /// <summary>
    /// Property to management the status transaction. Default is error code 500
    /// </summary>
    [DataMember( Name = "statusCode" )]
    public string StatusCode { get; private set; } = ApplicationStatusBase.INTERNAL_ERROR;

    /// <summary>
    /// Property to set message about transaction
    /// </summary>
    [DataMember( Name = "messages" )]
    public List<string> Messages { get; private set; } = new List<string>();

    /// <summary>
    /// Property for set success the transaction
    /// </summary>
    [DataMember( Name = "success" )]
    public bool Success { get; private set; } = false;

    /// <summary>
    ///  Method to set message about transaction process
    /// </summary>
    /// <param name="message"></param>
    public void SetMessage( string message, string statusCode = ApplicationStatusBase.SUCCESSFUL )
    {
      this.Messages = new List<string>
      {
        message
      };
      this.Success = true;
      this.StatusCode = statusCode;
    }

    /// <summary>
    /// Method to add mmesage about transaction proccess
    /// </summary>
    /// <param name="message">Message to add</param>
    public void AddMessage( string message )
    {
      this.Success = true;
      this.Messages.Add( message );
    }

    /// <summary>
    /// Method to set the status for the current transaction
    /// </summary>
    /// <param name="statusCode">Http status code of transaction</param>
    public void SetStatusCode( string statusCode )
    {
      this.StatusCode = statusCode;
    }

    /// <summary>
    /// Set successful the transaction and set status code to 200 (OK)
    /// </summary>
    public void SetSuccess()
    {
      this.Success = true;
      this.StatusCode = ApplicationStatusBase.SUCCESSFUL;
    }

    /// <summary>
    /// Method to set the error message and statusCode for the current transaction
    /// </summary>
    /// <param name="errorMessage">Error message of transaction</param>
    /// <param name="statusCode">Status code for transaction</param>
    public void SetError( string errorMessage, string statusCode )
    {
      this.Messages = new List<string>
      {
        errorMessage
      };
      this.Success = false;
      this.StatusCode = statusCode;
    }

    /// <summary>
    /// Method 
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <param name="statusCode"></param>
    public void AddError( string errorMessage )
    {
      this.Success = false;
      this.Messages.Add( errorMessage );
    }

    /// <summary>
    /// Method to verify if result has any error
    /// </summary>
    public bool HasErrors()
    {
      return this.Messages.Count > 0 && this.Success == false;
    }

    /// <summary>
    /// Method to verify if result has any message
    /// </summary>
    public bool HasMessages()
    {
      return this.Messages.Count > 0 && this.Success == true;
    }
  }
}
