﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Shared.Common.Helper.Collections
{
  public static class GroupingExtensions
  {

    /// <summary>
    /// Converts an enumeration of groupings into a Dictionary of those groupings.
    /// </summary>
    /// <typeparam name="TKey">Key type of the grouping and dictionary.</typeparam>
    /// <typeparam name="TValue">Element type of the grouping and dictionary list.</typeparam>
    /// <param name="groupings">The enumeration of groupings from a GroupBy() clause.</param>
    /// <returns>A dictionary of groupings such that the key of the dictionary is TKey type and the value is List of TValue type.</returns>
    public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
    {
      return groupings.ToDictionary(group => group.Key, group => group.ToList());
    }


  }
}
