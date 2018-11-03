// ==========================================================
// File: TeamworkProjects.Base.ProjectsResponse.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;
using  Teamwork.Shared.Schema.Projects.V1;

namespace Teamwork.Shared.Schema.Projects.V1.Response
{
  public class ProjectResponse
  {
    public string STATUS { get; set; }
    public Project project { get; set; }
  }
}