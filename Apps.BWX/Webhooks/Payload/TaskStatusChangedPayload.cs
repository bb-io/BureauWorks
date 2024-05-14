using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class TaskStatusChangedPayload : TaskAssignedEvent
{
    [Display("New status")]
    public string NewStatus { get; set; }

    [Display("Previous status")]
    public string PreviousStatus { get; set; }

}