using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.DataSourceHandlers
{
    public class GlossaryDataHandler(InvocationContext invocationContext)
        : BWXInvocable(invocationContext), IAsyncDataSourceItemHandler
    {
        async Task<IEnumerable<DataSourceItem>> IAsyncDataSourceItemHandler.GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
        {
            var request = new RestRequest($"/api/v3/glossary", Method.Get);
            request.AddQueryParameter("name", context.SearchString);
            var glossaries = await Client.PaginateOnce<GlossaryDto>(request);

            return glossaries.Select(x => new DataSourceItem(x.Uuid, x.Name));
        }
    }
}
