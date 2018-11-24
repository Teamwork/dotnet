// ==========================================================
// File: TeamworkProjects.Base.TimeEntriesResponse.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;
using  TeamworkProjects.Model;

namespace TeamworkProjects.Response
{
  public class TimeEntriesResponse
  {
    [JsonProperty("time-entries")]
    public TimeEntry[] TimeEntries { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }
}