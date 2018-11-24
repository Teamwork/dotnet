// ==========================================================
// File: Teamwork.Projects.TeamworkNoAuth.cs
// Created: 2018.11.04
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Teamwork.Shared.Common.Exceptions;
using Teamwork.Shared.Schema.Projects.V1;

#endregion

namespace Teamwork
{
    /// <summary>
    /// Main entry point for the API
    /// </summary>
    public class TeamworkNoAuth
    {
        private AuthorizedHttpClient Client { get; set; }


        /// <summary>
        /// Returns authentication details and infos of the current user
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntry>> GetAuthenticationtDetails(string pUserName, string pAssword)
        {
            var accountlist = new List<UserEntry>();
            using (var webclient = new AuthorizedHttpClient("", new Uri("https://authenticate.teamwork.com/"),false)) {
                var data = await webclient.GetListAsync<UserEntry>(
                    @"accounts/search.json?email=" + pUserName + "&password=" + HttpUtility.UrlEncode(pAssword),
                    "accounts", null);
                if (data.StatusCode == HttpStatusCode.OK)
                    accountlist.AddRange(data.List);
                else
                    throw new Exception(data.Status + " " + data.Message);
            }


            using (var webclient = new AuthorizedHttpClient("", new Uri("https://authenticate.eu.teamwork.com/"),false)) {
                var data = await webclient.GetListAsync<UserEntry>(
                    @"accounts/search.json?email=" + pUserName + "&password=" + HttpUtility.UrlEncode(pAssword),
                    "accounts", null);
                if (data.StatusCode == HttpStatusCode.OK) {
                    foreach (var acc in data.List) acc.companyname = acc.companyname + "-EU";
                    accountlist.AddRange(data.List);
                }
                else {
                    throw new Exception(data.Status + " " + data.Message);
                }
            }

            if (accountlist.Count > 0) return accountlist;
            throw new Exception("No Login found");
        }


        /// <summary>
        /// Returns authentication details and infos of the current user
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntry>> GetAuthenticationtDetailsTest(string pUserName, string pAssword)
        {
            var accountlist = new List<UserEntry>();
            using (var webclient = new AuthorizedHttpClient("", new Uri("http://sunbeam.teamwork.dev/"),true)) {
                var data = await webclient.GetListAsync<UserEntry>(
                    @"accounts/search.json?email=" + pUserName + "&password=" + pAssword, "accounts", null);
                if (data.StatusCode == HttpStatusCode.OK)
                    accountlist.AddRange(data.List);
                else
                    throw new Exception(data.Status + " " + data.Message);
            }

            if (accountlist.Count > 0) return accountlist;
            throw new Exception("No Login found");
        }


        /// <summary>
        /// Returns authentication details and infos of the current user
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntry>> FindAccounts(string pUserName)
        {
            var accountlist = new List<UserEntry>();
            using (var webclient = new AuthorizedHttpClient("", new Uri("https://authenticate.teamwork.com/"), true)) {
                var data = await webclient.GetListAsync<UserEntry>(@"accounts/search.json?email=" + pUserName,
                    "accounts", null);
                if (data.StatusCode == HttpStatusCode.OK)
                    accountlist.AddRange(data.List);
                else
                    throw new Exception(data.Status + " " + data.Message);
            }

            using (var webclient = new AuthorizedHttpClient("", new Uri("https://authenticate.eu.teamwork.com/"), true)) {
                var data = await webclient.GetListAsync<UserEntry>(@"accounts/search.json?email=" + pUserName,
                    "accounts", null);
                if (data.StatusCode == HttpStatusCode.OK) {
                    foreach (var acc in data.List) acc.companyname = acc.companyname + "-EU";
                    accountlist.AddRange(data.List);
                }
                else {
                    throw new Exception(data.Status + " " + data.Message);
                }
            }

            if (accountlist.Count > 0) return accountlist;
            throw new Exception("No Login found");
        }
    }
}