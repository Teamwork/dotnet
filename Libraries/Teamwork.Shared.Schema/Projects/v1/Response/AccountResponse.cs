using Newtonsoft.Json;
using Teamwork.Shared.Schema.Projects.V1;

namespace Teamwork.Shared.Schema.Projects.V1.Response
{
  public class AccountResponse
  {

    [JsonProperty("STATUS")]
    public string Status { get; set; }

    [JsonProperty("account")]
    public Account Account { get; set; }
  }
}