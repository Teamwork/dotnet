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
using Teamwork.Endpoints;
using Teamwork.Handler;
using TeamworkProjects.Endpoints;
using TeamWork.Handler;

#endregion

namespace Teamwork
{
    /// <summary>
    /// Main entry point for the API
    /// </summary>
    public partial class Client
    {
        private ProjectsAPI projects;
        public ProjectsAPI Projects => projects ?? (projects = new ProjectsAPI(this));
    }


    public class ProjectsAPI
    {

        private Client client { get; set; }

        public ProjectsAPI(Client pClient)
        {
            client = pClient;
        }

        private ProjectHandler projects;
        private TimeHandler time;
        private MeHandler me;
        private TodoListHandler todolists;
        private CompanyHandler companies;
        private CategoryHandler categories;
        private TagHandler tags;
        private TaskHandler tasks;
        private PeopleHandler people;
        private BoardsHandler boards;
        private ChatHandler chat;
        private ReactionHandler reactions;


        public ProjectHandler Projects => projects ?? (projects = new ProjectHandler(client));
        public TimeHandler Time => time ?? (time = new TimeHandler(client));
        public MeHandler Me => me ?? (me = new MeHandler(client));
        public TodoListHandler TodoLists => todolists ?? (todolists = new TodoListHandler(client));
        public CompanyHandler Companies => companies ?? (companies = new CompanyHandler(client));
        public CategoryHandler Categories => categories ?? (categories = new CategoryHandler(client));
        public TagHandler Tags => tags ?? (tags = new TagHandler(client));
        public TaskHandler Tasks => tasks ?? (tasks = new TaskHandler(client));
        public PeopleHandler People => people ?? (people = new PeopleHandler(client));
        public BoardsHandler Boards => boards ?? (boards = new BoardsHandler(client));
        public ChatHandler Chat => chat ?? (chat = new ChatHandler(client));
        public ReactionHandler Reactions => reactions ?? (reactions = new ReactionHandler(client));
    }
}
