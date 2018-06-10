// ==========================================================
// File: TeamworkProjects.Base.Events.cs
// Created: 08.04.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using Newtonsoft.Json;
using TeamworkProjects.Extensions.DateTime;

namespace Teamwork.Model.Projects.V1
{
  public class Owner
  {
    [JsonProperty("first-name", NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string id { get; set; }

    [JsonProperty("last-name", NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }
  }

  public class Repeat
  {
   [JsonProperty("frequency", NullValueHandling = NullValueHandling.Ignore)]
    public string Frequency;
    
    [JsonProperty("end-date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime EndDate;
    
    [JsonProperty("selected-days-list", NullValueHandling = NullValueHandling.Ignore)]
    public string SelectedDays;
    
    [JsonProperty("ends", NullValueHandling = NullValueHandling.Ignore)]
    public bool Ends;

  }

  public class EventReminder
  {
    public string type { get; set; }
    public string period { get; set; }
    public string before { get; set; }
  }


  public class Privacy
  {
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }
   
    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public string ProjectID { get; set; }
  }

  public class EventType
  {
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string Color { get; set; }
  }

  public class Event
  {
    [JsonIgnore]
    public string CalendarItemID { get; set; }

    [JsonIgnore]
    public string notify { get; set; }

    [JsonProperty("where", NullValueHandling = NullValueHandling.Ignore)]
    public string Where { get; set; }

    [JsonProperty("project-users-can-edit", NullValueHandling = NullValueHandling.Ignore)]
    public bool ProjectUsersCanEdit { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("sequenceId", NullValueHandling = NullValueHandling.Ignore)]
    public string SequenceId { get; set; }

    [JsonProperty("attending-user-ids", NullValueHandling = NullValueHandling.Ignore)]
    public string AttendingUserIds { get; set; }

    [JsonProperty("notify-user-names", NullValueHandling = NullValueHandling.Ignore)]
    public string NotifyUserNames { get; set; }

    [JsonProperty("attending-user-names", NullValueHandling = NullValueHandling.Ignore)]
    public string AttendingUserNames { get; set; }

    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }

    [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
    public Owner Owner { get; set; }

    [JsonProperty("reminders", NullValueHandling = NullValueHandling.Ignore)]
    public EventReminder[] Reminders { get; set; }

    [JsonProperty("notify-user-ids", NullValueHandling = NullValueHandling.Ignore)]
    public string NotifyUserIds { get; set; }

    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public string start { get; set; }

    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public string end { get; set; }

    [JsonIgnore]
    public DateTime Start
    {
      get { return DateTime.Parse(start); }
      set { start = value.ToString("yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture); }
    }

    [JsonIgnore]
    public DateTime End
    {
      get {
          return DateTime.Parse(end);
      }
      set {
        end = value.ToString("yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
      }
    }
    
    [JsonProperty("repeat", NullValueHandling = NullValueHandling.Ignore)]
    public Repeat Repeat { get; set; }

    [JsonProperty("all-day", NullValueHandling = NullValueHandling.Ignore)]
    public bool AllDay { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string id { get; set; }

    [JsonProperty("show-as-busy", NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowAsBusy { get; set; }

    [JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
    public string lastChangedOn { get; set; }
    [JsonIgnore]
    public DateTime LastChangedOn
    {
      get { return lastChangedOn.ToDateTimeExactMin("yyyy-MM-ddThh:mm:ssZ"); }
    }
    [JsonProperty("privacy", NullValueHandling = NullValueHandling.Ignore)]
    public Privacy Privacy { get; set; }

    [JsonProperty("attendees-can-edit", NullValueHandling = NullValueHandling.Ignore)]
    public bool AttendeesCanEdit { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public EventType Type { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public string projectid { get; set; }
      
    [JsonProperty("additional-properties", NullValueHandling = NullValueHandling.Ignore)]
    public string properties { get; set; }

    [JsonIgnore]
    public Dictionary<string, string> Properties
    {
      get
      {
        return properties != null ? JsonConvert.DeserializeObject<Dictionary<string, string>>(properties) : new Dictionary<string, string>();
      }
      set
      {
        properties = JsonConvert.SerializeObject(value);
      }
    }


  }



  public class EventCreate
  {
    [JsonIgnore]
    public Dictionary<string, string> Properties
    {
      get
      {
        return properties != null ? JsonConvert.DeserializeObject<Dictionary<string, string>>(properties) : new Dictionary<string, string>();
      }
      set { properties = JsonConvert.SerializeObject(value); }
    }

    [JsonIgnore]
    public string notify { get; set; }

    [JsonProperty("additional-properties", NullValueHandling = NullValueHandling.Ignore)]
    public string properties { get; set; }

    [JsonProperty("where", NullValueHandling = NullValueHandling.Ignore)]
    public string Where { get; set; }

    [JsonProperty("project-users-can-edit", NullValueHandling = NullValueHandling.Ignore)]
    public bool ProjectUsersCanEdit { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("attending-user-ids", NullValueHandling = NullValueHandling.Ignore)]
    public string AttendingUserIds { get; set; }

    [JsonProperty("notify-user-names", NullValueHandling = NullValueHandling.Ignore)]
    public string NotifyUserNames { get; set; }

    [JsonProperty("attending-user-names", NullValueHandling = NullValueHandling.Ignore)]
    public string AttendingUserNames { get; set; }

    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    public string Status { get; set; }


    [JsonProperty("reminders", NullValueHandling = NullValueHandling.Ignore)]
    public EventReminder[] Reminders { get; set; }

    [JsonProperty("notify-user-ids", NullValueHandling = NullValueHandling.Ignore)]
    public string NotifyUserIds { get; set; }

    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public string Start { get; set; }
    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public string End { get; set; }

    [JsonIgnore]
    public DateTime StartDate
    {
      get { return DateTime.ParseExact(Start, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None); }
      set { Start = value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture); }
    }
   
    [JsonIgnore]
    public DateTime EndDate
    {
      get { return DateTime.ParseExact(End, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None); }
      set { End = value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture); }
    }
    

    [JsonProperty("repeat", NullValueHandling = NullValueHandling.Ignore)]
    public Repeat Repeat { get; set; }

    [JsonProperty("all-day", NullValueHandling = NullValueHandling.Ignore)]
    public bool AllDay { get; set; }



    [JsonProperty("show-as-busy", NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowAsBusy { get; set; }

    [JsonProperty("privacy", NullValueHandling = NullValueHandling.Ignore)]
    public Privacy Privacy { get; set; }

    [JsonProperty("attendees-can-edit", NullValueHandling = NullValueHandling.Ignore)]
    public bool AttendeesCanEdit { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public EventType Type { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("project-id", NullValueHandling = NullValueHandling.Ignore)]
    public string projectid { get; set; }


  }


  public class EventsResponse
  {
    [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)] public Event[] Events { get; set; }   
    [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)] public string STATUS { get; set; }   
    [JsonIgnore] public int TotalRecords { get; set; }
    [JsonIgnore] public int Pages { get; set; }
    [JsonIgnore] public int Page { get; set; }
  }
  public class EventResponse
  {
    [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
    public Event Event { get; set; }

    [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
    public string STATUS { get; set; }
  }


  public class EventTypeResponse
  {
  [JsonProperty("eventtypes", NullValueHandling = NullValueHandling.Ignore)]
  public EventType[] EventTypes { get; set; }

  [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
  public string STATUS { get; set; }
  }

}