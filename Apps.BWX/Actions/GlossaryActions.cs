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
        var request = new BWXRequest($"/api/v3/glossary", Method.Post, Creds);
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
        var initExportRequest = new BWXRequest($"/api/v3/glossary/export/{input.GlossaryId}/tbx", Method.Get, Creds);
        var initExportResult = await Client.ExecuteWithErrorHandling<ExportInitDto>(initExportRequest);

        var exportStatusRequest = new BWXRequest($"/api/v3/glossary/export/{input.GlossaryId}/tbx/{initExportResult.RequestUuid}/status", Method.Get, Creds);
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

    //[Action("Import glossary", Description = "Import glossary")]
    //public async Task ImportGlossary([ActionParameter] ImportGlossaryRequest input)
    //{
    //    var client = new PhraseTmsClient(InvocationContext.AuthenticationCredentialsProviders);

    //    var fileStream = await _fileManagementClient.DownloadAsync(input.File);
    //    var fileTBXV2Stream = await fileStream.ConvertFromTBXV3ToV2();

    //    var endpointGlossaryData = $"/api2/v1/termBases/{input.GlossaryUId}/upload";
    //    var requestGlossaryData = new PhraseTmsRequest(endpointGlossaryData.WithQuery(new { updateTerms = false }), Method.Post, InvocationContext.AuthenticationCredentialsProviders);
    //    requestGlossaryData.AddHeader("Content-Disposition", $"filename*=UTF-8''{input.File.Name}");
    //    requestGlossaryData.AddParameter("application/octet-stream", fileTBXV2Stream.GetByteData().Result, ParameterType.RequestBody);

    //    await client.ExecuteWithHandling(requestGlossaryData);
    //}

    private async Task<GlossaryDto> GetGlossary([ActionParameter] ExportGlossaryRequest input)
    {
        var request = new BWXRequest($"/api/v3/glossary/{input.GlossaryId}", Method.Get, Creds);
        return await Client.ExecuteWithErrorHandling<GlossaryDto>(request);
    }
}
