// ==========================================================
// File: TeamworkProjects.User.cs
// Created: 2018.11.04
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;
using Newtonsoft.Json;

#endregion

namespace Teamwork.Shared.Schema.Spaces
{
    public partial class User
    {
        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
        public string Firstname { get; set; }

        [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastname { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Avatar { get; set; }

        [JsonProperty("isAdmin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAdmin { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public State? State { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public TedBy CreatedBy { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public TedBy UpdatedBy { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("deletedBy", NullValueHandling = NullValueHandling.Ignore)]
        public TedBy DeletedBy { get; set; }

        [JsonProperty("deletedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DeletedAt { get; set; }
    }
}