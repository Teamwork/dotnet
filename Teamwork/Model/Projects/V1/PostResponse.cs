using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teamwork.Model.Projects.V1
{
  public class PostResponse
  {
      [JsonProperty(PropertyName = "MESSAGE")]
      public string Message { get; set; }
      [JsonProperty(PropertyName = "id")]
      public int id { get; set; }
      [JsonProperty(PropertyName = "STATUS")]
      public string status { get; set; }
  }
}
