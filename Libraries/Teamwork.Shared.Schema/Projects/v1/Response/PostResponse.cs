// ==========================================================
// File: Teamwork.Client.PostResponse.cs
// Created: 2018.11.03
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using Newtonsoft.Json;
using Teamwork.Shared.Schema.Projects.V1;

#endregion

namespace Teamwork.Projects.Base.Response
{
    public class PostResponse
    {
        [JsonProperty("post")] public Post Post { get; set; }

        [JsonProperty("STATUS")] public string Status { get; set; }
    }

    public class PostsResponse
    {
        [JsonProperty("posts")] public Post[] Post { get; set; }

        [JsonProperty("STATUS")] public string Status { get; set; }
    }
}