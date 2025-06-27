using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Project.Requests;
using Apps.BWX.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Apps.BWX.Webhooks;

[PollingEventList]
public class ProjectsPollingList(InvocationContext invocationContext) : BWXInvocable(invocationContext)
{
    [PollingEvent("On projects created", Description = "Polling event that periodically checks for new projects. If a new projects are found, it will return the new projects.")]
    public async Task<PollingEventResponse<ProjectsMemory, ProjectsResponse>> OnProjectsCreated(PollingEventRequest<ProjectsMemory> pollingRequest)
    {
        var isFirstRun = pollingRequest.Memory == null;
        var memory = InitializeMemory(pollingRequest.Memory);
        
        var request = CreateProjectsRequest(memory.LastPollingTime);
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

        var currentStatus = project.Status;

        var match = projectWithStatusRequest.Statuses
            .Any(s => string.Equals(s, currentStatus, StringComparison.OrdinalIgnoreCase));

        if (match && !memory.WasTriggered)
        {
            return new PollingEventResponse<ProjectStatusMemory, ProjectDto>
            {
                Result = project,
                Memory = new ProjectStatusMemory
                {
                    PreviousStatus = currentStatus,
                    WasTriggered = true
                },
                FlyBird = true
            };
        }

        return new PollingEventResponse<ProjectStatusMemory, ProjectDto>
        {
            Result = project,
            Memory = new ProjectStatusMemory
            {
                PreviousStatus = currentStatus,
                WasTriggered = memory.WasTriggered
            },
            FlyBird = false
        };
    }

    [PollingEvent("On projects status changed", Description = "Polling event that periodically checks for projects with updated statuses that match your criteria.")]
    public async Task<PollingEventResponse<ProjectStatusMemoryGranular, ProjectsResponse>> OnGranularProjectStatusChanged(PollingEventRequest<ProjectStatusMemoryGranular> pollingRequest,
        [PollingEventParameter] ProjectWithStatusGranularRequest projectWithStatusRequest)
    {
        // initialize memory on the first run and return early
        if (pollingRequest.Memory == null)
        {
            return new PollingEventResponse<ProjectStatusMemoryGranular, ProjectsResponse>
            {
                Result = new([]),
                Memory = new ProjectStatusMemoryGranular
                {
                    LastPollingTime = DateTime.UtcNow,
                    ProjectsPreviousStatus = new()
                },
                FlyBird = false
            };
        }

        // main logic as it's not the first run
        List<ProjectDto> returnedProjects = [];
        List<ProjectDto> projectsToFlyWith = [];
        var memory = pollingRequest.Memory;
        var filterById = !string.IsNullOrEmpty(projectWithStatusRequest.ProjectId);
        var filterByReference = !string.IsNullOrEmpty(projectWithStatusRequest.Reference);
        var filterByStatuses = projectWithStatusRequest.Statuses?.Any() ?? false;
        var filterByTags = projectWithStatusRequest.Tags?.Any() ?? false;

        if (!string.IsNullOrEmpty(projectWithStatusRequest.ProjectId))
        {
            var projectRequest = new GetProjectRequest { ProjectId = projectWithStatusRequest.ProjectId };
            returnedProjects.Add(await GetProject(projectRequest));
        }
        else
        {
            var request = CreateProjectsRequest(memory.LastPollingTime);
            returnedProjects.AddRange(await Client.Paginate<ProjectDto>(request));
        }

        foreach (var project in returnedProjects)
        {
            // required filters
            var previousStatus = memory.ProjectsPreviousStatus.GetValueOrDefault(project.Uuid, "no-previous-project-status");
            if (string.Equals(project.Status, previousStatus, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            memory.ProjectsPreviousStatus[project.Uuid] = project.Status;

            var isNewStatusMatching = projectWithStatusRequest.Statuses?
                .Any(s => string.Equals(s, project.Status, StringComparison.OrdinalIgnoreCase)) ?? false;
            if (!isNewStatusMatching)
            {
                continue;
            }

            // optional filters
            var isIdMatching = string.Equals(project.Uuid, projectWithStatusRequest.ProjectId, StringComparison.OrdinalIgnoreCase);
            if (filterById && !isIdMatching)
            {
                continue;
            }

            var isReferenceMatching = project.Reference.Equals(projectWithStatusRequest.Reference, StringComparison.OrdinalIgnoreCase);
            if (filterByReference && !isReferenceMatching)
            {
                continue;
            }

            var areTagsMatching = projectWithStatusRequest.Tags?
                .Any(a => project.Tags.Any(b => b.Equals(a, StringComparison.OrdinalIgnoreCase))) ?? false;
            if (filterByTags && !areTagsMatching)
            {
                continue;
            }

            projectsToFlyWith.Add(project);
        }

        memory.LastPollingTime = DateTime.UtcNow;

        return new PollingEventResponse<ProjectStatusMemoryGranular, ProjectsResponse>
        {
            Result = new(projectsToFlyWith),
            Memory = memory,
            FlyBird = projectsToFlyWith.Count > 0
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
    
    private RestRequest CreateProjectsRequest(DateTime lastPollingTime)
    {
        var request = new RestRequest("/api/v3/project");

        var startCreateDate = lastPollingTime.ToString("yyyy-MM-dd");
        request.AddQueryParameter("startCreateDate", startCreateDate);

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
