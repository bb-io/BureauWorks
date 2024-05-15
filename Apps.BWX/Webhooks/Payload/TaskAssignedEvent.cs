using Apps.BWX.Converters;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class TaskAssignedEvent
{
    [Display("Task ID")]
    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    [Display("Acceptance date")]
    [JsonProperty("acceptance_date")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime AcceptanceDate { get; set; }

    [Display("Assign date")]
    [JsonProperty("assign_date")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime AssignDate { get; set; }

    [Display("Assigned by email")]
    [JsonProperty("assigned_by_email")]
    public string AssignedByEmail { get; set; }

    [Display("Assigned by name")]
    [JsonProperty("assigned_by_name")]
    public string AssignedByName { get; set; }

    [JsonProperty("assignee")]
    public string Assignee { get; set; }

    [Display("Assignee email")]
    [JsonProperty("assignee_email")]
    public string AssigneeEmail { get; set; }

    [Display("Assignee word rate")]
    [JsonProperty("assignee_word_rate", NullValueHandling = NullValueHandling.Ignore)]
    public double AssigneeWordRate { get; set; }

    [Display("Begin index")]
    [JsonProperty("begin_index", NullValueHandling = NullValueHandling.Ignore)]
    public long BeginIndex { get; set; }

    [Display("Creation date")]
    [JsonProperty("creation_timestamp")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime CreationTimestamp { get; set; }

    [JsonProperty("creator")]
    public string Creator { get; set; }

    [Display("Creator email")]
    [JsonProperty("creator_email")]
    public string CreatorEmail { get; set; }

    [Display("Delivery date")]
    [JsonProperty("delivery_date")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime DeliveryDate { get; set; }

    [Display("Due date")]
    [JsonProperty("due_date")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime DueDate { get; set; }

    //[Display("End index")]
    //[JsonProperty("end_index")]
    //public long EndIndex { get; set; }

    [Display("Event type")]
    [JsonProperty("event_type")]
    public string EventType { get; set; }

    [JsonProperty("files")]
    public List<string> Files { get; set; }

    //[Display("ID")]
    //[JsonProperty("id")]
    //public int Id { get; set; }

    [JsonProperty("instructions")]
    public string Instructions { get; set; }

    [Display("Minimum score required")]
    [JsonProperty("minimum_score_required", NullValueHandling = NullValueHandling.Ignore)]
    public double MinimumScoreRequired { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [Display("Reference files")]
    [JsonProperty("reference_files")]
    public List<string> ReferenceFiles { get; set; }

    //[Display("Scheduled date")]
    //[JsonProperty("scheduled_date")]
    //public long ScheduledDate { get; set; }

    //[Display("Skip date")]
    //[JsonProperty("skip_date")]
    //public long SkipDate { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("workflow")]
    public string Workflow { get; set; }

    [Display("Custom fields")]
    [JsonProperty("custom_fields")]
    public List<string> CustomFields { get; set; }
}