using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class ProjectTranslationFinishedEvent
{

    //[Display("Project ID")]
    //public int ProjectId { get; set; }

    [Display("Project ID")]
    public string ProjectUuid { get; set; }

    [Display("Project name")]
    public string ProjectName { get; set; }

    [Display("Total work units completed")]
    public int TotalWorkUnitsCompleted { get; set; }

    [Display("Total work units failed")]
    public int TotalWorkUnitsFailed { get; set; }

    [Display("Total work units")]
    public int TotalWorkUnits { get; set; }

    [Display("Event type")]
    public string EventType { get; set; }
}