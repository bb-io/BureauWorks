using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.BWX.Webhooks.Payload;

public class NewUserEvent
{
    [Display("User ID")]
    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [Display("Event type")]
    [JsonProperty("event_type")]
    public string EventType { get; set; }

    //[Display("ID")]
    //[JsonProperty("id")]
    //public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [Display("Roles")]
    [JsonProperty("role")]
    public List<string> Role { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [Display("Custom fields")]
    [JsonProperty("custom_fields")]
    public List<string> CustomFields { get; set; }
}