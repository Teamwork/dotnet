// ==========================================================
// File: TeamworkProjects.Portable.Account.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace Teamwork.Model.Projects.V1
{
    public class Account
    {
      [JsonProperty("requirehttps", NullValueHandling = NullValueHandling.Ignore)]
      public bool Requirehttps { get; set; }

      [JsonProperty("time-tracking-enabled", NullValueHandling = NullValueHandling.Ignore)]
      public bool TimeTrackingEnabled { get; set; }
        
      [JsonProperty("officeAddinAvailable", NullValueHandling = NullValueHandling.Ignore)]
      public bool officeAddinAvailable { get; set; }

      [JsonProperty("officeAddinMSProjectAvailable", NullValueHandling = NullValueHandling.Ignore)]
      public bool officeAddinMSProjectAvailable { get; set; }

      [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
      public string Name { get; set; }

      [JsonProperty("datesignedup", NullValueHandling = NullValueHandling.Ignore)]
      public string Datesignedup { get; set; }

      [JsonProperty("companyname", NullValueHandling = NullValueHandling.Ignore)]
      public string Companyname { get; set; }

      [JsonProperty("ssl-enabled", NullValueHandling = NullValueHandling.Ignore)]
      public bool SslEnabled { get; set; }

      [JsonProperty("created-at", NullValueHandling = NullValueHandling.Ignore)]
      public string CreatedAt { get; set; }

      [JsonProperty("cacheUUID", NullValueHandling = NullValueHandling.Ignore)]
      public string CacheUUID { get; set; }

      [JsonProperty("account-holder-id", NullValueHandling = NullValueHandling.Ignore)]
      public string AccountHolderId { get; set; }

      [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
      public string Logo { get; set; }

      [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
      public string Id { get; set; }

      [JsonProperty("URL", NullValueHandling = NullValueHandling.Ignore)]
      public string URL { get; set; }

      [JsonProperty("email-notification-enabled", NullValueHandling = NullValueHandling.Ignore)]
      public bool EmailNotificationEnabled { get; set; }

      [JsonProperty("companyid", NullValueHandling = NullValueHandling.Ignore)]
      public string Companyid { get; set; }

      [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
      public string Lang { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
      public string Code { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [JsonProperty("canaddprojects", NullValueHandling = NullValueHandling.Ignore)]
      public string canaddprojects { get; set; }

      public bool CanAddProjects
      {
        get { return canaddprojects != "0"; }
      }


      /// <summary>
      /// 
      /// </summary>
      [JsonProperty("userIsMemberOfOwnerCompany", NullValueHandling = NullValueHandling.Ignore)]
      public string UserIsMemberOfOwnerCompany { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public bool IsMemberOfOwnerCompany
      {
        get { return UserIsMemberOfOwnerCompany == "yes" ? true : false; }
      }


      [JsonProperty("userIsAdmin", NullValueHandling = NullValueHandling.Ignore)]
      public bool UserIsAdmin { get; set; }


      [JsonProperty("canManagePeople", NullValueHandling = NullValueHandling.Ignore)]
      public string canManagePeople { get; set; }

      public bool CanManagePeople
      {
        get { return canManagePeople != "0"; }
      }

      [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
      public string Firstname { get; set; }

        [JsonProperty("isPaid", NullValueHandling = NullValueHandling.Ignore)]
        public string isPaid { get; set; }
        [JsonProperty("pricePlan", NullValueHandling = NullValueHandling.Ignore)]
        public string pricePlan { get; set; }

        [JsonProperty("pricePlanId", NullValueHandling = NullValueHandling.Ignore)]
        public int pricePlanId { get; set; }


        [JsonProperty("dateSeperator", NullValueHandling = NullValueHandling.Ignore)]
      public string DateSeperator { get; set; }

      [JsonProperty("timeFormat", NullValueHandling = NullValueHandling.Ignore)]
      public string TimeFormat { get; set; }


      [JsonProperty("avatar-url", NullValueHandling = NullValueHandling.Ignore)]
      public string AvatarUrl { get; set; }

      [JsonProperty("startonsundays", NullValueHandling = NullValueHandling.Ignore)]
      public bool Startonsundays { get; set; }


      [JsonProperty("dateFormat", NullValueHandling = NullValueHandling.Ignore)]
      public string DateFormat { get; set; }

      [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
      public int UserId { get; set; }

      [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
      public string Lastname { get; set; }
    }
}
