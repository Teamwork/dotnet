using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork;
using Teamwork.Model.Projects.V1;

namespace Teamwork.Response
{
  public class CompanyResponse
  {
    [JsonProperty("company")]
    public Company Company { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }
}
