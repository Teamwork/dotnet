#region FileHeader
// ==========================================================
// File: Teamwork.Net.V2.TeamworkProjects.ErrorResponse.cs
// Last Mod:      23.05.2016
// Created:        23.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  23.05.2016 - Created
//  ==========================================================
#endregion

using Newtonsoft.Json;


namespace Teamwork.Shared.Common.Exceptions
{
    public class ErrorResponse
    {
        [JsonProperty("STATUS")]
        public string Status { get; set; }

        [JsonProperty("MESSAGE")]
        public string Message { get; set; }
    }
}
