// ==========================================================
// File: TeamworkProjects.Portable.Newproject.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
    using TeamworkProjects.Base.Model;

    public class Newproject
  {
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("companyId", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyId { get; set; }

    [JsonProperty("newCompany", NullValueHandling = NullValueHandling.Ignore)]
    public string NewCompany { get; set; }

    [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryId { get; set; }

    [JsonProperty("start-date", NullValueHandling = NullValueHandling.Ignore)]
    public string StartDate { get; set; }

    [JsonProperty("end-date", NullValueHandling = NullValueHandling.Ignore)]
    public string EndDate { get; set; }

    [JsonProperty("use-tasks", NullValueHandling = NullValueHandling.Ignore)]
    public string UseTasks { get; set; }

    [JsonProperty("use-milestones", NullValueHandling = NullValueHandling.Ignore)]
    public string UseMilestones { get; set; }

    [JsonProperty("use-messages", NullValueHandling = NullValueHandling.Ignore)]
    public string UseMessages { get; set; }

    [JsonProperty("use-files", NullValueHandling = NullValueHandling.Ignore)]
    public string UseFiles { get; set; }

    [JsonProperty("use-time", NullValueHandling = NullValueHandling.Ignore)]
    public string UseTime { get; set; }

    [JsonProperty("use-notebook", NullValueHandling = NullValueHandling.Ignore)]
    public string UseNotebook { get; set; }

    [JsonProperty("use-riskregister", NullValueHandling = NullValueHandling.Ignore)]
    public string UseRiskregister { get; set; }

    [JsonProperty("use-links", NullValueHandling = NullValueHandling.Ignore)]
    public string UseLinks { get; set; }

    [JsonProperty("use-billing", NullValueHandling = NullValueHandling.Ignore)]
    public string UseBilling { get; set; }

    [JsonProperty("start-page", NullValueHandling = NullValueHandling.Ignore)]
    public string StartPage { get; set; }

        [JsonProperty("People", NullValueHandling = NullValueHandling.Ignore)]
        public string People { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string tags { get; set; }

    }
}