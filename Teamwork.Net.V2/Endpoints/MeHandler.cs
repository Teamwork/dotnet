using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.HTTPClient;
using TeamworkProjects.Model;

namespace TeamworkProjects.Endpoints
{
    public class MeHandler
    {
        private readonly Client client;
        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public MeHandler(Client pClient)
        {
            this.client = pClient;
        }

        public async Task<bool> AddNewStatusMessage(UserStatus pStatus, int pErsonid = -1)
        {
           var request = "/me/status.json";
           string post = JsonConvert.SerializeObject(pStatus);
           var result = await client.HttpClient.PostWithReturnAsync(request, new StringContent("{\"userstatus\": " + post + "}", Encoding.UTF8));
           if (result.StatusCode == HttpStatusCode.Created || result.StatusCode == HttpStatusCode.OK) return true;
           return false;
        }
    }
}
