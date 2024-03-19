using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.DataSourceHandlers
{
    public class ProjectDataHandler : BWXInvocable, IAsyncDataSourceHandler
    {
        public ProjectDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
        {
            var request = new BWXRequest($"/api/v3/project", Method.Get, Creds);
            var projects = await Client.Paginate<ProjectDto>(request);

            return projects.Where(el =>
                    context.SearchString is null ||
                    el.Reference.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(k => k.Uuid, v => $"{v.Reference} ({v.Name})");
        }
    }
}
