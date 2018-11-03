using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teamwork.Shared.Schema.Projects.V1
{
  public class ErrorResponse
  {
    [JsonProperty(PropertyName = "MESSAGE", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }
    [JsonProperty(PropertyName = "STATUS", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }
  }
}
