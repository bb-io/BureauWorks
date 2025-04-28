namespace Apps.BWX.Webhooks.Models;

public class ProjectsMemory
{
    public DateTime LastPollingTime { get; set; }
    public List<string> ProjectIds { get; set; } = new();
}
