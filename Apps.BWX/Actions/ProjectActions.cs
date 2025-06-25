using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using RestSharp;
using Newtonsoft.Json;
using Apps.BWX.Models.Project.Responses;
using Apps.BWX.Models.Project.Requests;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Apps.BWX.Actions;

[ActionList]
public class ProjectActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : BWXInvocable(invocationContext)
{
    /** 
     * !!!Warning!!! 
     * Since BWX API is the same API their web platform uses 
     * and many endpoints are not described or irrelevant in BWX API documentation - 
     * some parts of code are based on the endpoints which are used by BWX web platform. (It could be both v3 or v2 endpoints)
     * Next method is based on web platform calls
     * **/
    [Action("Search projects", Description = "Search projects based on provided filters")]
    public async Task<List<ProjectDto>> SearchProjects([ActionParameter] SearchProjectRequest searchProjects)
    {
        var request = new RestRequest($"/api/v3/project");
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

        request.AddQueryParameter("fileName", searchProjects?.FileName);

        if (searchProjects.ProjectStatuses != null && searchProjects.ProjectStatuses.Any())
            foreach (var status in searchProjects.ProjectStatuses)
                request.AddQueryParameter("status", status);
        if (searchProjects.Tags != null && searchProjects.Tags.Any())
            foreach (var tag in searchProjects.Tags)
                request.AddQueryParameter("tags", tag);

        return await Client.Paginate<ProjectDto>(request);
    }

    [Action("Get project", Description = "Get project by ID")]
    public async Task<ProjectDto> GetProject([ActionParameter] GetProjectRequest input)
    {
        var request = new RestRequest($"/api/v3/project/{input.ProjectId}", Method.Get);
        return await Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }

    [Action("Create project", Description = "Create project with provided parameters")]
    public async Task<ProjectDto> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var request = new RestRequest($"/api/v3/project?inferDefaultSettings={input?.InferDefaultSettings?.ToString().ToLower() ?? "true"}", Method.Post);
        request.AddJsonBody(new
        {
            reference = input.Reference,
            orgUnitUUID = input.OrgUnitUUID,
            contactUUID = input.ContactUUID,
            sourceLocale = input.SourceLocale,
            notes = input.Notes,
            tags = input.Tags,
        });
        return await Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }

    [Action("Upload file to project", Description = "Upload file to project")]
    public async Task<WorkUnitDto> UploadFileToProject(
        [ActionParameter] GetProjectRequest getProjectRequest,
        [ActionParameter] UploadFileRequest uploadFileRequest)
    {
        var request = new RestRequest($"/api/v3/project/{getProjectRequest.ProjectId}/resource", Method.Post)
            .AddJsonBody(new
            {
                name = uploadFileRequest?.FileName ?? uploadFileRequest.File.Name,
                path = uploadFileRequest?.FilePath ?? uploadFileRequest.File.Name,
                notes = uploadFileRequest?.Notes ?? string.Empty
            });
        
        var projectFileInfoDto = await Client.ExecuteWithErrorHandling<ProjectFileInfoDto>(request);

        var uploadRequest = new RestRequest($"/api/v3/project/{getProjectRequest.ProjectId}/resource/{projectFileInfoDto.Uuid}/content", Method.Put);
        var fileBytes = await (await fileManagementClient.DownloadAsync(uploadFileRequest.File)).GetByteData();
        uploadRequest.AlwaysMultipartFormData = true;
        uploadRequest.AddFile("file", fileBytes, uploadFileRequest.File.Name);
        await Client.ExecuteWithErrorHandling(uploadRequest);

        var createWorkUnitRequest = new RestRequest($"/api/v3/project/{getProjectRequest.ProjectId}/work-unit?bulk=true", Method.Post);
        createWorkUnitRequest.AddJsonBody(JsonConvert.SerializeObject(
            new List<WorkUnitCreateDto>() {
                new WorkUnitCreateDto()
                {
                    ProjectResourceUuid = projectFileInfoDto.Uuid,
                    Workflows = uploadFileRequest.Workflows,
                    TargetLocales = uploadFileRequest.TargetLocales,
                }
            }));
        return (await Client.ExecuteWithErrorHandling<List<WorkUnitDto>>(createWorkUnitRequest)).First();
    }

    [Action("Change project status", Description = "Change project status to provided status")]
    public async Task<ProjectDto> ChangeProjectStatus(
        [ActionParameter] GetProjectRequest getProjectRequest,
        [ActionParameter] ChangeProjectStatusRequest changeProjectStatusRequest)
    {
        var request = new RestRequest($"/api/v3/project/{getProjectRequest.ProjectId}/status", Method.Post);
        request.AddJsonBody(new
        {
            newStatus = changeProjectStatusRequest.ProjectStatus,
            reason = changeProjectStatusRequest.Reason
        });
        return await Client.ExecuteWithErrorHandling<ProjectDto>(request);
    }

    [Action("Download translated files", Description = "Download translated files for project")]
    public async Task<DownloadTranslatedFilesResponse> DownloadTranslatedFiles(
        [ActionParameter] GetProjectRequest getProjectRequest,
        [ActionParameter] DownloadTranslatedFilesRequest downloadTranslatedFilesRequest)
    {
        string requestUuid = await InitiateTranslationDownload(getProjectRequest.ProjectId, downloadTranslatedFilesRequest);
        string downloadUrl = await WaitForTranslationPreparation(getProjectRequest.ProjectId, requestUuid);
        byte[] fileContent = await DownloadTranslationArchive(downloadUrl);

        var project = await GetProject(getProjectRequest);
        return await ProcessTranslationFiles(fileContent, project.SourceLocale, project.TargetLocales);
    }

    private async Task<string> InitiateTranslationDownload(string projectId, DownloadTranslatedFilesRequest downloadRequest)
    {
        var initiateRequest = new RestRequest($"/api/v3/project/{projectId}/download", Method.Post);
        AddResourcesAndLocalesParameters(initiateRequest, downloadRequest);

        var initiateResponse = await Client.ExecuteWithErrorHandling<DownloadTranslationInitiateResponse>(initiateRequest);
        return initiateResponse.RequestUuid;
    }

    private async Task<string> WaitForTranslationPreparation(string projectId, string requestUuid)
    {
        var statusRequest = new RestRequest(
            $"/api/v3/project/{projectId}/download/{requestUuid}/status", Method.Get);

        const int maxAttempts = 30;
        const int pollingIntervalMs = 20000;
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            if (attempts > 0)
            {
                await Task.Delay(pollingIntervalMs);
            }

            var statusResponse = await Client.ExecuteWithErrorHandling<DownloadTranslationStatusResponse>(statusRequest);

            if (statusResponse.Status == "COMPLETED")
            {
                return statusResponse.DownloadUrl;
            }

            attempts++;
        }

        throw new PluginApplicationException("Timeout waiting for translation files to be prepared");
    }

    private async Task<byte[]> DownloadTranslationArchive(string downloadUrl)
    {
        var client = new RestClient();
        var downloadRequest = new RestRequest(downloadUrl, Method.Get);
        var downloadResponse = await client.ExecuteAsync(downloadRequest);

        if (!downloadResponse.IsSuccessful)
        {
            throw new Exception($"Failed to download translation files: {downloadResponse.ErrorMessage}");
        }

        return downloadResponse.RawBytes!;
    }

    private async Task<DownloadTranslatedFilesResponse> ProcessTranslationFiles(byte[] archiveContent, string sourceLanguage, List<string> targetLanguages)
    {
        using var resultStream = new MemoryStream(archiveContent);
        var files = await resultStream.GetFilesFromZip();

        var translatedFiles = new DownloadTranslatedFilesResponse();
        foreach (var file in files)
        {
            var uploadedFile = await fileManagementClient.UploadAsync(
                file.FileStream,
                MimeMapping.MimeUtility.GetMimeMapping(file.UploadName),
                file.UploadName);

            var fileWithLanguages = new FileWithLanguagesResponse
            {
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguages.FirstOrDefault(x => uploadedFile.Name.StartsWith(x)) ?? string.Empty,
                File = uploadedFile
            };

            translatedFiles.TranslatedFiles.Add(fileWithLanguages);
        }

        return translatedFiles;
    }

    private void AddResourcesAndLocalesParameters(RestRequest request, DownloadTranslatedFilesRequest downloadRequest)
    {
        if (downloadRequest.Resources != null && downloadRequest.Resources.Any())
        {
            foreach (var resourceId in downloadRequest.Resources)
            {
                request.AddQueryParameter("resources", resourceId);
            }
        }

        if (downloadRequest.Locales != null && downloadRequest.Locales.Any())
        {
            foreach (var locale in downloadRequest.Locales)
            {
                request.AddQueryParameter("locales", locale);
            }
        }
    }
}