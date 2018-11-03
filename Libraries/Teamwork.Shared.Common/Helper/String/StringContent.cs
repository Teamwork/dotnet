using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Shared.Common.Helper.String
{
  public class JsonContent : StringContent
  {
    private string ObjectName;
    public JsonContent(string objectName, string content, Encoding encoding)
      : base(content, encoding)
    {
      ObjectName = objectName;
    }

    public override string ToString()
    {
      return "{" + ObjectName + ":" + base.ToString() + "}";
    }
  }
}
