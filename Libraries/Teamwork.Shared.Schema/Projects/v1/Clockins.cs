// ==========================================================
// File: Teamwork.Clockins.cs
// Created: 2019.02.13
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Teamwork.Schema.Projects.V2;

#endregion

namespace Teamwork.Shared.Schema.Projects.V1
{
    public partial class ClockIn
    {
        [JsonProperty("clockInDatetime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ClockInDatetime { get; set; }

        [JsonProperty("updatedDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedDateTime { get; set; }

        [JsonProperty("clockOutDatetime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ClockOutDatetime { get; set; }

        [JsonProperty("clockInSource", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockInSource { get; set; }

        [JsonProperty("clockOutInfo", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockOutInfo { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }

        [JsonProperty("clockInInfo", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockInInfo { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("clockOutSource", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockOutSource { get; set; }

        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? UserId { get; set; }
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            },
        };
    }

}