using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Glossary.Requests;
using Apps.BWX.Models.Glossary.Responses;
using Apps.BWX.Models.Project.Requests;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Glossaries.Utils.Converters;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;
using System.Net.Mime;

namespace Apps.BWX.Actions;

[ActionList]
public class GlossaryActions : BWXInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public GlossaryActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Create glossary", Description = "Create new glossary")]
    public async Task<GlossaryDto> CreateGlossary(
        [ActionParameter] CreateGlossaryRequest input)
    {
        var request = new RestRequest($"/api/v3/glossary", Method.Post);
        request.AddJsonBody(new
        {
            name = input.Name,
            languages = input.Languages,
            organization = new
            {
                uuid = input.Organization
            },
            note = input.Note,
            domain = input.Domain,
            subDomain = input.Subdomain,
            orgUnits = input.OrgUnitUUIDs != null ? input.OrgUnitUUIDs.Select(x => new UuidDto(){ Uuid = x}).ToArray() : new UuidDto[] { }
        });
        return await Client.ExecuteWithErrorHandling<GlossaryDto>(request);
    }

    [Action("Export glossary", Description = "Export glossary")]
    public async Task<ExportGlossaryResponse> ExportGlossary([ActionParameter] ExportGlossaryRequest input)
    {
        var initExportRequest = new RestRequest($"/api/v3/glossary/export/{input.GlossaryId}/tbx", Method.Get);
        var initExportResult = await Client.ExecuteWithErrorHandling<ExportInitDto>(initExportRequest);

        var exportStatusRequest = new RestRequest($"/api/v3/glossary/export/{input.GlossaryId}/tbx/{initExportResult.RequestUuid}/status", Method.Get);
        var exportStatusResult = await Client.ExecuteWithErrorHandling<ExportStatusDto>(exportStatusRequest);
        while(exportStatusResult.Status != "COMPLETED")
        {
            Thread.Sleep(1000);
            exportStatusResult = await Client.ExecuteWithErrorHandling<ExportStatusDto>(exportStatusRequest);
        }
        var downloadTbxRequest = new RestRequest(exportStatusResult.DownloadUrl, Method.Get);
        var downloadTbxResult = await new RestClient().ExecuteAsync(downloadTbxRequest);

        var glossaryInfo = await GetGlossary(input);

        using var streamGlossaryData = new MemoryStream(downloadTbxResult.RawBytes);

        using var resultStream = await streamGlossaryData.ConvertFromTbxV2ToV3(glossaryInfo.Name);
        return new ExportGlossaryResponse() { File = await _fileManagementClient.UploadAsync(resultStream, MediaTypeNames.Application.Xml, $"{glossaryInfo.Name}.tbx") };
    }

    [Action("Import glossary", Description = "Import glossary")]
    public async Task ImportGlossary([ActionParameter] ImportGlossaryRequest input)
    {
        var fileStream = await _fileManagementClient.DownloadAsync(input.File);
        var fileTBXV2Stream = await fileStream.ConvertFromTbxV3ToV2();

        var initImportRequest = new RestRequest($"/api/v3/glossary/{input.GlossaryId}/import-tbx", Method.Post);
        initImportRequest.AddFile("tbxFile", await fileTBXV2Stream.GetByteData(), input.File.Name);

        await Client.ExecuteWithErrorHandling(initImportRequest);
    }

    private async Task<GlossaryDto> GetGlossary([ActionParameter] ExportGlossaryRequest input)
    {
        var request = new RestRequest($"/api/v3/glossary/{input.GlossaryId}", Method.Get);
        return await Client.ExecuteWithErrorHandling<GlossaryDto>(request);
    }
}
