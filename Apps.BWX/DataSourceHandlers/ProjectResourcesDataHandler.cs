﻿using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Models.Project.Requests;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.DataSourceHandlers
{
    public class ProjectResourcesDataHandler(
        InvocationContext invocationContext,
        [ActionParameter] GetProjectRequest projectRequest)
        : BWXInvocable(invocationContext), IAsyncDataSourceItemHandler
    {
        async Task<IEnumerable<DataSourceItem>> IAsyncDataSourceItemHandler.GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(projectRequest?.ProjectId))
                throw new PluginMisconfigurationException("Please select project first!");

            var request = new RestRequest($"/api/v3/project/{projectRequest.ProjectId}/resource/simple", Method.Get);
            var projectResources = await Client.ExecuteWithErrorHandling<List<ProjectResourceDto>>(request);

            return projectResources.Where(el =>
                    context.SearchString is null ||
                    el.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                    .Select(x => new DataSourceItem(x.Uuid, x.Name));
        }
    }
}
