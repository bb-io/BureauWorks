using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class WorkUnitStatusChangedEvent
{
    [Display("Work unit ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [Display("Begin index")]
    [JsonProperty("begin_index", NullValueHandling = NullValueHandling.Ignore)]
    public int BeginIndex { get; set; }

    [JsonProperty("chars")]
    public int Chars { get; set; }

    [Display("Confirmed non translatable")]
    [JsonProperty("confirmed_non_translatable", NullValueHandling = NullValueHandling.Ignore)]
    public int ConfirmedNonTranslatable { get; set; }

    [Display("Confirmed segments")]
    [JsonProperty("confirmed_segments", NullValueHandling = NullValueHandling.Ignore)]
    public int ConfirmedSegments { get; set; }

    [Display("End index")]
    [JsonProperty("end_index")]
    public int EndIndex { get; set; }

    [Display("Event type")]
    [JsonProperty("event_type")]
    public string EventType { get; set; }

    [Display("New status")]
    [JsonProperty("new_status")]
    public string NewStatus { get; set; }

    [Display("Previous status")]
    [JsonProperty("previous_status")]
    public string PreviousStatus { get; set; }

    [Display("Project file ID")]
    [JsonProperty("project_file_id")]
    public string ProjectFileId { get; set; }

    [Display("Project file name")]
    [JsonProperty("project_file_name")]
    public string ProjectFileName { get; set; }

    [Display("Project step level", NullValueHandling = NullValueHandling.Ignore)]
    [JsonProperty("project_step_level")]
    public int ProjectStepLevel { get; set; }

    [Display("Source locale")]
    [JsonProperty("source_locale")]
    public string SourceLocale { get; set; }

    [Display("Target locale")]
    [JsonProperty("target_locale")]
    public string TargetLocale { get; set; }

    [Display("Total non translatable")]
    [JsonProperty("total_non_translatable")]
    public int TotalNonTranslatable { get; set; }

    [Display("Total segments")]
    [JsonProperty("total_segments", NullValueHandling = NullValueHandling.Ignore)]
    public int TotalSegments { get; set; }

    [Display("Translated file url")]
    [JsonProperty("translated_file_url")]
    public string TranslatedFileUrl { get; set; }

    [JsonProperty("words", NullValueHandling = NullValueHandling.Ignore)]
    public int Words { get; set; }

    [JsonProperty("workflow")]
    public string Workflow { get; set; }

    [Display("Is last workflow?")]
    [JsonProperty("is_last_workflow")]
    public bool IsLastWorkflow { get; set; }
}