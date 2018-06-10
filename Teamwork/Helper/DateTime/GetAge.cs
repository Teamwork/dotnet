using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Extensions.DateTime
{
  public static partial class DateTimeExtensions
  {
    /// <summary>
    /// Return Age in Years for a given Birthdate
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <returns></returns>
    static public int Age(this System.DateTime dateOfBirth)
    {
      if (System.DateTime.Today.Month < dateOfBirth.Month ||
      System.DateTime.Today.Month == dateOfBirth.Month &&
       System.DateTime.Today.Day < dateOfBirth.Day)
      {
        return System.DateTime.Today.Year - dateOfBirth.Year - 1;
      }
      else
        return System.DateTime.Today.Year - dateOfBirth.Year;
    }
  }
}
