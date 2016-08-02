// ==========================================================
// File: TeamworkProjects.Portable.Notebook.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
    using TeamworkProjects.Base.Model;

    public class Notebook
  {
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string Content { get; set; }

    [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public string Private { get; set; }

    [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryId { get; set; }

    [JsonProperty("category-name", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryName { get; set; }

    [JsonProperty("created-date", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedDate { get; set; }

    [JsonProperty("created-by-userId", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedByUserId { get; set; }

    [JsonProperty("created-by-userfirstname", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedByUserfirstname { get; set; }

    [JsonProperty("created-by-userlastname", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedByUserlastname { get; set; }

    [JsonProperty("locked", NullValueHandling = NullValueHandling.Ignore)]
    public string Locked { get; set; }

    [JsonProperty("locked-date", NullValueHandling = NullValueHandling.Ignore)]
    public string LockedDate { get; set; }

    [JsonProperty("locked-by-userid", NullValueHandling = NullValueHandling.Ignore)]
    public string LockedByUserid { get; set; }

    [JsonProperty("locked-by-userfirstname", NullValueHandling = NullValueHandling.Ignore)]
    public string LockedByUserfirstname { get; set; }

    [JsonProperty("locked-by-userlastname", NullValueHandling = NullValueHandling.Ignore)]
    public string LockedByUserlastname { get; set; }

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }



        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public Tag[] tags { get; set; }
    }
}