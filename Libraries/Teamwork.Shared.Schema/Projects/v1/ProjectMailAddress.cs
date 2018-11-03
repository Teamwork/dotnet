using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teamwork.Shared.Schema.Projects.V1
{
    public class Address
    {

      [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
      public string Tasks { get; set; }

      [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
      public string Messages { get; set; }

      [JsonProperty("notebooks", NullValueHandling = NullValueHandling.Ignore)]
      public string Notebooks { get; set; }

      [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
      public string Files { get; set; }

      [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
      public string Links { get; set; }
    }

    public class Emailaddress
    {

      [JsonProperty("addresses", NullValueHandling = NullValueHandling.Ignore)]
      public Address[] Addresses { get; set; }

      [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
      public string Code { get; set; }
    }

    public class ProjectMailResponse
    {

      [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
      public string STATUS { get; set; }

      [JsonProperty("emailaddress", NullValueHandling = NullValueHandling.Ignore)]
      public Emailaddress Emailaddress { get; set; }
    }

  }

