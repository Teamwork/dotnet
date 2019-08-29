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
    /// createActivityTypeRequest
    /// </summary>
    public partial class V1createActivityTypeRequest
    {
        /// <summary>
        /// Initializes a new instance of the V1createActivityTypeRequest
        /// class.
        /// </summary>
        public V1createActivityTypeRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1createActivityTypeRequest
        /// class.
        /// </summary>
        public V1createActivityTypeRequest(V1createActivityTypeRequestActivityType activityType = default(V1createActivityTypeRequestActivityType))
        {
            ActivityType = activityType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activityType")]
        public V1createActivityTypeRequestActivityType ActivityType { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ActivityType != null)
            {
                ActivityType.Validate();
            }
        }
    }
}