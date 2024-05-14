using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class TaskStatusChangedPayload : TaskAssignedEvent
{
    [Display("New status")]
    [JsonProperty("new_status")]
    public string NewStatus { get; set; }

    [Display("Previous status")]
    [JsonProperty("previous_status")]
    public string PreviousStatus { get; set; }

}