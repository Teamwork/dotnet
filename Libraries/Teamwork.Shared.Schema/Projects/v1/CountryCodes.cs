// ==========================================================
// File: TeamworkProjects.Portable.CountryCodes.cs
// Created: 14.02.2015
// Created By: Tim cadenbach
// 
// Copyright (C) 2015 Tim Cadenbach
// License: Apache License 2.0
// ==========================================================

using System.Collections.Generic;

namespace Teamwork.Shared.Schema.Projects.V1
{
  public class CountryCode
  {
    public string ShortCode { get; set; }
    public string Description { get; set; }
  }

  public class CountryCodes : List<CountryCode>
  {
    public CountryCodes()
    {
      Add(new CountryCode {ShortCode = "A2", Description = "Satellite Provider"});
      Add(new CountryCode {ShortCode = "A2", Description = "Satellite Provider"});
      Add(new CountryCode {ShortCode = "AD", Description = "Andorra"});
      Add(new CountryCode {ShortCode = "AE", Description = "United Arab Emirates"});
      Add(new CountryCode {ShortCode = "AF", Description = "Afghanistan"});
      Add(new CountryCode {ShortCode = "AG", Description = "Antigua and Barbuda"});
      Add(new CountryCode {ShortCode = "AI", Description = "Anguilla"});
      Add(new CountryCode {ShortCode = "AL", Description = "Albania"});
      Add(new CountryCode {ShortCode = "AM", Description = "Armenia"});
      Add(new CountryCode {ShortCode = "AN", Description = "Netherlands Antilles"});
      Add(new CountryCode {ShortCode = "AO", Description = "Angola"});
      Add(new CountryCode {ShortCode = "AP", Description = "Asia/Pacific Region "});
      Add(new CountryCode {ShortCode = "AQ", Description = "Antarctica"});
      Add(new CountryCode {ShortCode = "AR", Description = "Argentina"});
      Add(new CountryCode {ShortCode = "AS", Description = "American Samoa"});
      Add(new CountryCode {ShortCode = "AT", Description = "Austria"});
      Add(new CountryCode {ShortCode = "AU", Description = "Australia"});
      Add(new CountryCode {ShortCode = "AW", Description = "Aruba"});
      Add(new CountryCode {ShortCode = "AZ", Description = "Azerbaijan "});
      Add(new CountryCode {ShortCode = "BA", Description = "Bosnia and Herzegovina"});
      Add(new CountryCode {ShortCode = "BB", Description = "Barbados"});
      Add(new CountryCode {ShortCode = "BD", Description = "Banglades"});
      Add(new CountryCode {ShortCode = "BE", Description = "Belgium"});
      Add(new CountryCode {ShortCode = "BF", Description = "Burkina Faso"});
      Add(new CountryCode {ShortCode = "BG", Description = "Bulgaria"});
      Add(new CountryCode {ShortCode = "BH", Description = "Bahrain"});
      Add(new CountryCode {ShortCode = "BI", Description = "Burundi"});
      Add(new CountryCode {ShortCode = "BJ", Description = "Benin"});
      Add(new CountryCode {ShortCode = "BM", Description = "Bermuda"});
      Add(new CountryCode {ShortCode = "BN", Description = "Brunei Darussalam"});
      Add(new CountryCode {ShortCode = "BO", Description = "Bolivia"});
      Add(new CountryCode {ShortCode = "BR", Description = "Brazil"});
      Add(new CountryCode {ShortCode = "BS", Description = "Bahamas"});
      Add(new CountryCode {ShortCode = "BT", Description = "Bhutan"});
      Add(new CountryCode {ShortCode = "BV", Description = "Bouvet Island"});
      Add(new CountryCode {ShortCode = "BW", Description = "Botswana"});
      Add(new CountryCode {ShortCode = "BY", Description = "Belarus"});
      Add(new CountryCode {ShortCode = "BZ", Description = "Belize"});
      Add(new CountryCode {ShortCode = "CA", Description = "Canada"});
      Add(new CountryCode {ShortCode = "CD", Description = "Congo"});
      Add(new CountryCode {ShortCode = "CF", Description = "Central African Republic"});
      Add(new CountryCode {ShortCode = "CG", Description = "Congo"});
      Add(new CountryCode {ShortCode = "CH", Description = "Switzerland"});
      Add(new CountryCode {ShortCode = "CI", Description = "Cote D'Ivoire"});
      Add(new CountryCode {ShortCode = "CK", Description = "Cook Islands"});
      Add(new CountryCode {ShortCode = "CL", Description = "Chile"});
      Add(new CountryCode {ShortCode = "CM", Description = "Cameroon"});
      Add(new CountryCode {ShortCode = "CN", Description = "China"});
      Add(new CountryCode {ShortCode = "CO", Description = "Colombia"});
      Add(new CountryCode {ShortCode = "CR", Description = "Costa Rica"});
      Add(new CountryCode {ShortCode = "CU", Description = "Cuba"});
      Add(new CountryCode {ShortCode = "CV", Description = "Cape Verde"});
      Add(new CountryCode {ShortCode = "CY", Description = "Cyprus"});
      Add(new CountryCode {ShortCode = "CZ", Description = "Czech Republic"});
      Add(new CountryCode {ShortCode = "DE", Description = "Germany"});
      Add(new CountryCode {ShortCode = "DJ", Description = "Djibouti"});
      Add(new CountryCode {ShortCode = "DK", Description = "Denmark"});
      Add(new CountryCode {ShortCode = "DM", Description = "Dominica"});
      Add(new CountryCode {ShortCode = "DO", Description = "Dominican Republic"});
      Add(new CountryCode {ShortCode = "DZ", Description = "Algeria"});
      Add(new CountryCode {ShortCode = "EC", Description = "Ecuador"});
      Add(new CountryCode {ShortCode = "EE", Description = "Estonia"});
      Add(new CountryCode {ShortCode = "EG", Description = "Egypt"});
      Add(new CountryCode {ShortCode = "EH", Description = "Western Sahara"});
      Add(new CountryCode {ShortCode = "ER", Description = "Eritrea"});
      Add(new CountryCode {ShortCode = "ES", Description = "Spain"});
      Add(new CountryCode {ShortCode = "ET", Description = "Ethiopia"});
      Add(new CountryCode {ShortCode = "EU", Description = "Europe"});
      Add(new CountryCode {ShortCode = "FI", Description = "Finland"});
      Add(new CountryCode {ShortCode = "FJ", Description = "Fiji"});
      Add(new CountryCode {ShortCode = "FK", Description = "Falkland Islands (Malvinas)"});
      Add(new CountryCode {ShortCode = "FM", Description = "Micronesia"});
      Add(new CountryCode {ShortCode = "FO", Description = "Faroe Islands"});
      Add(new CountryCode {ShortCode = "FR", Description = "France"});
      Add(new CountryCode {ShortCode = "GA", Description = "Gabon"});
      Add(new CountryCode {ShortCode = "GB", Description = "United Kingdom"});
      Add(new CountryCode {ShortCode = "GD", Description = "Grenada"});
      Add(new CountryCode {ShortCode = "GE", Description = "Georgia"});
      Add(new CountryCode {ShortCode = "GH", Description = "Ghana"});
      Add(new CountryCode {ShortCode = "GI", Description = "Gibraltar"});
      Add(new CountryCode {ShortCode = "GL", Description = "Greenland"});
      Add(new CountryCode {ShortCode = "GM", Description = "Gambia"});
      Add(new CountryCode {ShortCode = "GN", Description = "Guinea"});
      Add(new CountryCode {ShortCode = "GP", Description = "Guadeloupe"});
      Add(new CountryCode {ShortCode = "GQ", Description = "Equatorial Guinea"});
      Add(new CountryCode {ShortCode = "GR", Description = "Greece"});
      Add(new CountryCode {ShortCode = "GT", Description = "Guatemala"});
      Add(new CountryCode {ShortCode = "GU", Description = "Guam"});
      Add(new CountryCode {ShortCode = "GW", Description = "Guinea-Bissau"});
      Add(new CountryCode {ShortCode = "GY", Description = "Guyana"});
      Add(new CountryCode {ShortCode = "HK", Description = "Hong Kong"});
      Add(new CountryCode {ShortCode = "HM", Description = "Heard Island and McDonald Islands"});
      Add(new CountryCode {ShortCode = "HN", Description = "Honduras"});
      Add(new CountryCode {ShortCode = "HR", Description = "Croatia"});
      Add(new CountryCode {ShortCode = "HT", Description = "Haiti"});
      Add(new CountryCode {ShortCode = "HU", Description = "Hungary"});
      Add(new CountryCode {ShortCode = "ID", Description = "Indonesia"});
      Add(new CountryCode {ShortCode = "IE", Description = "Ireland"});
      Add(new CountryCode {ShortCode = "IL", Description = "Israel"});
      Add(new CountryCode {ShortCode = "IN", Description = "India"});
      Add(new CountryCode {ShortCode = "IO", Description = "British Indian Ocean Territory"});
      Add(new CountryCode {ShortCode = "IQ", Description = "Iraq"});
      Add(new CountryCode {ShortCode = "IR", Description = "Iran"});
      Add(new CountryCode {ShortCode = "IS", Description = "Iceland"});
      Add(new CountryCode {ShortCode = "IT", Description = "Italy"});
      Add(new CountryCode {ShortCode = "JM", Description = "Jamaica"});
      Add(new CountryCode {ShortCode = "JO", Description = "Jordan"});
      Add(new CountryCode {ShortCode = "JP", Description = "Japan"});
      Add(new CountryCode {ShortCode = "KE", Description = "Kenya"});
      Add(new CountryCode {ShortCode = "KG", Description = "Kyrgyzstan"});
      Add(new CountryCode {ShortCode = "KH", Description = "Cambodia"});
      Add(new CountryCode {ShortCode = "KI", Description = "Kiribati"});
      Add(new CountryCode {ShortCode = "KM", Description = "Comoros"});
      Add(new CountryCode {ShortCode = "KN", Description = "Saint Kitts and Nevis"});
      Add(new CountryCode {ShortCode = "KP", Description = "Korea"});
      Add(new CountryCode {ShortCode = "KR", Description = "Korea"});
      Add(new CountryCode {ShortCode = "KW", Description = "Kuwait"});
      Add(new CountryCode {ShortCode = "KY", Description = "Cayman Islands"});
      Add(new CountryCode {ShortCode = "KZ", Description = "Kazakstan"});
      Add(new CountryCode {ShortCode = "LA", Description = "Lao People's Democratic Republic"});
      Add(new CountryCode {ShortCode = "LB", Description = "Lebanon"});
      Add(new CountryCode {ShortCode = "LC", Description = "Saint Lucia"});
      Add(new CountryCode {ShortCode = "LI", Description = "Liechtenstein"});
      Add(new CountryCode {ShortCode = "LK", Description = "Sri Lanka"});
      Add(new CountryCode {ShortCode = "LR", Description = "Liberia"});
      Add(new CountryCode {ShortCode = "LS", Description = "Lesotho"});
      Add(new CountryCode {ShortCode = "LT", Description = "Lithuania"});
      Add(new CountryCode {ShortCode = "LU", Description = "Luxembourg"});
      Add(new CountryCode {ShortCode = "LV", Description = "Latvia"});
      Add(new CountryCode {ShortCode = "LY", Description = "Libyan Arab Jamahiriya"});
      Add(new CountryCode {ShortCode = "MA", Description = "Morocco"});
      Add(new CountryCode {ShortCode = "MC", Description = "Monaco"});
      Add(new CountryCode {ShortCode = "MD", Description = "Moldova"});
      Add(new CountryCode {ShortCode = "MG", Description = "Madagascar"});
      Add(new CountryCode {ShortCode = "MH", Description = "Marshall Islands"});
      Add(new CountryCode {ShortCode = "MK", Description = "Macedonia"});
      Add(new CountryCode {ShortCode = "ML", Description = "Mali"});
      Add(new CountryCode {ShortCode = "MM", Description = "Myanmar"});
      Add(new CountryCode {ShortCode = "MN", Description = "Mongolia"});
      Add(new CountryCode {ShortCode = "MO", Description = "Macau"});
      Add(new CountryCode {ShortCode = "MP", Description = "Northern Mariana Islands"});
      Add(new CountryCode {ShortCode = "MQ", Description = "Martinique"});
      Add(new CountryCode {ShortCode = "MR", Description = "Mauritania"});
      Add(new CountryCode {ShortCode = "MS", Description = "Montserrat"});
      Add(new CountryCode {ShortCode = "MT", Description = "Malta"});
      Add(new CountryCode {ShortCode = "MU", Description = "Mauritius"});
      Add(new CountryCode {ShortCode = "MV", Description = "Maldives"});
      Add(new CountryCode {ShortCode = "MW", Description = "Malawi"});
      Add(new CountryCode {ShortCode = "MX", Description = "Mexico"});
      Add(new CountryCode {ShortCode = "MY", Description = "Malaysia"});
      Add(new CountryCode {ShortCode = "MZ", Description = "Mozambique"});
      Add(new CountryCode {ShortCode = "NA", Description = "Namibia"});
      Add(new CountryCode {ShortCode = "NC", Description = "New Caledonia"});
      Add(new CountryCode {ShortCode = "NE", Description = "Niger"});
      Add(new CountryCode {ShortCode = "NG", Description = "Nigeria"});
      Add(new CountryCode {ShortCode = "NI", Description = "Nicaragua"});
      Add(new CountryCode {ShortCode = "NL", Description = "Netherlands"});
      Add(new CountryCode {ShortCode = "NO", Description = "Norway"});
      Add(new CountryCode {ShortCode = "NP", Description = "Nepal"});
      Add(new CountryCode {ShortCode = "NR", Description = "Nauru"});
      Add(new CountryCode {ShortCode = "NZ", Description = "New Zealand"});
      Add(new CountryCode {ShortCode = "OM", Description = "Oman"});
      Add(new CountryCode {ShortCode = "PA", Description = "Panama"});
      Add(new CountryCode {ShortCode = "PE", Description = "Peru"});
      Add(new CountryCode {ShortCode = "PF", Description = "French Polynesia"});
      Add(new CountryCode {ShortCode = "PG", Description = "Papua New Guinea"});
      Add(new CountryCode {ShortCode = "PH", Description = "Philippines"});
      Add(new CountryCode {ShortCode = "PK", Description = "Pakistan"});
      Add(new CountryCode {ShortCode = "PL", Description = "Poland"});
      Add(new CountryCode {ShortCode = "PR", Description = "Puerto Rico"});
      Add(new CountryCode {ShortCode = "PS", Description = "Palestinian Territory"});
      Add(new CountryCode {ShortCode = "PT", Description = "Portugal"});
      Add(new CountryCode {ShortCode = "PW", Description = "Palau"});
      Add(new CountryCode {ShortCode = "PY", Description = "Paraguay"});
      Add(new CountryCode {ShortCode = "QA", Description = "Qatar"});
      Add(new CountryCode {ShortCode = "RE", Description = "Reunion"});
      Add(new CountryCode {ShortCode = "RO", Description = "Romania"});
      Add(new CountryCode {ShortCode = "RU", Description = "Russian Federation"});
      Add(new CountryCode {ShortCode = "RW", Description = "Rwanda"});
      Add(new CountryCode {ShortCode = "SA", Description = "Saudi Arabia"});
      Add(new CountryCode {ShortCode = "SB", Description = "Solomon Islands"});
      Add(new CountryCode {ShortCode = "SC", Description = "Seychelles"});
      Add(new CountryCode {ShortCode = "SD", Description = "Sudan"});
      Add(new CountryCode {ShortCode = "SE", Description = "Sweden"});
      Add(new CountryCode {ShortCode = "SG", Description = "Singapore"});
      Add(new CountryCode {ShortCode = "SI", Description = "Slovenia"});
      Add(new CountryCode {ShortCode = "SK", Description = "Slovakia"});
      Add(new CountryCode {ShortCode = "SL", Description = "Sierra Leone"});
      Add(new CountryCode {ShortCode = "SM", Description = "San Marino"});
      Add(new CountryCode {ShortCode = "SN", Description = "Senegal"});
      Add(new CountryCode {ShortCode = "SO", Description = "Somalia"});
      Add(new CountryCode {ShortCode = "SR", Description = "Suriname"});
      Add(new CountryCode {ShortCode = "ST", Description = "Sao Tome and Principe"});
      Add(new CountryCode {ShortCode = "SV", Description = "El Salvador"});
      Add(new CountryCode {ShortCode = "SY", Description = "Syrian Arab Republic"});
      Add(new CountryCode {ShortCode = "SZ", Description = "Swaziland"});
      Add(new CountryCode {ShortCode = "TC", Description = "Turks and Caicos Islands"});
      Add(new CountryCode {ShortCode = "TD", Description = "Chad"});
      Add(new CountryCode {ShortCode = "TF", Description = "French Southern Territories"});
      Add(new CountryCode {ShortCode = "TG", Description = "Togo"});
      Add(new CountryCode {ShortCode = "TH", Description = "Thailand"});
      Add(new CountryCode {ShortCode = "TJ", Description = "Tajikistan"});
      Add(new CountryCode {ShortCode = "TK", Description = "Tokelau"});
      Add(new CountryCode {ShortCode = "TM", Description = "Turkmenistan"});
      Add(new CountryCode {ShortCode = "TN", Description = "Tunisia"});
      Add(new CountryCode {ShortCode = "TO", Description = "Tonga"});
      Add(new CountryCode {ShortCode = "TR", Description = "Turkey"});
      Add(new CountryCode {ShortCode = "TT", Description = "Trinidad and Tobago"});
      Add(new CountryCode {ShortCode = "TV", Description = "Tuvalu"});
      Add(new CountryCode {ShortCode = "TW", Description = "Taiwan"});
      Add(new CountryCode {ShortCode = "TZ", Description = "Tanzania"});
      Add(new CountryCode {ShortCode = "UA", Description = "Ukraine"});
      Add(new CountryCode {ShortCode = "UG", Description = "Uganda"});
      Add(new CountryCode {ShortCode = "UM", Description = "United States Minor Outlying Islands"});
      Add(new CountryCode {ShortCode = "US", Description = "United States"});
      Add(new CountryCode {ShortCode = "UY", Description = "Uruguay"});
      Add(new CountryCode {ShortCode = "UZ", Description = "Uzbekistan"});
      Add(new CountryCode {ShortCode = "VA", Description = "Holy See (Vatican City State)"});
      Add(new CountryCode {ShortCode = "VC", Description = "Saint Vincent and the Grenadines"});
      Add(new CountryCode {ShortCode = "VE", Description = "Venezuela"});
      Add(new CountryCode {ShortCode = "VG", Description = "Virgin Islands"});
      Add(new CountryCode {ShortCode = "VI", Description = "Virgin Islands"});
      Add(new CountryCode {ShortCode = "VN", Description = "Vietnam"});
      Add(new CountryCode {ShortCode = "VU", Description = "Vanuatu"});
      Add(new CountryCode {ShortCode = "WF", Description = "Wallis and Futuna"});
      Add(new CountryCode {ShortCode = "WS", Description = "Samoa"});
      Add(new CountryCode {ShortCode = "YE", Description = "Yemen"});
      Add(new CountryCode {ShortCode = "YU", Description = "Yugoslavia"});
      Add(new CountryCode {ShortCode = "ZA", Description = "South Africa"});
      Add(new CountryCode {ShortCode = "ZM", Description = "Zambia"});
      Add(new CountryCode {ShortCode = "ZW", Description = "Zimbabwe"});
    }
  }
}