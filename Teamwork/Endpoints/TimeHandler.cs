#region FileHeader
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
using Teamwork;

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


        public async Task<int> AddTimeEntry(NewTimeEntry pTimeEntry, string pProjectId, bool IsTaskID = false, bool markCompleted = false)
        {
            try
            {
                var requestring = "/projects/" + pProjectId + "/time_entries.json";
                if(IsTaskID) requestring = "/tasks/" + pProjectId + "/time_entries.json";
                string postdata = JsonConvert.SerializeObject(pTimeEntry);
                var data = await client.HttpClient.PostWithReturnAsync(requestring, new StringContent("{\"time-entry\": " + postdata + "}", Encoding.UTF8));

                if (data.StatusCode == HttpStatusCode.Created || data.StatusCode == HttpStatusCode.OK)
                {
                    if (markCompleted && IsTaskID)
                    {
                        await client.Tasks.CompleteTask(int.Parse(pProjectId));
                    }
                    return int.Parse(((string[])(data.Headers.GetValues("id")))[0]);
                }


                return (int)data.ContentObj;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }

        public async Task<bool> UpdateTimeEntry(int id, NewTimeEntry pTimeEntry)
        {
            try
            {
                var requestring = "/time_entries/" + id + ".json";
                string postdata = JsonConvert.SerializeObject(pTimeEntry);
                var data = await client.HttpClient.PutAsync(requestring, new StringContent("{\"time-entry\": " + postdata + "}", Encoding.UTF8));

                if (data.StatusCode == HttpStatusCode.Created || data.StatusCode == HttpStatusCode.OK) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }
    }
}