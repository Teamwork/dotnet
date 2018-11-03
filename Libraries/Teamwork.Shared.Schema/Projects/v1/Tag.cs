// ==========================================================
// File: TeamworkProjects.Base.Tag.cs
// Created: 30.05.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using Newtonsoft.Json;

namespace TeamworkProjects.Base.Model
{
    [Serializable]
  public class Tag
  {
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string color;

    [JsonIgnore]
    public string Color
    {
      get { return color; }
      set
      {
        if (
            value.Contains("#d84640") 
            || value.Contains("#f78234") 
            || value.Contains("#f4bd38") 
            || value.Contains("#b1da34") 
            || value.Contains("#53c944")
            || value.Contains("#37ced0")
            || value.Contains("#2f8de4")
            || value.Contains("#9b7cdb")
            || value.Contains("#f47fbe")
            || value.Contains("#a6a6a6")
            || value.Contains("#4d4d4d")
            || value.Contains("#9e6957")
            )
        {
          color = value;
        }
        else
        {
          throw new Exception("Color is not supported, please use only #d84640,#f78234,#f4bd38,#b1da34,#53c944,#37ced0,#2f8de4,#9b7cdb,#f47fbe,#a6a6a6,#4d4d4d,#9e6957");
        }

      }
    }




    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string ID { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
  }
}