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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.Generic;
using TeamworkProjects.Helper;
using TeamworkProjects.Model;
using TeamworkProjects.Response;
using AuthorizedHttpClient = TeamworkProjects.HTTPClient.AuthorizedHttpClient;

namespace TeamworkProjects.Endpoints
{
    /// <summary>
    /// Handler for Projects
    /// </summary>
    public class TodoListHandler
    {
        private readonly Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public TodoListHandler(Client pClient)
        {
            client = pClient;
        }


        /// <summary>
        ///   Add a Tasklist to the given project
        ///   http://developer.teamwork.com/tasklists#create_list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="projectId">Project ID (int)</param>
        /// <returns>Milestone ID</returns>
        public async Task<TodoList> AddTodoList(TodoList list, int projectId)
        {
            string post = JsonConvert.SerializeObject(list);
            var newList =
                await
                    client.HttpClient.PostWithReturnAsync("/projects/" + projectId + "/todo_lists.json",
                        new StringContent("{\"todo-list\": " + post + "}", Encoding.UTF8));

            var id = newList.Headers.First(p => p.Key == "id");
            if (id.Value != null)
            {
                var listresponse =
                    await
                        client.HttpClient.GetAsync<TaskListResponse>(
                            "/todo_lists/" + int.Parse((string) id.Value.First()) + ".json", null,
                            RequestFormat.Json);
                if (listresponse != null && listresponse.ContentObj != null)
                {
                    var response = (TaskListResponse) listresponse.ContentObj;
                    return response.TodoList;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        ///   Add a Tasklist to the given project
        ///   http://developer.teamwork.com/tasklists#create_list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="projectId">Project ID (int)</param>
        /// <returns>Milestone ID</returns>
        public async Task<int> AddTodoListReturnOnlyID(TodoList list, int projectId)
        {
                string post = JsonConvert.SerializeObject(list);
                var newList =
                    await
                        client.HttpClient.PostWithReturnAsync("/projects/" + projectId + "/todo_lists.json",
                            new StringContent("{\"todo-list\": " + post + "}", Encoding.UTF8));

                var id = newList.Headers.First(p => p.Key == "id");
                if (id.Value != null)
                {
                    return int.Parse((string) id.Value.First());
                }
                return -1;
        }


        /// <summary>
        ///   Add a Task to the tasklist
        ///   http://developer.teamwork.com/todolistitems#add_a_task
        /// </summary>
        /// <param name="todo">The Task</param>
        /// <param name="taskListId">Tasklist to add the task to</param>
        /// <returns>Milestone ID</returns>
        public async Task<TodoItem> AddTodoItem(TodoItem todo, int taskListId)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
                var settings = new JsonSerializerSettings() {ContractResolver = new NullToEmptyStringResolver()};
                string post = JsonConvert.SerializeObject(todo, settings);
                var newList =
                    await
                        client.PostWithReturnAsync("/tasklists/" + taskListId + "/tasks.json",
                            new StringContent("{\"todo-item\": " + post + "}", Encoding.UTF8));

                var id = newList.Headers.First(p => p.Key == "id");
                if (id.Value != null)
                {
                    var listresponse =
                        await
                            client.GetAsync<TaskResponse>("/tasks/" + int.Parse((string) id.Value.First()) + ".json",
                                null,
                                RequestFormat.Json);
                    if (listresponse != null && listresponse.ContentObj != null)
                    {
                        var response = (TaskResponse) listresponse.ContentObj;
                        return response.TodoItem;
                    }
                }
                return null;
            }
        }


        public async Task<TodoItem> AddTodoItem(TodoItemCreate todo, int taskListId)
        {

                var settings = new JsonSerializerSettings() {ContractResolver = new NullToEmptyStringResolver()};
                string post = JsonConvert.SerializeObject(todo, settings);
                var newList =
                    await
                        client.HttpClient.PostWithReturnAsync("/tasklists/" + taskListId + "/tasks.json",
                            new StringContent("{\"todo-item\": " + post + "}", Encoding.UTF8));

                var id = newList.Headers.First(p => p.Key == "id");
                if (id.Value != null)
                {
                    var listresponse =
                        await
                            client.HttpClient.GetAsync<TaskResponse>("/tasks/" + int.Parse((string) id.Value.First()) + ".json",
                                null,
                                RequestFormat.Json);
                    if (listresponse != null && listresponse.ContentObj != null)
                    {
                        var response = (TaskResponse) listresponse.ContentObj;
                        return response.TodoItem;
                    }
                }
                return null;
        }


        public async Task<int> AddTodoItemFetchId(TodoItemCreate todo, int taskListId)
        {

            var settings = new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() };
            string post = JsonConvert.SerializeObject(todo, settings);
            var newList =
                await
                    client.HttpClient.PostWithReturnAsync("/tasklists/" + taskListId + "/tasks.json",
                        new StringContent("{\"todo-item\": " + post + "}", Encoding.UTF8));

            var id = newList.Headers.FirstOrDefault(p => p.Key == "id");
            return int.Parse((string)id.Value.FirstOrDefault());
        }


        /// <summary>
        ///   Returns all Roles of a project together with the persons in the roles
        ///   Details: http://developer.teamwork.com/projectroles
        /// </summary>
        /// <param name="tasklistid"></param>
        /// <param name="showCompleted"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<TodoItemsResponse> GetTasks(int tasklistid, bool showCompleted, int page = 1)
        {
            var data =
                await
                    client.HttpClient.GetAsync<TodoItemsResponse>(
                        "/tasklists/" + tasklistid + "/tasks.json?page=" + page +
                        "&nestSubTasks=true&includeCompletedTasks=" + showCompleted, null);
            if (data.StatusCode == HttpStatusCode.OK)
            {
                var response = (TodoItemsResponse) data.ContentObj;
                response.Pages = int.Parse(data.Headers.GetValues("X-Pages").First());
                response.Page = int.Parse(data.Headers.GetValues("X-Page").First());
                response.TotalRecords = int.Parse(data.Headers.GetValues("X-Records").First());
                return response;
            }
            return null;
        }

        /// <summary>
        ///   Returns all Roles of a project together with the persons in the roles
        ///   Details: http://developer.teamwork.com/projectroles
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<List<TodoList>> GetTaskListTemplates(int page = 1)
        {
            var data = await client.HttpClient.GetListAsync<TodoList>("/tasklists/templates.json", "tasklists", null);
            if (data.StatusCode == HttpStatusCode.OK) return data.List;
            throw new Exception(data.Message);
        }


        public async Task<LockDown> GetTaskListLockDown(int LockdownID)
        {
            var data = await client.HttpClient.GetAsync<LockDown>("/lockdown/" + LockdownID + ".json", "lockdown", null);
            if (data.StatusCode == HttpStatusCode.OK) return data.Data;
            throw new Exception(data.Message);
        }
    }
}