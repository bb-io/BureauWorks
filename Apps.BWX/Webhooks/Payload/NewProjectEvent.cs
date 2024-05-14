using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class NewProjectEvent
{
    [Display("Project ID")]
    public string Uuid { get; set; }

    //[Display("Creation timestamp")]
    //public long CreationTimestamp { get; set; }
    public string Creator { get; set; }

    [Display("Creator email")]
    public string CreatorEmail { get; set; }

    [Display("Event type")]
    public string EventType { get; set; }

    //[Display("ID")]
    //public int Id { get; set; }
    public string Instructions { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public string Reference { get; set; }

    [Display("Source locale")]
    public string SourceLocale { get; set; }
    public string Status { get; set; }
    public List<string> Tags { get; set; }

    [Display("Target locales")]
    public List<string> TargetLocales { get; set; }
    public List<string> Workflows { get; set; }

    [Display("Custom fields")]
    public List<string> CustomFields { get; set; }
}