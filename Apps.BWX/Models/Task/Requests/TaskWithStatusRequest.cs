using Apps.BWX.DataSourceHandlers;
using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Task.Requests;

public class TaskWithStatusRequest
{
    [Display("Project ID"), DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; } = string.Empty;
    
    [Display("Task ID"), DataSource(typeof(TaskDataHandler))]
    public string TaskId { get; set; } = string.Empty;
    
    [Display("Status"), StaticDataSource(typeof(TaskStatusDataHandler))]
    public string Status { get; set; } = string.Empty;
}