using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork;
using Teamwork.Schema.Projects.V1;
using Teamwork.Shared.Common.Generic;
using Teamwork.Shared.Schema.Projects.V1;


namespace Teamwork.Handler
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

        public async Task<bool> AddNewStatusMessage(UserStatus2 pStatus, int pErsonid = -1)
        {
           var request = "/me/status.json";
           string post = JsonConvert.SerializeObject(pStatus);
           var result = await client.HttpClient.PostWithReturnAsync(request, new StringContent("{\"userstatus\": " + post + "}", Encoding.UTF8));
           if (result.StatusCode == HttpStatusCode.Created || result.StatusCode == HttpStatusCode.OK) return true;
           return false;
        }


        public async Task<bool> Clockin()
        {
            var request = "/me/clockin.json";
            string post = string.Empty;
            var result = await client.HttpClient.PostAsync(request, new StringContent("{\"info\": \"\""+ "}", Encoding.UTF8));
            if (result.StatusCode == HttpStatusCode.Created || result.StatusCode == HttpStatusCode.OK) return true;
            return false;
        }

        public async Task<bool> ClockOut()
        {
            var request = "/me/clockout.json";
            string post = string.Empty;
            var result = await client.HttpClient.PostAsync(request, new StringContent("{\"info\": \"\"" + "}", Encoding.UTF8));
            if (result.StatusCode == HttpStatusCode.Created || result.StatusCode == HttpStatusCode.OK) return true;
            return false;
        }


        public async Task<Person> GetMyDetails()
        {
            var request = "/me.json";
            var result = await client.HttpClient.GetAsync<Person>(request,"person",null,RequestFormat.Json);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return result.Data;
            }
            return null;
        }


        public async Task<Account> GetAccountDetails()
        {

						try
						{
							var request = "/account.json";
							var result = await client.HttpClient.GetAsync<Account>(request, "account", null, RequestFormat.Json);
							if (result.StatusCode == HttpStatusCode.OK)
							{
								return result.Data;
							}
							return null;
						}
						catch(Exception ex)
									{
							return null;
						}
        }
    }
}
