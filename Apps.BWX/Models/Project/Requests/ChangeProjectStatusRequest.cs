using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.BWX.Models.Project.Requests;

public class ChangeProjectStatusRequest
{
    [Display("Project status")]
    [StaticDataSource(typeof(ProjectStatusDataHandler))]
    public string ProjectStatus { get; set; }

    public string Reason { get; set; }
}