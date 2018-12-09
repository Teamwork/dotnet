using Newtonsoft.Json;

namespace TeamworkProjects.Model.V1
{
  public class ErrorResponse
  {
    [JsonProperty(PropertyName = "MESSAGE", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }
    [JsonProperty(PropertyName = "STATUS", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }
  }
}
