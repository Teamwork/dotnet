using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork;

namespace TeamworkProjects.Base.Response
{
  public class UserResponse
  {

    [JsonProperty("accounts")]
    public List<UserEntry> Entries { get; set; }
    public string STATUS { get; set; }
  }
}
