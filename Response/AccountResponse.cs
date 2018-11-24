using Newtonsoft.Json;
using TeamworkProjects.Model;

namespace TeamworkProjects.Response
{
  public class AccountResponse
  {

    [JsonProperty("STATUS")]
    public string Status { get; set; }

    [JsonProperty("account")]
    public Account Account { get; set; }
  }
}