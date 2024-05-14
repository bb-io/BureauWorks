using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Dtos;

public class WorkUnitDto
{
    [Display("Work unit ID")]
    public string Uuid { get; set; }

    [Display("Work ID")]
    public string WorkId { get; set; }
    public string Name { get; set; }

    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [Display("Target language")]
    public string TargetLanguage { get; set; }
    public string Filename { get; set; }

    //[Display("Creation timestamp")]
    //public long CreationTimestamp { get; set; }

    //[Display("Last update")]
    //public long LastUpdate { get; set; }
    public int Sequence { get; set; }
    public string Workflow { get; set; }

    [Display("Project ID")]
    public string ProjectUUID { get; set; }

    [Display("Project resource ID")]
    public string ProjectResourceUuid { get; set; }
}