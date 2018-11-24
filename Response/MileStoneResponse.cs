// ==========================================================
// File: TeamworkProjects.Base.MileStonesResponse.cs
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
  public partial class MileStoneResponse
  {
    [JsonProperty("milestone")]
    public Milestone Milestone { get; set; }
  }
}