using Apps.BWX.DataSourceHandlers;
using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Project.Requests;

public class ProjectWithStatusGranularRequest
{
    [Display("Status"), StaticDataSource(typeof(ProjectStatusDataHandler))]
    public IEnumerable<string> Statuses { get; set; } = new List<string>();

    [Display("Project ID"), DataSource(typeof(ProjectDataHandler))]
    public string? ProjectId { get; set; }

    [Display("Reference")]
    public string? Reference { get; set; }

    [Display("Tags")]
    public IEnumerable<string>? Tags { get; set; } = new List<string>();
}
