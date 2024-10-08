using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.DataSourceHandlers;

public class OrganizationDataHandler(InvocationContext invocationContext)
    : BWXInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var request = new RestRequest($"/api/v2/organization", Method.Get);
        request.AddQueryParameter("name", context.SearchString);
        var organizations = await Client.PaginateOnce<OrganizationDto>(request);

        return organizations.ToDictionary(k => k.Uuid, v => v.Name);
    }
}