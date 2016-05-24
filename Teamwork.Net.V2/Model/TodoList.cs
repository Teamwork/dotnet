// ==========================================================
// File: TeamworkProjects.Base.TodoList.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using System.Linq;
using Newtonsoft.Json;

namespace  TeamworkProjects.Model
{
  public class TodoList
  {
    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }

    [JsonProperty("todo-items", NullValueHandling = NullValueHandling.Ignore)]
    public TodoItem[] TodoItems { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("milestone-id", NullValueHandling = NullValueHandling.Ignore)]
    public string MilestoneId { get; set; }

    [JsonProperty("uncompleted-count", NullValueHandling = NullValueHandling.Ignore)]
    public string UncompletedCount { get; set; }


    public bool Complete
    {
      get
      {
        return _complete == "1";
      }
      set
      {
        _complete = value ? "1" : "0";
      }
    }

    [JsonProperty("complete", NullValueHandling = NullValueHandling.Ignore)]
    public string _complete { get; set; }


    public bool Private
    {
      get
      {
        return _private == "1";
      }
      set
      {
        _private = value? "1" : "0";
      } 
    }
   [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public string _private { get; set; }

    [JsonProperty("overdue-count", NullValueHandling = NullValueHandling.Ignore)]
    public string OverdueCount { get; set; }

    [JsonProperty("project-name", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectName { get; set; }

    [JsonProperty("pinned", NullValueHandling = NullValueHandling.Ignore)]
    public bool Pinned { get; set; }

    [JsonProperty("tracked", NullValueHandling = NullValueHandling.Ignore)]
    public bool Tracked { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int Id { get; set; }

    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    public string Position { get; set; }

    [JsonProperty("completed-count", NullValueHandling = NullValueHandling.Ignore)]
    public string CompletedCount { get; set; }
    [JsonIgnore]
    public double TodolistProgress
    {
      get
      {
        var taskCount = TodoItems.Count();
        double taskProgress = TodoItems.Sum(task => double.Parse(task.Progress));
        return taskProgress/taskCount;
      }
    }



  }
}