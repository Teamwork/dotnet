using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
  class ErrorResponse
  {
    [JsonProperty(PropertyName = "MESSAGE", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }
    [JsonProperty(PropertyName = "STATUS", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }
  }
}
