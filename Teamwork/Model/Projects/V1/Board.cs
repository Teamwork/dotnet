// ==========================================================
// File: TeamworkProjects.Portable.Account.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Teamwork.Model.Projects.V1
{
    public class Settings
    {
        public bool avatar { get; set; }
        public bool time { get; set; }
        public bool name { get; set; }
        public bool files { get; set; }
        public bool comments { get; set; }
        public bool progress { get; set; }
        public bool priority { get; set; }
        public bool tasklist { get; set; }
        public bool @private { get; set; }
        public bool reminders { get; set; }
        public bool assignee { get; set; }
        public bool dependencies { get; set; }
        public bool tags { get; set; }
        public bool estimatedtime { get; set; }
        public bool startdate { get; set; }
        public bool tickets { get; set; }
        public bool followers { get; set; }
        public bool recurring { get; set; }
        public bool enddate { get; set; }
    }

    public class DefaultTasklist
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Column
    {
        public string name { get; set; }
        public string displayOrder { get; set; }
        public string sortOrder { get; set; }
        public string deletedDate { get; set; }
        public string dateUpdated { get; set; }
        public Settings settings { get; set; }
        public DefaultTasklist defaultTasklist { get; set; }
        public string projectId { get; set; }
        public string sort { get; set; }
        public bool canEdit { get; set; }
        public string id { get; set; }
        public string dateCreated { get; set; }
        public string color { get; set; }
        public bool deleted { get; set; }
    }


    public class RootObject
    {
        public List<Column> columns { get; set; }
        public string STATUS { get; set; }
    }
}
