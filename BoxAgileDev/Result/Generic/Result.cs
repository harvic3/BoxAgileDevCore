using System;
using System.Runtime.Serialization;

namespace BoxAgileDev.Result.Generic
{
    [DataContract]
    public class Result<T>: Result, IBaseResult<T>
    {
        /// <summary>
        /// Property for data of transaction
        /// </summary>
        [DataMember(Name = "result")]
        public T Data { get; private set; }

        /// <summary>
        /// Method for set data of transaction
        /// </summary>
        /// <param name="data"></param>
        public void SetData(T data)
        {
            this.Data = data;
        }
    }
}
