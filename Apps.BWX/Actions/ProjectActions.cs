using Apps.BWX.Api;
using Apps.BWX.Constants;
using Apps.BWX.Dtos;
using Apps.BWX.Extensions;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Requests.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using RestSharp;
using System.IO.Compression;

namespace Apps.BWX.Actions;

[ActionList]
public class ProjectActions : BWXInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public ProjectActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    /** 
     * !!!Warning!!! 
     * Since BWX API is the same API their web platform uses 
     * and many endpoints are not described or irrelevant in BWX API documentation - 
     * some parts of code are based on the endpoints which are used by BWX web platform. (It could be both v3 or v2 endpoints)
     * Next method is based on web platform calls
     * **/
    [Action("Search projects", Description = "Search projects")]
    public async Task<List<ProjectDto>> SearchProjects([ActionParameter] SearchProjectRequest searchProjects)
    {      
        var request = new BWXRequest($"/api/v3/project", Method.Get, Creds);
        request.AddQueryParameter("name", searchProjects?.ProjectName);
        request.AddQueryParameter("organizationUuid", searchProjects?.Organization);
        request.AddQueryParameter("orgUnitUuid", searchProjects?.Client);
        request.AddQueryParameter("projectManagerUuid", searchProjects?.ProjectManager);
        request.AddQueryParameter("contactPersonUuid", searchProjects?.ContactPerson);
        request.AddQueryParameter("reference", searchProjects?.Reference);

        request.AddQueryParameter("startCreateDate", searchProjects.CreationDateStart?.ToString("yyyy-MM-dd"));
        request.AddQueryParameter("endCreateDate", searchProjects.CreationDateEnd?.ToString("yyyy-MM-dd"));
        request.AddQueryParameter("startDueDate", searchProjects.DueDateStart?.ToString("yyyy-MM-dd"));
        request.AddQueryParameter("endDueDate", searchProjects.DueDateEnd?.ToString("yyyy-MM-dd"));

        if (searchProjects.ProjectStatuses != null && searchProjects.ProjectStatuses.Any())
            foreach(var status in searchProjects.ProjectStatuses)
                request.AddQueryParameter("status", status);
        if (searchProjects.Tags != null && searchProjects.Tags.Any())
            foreach (var tag in searchProjects.Tags)
                request.AddQueryParameter("tags", tag);

        return await Client.Paginate<ProjectDto>(request);
    }

    [Action("Get project", Description = "Get project")]
    public Task<ProjectDto> GetProject([ActionParameter] GetProjectRequest input)
    {
        var request = new BWXRequest($"/api/v3/project/{input.ProjectId}", Method.Get, Creds);
        return Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }

    [Action("Create project", Description = "Create project")]
    public Task<ProjectDto> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var request = new BWXRequest($"/api/v3/project?inferDefaultSettings={input?.InferDefaultSettings?.ToString().ToLower() ?? "true"}", Method.Post, Creds);
        request.AddJsonBody(new
        {
            reference = input.Reference,
            orgUnitUUID = input.OrgUnitUUID,
            contactUUID = input.ContactUUID,
            sourceLocale = input.SourceLocale,
            notes = input.Notes,
            tags = input.Tags,
        });
        return Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }

    [Action("Upload file to project", Description = "Upload file to project")]
    public async Task<ProjectFileInfoDto> UploadFileToProject(
        [ActionParameter] GetProjectRequest getProjectRequest, 
        [ActionParameter] UploadFileRequest uploadFileRequest)
    {
        var request = new BWXRequest($"/api/v3/project/{getProjectRequest.ProjectId}/resource", Method.Post, Creds);
        request.AddJsonBody(new
        {
            name = uploadFileRequest?.FileName ?? uploadFileRequest.File.Name,
            path = uploadFileRequest?.FilePath ?? uploadFileRequest.File.Name,
            notes = uploadFileRequest?.Notes ?? string.Empty
        });
        var projectFileInfoDto = await Client.ExecuteWithErrorHandling<ProjectFileInfoDto>(request);

        var uploadRequest = new BWXRequest($"/api/v3/project/{getProjectRequest.ProjectId}/resource/{projectFileInfoDto.Uuid}/content", Method.Post, Creds);
        var fileBytes = await (await _fileManagementClient.DownloadAsync(uploadFileRequest.File)).GetByteData();
        uploadRequest.AddFile("file", fileBytes, uploadFileRequest.File.Name);
        await Client.ExecuteWithErrorHandling(uploadRequest);
        return projectFileInfoDto;
    }
}