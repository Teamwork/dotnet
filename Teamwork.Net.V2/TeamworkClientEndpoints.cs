#region FileHeader
// ==========================================================
// File:            TeamworkProjects.TeamworkClientEndpoints.cs
// Last Mod:        18.07.2016
// Created:         24.05.2016
// Created By:      Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  24.05.2016 - Created
//  18.7.2016  - TCA - Added TimeHandler
//  ==========================================================
#endregion

#region Imports

using System.ComponentModel;
using TeamworkProjects.Endpoints;
using TeamWorkNet.Handler;

#endregion

namespace TeamworkProjects
{
    /// <summary>
    /// Main entry point for the API
    /// </summary>
    public partial class Client
    {
        private ProjectHandler projects;
        private TimeHandler time;
        private MeHandler me;
        private TodoListHandler todolists;
        private CompanyHandler companies;
        private CategoryHandler categories;
        private FileHandler files;

        public ProjectHandler Projects => projects ?? (projects = new ProjectHandler(this));
        public TimeHandler Time => time ?? (time = new TimeHandler(this));
        public MeHandler Me => me ?? (me = new MeHandler(this));
        public TodoListHandler TodoLists => todolists ?? (todolists = new TodoListHandler(this));
        public CompanyHandler Companies => companies ?? (companies = new CompanyHandler(this));
        public CategoryHandler Categories => categories ?? (categories = new CategoryHandler(this));
        public FileHandler Files => files ?? (files = new FileHandler(this));
    }
}
