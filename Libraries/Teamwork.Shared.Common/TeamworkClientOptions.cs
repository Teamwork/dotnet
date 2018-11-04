// ==========================================================
// File: Teamwork.Projects.TeamworkClientOptions.cs
// Created: 2018.11.03
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

namespace Teamwork.Shared.Common
{
    /// <summary>
    /// Configuration options for Teamwork Client
    /// </summary>
    public class TeamworkClientOptions
    {
        /// <summary>
        /// Lazyloading for child objects and arrays. Automatically load Tasklists and milestones for a project etc
        /// </summary>
        public bool LazyLoading { get; set; } = false;

        /// <summary>
        /// When an object does not have an ID set, .Update() will do a POST instead of Put to automatically create
        /// the item and get back the id. 
        /// </summary>
        public bool AutoPost { get; set; } = true;

        /// <summary>
        /// Cache entries and check etags before fetching new data, highly recommended as it prevents unnecessary requests
        /// </summary>
        public bool UseCaching { get; set; } = true;
    }
}