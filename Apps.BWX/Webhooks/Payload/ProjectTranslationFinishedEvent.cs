using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class ProjectTranslationFinishedEvent
{

    //[Display("Project ID")]
    //[JsonProperty("project_id")]
    //public int ProjectId { get; set; }

    [Display("Project ID")]
    [JsonProperty("project_uuid")]
    public string ProjectUuid { get; set; }

    [Display("Project name")]
    [JsonProperty("project_name")]
    public string ProjectName { get; set; }

    [Display("Total work units completed")]
    [JsonProperty("total_work_units_completed")]
    public int TotalWorkUnitsCompleted { get; set; }

    [Display("Total work units failed")]
    [JsonProperty("total_work_units_failed")]
    public int TotalWorkUnitsFailed { get; set; }

    [Display("Total work units")]
    [JsonProperty("total_work_units")]
    public int TotalWorkUnits { get; set; }

    [Display("Event type")]
    [JsonProperty("event_type")]
    public string EventType { get; set; }
}