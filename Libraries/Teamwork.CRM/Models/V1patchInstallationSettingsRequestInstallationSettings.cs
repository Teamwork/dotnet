// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Teamwork.CRM.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class V1patchInstallationSettingsRequestInstallationSettings
    {
        /// <summary>
        /// Initializes a new instance of the
        /// V1patchInstallationSettingsRequestInstallationSettings class.
        /// </summary>
        public V1patchInstallationSettingsRequestInstallationSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// V1patchInstallationSettingsRequestInstallationSettings class.
        /// </summary>
        /// <param name="currency">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// linking to a currency.
        /// This currency will be used when converting multiple currencies to
        /// one, e.g deals totalValue
        /// field.</param>
        public V1patchInstallationSettingsRequestInstallationSettings(V1patchInstallationSettingsRequestInstallationSettingsCurrency currency = default(V1patchInstallationSettingsRequestInstallationSettingsCurrency))
        {
            Currency = currency;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// linking to a currency.
        /// This currency will be used when converting multiple currencies to
        /// one, e.g deals totalValue
        /// field.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public V1patchInstallationSettingsRequestInstallationSettingsCurrency Currency { get; set; }

    }
}