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
using Teamwork;
using Teamwork.Shared.Schema.Projects.V1;


#endregion

namespace TeamWork.Handler
{
    public class ReactionHandler
    {
        private readonly Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public ReactionHandler(Client pClient)
        {
            client = pClient;
        }

        /// <summary>
        /// Like an item
        /// </summary>
        /// <param name="resource">Resources such as: Message Replies, FileVersions, Comments</param>
        /// <param name="resourceid">The id of the resource</param>
        /// <returns></returns>
		public async Task LikeItem(string resource, int resourceid)
		{
			try {
			    var requestString = $"{resource}/{resourceid}/like.json";
				var data = await client.HttpClient.PutAsync(requestString, null);
				throw new Exception("Error processing Teamwork API Request: ", new Exception(data.ReasonPhrase));
			}
			catch (Exception ex)
			{
				throw new Exception("Error processing Teamwork API Request: ", ex);
			}
		}

        /// <summary>
        /// Like an item
        /// </summary>
        /// <param name="resource">Resources such as: Message Replies, FileVersions, Comments</param>
        /// <param name="resourceid">The id of the resource</param>
        /// <returns></returns>
        public async Task UnLikeItem(string resource, int resourceid)
        {
            try
            {
                var requestString = $"{resource}/{resourceid}/unlike.json";
                var data = await client.HttpClient.PutAsync(requestString, null);
                throw new Exception("Error processing Teamwork API Request: ", new Exception(data.ReasonPhrase));
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }




        




    }
}