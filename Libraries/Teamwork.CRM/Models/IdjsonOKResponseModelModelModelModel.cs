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
    /// currencyResponse
    /// </summary>
    public partial class IdjsonOKResponseModelModelModelModel
    {
        /// <summary>
        /// Initializes a new instance of the
        /// IdjsonOKResponseModelModelModelModel class.
        /// </summary>
        public IdjsonOKResponseModelModelModelModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// IdjsonOKResponseModelModelModelModel class.
        /// </summary>
        /// <param name="currency">Currency</param>
        public IdjsonOKResponseModelModelModelModel(IdjsonOKResponseCurrency currency = default(IdjsonOKResponseCurrency))
        {
            Currency = currency;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets currency
        /// </summary>
        /// <remarks>
        /// Currency represents a currency in the CRM system.
        /// </remarks>
        [JsonProperty(PropertyName = "currency")]
        public IdjsonOKResponseCurrency Currency { get; set; }

    }
}