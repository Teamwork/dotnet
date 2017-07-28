#region FileHeader
// ==========================================================
// File:         TeamworkProjects.TimeEntry.cs
// Last Mod:     18.07.2016
// Created:      24.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  24.05.2016 - Created
//  ==========================================================
#endregion

#region Imports

using Newtonsoft.Json;
using TeamworkProjects.Base.Model;

#endregion

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

    /// <summary>
    /// Use to add a new Time Entry
    /// </summary>
    public class NewTimeEntry
    {
        public string description { get; set; }

        [JsonProperty("person-id", NullValueHandling = NullValueHandling.Ignore)]
        public string person { get; set; }

        public string date { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public string time { get; set; }

        public string hours { get; set; }
        public string minutes { get; set; }
        public string isbillable { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string tags { get; set; }

        [JsonProperty("has-start-time", NullValueHandling = NullValueHandling.Ignore)]
        public string HasStartTime { get; set; }
    }
}