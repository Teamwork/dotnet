using System;
using System.Collections.Generic;
using System.Text;

namespace Teamwork.Shared.Schema.Projects.v1.Response
{
    public partial class SearchResult
    {
        [JsonProperty("searchResult", NullValueHandling = NullValueHandling.Ignore)]
        public SearchResultClass SearchResultSearchResult { get; set; }

        [JsonProperty("STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

    public partial class SearchResultClass
    {
        [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
        public List<SearchResultTask> Tasks { get; set; }

        [JsonProperty("people", NullValueHandling = NullValueHandling.Ignore)]
        public List<Person> People { get; set; }

        [JsonProperty("projects", NullValueHandling = NullValueHandling.Ignore)]
        public List<Project> Projects { get; set; }

        [JsonProperty("moreAvailable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MoreAvailable { get; set; }
    }

    public partial class SearchResultTask
    {

        [JsonIgnore]
        public string BaseUrl
        {
            get;
            set;
        }

        [JsonIgnore]
        public string ProjectURL => BaseUrl + "/projects/" + ProjectId;

        [JsonIgnore]
        public string TaskListUrl => BaseUrl + "/tasklists/" + TaskListId;

        [JsonIgnore]
        public string DirectUrl => BaseUrl + "/tasks/" + Id.ToString();

        [JsonProperty("taskListId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TaskListId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("projectName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectName { get; set; }

        [JsonProperty("projectId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? ProjectId { get; set; }

        [JsonProperty("taskEstimateMinutes", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TaskEstimateMinutes { get; set; }

        [JsonProperty("taskDisplayOrder", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TaskDisplayOrder { get; set; }

        [JsonProperty("taskParentTaskId", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskParentTaskId { get; set; }

        [JsonProperty("lastUpdated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Tag> Tags { get; set; }

        [JsonProperty("taskProgress", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TaskProgress { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }

        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Completed { get; set; }

        [JsonProperty("taskListName", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskListName { get; set; }
    }

}
