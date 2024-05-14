using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class NewOrgEvent
{
    [Display("Organization ID")]
    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [Display("Event type")]
    [JsonProperty("event_type")]
    public string EventType { get; set; }

    //[JsonProperty("id")]
    //public int Id { get; set; }
    public string Name { get; set; }

    [Display("Custom fields")]
    [JsonProperty("custom_fields")]
    public List<string> CustomFields { get; set; }
}