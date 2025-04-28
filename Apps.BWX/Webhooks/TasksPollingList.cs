using Apps.BWX.Invocables;
using Apps.BWX.Models.Task.Requests;
using Apps.BWX.Models.Task.Response;
using Apps.BWX.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;

namespace Apps.BWX.Webhooks;

[PollingEventList]
public class TasksPollingList(InvocationContext invocationContext) : BWXInvocable(invocationContext)
{
    [PollingEvent("On task status changed", Description = "Polling event that periodically checks for new tasks. If a new tasks are found, it will return the new tasks.")]
    public async Task<PollingEventResponse<TaskStatusMemory, TaskDto>> OnTaskStatusChanged(PollingEventRequest<TaskStatusMemory> pollingRequest,
        [PollingEventParameter] TaskWithStatusRequest taskWithStatusRequest)
    {
        var task = await GetTask(taskWithStatusRequest);
        var memory = pollingRequest.Memory ?? new TaskStatusMemory
        {
            WasTriggered = false
        };

        if (task.Status.Equals(taskWithStatusRequest.Status, StringComparison.OrdinalIgnoreCase) && memory.WasTriggered == false)
        {
            return new PollingEventResponse<TaskStatusMemory, TaskDto>
            {
                Result = task,
                Memory = new()
                {
                    WasTriggered = true
                },
                FlyBird = true
            };
        }

        return new PollingEventResponse<TaskStatusMemory, TaskDto>
        {
            Result = task,
            Memory = new()
            {
                WasTriggered = memory.WasTriggered
            },
            FlyBird = false
        };
    }
    
    private async Task<TaskDto> GetTask(TaskWithStatusRequest taskWithStatusRequest)
    {
        var request = new RestRequest($"/api/v3/task")
            .AddQueryParameter("projectUuid", taskWithStatusRequest.ProjectId);
        var tasks = await Client.PaginateOnce<TaskDto>(request);
        
        var task = tasks.FirstOrDefault(t => t.Uuid == taskWithStatusRequest.TaskId)
            ?? throw new Exception($"Task with ID {taskWithStatusRequest.TaskId} not found.");
        
        return task;
    }
}