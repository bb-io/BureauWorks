using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

/** !!!Warning!!! 
 *  Since BWX API is the same API their web platform uses 
 *  and many endpoints are not described or irrelevant in BWX API documentation - 
 *  some parts of code are based on the endpoints which are used by BWX web platform. (It could be both v3 or v2 endpoints)
 *  Next method is based on web platform calls
 **/

namespace Apps.BWX.DataSourceHandlers;

public class OrganizationDataHandler : BWXInvocable, IAsyncDataSourceHandler
{
    public OrganizationDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var request = new BWXRequest($"/api/v2/organization", Method.Get, Creds);
        var languages = await Client.Paginate<OrganizationDto>(request);

        return languages.Where(el =>
                context.SearchString is null ||
                el.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(k => k.Uuid, v => v.Name);
    }
}