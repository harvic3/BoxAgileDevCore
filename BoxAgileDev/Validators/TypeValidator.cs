using BoxAgileDev.Result.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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

            if (Int32.TryParse(expected, out int value))
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

            if (Double.TryParse(expected, out double value))
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

            if (Decimal.TryParse(expected, out decimal value))
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

            if (Boolean.TryParse(expected, out bool value))
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

            if (Int64.TryParse(expected, out long value))
            {
                result.SetData(value);
                result.Successful();
            }

            return result;

        }
        
        /// <summary>
        /// Method for validate a email address
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(email,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for validate a IP address V4 or V6
        /// </summary>
        /// <param name="ip">Value in string of ip address</param>
        /// <returns></returns>
        public static bool IsValidIPAddess(string ip)
        {
            if (String.IsNullOrEmpty(ip))
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                if (ip.Split('.').Count() == 4)
                {
                    return Regex.IsMatch(ip,
                      @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",
                      RegexOptions.IgnoreCase);
                }
                else if (ip.Split(':').Count() == 8)
                {
                    return Regex.IsMatch(ip,
                      @"(?:^|(?<=\s))(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))(?=\s|$)",
                      RegexOptions.IgnoreCase);
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            return false;
        }
        
    }
}
