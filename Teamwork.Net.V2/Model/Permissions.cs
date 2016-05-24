// ==========================================================
// File: TeamworkProjects.Portable.Permissions.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
  public class Permissions
  {
    [JsonProperty("can-manage-people", NullValueHandling = NullValueHandling.Ignore)]
    public bool CanManagePeople { get; set; }

    [JsonProperty("can-add-projects", NullValueHandling = NullValueHandling.Ignore)]
    public bool CanAddProjects { get; set; }

    [JsonProperty("add-tasks", NullValueHandling = NullValueHandling.Ignore)]
    public string AddTasks { get; set; }

    [JsonProperty("view-time", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewTime { get; set; }

    [JsonProperty("add-messages", NullValueHandling = NullValueHandling.Ignore)]
    public string AddMessages { get; set; }

    [JsonProperty("view-messages-and-files", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewMessagesAndFiles { get; set; }

    [JsonProperty("view-estimated-time", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewEstimatedTime { get; set; }

    [JsonProperty("view-tasks-and-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewTasksAndMilestones { get; set; }

    [JsonProperty("add-links", NullValueHandling = NullValueHandling.Ignore)]
    public string AddLinks { get; set; }

    [JsonProperty("view-notebooks", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewNotebooks { get; set; }

    [JsonProperty("view-invoices", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewInvoices { get; set; }

    [JsonProperty("edit-all-tasks", NullValueHandling = NullValueHandling.Ignore)]
    public string EditAllTasks { get; set; }

    [JsonProperty("set-privacy", NullValueHandling = NullValueHandling.Ignore)]
    public string SetPrivacy { get; set; }

    [JsonProperty("add-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public string AddMilestones { get; set; }

    [JsonProperty("add-time", NullValueHandling = NullValueHandling.Ignore)]
    public string AddTime { get; set; }

    [JsonProperty("view-all-time-logs", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewAllTimeLogs { get; set; }

    [JsonProperty("add-taskLists", NullValueHandling = NullValueHandling.Ignore)]
    public string AddTaskLists { get; set; }

    [JsonProperty("project-administrator", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectAdministrator { get; set; }

    [JsonProperty("can-be-assigned-to-tasks-and-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public string CanBeAssignedToTasksAndMilestones { get; set; }

    [JsonProperty("view-links", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewLinks { get; set; }

    [JsonProperty("add-files", NullValueHandling = NullValueHandling.Ignore)]
    public string AddFiles { get; set; }

    [JsonProperty("can-receive-email", NullValueHandling = NullValueHandling.Ignore)]
    public string CanReceiveEmail { get; set; }

    [JsonProperty("add-notebooks", NullValueHandling = NullValueHandling.Ignore)]
    public string AddNotebooks { get; set; }

    [JsonProperty("add-people-to-project", NullValueHandling = NullValueHandling.Ignore)]
    public string AddPeopleToProject { get; set; }

    [JsonProperty("view-risk-register", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewRiskRegister { get; set; }

  }
}