using Newtonsoft.Json;
using Teamwork.Model.Projects.V1;

namespace TeamworkProjects.Model.V1
{

    public class TimeEstimates
    {

      [JsonProperty("total-hours-estimated", NullValueHandling = NullValueHandling.Ignore)]
      public string TotalHoursEstimated { get; set; }

      [JsonProperty("active-mins-estimated", NullValueHandling = NullValueHandling.Ignore)]
      public string ActiveMinsEstimated { get; set; }

      [JsonProperty("total-mins-estimated", NullValueHandling = NullValueHandling.Ignore)]
      public string TotalMinsEstimated { get; set; }

      [JsonProperty("active-hours-estimated", NullValueHandling = NullValueHandling.Ignore)]
      public string ActiveHoursEstimated { get; set; }

      [JsonProperty("completed-hours-estimated", NullValueHandling = NullValueHandling.Ignore)]
      public string CompletedHoursEstimated { get; set; }

      [JsonProperty("completed-mins-estimated", NullValueHandling = NullValueHandling.Ignore)]
      public string CompletedMinsEstimated { get; set; }
    }

    public class TimeTotals
    {

      [JsonProperty("total-mins-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string TotalMinsSum { get; set; }

      [JsonProperty("non-billed-mins-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string NonBilledMinsSum { get; set; }

      [JsonProperty("non-billable-hours-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string NonBillableHoursSum { get; set; }

      [JsonProperty("total-hours-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string TotalHoursSum { get; set; }

      [JsonProperty("billed-mins-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string BilledMinsSum { get; set; }

      [JsonProperty("billed-hours-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string BilledHoursSum { get; set; }

      [JsonProperty("billable-bours-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string BillableBoursSum { get; set; }

      [JsonProperty("non-billable-mins-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string NonBillableMinsSum { get; set; }

      [JsonProperty("non-billed-hours-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string NonBilledHoursSum { get; set; }

      [JsonProperty("billable-mins-sum", NullValueHandling = NullValueHandling.Ignore)]
      public string BillableMinsSum { get; set; }
    }

    public partial class Project
    {
      [JsonProperty("time-estimates", NullValueHandling = NullValueHandling.Ignore)]
      public TimeEstimates TimeEstimates { get; set; }

      [JsonProperty("time-totals", NullValueHandling = NullValueHandling.Ignore)]
      public TimeTotals TimeTotals { get; set; }

      [JsonProperty("tasklist", NullValueHandling = NullValueHandling.Ignore)]
      public TodoList[] Tasklist { get; set; }
      
    }

    public class TimeTotalsResponse
    {

      [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
      public string STATUS { get; set; }

      [JsonProperty("projects", NullValueHandling = NullValueHandling.Ignore)]
      public Project[] Projects { get; set; }
    }

  }

