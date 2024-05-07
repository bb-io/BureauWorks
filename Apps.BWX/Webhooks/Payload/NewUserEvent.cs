using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Webhooks.Payload;

public class NewUserEvent
{
    public string Country { get; set; }

    [Display("Event type")]
    public string EventType { get; set; }

    [Display("ID")]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> Role { get; set; }
    public string Status { get; set; }

    [Display("UUID")]
    public string Uuid { get; set; }

    [Display("Custom fields")]
    public List<string> CustomFields { get; set; }
}