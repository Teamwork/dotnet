#region FileHeader

// ==========================================================
// File:            TeamworkProjects.CategoryHandler.cs
// Last Mod:        19.07.2016
// Created:         19.07.2016
// Created By:      Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  19.07.2016 - Created
//  ==========================================================

#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects;
using TeamworkProjects.HTTPClient;
using Teamwork.Shared.Schema.Projects.V1;
using TeamworkProjects.Response;

#endregion

namespace Teamwork.Projects.Handler
{
    public class PeopleHandler
    {
        private readonly Client.Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public PeopleHandler(Client.Client pClient)
        {
            client = pClient;
        }


		public async Task<List<UserStatus>> GetPeopleStatusAsync()
		{
			try
			{
				var requestString = "people/status.json";
				var data = await client.HttpClient.GetListAsync<UserStatus>(requestString, "userStatuses", null);
				if (data.StatusCode == HttpStatusCode.OK)
				{

					var pages = int.Parse(data.Headers.GetValues("X-Pages").First());
					var Page = int.Parse(data.Headers.GetValues("X-Page").First());
					var total = int.Parse(data.Headers.GetValues("X-Records").First());
					return data.List;
				}

				throw new Exception("Error processing Teamwork API Request: ", new Exception(data.Message));
			}
			catch (Exception ex)
			{
				throw new Exception("Error processing Teamwork API Request: ", ex);
			}
		}


		public async Task<List<Person>> GetPeopleAsync()
        {
            try
            {
                var requestString = "people.json";
                var data = await client.HttpClient.GetListAsync<Person>(requestString, "people", null);
                if (data.StatusCode == HttpStatusCode.OK)
                {

                    var pages = int.Parse(data.Headers.GetValues("X-Pages").First());
                    var Page = int.Parse(data.Headers.GetValues("X-Page").First());
                    var total = int.Parse(data.Headers.GetValues("X-Records").First());
                    return data.List;
                }

                throw new Exception("Error processing Teamwork API Request: ", new Exception(data.Message));
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }

        public async Task<int> AddPerson(PersonAdd personData)
        {
            try
            {
                var requestString = "people.json";
                string postdata = JsonConvert.SerializeObject(personData);
                var data = await client.HttpClient.PostWithReturnAsync(requestString, new StringContent("{\"person\": " + postdata + "}", Encoding.UTF8));

                if (data.StatusCode == HttpStatusCode.Created || data.StatusCode == HttpStatusCode.OK) return int.Parse(((string[])(data.Headers.GetValues("id")))[0]);

                return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }

        public async Task<Person> GetPersonByMailAsync(string email)
        {
            try
            {
                var requestString = "people.json?emailaddress=" + email;
                var data = await client.HttpClient.GetListAsync<Person>(requestString, "people", null);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    return data.List.FirstOrDefault();
                }

                throw new Exception("Error processing Teamwork API Request: ", new Exception(data.Message));
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }


    }
}