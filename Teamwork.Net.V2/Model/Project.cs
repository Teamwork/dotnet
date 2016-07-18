#region FileHeader
// ==========================================================
// File:            TeamworkProjects.Project.cs
// Last Mod:        18.07.2016
// Created:         24.05.2016
// Created By:      Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  24.05.2016 - Created
//  ==========================================================
#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TeamworkProjects.Base.Model;
using TeamworkProjects.Extensions.DateTime;

#endregion

namespace TeamworkProjects.Model
{

  public partial class Project : TeamworkObjectBase
  {
      [JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
    public string lastChangedOn;

      public Company company { get; set; }
      public bool starred { get; set; }

      [JsonProperty(PropertyName = "show-announcement")]
    public bool ShowAnnouncement { get; set; }

      public string announcement { get; set; }

      public string status { get; set; }
      public bool isProjectAdmin { get; set; }

      [JsonProperty(PropertyName = "created-on")]
    public string createdon { get; set; }

      public Category category { get; set; }

      [JsonProperty(PropertyName = "start-page ")]
    public string Startpage { get; set; }


      public string logo { get; set; }
      public bool notifyeveryone { get; set; }


      public string endDate { get; set; }


      public string startDate { get; set; }


      public Permissions permissions { get; set; }

      public List<Milestone> Milestones { get; set; }
      public List<TodoList> Tasklists { get; set; }
      public List<Person> People { get; set; }

      public string CalendarItemID { get; set; }

      [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
    public Tag[] Tags { get; set; }


      // -- Ignored by Serialization --

      [JsonIgnore]
    public DateTime EndDate => endDate.ToDateTimeExactMax("yyyy-MM-ddTHH:mm:ssZ");

      [JsonIgnore]
    public DateTime StartDate => startDate.ToDateTimeExactMin("yyyy-MM-ddTHH:mm:ssZ");

      [JsonIgnore]
    public DateTime LastChangedOn => DateTime.Parse(lastChangedOn);

      [JsonIgnore]
    public double TaskCount
    {
      get
      {
        if (Tasklists == null) return 0;
        return Tasklists.Sum(p => p.TodoItems.Count());
      }
    }

      [JsonIgnore]
    public double TaskCountCompleted
    {
      get
      {
        if (Tasklists == null) return 0;
        return Tasklists.Sum(p => p.TodoItems.Count(i => i.Completed));
      }
    }

      [JsonIgnore]
    public int MilestoneCount
    {
      get
      {
        if (Milestones == null) return 0;
        return Milestones.Count();
      }
    }

      [JsonIgnore]
    public int MilestoneCountCompleted
    {
      get
      {
        if (Milestones == null) return 0;
        return Milestones.Count(p=>p.Completed);
      }
    }

      [JsonIgnore]
    public double Progress
    {
      get
      {
        if (TaskCountCompleted > 0) return Math.Round(TaskCountCompleted / TaskCount * 100,0);
        return 0;
      }
    }

      [JsonIgnore]
    public Milestone UpcomingMilestone
    {
      get
      {
        return Milestones?.OrderBy(p => p.Deadline).Take(1).First();
      }

    }

      [JsonIgnore]
    private DateTime lastSynchronized { get; set; }

      [JsonIgnore]
    public DateTime LastSynchronized
    {
      get { return lastSynchronized; }
      set { lastSynchronized = value; }

    }
  }
}