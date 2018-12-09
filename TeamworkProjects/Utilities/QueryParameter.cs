using System;
using System.Collections.Generic;

namespace TeamworkProjects.Utilities
{
    /// <summary>
    ///     Provides an structure to hold the query parameters
    /// </summary>
    public class QueryParameter : IComparable<QueryParameter>, IComparable
    {
        public static IComparer<QueryParameter> defaultComparer = new QueryParameterComparer();

        public QueryParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; internal set; }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return ReferenceEquals(this, null) ? 0 : 1;

            var other = obj as QueryParameter;
            return CompareTo(other);
        }

        public int CompareTo(QueryParameter other)
        {
            return defaultComparer.Compare(this, other);
        }
    }

    /// <summary>
    /// Comparer class used to perform the sorting of the query parameters
    /// </summary>
    public class QueryParameterComparer : IComparer<QueryParameter>
    {
        public int Compare(QueryParameter x, QueryParameter y)
        {
            return x.Name.Equals(y.Name) ? string.CompareOrdinal(x.Value, y.Value) : string.CompareOrdinal(x.Name, y.Name);
        }
    }
}