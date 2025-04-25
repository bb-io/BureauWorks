using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;

namespace Apps.BWX.Webhooks;

[PollingEventList]
public class PollingList(InvocationContext invocationContext) : BWXInvocable(invocationContext)
{
    [PollingEvent("On projects created", Description = "Polling event that periodically checks for new projects. If a new projects are found, it will return the new projects.")]
    public async Task<PollingEventResponse<ProjectsMemory, List<ProjectDto>>> OnProjectsCreated(PollingEventRequest<ProjectsMemory> pollingRequest)
    {
        var isFirstRun = pollingRequest.Memory == null;
        var memory = InitializeMemory(pollingRequest.Memory);
        
        var request = CreateProjectsRequest(memory);
        var projects = await FetchProjects(request);
        
        var newProjects = FilterNewProjects(projects, memory.ProjectIds);
        UpdateMemory(memory, newProjects);
        
        return CreatePollingResponse(newProjects, memory, isFirstRun);
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
    
    private async Task<List<ProjectDto>> FetchProjects(RestRequest request)
    {
        return await Client.Paginate<ProjectDto>(request);
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
    
    private PollingEventResponse<ProjectsMemory, List<ProjectDto>> CreatePollingResponse(
        List<ProjectDto> newProjects, 
        ProjectsMemory memory, 
        bool isFirstRun)
    {
        return new PollingEventResponse<ProjectsMemory, List<ProjectDto>>
        {
            Result = newProjects,
            Memory = memory,
            FlyBird = isFirstRun ? false : newProjects.Any()
        };
    }
}
