// ==========================================================
// File: TeamworkProjects.Portable.Milestone.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.Base;
using TeamworkProjects.Base.Model;
using TeamworkProjects.Extensions.DateTime;

namespace Teamwork.Shared.Schema.Projects.V1
{
  public class Milestone
  {
    [JsonIgnore]
    public string notify { get; set; }

    [JsonIgnore]
    public string CalendarItemID { get; set; }

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }

    [JsonProperty("canComplete", NullValueHandling = NullValueHandling.Ignore)]
    public bool CanComplete { get; set; }

    [JsonProperty("responsible-party-id", NullValueHandling = NullValueHandling.Ignore)]
    public string ResponsiblePartyId { get; set; }

    [JsonProperty("completer-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CompleterId { get; set; }

    [JsonProperty("comments-count", NullValueHandling = NullValueHandling.Ignore)]
    public string CommentsCount { get; set; }

    [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public bool Private { get; set; }

    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonProperty("completed-on", NullValueHandling = NullValueHandling.Ignore)]
    public string CompletedOn { get; set; }

    [JsonProperty("created-on", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedOn { get; set; }

    [JsonProperty("canEdit", NullValueHandling = NullValueHandling.Ignore)]
    public bool CanEdit { get; set; }

    [JsonProperty("responsible-party-type", NullValueHandling = NullValueHandling.Ignore)]
    public string ResponsiblePartyType { get; set; }

    [JsonProperty("isprivate", NullValueHandling = NullValueHandling.Ignore)]
    public string Isprivate { get; set; }

    [JsonProperty("company-name", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyName { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string id { get; set; }

    [JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
    public string lastChangedOn { get; set; }
    [JsonIgnore]
    public DateTime LastChangedOn
    {
      get { return DateTime.Parse(lastChangedOn); }
    }


        [JsonIgnore]
        public DateTime DeadLineDate => Deadline.ToDateTimeExactMax("yyyyMMdd");


        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
    public bool Completed { get; set; }

    [JsonProperty("reminder", NullValueHandling = NullValueHandling.Ignore)]
    public string Reminder { get; set; }

    [JsonProperty("tasklists", NullValueHandling = NullValueHandling.Ignore)]
    public object[] Tasklists { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("responsible-party-firstname", NullValueHandling = NullValueHandling.Ignore)]
    public string ResponsiblePartyFirstname { get; set; }

    [JsonProperty("completer-firstname", NullValueHandling = NullValueHandling.Ignore)]
    public string CompleterFirstname { get; set; }

    [JsonProperty("responsible-party-ids", NullValueHandling = NullValueHandling.Ignore)]
    public string ResponsiblePartyIds { get; set; }

    [JsonProperty("responsible-party-names", NullValueHandling = NullValueHandling.Ignore)]
    public string ResponsiblePartyNames { get; set; }

    [JsonProperty("responsible-party-lastname", NullValueHandling = NullValueHandling.Ignore)]
    public string ResponsiblePartyLastname { get; set; }

    [JsonProperty("company-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyId { get; set; }

    [JsonProperty("creator-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatorId { get; set; }

    [JsonProperty("completer-lastname", NullValueHandling = NullValueHandling.Ignore)]
    public string CompleterLastname { get; set; }

    [JsonProperty("project-name", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectName { get; set; }

    [JsonProperty("deadline", NullValueHandling = NullValueHandling.Ignore)]
    public string Deadline { get; set; }

    [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
    public Tag[] Tags { get; set; }
    
    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

  }
}