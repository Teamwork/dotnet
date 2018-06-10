// ==========================================================
// File: TeamworkProjects.Portable.Company.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using Newtonsoft.Json;

namespace Teamwork.Model.Projects.V1
{
  public class Company
  {
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("can_see_private", NullValueHandling = NullValueHandling.Ignore)]
    public bool CanSeePrivate { get; set; }

    [JsonProperty("company_name_url", NullValueHandling = NullValueHandling.Ignore)]
    public string CompanyNameUrl { get; set; }

    [JsonProperty("email_one", NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty("email_two", NullValueHandling = NullValueHandling.Ignore)]
    public string Email2 { get; set; }

    [JsonProperty("accounts", NullValueHandling = NullValueHandling.Ignore)]
    public string Accounts { get; set; }

    [JsonProperty("address_one", NullValueHandling = NullValueHandling.Ignore)]
    public string AddressOne { get; set; }

    [JsonProperty("address_two", NullValueHandling = NullValueHandling.Ignore)]
    public string AddressTwo { get; set; }

    [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
    public string City { get; set; }

    [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }

    [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
    public string Zip { get; set; }

    [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }

    [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
    public string Website { get; set; }

    [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
    public string Phone { get; set; }

    [JsonProperty("fax", NullValueHandling = NullValueHandling.Ignore)]
    public string Fax { get; set; }
  }
}