﻿#region FileHeader
// ==========================================================
// File:               TeamworkProjects.ProjectHandler.cs
// Last Mod:      18.07.2016
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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Projects.Base.Response;
using Teamwork.Projects.Schema.V1.Response;
using Teamwork.Shared.Common.Generic;
using Teamwork.Shared.Common.Response;
using Teamwork.Shared.Schema.Projects.v1.Response;
using Teamwork.Shared.Schema.Projects.V1;
using Teamwork.Shared.Schema.Projects.V1.Response;
#endregion

namespace Teamwork.Endpoints
{
    /// <summary>
    /// https://domain.teamwork.com/projects/xxxxx
    /// </summary>
    public class ProjectHandler
    {
        private readonly Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public ProjectHandler(Client pClient)
        {
            this.client = pClient;
        }



        /// <summary>
        ///   Returns all projects the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<SearchResultClass> Search(string searchTerm, string searchType)
        {
            try
            {
                var requestString = "search.json?SearchFor=" + searchType + "&searchTerm=" + searchTerm;
                var data = await this.client.HttpClient.GetAsync<SearchResultClass>(requestString, "searchResult", null);
                if (data.StatusCode == HttpStatusCode.OK) return data.Data;
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
        ///   Returns all projects the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllProjectsAsync(bool pStarredOnly)
        {
            try
            {
                var requestString = "projects.json?status=active&orderby=lastActivityDate";
                if (pStarredOnly) requestString = "/projects/starred.json?status=active&orderby=lastActivityDate";
                var data = await client.HttpClient.GetListAsync<Project>(requestString, "projects", null);
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



        ///// <summary>
        /////   Returns all projects the user has access to
        ///// </summary>
        ///// <returns></returns>
        //public async Task<SearchResultClass> Search(string searchTerm, string searchType)
        //{
        //    try
        //    {
        //        var requestString = "search.json?SearchFor=" + searchType + "&searchTerm=" + searchTerm;
        //        var data = await client.HttpClient.GetAsync<SearchResultClass>(requestString, "searchResult", null);
        //        if (data.StatusCode == HttpStatusCode.OK) return data.Data;
        //        if (data.StatusCode == HttpStatusCode.InternalServerError)
        //        {
        //            throw new Exception(data.Message);
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error processing Teamwork API Request: ", ex);
        //    }
        //}

        public Task AddTodoItem()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///   Returns all projects the user has access that have messages enabled
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllProjectsAsyncMessages(bool pStarredOnly)
        {
            try
            {
                var requestString = "/messages/projects.json?status=active&orderby=lastActivityDate&type=featureEnabled";
                if (pStarredOnly) requestString += "&starredOnly=true";
                var data = await client.HttpClient.GetListAsync<Project>(requestString, "projects", null);
                if (data.StatusCode == HttpStatusCode.OK) return data.List.OrderBy(p=>p.Name).ToList();
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
        ///   Returns all projects the user has access that have messages enabled
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllProjectsAsyncMilestones(bool pStarredOnly)
        {
            try
            {
                var requestString = "/Milestones/projects.json?status=active&orderby=lastActivityDate&type=featurenabled";
                if (pStarredOnly) requestString += "&starredOnly=true";
                var data = await client.HttpClient.GetListAsync<Project>(requestString, "projects", null);
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
        ///   Returns all projects the user has access that have messages enabled
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllProjectsAsyncNotebooks(bool pStarredOnly)
        {
            try
            {
                var requestString = "/notebooks/projects.json?status=active&orderby=lastActivityDate&type=featurenabled";
                if (pStarredOnly) requestString += "&starredOnly=true";
                var data = await client.HttpClient.GetListAsync<Project>(requestString, "projects", null);
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
        ///   Returns all projects the user has access that have messages enabled
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllProjectsAsyncTime(bool pStarredOnly)
        {
            try
            {
                var requestString = "/Time/projects.json?status=active&orderby=lastActivityDate&type=featurenabled";
                if (pStarredOnly) requestString += "&starredOnly=true";
                var data = await client.HttpClient.GetListAsync<Project>(requestString, "projects", null);
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
        ///   Returns all projects the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> GetAllRecentProjectsAsync(DateTime pUpdatedSince)
        {
            try
            { 
               var data = await client.HttpClient.GetListAsync<Project>("projects.json?updatedAfterDate=" + pUpdatedSince.ToString("yyyyMMddhhmmss"), "projects", null);
               if (data.StatusCode == HttpStatusCode.OK) return data.List;
               return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }


        /// <summary>
        ///   Return all persons of a given project
        ///   http://developer.teamwork.com/people
        /// </summary>
        /// <param name="pRojectId">Project ID (int)</param>
        /// <returns>Person List</returns>
        public async Task<List<Person>> GetPeople(int pRojectId)
        {
            try
            {
                var data = await client.HttpClient.GetListAsync<Person>("/projects/" + pRojectId + "/people.json","people", null);
                if (data.StatusCode == HttpStatusCode.OK) return data.List;
                throw new Exception(data.Status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }


        /// <summary>
        ///   Returns details of a specific person in a project
        ///   http://developer.teamwork.com/people
        /// </summary>
        /// <param name="pRojectId">Project ID (int)</param>
        /// <param name="pErsonId"></param>
        /// <returns>Person List</returns>
        public async Task<PeopleResponse> GetPeople(int pRojectId, int pErsonId)
        {
            try
            {
                using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
                {
                    var data =
                        await
                            client.GetAsync<PeopleResponse>("/projects/" + pRojectId + "/people/" + pErsonId + ".json",
                                null);
                    if (data.StatusCode == HttpStatusCode.OK) return (PeopleResponse) data.ContentObj;
                }
                return new PeopleResponse {STATUS = "ERROR", People = null};
            }
            catch (Exception ex)
            {
                return new PeopleResponse {STATUS = "ERROR:" + ex.Message, People = null};
            }
        }


        /// <summary>
        ///   Returns a single Project, returns null if the user can not access the project
        /// </summary>
        /// <param name="pRojectId">the project id</param>
        /// <param name="pIncludePeople">include people on project</param>
        /// <param name="pIncludeTaskLists">include task lists</param>
        /// <param name="pIncludeTasks">Nest </param>
        /// <param name="pIncludeMilestones">include all milestones</param>
        /// <param name="pIncludeNotebookCategories"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<Project> GetProject(int pRojectId, bool pIncludePeople, bool pIncludeTaskLists,bool pIncludeTasks,
            bool pIncludeMilestones = true, 
            bool pIncludeNotebookCategories = false,
            bool pIncludeMessageCategories = false,
            bool pIncludeLinkCategories = false,
            bool pMSProjectMode = false,
            bool pIncludeFileCategories = false,
            bool pIncludeCompletedTasks = false,
            bool pIncludeTimeEntries = false)
        {
            try
            {
                var requestString = "/projects/" + pRojectId + ".json";
                if (pMSProjectMode) requestString = "/msprj/getproject.json";
                var data = await client.HttpClient.GetAsync<Project>(requestString, "project", null);

                if (data.StatusCode == HttpStatusCode.OK)
                {
                    // Load all task lists if requested
                    if (pIncludeTaskLists)
                    {
                        await AddTasksToProject(pRojectId, pIncludeTasks, data,DateTime.MinValue, DateTime.MaxValue, pMSProjectMode, showCompleted:pIncludeCompletedTasks);
                    }

                    // Load all people in the project
                    if (pIncludePeople)
                    {
                        await AddPeopleToProject(pRojectId, data, pMSProjectMode);
                    }

                    // Load all milestones
                    if (pIncludeMilestones)
                    {
                        await AddMilestonesToProjectz(pRojectId, data, pMSProjectMode);
                    }

                    if (pIncludeNotebookCategories && !pMSProjectMode)
                    {
                        await AddNotebookCategories(pRojectId, data);
                    }


                    if (pIncludeMessageCategories && !pMSProjectMode)
                    {
                        await AddMessageCategories(pRojectId, data);
                    }

                    if (pIncludeLinkCategories && !pMSProjectMode)
                    {
                        await AddLinkCategories(pRojectId, data);
                    }

                    if (pIncludeFileCategories && !pMSProjectMode)
                    {
                        await AddFileCategories(pRojectId, data);
                    }

                    if (pIncludeTimeEntries && !pMSProjectMode)
                    {
                        await AddTimeEntries(pRojectId, data);
                    }


                    return data.Data;
                }
                throw new Exception(data.Status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }


        public async Task<StatsResponse> GetProjectStatus(int projectID)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                var data = await client.GetAsync<StatsResponse>("/projects/" + projectID + "/stats.json", null);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    var prj = (StatsResponse) data.ContentObj;

                    return new StatsResponse {Status = "OK", Stats = prj.Stats};
                }
            }
            return null;
        }


        /// <summary>
        ///   Return all Milestones of a given project
        ///   http://developer.teamwork.com/milestones
        /// </summary>
        /// <param name="projectid">Project ID (int)</param>
        /// <param name="type">Milestone Search Type</param>
        /// <returns>Milestone List</returns>
        public async Task<MileStonesResponse> GetProjectMilestones(int projectid, MilestoneFindType type)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                var data =
                    await
                        client.GetAsync<MileStonesResponse>(
                            "/projects/" + projectid + "/milestones.json?getProgress=true&find=" + type, null);
                if (data.StatusCode == HttpStatusCode.OK) return (MileStonesResponse) data.ContentObj;
            }
            return null;
        }

        /// <summary>
        ///   Returns all Companies within the given Project
        ///   Details: http://developer.teamwork.com/companies
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public async Task<CompaniesResponse> GetProjectCompanies(int projectid)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                var data = await client.GetAsync<CompaniesResponse>("/projects/" + projectid + "/companies.json", null);
                if (data.StatusCode == HttpStatusCode.OK) return (CompaniesResponse) data.ContentObj;
            }
            return null;
        }

        /// <summary>
        ///   Returns all Roles of a project together with the persons in the roles
        ///   Details: http://developer.teamwork.com/projectroles
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public async Task<RoleResponse> GetProjectRoles(int projectid)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                var data = await client.GetAsync<RoleResponse>("/projects/" + projectid + "/projectroles.json", null);
                if (data.StatusCode == HttpStatusCode.OK) return (RoleResponse) data.ContentObj;
            }
            return null;
        }


        /// <summary>
        ///   Returns all Roles of a project together with the persons in the roles
        ///   Details: http://developer.teamwork.com/projectroles
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public async Task<List<TeamWorkFile>> GetProjectFiles(int projectid)
        {
             var data = await client.HttpClient.GetAsync<TeamworkFileProjectCallWrapper>("/projects/" + projectid + "/files.json","project", null);
             if (data.StatusCode == HttpStatusCode.OK) return data.Data.files;
              return null;
        }



        /// <summary>
        ///   Add a Milestone to the given project
        ///   http://developer.teamwork.com/milestones#create_a_single_m
        /// </summary>
        /// <param name="milestone">Milestone ID (int)</param>
        /// <param name="projectId">Project ID (int)</param>
        /// <returns>Milestone ID</returns>
        public async Task<BaseResponse<int>> AddMilestone(Milestone milestone, int projectId)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                string post = JsonConvert.SerializeObject(milestone);
                return
                    await
                        client.PostWithReturnAsync("/projects/" + projectId + "/milestones.json",
                            new StringContent("{\"milestone\": " + post + "}", Encoding.UTF8));
            }
        }

        /// <summary>
        ///   Add a Milestone to the given project
        ///   http://developer.teamwork.com/milestones#create_a_single_m
        /// </summary>
        /// <param name="milestone">Milestone ID (int)</param>
        /// <param name="projectId">Project ID (int)</param>
        /// <returns>Milestone ID</returns>
        public async Task<BaseResponse<int>> AddLink(Link link, int projectId)
        {
                string post = JsonConvert.SerializeObject(link);
                return
                    await
                        client.HttpClient.PostWithReturnAsync("/projects/" + projectId + "/links.json",
                            new StringContent("{\"link\": " + post + "}", Encoding.UTF8));
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
                                "/todo_lists/" + int.Parse(id.Value.First()) + ".json", null,
                                RequestFormat.Json);
                    if (listresponse != null && listresponse.ContentObj != null)
                    {
                        var response = (TaskListResponse) listresponse.ContentObj;
                        return response.TodoList;
                    }
            }
                throw new Exception("Something went wrong");
        }


        /// <summary>
        ///   Add a Task to the tasklist
        ///   http://developer.teamwork.com/todolistitems#add_a_task
        /// </summary>
        /// <param name="todo">The Task</param>
        /// <param name="taskListId">Tasklist to add the task to</param>
        /// <returns>Milestone ID</returns>
        public async Task<TodoItem> AddTodoItem(TodoItemCreate todo, int taskListId, bool IsSubTask = false, string parentTaskID = "")
        {

                var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
                string post = JsonConvert.SerializeObject(todo, settings);


               var requesturi = IsSubTask ? "/tasks/" + parentTaskID + ".json" : "/tasklists/" + taskListId + "/tasks.json";


                var newList =await client.HttpClient.PostWithReturnAsync(requesturi, 
                            new StringContent("{\"todo-item\": " + post + "}", Encoding.UTF8));

                var id = newList.Headers.First(p => p.Key == "id");
                if (id.Value != null)
                {
                    var listresponse =
                        await
                            client.HttpClient.GetAsync<TaskResponse>("/tasks/" + int.Parse(id.Value.First()) + ".json",
                                null,
                                RequestFormat.Json);
                    if (listresponse != null && listresponse.ContentObj != null)
                    {
                        var response = (TaskResponse) listresponse.ContentObj;
                        return response.TodoItem;
                    }
                }
throw new Exception("Something went wrong whilea dding the task");
        }


        /// <summary>
        ///   Add a message to the project
        ///   http://developer.teamwork.com/messages#create_a_message
        /// </summary>
        /// <param name="message">The Task</param>
        /// <param name="projectID">Tasklist to add the task to</param>
        /// <returns>Milestone ID</returns>
        public async Task<int> AddMessage(MessageCreate message, int projectID)
        {
                string post = JsonConvert.SerializeObject(message);
                var newList =
                    await
                        client.HttpClient.PostWithReturnAsync("/projects/" + projectID + "/posts.json",
                            new StringContent("{\"post\": " + post + "}", Encoding.UTF8));
            if (newList.StatusCode != HttpStatusCode.OK && newList.StatusCode != HttpStatusCode.Created) return -1;
            var id = newList.Headers.First(p => p.Key == "id");
            if (id.Value != null)
            {
                return int.Parse(id.Value.First().ToString());
            }
            return -1;
        }


        /// <summary>
        ///   Add a message to the project
        ///   http://developer.teamwork.com/messages#create_a_message
        /// </summary>
        /// <param name="message">The Task</param>
        /// <param name="projectID">Tasklist to add the task to</param>
        /// <returns>Milestone ID</returns>
        public async Task<bool> AddNotebook(Notebook book, int projectID)
        {
            string post = JsonConvert.SerializeObject(book);
            var newList =
                await
                    client.HttpClient.PostWithReturnAsync("/projects/" + projectID + "/notebooks.json",
                        new StringContent("{\"notebook\": " + post + "}", Encoding.UTF8));
            if (newList.StatusCode != HttpStatusCode.OK && newList.StatusCode != HttpStatusCode.Created) return false;
            return true;
        }


        /// <summary>
        ///   Add a message to the project
        ///   http://developer.teamwork.com/messages#create_a_message
        /// </summary>
        /// <param name="message">The Task</param>
        /// <param name="projectID">Tasklist to add the task to</param>
        /// <returns>Milestone ID</returns>
        public async Task<bool> AddMessageNoCallback(NewPost message, int projectID)
        {

            try
            {
                using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
                {
                    string post = JsonConvert.SerializeObject(message);
                    await
                        client.PostWithReturnAsync("/projects/" + projectID + "/posts.json",
                            new StringContent("{\"post\": " + post + "}", Encoding.UTF8));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
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
                    return int.Parse(id.Value.First());
                }
                return -1;
          }


        /// <summary>
        ///   Add a Tasklist to the given project
        ///   http://developer.teamwork.com/tasklists#create_list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="projectId">Project ID (int)</param>
        /// <returns>Milestone ID</returns>
        public async Task<int> UpdateTodoList(TodoList list, int projectId)
        {

            string post = JsonConvert.SerializeObject(list);
            var newList =
                await
                    client.HttpClient.PutAsync("/tasklists/" + list.Id + ".json",
                        new StringContent("{\"todo-list\": " + post + "}", Encoding.UTF8));
            return -1;
        }


        /// <summary>
        ///   Create a new Project
        ///   http://developer.teamwork.com/projects
        /// </summary>
        /// <param name="project">New Project Object</param>
        /// <returns>Project ID</returns>
        public async Task<BaseResponse<int>> AddProject(Newproject project)
        {
            string post = JsonConvert.SerializeObject(project);
            return await client.HttpClient.PostWithReturnAsync("projects.json",
                        new StringContent("{\"project\": " + post + "}", Encoding.UTF8));
        }


        /// <summary>
        ///   Create a new Project
        ///   http://developer.teamwork.com/projects
        /// </summary>
        /// <param name="project">New Project Object</param>
        /// <returns>Project ID</returns>
        public async void StarProject(int project)
        {
            await client.HttpClient.PutAsync("/projects/" + project + "/star.json",null);
        }

        /// <summary>
        ///   Update details of given Project
        ///   http://developer.teamwork.com/projects
        /// </summary>
        /// <param name="project">Project Object</param>
        /// <returns>Project ID</returns>
        public async Task<BaseResponse<bool>> UpdateProject(Project project)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                string post = JsonConvert.SerializeObject(project);
                return
                    await
                        client.PutWithReturnAsync("/projects/" + project.Id + ".json",
                            new StringContent("{\"project\": " + post + "}", Encoding.UTF8));
            }
        }


        /// <summary>
        ///   Update details of given Project
        ///   http://developer.teamwork.com/projects
        /// </summary>
        /// <param name="code">code eg: code@tasks.teamwork.com</param>
        /// <param name="projectId"></param>
        /// <returns>Project ID</returns>
        public async Task<BaseResponse<ProjectMailResponse>> SetProjectEmailAddressCode(string code, int projectId)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                return
                    await
                        client.PutWithReturnObjectAsync("/projects/" + projectId + "/emailaddress.json",
                            new StringContent("{\"emailaddress\": {\"code\":\"" + code + "\"}", Encoding.UTF8));
            }
        }




        /// <summary>
        ///   Delete given Project
        ///   http://developer.teamwork.com/projects
        /// </summary>
        /// <param name="project">Project Object</param>
        /// <returns>true/false</returns>
        public async Task<bool> DeleteProject(Project project)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                await client.DeleteAsync("/projects/" + project.Id + ".json");
                return true;
            }
        }

        /// <summary>
        ///   Deprecated, should not be used!
        /// </summary>
        /// <returns></returns>
        public BaseListResponse<Project> GetAllProjects(bool useDefaultParser = false)
        {
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                var requestString = "projects.json";
                if (useDefaultParser) requestString += "?useDefaultParser=true";
                var data = client.Get<BaseListResponse<Project>>(requestString, null);
                if (data.StatusCode == HttpStatusCode.OK) return (BaseListResponse<Project>) data.ContentObj;
            }
            return null;
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddMilestonesToProjectz(int pRojectId, BaseSingleResponse<Project> pData, bool pMSProjectMode = false)
        {

            var request = "/projects/" + pRojectId + "/milestones.json ? find = all & getProgress = true";
            if (pMSProjectMode) request = "/msprj/getprojectmilestones.jsonfind=all&getProgress=true";
            var tasks =
                await
                    client.HttpClient.GetListAsync<Milestone>(request
                        , "milestones", null);
            if (tasks.StatusCode == HttpStatusCode.OK)
            {
                pData.Data.Milestones = tasks.List;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddNotebookCategories(int pRojectId, BaseSingleResponse<Project> pData)
        {
            var tasks =
                await
                    client.HttpClient.GetListAsync<Category>(
                        "/projects/" + pRojectId + "/notebookCategories.json", "Categories", null);
            if (tasks.StatusCode == HttpStatusCode.OK)
            {
                // Prepare Categories

                foreach (var cat in tasks.List)
                {
                    cat.Children = tasks.List.Where(p => p.ParentId == cat.Id).ToList();
                    if (cat.Children.Count > 0) cat.HasChildren = true;
                    cat.Children.ForEach(p => p.ParentName = cat.Name);
                }


                pData.Data.NotebookCategories = tasks.List;
            }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddMessageCategories(int pRojectId, BaseSingleResponse<Project> pData)
        {
            var tasks =
                await
                    client.HttpClient.GetListAsync<Category>(
                        "/projects/" + pRojectId + "/messageCategories.json", "Categories", null);
            if (tasks.StatusCode == HttpStatusCode.OK)
            {
                // Prepare Categories

                foreach (var cat in tasks.List)
                {
                    cat.Children = tasks.List.Where(p => p.ParentId == cat.Id).ToList();
                    if (cat.Children.Count > 0) cat.HasChildren = true;
                    cat.Children.ForEach(p => p.ParentName = cat.Name);
                }
                pData.Data.MessageCategories = tasks.List;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddLinkCategories(int pRojectId, BaseSingleResponse<Project> pData)
        {
            var tasks =
                await
                    client.HttpClient.GetListAsync<Category>(
                        "/projects/" + pRojectId + "/LinkCategories.json", "Categories", null);
            if (tasks.StatusCode == HttpStatusCode.OK)
            {
                // Prepare Categories

                foreach (var cat in tasks.List)
                {
                    cat.Children = tasks.List.Where(p => p.ParentId == cat.Id).ToList();
                    if (cat.Children.Count > 0) cat.HasChildren = true;
                    cat.Children.ForEach(p => p.ParentName = cat.Name);
                }
                pData.Data.LinkCategories = tasks.List;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddFileCategories(int pRojectId, BaseSingleResponse<Project> pData)
        {
            var tasks =
                await
                    client.HttpClient.GetListAsync<Category>(
                        "/projects/" + pRojectId + "/FileCategories.json", "Categories", null);
            if (tasks.StatusCode == HttpStatusCode.OK)
            {
                // Prepare Categories

                foreach (var cat in tasks.List)
                {
                    cat.Children = tasks.List.Where(p => p.ParentId == cat.Id).ToList();
                    if (cat.Children.Count > 0) cat.HasChildren = true;
                    cat.Children.ForEach(p => p.ParentName = cat.Name);
                }
                pData.Data.FileCategories = tasks.List;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddPeopleToProject(int pRojectId, BaseSingleResponse<Project> pData, bool pMSProjectMode = false)
        {
            var taskRequestString = "/projects/" + pRojectId + "/people.json";
            if (pMSProjectMode) taskRequestString = "/msprj/getprojectpeople.json";

            var result =
                await client.HttpClient.GetListAsync<Person>(taskRequestString, "people", null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                pData.Data.People = result.List;
            }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddTimeEntries(int pRojectId, BaseSingleResponse<Project> pData, bool pMSProjectMode = false)
        {
            var taskRequestString = "/projects/" + pRojectId + "/time_entries.json";

            var result =
                await client.HttpClient.GetListAsync<TimeEntry>(taskRequestString, "time-entries", null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                pData.Data.TimEntries = result.List;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddTasksToProject(int pRojectId, bool pIncludeTasks, BaseSingleResponse<Project> pData, DateTime? startDate, DateTime? endDate, bool pMSProjectMode = false, bool showCompleted = false)
        {
            var listname =  "tasklists";
            var taskRequestString = "/projects/" + pRojectId + "/tasklists.json?getNewTaskDefaults=true";
            //if (pIncludeTasks) taskRequestString = "/projects/" + pRojectId + "/todo_lists.json?getNewTaskDefaults=true&nestSubTasks=true";
            if (showCompleted) taskRequestString = taskRequestString + "&showCompleted=true&status=all";
            if (pMSProjectMode) taskRequestString = "/msprj/getprojecttasklists.json?nestSubTasks=true";


						var result = await client.HttpClient.GetListParallelAsync<TodoList>(taskRequestString, listname, null);

						if (pIncludeTasks) {

							await Task.WhenAll(result.List.Select(list => Task.Run(() => {

								var taskurl = $"/tasklists/{list.Id}/tasks.json?pageSize=50&getFiles=1&getSubTasks=1&nestSubTasks=true";
							    if (showCompleted) taskurl += "&includeCompletedTasks=1&includeCompletedSubTasks=1";


                                var taskresult = client.HttpClient.GetListParallelAsync<TodoItem>(taskurl, "todo-items", null).Result;

								if (list.TodoItems == null) list.TodoItems = new List<TodoItem>();
								list.TodoItems.AddRange(taskresult.List);

							})));



						}


			if (result.StatusCode == HttpStatusCode.OK)
            {
                pData.Data.Tasklists = result.List;
            }
        }

    }
}