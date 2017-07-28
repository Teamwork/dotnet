#region FileHeader
// ==========================================================
// File: Teamwork.Net.V2.TeamworkProjects.HttpClientOverrides.cs
// Last Mod:      24.05.2016
// Created:        23.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  23.05.2016 - Created
//  ==========================================================
#endregion
#region Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkProjects.Generic;
using TeamworkProjects.Response;

#endregion

namespace TeamworkProjects.HTTPClient
{
    using System.Linq;

    public partial class AuthorizedHttpClient : HttpClient
  {
      public async Task<BaseListResponse<T>> GetListAsync<T>(string pEndpoint,string pObjName, Dictionary<string, string> pParamsDictionary,RequestFormat pFormat = RequestFormat.Json)
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
  }


  public static class GetExtension
  {
      public static BaseResponse<T> Get<T>(this T obj, string endpoint, Dictionary<string, string> paramsDictionary, RequestFormat format = RequestFormat.Json)
    {
      throw new NotImplementedException("Not Implemented yet");
    }
  }
}


//public async Task<BaseResponse<ProjectMailResponse>> PutWithReturnObjectAsync(string requestUri, HttpContent content)
//{

//    var response = await PutAsync(requestUri, content);
//    if (response.StatusCode == HttpStatusCode.InternalServerError)
//    {
//        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
//        {
//            var message = GetError(new StreamReader(responseStream).ReadToEnd());
//            return new BaseResponse<ProjectMailResponse>(response.StatusCode, null) { Error = new Exception(message) };
//        }
//    }

//    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
//    {
//        string jsonMessage = new StreamReader(responseStream).ReadToEnd();
//        var result = (AddResponse)JsonConvert.DeserializeObject(jsonMessage, typeof(AddResponse));
//        if (!string.IsNullOrEmpty(result.Message))
//        {
//            return new BaseResponse<ProjectMailResponse>(HttpStatusCode.BadRequest, null) { Content = result.Message };
//        }
//        return new BaseResponse<ProjectMailResponse>(HttpStatusCode.OK, null) { ContentObj = result.id };
//    }

//}