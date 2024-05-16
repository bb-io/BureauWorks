using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Project.Requests;
using Blackbird.Applications.Sdk.Common;
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
    public class ProjectResourcesDataHandler : BWXInvocable, IAsyncDataSourceHandler
    {
        public GetProjectRequest ProjectRequest { get; set; }

        public ProjectResourcesDataHandler(InvocationContext invocationContext, [ActionParameter] GetProjectRequest projectRequest) : base(invocationContext)
        {
            ProjectRequest = projectRequest;
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
        {
            if (string.IsNullOrEmpty(ProjectRequest?.ProjectId))
                throw new ArgumentException("Please select project first!");

            var request = new RestRequest($"/api/v3/project/{ProjectRequest.ProjectId}/resource/simple", Method.Get);
            var projectResources = await Client.ExecuteWithErrorHandling<List<ProjectResourceDto>>(request);

            return projectResources.Where(el =>
                    context.SearchString is null ||
                    el.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(k => k.Uuid, v => v.Name);
        }
    }
}
