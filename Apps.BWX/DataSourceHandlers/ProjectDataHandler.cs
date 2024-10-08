using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.DataSourceHandlers;

public class ProjectDataHandler(InvocationContext invocationContext)
    : BWXInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var request = new RestRequest($"/api/v3/project", Method.Get);
        request.AddQueryParameter("reference", context.SearchString);
        var projects = await Client.PaginateOnce<ProjectDto>(request);

        return projects.ToDictionary(k => k.Uuid, v => $"{v.Reference} ({v.Name})");
    }
}