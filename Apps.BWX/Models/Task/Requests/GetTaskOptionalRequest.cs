using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Models.Task.Requests;

public class GetTaskOptionalRequest
{
    [Display("Task ID")]
    public string? TaskId { get; set; }
}