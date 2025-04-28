namespace Apps.BWX.Webhooks.Models;

public class UsersMemory
{
    public DateTime LastPollingTime { get; set; }
    public List<string> UserIds { get; set; } = new();
}