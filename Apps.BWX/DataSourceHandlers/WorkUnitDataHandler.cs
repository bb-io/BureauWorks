using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Models;
using Apps.BWX.Models.Project.Requests;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Globalization;

namespace Apps.BWX.DataSourceHandlers;

public class WorkUnitDataHandler(
    InvocationContext context,
    [ActionParameter] GetProjectRequest project) 
    : BWXInvocable(context), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken ct)
    {
        var request = new RestRequest($"/api/v3/project/{project.ProjectId}/work-unit", Method.Get);
        var response = await Client.ExecuteWithErrorHandling<ContentWrapper<WorkUnitDataHandlerDto>>(request);
        return response.Content.Select(x => 
            new DataSourceItem(x.Uuid, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.WorkflowName.ToLower()))
        );
    }
}
