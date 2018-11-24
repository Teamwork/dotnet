// ==========================================================
// File: Coority.Extensions.FloatExtension.cs
// Created: 16.12.2014
// Created By: Tim cadenbach
// 
// Copyright (C) 2014 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

namespace TeamworkProjects.Extensions.Numeric
{
  public static class FloatExtensions
  {
    #region PercentageOf calculations

    /// <summary>
    /// Toes the percent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="percentOf">The percent of.</param>
    /// <returns></returns>
    public static decimal PercentageOf(this float value, int percentOf)
    {
      return (decimal)(value / percentOf * 100);
    }
    /// <summary>
    /// Toes the percent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="percentOf">The percent of.</param>
    /// <returns></returns>
    public static decimal PercentageOf(this float value, float percentOf)
    {
      return (decimal)(value / percentOf * 100);
    }
    /// <summary>
    /// Toes the percent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="percentOf">The percent of.</param>
    /// <returns></returns>
    public static decimal PercentageOf(this float value, double percentOf)
    {
      return (decimal)(value / percentOf * 100);
    }
    /// <summary>
    /// Toes the percent.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="percentOf">The percent of.</param>
    /// <returns></returns>
    public static decimal PercentageOf(this float value, long percentOf)
    {
      return (decimal)(value / percentOf * 100);
    }

    #endregion
  }
}
