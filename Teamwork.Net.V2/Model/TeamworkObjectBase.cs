// ==========================================================
// File: TeamworkProjects.Portable.TeamworkObjectBase.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================
// ReSharper disable UnusedAutoPropertyAccessor.Local

using Newtonsoft.Json;


namespace TeamworkProjects.Model
{
  public class TeamworkObjectBase
  {
    private string id { get; set; }


    // --- Public properties --- 

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string description { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }


    // --- Ignored by Serialization ---
    [JsonIgnore] public int ID => int.Parse(id);

  }
}