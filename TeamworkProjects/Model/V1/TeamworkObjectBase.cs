using Newtonsoft.Json;


namespace Teamwork.Model.Projects.V1
{
  public class TeamworkObjectBase
  {
   [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
   public string id { get; set; }


    // --- Public properties --- 

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string description { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }


    // --- Ignored by Serialization ---
      [JsonIgnore]
      public int Id
        {
          get
          {
              int num = 0;
              if (int.TryParse(id, out num)) return num;
              return -1;
          }
        }
  }
}