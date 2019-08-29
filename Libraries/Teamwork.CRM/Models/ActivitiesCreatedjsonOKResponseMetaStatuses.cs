// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Teamwork.CRM.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// DealReportStatuses
    /// </summary>
    /// <remarks>
    /// DealReportStatuses fields.
    /// </remarks>
    public partial class ActivitiesCreatedjsonOKResponseMetaStatuses
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ActivitiesCreatedjsonOKResponseMetaStatuses class.
        /// </summary>
        public ActivitiesCreatedjsonOKResponseMetaStatuses()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ActivitiesCreatedjsonOKResponseMetaStatuses class.
        /// </summary>
        /// <param name="lost">DealReportStatus</param>
        /// <param name="open">DealReportStatus</param>
        /// <param name="won">DealReportStatus</param>
        public ActivitiesCreatedjsonOKResponseMetaStatuses(ActivitiesCreatedjsonOKResponseMetaStatusesLost lost = default(ActivitiesCreatedjsonOKResponseMetaStatusesLost), ActivitiesCreatedjsonOKResponseMetaStatusesOpen open = default(ActivitiesCreatedjsonOKResponseMetaStatusesOpen), ActivitiesCreatedjsonOKResponseMetaStatusesWon won = default(ActivitiesCreatedjsonOKResponseMetaStatusesWon))
        {
            Lost = lost;
            Open = open;
            Won = won;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets dealReportStatus
        /// </summary>
        /// <remarks>
        /// DealReportStatus fields
        /// </remarks>
        [JsonProperty(PropertyName = "lost")]
        public ActivitiesCreatedjsonOKResponseMetaStatusesLost Lost { get; set; }

        /// <summary>
        /// Gets or sets dealReportStatus
        /// </summary>
        /// <remarks>
        /// DealReportStatus fields
        /// </remarks>
        [JsonProperty(PropertyName = "open")]
        public ActivitiesCreatedjsonOKResponseMetaStatusesOpen Open { get; set; }

        /// <summary>
        /// Gets or sets dealReportStatus
        /// </summary>
        /// <remarks>
        /// DealReportStatus fields
        /// </remarks>
        [JsonProperty(PropertyName = "won")]
        public ActivitiesCreatedjsonOKResponseMetaStatusesWon Won { get; set; }

    }
}