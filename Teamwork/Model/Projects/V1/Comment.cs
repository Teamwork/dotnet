// ==========================================================
// File: TeamworkProjects.Portable.Comment.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace Teamwork.Model.Projects.V1
{
  public class Comment
  {
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("commentable_type", NullValueHandling = NullValueHandling.Ignore)]
    public string CommentableType { get; set; }

    [JsonProperty("notify", NullValueHandling = NullValueHandling.Ignore)]
    public string Notify { get; set; }

    [JsonProperty("content-type", NullValueHandling = NullValueHandling.Ignore)]
    public string ContentType { get; set; }

    [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
    public string Body { get; set; }

    [JsonProperty("author_id", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorId { get; set; }

    [JsonProperty("author-firstname", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorFirstname { get; set; }

    [JsonProperty("author-lastname", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorLastname { get; set; }

    [JsonProperty("author-avatar-url", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorAvatarUrl { get; set; }

    [JsonProperty("commentable-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CommentableId { get; set; }

    [JsonProperty("attachments-count", NullValueHandling = NullValueHandling.Ignore)]
    public string AttachmentsCount { get; set; }

    [JsonProperty("emailed-from", NullValueHandling = NullValueHandling.Ignore)]
    public string EmailedFrom { get; set; }

    [JsonProperty("datetime", NullValueHandling = NullValueHandling.Ignore)]
    public string Datetime { get; set; }

    [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public bool Private { get; set; }
  }
}