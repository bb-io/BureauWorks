namespace Apps.BWX.Webhooks.Payload;

public class WorkUnitStatusChangedEvent
{
    public int BeginIndex { get; set; }
    public int Chars { get; set; }
    public int ConfirmedNonTranslatable { get; set; }
    public int ConfirmedSegments { get; set; }
    public int EndIndex { get; set; }
    public string EventType { get; set; }
    public string Id { get; set; }
    public string NewStatus { get; set; }
    public string PreviousStatus { get; set; }
    public string ProjectFileId { get; set; }
    public string ProjectFileName { get; set; }
    public int ProjectStepLevel { get; set; }
    public string SourceLocale { get; set; }
    public string TargetLocale { get; set; }
    public int TotalNonTranslatable { get; set; }
    public int TotalSegments { get; set; }
    public string TranslatedFileUrl { get; set; }
    public int Words { get; set; }
    public string Workflow { get; set; }
    public bool IsLastWorkflow { get; set; }
}