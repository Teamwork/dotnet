using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teamwork.Projects.Base.Response
{
  public class StatsResponse
  {
   [JsonProperty("STATUS")]
    public string Status { get; set; }
   [JsonProperty("Stats")]
   public Stats Stats { get; set; }
  }
}

public class StatsTasks
{
  public int nodate { get; set; }
  public int today { get; set; }
  public int late { get; set; }
  public int complete { get; set; }
  public int upcoming { get; set; }
  public int active { get; set; }
}

public class StatsTime
{
  public int billable { get; set; }
  public int nonBilled { get; set; }
  public int billed { get; set; }
  public int nonBillable { get; set; }
  public int estimatedActive { get; set; }
  public int estimatedWithLoggedTime { get; set; }
  public int total { get; set; }
  public int estimated { get; set; }
  public int estimatedCompleted { get; set; }
}

public class StatsNotebooks
{
  public string count { get; set; }
}

public class StatsTasklists
{
  public string complete { get; set; }
  public string active { get; set; }
}

public class StatsCompanies
{
  public string count { get; set; }
}

public class StatsFiles
{
  public string count { get; set; }
}

public class StatsContacts
{
  public string count { get; set; }
}

public class StatsEvents
{
  public string count { get; set; }
}

public class StatsMilestones
{
  public string today { get; set; }
  public string late { get; set; }
  public string complete { get; set; }
  public string upcoming { get; set; }
  public string active { get; set; }
}

public class StatsMessages
{
  public string count { get; set; }
  public string unread { get; set; }
}

public class Stats
{
  public StatsTasks tasks { get; set; }
  public StatsTime time { get; set; }
  public StatsNotebooks notebooks { get; set; }
  public StatsTasklists tasklists { get; set; }
  public StatsCompanies companies { get; set; }
  public StatsFiles files { get; set; }
  public StatsContacts contacts { get; set; }
  public StatsEvents events { get; set; }
  public StatsMilestones milestones { get; set; }
  public StatsMessages messages { get; set; }
}

