using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamworkProjects.Model
{
  public class Owner
  {
    [JsonProperty("first-name ", NullValueHandling = NullValueHandling.Ignore)]
    public string firstname { get; set; }

    public string id { get; set; }

    [JsonProperty("last-name", NullValueHandling = NullValueHandling.Ignore)]
    public string lastname { get; set; }
  }

  public class Privacy
  {
    public string type { get; set; }
  }

  public class EventType
  {
    public string name { get; set; }
    public string id { get; set; }
    public string color { get; set; }
  }

  public class Repeat
  {
    public string frequency { get; set; }
    public bool ends { get; set; }

    [JsonProperty("month-type", NullValueHandling = NullValueHandling.Ignore)]
    public string monthtype { get; set; }
  }

  public class Event
  {
    public string where { get; set; }

    [JsonProperty("attending-user-name", NullValueHandling = NullValueHandling.Ignore)]
    public string attendingUserNames { get; set; }

    public string status { get; set; }
    public Owner owner { get; set; }
    public List<object> reminders { get; set; }

    [JsonProperty("notify-user-ids ", NullValueHandling = NullValueHandling.Ignore)]
    public string notifyUserIds { get; set; }

    public bool canEdit { get; set; }


    //all-day
    [JsonProperty("all-day", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsAllDay { get; set; }

    public string id { get; set; }

    [JsonProperty("is-unavailable", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsUnavailable { get; set; }

    [JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
    public string lastChangedON { get; set; }

    public Privacy privacy { get; set; }
    public EventType type { get; set; }
    public string description { get; set; }

    [JsonProperty("attending-user-ids ", NullValueHandling = NullValueHandling.Ignore)]
    public string attendingUserIds { get; set; }

    [JsonProperty("notify-user-names", NullValueHandling = NullValueHandling.Ignore)]
    public string notifyUserName { get; set; }

    public string createdAt { get; set; }
    public string start { get; set; }
    public Repeat repeat { get; set; }

    [JsonProperty("show-as-busy", NullValueHandling = NullValueHandling.Ignore)]
    public bool ShowAsBusy { get; set; }

    public string end { get; set; }
    public string sequenceId { get; set; }

    public string title { get; set; }
  }

}