using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Shared.Common.Helper.String
{
  public static partial class StringExtensions
  {
    /// <summary>
    /// Formats the string according to the specified mask
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="mask">The mask for formatting. Like "A##-##-T-###Z"</param>
    /// <returns>The formatted string</returns>
    public static string FormatWithMask(this string input, string mask)
    {

      if(string.IsNullOrEmpty(input)) return input;
      var output = string.Empty;
      var index = 0;
      foreach (var m in mask)
      {
        if (m == '#')
        {
          if (index < input.Length)
          {
            output += input[index];
            index++;
          }
        }
        else
          output += m;
      }
      return output;
    }
  }
}
