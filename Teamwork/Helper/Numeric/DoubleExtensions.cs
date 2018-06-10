// ==========================================================
// File: Coority.Extensions.DoubleExtensions.cs
// Created: 16.12.2014
// Created By: Tim cadenbach
// 
// Copyright (C) 2014 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

namespace Teamwork.Extensions.Numeric
{
  public static class DoubleExtensions
  {
    #region PercentageOf calculations

    public static decimal PercentageOf(this double number, int percent)
    {
      return (decimal)(number * percent / 100);
    }

    public static decimal PercentageOf(this double number, float percent)
    {
      return (decimal)(number * percent / 100);
    }

    public static decimal PercentageOf(this double number, double percent)
    {
      return (decimal)(number * percent / 100);
    }

    public static decimal PercentageOf(this double number, long percent)
    {
      return (decimal)(number * percent / 100);
    }

    public static decimal PercentOf(this double position, int total)
    {
      decimal result = 0;
      if (position > 0 && total > 0)
        result = (decimal)((decimal)position / (decimal)total * 100);
      return result;
    }

    public static decimal PercentOf(this double position, float total)
    {
      decimal result = 0;
      if (position > 0 && total > 0)
        result = (decimal)((decimal)position / (decimal)total * 100);
      return result;
    }

    public static decimal PercentOf(this double position, double total)
    {
      decimal result = 0;
      if (position > 0 && total > 0)
        result = (decimal)((decimal)position / (decimal)total * 100);
      return result;
    }

    public static decimal PercentOf(this double position, long total)
    {
      decimal result = 0;
      if (position > 0 && total > 0)
        result = (decimal)((decimal)position / (decimal)total * 100);
      return result;
    }

    #endregion
  }
}
