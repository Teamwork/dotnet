// ==========================================================
// File: Teamwork.ClockinResponse.cs
// Created: 2019.02.13
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System.Collections.Generic;
using Newtonsoft.Json;
using Teamwork.Shared.Schema.Projects.V1;

#endregion

namespace Teamwork.Shared.Schema.Projects.v1.Response
{
    public partial class ClockinsResponse
    {
        [JsonProperty("clockIns", NullValueHandling = NullValueHandling.Ignore)]
        public List<ClockIn> ClockIns { get; set; }

        [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}