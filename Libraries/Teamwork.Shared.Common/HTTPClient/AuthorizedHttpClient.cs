// ==========================================================
// File: Teamwork.Projects.AuthorizedHttpClient.cs
// Created: 2018.11.04
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Shared.Common.Generic;
using Teamwork.Shared.Common.Response;
using Teamwork.Shared.Schema.Projects.V1;
using Teamwork.Shared.Schema.Projects.V1.Response;

#endregion

namespace Teamwork
{
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
        public AuthorizedHttpClient(string pApiKey, Uri pBaseuri, bool pUseOauth = false)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            BaseAddress = pBaseuri;
            DefaultRequestHeaders.Authorization = pUseOauth ? new AuthenticationHeaderValue("Bearer",pApiKey) : new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.UTF8.GetBytes($"{pApiKey}:x")));
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
        }

        /// <summary>
        ///   Initialize a new Instance of the Client
        /// </summary>
        /// <param name="pApiKey">APIKey for Projects API</param>
        /// <param name="pBaseuri"></param>
        public AuthorizedHttpClient(string pApiKey, Uri pBaseuri, HttpMessageHandler handler, bool pUseOauth = false) : base(handler)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            BaseAddress = pBaseuri;
            DefaultRequestHeaders.Authorization = pUseOauth ? new AuthenticationHeaderValue("Bearer", pApiKey) : new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{pApiKey}:x")));
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
        }

        public AuthorizedHttpClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
        }

        public async Task<BaseResponse<T>> GetAsync<T>(string pEndpoint, Dictionary<string, string> pAramsDictionary,
            RequestFormat pFormat = RequestFormat.Json)
        {
            try {
                var data2 = Task.Run(() => GetAsync(pEndpoint)).Result;

                // var data = await GetAsync(endpoint);
                if (!data2.IsSuccessStatusCode) return new BaseResponse<T>(HttpStatusCode.InternalServerError);
                using (var responseStream = await data2.Content.ReadAsStreamAsync()) {
                    var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
                    return new BaseResponse<T>(HttpStatusCode.OK) {
                        ContentObj = JsonConvert.DeserializeObject(jsonMessage, typeof(T), settings),
                        Headers = data2.Headers
                    };
                }
            }
            catch (Exception ex) {
                if (Debugger.IsAttached) Console.WriteLine(ex.Message);
            }

            return new BaseResponse<T>(HttpStatusCode.InternalServerError);
        }

        public async Task<BaseListResponse<T>> GetListAsync<T>(string pEndpoint, string pObjName, Dictionary<string, string> pParamsDictionary, RequestFormat pFormat = RequestFormat.Json)
        {
            try
            {
                ClientCacheEntry OldData = null;
                // Try to find cached results
                if (this.Cache != null)
                {
                    OldData = Cache.FindEntry(this.BaseAddress + "/" + pEndpoint + "/" + this.DefaultRequestHeaders);
                }
                if (OldData == null || (OldData.DateCreated < DateTime.Now.AddMinutes(5)))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var response = Task.Run(() => GetAsync(pEndpoint)).Result;
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var returndata = BaseListResponse<T>.Deserialize<T>(jsonMessage, pObjName);
                            // Add Header from Response
                            returndata.Headers = response.Headers;
                            returndata.StatusCode = response.StatusCode;


                            Cache?.AddEntry(this.BaseAddress + "/" + pEndpoint, jsonMessage, DateTime.Now, response.Headers, response.StatusCode);
                            return returndata;
                        }
                        return new BaseListResponse<T>
                        {
                            Headers = response.Headers,
                            StatusCode = response.StatusCode,
                            Message = jsonMessage
                        };
                    }
                }
                else
                {
                    var returndata = BaseListResponse<T>.Deserialize<T>(OldData.Data, pObjName);
                    // Add Header from Response
                    returndata.Headers = OldData.Headers;
                    returndata.StatusCode = OldData.StatusCode;
                    return returndata;
                }



            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Console.WriteLine(ex.Message);
                return new BaseListResponse<T>
                {
                    Headers = null,
                    StatusCode = HttpStatusCode.UnsupportedMediaType,
                    Message = ex.Message
                };
            }
        }



        public async Task<BaseListResponse<T>> GetListParallelAsync<T>(string pEndpoint, string pObjName, Dictionary<string, string> pParamsDictionary, RequestFormat pFormat = RequestFormat.Json)
        {
            try
            {
                var response = Task.Run(() => GetAsync(pEndpoint)).Result;
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {

                    var rateLimit = 0;
                    var rateLimitRemaining = 250;
                    var pages = 0;
                    var page = 0;
                    var items = 0;

                    var returnList = new List<T>();

                    var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {


                        // Lets see if there's more to fetch
                        rateLimit = int.Parse(response.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault()?.ToString());
                        rateLimitRemaining = int.Parse(response.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault()?.ToString());
                        page = int.Parse(response.Headers.GetValues("X-Page").FirstOrDefault()?.ToString());
                        pages = int.Parse(response.Headers.GetValues("X-Pages").FirstOrDefault()?.ToString());

                        var data = BaseListResponse<T>.Deserialize<T>(jsonMessage, pObjName);
                        returnList.AddRange(data.List);

                        if (page != pages)
                        {
                            List<string> urls = new List<string>();
                            while (page < pages)
                            {
                                urls.Add(pEndpoint + "&page=" + page);
                                page++;
                            }
                            await Task.WhenAll(urls.Select(pagedUrl => Task.Run(() => {

                                //Lets check rate limits first
                                response = Task.Run(() => GetAsync(pagedUrl)).Result;
                                rateLimit = int.Parse(response.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault()?.ToString());
                                rateLimitRemaining = int.Parse(response.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault()?.ToString());

                                if (rateLimitRemaining < 1) System.Threading.Thread.Sleep(60000);


                                data = BaseListResponse<T>.Deserialize<T>(jsonMessage, pObjName);
                                returnList.AddRange(data.List);

                            })));
                        }
                        var returndata = new BaseListResponse<T>
                        {
                            Headers = response.Headers,
                            StatusCode = response.StatusCode,
                            Message = jsonMessage,
                            List = returnList
                        };

                        return returndata;
                    }
                    return new BaseListResponse<T>
                    {
                        Headers = response.Headers,
                        StatusCode = response.StatusCode,
                        Message = jsonMessage
                    };
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Console.WriteLine(ex.Message);
                return new BaseListResponse<T>
                {
                    Headers = null,
                    StatusCode = HttpStatusCode.UnsupportedMediaType,
                    Message = ex.Message
                };
            }
        }



        public async Task<BaseSingleResponse<T>> GetAsync<T>(string pEndpoint, string pObjName, Dictionary<string, string> pParamsDictionary, RequestFormat pFormat = RequestFormat.Json)
        {
            try
            {
                ClientCacheEntry OldData = null;
                // Try to find cached results
                if (this.Cache != null)
                {
                    OldData = Cache.FindEntry(pEndpoint);
                }
                if (OldData == null)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var response = Task.Run(() => GetAsync(pEndpoint)).Result;
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var returndata = BaseSingleResponse<T>.Deserialize<T>(jsonMessage, pObjName);
                            // Add Header from Response
                            returndata.Headers = response.Headers;
                            returndata.StatusCode = response.StatusCode;
                            Cache?.AddEntry(pEndpoint, jsonMessage, DateTime.Now, response.Headers, response.StatusCode);
                            return returndata;
                        }
                        return new BaseSingleResponse<T>
                        {
                            Headers = response.Headers,
                            StatusCode = response.StatusCode,
                            Message = jsonMessage
                        };
                    }
                }
                else
                {
                    var returndata = BaseSingleResponse<T>.Deserialize<T>(OldData.Data, pObjName);
                    returndata.Headers = OldData.Headers;
                    returndata.StatusCode = OldData.StatusCode;
                    return returndata;
                }


            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Console.WriteLine(ex.Message);
                return new BaseSingleResponse<T>
                {
                    Data = default(T),
                    Headers = null,
                    StatusCode = HttpStatusCode.UnsupportedMediaType,
                    Message = ex.Message
                };
            }
        }



        public async Task<BaseResponse<int>> PostWithReturnAsync(string pRequestUri, HttpContent pContent)
        {
            var response = await PostAsync(pRequestUri, pContent);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                    var message = GetError(new StreamReader(responseStream).ReadToEnd());
                    return new BaseResponse<int>(response.StatusCode, null) {Error = new Exception(message)};
                }

            using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
                var result = (PostResponse) JsonConvert.DeserializeObject(jsonMessage, typeof(PostResponse), settings);
                if (!string.IsNullOrEmpty(result.Message))
                    return new BaseResponse<int>(HttpStatusCode.BadRequest, null) {Content = result.Message};
                return new BaseResponse<int>(HttpStatusCode.OK, null) {
                    Headers = response.Headers,
                    ContentObj = result.id
                };
            }
        }

        public async Task<BaseResponse<ProjectMailResponse>> PutWithReturnObjectAsync(string pRequestUri,
            HttpContent pContent)
        {
            var response = await PutAsync(pRequestUri, pContent);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                    var message = GetError(new StreamReader(responseStream).ReadToEnd());
                    return new BaseResponse<ProjectMailResponse>(response.StatusCode, null) {
                        Error = new Exception(message)
                    };
                }

            using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                var result = (PostResponse) JsonConvert.DeserializeObject(jsonMessage, typeof(PostResponse));
                if (!string.IsNullOrEmpty(result.Message))
                    return new BaseResponse<ProjectMailResponse>(HttpStatusCode.BadRequest, null) {
                        Content = result.Message
                    };
                return new BaseResponse<ProjectMailResponse>(HttpStatusCode.OK, null) {ContentObj = result.id};
            }
        }

        public async Task<BaseResponse<bool>> PutWithReturnAsync(string pRequestUri, HttpContent pContent)
        {
            var response = await PutAsync(pRequestUri, pContent);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                    var message = GetError(new StreamReader(responseStream).ReadToEnd());
                    return new BaseResponse<bool>(response.StatusCode, null) {Error = new Exception(message)};
                }

            using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                var result = (PostResponse) JsonConvert.DeserializeObject(jsonMessage, typeof(PostResponse));
                if (!string.IsNullOrEmpty(result.Message))
                    return new BaseResponse<bool>(HttpStatusCode.BadRequest, null) {Content = result.Message};
                return new BaseResponse<bool>(HttpStatusCode.OK, null) {ContentObj = result.id};
            }
        }

        public string GetError(string pContent)
        {
            var error = JsonConvert.DeserializeObject<ErrorResponse>(pContent);
            return error.Message;
        }

        public BaseResponse<T> Get<T>(string pEndpoint, Dictionary<string, string> pAramsDictionary,
            RequestFormat pFormat = RequestFormat.Json)
        {
            var data = GetAsync(pEndpoint).Result;
            if (!data.IsSuccessStatusCode) return new BaseResponse<T>(HttpStatusCode.InternalServerError);
            using (var responseStream = data.Content.ReadAsStreamAsync().Result) {
                var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                return new BaseResponse<T>(HttpStatusCode.OK) {
                    ContentObj = JsonConvert.DeserializeObject(jsonMessage, typeof(T))
                };
            }
        }
    }


    public class ClientCache
    {
        public List<ClientCacheEntry> data;

        public List<ClientCacheEntry> Data {
            get => data ?? (data = new List<ClientCacheEntry>());
            set => data = value;
        }


        public void AddEntry(string pID, string pData, DateTime pCreated, HttpResponseHeaders pHeaders,
            HttpStatusCode pStatus)
        {
            Data.Add(new ClientCacheEntry() {
                ID = pID,
                Data = pData,
                DateCreated = DateTime.Now,
                Headers = pHeaders,
                StatusCode = pStatus
            });
        }

        public ClientCacheEntry FindEntry(string pID)
        {
            var res = Data?.FirstOrDefault(p => p.ID == pID);
            if (res != null) {
                if (res.DateCreated.AddMinutes(5) < DateTime.Now)
                    Data.Remove(res);
                else
                    return res;
            }

            return null;
        }
    }

    public class ClientCacheEntry
    {
        public string Data;
        public DateTime DateCreated;
        public string ETAG;
        public HttpResponseHeaders Headers;
        public string ID;
        public HttpStatusCode StatusCode;
    }
}