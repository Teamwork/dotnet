﻿#region FileHeader
// ==========================================================
// File: Teamwork.Net.V2.TeamworkProjects.ProjectHandler.cs
// Last Mod:      24.05.2016
// Created:        24.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  24.05.2016 - Created
//  ==========================================================
#endregion

#region Imports

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.Model;

#endregion

namespace TeamworkProjects.Endpoints
{
    /// <summary>
    /// https://domain.teamwork.com/projects/xxxxx
    /// </summary>
    public class TimeHandler
    {
        private readonly Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public TimeHandler(Client pClient)
        {
            client = pClient;
        }

        /// <summary>
        ///   Return time totals for a project or tasklist
        ///   http://developer.teamwork.com/timetracking#time_totals
        /// </summary>
        /// <param name="pRojectId">Project ID (int)</param>
        /// <param name="pUserId"></param>
        /// <param name="pFromDate"></param>
        /// <param name="pToDate"></param>
        /// <param name="pFromTime"></param>
        /// <param name="pToTime"></param>
        /// <returns>Person List</returns>
        public async Task<TimeTotalsResponse> GetTotals_Project(int pRojectId, int pUserId = 0,
                                                                DateTime? pFromDate = null,
                                                                DateTime? pToDate = null,
                                                                string pFromTime = "",
                                                                string pToTime = "")
        {
            try
            {
                var requestring = "/projects/" + pRojectId + "/time/total.json";
                var data = await client.HttpClient.GetAsync<TimeTotalsResponse>(requestring, null);
                if (data.StatusCode == HttpStatusCode.OK) return (TimeTotalsResponse)data.ContentObj;
                return new TimeTotalsResponse { STATUS = data.Error.Message, Projects = null };
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }


        public async Task<bool> AddTimeEntry(NewTimeEntry pTimeEntry, string pProjectId)
        {
            try
            {
                var requestring = "/projects/" + pProjectId + "/time_entries.json";
                string postdata = JsonConvert.SerializeObject(pTimeEntry);
                var data = await client.HttpClient.PostWithReturnAsync(requestring, new StringContent("{\"time-entry\": " + postdata + "}", Encoding.UTF8));
                if (data.StatusCode == HttpStatusCode.Created) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }

    }
}