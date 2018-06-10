// ==========================================================
// File: TeamworkProjects.Base.TodoList.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Teamworks.Base.Model;

namespace Teamwork.Model.Projects.V1
{
    public class TodoList
    {
        [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
        public int ProjectId { get; set; }

        [JsonProperty("todo-items", NullValueHandling = NullValueHandling.Ignore)]
        public List<TodoItem> TodoItems { get; set; }

        [JsonProperty("grant-access-to", NullValueHandling = NullValueHandling.Ignore)]
        public string GrantAccessTo { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("milestone-id", NullValueHandling = NullValueHandling.Ignore)]
        public string MilestoneId { get; set; }

        [JsonProperty("uncompleted-count", NullValueHandling = NullValueHandling.Ignore)]
        public string UncompletedCount { get; set; }

        [JsonProperty("newTaskDefaults", NullValueHandling = NullValueHandling.Ignore)]
        public NewTaskDefaults newTaskDefaults { get; set; }

        [JsonProperty("lockdownId", NullValueHandling = NullValueHandling.Ignore)]
        public int lockdownId { get; set; }


        public bool Complete
        {
            get { return _complete == "1"; }
            set { _complete = value ? "1" : "0"; }
        }

        [JsonProperty("complete", NullValueHandling = NullValueHandling.Ignore)]
        public string _complete { get; set; }


        public bool Private
        {
            get { return _private == "1" || _private == "true"; }
            set { _private = value ? "1" : "0"; }
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



        [JsonProperty("todo-list-template-id", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get; set; }

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



    public class NewTaskDefaults
    {
        [JsonProperty("grantAccessTo", NullValueHandling = NullValueHandling.Ignore)]
        public string grantAccessTo { get; set; }

        [JsonProperty("dueDateOffset", NullValueHandling = NullValueHandling.Ignore)]
        public double? dueDateOffset { get; set; }

        [JsonProperty("estimated-minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int estimatedminutes { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string content { get; set; }

        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public string priority { get; set; }

        [JsonProperty("defaultsTaskId", NullValueHandling = NullValueHandling.Ignore)]
        public int defaultsTaskId { get; set; }

        [JsonProperty("viewEstimatedTime", NullValueHandling = NullValueHandling.Ignore)]
        public bool viewEstimatedTime { get; set; }

        [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
        public int Isprivate { get; set; }

        [JsonProperty("startDateOffset", NullValueHandling = NullValueHandling.Ignore)]
        public double? startDateOffset { get; set; }

        [JsonProperty("lockdownId", NullValueHandling = NullValueHandling.Ignore)]
        public string lockdownId { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Tag> tags { get; set; }

        [JsonProperty("responsible-party-ids", NullValueHandling = NullValueHandling.Ignore)]
        public string responsiblepartyids { get; set; }

        [JsonProperty("responsible-party-summary ", NullValueHandling = NullValueHandling.Ignore)]
        public string responsiblepartysummary { get; set; }

        [JsonProperty("responsible-party-names", NullValueHandling = NullValueHandling.Ignore)]
        public string responsiblepartynames { get; set; }

    }
}