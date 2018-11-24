// ==========================================================
// File: Teamwork.TeamworkLoginFlow.cs
// Created: 2018.11.24
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Shared.Schema.Projects.V1;
using Teamwork.Shared.Schema.Projects.V1.Response;

#endregion

namespace Teamwork.Shared.Common.LoginFlow
{
    public static class TeamworkLoginFlow
    {

        /// <summary>
        /// Use the AppLoginflow code to return the final login data for a user
        /// </summary>
        /// <param name="code">Code retrieved as callback from app login flow</param>
        /// <returns></returns>
        public static async Task<LoginFlowResponse> GetLoginDataAsync(string code)
        {
            try {
                LoginFlowResponse response = new LoginFlowResponse();

                // Fetch the final token from teamwork API.
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://authenticate.teamwork.com");

                    var result = await client.PostAsync("/launchpad/v1/token.json?code=" + code,
                        new StringContent("{\"code\":\"" + code + "\"}", Encoding.UTF8, "application/json"));
                    var responseString = await result.Content.ReadAsStringAsync();
                    response.TokenData = JsonConvert.DeserializeObject<TokenResponse>(responseString);
                }

                // Fetch User Details
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(response.TokenData.Installation.ApiEndPoint);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", response.TokenData.AccessToken);
                    var result = await client.GetAsync("/me.json");
                    var responseString = await result.Content.ReadAsStringAsync();
                    response.UserData = JsonConvert.DeserializeObject<MeResponse>(responseString);
                }

                // Fetch Account Details
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(response.TokenData.Installation.ApiEndPoint);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", response.TokenData.AccessToken);
                    var result = await client.GetAsync("/account.json");
                    var responseString = await result.Content.ReadAsStringAsync();
                    response.AccountData = JsonConvert.DeserializeObject<AccountResponse>(responseString);
                }

                return response;
            }
            catch (Exception e) {
               throw new Exception("An error occured while getting access token data", e);
            }

        }
    }


    public class LoginFlowResponse
    {
        public MeResponse UserData { get; set; }
        public AccountResponse AccountData { get; set; }

        public TokenResponse TokenData { get; set; }
    }

    public class MeResponse
    {
        [JsonProperty("person", NullValueHandling = NullValueHandling.Ignore)]
        public Person Person { get; set; }

        [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

    public class Address
    {
        [JsonProperty("zipcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Zipcode { get; set; }

        [JsonProperty("countrycode", NullValueHandling = NullValueHandling.Ignore)]
        public string Countrycode { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("line1", NullValueHandling = NullValueHandling.Ignore)]
        public string Line1 { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("line2", NullValueHandling = NullValueHandling.Ignore)]
        public string Line2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
    }

    public class Integrations
    {
        [JsonProperty("idonethis", NullValueHandling = NullValueHandling.Ignore)]
        public Idonethis Idonethis { get; set; }

        [JsonProperty("microsoftConnector", NullValueHandling = NullValueHandling.Ignore)]
        public Idonethis MicrosoftConnector { get; set; }
    }

    public class Idonethis
    {
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; }
    }

    public class Permissions
    {
        [JsonProperty("can-manage-people", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanManagePeople { get; set; }

        [JsonProperty("can-add-projects", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanAddProjects { get; set; }

        [JsonProperty("can-access-templates", NullValueHandling = NullValueHandling.Ignore)]
        public bool CanAccessTemplates { get; set; }
    }

    public class PhoneNumberMobileParts { }


    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("installation")]
        public Installation Installation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Installation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("apiEndPoint")]
        public string ApiEndPoint { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("chatEnabled")]
        public bool ChatEnabled { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    public class Company
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}