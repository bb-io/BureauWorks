using Apps.BWX.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Models;

public class UsersResponse(List<UserDto> users)
{
    [Display("Users")]
    public List<UserDto> Users { get; set; } = users;

    [Display("Total count")]
    public double TotalCount { get; set; } = users.Count;
}