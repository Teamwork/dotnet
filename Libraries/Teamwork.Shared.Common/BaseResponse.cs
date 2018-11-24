using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Teamwork.Shared.Common.Response
{
    public class BaseResponse
    {
        [JsonProperty("STATUS")]
        public string Status { get; set; }
        /// <summary>
        /// Gets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        public HttpHeaders Headers { get; set; }

        [JsonProperty("MESSAGE",NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
