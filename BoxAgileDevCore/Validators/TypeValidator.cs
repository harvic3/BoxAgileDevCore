using BoxAgileDevCore.Result.Generic;
using System;

namespace BoxAgileDevCore.Validators
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
            BaseResult<int> result = new BaseResult<int>();

            if (int.TryParse(expected, out int value))
            {
                result.SetResult(value);
                result.SetSuccess();
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
            BaseResult<DateTime> result = new BaseResult<DateTime>();

            if (DateTime.TryParse(expected, out DateTime value))
            {
                result.SetResult(value);
                result.SetSuccess();
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
            BaseResult<double> result = new BaseResult<double>();

            if (double.TryParse(expected, out double value))
            {
                result.SetResult(value);
                result.SetSuccess();
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
            BaseResult<decimal> result = new BaseResult<decimal>();

            if (decimal.TryParse(expected, out decimal value))
            {
                result.SetResult(value);
                result.SetSuccess();
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
            BaseResult<bool> result = new BaseResult<bool>();

            if (bool.TryParse(expected, out bool value))
            {
                result.SetResult(value);
                result.SetSuccess();
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
            BaseResult<long> result = new BaseResult<long>();

            if (long.TryParse(expected, out long value))
            {
                result.SetResult(value);
                result.SetSuccess();
            }

            return result;
        }
    }
}
