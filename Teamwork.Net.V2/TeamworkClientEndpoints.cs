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

using TeamworkProjects.Endpoints;

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

        public ProjectHandler Projects => projects ?? (projects = new ProjectHandler(this));
        public TimeHandler Time => time ?? (time = new TimeHandler(this));
    }
}
