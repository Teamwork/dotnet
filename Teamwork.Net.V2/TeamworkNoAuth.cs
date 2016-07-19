#region FileHeader
// ==========================================================
// File: TeamworkProjects.Base.TeamWorkHTTPRequest.cs
// Last Mod:      23.05.2016
// Created:        23.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  23.05.2016 - Created
//  ==========================================================
#endregion

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Teamwork.Net;
using TeamworkProjects.Base.Response;
using TeamworkProjects.HTTPClient;
using TeamworkProjects.Model;

namespace TeamworkProjects
{
    /// <summary>
    /// Main entry point for the API
    /// </summary>
    public class TeamworkNoAuth
    {
        private AuthorizedHttpClient Client { get; set; }

        /// <summary>
        /// Returns a new instance of the Teamwork API Client
        /// </summary>
        /// <returns></returns>
        public static TeamworkNoAuth GetTeamworkClient()
        {
            try
            {
                return new TeamworkNoAuth { Client = new AuthorizedHttpClient(string.Empty, new Uri(""))};
            }
            catch (Exception ex)
            {
               ErrorHandler.ThrowGenericTeamworkError(ex);
               return null;
            }
        }

        /// <summary>
        /// Returns authentication details and infos of the current user
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntry>> GetAuthenticationtDetails(string pUserName, string pAssword)
        {
            using (var webclient = new AuthorizedHttpClient("", new Uri("https://authenticate.teamwork.com/")))
            {
                var data = await webclient.GetListAsync<UserEntry>(@"accounts/search.json?email=" + pUserName + "&password=" + pAssword,"accounts", null);
                if (data.StatusCode == HttpStatusCode.OK) return data.List;
                throw new Exception(data.Status + " " + data.Message);
            }
        }
    }
}
