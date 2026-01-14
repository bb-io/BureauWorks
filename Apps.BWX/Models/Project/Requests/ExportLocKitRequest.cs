using Apps.BWX.DataSourceHandlers;
using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Project.Requests;

public class ExportLocKitRequest
{
    [Display("LOC kit type")]
    [StaticDataSource(typeof(LocKitTypeHandler))]
    public string LocKitTypeJob { get; set; }

    [Display("Work unit UUIDs")]
    [DataSource(typeof(WorkUnitDataHandler))]
    public IEnumerable<string>? WorkUnitUuids { get; set; }

    [Display("Workflow level")]
    public int WorkflowLevel { get; set; }
}