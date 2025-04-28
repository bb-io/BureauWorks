using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Dtos;

public class UserDto
{
    [Display("User ID")]
    public string Uuid { get; set; } = string.Empty;
    
    [Display("Email")]
    public string Email { get; set; } = string.Empty;
    
    [Display("Name")]
    public string Name { get; set; } = string.Empty;
    
    [Display("User status")]
    public string Status { get; set; } = string.Empty;
    
    [Display("Tasks completed count")]
    public int TasksCompletedCount { get; set; }
}