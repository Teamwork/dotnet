// ==========================================================
// File: TeamworkProjects.Base.TasksResponse.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;
using Teamwork.Projects.Base.Model;

namespace Teamwork.Shared.Schema.Projects.V1.Response
{
  public class TagResponse
  {
    [JsonProperty("tag")]
    public TodoItem Tag { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }

  public class TagsResponse
  {
    [JsonProperty("tags")]
    public Tag[] Tags { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }

}