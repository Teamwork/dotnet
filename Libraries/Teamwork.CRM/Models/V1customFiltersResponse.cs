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
    /// customFiltersResponse
    /// </summary>
    public partial class V1customFiltersResponse
    {
        /// <summary>
        /// Initializes a new instance of the V1customFiltersResponse class.
        /// </summary>
        public V1customFiltersResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1customFiltersResponse class.
        /// </summary>
        /// <param name="meta">ResponseMeta</param>
        public V1customFiltersResponse(IList<V1customFiltersResponseCustomFiltersItem> customFilters = default(IList<V1customFiltersResponseCustomFiltersItem>), V1customFiltersResponseMeta meta = default(V1customFiltersResponseMeta))
        {
            CustomFilters = customFilters;
            Meta = meta;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customFilters")]
        public IList<V1customFiltersResponseCustomFiltersItem> CustomFilters { get; set; }

        /// <summary>
        /// Gets or sets responseMeta
        /// </summary>
        /// <remarks>
        /// ResponseMeta contains common meta data.
        /// </remarks>
        [JsonProperty(PropertyName = "meta")]
        public V1customFiltersResponseMeta Meta { get; set; }

    }
}