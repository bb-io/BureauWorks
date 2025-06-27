namespace Apps.BWX.Webhooks.Models;

public class ProjectStatusMemoryGranular
{
    public DateTime LastPollingTime { get; set; }

    /// <summary>
    /// Key - project ID,
    /// Value - last observed previous status of the project.
    /// </summary>
    public Dictionary<string, string> ProjectsPreviousStatus { get; set; } = new();
}
