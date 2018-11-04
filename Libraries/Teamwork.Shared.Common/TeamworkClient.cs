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
using Teamwork.Client.HTTPClient;
using Teamwork.Shared.Common.Exceptions;

namespace Teamwork.Client
{

    /// <summary>
    /// Main entry point for the API
    /// </summary>
    public partial class Client
    {
        public AuthorizedHttpClient HttpClient { get; set; }
        public string ApiKey { get; set; }
        public Uri Domain { get; set; }

        public Client()
        {
        }

        /// <summary>
        /// Deprecated, please use GetTeamworkClient
        /// </summary>
        /// <param name="pDomain"></param>
        /// <param name="pApiKey"></param>
        public Client(Uri pDomain, string pApiKey)
        {
            try
            {
                ApiKey = pApiKey;
                Domain = pDomain;
                HttpClient = new AuthorizedHttpClient(pApiKey, pDomain) {BaseAddress = pDomain};
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowGenericTeamworkError(ex);
            }
        }

        /// <summary>
        /// Returns a new instance of the Teamwork API Client
        /// </summary>
        /// <param name="pDomain">Your Projects Domain eg: https://name.teamwork.com</param>
        /// <param name="pApiKey">Your API Key</param>
        /// <returns></returns>
        public static Client GetTeamworkClient(Uri pDomain, string pApiKey)
        {
            try
            {
                Client newTeamworkClient = null;
                newTeamworkClient = new Client { HttpClient = new AuthorizedHttpClient(pApiKey, pDomain) };
                newTeamworkClient.HttpClient.BaseAddress = pDomain;
                return newTeamworkClient;
            }
            catch (Exception ex)
            {
               ErrorHandler.ThrowGenericTeamworkError(ex);
               return null;
            }
        }


        /// <summary>
        /// Returns a new instance of the Teamwork API Client
        /// </summary>
        /// <param name="pDomain">Your Projects Domain eg: https://name.teamwork.com</param>
        /// <param name="pApiKey">Your API Key</param>
        /// <returns></returns>
        public static Client GetTeamworkClient(string AuthToken)
        {
            try
            {
                var newTeamworkClient = new Client { HttpClient = new AuthorizedHttpClient() };
                newTeamworkClient.HttpClient.BaseAddress = new Uri("http://sunbeam.teamwork.dev");
                newTeamworkClient.HttpClient.DefaultRequestHeaders.Add("apiToken", AuthToken);
                return newTeamworkClient;
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowGenericTeamworkError(ex);
                return null;
            }
        }


        /// <summary>
        /// Returns a new instance of the Teamwork API Client using Username & Password
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public static Client GetTeamworkClient(string pUserName, string pPassword)
        {
            try
            {
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
