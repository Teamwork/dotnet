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
    /// Returns true if two dates intersect
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="intersectingStartDate"></param>
    /// <param name="intersectingEndDate"></param>
    /// <returns></returns>
    public static bool Intersects(this System.DateTime startDate, System.DateTime endDate, System.DateTime intersectingStartDate, System.DateTime intersectingEndDate)
    {
      return (intersectingEndDate >= startDate && intersectingStartDate <= endDate);
    }
  }
}
