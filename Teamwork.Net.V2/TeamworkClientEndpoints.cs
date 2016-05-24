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
        public ProjectHandler Projects
        {
            get
            {
                if(projects == null) projects = new ProjectHandler(this);
                return projects;
            }
        } 
        private ProjectHandler projects;

    }
}
