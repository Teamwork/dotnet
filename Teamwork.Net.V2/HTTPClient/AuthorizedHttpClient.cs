#region FileHeader
// ==========================================================
// File: Teamwork.Net.V2.TeamworkProjects.AuthorizedHttpClient.cs
// Last Mod:      23.05.2016
// Created:        23.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  23.05.2016 - Created
//  23.05.2016 - Cleaned unused functions, moved overrides to different file
//  ==========================================================
#endregion
#region Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.Generic;
using TeamworkProjects.Model;
using TeamworkProjects.Response;

#endregion

namespace TeamworkProjects.HTTPClient
{

  /// <summary>
  /// Authorized Http Client is a derived HTTPClient with added Authentication Header
  /// </summary>
  public partial class AuthorizedHttpClient : HttpClient
   {
    /// <summary>
    ///   Initialize a new Instance of the Client
    /// </summary>
    /// <param name="apiKey">APIKey for Projects API</param>
    public AuthorizedHttpClient(string apiKey, Uri baseuri)
    {
     BaseAddress = baseuri;
     DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:x")));DefaultRequestHeaders.Accept.Clear();
     DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

        public async Task<BaseResponse<T>> GetAsync<T>(string pEndpoint, Dictionary<string, string> pAramsDictionary, RequestFormat pFormat = RequestFormat.Json)
        {
            try
            {

                var data2 = Task.Run(() => GetAsync(pEndpoint)).Result;

                // var data = await GetAsync(endpoint);
                if (!data2.IsSuccessStatusCode) return new BaseResponse<T>(HttpStatusCode.InternalServerError);
                using (Stream responseStream = await data2.Content.ReadAsStreamAsync())
                {
                    string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                    return new BaseResponse<T>(HttpStatusCode.OK) { ContentObj = JsonConvert.DeserializeObject(jsonMessage, typeof(T), settings), Headers = data2.Headers };
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Console.WriteLine(ex.Message);
            }
            return new BaseResponse<T>(HttpStatusCode.InternalServerError);
        }


        public async Task<BaseResponse<int>> PostWithReturnAsync(string requestUri, HttpContent content)
        {

            var response = await PostAsync(requestUri, content);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var message = GetError(new StreamReader(responseStream).ReadToEnd());
                    return new BaseResponse<int>(response.StatusCode, null) { Error = new Exception(message) };
                }
            }

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var result = (PostResponse)JsonConvert.DeserializeObject(jsonMessage, typeof(PostResponse), settings);
                if (!string.IsNullOrEmpty(result.Message))
                {
                    return new BaseResponse<int>(HttpStatusCode.BadRequest, null) { Content = result.Message };
                }
                else
                {
                    return new BaseResponse<int>(HttpStatusCode.OK, null) { Headers = response.Headers, ContentObj = result.id };
                }
            }

        }

        public async Task<BaseResponse<ProjectMailResponse>> PutWithReturnObjectAsync(string requestUri, HttpContent content)
        {

            var response = await PutAsync(requestUri, content);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var message = GetError(new StreamReader(responseStream).ReadToEnd());
                    return new BaseResponse<ProjectMailResponse>(response.StatusCode, null) { Error = new Exception(message) };
                }
            }

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                var result = (PostResponse)JsonConvert.DeserializeObject(jsonMessage, typeof(PostResponse));
                if (!string.IsNullOrEmpty(result.Message))
                {
                    return new BaseResponse<ProjectMailResponse>(HttpStatusCode.BadRequest, null) { Content = result.Message };
                }
                else
                {
                    return new BaseResponse<ProjectMailResponse>(HttpStatusCode.OK, null) { ContentObj = result.id };
                }
            }

        }

        public async Task<BaseResponse<bool>> PutWithReturnAsync(string requestUri, HttpContent content)
        {

            var response = await PutAsync(requestUri, content);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var message = GetError(new StreamReader(responseStream).ReadToEnd());
                    return new BaseResponse<bool>(response.StatusCode, null) { Error = new Exception(message) };
                }
            }

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                var result = (PostResponse)JsonConvert.DeserializeObject(jsonMessage, typeof(PostResponse));
                if (!string.IsNullOrEmpty(result.Message))
                {
                    return new BaseResponse<bool>(HttpStatusCode.BadRequest, null) { Content = result.Message };
                }
                else
                {
                    return new BaseResponse<bool>(HttpStatusCode.OK, null) { ContentObj = result.id };
                }
            }

        }



        public string GetError(string content)
        {
            var error = (ErrorResponse)JsonConvert.DeserializeObject<ErrorResponse>(content);
            return error.Message;
        }

        public BaseResponse<T> Get<T>(string endpoint, Dictionary<string, string> paramsDictionary, RequestFormat format = RequestFormat.Json)
        {
            var data = GetAsync(endpoint).Result;
            if (!data.IsSuccessStatusCode) return new BaseResponse<T>(HttpStatusCode.InternalServerError);
            using (Stream responseStream = data.Content.ReadAsStreamAsync().Result)
            {
                string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                return new BaseResponse<T>(HttpStatusCode.OK) { ContentObj = JsonConvert.DeserializeObject(jsonMessage, typeof(T)) };
            }
        }

    }
    


}