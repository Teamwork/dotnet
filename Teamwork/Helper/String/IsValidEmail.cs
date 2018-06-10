// ==========================================================
// File: Coority.Extensions.IsValidEmail.cs
// Created: 15.12.2014
// Created By: Tim cadenbach
// 
// Copyright (C) 2014 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================
using System.Text.RegularExpressions;

namespace TeamworkProjects.Extensions.String
{
  public static partial class StringExtensions
  {
    public static bool IsValidEmail(this string text)
    {
      const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

      var regex = new Regex(pattern, RegexOptions.IgnoreCase);
      return regex.IsMatch(text);
    }
  }
}
