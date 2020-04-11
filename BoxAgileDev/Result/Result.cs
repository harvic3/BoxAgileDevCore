using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace BoxAgileDev.Result
{
    [DataContract]
    public class Result : IBaseResult
    {
        /// <summary>
        /// Property for management the status transaction. Default is error code 500
        /// </summary>
        [DataMember(Name = "statusCode")]
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.InternalServerError;

        /// <summary>
        /// Property for set message about transaction
        /// </summary>
        [DataMember(Name = "messages")]
        public List<string> Messages { get; private set; }

        /// <summary>
        /// Property for set success the transaction
        /// </summary>
        [DataMember(Name = "success")]
        public bool Success { get; private set; }

        /// <summary>
        /// Methos for add mmesage about transaction proccess
        /// </summary>
        /// <param name="message">Message to add</param>
        public void AddMessage(string message)
        {
            if (this.Messages == null)
            {
                this.Messages = new List<string>();
            }

            this.Messages.Add(message);
        }       

        /// <summary>
        /// Method for set the status for the current transaction
        /// </summary>
        /// <param name="statusCode">Http status code of transaction</param>
        public void SetStatusCode(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Set successful the transaction and set status code to 200 (OK)
        /// </summary>
        public void Successful()
        {
            this.Success = true;
            this.StatusCode = HttpStatusCode.OK;
        }

        /// <summary>
        /// Method for set the error message and statusCode for the current transaction
        /// </summary>
        /// <param name="errorMessage">Error message of transaction</param>
        /// <param name="statusCode">Status code for transaction</param>
        public void SetError(string errorMessage, HttpStatusCode statusCode)
        {
            this.Success = false;
            this.AddMessage(errorMessage);
            this.StatusCode = statusCode;
        }
    }
}
