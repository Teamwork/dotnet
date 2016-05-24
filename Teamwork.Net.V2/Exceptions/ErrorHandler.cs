using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Teamwork.Net
{
    public static class ErrorHandler
    {
        public static void ThrowGenericTeamworkError(Exception ex)
        {
            throw (ex);
        }
    }
}
