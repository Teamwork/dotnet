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
    /// Contact
    /// </summary>
    /// <remarks>
    /// Contact represents a contact in the CRM system.
    /// </remarks>
    public partial class V1contactsListResponseContactsItem
    {
        /// <summary>
        /// Initializes a new instance of the
        /// V1contactsListResponseContactsItem class.
        /// </summary>
        public V1contactsListResponseContactsItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// V1contactsListResponseContactsItem class.
        /// </summary>
        /// <param name="avatar">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="company">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="country">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="createdBy">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="custom">Custom fields of the entity, which properties
        /// are accepted in here will depend
        /// on your settings. For more information see
        /// [dealing with custom
        /// fields](https://crmdev-teamwork.docs.stoplight.io/documentation/miscellaneous/custom-fields).</param>
        /// <param name="deletedBy">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="owner">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="timezone">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        /// <param name="updatedBy">[Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.</param>
        public V1contactsListResponseContactsItem(string addressLine1 = default(string), string addressLine2 = default(string), V1contactsListResponseContactsItemAvatar avatar = default(V1contactsListResponseContactsItemAvatar), string city = default(string), V1contactsListResponseContactsItemCompany company = default(V1contactsListResponseContactsItemCompany), V1contactsListResponseContactsItemCountry country = default(V1contactsListResponseContactsItemCountry), System.DateTime? createdAt = default(System.DateTime?), V1contactsListResponseContactsItemCreatedBy createdBy = default(V1contactsListResponseContactsItemCreatedBy), object custom = default(object), System.DateTime? deletedAt = default(System.DateTime?), V1contactsListResponseContactsItemDeletedBy deletedBy = default(V1contactsListResponseContactsItemDeletedBy), IList<V1contactsListResponseContactsItemEmailAddressesItem> emailAddresses = default(IList<V1contactsListResponseContactsItemEmailAddressesItem>), string firstName = default(string), int? id = default(int?), string lastName = default(string), V1contactsListResponseContactsItemOwner owner = default(V1contactsListResponseContactsItemOwner), V1contactsListResponseContactsItemPhoneNumbers phoneNumbers = default(V1contactsListResponseContactsItemPhoneNumbers), string stateOrCounty = default(string), V1contactsListResponseContactsItemTimezone timezone = default(V1contactsListResponseContactsItemTimezone), string title = default(string), System.DateTime? updatedAt = default(System.DateTime?), V1contactsListResponseContactsItemUpdatedBy updatedBy = default(V1contactsListResponseContactsItemUpdatedBy), int? updatedSourceId = default(int?), string zipcode = default(string))
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Avatar = avatar;
            City = city;
            Company = company;
            Country = country;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            Custom = custom;
            DeletedAt = deletedAt;
            DeletedBy = deletedBy;
            EmailAddresses = emailAddresses;
            FirstName = firstName;
            Id = id;
            LastName = lastName;
            Owner = owner;
            PhoneNumbers = phoneNumbers;
            StateOrCounty = stateOrCounty;
            Timezone = timezone;
            Title = title;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            UpdatedSourceId = updatedSourceId;
            Zipcode = zipcode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "addressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public V1contactsListResponseContactsItemAvatar Avatar { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "company")]
        public V1contactsListResponseContactsItemCompany Company { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public V1contactsListResponseContactsItemCountry Country { get; set; }

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
        public V1contactsListResponseContactsItemCreatedBy CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets custom fields of the entity, which properties are
        /// accepted in here will depend
        /// on your settings. For more information see
        /// [dealing with custom
        /// fields](https://crmdev-teamwork.docs.stoplight.io/documentation/miscellaneous/custom-fields).
        /// </summary>
        [JsonProperty(PropertyName = "custom")]
        public object Custom { get; set; }

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
        public V1contactsListResponseContactsItemDeletedBy DeletedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailAddresses")]
        public IList<V1contactsListResponseContactsItemEmailAddressesItem> EmailAddresses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public V1contactsListResponseContactsItemOwner Owner { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phoneNumbers")]
        public V1contactsListResponseContactsItemPhoneNumbers PhoneNumbers { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "stateOrCounty")]
        public string StateOrCounty { get; set; }

        /// <summary>
        /// Gets or sets [Resource identifier
        /// object](https://crmdev-teamwork.docs.stoplight.io/documentation/general/entity-models#relationships)
        /// which describes a relationship to another entity.
        /// </summary>
        [JsonProperty(PropertyName = "timezone")]
        public V1contactsListResponseContactsItemTimezone Timezone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

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
        public V1contactsListResponseContactsItemUpdatedBy UpdatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "updatedSourceId")]
        public int? UpdatedSourceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "zipcode")]
        public string Zipcode { get; set; }

    }
}