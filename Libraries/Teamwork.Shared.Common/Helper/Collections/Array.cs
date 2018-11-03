using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Shared.Common.Helper.Collections
{
  public static class ArrayExtensions
  {
    /// <summary>
    /// Convert any Array to a generic List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <param name="mapFunction"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(this Array items, Func<object, T> mapFunction)
    {
      if (items == null || mapFunction == null) return new List<T>();
      return items.Cast<object>().Select((t, i) => mapFunction(items.GetValue(i))).Where(val => val != null).ToList();
    }

  }
}
