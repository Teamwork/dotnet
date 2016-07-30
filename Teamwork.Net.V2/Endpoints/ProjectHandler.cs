#region FileHeader
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
using TeamworkProjects.Base.Response;
using TeamworkProjects.Generic;
using TeamworkProjects.HTTPClient;
using TeamworkProjects.Model;
using TeamworkProjects.Response;
using PostResponse = TeamworkProjects.Model.PostResponse;

#endregion

namespace TeamworkProjects.Endpoints
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
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            try
            {
                var requestString = "projects.json";
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
        /// <returns></returns>
        public async Task<Project> GetProject(int pRojectId, bool pIncludePeople, bool pIncludeTaskLists,bool pIncludeTasks, bool pIncludeMilestones = true, bool pIncludeNotebookCategories = false)
        {
            try
            {
                var requestString = "/projects/" + pRojectId + ".json";
                var data = await client.HttpClient.GetAsync<Project>(requestString, "project", null);

                if (data.StatusCode == HttpStatusCode.OK)
                {
                    // Load all task lists if requested
                    if (pIncludeTaskLists)
                    {
                        await AddTasksToProject(pRojectId, pIncludeTasks, data);
                    }

                    // Load all people in the project
                    if (pIncludePeople)
                    {
                        await AddPeopleToProject(pRojectId, data);
                    }

                    // Load all milestones
                    if (pIncludeMilestones)
                    {
                        await AddMilestonesToProjectz(pRojectId, data);
                    }

                    if (pIncludeNotebookCategories)
                    {
                        await AddNotebookCategories(pRojectId, data);
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
                            "/projects/" + projectid + "milestones.json?getProgress=true&find=" + type, null);
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
        public async Task<TodoItem> AddTodoItem(TodoItem todo, int taskListId)
        {

                var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
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
        public async Task<bool> AddMessage(MessageCreate message, int projectID)
        {
                string post = JsonConvert.SerializeObject(message);
                var newList =
                    await
                        client.HttpClient.PostWithReturnAsync("/projects/" + projectID + "/posts.json",
                            new StringContent("{\"post\": " + post + "}", Encoding.UTF8));
            if (newList.StatusCode != HttpStatusCode.OK && newList.StatusCode != HttpStatusCode.Created) return false;
                //var id = newList.Headers.First(p => p.Key == "id");
                //if (id.Value != null)
                //{
                //    var listresponse =
                //        await
                //            client.HttpClient.GetAsync<PostResponse>("/posts/" + int.Parse(id.Value.First()) + ".json",
                //                null,
                //                RequestFormat.Json);
                //    if (listresponse != null && listresponse.ContentObj != null)
                //    {
                //        var response = (TaskResponse) listresponse.ContentObj;
                //        return response;
                //    }
                //}
            return true;
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
            using (var client = new  AuthorizedHttpClient(this.client.ApiKey,this.client.Domain))
            {
                string post = JsonConvert.SerializeObject(list);
                var newList =
                    await
                        client.PostWithReturnAsync("/projects/" + projectId + "/todo_lists.json",
                            new StringContent("{\"todo-list\": " + post + "}", Encoding.UTF8));

                var id = newList.Headers.First(p => p.Key == "id");
                if (id.Value != null)
                {
                    return int.Parse(id.Value.First());
                }
                return -1;
            }
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
        private async Task AddMilestonesToProjectz(int pRojectId, BaseSingleResponse<Project> pData)
        {
            var tasks =
                await
                    client.HttpClient.GetListAsync<Milestone>(
                        "/projects/" + pRojectId + "/milestones.json?find=all&getProgress=true", "milestones", null);
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
                pData.Data.NotebookCategories = tasks.List;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddPeopleToProject(int pRojectId, BaseSingleResponse<Project> pData)
        {
            var result =
                await client.HttpClient.GetListAsync<Person>("/projects/" + pRojectId + "/people.json", "people", null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                pData.Data.People = result.List;
            }
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private async Task AddTasksToProject(int pRojectId, bool pIncludeTasks, BaseSingleResponse<Project> pData)
        {
            var listname = pIncludeTasks ? "todo-lists" : "tasklists";
            var taskRequestString = "/projects/" + pRojectId + "/tasklists.json?getNewTaskDefaults=true";
            if (pIncludeTasks) taskRequestString = "/projects/" + pRojectId + "/todo_lists.json?getNewTaskDefaults=true&nestSubTasks =true";

            var result = await client.HttpClient.GetListAsync<TodoList>(taskRequestString, listname, null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                pData.Data.Tasklists = result.List;
            }
        }

    }
}