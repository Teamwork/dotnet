#region FileHeader
// ==========================================================
// File: Teamwork.Net.V2.TeamworkProjects.RequestFormat.cs
// Last Mod:      23.05.2016
// Created:        23.05.2016
// Created By:   Tim cadenbach
//  
// Copyright (C) 2016 Digital Crew Limited
// History:
//  23.05.2016 - Created
//  ==========================================================
#endregion
namespace TeamworkProjects.Generic
{
  public enum RequestFormat
  {
    /// <summary>
    ///   XML format
    /// </summary>
    Xml,

    /// <summary>
    ///   JSON format
    /// </summary>
    Json,

    /// <summary>
    ///   Protocol Buffer format
    /// </summary>
    ProtoBuf,

    /// <summary>
    ///   Comma-separated format
    /// </summary>
    Csv,

    CustomBinary
  }
}