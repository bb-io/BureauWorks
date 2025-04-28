namespace Apps.BWX.Webhooks.Models;

public class ProjectStatusMemory
{
    public string PreviousStatus { get; set; } = string.Empty;
    public bool WasTriggered { get; set; }
}