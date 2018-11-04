using System;
using Newtonsoft.Json;

namespace Teamwork.Shared.Schema.Spaces {
    public partial class Space
    {
        [JsonProperty("spaceId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpaceId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("isHomepageHeaderEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsHomepageHeaderEnabled { get; set; }

        [JsonProperty("homePageId", NullValueHandling = NullValueHandling.Ignore)]
        public long? HomePageId { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public State? State { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public TedBy CreatedBy { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public TedBy UpdatedBy { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("spaceColor", NullValueHandling = NullValueHandling.Ignore)]
        public string SpaceColor { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }
    }
}