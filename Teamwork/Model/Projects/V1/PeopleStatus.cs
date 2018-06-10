using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects.Model
{
	public class PeopleStatus
	{

		public List<UserStatus> UserStatuses { get; set; }


	}


	public class UserStatus
	{

		[JsonProperty("geoipLocation", NullValueHandling = NullValueHandling.Ignore)]
		public string geoipLocation { get; set; }


		[JsonProperty("posted-on", NullValueHandling = NullValueHandling.Ignore)]
		public string PostDate { get; set; }

		[JsonProperty("first-name", NullValueHandling = NullValueHandling.Ignore)]
		public string Firstname { get; set; }

		[JsonProperty("avatar-url", NullValueHandling = NullValueHandling.Ignore)]
		public string avatar { get; set; }

		[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
		public int id { get; set; }

		[JsonProperty("last-changed-on", NullValueHandling = NullValueHandling.Ignore)]
		public string LastChanged { get; set; }

		[JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
		public string userID { get; set; }

		[JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
		public string Status { get; set; }

		[JsonProperty("last-name", NullValueHandling = NullValueHandling.Ignore)]
		public string Lastname { get; set; }

	}

}
