// ==========================================================
// File: TeamworkProjects.Base.ProjectsResponse.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;
using  Teamwork;
using Teamwork.Model.Projects.V1;

namespace Teamwork.Response
{
  public class ProjectResponse
  {
    public string STATUS { get; set; }
    public Project project { get; set; }
  }
}