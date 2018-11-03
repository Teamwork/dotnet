// ==========================================================
// File: TeamworkProjects.Portable.Category.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Teamwork.Shared.Schema.Projects.V1
{
  public class Category
  {
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("elements_count", NullValueHandling = NullValueHandling.Ignore)]
    public string ElementsCount { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("parent-id", NullValueHandling = NullValueHandling.Ignore)]
    public string ParentId { get; set; }

        [JsonIgnore]
        public string ParentName { get; set; }
        [JsonIgnore]
        public bool HasChildren { get; set; }
        [JsonIgnore]
        public List<Category> Children { get; set; }

    }
}