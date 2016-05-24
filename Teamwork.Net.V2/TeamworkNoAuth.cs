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
using Teamwork.Net;
using TeamworkProjects.HTTPClient;

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
                var newTeamworkClient = new TeamworkNoAuth { Client = new AuthorizedHttpClient(string.Empty, new Uri(""))};
                
                return null;
            }
            catch (Exception ex)
            {
               ErrorHandler.ThrowGenericTeamworkError(ex);
               return null;
            }
        }





    }
}
