using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class ProjectStatusChangedPayload
{
    [Display("Project ID")]
    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    //[Display("Creation timestamp")]
    //[JsonProperty("creation_timestamp")]
    //public long CreationTimestamp { get; set; }
    public string Creator { get; set; }

    [Display("Creator email")]
    [JsonProperty("creator_email")]
    public string CreatorEmail { get; set; }

    [Display("Event type")]
    [JsonProperty("event_type")]
    public string EventType { get; set; }

    //[Display("ID")]
    //[JsonProperty("id")]
    //public int Id { get; set; }

    [JsonProperty("instructions")]
    public string Instructions { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [Display("New status")]
    [JsonProperty("new_status")]
    public string NewStatus { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }

    [Display("Previous status")]
    [JsonProperty("previous_status")]
    public string PreviousStatus { get; set; }

    [JsonProperty("reference")]
    public string Reference { get; set; }

    [Display("Source locale")]
    [JsonProperty("source_locale")]
    public string SourceLocale { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("tags")]
    public List<string> Tags { get; set; }

    [Display("Target locales")]
    [JsonProperty("target_locales")]
    public List<string> TargetLocales { get; set; }

    [JsonProperty("workflows")]
    public List<string> Workflows { get; set; }

    [Display("Custom fields")]
    [JsonProperty("custom_fields")]
    public List<string> CustomFields { get; set; }
}