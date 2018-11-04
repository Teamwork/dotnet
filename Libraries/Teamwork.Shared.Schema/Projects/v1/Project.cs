// ==========================================================
// File: Teamwork.Projects.Project.cs
// Created: 2018.11.03
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Teamwork.Projects.Base.Model;
using Teamwork.Shared.Common.Helper.DateTime;

#endregion

namespace Teamwork.Shared.Schema.Projects.V1
{
    public partial class Project : TeamworkObjectBase
    {

        public string PathSingle => $"/projects/{Id}.json";
        public string PathList => $"/projects.json";

        [JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
        public string lastChangedOn;

        public Company company { get; set; }
        public bool starred { get; set; }

        [JsonIgnore]
        public List<TimeEntry> TimEntries { get; set; }

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


        [JsonProperty(PropertyName = "active-pages")]
        public ProjectActivePages ActivePages { get; set; }

        public string logo { get; set; }
        public bool notifyeveryone { get; set; }


        public string endDate { get; set; }


        public string startDate { get; set; }


        public Permissions permissions { get; set; }

        public List<Milestone> Milestones { get; set; }
        public List<TodoList> Tasklists { get; set; }
        public List<Person> People { get; set; }

        [JsonIgnore]
        public List<Category> NotebookCategories { get; set; }

        [JsonIgnore]
        public List<Category> MessageCategories { get; set; }

        [JsonIgnore]
        public List<Category> LinkCategories { get; set; }

        [JsonIgnore]
        public List<Category> FileCategories { get; set; }

        public string CalendarItemID { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public Tag[] Tags { get; set; }


        // -- Ignored by Serialization --

        [JsonIgnore]
        public DateTime EndDate => endDate.ToDateTimeExactMax("yyyyMMdd");

        [JsonIgnore]
        public DateTime StartDate => startDate.ToDateTimeExactMin("yyyyMMdd");

        [JsonIgnore]
        public DateTime LastChangedOn => !string.IsNullOrEmpty(lastChangedOn) ? DateTime.Parse(lastChangedOn) : DateTime.MinValue;

        [JsonIgnore]
        public double TaskCount {
            get {
                if (Tasklists == null) return 0;
                var counter = 0;
                foreach (var list in Tasklists) {
                    if (list.TodoItems == null) continue;
                    if (list.TodoItems.Count == 0) continue;
                    counter += list.TodoItems.Count;
                    counter += CountSubTasks(list.TodoItems.Where(p => p.SubTasks != null).ToList());
                }

                return counter;
            }
        }

        [JsonIgnore]
        public double TaskCountCompleted {
            get {
                if (Tasklists == null) return 0;
                var counter = 0;
                foreach (var list in Tasklists) {
                    if (list.TodoItems == null) continue;
                    if (list.TodoItems.Count == 0) continue;
                    counter += list.TodoItems.Count(p => p.Completed);
                    counter += CountSubTasks(list.TodoItems.Where(p => p.SubTasks != null).ToList());
                }

                return counter;
            }
        }

        [JsonIgnore]
        public int MilestoneCount {
            get {
                if (Milestones == null) return 0;
                return Milestones.Count();
            }
        }

        [JsonIgnore]
        public int MilestoneCountCompleted {
            get {
                if (Milestones == null) return 0;
                return Milestones.Count(p => p.Completed);
            }
        }

        [JsonIgnore]
        public double Progress {
            get {
                if (TaskCountCompleted > 0) return Math.Round(TaskCountCompleted / TaskCount);


                foreach (var list in this.Tasklists) { }


                return 0;
            }
        }

        [JsonIgnore]
        public Milestone UpcomingMilestone {
            get { return Milestones?.OrderBy(p => p.Deadline).Take(1).First(); }
        }

        [JsonIgnore]
        private DateTime lastSynchronized { get; set; }

        [JsonIgnore]
        public DateTime LastSynchronized {
            get => lastSynchronized;
            set => lastSynchronized = value;
        }


        public int CountSubTasks(List<TodoItem> listSource, bool onlyCompleted = false)
        {
            var counter = 0;
            if (onlyCompleted) {
                counter += listSource.Count(p => p.Completed);
                counter += listSource.Where(p => p.SubTasks != null).Sum(sub => CountSubTasks(sub.SubTasks));
            }
            else {
                counter += listSource.Count;
                counter += listSource.Where(p => p.SubTasks != null).Sum(sub => CountSubTasks(sub.SubTasks));
            }

            return counter;
        }


        public override string ToString()
        {
            return this.Name;
        }
    }


    public class ProjectActivePages
    {
        public string links { get; set; }
        public string tasks { get; set; }
        public string time { get; set; }
        public string billing { get; set; }
        public string notebooks { get; set; }
        public string files { get; set; }
        public string riskRegister { get; set; }
        public string milestones { get; set; }
        public string messages { get; set; }
    }
}