using Apps.BWX.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Project.Requests;

public class GetProjectOptionalRequest
{
    [Display("Project ID")]
    [DataSource(typeof(ProjectDataHandler))]
    public string? ProjectId { get; set; }
}