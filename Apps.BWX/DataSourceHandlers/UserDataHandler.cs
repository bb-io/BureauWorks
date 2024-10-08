﻿using Apps.BWX.Dtos;
using Apps.BWX.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.DataSourceHandlers;

public class UserDataHandler(InvocationContext invocationContext)
    : BWXInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken token)
    {
        var request = new RestRequest($"/api/v3/user", Method.Get);
        request.AddQueryParameter("simple", "true");
        request.AddQueryParameter("name", context.SearchString);
        var users = await Client.PaginateOnce<UserDto>(request);

        return users.ToDictionary(k => k.Uuid, v => v.Name);
    }
}