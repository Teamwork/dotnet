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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Teamwork.Shared.Common.Generic;
using Teamwork.Shared.Common.Response;
using Teamwork.Shared.Schema.Projects.V1.Response;

#endregion
namespace Teamwork
{
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