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
using Teamwork.Client;
using TeamworkProjects;
using TeamworkProjects.HTTPClient;
using Teamwork.Shared.Schema.Projects.V1;
using TeamworkProjects.Response;

#endregion

namespace Teamwork.Projects.Handler
{

	public class ChatMessage
	{
		public string body { get; set; }
	}


	public class ChatHandler
    {
        private readonly Client.Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public ChatHandler(Client.Client pClient)
        {
            client = pClient;
        }


        public async Task<bool> SendMessage(string Body, string roomID)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
								
                string post = JsonConvert.SerializeObject(new ChatMessage() { body = Body });
                var response =
                    await
                        client.PostAsync($"/chat/v3/rooms/{roomID}/messages.json",
                            new StringContent("{\"message\":" + post + "}", Encoding.UTF8,"application/json"));
            }
            return false;
        }


    }
}