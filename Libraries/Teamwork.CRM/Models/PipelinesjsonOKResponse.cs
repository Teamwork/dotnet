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
    /// PipelinesResponse
    /// </summary>
    /// <remarks>
    /// PipelinesResponse contains the body for a list of pipelines.
    /// </remarks>
    public partial class PipelinesjsonOKResponse
    {
        /// <summary>
        /// Initializes a new instance of the PipelinesjsonOKResponse class.
        /// </summary>
        public PipelinesjsonOKResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PipelinesjsonOKResponse class.
        /// </summary>
        /// <param name="included">Included</param>
        /// <param name="meta">ResponseMeta</param>
        public PipelinesjsonOKResponse(object included = default(object), PipelinesjsonOKResponseMeta meta = default(PipelinesjsonOKResponseMeta), IList<PipelinesjsonOKResponsePipelinesItem> pipelines = default(IList<PipelinesjsonOKResponsePipelinesItem>))
        {
            Included = included;
            Meta = meta;
            Pipelines = pipelines;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets included
        /// </summary>
        /// <remarks>
        /// Included contains all the side-loaded data of a response.
        /// See [including related
        /// entities](https://crmdev-teamwork.docs.stoplight.io/documentation/general/related-entities).
        /// </remarks>
        [JsonProperty(PropertyName = "included")]
        public object Included { get; set; }

        /// <summary>
        /// Gets or sets responseMeta
        /// </summary>
        /// <remarks>
        /// ResponseMeta contains common meta data.
        /// </remarks>
        [JsonProperty(PropertyName = "meta")]
        public PipelinesjsonOKResponseMeta Meta { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pipelines")]
        public IList<PipelinesjsonOKResponsePipelinesItem> Pipelines { get; set; }

    }
}