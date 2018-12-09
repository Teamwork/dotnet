#region FileHeader

// ==========================================================
// File:            TeamworkProjects.CategoryHandler.cs
// Last Mod:        19.07.2016
// Created:         19.07.2016
// Created By:      Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  19.07.2016 - Created
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
using Teamwork;
using Teamwork.HTTPClient;
using Teamwork;
using Teamwork.Model.Projects.V1;
using Teamwork.Response;

#endregion

namespace TeamWorkNet.Handler
{
    public class CategoryHandler
    {
        private readonly Client client;

        /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public CategoryHandler(Client pClient)
        {
            client = pClient;
        }


        public async Task<List<Category>> GetProjectCategoriesAsync()
        {
            try
            {
                var requestString = "projectCategories.json";
                var data = await client.HttpClient.GetListAsync<Category>(requestString, "categories", null);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    // Prepare Categories

                    foreach (var cat in data.List)
                    {
                        cat.Children = data.List.Where(p => p.ParentId == cat.Id).ToList();
                        if (cat.Children.Count > 0) cat.HasChildren = true;
                        cat.Children.ForEach(p => p.ParentName = cat.Name);
                    }
                    
                    return data.List;
                }

                throw new Exception("Error processing Teamwork API Request: ", new Exception(data.Message));
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
        }

        public async Task<bool> AddProjectCategory(Category company)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
                string post = JsonConvert.SerializeObject(company);
                var response =
                    await
                        client.PostAsync("categories.json",
                            new StringContent("{\"category\":" + post + "}", Encoding.UTF8));
            }
            return false;
        }

        public async Task<bool> UpdateProjectCategory(Category company)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
                string post = JsonConvert.SerializeObject(company);
                var response =
                    await
                        client.PutAsync("/category/" + company.Id + ".json",
                            new StringContent("{\"category\":" + post + "}", Encoding.UTF8));
            }
            return false;
        }

        public async Task<bool> DeleteCProjectCategory(Category company)
        {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
                string post = JsonConvert.SerializeObject(company);
                var response = await client.DeleteAsync("/category/" + company.Id + ".json");
            }
            return false;
        }
    }
}