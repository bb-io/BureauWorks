using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using DocumentFormat.OpenXml.Drawing;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.DataSourceHandlers
{
    public class GlossaryDataHandler : BWXInvocable, IAsyncDataSourceHandler
    {
        public GlossaryDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
        {
            var request = new RestRequest($"/api/v3/glossary", Method.Get);
            request.AddQueryParameter("name", context.SearchString);
            var glossaries = await Client.PaginateOnce<GlossaryDto>(request);

            return glossaries.ToDictionary(k => k.Uuid, v => v.Name);
        }
    }
}
