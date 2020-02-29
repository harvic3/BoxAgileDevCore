using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace BoxAgileDev.Mapping
{
    /// <summary>
    /// Class for mapping and emulate objects.
    /// </summary>
    public static class SimpleMapper
    {
        /// <summary>
        /// Function to map a object to other similar object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin">Object of origin data.</param>
        /// <param name="dest">Object to destination data.</param>
        /// <returns></returns>
        public static T Map<T>(object origin, T dest)
            where T : new()
        {
            if (origin == null)
            {
                return default(T);
            }

            PropertyInfo[] destProperties = dest.GetType().GetProperties();

            if (MapWithDataContract(origin, dest))
            {
                var originAttributes = origin.GetType().GetCustomAttributes(typeof(DataMemberAttribute), true);

                foreach (PropertyInfo prop in destProperties)
                {
                    PropertyInfo value = originAttributes.GetType().GetProperty(prop.Name);
                    MapValue(origin, dest, prop, value);
                }
            }
            else
            {
                Type originProperties = origin.GetType();

                foreach (PropertyInfo prop in destProperties)
                {
                    PropertyInfo value = originProperties.GetProperty(prop.Name);

                    MapValue(origin, dest, prop, value);
                }
            }

            return dest;
        }

        private static void MapValue<T>(object origin, T dest, PropertyInfo prop, PropertyInfo value) where T : new()
        {
            if (value != null)
            {
                if (prop.PropertyType.IsPrimitive || prop.PropertyType.Name == "Decimal" || prop.PropertyType.Name == "String" || prop.PropertyType.Name == "DateTime")
                {
                    prop.SetValue(dest, value.GetValue(origin, null), null);
                }
                else
                {
                    var originInt = value.GetValue(origin, null);
                    prop.SetValue(dest, Map(originInt, Activator.CreateInstance(originInt.GetType())));
                }
            }
        }

        private static bool MapWithDataContract(object origin, object destination)
        {
            return origin.GetType().GetCustomAttributes(typeof(DataMemberAttribute), true).Any() &&
                destination.GetType().GetCustomAttributes(typeof(DataMemberAttribute), true).Any();
        }

        /// <summary>
        /// FUnction to map the properties a type object to other similar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static T Map<T>(object origin) where T : new()
        {
            T dest = Activator.CreateInstance<T>();
            return Map<T>(origin, dest);
        }

        /// <summary>
        /// Function for map a collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object to be converted.</typeparam>
        /// <param name="Data">List of object to map.</param>
        /// <returns></returns>
        public static List<T> MapCollection<T>(dynamic Data) where T : new()
        {
            List<T> results = new List<T>();
            foreach (var item in Data)
            {
                results.Add(Map<T>(item));
            }
            return results;
        }

        /// <summary>
        /// Function for emulate a List of a type object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v"></param>
        /// <returns></returns>
        public static List<T> Emulate<T>(int v)
        {
            List<T> lista = new List<T>();
            for (int i = 0; i < v; i++)
            {
                T newItem = Activator.CreateInstance<T>();
                lista.Add(newItem);
            }
            return lista;
        }

    }
}
