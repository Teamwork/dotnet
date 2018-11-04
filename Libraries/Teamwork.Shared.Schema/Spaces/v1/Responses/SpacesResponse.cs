// ==========================================================
// File: TeamworkProjects.SpacesResponse.cs
// Created: 2018.11.04
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace Teamwork.Shared.Schema.Spaces
{
    public partial class SpacesResponse
    {
        [JsonProperty("spaces", NullValueHandling = NullValueHandling.Ignore)]
        public List<Space> Spaces { get; set; }

        [JsonProperty("included", NullValueHandling = NullValueHandling.Ignore)]
        public Included Included { get; set; }
    }

    public partial class Included
    {
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, User> Users { get; set; }
    }

    public partial class TedBy
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type { get; set; }
    }

    public enum State
    {
        Active,
        Deleted
    };
}