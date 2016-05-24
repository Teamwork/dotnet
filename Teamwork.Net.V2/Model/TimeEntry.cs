// ==========================================================
// File: TeamworkProjects.Portable.TimeEntry.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
  public class TimeEntry
  {
    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }

    [JsonProperty("minutes", NullValueHandling = NullValueHandling.Ignore)]
    public string Minutes { get; set; }

    [JsonProperty("isbillable", NullValueHandling = NullValueHandling.Ignore)]
    public string Isbillable { get; set; }

    [JsonProperty("person-first-name", NullValueHandling = NullValueHandling.Ignore)]
    public string PersonFirstName { get; set; }

    [JsonProperty("todo-list-name", NullValueHandling = NullValueHandling.Ignore)]
    public string TodoListName { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("todo-item-name", NullValueHandling = NullValueHandling.Ignore)]
    public string TodoItemName { get; set; }

    [JsonProperty("todo-list-id", NullValueHandling = NullValueHandling.Ignore)]
    public string TodoListId { get; set; }

    [JsonProperty("company-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyId { get; set; }

    [JsonProperty("person-id", NullValueHandling = NullValueHandling.Ignore)]
    public string PersonId { get; set; }

    [JsonProperty("project-name", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectName { get; set; }

    [JsonProperty("company-name", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyName { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    public string Date { get; set; }

    [JsonProperty("todo-item-id", NullValueHandling = NullValueHandling.Ignore)]
    public string TodoItemId { get; set; }

    [JsonProperty("invoiceNo", NullValueHandling = NullValueHandling.Ignore)]
    public string InvoiceNo { get; set; }

    [JsonProperty("person-last-name", NullValueHandling = NullValueHandling.Ignore)]
    public string PersonLastName { get; set; }

    [JsonProperty("has-start-time", NullValueHandling = NullValueHandling.Ignore)]
    public string HasStartTime { get; set; }

    [JsonProperty("hours", NullValueHandling = NullValueHandling.Ignore)]
    public string Hours { get; set; }

  }

}