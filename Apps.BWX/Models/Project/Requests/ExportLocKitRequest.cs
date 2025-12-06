using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Models.Project.Requests;

public class ExportLocKitRequest
{
    [Display("LOC kit type (XLIFF or XLSX)")]
    public string LocKitTypeJob { get; set; }

    [Display("Work unit UUIDs")]
    public IEnumerable<string>? WorkUnitUuids { get; set; }

    [Display("Workflow level")]
    public int WorkflowLevel { get; set; }
}