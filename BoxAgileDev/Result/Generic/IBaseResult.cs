namespace BoxAgileDev.Result.Generic
{
    public interface IBaseResult<T>: IBaseResult
    {
        T Data { get;  }

        void SetData(T data);
    }
}
