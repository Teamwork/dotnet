// ==========================================================
// File: Coority.Extensions.ObservableCollection.cs
// Created: 15.12.2014
// Created By: Tim cadenbach
// 
// Copyright (C) 2014 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Extensions.Collections
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
