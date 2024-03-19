using Apps.BWX.Api;
using Apps.BWX.Constants;
using Apps.BWX.Dtos;
using Apps.BWX.Extensions;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Requests.Channel;
using Apps.BWX.Models.Requests.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.Actions;

[ActionList]
public class ProjectActions : BWXInvocable
{
    public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Search projects", Description = "Search projects")]
    public async Task<List<ProjectDto>> SearchProjects([ActionParameter] GetProjectRequest input)
    {
        var request = new BWXRequest($"/api/v3/project", Method.Get, Creds);
        return await Client.Paginate<ProjectDto>(request);
    }

    [Action("Get project", Description = "Get project")]
    public Task<ProjectDto> GetProject([ActionParameter] GetProjectRequest input)
    {
        var request = new BWXRequest($"/api/v3/project/{input.ProjectId}", Method.Get, Creds);
        return Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }
}