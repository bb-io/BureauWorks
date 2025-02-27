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

public class ProjectManagerDataHandler(InvocationContext invocationContext)
    : BWXInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    async Task<IEnumerable<DataSourceItem>> IAsyncDataSourceItemHandler.GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new RestRequest($"/api/v3/user", Method.Get);
        request.AddQueryParameter("roles", "PROJECT_MANAGER");
        request.AddQueryParameter("simple", "true");
        request.AddQueryParameter("name", context.SearchString);
        var users = await Client.PaginateOnce<UserDto>(request);

        return users.Select(x=> new DataSourceItem(x.Uuid, x.Name));
    }
}