// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Teamwork.CRM.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// CustomFilter
    /// </summary>
    /// <remarks>
    /// CustomFilter is a custom field defined by a user.
    /// </remarks>
    public partial class CrmcoreCustomFilter
    {
        /// <summary>
        /// Initializes a new instance of the CrmcoreCustomFilter class.
        /// </summary>
        public CrmcoreCustomFilter()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CrmcoreCustomFilter class.
        /// </summary>
        /// <param name="createdBy">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="deletedBy">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="updatedBy">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        public CrmcoreCustomFilter(IList<CrmcoreCustomFilterColumnsItem> columns = default(IList<CrmcoreCustomFilterColumnsItem>), IList<CrmcoreCustomFilterConditionsItem> conditions = default(IList<CrmcoreCustomFilterConditionsItem>), string conditionsBinding = default(string), System.DateTime? createdAt = default(System.DateTime?), CrmcoreCustomFilterCreatedBy createdBy = default(CrmcoreCustomFilterCreatedBy), System.DateTime? deletedAt = default(System.DateTime?), CrmcoreCustomFilterDeletedBy deletedBy = default(CrmcoreCustomFilterDeletedBy), int? id = default(int?), bool? isShared = default(bool?), string kind = default(string), string name = default(string), string orderBy = default(string), string orderMode = default(string), System.DateTime? updatedAt = default(System.DateTime?), CrmcoreCustomFilterUpdatedBy updatedBy = default(CrmcoreCustomFilterUpdatedBy), int? updatedSourceId = default(int?))
        {
            Columns = columns;
            Conditions = conditions;
            ConditionsBinding = conditionsBinding;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            DeletedAt = deletedAt;
            DeletedBy = deletedBy;
            Id = id;
            IsShared = isShared;
            Kind = kind;
            Name = name;
            OrderBy = orderBy;
            OrderMode = orderMode;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            UpdatedSourceId = updatedSourceId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "columns")]
        public IList<CrmcoreCustomFilterColumnsItem> Columns { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "conditions")]
        public IList<CrmcoreCustomFilterConditionsItem> Conditions { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "conditionsBinding")]
        public string ConditionsBinding { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdAt")]
        public System.DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "createdBy")]
        public CrmcoreCustomFilterCreatedBy CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deletedAt")]
        public System.DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "deletedBy")]
        public CrmcoreCustomFilterDeletedBy DeletedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isShared")]
        public bool? IsShared { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderBy")]
        public string OrderBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderMode")]
        public string OrderMode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "updatedAt")]
        public System.DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "updatedBy")]
        public CrmcoreCustomFilterUpdatedBy UpdatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "updatedSourceId")]
        public int? UpdatedSourceId { get; set; }

    }
}