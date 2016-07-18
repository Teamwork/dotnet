#region FileHeader
// ==========================================================
// File: TeamworkProjects.Base.TeamWorkHTTPRequest.cs
// Last Mod:      23.05.2016
// Created:        23.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  23.05.2016 - Created
//  ==========================================================
#endregion

using System;
using TeamworkProjects.Endpoints;
using TeamworkProjects.HTTPClient;


namespace TeamworkProjects
{
    /// <summary>
    /// Main entry point for the API
    /// </summary>
    public partial class Client
    {
        public ProjectHandler Projects => projects ?? (projects = new ProjectHandler(this));
        private ProjectHandler projects;

        public TimeHandler Time => time ?? (time = new TimeHandler(this));
        private TimeHandler time;


    }
}
