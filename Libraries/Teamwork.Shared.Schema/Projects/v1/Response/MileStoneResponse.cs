// ==========================================================
// File: Teamwork.Client.MileStoneResponse.cs
// Created: 2018.11.03
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using Newtonsoft.Json;

#endregion

namespace Teamwork.Shared.Schema.Projects.V1.Response
{
    public partial class MileStoneResponse
    {
        [JsonProperty("milestone")] public Milestone Milestone { get; set; }
    }
}