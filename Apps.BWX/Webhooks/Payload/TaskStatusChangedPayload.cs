namespace Apps.BWX.Webhooks.Payload;

public class TaskStatusChangedPayload
{
    public long AcceptanceDate { get; set; }
    public long AssignDate { get; set; }
    public string AssignedByEmail { get; set; }
    public string AssignedByName { get; set; }
    public string Assignee { get; set; }
    public string AssigneeEmail { get; set; }
    public long AssigneeWordRate { get; set; }
    public long BeginIndex { get; set; }
    public long CreationTimestamp { get; set; }
    public string Creator { get; set; }
    public string CreatorEmail { get; set; }
    public long DeliveryDate { get; set; }
    public long DueDate { get; set; }
    public long EndIndex { get; set; }
    public string EventType { get; set; }
    public List<string> Files { get; set; }
    public int Id { get; set; }
    public object Instructions { get; set; }
    public double MinimumScoreRequired { get; set; }
    public string Name { get; set; }
    public string NewStatus { get; set; }
    public string PreviousStatus { get; set; }
    public List<string> ReferenceFiles { get; set; }
    public long ScheduledDate { get; set; }
    public long SkipDate { get; set; }
    public string Status { get; set; }
    public string Uuid { get; set; }
    public string Workflow { get; set; }
    public List<string> CustomFields { get; set; }
}