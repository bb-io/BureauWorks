using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class WorkUnitStatusChangedEvent
{
    [Display("Work unit ID")]
    public string Id { get; set; }

    [Display("Begin index")]
    public int BeginIndex { get; set; }
    public int Chars { get; set; }

    [Display("Confirmed non translatable")]
    public int ConfirmedNonTranslatable { get; set; }

    [Display("Confirmed segments")]
    public int ConfirmedSegments { get; set; }

    [Display("End index")]
    public int EndIndex { get; set; }

    [Display("Event type")]
    public string EventType { get; set; }

    [Display("New status")]
    public string NewStatus { get; set; }

    [Display("Previous status")]
    public string PreviousStatus { get; set; }

    [Display("Project file ID")]
    public string ProjectFileId { get; set; }

    [Display("Project file name")]
    public string ProjectFileName { get; set; }

    [Display("Project step level")]
    public int ProjectStepLevel { get; set; }

    [Display("Source locale")]
    public string SourceLocale { get; set; }

    [Display("Target locale")]
    public string TargetLocale { get; set; }

    [Display("Total non translatable")]
    public int TotalNonTranslatable { get; set; }

    [Display("Total segments")]
    public int TotalSegments { get; set; }

    [Display("Translated file url")]
    public string TranslatedFileUrl { get; set; }
    public int Words { get; set; }
    public string Workflow { get; set; }

    [Display("Is last workflow")]
    public bool IsLastWorkflow { get; set; }
}