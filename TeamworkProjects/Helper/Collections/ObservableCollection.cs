using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TeamworkProjects.Helper.Collections
{
  public static class ObservableCollectionExtension
  {
    /// <summary>
    /// Add a collection to an Observable Collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="oc"></param>
    /// <param name="collection"></param>
    public static void AddRange<T>(this ObservableCollection<T> oc, IEnumerable<T> collection)
    {
      if (collection == null)
      {
        throw new ArgumentNullException("collection");
      }
      foreach (var item in collection)
      {
        oc.Add(item);
      }


    }
  }
}
