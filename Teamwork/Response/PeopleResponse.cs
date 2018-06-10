using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork;

namespace Teamwork.Response
{
  public class PeopleResponse
  {
    [JsonProperty("people")]
    public List<Person> People { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }

    [JsonIgnore]
    public int TotalRecords { get; set; }
    [JsonIgnore]
    public int Pages { get; set; }
    [JsonIgnore]
    public int Page { get; set; }
  }

  public class PersonResponse
  {
    [JsonProperty("person")]
    public Person Person { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }


  }

}
