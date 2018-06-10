// ==========================================================
// File: TeamworkProjects.Base.MileStonesResponse.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using Newtonsoft.Json;
using  Teamwork;

namespace Teamwork.Response
{
  public partial class MileStonesResponse
  {
    [JsonProperty("milestones")]
    public Milestone[] Milestones { get; set; }
    [JsonIgnore]
    public string Etag { get; set; }
    [JsonIgnore]
    public DateTime LastUpdate { get; set; }
    [JsonIgnore]
    public int TotalRecords { get; set; }
    [JsonIgnore]
    public int Pages { get; set; }
    [JsonIgnore]
    public int Page { get; set; }
  }
}