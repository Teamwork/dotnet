using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork;

namespace Teamwork.Base.Response
{
 public class PostResponse
  {
    [JsonProperty("post")]
    public Post Post { get; set; }

    [JsonProperty("STATUS")]
    public string Status { get; set; }
  }

 public class PostsResponse
 {
   [JsonProperty("posts")]
   public Post[] Post { get; set; }

   [JsonProperty("STATUS")]
   public string Status { get; set; }
 }

}
