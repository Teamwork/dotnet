// ==========================================================
// File: TeamworkProjects.Portable.Link.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
  public class Link : TeamworkObjectBase
  {

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }

    [JsonProperty("created-by-userfirstname", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedByUserfirstname { get; set; }

    [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
    public string Height { get; set; }

    [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public string Private { get; set; }

    [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
    public string Width { get; set; }

    [JsonProperty("created-by-userId", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedByUserId { get; set; }

    [JsonProperty("created-by-userlastname", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedByUserlastname { get; set; }

    [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryId { get; set; }

    [JsonProperty("project-name", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectName { get; set; }

    [JsonProperty("open-in-new-window", NullValueHandling = NullValueHandling.Ignore)]
    public bool OpenInNewWindow { get; set; }

    [JsonProperty("provider", NullValueHandling = NullValueHandling.Ignore)]
    public string Provider { get; set; }

    [JsonProperty("created-date", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedDate { get; set; }

    [JsonProperty("category-name", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryName { get; set; }

    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }
  }
}