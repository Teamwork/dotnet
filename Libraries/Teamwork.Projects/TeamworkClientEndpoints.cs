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
using Teamwork.Projects.Endpoints;
using Teamwork.Projects.Handler;
using TeamworkProjects.Endpoints;
using Teamwork.Shared.Schema.Projects.V1;
using TeamWorkNet.Handler;

#endregion

namespace Teamwork.Client
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
        private TagHandler tags;
        private TaskHandler tasks;
        private PeopleHandler people;
        private BoardsHandler boards;
		private ChatHandler chat;



		public ProjectHandler Projects => projects ?? (projects = new ProjectHandler(this));
        public TimeHandler Time => time ?? (time = new TimeHandler(this));
        public MeHandler Me => me ?? (me = new MeHandler(this));
        public TodoListHandler TodoLists => todolists ?? (todolists = new TodoListHandler(this));
        public CompanyHandler Companies => companies ?? (companies = new CompanyHandler(this));
        public CategoryHandler Categories => categories ?? (categories = new CategoryHandler(this));
        public FileHandler Files => files ?? (files = new FileHandler(this));
        public TagHandler Tags => tags ?? (tags = new TagHandler(this));
        public TaskHandler Tasks => tasks ?? (tasks = new TaskHandler(this));
        public PeopleHandler People => people ?? (people = new PeopleHandler(this));
        public BoardsHandler Boards => boards ?? (boards = new BoardsHandler(this));
		public ChatHandler Chat => chat ?? (chat = new ChatHandler(this));
	}
}
