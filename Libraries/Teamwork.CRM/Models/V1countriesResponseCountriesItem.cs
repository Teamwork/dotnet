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
    /// Country
    /// </summary>
    /// <remarks>
    /// Country in CRM
    /// </remarks>
    public partial class V1countriesResponseCountriesItem
    {
        /// <summary>
        /// Initializes a new instance of the V1countriesResponseCountriesItem
        /// class.
        /// </summary>
        public V1countriesResponseCountriesItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1countriesResponseCountriesItem
        /// class.
        /// </summary>
        /// <param name="code">Two letter country code.</param>
        public V1countriesResponseCountriesItem(string code = default(string), int? id = default(int?), string name = default(string))
        {
            Code = code;
            Id = id;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets two letter country code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}