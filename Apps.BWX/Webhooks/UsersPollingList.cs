using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Apps.BWX.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;

namespace Apps.BWX.Webhooks;

[PollingEventList]
public class UsersPollingList(InvocationContext invocationContext) : BWXInvocable(invocationContext)
{
    [PollingEvent("On users created", Description = "Polling event that periodically checks for new users. If a new users are found, it will return the new users.")]
    public async Task<PollingEventResponse<UsersMemory, UsersResponse>> OnUsersCreated(PollingEventRequest<UsersMemory> pollingRequest)
    {
        var isFirstRun = pollingRequest.Memory == null;
        var memory = InitializeMemory(pollingRequest.Memory);
        
        var request = new RestRequest("/api/v3/user");
        var users = await Client.Paginate<UserDto>(request);
        
        var newUsers = FilterNewUsers(users, memory.UserIds);
        UpdateMemory(memory, newUsers);
        
        return new PollingEventResponse<UsersMemory, UsersResponse>
        {
            Result = new(newUsers),
            Memory = memory,
            FlyBird = isFirstRun ? false : newUsers.Any()
        };
    }
    
    private UsersMemory InitializeMemory(UsersMemory? existingMemory)
    {
        return existingMemory ?? new UsersMemory
        {
            LastPollingTime = DateTime.UtcNow,
            UserIds = []
        };
    }
    
    private List<UserDto> FilterNewUsers(List<UserDto> allUsers, List<string> existingUserIds)
    {
        return allUsers
            .Where(p => !existingUserIds.Contains(p.Uuid))
            .ToList();
    }
    
    private void UpdateMemory(UsersMemory memory, List<UserDto> newUsers)
    {
        foreach (var user in newUsers)
        {
            memory.UserIds.Add(user.Uuid);
        }
        
        memory.LastPollingTime = DateTime.UtcNow;
    }
}