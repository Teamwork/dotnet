// ==========================================================
// File: TeamworkProjects.Portable.MessageReply.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================
using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
  public class MessageReply
  {
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("author-id", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorId { get; set; }

    [JsonProperty("author-firstname", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorFirstname { get; set; }

    [JsonProperty("author-lastname", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorLastname { get; set; }

    [JsonProperty("author-avatar-url", NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorAvatarUrl { get; set; }

    [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
    public string Body { get; set; }

    [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryId { get; set; }

    [JsonProperty("posted-on", NullValueHandling = NullValueHandling.Ignore)]
    public string PostedOn { get; set; }

    [JsonProperty("messageId", NullValueHandling = NullValueHandling.Ignore)]
    public string MessageId { get; set; }

    [JsonProperty("attachments-count", NullValueHandling = NullValueHandling.Ignore)]
    public string AttachmentsCount { get; set; }

    [JsonProperty("comments-count", NullValueHandling = NullValueHandling.Ignore)]
    public string CommentsCount { get; set; }

    [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
    public bool Private { get; set; }

    [JsonProperty("replyNo", NullValueHandling = NullValueHandling.Ignore)]
    public string ReplyNo { get; set; }
  }


    public class MessageCreate
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        [JsonProperty("category-id", NullValueHandling = NullValueHandling.Ignore)]
        public string categoryid { get; set; }
        [JsonProperty("notify", NullValueHandling = NullValueHandling.Ignore)]
        public string notify { get; set; }
        [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
        public string Isprivate { get; set; }
        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string body { get; set; }
        [JsonProperty("pendingFileAttachments", NullValueHandling = NullValueHandling.Ignore)]
        public string pendingFileAttachments { get; set; }
    }
}