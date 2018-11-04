#region FileHeader
// ==========================================================
// File:            TeamworkProjects.CompanyHandler.cs
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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Client;
using TeamworkProjects.HTTPClient;
using Teamwork.Shared.Schema.Projects.V1;
using Teamwork.Shared.Schema.Projects.V1.Response;
using TeamworkProjects.Response;

#endregion

namespace Teamwork.Projects.Endpoints
{
  public class CompanyHandler
  {
      private readonly Client.Client client;

      /// <summary>
        /// Constructor for Project Handler
        /// </summary>
        public CompanyHandler(Client.Client pClient)
        {
            client = pClient;
        }


      /// <summary>
        /// Returns all projects the user has access to
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAllCompaniesAsync()
         {

          try
          {
                var requestString = "companies.json";
                var data = await client.HttpClient.GetListAsync<Company>(requestString, "companies", null);
                if (data.StatusCode == HttpStatusCode.OK) return data.List;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing Teamwork API Request: ", ex);
            }
          return null;
         }


      public async Task<CompanyResponse> GetCompanyAsync(int companyID)
   {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
       var data = await client.GetAsync<CompanyResponse>("/companies/" + companyID +".json", null);
       if (data.StatusCode == HttpStatusCode.OK) return (CompanyResponse)data.ContentObj;
     }
     return null;
   }


      public async Task<BaseResponse<int>> AddCompany(Company company)
    {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
        string post = JsonConvert.SerializeObject(company);
        return await client.PostWithReturnAsync("/companies.json", new StringContent("{\"company\": " + post + "}", Encoding.UTF8));
      }
    }


      public async Task<bool> UpdateCompany(Company company)
   {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
       string post = JsonConvert.SerializeObject(company);
       var response =
         await client.PutAsync("/companies/" + company.Id + ".json", new StringContent("{\"company\": " + post + "}", Encoding.UTF8));
     }
     return false;
   }

      public async Task<bool> DeleteCompany(Company company)
   {
            using (var client = new AuthorizedHttpClient(this.client.ApiKey, this.client.Domain))
            {
       string post = JsonConvert.SerializeObject(company);
       var response = await client.DeleteAsync("/companies/" + company.Id + ".json");
     }
     return false;
   }
  }
}
