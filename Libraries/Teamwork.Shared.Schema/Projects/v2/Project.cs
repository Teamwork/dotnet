using Teamwork.Shared.Common.Response;

namespace Teamwork.Schema.Projects.V2
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ProjectListResponse : BaseListResponse<Project>
    {
        [JsonProperty("STATUS")]
        public string Status { get; set; }

        [JsonProperty("categoryPath")]
        public List<CategoryPath> CategoryPath { get; set; }

        [JsonProperty("letters")]
        public List<string> Letters { get; set; }

        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }
    }

    public partial class CategoryPath
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Project
    {
        [JsonProperty("activePages")]
        public ActivePages ActivePages { get; set; }

        [JsonProperty("activeUserIsProjectAdmin")]
        public bool ActiveUserIsProjectAdmin { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("defaultPrivacy")]
        public DefaultPrivacy DefaultPrivacy { get; set; }

        [JsonProperty("defaults")]
        public Defaults Defaults { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("directFileUploadsEnabled")]
        public bool DirectFileUploadsEnabled { get; set; }

        [JsonProperty("filesAutoNewVersion")]
        public bool FilesAutoNewVersion { get; set; }

        [JsonProperty("harvestTimersEnabled")]
        public bool HarvestTimersEnabled { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("integrations")]
        public Integrations Integrations { get; set; }

        [JsonProperty("isProjectAdmin")]
        public bool IsProjectAdmin { get; set; }

        [JsonProperty("lastChangedOn")]
        public DateTimeOffset LastChangedOn { get; set; }

        [JsonProperty("logo")]
        public Uri Logo { get; set; }

        [JsonProperty("logoFromCompany", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LogoFromCompany { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notifyEveryone")]
        public bool NotifyEveryone { get; set; }

        [JsonProperty("notifySettings")]
        public Dictionary<string, bool> NotifySettings { get; set; }

        [JsonProperty("overviewStartPage")]
        public OverviewStartPage OverviewStartPage { get; set; }

        [JsonProperty("permissions")]
        public Permissions Permissions { get; set; }

        [JsonProperty("privacyEnabled")]
        public bool PrivacyEnabled { get; set; }

        [JsonProperty("projectOwnerId")]
        public long ProjectOwnerId { get; set; }

        [JsonProperty("replyByEmailEnabled")]
        public bool ReplyByEmailEnabled { get; set; }

        [JsonProperty("showAnnouncement")]
        public bool ShowAnnouncement { get; set; }

        [JsonProperty("skipWeekends")]
        public bool SkipWeekends { get; set; }

        [JsonProperty("starred")]
        public bool Starred { get; set; }

        [JsonProperty("startPage")]
        public StartPage StartPage { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("subStatus")]
        public SubStatus SubStatus { get; set; }

        [JsonProperty("tasksStartPage")]
        public TasksStartPage TasksStartPage { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public Category Category { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Category> Tags { get; set; }

        [JsonProperty("announcement", NullValueHandling = NullValueHandling.Ignore)]
        public string Announcement { get; set; }

        [JsonProperty("boardData", NullValueHandling = NullValueHandling.Ignore)]
        public BoardData BoardData { get; set; }

        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? EndDate { get; set; }

        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? StartDate { get; set; }
    }

    public partial class ActivePages
    {
        [JsonProperty("billing")]
        public bool Billing { get; set; }

        [JsonProperty("comments")]
        public bool Comments { get; set; }

        [JsonProperty("files")]
        public bool Files { get; set; }

        [JsonProperty("links")]
        public bool Links { get; set; }

        [JsonProperty("messages")]
        public bool Messages { get; set; }

        [JsonProperty("milestones")]
        public bool Milestones { get; set; }

        [JsonProperty("notebooks")]
        public bool Notebooks { get; set; }

        [JsonProperty("riskRegister")]
        public bool RiskRegister { get; set; }

        [JsonProperty("tasks")]
        public bool Tasks { get; set; }

        [JsonProperty("time")]
        public bool Time { get; set; }
    }

    public partial class BoardData
    {
        [JsonProperty("board")]
        public Category Board { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }

        [JsonProperty("column")]
        public Category Column { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Card
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isOwner")]
        public bool IsOwner { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public partial class Defaults
    {
        [JsonProperty("privacy")]
        public Privacy Privacy { get; set; }
    }

    public partial class Integrations
    {
        [JsonProperty("microsoftConnectors")]
        public MicrosoftConnectors MicrosoftConnectors { get; set; }

        [JsonProperty("oneDriveBusiness")]
        public OneDriveBusiness OneDriveBusiness { get; set; }

        [JsonProperty("sharepoint")]
        public OneDriveBusiness Sharepoint { get; set; }

        [JsonProperty("xero")]
        public Xero Xero { get; set; }
    }

    public partial class MicrosoftConnectors
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public partial class OneDriveBusiness
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("folder")]
        public Folder Folder { get; set; }

        [JsonProperty("folderName")]
        public Folder FolderName { get; set; }
    }

    public partial class Xero
    {
        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("organisation")]
        public string Organisation { get; set; }
    }

    public partial class Permissions
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("canAccess")]
        public bool CanAccess { get; set; }

        [JsonProperty("canAccessBox")]
        public bool CanAccessBox { get; set; }

        [JsonProperty("canAccessDropbox")]
        public bool CanAccessDropbox { get; set; }

        [JsonProperty("canAccessGoogleDocs")]
        public bool CanAccessGoogleDocs { get; set; }

        [JsonProperty("canAccessInvoiceTracking")]
        public bool CanAccessInvoiceTracking { get; set; }

        [JsonProperty("canAccessOneDrive")]
        public bool CanAccessOneDrive { get; set; }

        [JsonProperty("canAccessOneDriveBusiness")]
        public bool CanAccessOneDriveBusiness { get; set; }

        [JsonProperty("canAccessPortfolio")]
        public bool CanAccessPortfolio { get; set; }

        [JsonProperty("canAccessSharePoint")]
        public bool CanAccessSharePoint { get; set; }

        [JsonProperty("canAccessTemplates")]
        public bool CanAccessTemplates { get; set; }

        [JsonProperty("canAddFiles")]
        public bool CanAddFiles { get; set; }

        [JsonProperty("canAddLinks")]
        public bool CanAddLinks { get; set; }

        [JsonProperty("canAddMessages")]
        public bool CanAddMessages { get; set; }

        [JsonProperty("canAddMilestones")]
        public bool CanAddMilestones { get; set; }

        [JsonProperty("canAddNotebooks")]
        public bool CanAddNotebooks { get; set; }

        [JsonProperty("canAddProjectUpdate")]
        public bool CanAddProjectUpdate { get; set; }

        [JsonProperty("canAddProjects")]
        public bool CanAddProjects { get; set; }

        [JsonProperty("canAddTaskLists")]
        public bool CanAddTaskLists { get; set; }

        [JsonProperty("canAddTasks")]
        public bool CanAddTasks { get; set; }

        [JsonProperty("canBeAssignedToTasksAndMilestones")]
        public bool CanBeAssignedToTasksAndMilestones { get; set; }

        [JsonProperty("canEditAllTasks")]
        public bool CanEditAllTasks { get; set; }

        [JsonProperty("canLogTime")]
        public bool CanLogTime { get; set; }

        [JsonProperty("canManagePeople")]
        public bool CanManagePeople { get; set; }

        [JsonProperty("canManagePortfolio")]
        public bool CanManagePortfolio { get; set; }

        [JsonProperty("canSetPrivacy")]
        public bool CanSetPrivacy { get; set; }

        [JsonProperty("canViewProjectUpdate")]
        public bool CanViewProjectUpdate { get; set; }

        [JsonProperty("isArchived")]
        public bool IsArchived { get; set; }

        [JsonProperty("isObserving")]
        public bool IsObserving { get; set; }

        [JsonProperty("notifyDefaults")]
        public NotifyDefaults NotifyDefaults { get; set; }

        [JsonProperty("projectAdministrator")]
        public bool ProjectAdministrator { get; set; }

        [JsonProperty("receiveEmailNotifications")]
        public bool ReceiveEmailNotifications { get; set; }

        [JsonProperty("viewAllTimeLogs")]
        public bool ViewAllTimeLogs { get; set; }

        [JsonProperty("viewEstimatedTime")]
        public bool ViewEstimatedTime { get; set; }

        [JsonProperty("viewInvoices")]
        public bool ViewInvoices { get; set; }

        [JsonProperty("viewLinks")]
        public bool ViewLinks { get; set; }

        [JsonProperty("viewMessagesAndFiles")]
        public bool ViewMessagesAndFiles { get; set; }

        [JsonProperty("viewNotebook")]
        public bool ViewNotebook { get; set; }

        [JsonProperty("viewRiskRegister")]
        public bool ViewRiskRegister { get; set; }

        [JsonProperty("viewTasksAndMilestones")]
        public bool ViewTasksAndMilestones { get; set; }

        [JsonProperty("viewTimeLog")]
        public bool ViewTimeLog { get; set; }
    }

    public partial class NotifyDefaults
    {
        [JsonProperty("newTasks")]
        public long NewTasks { get; set; }
    }

    public enum Name { TeamworkCom };

    public enum DefaultPrivacy { Open, OwnerCompany };

    public enum Privacy { C1, Empty };

    public enum Folder { Root };

    public enum OverviewStartPage { Activity, Default, Summary };

    public enum StartPage { Overview, Projectoverview, Tasks };

    public enum Status { Active };

    public enum SubStatus { Current, Late };

    public enum TasksStartPage { Default, List };

    public enum TypeEnum { Normal };

    public partial class SpacesResponse
    {
        public static SpacesResponse FromJson(string json) => JsonConvert.DeserializeObject<SpacesResponse>(json, Teamwork.Schema.Projects.V2.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SpacesResponse self) => JsonConvert.SerializeObject(self, Teamwork.Schema.Projects.V2.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                NameConverter.Singleton,
                DefaultPrivacyConverter.Singleton,
                PrivacyConverter.Singleton,
                FolderConverter.Singleton,
                OverviewStartPageConverter.Singleton,
                StartPageConverter.Singleton,
                StatusConverter.Singleton,
                SubStatusConverter.Singleton,
                TasksStartPageConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Teamwork.com")
            {
                return Name.TeamworkCom;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            if (value == Name.TeamworkCom)
            {
                serializer.Serialize(writer, "Teamwork.com");
                return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class DefaultPrivacyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefaultPrivacy) || t == typeof(DefaultPrivacy?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "open":
                    return DefaultPrivacy.Open;
                case "owner company":
                    return DefaultPrivacy.OwnerCompany;
            }
            throw new Exception("Cannot unmarshal type DefaultPrivacy");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DefaultPrivacy)untypedValue;
            switch (value)
            {
                case DefaultPrivacy.Open:
                    serializer.Serialize(writer, "open");
                    return;
                case DefaultPrivacy.OwnerCompany:
                    serializer.Serialize(writer, "owner company");
                    return;
            }
            throw new Exception("Cannot marshal type DefaultPrivacy");
        }

        public static readonly DefaultPrivacyConverter Singleton = new DefaultPrivacyConverter();
    }

    internal class PrivacyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Privacy) || t == typeof(Privacy?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Privacy.Empty;
                case "c1":
                    return Privacy.C1;
            }
            throw new Exception("Cannot unmarshal type Privacy");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Privacy)untypedValue;
            switch (value)
            {
                case Privacy.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Privacy.C1:
                    serializer.Serialize(writer, "c1");
                    return;
            }
            throw new Exception("Cannot marshal type Privacy");
        }

        public static readonly PrivacyConverter Singleton = new PrivacyConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class FolderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Folder) || t == typeof(Folder?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "root")
            {
                return Folder.Root;
            }
            throw new Exception("Cannot unmarshal type Folder");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Folder)untypedValue;
            if (value == Folder.Root)
            {
                serializer.Serialize(writer, "root");
                return;
            }
            throw new Exception("Cannot marshal type Folder");
        }

        public static readonly FolderConverter Singleton = new FolderConverter();
    }

    internal class OverviewStartPageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OverviewStartPage) || t == typeof(OverviewStartPage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "activity":
                    return OverviewStartPage.Activity;
                case "default":
                    return OverviewStartPage.Default;
                case "summary":
                    return OverviewStartPage.Summary;
            }
            throw new Exception("Cannot unmarshal type OverviewStartPage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OverviewStartPage)untypedValue;
            switch (value)
            {
                case OverviewStartPage.Activity:
                    serializer.Serialize(writer, "activity");
                    return;
                case OverviewStartPage.Default:
                    serializer.Serialize(writer, "default");
                    return;
                case OverviewStartPage.Summary:
                    serializer.Serialize(writer, "summary");
                    return;
            }
            throw new Exception("Cannot marshal type OverviewStartPage");
        }

        public static readonly OverviewStartPageConverter Singleton = new OverviewStartPageConverter();
    }

    internal class StartPageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StartPage) || t == typeof(StartPage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "overview":
                    return StartPage.Overview;
                case "projectoverview":
                    return StartPage.Projectoverview;
                case "tasks":
                    return StartPage.Tasks;
            }
            throw new Exception("Cannot unmarshal type StartPage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StartPage)untypedValue;
            switch (value)
            {
                case StartPage.Overview:
                    serializer.Serialize(writer, "overview");
                    return;
                case StartPage.Projectoverview:
                    serializer.Serialize(writer, "projectoverview");
                    return;
                case StartPage.Tasks:
                    serializer.Serialize(writer, "tasks");
                    return;
            }
            throw new Exception("Cannot marshal type StartPage");
        }

        public static readonly StartPageConverter Singleton = new StartPageConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "active")
            {
                return Status.Active;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            if (value == Status.Active)
            {
                serializer.Serialize(writer, "active");
                return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class SubStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SubStatus) || t == typeof(SubStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "current":
                    return SubStatus.Current;
                case "late":
                    return SubStatus.Late;
            }
            throw new Exception("Cannot unmarshal type SubStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SubStatus)untypedValue;
            switch (value)
            {
                case SubStatus.Current:
                    serializer.Serialize(writer, "current");
                    return;
                case SubStatus.Late:
                    serializer.Serialize(writer, "late");
                    return;
            }
            throw new Exception("Cannot marshal type SubStatus");
        }

        public static readonly SubStatusConverter Singleton = new SubStatusConverter();
    }

    internal class TasksStartPageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TasksStartPage) || t == typeof(TasksStartPage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "default":
                    return TasksStartPage.Default;
                case "list":
                    return TasksStartPage.List;
            }
            throw new Exception("Cannot unmarshal type TasksStartPage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TasksStartPage)untypedValue;
            switch (value)
            {
                case TasksStartPage.Default:
                    serializer.Serialize(writer, "default");
                    return;
                case TasksStartPage.List:
                    serializer.Serialize(writer, "list");
                    return;
            }
            throw new Exception("Cannot marshal type TasksStartPage");
        }

        public static readonly TasksStartPageConverter Singleton = new TasksStartPageConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "normal")
            {
                return TypeEnum.Normal;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Normal)
            {
                serializer.Serialize(writer, "normal");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
