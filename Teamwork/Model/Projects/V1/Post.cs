// ==========================================================
// File: TeamworkProjects.Portable.Post.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace TeamworkProjects.Model
{

  public class NewPost
  {
      [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
      public string Title { get; set; }

        [JsonProperty("grant-access-to", NullValueHandling = NullValueHandling.Ignore)]
        public string GrantAccessTo { get; set; }

        [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
      public string CategoryId { get; set; }

      [JsonProperty("notify", NullValueHandling = NullValueHandling.Ignore)]
      public string[] Notify { get; set; }

      [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
      public string Private { get; set; }

      [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
      public string Body { get; set; }

      [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
      public string Attachments { get; set; }

      [JsonProperty("pendingFileAttachments", NullValueHandling = NullValueHandling.Ignore)]
      public string PendingFileAttachments { get; set; }
  }

  public class Post
  {
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("author-id", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorId { get; set; }

    [JsonProperty("author-first-name", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorFirstName { get; set; }

    [JsonProperty("author-last-name", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorLastName { get; set; }

    [JsonProperty("author-avatar-url", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorAvatarUrl { get; set; }

    [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
    public string Body { get; set; }

    [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryId { get; set; }

    [JsonProperty("posted-on", NullValueHandling = NullValueHandling.Ignore)]
    public string PostedOn { get; set; }

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public int ProjectId { get; set; }

    [JsonProperty("comments-count", NullValueHandling = NullValueHandling.Ignore)]
    public string CommentsCount { get; set; }

    [JsonProperty("attachments-count", NullValueHandling = NullValueHandling.Ignore)]
    public string AttachmentsCount { get; set; }

    [JsonProperty("display-body", NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayBody { get; set; }

    [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public bool Private { get; set; }
  }
}
