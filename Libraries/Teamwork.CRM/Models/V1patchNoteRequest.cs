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
    /// patchNoteRequest
    /// </summary>
    public partial class V1patchNoteRequest
    {
        /// <summary>
        /// Initializes a new instance of the V1patchNoteRequest class.
        /// </summary>
        public V1patchNoteRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1patchNoteRequest class.
        /// </summary>
        /// <param name="note">patchNote</param>
        public V1patchNoteRequest(V1patchNoteRequestNote note)
        {
            Note = note;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets patchNote
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public V1patchNoteRequestNote Note { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Note == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Note");
            }
        }
    }
}