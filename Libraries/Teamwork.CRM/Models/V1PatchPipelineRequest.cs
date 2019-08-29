// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Teamwork.CRM.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// PatchPipelineRequest
    /// </summary>
    /// <remarks>
    /// PatchPipelineRequest contains the body for a pipeline update request.
    /// </remarks>
    public partial class V1PatchPipelineRequest
    {
        /// <summary>
        /// Initializes a new instance of the V1PatchPipelineRequest class.
        /// </summary>
        public V1PatchPipelineRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1PatchPipelineRequest class.
        /// </summary>
        public V1PatchPipelineRequest(V1PatchPipelineRequestPipeline pipeline)
        {
            Pipeline = pipeline;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pipeline")]
        public V1PatchPipelineRequestPipeline Pipeline { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Pipeline == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Pipeline");
            }
        }
    }
}