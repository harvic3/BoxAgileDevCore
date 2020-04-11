using System.Net;
using System.Runtime.Serialization;

namespace BoxAgileDev.Result.Generic
{
    [DataContract]
    public class Result<T> : Result, IBaseResult<T>
    {
        /// <summary>
        /// Property for data of transaction
        /// </summary>
        [DataMember(Name = "result")]
        public T Data { get; private set; }

        /// <summary>
        /// Method for set data of transaction
        /// </summary>
        /// <param name="data">Result data for transaction</param>
        public void SetData(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Method for set a succesful transaction
        /// </summary>
        /// <param name="data">Result data for transaction</param>
        /// <param name="statusCode">StatusCode of transaction</param>
        public void Successful(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            this.Successful();
            this.Data = data;
            this.SetStatusCode(statusCode);
        }

        /// <summary>
        /// Method for set a succesful transaction
        /// </summary>
        /// <param name="message">Message for transaction</param>
        /// <param name="statusCode">StatusCode of transaction</param>
        public void Successful(string message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            this.Successful();
            this.AddMessage(message);
            this.SetStatusCode(statusCode);
        }

        /// <summary>
        /// Method for set a succesful transaction
        /// </summary>
        /// <param name="data">Result data for transaction</param>
        /// <param name="message">Message for transaction</param>
        /// <param name="statusCode">StatusCode of transaction</param>
        public void Successful(T data, string message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            this.Successful();
            this.Data = data;
            this.AddMessage(message);
            this.SetStatusCode(statusCode);
        }
    }
}
