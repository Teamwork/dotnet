// ==========================================================
// File: TeamworkProjects.Portable.Role.cs
// Created: 24.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace Teamwork.Shared.Schema.Projects.V1
{
  public class Role
  {
    [JsonProperty("roleDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string RoleDescription { get; set; }

    [JsonProperty("roleId", NullValueHandling = NullValueHandling.Ignore)]
    public string RoleId { get; set; }

    [JsonProperty("roleName", NullValueHandling = NullValueHandling.Ignore)]
    public string RoleName { get; set; }

    [JsonProperty("people", NullValueHandling = NullValueHandling.Ignore)]
    public Person[] People { get; set; }
  }

  public class RoleResponse
  {
    [JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
    public Role[] Roles { get; set; }
  }
}