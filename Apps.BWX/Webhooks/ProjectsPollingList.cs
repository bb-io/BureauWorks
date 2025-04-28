using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Project.Requests;
using Apps.BWX.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;

namespace Apps.BWX.Webhooks;

[PollingEventList]
public class ProjectsPollingList(InvocationContext invocationContext) : BWXInvocable(invocationContext)
{
    [PollingEvent("On projects created", Description = "Polling event that periodically checks for new projects. If a new projects are found, it will return the new projects.")]
    public async Task<PollingEventResponse<ProjectsMemory, ProjectsResponse>> OnProjectsCreated(PollingEventRequest<ProjectsMemory> pollingRequest)
    {
        var isFirstRun = pollingRequest.Memory == null;
        var memory = InitializeMemory(pollingRequest.Memory);
        
        var request = CreateProjectsRequest(memory);
        var projects = await Client.Paginate<ProjectDto>(request);
        
        var newProjects = FilterNewProjects(projects, memory.ProjectIds);
        UpdateMemory(memory, newProjects);
        
        return new PollingEventResponse<ProjectsMemory, ProjectsResponse>
        {
            Result = new(newProjects),
            Memory = memory,
            FlyBird = isFirstRun ? false : newProjects.Any()
        };
    }
    
    [PollingEvent("On project status changed", Description = "Polling event that periodically checks for project status changes. If a project status changes, it will return the project with the new status.")]
    public async Task<PollingEventResponse<ProjectStatusMemory, ProjectDto>> OnProjectStatusChanged(PollingEventRequest<ProjectStatusMemory> pollingRequest,
        [PollingEventParameter] ProjectWithStatusRequest projectWithStatusRequest)
    {
        var project = await GetProject(projectWithStatusRequest);
        var memory = pollingRequest.Memory ?? new ProjectStatusMemory
        {
            PreviousStatus = string.Empty,
            WasTriggered = false
        };
        
        if (project.Status.Equals(projectWithStatusRequest.Status, StringComparison.OrdinalIgnoreCase) && memory.WasTriggered == false)
        {
            return new PollingEventResponse<ProjectStatusMemory, ProjectDto>
            {
                Result = project,
                Memory = new()
                {
                    PreviousStatus = project.Status,
                    WasTriggered = true
                },
                FlyBird = true
            };
        }
        
        return new PollingEventResponse<ProjectStatusMemory, ProjectDto>
        {
            Result = project,
            Memory = new()
            {
                PreviousStatus = project.Status,
                WasTriggered = memory.WasTriggered
            },
            FlyBird = false
        };
    }
    
    private async Task<ProjectDto> GetProject(GetProjectRequest input)
    {
        var request = new RestRequest($"/api/v3/project/{input.ProjectId}", Method.Get);
        return await Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }
    
    private ProjectsMemory InitializeMemory(ProjectsMemory? existingMemory)
    {
        return existingMemory ?? new ProjectsMemory
        {
            LastPollingTime = DateTime.UtcNow,
            ProjectIds = []
        };
    }
    
    private RestRequest CreateProjectsRequest(ProjectsMemory memory)
    {
        var request = new RestRequest("/api/v3/project");
        if (memory != null && memory.ProjectIds.Any())
        {
            var startCreateDate = memory.LastPollingTime.ToString("yyyy-MM-dd");
            request.AddQueryParameter("startCreateDate", startCreateDate);
        }
        
        return request;
    }
    
    private List<ProjectDto> FilterNewProjects(List<ProjectDto> allProjects, List<string> existingProjectIds)
    {
        return allProjects
            .Where(p => !existingProjectIds.Contains(p.Uuid))
            .ToList();
    }
    
    private void UpdateMemory(ProjectsMemory memory, List<ProjectDto> newProjects)
    {
        foreach (var project in newProjects)
        {
            memory.ProjectIds.Add(project.Uuid);
        }
        
        memory.LastPollingTime = DateTime.UtcNow;
    }
}
