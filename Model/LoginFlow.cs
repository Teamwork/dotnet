using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects.Model
{
    using Newtonsoft.Json;

    public class MeResponse
    {
        [JsonProperty("person", NullValueHandling = NullValueHandling.Ignore)]
        public Person Person { get; set; }

        [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }


    public class Integrations
    {
        [JsonProperty("idonethis", NullValueHandling = NullValueHandling.Ignore)]
        public Idonethis Idonethis { get; set; }

        [JsonProperty("microsoftConnector", NullValueHandling = NullValueHandling.Ignore)]
        public Idonethis MicrosoftConnector { get; set; }
    }

    public class Idonethis
    {
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; }
    }

    public class PhoneNumberMobileParts
    {

    }


    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("installation")]
        public Installation Installation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Installation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("apiEndPoint")]
        public string ApiEndPoint { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("chatEnabled")]
        public bool ChatEnabled { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }


}
