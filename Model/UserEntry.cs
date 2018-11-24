using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
    public class UserEntry
    {

        public bool IsDeprecated { get; set; } = true;

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("requirehttps")]
        public string requirehttps { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("firstname")]
        public string firstname { get; set; }

        [JsonProperty("companyname")]
        public string companyname { get; set; }
        [JsonProperty("api-key")]
        public string ApiKey { get; set; }
        [JsonProperty("user-in-owner-company")]
        public string isInOwnerCompany { get; set; }
        [JsonProperty("ssl-enabled")]
        public string isSslEnabled { get; set; }
        [JsonProperty("projectsEnabled")]
        public string isProjectsEnabled { get; set; }
        [JsonProperty("chatEnabled")]
        public string isChatEnabled { get; set; }
        [JsonProperty("chat-enabled")]
        public string isUserChatEnabled { get; set; }
        [JsonProperty("deskEnabled")]
        public string isDeskEnabled { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }


        public string logo { get; set; }

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
        public string UserCompanyName {
            get { return companyname; }
            set { companyname = value; } }
    }

}