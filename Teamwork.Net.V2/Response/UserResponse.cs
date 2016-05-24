using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamworkProjects.Base.Response
{
  public class UserResponse
  {

    [JsonProperty("accounts")]
    public List<UserEntry> Entries { get; set; }
    public string STATUS { get; set; }
  }

  public class UserEntry
  {
    [JsonProperty("accounts")]
    public int ID { get; set; }
    [JsonProperty("accounts")]
    public string requirehttps { get; set; }
    [JsonProperty("accounts")]
    public string name { get; set; }
    [JsonProperty("accounts")]
    public string companyname { get; set; }
    [JsonProperty("api-key")]
    public string ApiKey { get; set; }
    [JsonProperty("user-in-owner-company")]
    public bool isInOwnerCompany { get; set; }
    [JsonProperty("ssl-enabled")]
    public bool isSslEnabled { get; set; }
    [JsonProperty("projectsEnabled")]
    public bool isProjectsEnabled { get; set; }
    [JsonProperty("chatEnabled")]
    public bool isChatEnabled { get; set; }
    [JsonProperty("chat-enabled")]
    public bool isUserChatEnabled { get; set; }
    [JsonProperty("deskEnabled")]
    public bool isDeskEnabled { get; set; }
    [JsonProperty("url")]
    public string url { get; set; }
    [JsonProperty("domain")]
    public string domain { get; set; }
    [JsonProperty("companyid")]
    public int companyid { get; set; }
    [JsonProperty("code")]
    public string code { get; set; }
    [JsonProperty("userid")]
    public int userid { get; set; }
    [JsonProperty("lastname")]
    public string lastname { get; set; }
    [JsonProperty("user-company-name")]
    public string UserCompanyName { get; set; } 
  }

}
