using Apps.BWX.Invocables;
using Apps.BWX.Models.Project.Requests;
using Apps.BWX.Models.Task.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.DataSourceHandlers;

public class TaskDataHandler(InvocationContext invocationContext, [ActionParameter] GetProjectRequest projectRequest)
    : BWXInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    async Task<IEnumerable<DataSourceItem>> IAsyncDataSourceItemHandler.GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new RestRequest($"/api/v3/task", Method.Get)
            .AddQueryParameter("projectUuid", projectRequest.ProjectId);
        var tasks = await Client.PaginateOnce<TaskDto>(request);
        
        return tasks.Where(x => context.SearchString == null || x.WorkUnit.Workflow.Contains(context.SearchString, StringComparison.InvariantCultureIgnoreCase))
            .Select(x=> new DataSourceItem(x.Uuid, $"{x.WorkUnit?.Workflow}"));
    }
}