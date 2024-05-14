using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class TaskAssignedEvent
{
    [Display("Task ID")]
    public string Uuid { get; set; }

    //[Display("Acceptance date")]
    //public long AcceptanceDate { get; set; }

    //[Display("Assign date")]
    //public long AssignDate { get; set; }

    [Display("Assigned by email")]
    public string AssignedByEmail { get; set; }

    [Display("Assigned by name")]
    public string AssignedByName { get; set; }
    public string Assignee { get; set; }

    [Display("Assignee email")]
    public string AssigneeEmail { get; set; }

    [Display("Assignee word rate")]
    public double AssigneeWordRate { get; set; }

    [Display("Begin index")]
    public long BeginIndex { get; set; }

    //[Display("Creation timestamp")]
    //public long CreationTimestamp { get; set; }
    public string Creator { get; set; }

    [Display("Creator email")]
    public string CreatorEmail { get; set; }

    //[Display("Delivery date")]
    //public long DeliveryDate { get; set; }

    //[Display("Due date")]
    //public long DueDate { get; set; }

    //[Display("End index")]
    //public long EndIndex { get; set; }

    [Display("Event type")]
    public string EventType { get; set; }
    public List<string> Files { get; set; }

    //[Display("ID")]
    //public int Id { get; set; }
    public string Instructions { get; set; }

    [Display("Minimum score required")]
    public double MinimumScoreRequired { get; set; }
    public string Name { get; set; }

    [Display("Reference files")]
    public List<string> ReferenceFiles { get; set; }

    //[Display("Scheduled date")]
    //public long ScheduledDate { get; set; }

    //[Display("Skip date")]
    //public long SkipDate { get; set; }
    public string Status { get; set; }
    public string Workflow { get; set; }

    [Display("Custom fields")]
    public List<string> CustomFields { get; set; }
}