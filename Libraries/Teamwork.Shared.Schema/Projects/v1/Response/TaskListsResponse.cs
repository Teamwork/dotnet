// ==========================================================
// File: TeamworkProjects.Base.TaskListsResponse.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;
using Newtonsoft.Json;
using Teamwork.Shared.Schema.Projects.V1;

namespace Teamwork.Projects.Schema.V1.Response
{
  public class TaskListsResponse
  {
    [JsonProperty("todo-lists")]
    public List<TodoList> TodoLists { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }
  public class TaskListResponse
  {
    [JsonProperty("todo-list")]
    public TodoList TodoList { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }

  public class TodoItemsResponse
  {
    [JsonProperty("todo-items")]
    public List<TodoItem> TodoLists { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }

    [JsonIgnore]
    public int TotalRecords { get; set; }
    [JsonIgnore]
    public int Pages { get; set; }
    [JsonIgnore]
    public int Page { get; set; }

  }


  public class TodoItemResponse
  {
    [JsonProperty("todo-item")]
    public TodoItem TodoItem { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }

}