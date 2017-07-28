#region FileHeader
// ==========================================================
// File:            TeamworkProjects.AuthorizedHttpClient.cs
// Last Mod:        18.07.2016
// Created:         24.05.2016
// Created By:      Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  24.05.2016 - Created
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
    using System.Linq;

    /// <summary>
    /// Authorized Http Client is a derived HTTPClient with added Authentication Header
    /// </summary>
   public partial class AuthorizedHttpClient : HttpClient
   {
      /// <summary>
      ///   Initialize a new Instance of the Client
      /// </summary>
      /// <param name="pApiKey">APIKey for Projects API</param>
      /// <param name="pBaseuri"></param>
      public AuthorizedHttpClient(string pApiKey, Uri pBaseuri)
        {
         BaseAddress = pBaseuri;
         DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.UTF8.GetBytes($"{pApiKey}:x")));
         DefaultRequestHeaders.Accept.Clear();
         DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
        }

        /// <summary>
        ///   Initialize a new Instance of the Client
        /// </summary>
        /// <param name="pApiKey">APIKey for Projects API</param>
        /// <param name="pBaseuri"></param>
        public AuthorizedHttpClient(string pApiKey, Uri pBaseuri, HttpMessageHandler handler) : base(handler)
        {
            BaseAddress = pBaseuri;
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{pApiKey}:x")));
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
        }
        public AuthorizedHttpClient()
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
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

      public async Task<BaseResponse<int>> PostWithReturnAsync(string pRequestUri, HttpContent pContent)
        {

            var response = await PostAsync(pRequestUri, pContent);
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
                return new BaseResponse<int>(HttpStatusCode.OK, null) { Headers = response.Headers, ContentObj = result.id };
            }

        }

      public async Task<BaseResponse<ProjectMailResponse>> PutWithReturnObjectAsync(string pRequestUri, HttpContent pContent)
        {

            var response = await PutAsync(pRequestUri, pContent);
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
                return new BaseResponse<ProjectMailResponse>(HttpStatusCode.OK, null) { ContentObj = result.id };
            }

        }

      public async Task<BaseResponse<bool>> PutWithReturnAsync(string pRequestUri, HttpContent pContent)
        {

            var response = await PutAsync(pRequestUri, pContent);
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
                return new BaseResponse<bool>(HttpStatusCode.OK, null) { ContentObj = result.id };
            }

        }

      public string GetError(string pContent)
        {
            var error = JsonConvert.DeserializeObject<ErrorResponse>(pContent);
            return error.Message;
        }

      public BaseResponse<T> Get<T>(string pEndpoint, Dictionary<string, string> pAramsDictionary, RequestFormat pFormat = RequestFormat.Json)
        {
            var data = GetAsync(pEndpoint).Result;
            if (!data.IsSuccessStatusCode) return new BaseResponse<T>(HttpStatusCode.InternalServerError);
            using (Stream responseStream = data.Content.ReadAsStreamAsync().Result)
            {
                string jsonMessage = new StreamReader(responseStream).ReadToEnd();
                return new BaseResponse<T>(HttpStatusCode.OK) { ContentObj = JsonConvert.DeserializeObject(jsonMessage, typeof(T)) };
            }
        }
   }


    public class ClientCache
    {
        public List<ClientCacheEntry> data; 
        public List<ClientCacheEntry> Data
        {
            get { return data ?? (data = new List<ClientCacheEntry>()); }
            set { data = value; }
        }


        public void AddEntry(string pID, string pData, DateTime pCreated, HttpResponseHeaders pHeaders, HttpStatusCode pStatus)
        {
            Data.Add(new ClientCacheEntry() {
                ID =pID,
                Data = pData,
                DateCreated = DateTime.Now,
                Headers = pHeaders,
                 StatusCode = pStatus});
        }

        public ClientCacheEntry FindEntry(string pID)
        {
            var res = Data?.FirstOrDefault(p => p.ID == pID);
            if(res != null) { 
                if (res.DateCreated.AddMinutes(5) < DateTime.Now)
                {
                    Data.Remove(res);
                }
                else
                {
                    return res;
                }
            }
            return null;
        }

    }

    public class ClientCacheEntry
    {
        public string ID;
        public string Data;
        public DateTime DateCreated;
        public HttpResponseHeaders Headers;
        public HttpStatusCode StatusCode;
        public string ETAG;
    }


}