﻿

using System;
using Newtonsoft.Json;

namespace Teamwork.Model.Projects.V1
{
  public class Person
  {

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("user-type", NullValueHandling = NullValueHandling.Ignore)]
    public string UserType { get; set; }
    public string DisplayName
    {
      get { return FirstName + " " + LastName; }
      set { FirstName = value; }
    }

     public override string ToString()
    {
         return FirstName + " " + LastName;
     }

   [JsonProperty("first-name", NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }

    [JsonProperty("last-name", NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("email-address", NullValueHandling = NullValueHandling.Ignore)]
    public string EmailAddress { get; set; }

    [JsonProperty("im-handle", NullValueHandling = NullValueHandling.Ignore)]
    public string ImHandle { get; set; }

    [JsonProperty("im-service", NullValueHandling = NullValueHandling.Ignore)]
    public string ImService { get; set; }

    [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
    public string Notes { get; set; }

    [JsonProperty("phone-number-office", NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumberOffice { get; set; }

    [JsonProperty("phone-number-office-ext", NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumberOfficeExt { get; set; }

    [JsonProperty("phone-number-mobile", NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumberMobile { get; set; }

    [JsonProperty("phone-number-home", NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumberHome { get; set; }

    [JsonProperty("phone-number-fax", NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumberFax { get; set; }

    [JsonProperty("last-login", NullValueHandling = NullValueHandling.Ignore)]
    public string LastLogin { get; set; }

    [JsonProperty("company-id", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyId { get; set; }

    [JsonProperty("company-name", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyName { get; set; }

    [JsonProperty("in-owner-company", NullValueHandling = NullValueHandling.Ignore)]
    public string InOwnerCompany { get; set; }

    [JsonProperty("created-at", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedAt { get; set; }

    [JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
    public string LastChangedOn { get; set; }

    [JsonProperty("avatar-url", NullValueHandling = NullValueHandling.Ignore)]
    public string AvatarUrl { get; set; }

    [JsonProperty("user-name", NullValueHandling = NullValueHandling.Ignore)]
    public string UserName { get; set; }

    [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
    public bool Deleted { get; set; }

    [JsonProperty("has-access-to-new-projects", NullValueHandling = NullValueHandling.Ignore)]
    public bool HasAccessToNewProjects { get; set; }

    [JsonProperty("administrator", NullValueHandling = NullValueHandling.Ignore)]
    public bool Administrator { get; set; }

    [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
    public Permissions Permissions { get; set; }

    [JsonProperty("address-city", NullValueHandling = NullValueHandling.Ignore)]
    public string AddressCity { get; set; }

    [JsonProperty("pid", NullValueHandling = NullValueHandling.Ignore)]
    public string Pid { get; set; }

    [JsonProperty("site-owner", NullValueHandling = NullValueHandling.Ignore)]
    public bool SiteOwner { get; set; }

    [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
    public string Twitter { get; set; }

    [JsonProperty("userUUID", NullValueHandling = NullValueHandling.Ignore)]
    public string UserUUID { get; set; }

    [JsonProperty("address-state", NullValueHandling = NullValueHandling.Ignore)]
    public string AddressState { get; set; }

    [JsonProperty("address-country", NullValueHandling = NullValueHandling.Ignore)]
    public string AddressCountry { get; set; }

    [JsonProperty("user-invited-status", NullValueHandling = NullValueHandling.Ignore)]
    public string UserInvitedStatus { get; set; }
  }


    public class PersonAdd
    {


        [JsonProperty("user-type", NullValueHandling = NullValueHandling.Ignore)]
        public string UserType { get; set; }

        [JsonProperty("full-name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("email-address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }

       [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }

       [JsonProperty("company-id", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyId { get; set; }

       [JsonProperty("user-name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty("user-invited", NullValueHandling = NullValueHandling.Ignore)]
        public string UserInvited { get; set; }

        [JsonProperty("allowEmailNotifications", NullValueHandling = NullValueHandling.Ignore)]
        public string AllowNotifications { get; set; }



    }
}