using Newtonsoft.Json;

namespace BoxAgileDev.Controller.Utils
{
    /// <summary>
    /// Class for convert data in JSon to other object Type.
    /// </summary>
    public class JsonUtils
    {
        /// <summary>
        /// Method for convert dynamic object to another object
        /// </summary>
        /// <typeparam name="T">Generic type to return</typeparam>
        /// <param name="data">Object y Json</param>
        /// <returns></returns>
        public T DeserializeObject<T>(dynamic data)
        {
            if (data != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                return JsonConvert.DeserializeObject<T>(data.ToString(), settings);
            }
            return default(T);
        }

        /// <summary>
        /// Method for serialize object
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns></returns>
        public string SerializeObject(object obj)
        {
            string result = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.Default,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                FloatFormatHandling = FloatFormatHandling.DefaultValue,
                Formatting = Formatting.Indented
            });

            return result;
        }
    }
}
