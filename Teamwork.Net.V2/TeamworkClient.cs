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
    public partial class Client
    {
        public AuthorizedHttpClient httpClient { get; set; }
        public string ApiKey { get; set; }
        public Uri Domain { get; set; }

        public Client()
        {
            throw new NotSupportedException("Only init the Client using GetTeamworkClient");
        }

        public Client(Uri pDomain, string pAPIKey)
        {
            try
            {
                ApiKey = pAPIKey;
                Domain = pDomain;
                httpClient = new AuthorizedHttpClient(pAPIKey, pDomain) {BaseAddress = pDomain};
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowGenericTeamworkError(ex);
            }
        }

        /// <summary>
        /// Returns a new instance of the Teamwork API Client
        /// </summary>
        /// <param name="domain">Your Projects Domain eg: https://name.teamwork.com</param>
        /// <param name="apiKey">Your API Key</param>
        /// <returns></returns>
        public static Client GetTeamworkClient(Uri domain, string apiKey)
        {
            try
            {
                var newTeamworkClient = new Client { httpClient = new AuthorizedHttpClient(apiKey, domain)};
                newTeamworkClient.httpClient.BaseAddress = domain;
                return newTeamworkClient;
            }
            catch (Exception ex)
            {
               ErrorHandler.ThrowGenericTeamworkError(ex);
               return null;
            }
        }

        
        //todo: Remove for Codeplex Release
        /// <summary>
        /// Returns a new instance of the Teamwork API Client using Username & Password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Client GetTeamworkClient(string userName, string password)
        {
            try
            {
                // accounts.teamwork.com/accounts/search,json 

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
