// ==========================================================
// File: TeamworkProjects.Base.Activity.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace  TeamworkProjects.Model
{
  public class Activity
  {
    [JsonProperty(PropertyName = "project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }
    [JsonProperty(PropertyName = "itemid", NullValueHandling = NullValueHandling.Ignore)]
    public string itemid { get; set; }

    [JsonProperty(PropertyName = "todo-list-name", NullValueHandling = NullValueHandling.Ignore)]
    public string todoListName { get; set; }
    public string description { get; set; }
    public string forusername { get; set; }
    public string publicinfo { get; set; }
    public string foruserid { get; set; }
    public string itemlink { get; set; }
    public string datetime { get; set; }

    public DateTime DateTime => DateTime.ParseExact(datetime, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.CurrentCulture);


    public string activitytype { get; set; }

    [JsonProperty(PropertyName = "project-name", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectName { get; set; }

    public string link { get; set; }
    public string extradescription { get; set; }
    public string isprivate { get; set; }
    public string id { get; set; }

    [JsonProperty(PropertyName = "due-date", NullValueHandling = NullValueHandling.Ignore)]
    public string DueDate { get; set; }

    public string fromusername { get; set; }
    public string type { get; set; }

    [JsonProperty(PropertyName = "from-user-avatar-url", NullValueHandling = NullValueHandling.Ignore)]
    public string FromUserAvatarURL { get; set; }

    [JsonProperty(PropertyName = "for-user-avatar-url", NullValueHandling = NullValueHandling.Ignore)]
    public string ForUserAvatarURL { get; set; }

    public string userid { get; set; }
  }

  public class ActivityResponse
  {
    public List<Activity> activity { get; set; }
    public string STATUS { get; set; }
  }
}