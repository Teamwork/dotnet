// ==========================================================
// File: TeamworkProjects.Base.MileStonesResponse.Isprivate2.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace Teamwork.Response
{
  public partial class MileStonesResponse
  {
    public class Isprivate2
    {
      [JsonProperty("deprecated")]
      public bool Deprecated { get; set; }
    }
  }
}