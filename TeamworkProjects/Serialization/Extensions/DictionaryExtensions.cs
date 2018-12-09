using System;
using System.Collections.Generic;

namespace TeamworkProjects.Serialization.Extensions
{
    public static class DictionaryExtensions
    {
        public static DateTime GetValue(this IDictionary<string, object> dictionary, string key, DateTime defaultValue)
        {
            var value = dictionary.GetValue(key, String.Empty);
            return value.GetDate(defaultValue);
        }

        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary.GetValue(key, default(T));
        }

        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key, T defaultValue)
        {
            object value;

            if (dictionary.TryGetValue(key, out value) && value != null)
                return (T)value;

            return defaultValue;
        }

        public static ulong GetULong(this IDictionary<string, object> dictionary, string key)
        {
            object value;
            return dictionary.TryGetValue(key, out value) ? (ulong) (int) value : 0UL;
        }

    }
}
