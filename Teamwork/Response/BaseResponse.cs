using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamworks.Generic;

namespace Teamwork.Response
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
