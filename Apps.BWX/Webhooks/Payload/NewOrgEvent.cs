using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class NewOrgEvent
{
    public string Country { get; set; }

    [Display("Event type")]
    public string EventType { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }

    [Display("UUID")]
    public string Uuid { get; set; }

    [Display("Custom fields")]
    public List<string> CustomFields { get; set; }
}