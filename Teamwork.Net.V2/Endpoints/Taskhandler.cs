// ==========================================================
// File: TeamWorkNet.Portable.ProjectHandler.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.Helper;
using TeamworkProjects.HTTPClient;
using TeamworkProjects.Model;
using TeamworkProjects.Response;


namespace TeamworkProjects.Endpoints
{
  /// <summary>
  /// Handler for Projects
  /// </summary>
  public class TaskHandler
  {
        private readonly Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public TaskHandler(Client pClient)
        {
            client = pClient;
        }

        /// <summary>
        ///   Returns all projects the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodoItem>> GetAllTasks(int userID, DateTime Start, DateTime To)
        {
            try
            {
                var requestString = "tasks.json?filter=today&include=overdue&responsible-party-ids=78362";
               var data = await client.HttpClient.GetListAsync<TodoItem>(requestString, "todo-items", null);
                if (data.StatusCode == HttpStatusCode.OK) return data.List;
                if (data.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(data.Message);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }


        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public async Task<bool>CompleteTask(int taskid)
        {
            var response = await client.HttpClient.PutAsync("/tasks/" + taskid + "/complete.json",null);
        return false;
        }

    /// <summary>
    /// Delete a Task
    /// </summary>
    /// <param name="taskid"></param>
    /// <returns></returns>
    public async Task<bool> UnCompleteTask(int taskid)
    {

        var response = await client.HttpClient.PutAsync("/tasks/" + taskid + "/uncomplete.json", null);

      return false;
    }



        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTask(TodoItem task)
        {
            var requestString = "/tasks/" + task.id + ".json";
            string postdata = JsonConvert.SerializeObject(task);
            var data = await client.HttpClient.PutWithReturnAsync(requestString, new StringContent("{\"todo-item\": " + postdata + "}", Encoding.UTF8));
            var response = await client.HttpClient.PutAsync(requestString, null);

            return false;
        }


        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTask(TodoItemUpdate task)
        {
            var requestString = "/tasks/" + task.id + ".json";
            string postdata = JsonConvert.SerializeObject(task);
            var data = await client.HttpClient.PutWithReturnAsync(requestString, new StringContent("{\"todo-item\": " + postdata + "}", Encoding.UTF8));
            var response = await client.HttpClient.PutAsync(requestString, null);

            return false;
        }
    }
}