using BoxAgileDev.Result.Generic;
using System;

namespace BoxAgileDev.Validators
{
    public static class TypeValidator
    {
        /// <summary>
        /// Method for try to convert a string to int
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static IBaseResult<int> GetValidInt(string expected)
        {
            Result<int> result = new Result<int>();

            if (int.TryParse(expected, out int value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;
        }

        /// <summary>
        /// Method for try to convert a string to DateTime
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static IBaseResult<DateTime> GetValidDateTime(string expected)
        {
            Result<DateTime> result = new Result<DateTime>();

            if (DateTime.TryParse(expected, out DateTime value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;
        }

        /// <summary>
        /// Method for try to convert a string to double
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static IBaseResult<double> GetValidDouble(string expected)
        {
            Result<double> result = new Result<double>();

            if (double.TryParse(expected, out double value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;
        }

        /// <summary>
        /// Method for try to convert a string to decimal
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static IBaseResult<decimal> GetValidDecimal(string expected)
        {
            Result<decimal> result = new Result<decimal>();

            if (decimal.TryParse(expected, out decimal value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;
        }

        /// <summary>
        /// Method for try to convert a string to boolean
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static IBaseResult<bool> GetValidBoolean(string expected)
        {
            Result<bool> result = new Result<bool>();

            if (bool.TryParse(expected, out bool value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;
        }

        /// <summary>
        /// Method for try to convert a string to long
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static IBaseResult<long> GetValidLong(string expected)
        {
            Result<long> result = new Result<long>();

            if (long.TryParse(expected, out long value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;
        }
    }
}
