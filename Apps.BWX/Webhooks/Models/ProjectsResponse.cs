using Apps.BWX.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Models;

public class ProjectsResponse(List<ProjectDto> projects)
{
    [Display("Projects")]
    public List<ProjectDto> Projects { get; set; } = projects;

    [Display("Total count")]
    public double TotalCount { get; set; } = projects.Count;
}