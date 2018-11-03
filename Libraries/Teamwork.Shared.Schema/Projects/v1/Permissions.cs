// ==========================================================
// File: TeamworkProjects.Portable.Permissions.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;
using TeamworkProjects.Helper;

namespace Teamwork.Shared.Schema.Projects.V1
{
  public class Permissions
  {
   [JsonConverter(typeof(MyBooleanConverter))]
   [JsonProperty("can-manage-people", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CanManagePeople { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("can-access-templates", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanAccessTemplates { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("can-add-projects", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CanAddProjects { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-tasks", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddTasks { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-time", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewTime { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-messages", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddMessages { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-messages-and-files", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewMessagesAndFiles { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-estimated-time", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewEstimatedTime { get; set; }

        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-tasks-and-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewTasksAndMilestones { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-links", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddLinks { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-notebooks", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewNotebooks { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-invoices", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewInvoices { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("edit-all-tasks", NullValueHandling = NullValueHandling.Ignore)]
    public bool? EditAllTasks { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("set-privacy", NullValueHandling = NullValueHandling.Ignore)]
    public bool? SetPrivacy { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddMilestones { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-time", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddTime { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-all-time-logs", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewAllTimeLogs { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-taskLists", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddTaskLists { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("project-administrator", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ProjectAdministrator { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("can-be-assigned-to-tasks-and-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CanBeAssignedToTasksAndMilestones { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-links", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewLinks { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-files", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddFiles { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("can-receive-email", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CanReceiveEmail { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-notebooks", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddNotebooks { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("add-people-to-project", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AddPeopleToProject { get; set; }
        [JsonConverter(typeof(MyBooleanConverter))]
        [JsonProperty("view-risk-register", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ViewRiskRegister { get; set; }

  }
}